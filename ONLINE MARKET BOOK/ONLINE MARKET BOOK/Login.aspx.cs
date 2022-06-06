using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // user login
        protected void LogI(object sender, EventArgs e)
        {
            //  Response.Write("<script>alert('Sign Up Successful.  Go to User Login to Login');</script>");

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("select * from Customer_tbl where Email = '" + inputEmail.Text.Trim() + "' and Pass = '" + ComputeSha256Hash(inputPassword.Text.Trim()) + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read()) // 
                    {
                       
                        Session["Email"] = dr.GetValue(4);
                        Session["CustomerID"] = dr.GetValue(0);
                        Session["Fname"] = dr.GetValue(1);
                        Session["role"] = "user";


                    }
                    Response.Write("<script>alert('Login Successful');</script>");
                    Response.Redirect("HomePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('User is not in the system');</script>");
                }


            }
            catch(Exception ex)
            {

            }


        }

        // user defined functions
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