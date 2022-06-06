using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // sign up button click event
        protected void SignU(object sender, EventArgs e)
        {
            //  Response.Write("<script>alert('Testing');</script>");

            if(checkUserExists())
            {
                Response.Write("<script>alert('Email already exists, please try a different email.');</script>");
            }
            else
            {
                signUpNewUser();             
            }
            
          
        }

        // user defined method

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Customer_tbl where Email = '"+TextBox4.Text.Trim()+"'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>=1)
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


        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("insert into Customer_tbl(Customer_Fname,Customer_Lname,Phone_num,Email,Pass) values(@Customer_Fname,@Customer_Lname,@Phone_num,@Email,@Pass)", con);


                cmd.Parameters.AddWithValue("@Customer_Fname", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Customer_Lname", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Phone_num", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Pass", ComputeSha256Hash(SignPassword.Text.Trim()));







                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Sign Up Successful.  Go to User Login to Login');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

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