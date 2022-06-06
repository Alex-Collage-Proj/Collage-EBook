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
    public partial class WebForm21 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");


        int Book_Id;
        string Pdf;

        protected void Page_Load(object sender, EventArgs e)
        {

            Book_Id = Convert.ToInt32(Session["Book_Id"].ToString());

            SqlCommand cmd = new SqlCommand("select Book_id,Pdf from Book_tbl where Book_id= " + Book_Id, con);
            SqlDataAdapter Id_conncet = new SqlDataAdapter();
            cmd.Connection = con;
            Id_conncet.SelectCommand = cmd;
            DataTable dt = new DataTable();
            Id_conncet.Fill(dt);
            foreach (DataRow num in dt.Rows)
            {
                Pdf = (num["Pdf"].ToString());
            }
            String filename = Pdf;
            String filepath = Server.MapPath(filename);

            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.Flush();

            Response.TransmitFile(filepath);
            Response.End();


        }
    }
}