using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string PhoneNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            
               
            
            try
            {

                if (Session["role"] == null || Session["role"].ToString() != "admin")
                {
                    Response.Redirect("HomePage.aspx");

                }
                else
                {
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("HomePage.aspx");
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }

        protected void OrderGo_Click(object sender, EventArgs e)
        {
            getOrderbyID();
        }

       void getOrderbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Order_tbl where Order_Id='" + OrderID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    CustomerID.Text = dt.Rows[0]["Customer_Id"].ToString();
                    OrderD.Text = dt.Rows[0]["Order_Date"].ToString().Trim();
                    Status.Text = dt.Rows[0]["Order_Status"].ToString().Trim();              

                }
                else
                {
                    Response.Write("<script>alert('Invalid Order ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void StatusYes_Click(object sender, EventArgs e)
        {
            UpdateStatusByOrderID();
        }

        void UpdateStatusByOrderID()
        {
            if (CheckIfOrderExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("update Order_tbl set Order_Status=@Order_Status where Order_Id ='" + OrderID.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Order_Status", Status.Text.Trim());
                    cmd.ExecuteNonQuery();


                    if (Status.Text.Trim() == "1")
                    {
                        SqlCommand cmd1 = new SqlCommand("Select Order_Id, Customer_tbl.Customer_Id, Phone_num, Order_Status from Customer_tbl join Order_tbl on Customer_tbl.Customer_Id = Order_tbl.Customer_Id where Order_Id = '" + OrderID.Text.Trim() + "' and Order_Status = 1", con);
                        SqlDataAdapter da = new SqlDataAdapter(cmd1);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count >= 1)
                        {
                            PhoneNum = dt.Rows[0]["Phone_num"].ToString();

                            string URI = "https://www.sms4free.co.il/ApiSMS/SendSMS";
                            WebClient wc = new WebClient();
                            string key = "7H4GpJgFN";
                            string user = "" + PhoneNum + "";
                            string pass = "41214871";
                            string sender = "Ebook";
                            string recipient = "0544754889";
                            string msg = "Hello, Your order has been reviewed and accepeted please visit your downloads";
                            string myParameters = $"key={key}&user={user}&pass={pass}&sender={sender}&recipient={recipient}&msg={msg}";
                            wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                            string HtmlResult = wc.UploadString(URI, myParameters);


                        }
                    }






                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Order Status updated Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

       bool CheckIfOrderExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from Order_tbl where Order_Id='" +
                    OrderID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
    }
}