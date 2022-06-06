using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath, global_filepath2;
        static int[] global_numbers = new int[100];
        

        protected void Page_Load(object sender, EventArgs e)
        {
          
            try
            {

                
                    if (Session["role"] == null || Session["role"].ToString() != "admin")
                    {
                        Response.Redirect("HomePage.aspx");
                    }
                    else
                    {

                        GridView1.DataBind();
                    }
                

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("Login.aspx");
                //Response.Write("<script>alert('" + ex.Message + "');</script>");


            }


        }
        // Go button
        protected void Button4_Click(object sender, EventArgs e)
        {
            getBookByID();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exist');</script>");
            }
            else
            {
                addNewBook();
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            deleteBookByID();
        }


        protected void AddGenre_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                foreach (int i in GenreList.GetSelectedIndices())
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO BookGenre_tbl(Genre_id,Book_id) values(@Genre_id,@Book_id)", con);
                    cmd2.Parameters.AddWithValue("@Genre_id", GenreList.Items[i].Value);
                    cmd2.Parameters.AddWithValue("@Book_id", BookId.Text.Trim());
                    cmd2.ExecuteNonQuery();
                }
                Response.Write("<script>alert('Genre added successfully');</script>");

                GridView1.DataBind();
                con.Close();
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
           
        }

        protected void DeleteGenre_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                   
                    SqlCommand cmd2 = new SqlCommand("DELETE from BookGenre_tbl where Book_id = '" + BookId.Text.Trim() + "'", con);

                    
                    cmd2.ExecuteNonQuery();

                    con.Close();
                    Response.Write("<script>alert('Book Genre Deleted Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }



        bool checkIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from Book_tbl where Book_id='" +
                    BookId.Text.Trim()+"' OR Book_Name='"+BookName.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkIfBookInOrder()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select BookOrders_tbl.Book_Id from Book_tbl join BookOrders_tbl on Book_tbl.Book_id = BookOrders_tbl.Book_Id where BookOrders_tbl.Book_Id ='"+BookId.Text.Trim()+ "'" , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
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

        void addNewBook()
        {
            try
            {
                string filepath = "/images/Books.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("images/" + filename));
                filepath = "/images/" + filename;

                string filepath2 = "/Pdf/2.pdf";
                string filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                FileUpload2.SaveAs(Server.MapPath("Pdf/" + filename2));
                filepath2 = "/Pdf/" + filename2;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Book_tbl(Book_id,Book_Name,Buy_Price,Sell_Price,Format,PageNum,Sup_Id,Book_Desc,Book_image,Pdf)" +
                    "values(@Book_id,@Book_Name,@Buy_Price,@Sell_Price,@Format,@PageNum,@Sup_Id,@Book_Desc,@Book_image,@Pdf)", con);
                

                cmd.Parameters.AddWithValue("@Book_id", BookId.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Name", BookName.Text.Trim());

                cmd.Parameters.AddWithValue("@Buy_Price", BuyPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@Sell_Price", SellPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@Format", Format.Text.Trim());
                cmd.Parameters.AddWithValue("@PageNum", Pagenum.Text.Trim());
                cmd.Parameters.AddWithValue("@Sup_Id", Supid.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_Desc", BookDesc.Text.Trim());
                cmd.Parameters.AddWithValue("@Book_image", filepath);
                cmd.Parameters.AddWithValue("@Pdf", filepath2);
                

                foreach (int i in GenreList.GetSelectedIndices())
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO BookGenre_tbl(Genre_id,Book_id) values(@Genre_id,@Book_id)", con);
                    cmd2.Parameters.AddWithValue("@Genre_id", GenreList.Items[i].Value);
                    cmd2.Parameters.AddWithValue("@Book_id", BookId.Text.Trim());
                    cmd2.ExecuteNonQuery();
                }


                cmd.ExecuteNonQuery();
                GridView1.DataBind();


                Response.Write("<script>alert('Book added successfully');</script>");
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                
            }
        }

       void getBookByID()
        {
            int b = 0;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select bt.Book_id, bt.Book_Name ,Buy_Price , Sell_Price, bt.Format, bt.PageNum, bt.Sup_Id, Book_Desc, Book_image, Pdf," +
                "STUFF((select  distinct + ',' + Genre_Name from Genre_tbl join BookGenre_tbl on Genre_tbl.Genre_id = BookGenre_tbl.Genre_id" +
                " join Book_tbl on BookGenre_tbl.Book_id = bt.Book_id for xml path('')), 1, 1, '') [Genre Name] from Book_tbl bt group by bt.Book_id, bt.Book_Name, bt.Format, Sell_Price,bt.PageNum, bt.Book_Desc, bt.Book_image, Pdf, Buy_Price, bt.Sup_Id having bt.Book_id = '" + BookId.Text.Trim() + "'"
                    , con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>=1)
                {
                    BookName.Text = dt.Rows[0]["Book_Name"].ToString();
                    Supid.Text = dt.Rows[0]["Sup_Id"].ToString().Trim();
                    BuyPrice.Text = dt.Rows[0]["Buy_Price"].ToString().Trim();
                    Format.Text = dt.Rows[0]["Format"].ToString();
                    SellPrice.Text = dt.Rows[0]["Sell_Price"].ToString().Trim();
                    Pagenum.Text = dt.Rows[0]["PageNum"].ToString().Trim();
                    BookDesc.Text = dt.Rows[0]["Book_Desc"].ToString();

                    GenreList.ClearSelection();
                    string[] genre = dt.Rows[0]["Genre Name"].ToString().Trim().Split(',');
                    for(int i = 0; i<genre.Length;i++)
                    {
                        for(int j = 0; j<GenreList.Items.Count; j++)
                        {
                            if(GenreList.Items[j].ToString() == genre[i])
                            {
                                GenreList.Items[j].Selected = true;
                            }
                          
                        }

                    }
                    global_filepath = dt.Rows[0]["Book_image"].ToString();
                    global_filepath2 = dt.Rows[0]["Pdf"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");              
            }
            Array.Clear(global_numbers, 0, global_numbers.Length);
            foreach (int i in GenreList.GetSelectedIndices())
            {               
                global_numbers[b] = int.Parse(GenreList.Items[i].Value);
                b = b + 1;
            }
            Array.ForEach(global_numbers, Console.WriteLine);

        }

        void updateBookByID()
        {
            int b = 0;
            if (checkIfBookExists())
            {
                try
                {
                    string filepath = "/images/Books.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename =="" || filename ==null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("images/" + filename));
                        filepath = "/images/" + filename;
                    }


                    string filepath2 = "/Pdf/Test.pdf";
                    string filename2 = Path.GetFileName(FileUpload2.PostedFile.FileName);
                    if (filename2 == "" || filename2 == null)
                    {
                        filepath2 = global_filepath2;
                        
                    }
                    else
                    {
                        FileUpload2.SaveAs(Server.MapPath("Pdf/" + filename2));
                        filepath2 = "/Pdf/" + filename2;
                    }


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    //Book_id,Book_Name,Buy_Price,Sell_Price,Format,PageNum,Sup_Id,Book_Desc,Book_image

                    SqlCommand cmd = new SqlCommand("update Book_tbl set Book_Name=@Book_Name, Buy_Price=@Buy_Price, Sell_Price=@Sell_Price, " +
                        "Format=@Format, PageNum=@PageNum, Sup_Id=@Sup_Id, Book_Desc=@Book_Desc, Book_image=@Book_image, Pdf=@Pdf where Book_id ='" + BookId.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Book_Name", BookName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Buy_Price", BuyPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sell_Price", SellPrice.Text.Trim());
                    cmd.Parameters.AddWithValue("@Format", Format.Text.Trim());
                    cmd.Parameters.AddWithValue("@PageNum", Pagenum.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sup_Id", Supid.Text.Trim());
                    cmd.Parameters.AddWithValue("@Book_Desc", BookDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@Book_image", filepath);
                    cmd.Parameters.AddWithValue("@Pdf", filepath2);



                    //"Select * from Book_tbl where Book_id='"bookId.Text.Trim() + "' OR Book_Name='" + BookName.Text.Trim() + "';", con);
                    foreach (int i in GenreList.GetSelectedIndices())
                        {
                        Array.ForEach(GenreList.GetSelectedIndices(), Console.WriteLine);

                        SqlCommand cmd2 = new SqlCommand("UPDATE BookGenre_tbl set Genre_id = @Genre_id where Book_id ='" + BookId.Text.Trim() + "' and Genre_id = '"+ global_numbers[b]+"';", con);
                             cmd2.Parameters.AddWithValue("@Genre_id", GenreList.Items[i].Value);
                             cmd2.ExecuteNonQuery();
                        b=b+1;
                    }

                    b = 0;
                    Array.Clear(global_numbers, 0, global_numbers.Length);
                    foreach (int i in GenreList.GetSelectedIndices())
                    {
                        global_numbers[b] = int.Parse(GenreList.Items[i].Value);
                        b = b + 1;
                    }
                    b = 0;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Book updated Successfully');</script>");

                    
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        void deleteBookByID()
        {
            if(checkIfBookExists())
            {
                if(checkIfBookInOrder() == false)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("DELETE from Book_tbl where Book_id = '" + BookId.Text.Trim() + "'", con);
                        SqlCommand cmd2 = new SqlCommand("DELETE from BookGenre_tbl where Book_id = '" + BookId.Text.Trim() + "'", con);

                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();

                        con.Close();
                        Response.Write("<script>alert('Book Deleted Successfully');</script>");
                        GridView1.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Cannot delete a Book that exists in an order');</script>");
                }
                
            }
        }

     
    }
}