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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            //SqlConnection con = new SqlConnection(strcon);
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from Book_tbl";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter(cmd);
            //da.Fill(dt);
            //d1.DataSource = dt;
            //d1.DataBind();
            //con.Close();
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}