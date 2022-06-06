using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int id, Book_id;
        String Book_Name, Sell_Price, Format, Book_image;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    AddToCart.Visible = false;

                }
                else if (Session["role"].Equals("user"))
                {
                    AddToCart.Visible = true;
                }

                else if (Session["role"].Equals("admin"))
                {

                    AddToCart.Visible = false;

                }
            }
            catch (Exception ex)
            {

            }






            id = Convert.ToInt32(Request.QueryString["id"].ToString());
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            SqlCommand cmd1 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            
            cmd.CommandText = "Select bt.Book_id, bt.Book_Name ,Buy_Price , Sell_Price, bt.Format, bt.PageNum, Book_Desc, Book_image," +
                "STUFF((select  distinct + ', ' + Genre_Name from Genre_tbl join BookGenre_tbl on Genre_tbl.Genre_id = BookGenre_tbl.Genre_id" +
                " join Book_tbl on BookGenre_tbl.Book_id = bt.Book_id for xml path('')), 1, 1, '') [Genre Name] from Book_tbl bt group by bt.Book_id, bt.Book_Name, bt.Format, Sell_Price,bt.PageNum, bt.Book_Desc, bt.Book_image, Buy_Price having bt.Book_id = '" + id + "'";


            cmd.ExecuteNonQuery();
            

            DataTable dt = new DataTable();
            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            

            da.Fill(dt);  

            d1.DataSource = dt;
            d1.DataBind();

            con.Close();
        }

        protected void AddToCart_Click(object sender, EventArgs e)
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





            //new cookies****
            if (Request.Cookies["aa"] == null)
            {

                Response.Cookies["aa"].Value = Book_Name.ToString() + "^" + Sell_Price.ToString()
                   + "^" + Format.ToString()+ "^" + Book_image.ToString() + "^" + id.ToString();
                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                

            }
            else
            {
                bool exist = false;

                //dt.Rows.Add("a0", "a1", "a2", "a3");
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

                        if (a[4].ToString() == id.ToString())
                        {
                            exist = true;
                        }

                    }

                }

                if (!exist)
                {

                    Response.Cookies["aa"].Value = Request.Cookies["aa"].Value + "|" + Book_Name.ToString()
                        + "^" + Sell_Price.ToString() + "^" + Format.ToString() + "^" +Book_image.ToString() +"^" + id.ToString();
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);
                }
            }
            Response.Redirect("Cart.aspx");
        }
    }
}