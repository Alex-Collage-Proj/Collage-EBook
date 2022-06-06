using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
                      
            try
            {

                if (Session["role"] == null || Session["role"].ToString() != "user")
                {
                    Response.Redirect("HomePage.aspx");
                }


                if (Session["role"].ToString()=="user")
                {
                    if (Session["Email"].ToString() == "" || Session["Email"] == null)
                    {
                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("Login.aspx");
                    }

                    else
                    {
                        //getUserData();                       
                        if (!Page.IsPostBack)
                        {
                            getUserPersonalDetails();
                        }
                    }
                }
          
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
                //Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }


        // update button click
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["Email"].ToString() == "" || Session["Email"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
            }

            else
            {
                updateUserPesonalDetails();
            }
        }

        // user defined fucntion


        void updateUserPesonalDetails()
        {
            string password = "";
            if(TextBox5.Text.Trim() =="")
            {
                password = SignPassword.Text.Trim();
            }
            else
            {
                password = ComputeSha256Hash(TextBox5.Text.Trim());
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update Customer_tbl set Customer_Fname=@Customer_Fname," +
                    " Customer_Lname=@Customer_Lname, Phone_num=@Phone_num, Email=@Email, Pass=@Pass WHERE Email='"+ Session["Email"].ToString().Trim() + "'",con);

                cmd.Parameters.AddWithValue("@Customer_Fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Customer_Lname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_num", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Pass", password);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if(result>0)
                {
                    getUserPersonalDetails();
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");                  
                    //getUserData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid entry');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        void getUserPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Customer_tbl where Email='" + Session["Email"] + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["Customer_Fname"].ToString();
                TextBox2.Text = dt.Rows[0]["Customer_Lname"].ToString();
                TextBox3.Text = dt.Rows[0]["Phone_num"].ToString();
                TextBox4.Text = dt.Rows[0]["Email"].ToString();
                SignPassword.Text = dt.Rows[0]["Pass"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //void getUserData()
        //{
        //    try
        //    {
        //        SqlConnection con = new SqlConnection(strcon);
        //        if (con.State == ConnectionState.Closed)
        //        {
        //            con.Open();
        //        }

        //        SqlCommand cmd = new SqlCommand("select * from Book_tbl /*where Customer_id='" + Session["CustomerID"] + "';*/", con);
        //        SqlDataAdapter da = new SqlDataAdapter(cmd);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);

        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //    }
        //    catch(Exception ex)
        //    {
        //        Response.Write("<script>alert('" + ex.Message + "');</script>");
        //    }

        //}

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}