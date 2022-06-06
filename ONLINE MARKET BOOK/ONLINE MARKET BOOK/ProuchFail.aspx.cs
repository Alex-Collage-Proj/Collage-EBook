using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        string GlobalResualt;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (Session["role"] == null || Session["role"].ToString() != "user")
                {
                    Response.Redirect("HomePage.aspx");
                }
            

            Error.Text = Session["GlobalResualt"].ToString();
        }

        protected void BackToMain1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.Aspx");
        }

        protected void BackToCart1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.Aspx");
        }

        protected void BackToPayment1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptOrder.Aspx");
        }
    }
}