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
    public partial class WebForm13 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        string s, t, Format, Book_Name, Sell_Price, Book_image;
        string[] a = new string[100];
        int id, Book_id;
        int Countp = 0;
        double Total = 0;

        protected void Buy_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Book_tbl where Book_id = '" + id + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Book_Name = dr["Book_Name"].ToString();
                Sell_Price = dr["Sell_Price"].ToString();
                Format = dr["Format"].ToString();
                Book_image = dr["Book_image"].ToString();
                id = Convert.ToInt32(dr["Book_id"].ToString());
                Book_id = Convert.ToInt32(dr["Book_id"].ToString());
                //Book_image = dr["Book_image"].ToString();
                //Book_Desc = dr["Book_Desc"].ToString();  

            }
            con.Close();

            string s, t;
            string[] a = new string[100];


            Response.Cookies["bb"].Value = Request.Cookies["aa"].Value;



            Response.Redirect("AcceptOrder.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {

           
                if (Session["role"] == null || Session["role"].ToString() != "user")
                {
                    Response.Redirect("HomePage.aspx");
                }
            else
            {

                if (Request.Cookies["aa"] != null)
                {
                    EmptyCart.Visible = false;

                }
                if (Request.Cookies["aa"] == null)
                {
                    Tot.Visible = false;
                }



                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Book_Name"), new DataColumn("Sell_Price"), new DataColumn("Format"), new DataColumn("Book_image"), new DataColumn("id") });

                if (Request.Cookies["aa"] != null)
                {
                    s = Convert.ToString(Request.Cookies["aa"].Value);

                    string[] strArr = s.Split('|');

                    for (int i = 0; i < strArr.Length; i++)
                    {
                        t = Convert.ToString(strArr[i].ToString());
                        string[] strArr1 = t.Split('^');
                        for (int j = 0; j < strArr1.Length; j++)
                        {
                            a[j] = strArr1[j].ToString();
                        }




                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), i.ToString());
                        Total = Total + Convert.ToDouble(a[1].ToString());



                    }

                }

                d1.DataSource = dt;
                d1.DataBind();
                ToTCPrice.Text = Total.ToString();
            }


        }

      
        //    -------------------Checking Buttons----------------------------------------------
        //protected void testing_Click(object sender, EventArgs e)
        //{
        //    if (Request.Cookies["aa"] != null)
        //    {
        //        s = Convert.ToString(Request.Cookies["aa"].Value);
        //        string[] strArr = s.Split('.');
        //        for (int i = 0; i < strArr.Length; i++)
        //        {
        //            Response.Write(strArr[i].ToString());
        //            Response.Write("<br>");
        //        }
        //    }

        //}
    }
}