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
    public partial class WebForm12 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
         
            try
            {
                
                    if (Session["role"] == null || Session["role"].ToString() != "admin")
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                

                if (Session["role"].ToString() == "admin")
                {
                    if (Session["UserName"].ToString() == "" || Session["UserName"] == null)
                    {
                        Response.Write("<script>alert('Session Expired Login Again');</script>");
                        Response.Redirect("AdminLogin.aspx");
                    }
                    else
                    {
                        //getUserData();
                        if (!Page.IsPostBack)
                        {
                            getAdminPersonalDetails();
                        }
                    }
                }
      

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("HomePage.aspx");
                //Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }

        protected void PassUpdateA_Click(object sender, EventArgs e)
        {
            if (Session["UserName"].ToString() == "" || Session["UserName"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
            }

            else
            {
                updateAdminPesonalDetails();
            }
        }

        void updateAdminPesonalDetails()
        {
            string password = "";
            if (Apass1.Text.Trim() == "")
            {
                password = SignPassword1.Text.Trim();
            }
            else
            {
                password = ComputeSha256Hash(Apass1.Text.Trim());
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("update Admin_table set UserName=@UserName," +
                    "  Password=@Password, Admin_Fname=@Admin_Fname WHERE UserName='" + Session["UserName"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@UserName", TextBox4.Text.Trim());    
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Admin_Fname", TextBox1.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                    getAdminPersonalDetails();
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
        void getAdminPersonalDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Admin_table where UserName='" + Session["UserName"] + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                TextBox4.Text = dt.Rows[0]["UserName"].ToString();
                SignPassword1.Text = dt.Rows[0]["Password"].ToString();
                TextBox1.Text = dt.Rows[0]["Admin_Fname"].ToString();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

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