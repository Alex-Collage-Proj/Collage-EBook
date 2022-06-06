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
    public partial class WebForm22 : System.Web.UI.Page
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

                LtlLabels.Text = "'DATA'";
                LtlLabel.Text = "'Sum of Sales'";
                LtlData.Text = "'0'";  // from sql           
                LtlData1.Text = "'0'"; // from sql

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                Response.Redirect("HomePage.aspx");
            }

        }

        protected void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                
                

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select count(Order_tbl.Order_Id) as [Amount Of Orders] ,Sum(Order_tbl.Total_Price) as [Sum Of Price] FROM Order_tbl WHERE convert(varchar(20), Order_Date, 102) between '" + StartDate.Value.ToString() + "' and '" + EndDate.Value.ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                CountOfOrders.Text = dt.Rows[0]["Amount Of Orders"].ToString();
                SumOfAllOrders.Text = dt.Rows[0]["Sum Of Price"].ToString();

                con.Close();

                LtlData.Text = dt.Rows[0]["Amount Of Orders"].ToString();  // from sql           
                LtlData1.Text = dt.Rows[0]["Sum Of Price"].ToString(); // from sql


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

            
        }
    }
}