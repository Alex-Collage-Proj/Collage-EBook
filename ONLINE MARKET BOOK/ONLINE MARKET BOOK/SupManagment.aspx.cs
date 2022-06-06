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
    public partial class WebForm16 : System.Web.UI.Page
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
                    else
                    {

                        GridView1.DataBind();
                    }
                

            }
            catch (Exception ex)
            {
                

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("HomePage.aspx");
                //Response.Write("<script>alert('" + ex.Message + "');</script>");


            }

        }

        //go
        protected void SupGo_Click(object sender, EventArgs e)
        {
            getSupbyID();
        }

        protected void AddSup_Click(object sender, EventArgs e)
        {
            if (checkIfSupExists())
            {
                Response.Write("<script>alert('Sup Already Exist');</script>");
            }
            else
            {
                addNewSup();
            }
        }

        protected void UpdateSup_Click(object sender, EventArgs e)
        {
            UpdateSupbyID();
        }

        protected void DeleteSup_Click(object sender, EventArgs e)
        {
            DeleteSupbyID();
        }


        void getSupbyID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("select * from Supplier_tbl where Sup_Id='" + SupID.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    SupID.Text = dt.Rows[0]["Sup_Id"].ToString();
                    SupName.Text = dt.Rows[0]["Sup_Name"].ToString().Trim();
                    CountryName.Text = dt.Rows[0]["Sup_Country"].ToString().Trim();

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

        }

        bool checkIfSupExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("Select * from Supplier_tbl where Sup_Id='" +
                    SupID.Text.Trim() + "' OR Sup_Name='" + SupName.Text.Trim() + "';", con);
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

        void addNewSup()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Supplier_tbl(Sup_Id,Sup_Name,Sup_Country)" +
                    "values(@Sup_Id,@Sup_Name,@Sup_Country)", con);


                cmd.Parameters.AddWithValue("@Sup_Id", SupID.Text.Trim());
                cmd.Parameters.AddWithValue("@Sup_Name", SupName.Text.Trim());
                cmd.Parameters.AddWithValue("@Sup_Country", CountryName.Text.Trim());






                cmd.ExecuteNonQuery();
                GridView1.DataBind();


                Response.Write("<script>alert('Supplier added successfully');</script>");
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void UpdateSupbyID()
        {
            if (checkIfSupExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("update Supplier_tbl set Sup_Name=@Sup_Name, Sup_Country=@Sup_Country where Sup_Id ='" + SupID.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@Sup_Name", SupName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Sup_Country", CountryName.Text.Trim());

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Supplier updated Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        void DeleteSupbyID()
        {
            if (checkIfSupExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from Supplier_tbl where Sup_Id = '" + SupID.Text.Trim() + "'", con);


                    cmd.ExecuteNonQuery();


                    con.Close();
                    Response.Write("<script>alert('Supplier Deleted Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

    }
}