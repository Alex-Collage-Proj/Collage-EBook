using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;



namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");


        protected void Page_Load(object sender, EventArgs e)
        {
            Select();
            SelectC();

            try
            {
                if (Session["role"] == null)
                {
                    Zaner_Repeater.Visible = false;
                    Reco_Zan.Visible = false;
                }
                else if (Session["role"].Equals("user"))
                {
                    Zaner_Repeater.Visible = true;
                    if (check_orders() != 1)
                    {
                        Reco_Zan.Visible = false;
                    }
                    else
                    {
                        Reco_Zan.Visible = true;
                    }

                }
                else if (Session["role"].Equals("admin"))
                {
                    Zaner_Repeater.Visible = false;
                    Reco_Zan.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }


            if (Session["role"] != null && !Session["role"].Equals("admin") && Session["role"].Equals("user"))
            {
                try
                {

                    // SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    //try//

                    string Ganer_All1 = "";
                    int i = 0;
                    int[] Ganer;

                    SqlCommand cmd3 = new SqlCommand("select * from Genre_tbl", con);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    Ganer = new int[dt3.Rows.Count];
                    foreach (DataRow dr in dt3.Rows)
                    {
                        Ganer[i] = Convert.ToInt32(dr["Genre_id"].ToString());
                        // checking
                        //Response.Write("<br> Check:");
                        //Response.Write(Ganer[i]);
                        //Ganer_All1 = "" + Ganer_All1 + "|"+ dr["Genre_id"].ToString();
                        // checking
                        i++;
                    }
                    Ganer_All1 = "" + Ganer_All1 + "|";
                    // checking
                    //Response.Write(Ganer_All1);
                    //Response.Write("<br>");
                    //Response.Write(("Ganer Tot:"+dt3.Rows.Count).ToString());
                    // checking

                    int[] Ganer_from_order;
                    int[] Count_Ganer_Biggest = { 0 };
                    int Ganer_Big = 0, Remmmber_location_Big = 0;
                    Count_Ganer_Biggest = new int[dt3.Rows.Count];
                    i = 0;


                    // SqlCommand cmd2 = new SqlCommand("select BookOrders_tbl.Order_Id,BookOrders_tbl.Book_Id, Book_tbl.Book_image,Book_tbl.Sell_Price,Order_Date,Pdf, Book_Name from Order_tbl join BookOrders_tbl on Order_tbl.Order_Id = BookOrders_tbl.Order_Id join Book_tbl on BookOrders_tbl.Book_Id = Book_tbl.Book_id where Customer_Id = " + Session["CustomerID"] + " and Order_Status = 1 andBook_tbl.Book_id=Order_tbl.Order_Id ", con2);
                    SqlCommand cmd2 = new SqlCommand("select  BookGenre_tbl.Genre_id,BookOrders_tbl.Order_Id,BookOrders_tbl.Book_Id, Book_tbl.Book_image,Book_tbl.Sell_Price,Order_Date,Pdf, Book_Name  from Order_tbl join BookOrders_tbl on Order_tbl.Order_Id = BookOrders_tbl.Order_Id join Book_tbl on BookOrders_tbl.Book_Id = Book_tbl.Book_id join BookGenre_tbl on Book_tbl.Book_id = BookGenre_tbl.Book_id where Customer_Id = " + Session["CustomerID"] + "  and Order_Status = 1 and Book_tbl.Book_id=BookOrders_tbl.Book_Id", con);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    Ganer_from_order = new int[dt2.Rows.Count];
                    foreach (DataRow dr in dt2.Rows)
                    {
                        Ganer_from_order[i] = Convert.ToInt32(dr["Genre_id"].ToString());
                        //checking
                        //Response.Write("<br> Check:");
                        //Response.Write(Ganer_from_order[i]);
                        //checking
                        i++;
                    }
                    //checking
                    //Response.Write("<br>"); Response.Write("<br>");
                    //checking
                    int j = 0;
                    for (i = 0; i < dt3.Rows.Count; i++)
                    {
                        //checking
                        //Response.Write("Checking By Order" + Ganer[i] + ":");
                        //checking
                        for (j = 0; j < dt2.Rows.Count; j++)
                        {
                            if (Ganer[i] == Ganer_from_order[j])
                            {
                                Count_Ganer_Biggest[i]++;
                            }
                        }
                        j = 0;
                        //checking
                        //Response.Write(Count_Ganer_Biggest[i] + ",");
                        //Response.Write("<br>");
                        //checking
                    }

                    Ganer_Big = Count_Ganer_Biggest[0];



                    for (i = 0; i < dt3.Rows.Count; i++)
                    {
                        if (Ganer_Big < Count_Ganer_Biggest[i])
                        {
                            Ganer_Big = Count_Ganer_Biggest[i];
                            Remmmber_location_Big = i + 1;
                        }
                        if (Ganer_Big == Count_Ganer_Biggest[i] && Count_Ganer_Biggest[0] != 0)
                        {
                            Remmmber_location_Big = i + 1;
                        }
                    }
                    //checking
                    //Response.Write("<br>");
                    //Response.Write("Loc:" + Remmmber_location_Big + ", How Much Same Gan:" + Ganer_Big);
                    //checking


                    SqlCommand cmd1 = new SqlCommand("select DISTINCT top (8) * from Book_tbl join BookGenre_tbl on Book_tbl.Book_id = BookGenre_tbl.Book_id where BookGenre_tbl.Genre_id=" + Remmmber_location_Big, con);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    Zaner_Repeater.DataSource = dt1;
                    Zaner_Repeater.DataBind();
                    con.Close();



                    //try//

                }
                catch (Exception ex)
                {

                }
            }


        }



        void SelectC()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select top (4) * from Book_tbl order by Book_id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            Carouseld1.DataSource = dt;
            Carouseld1.DataBind();        
            con.Close();
        }

        void Select()
        {
            SqlConnection con = new SqlConnection(strcon);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select top (8) * from Book_tbl order by Book_id desc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);          
            d1.DataSource = dt;
            d1.DataBind();
            con.Close();
        }
        int check_orders()
        {
            try
            {
                int flag = 0;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select  BookGenre_tbl.Genre_id,BookOrders_tbl.Order_Id,BookOrders_tbl.Book_Id, Book_tbl.Book_image,Book_tbl.Sell_Price,Order_Date,Pdf, Book_Name  from Order_tbl join BookOrders_tbl on Order_tbl.Order_Id = BookOrders_tbl.Order_Id join Book_tbl on BookOrders_tbl.Book_Id = Book_tbl.Book_id join BookGenre_tbl on Book_tbl.Book_id = BookGenre_tbl.Book_id where Customer_Id = " + Session["CustomerID"] + "  and Order_Status = 1 and Book_tbl.Book_id=BookOrders_tbl.Book_Id", con);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    return flag = 1;
                    
                }
                else
                {
                    return flag = 0;                   
                }
                

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}