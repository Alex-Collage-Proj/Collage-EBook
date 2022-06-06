using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string Order_Id, Order_id_to_download = "";
        int Book_count, Order_Book_count;
        string[] Book_Id, Data_comparison_id_books, Data_comparison_orders, Equal_id, Download_Jpg_Name, Book_name, All_images;

        protected void Send_To_Downloag_Page_Click(object sender, EventArgs e)
        {
            int Book_id = Convert.ToInt32((sender as LinkButton).CommandArgument);
            Session["Book_Id"] = Book_id;
            Response.Redirect("Download_Book.aspx");
        }

        int Check_first_time = 1;



        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");
        void getUserData()
        {

            try
            {
                // SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select BookOrders_tbl.Order_Id,BookOrders_tbl.Book_Id,Order_Date,Pdf, Book_Name from Order_tbl join BookOrders_tbl on Order_tbl.Order_Id = BookOrders_tbl.Order_Id join Book_tbl on BookOrders_tbl.Book_Id = Book_tbl.Book_id where Customer_Id = " + Session["CustomerID"] + " and Order_Status = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt1 = new DataTable();
                DataTable dt = new DataTable();
                da.Fill(dt1);
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                con.Close();





            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }



        protected void Page_Load(object sender, EventArgs e)
        {
            
               
            
            try
            {
                if (Session["role"] == null || Session["role"].Equals("admin"))
                {
                    Response.Redirect("HomePage.aspx");
                }

                if (Session["role"].ToString() == "user")
                {
                    if (Session["Email"].ToString() == "" || Session["Email"] == null)
                    {
                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        getUserData();
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            Response.Write(Order_id_to_download);






        }


    }
}