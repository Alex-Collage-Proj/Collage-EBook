using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        string s, t;
        string[] a = new string[100];
        int id, Book_id, c2;
        string Book_Name, Sell_Price, Format, Book_image;
        string Cookies21;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Cart.aspx");
            }
            else
            {
                id = Convert.ToInt32(Request.QueryString["id"].ToString());
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[5] { new DataColumn("Book_Name"), new DataColumn("Sell_Price"), new DataColumn("Format"),new DataColumn("Book_image"), new DataColumn("id") });

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
                            Cookies21 = strArr1[j].ToString();
                        }



                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(),a[3].ToString(), i.ToString());


                    }

                }

                Console.WriteLine(dt.Rows.Count);
                dt.Rows[id].Delete();
                Console.WriteLine(dt.Rows.Count);


                Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);



                foreach (DataRow dr in dt.Rows)
                {
                    Book_Name = dr["Book_Name"].ToString();
                    Sell_Price = dr["Sell_Price"].ToString();
                    Format = dr["Format"].ToString();
                    Book_image = dr["Book_image"].ToString();
                    id = Convert.ToInt32(dr["id"].ToString());
                    //Book_image = dr["Book_image"].ToString();
                    //Book_Desc = dr["Book_Desc"].ToString();


                    count = count + 1;


                    if (count == 1)
                    {
                        Response.Cookies["aa"].Value = Book_Name.ToString() + "^" + Sell_Price.ToString()
                            + "^" + Format.ToString() + "^" + Book_image.ToString()+"^"+ id.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);

                    }

                    else
                    {

                        Response.Cookies["aa"].Value = Response.Cookies["aa"].Value + "|" + Book_Name.ToString()
                        + "^" + Sell_Price.ToString() + "^" + Format.ToString() + "^"+ Book_image.ToString() + "^" + id.ToString();
                        Response.Cookies["aa"].Expires = DateTime.Now.AddDays(1);

                    }
                }


            }
            Response.Redirect("Cart.aspx");
        }
    }
}