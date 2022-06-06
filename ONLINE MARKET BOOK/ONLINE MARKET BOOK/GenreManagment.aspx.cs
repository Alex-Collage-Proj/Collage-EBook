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
    public partial class WebForm15 : System.Web.UI.Page
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

                if (!Page.IsPostBack)
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

        //go
        protected void GenreGo_Click(object sender, EventArgs e)
        {
            getGenrebyID();
        }

        protected void AddGenre_Click(object sender, EventArgs e)
        {
            if (checkIfGenreExists())
            {
                Response.Write("<script>alert('Genre Already Exist');</script>");
            }
            else
            {
                addNewGenre();
            }
        }

        protected void DeleteGenre_Click(object sender, EventArgs e)
        {
            DeleteGenrebyID();
        }

        void getGenrebyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Genre_tbl where Genre_id='" + GenreID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    GenreID.Text = dt.Rows[0]["Genre_id"].ToString();
                    GenreName.Text = dt.Rows[0]["Genre_Name"].ToString().Trim();
                   
                }
                else
                {
                    Response.Write("<script>alert('Invalid Genre ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        
        void DeleteGenrebyID()
        {
            if (checkIfGenreExists())
            {
                if(checkIfGenreInBook() == false)
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(strcon);
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        SqlCommand cmd = new SqlCommand("DELETE from Genre_tbl where Genre_id = '" + GenreID.Text.Trim() + "'", con);


                        cmd.ExecuteNonQuery();


                        con.Close();
                        Response.Write("<script>alert('Genre Deleted Successfully');</script>");
                        GridView1.DataBind();

                    }
                    catch (Exception ex)
                    {
                        Response.Write("<script>alert('" + ex.Message + "');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('A Book is using this Genre in the system');</script>");
                }
                
            }
            else
            {
                Response.Write("<script>alert('Genre Does not exist');</script>");
            }
        }

        bool checkIfGenreExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from Genre_tbl where Genre_id='" +
                    GenreID.Text.Trim() + "' OR Genre_Name='" + GenreName.Text.Trim() + "';", con);
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

        bool checkIfGenreInBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select BookGenre_tbl.Genre_Id from Genre_tbl join BookGenre_tbl on Genre_tbl.Genre_id = BookGenre_tbl.Genre_Id where BookGenre_tbl.Genre_Id ='" + GenreID.Text.Trim() + "'", con);
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

        void addNewGenre()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Genre_tbl(Genre_id,Genre_Name)" +
                    "values(@Genre_id,@Genre_Name)", con);


                cmd.Parameters.AddWithValue("@Genre_id", GenreID.Text.Trim());
                cmd.Parameters.AddWithValue("@Genre_Name", GenreName.Text.Trim());
                






                cmd.ExecuteNonQuery();
                GridView1.DataBind();

                
                Response.Write("<script>alert('Genre added successfully');</script>");

            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}
