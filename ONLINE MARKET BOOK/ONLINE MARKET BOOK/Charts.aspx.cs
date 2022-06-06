using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LtlLabels.Text = "'DATA'"; 
                LtlLabel.Text = "'Sum of Sales'";
                LtlData.Text = "'1500'"; // from sql           
                LtlData1.Text = "'500'"; // from sql

               


            }
        }
    }
}