using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ONLINE_MARKET_BOOK
{
    public partial class Skeleton : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton2.Visible = true; // user login link button
                    LinkButton1.Visible = true; // Sign up link button
                    LinkButtonAL.Visible = true; // admin login link button
                    

                    LinkButton3.Visible = false; // Log out link button
                    navbarDropdown.Visible = false; // Hello user link button
                    /*LinkButton5.Visible = false;*/ // profile link button
                    LinkButtonBI.Visible = false; // Book inventory link button
                    YourCart.Visible = false;
                    LinkButtonGM.Visible = false;
                    LinkbuttonSM.Visible = false;
                    LinkButtonOM.Visible = false;
                    LinkButtonOrderData.Visible = false;
                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton2.Visible = false; // user login link button
                    LinkButton1.Visible = false; // Sign up link button
                    LinkButtonAL.Visible = false; // admin login link button
                    LinkButtonGM.Visible = false;
                    LinkbuttonSM.Visible = false;
                    LinkButtonOM.Visible = false;
                    LinkButtonOrderData.Visible = false;

                    LinkButton3.Visible = true; // Log out link button
                    navbarDropdown.Visible = true; // Hello user link button
                    /*LinkButton5.Visible = true;*/ // profile link button
                    navbarDropdown.Text = "Hello " + Session["Fname"];
                    LinkButton7.Visible = true;
                    Orders.Visible = true;
                    YourCart.Visible = true;
                }

                else if(Session["role"].Equals("admin"))
                {
                    LinkButton2.Visible = false; // user login link button
                    LinkButton1.Visible = false; // Sign up link button
                    LinkButtonAL.Visible = false; // admin login link button
                    YourCart.Visible = false;

                    LinkButton3.Visible = true; // Log out link button
                    navbarDropdown.Visible = true; // Hello user link button
                    navbarDropdown.Text = "Hello " + Session["UserName"];

                    LinkButtonBI.Visible = true; // Book inventory link button
                    
                    Orders.Visible = false; // No orders for Admin
                    LinkButton7.Visible = false;
                    AdminProfile7.Visible = true;
                    LinkButtonGM.Visible = true;
                    LinkbuttonSM.Visible = true;
                    LinkButtonOM.Visible = true;
                    LinkButtonOrderData.Visible = true;


                }
            }
            catch(Exception ex)
            {

            }
        }


        protected void ViewB(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");
        }

        protected void SignU(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void LogO(object sender, EventArgs e)
        {        

            if(Session["role"].Equals("admin"))
            {

             

                LinkButton2.Visible = true; // user login link button
                LinkButton1.Visible = true; // Sign up link button

                LinkButton3.Visible = false; // Log out link button
                LinkButton7.Visible = false; // Hello user link button
                /*LinkButton5.Visible = false;*/ // profile link button


                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-10));
                Session["Email"] = null;
                Session["Fname"] = null;
                Session["role"] = null;
                FormsAuthentication.SignOut();
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.UtcNow.AddDays(-1d);
                Response.CacheControl = "no-cache";




                Response.Redirect("AdminLogin.aspx");
                

            }
            else if(Session["role"].Equals("user"))
            {
                if (Request.Cookies["aa"] != null)
                {
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                }

                LinkButton2.Visible = true; // user login link button
                LinkButton1.Visible = true; // Sign up link button

                LinkButton3.Visible = false; // Log out link button
                LinkButton7.Visible = false; // Hello user link button
                /*LinkButton5.Visible = false;*/ // profile link button


                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetNoStore();
                Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-10));
                Session["Email"] = null;
                Session["Fname"] = null;
                Session["role"] = null;
                FormsAuthentication.SignOut();
                Response.Buffer = true;
                Response.ExpiresAbsolute = DateTime.UtcNow.AddDays(-1d);
                Response.CacheControl = "no-cache";

                Response.Redirect("Login.aspx");
               
            }

           

        }



        protected void UserL(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");

        }

        protected void Profi(object sender, EventArgs e)
        {

        }

        protected void LinkButtonAL_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButtonBI_Click(object sender, EventArgs e)
        {
            Response.Redirect("ABookinventory.aspx");
        }

      

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserProfile.aspx");
        }

        protected void Orders_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrder.aspx");
        }

        protected void AdminProfile7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminProfile.aspx");
        }

        protected void YourCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }

        protected void LinkButtonGM_Click(object sender, EventArgs e)
        {
            Response.Redirect("GenreManagment.aspx");
        }

        protected void LinkbuttonSM_Click(object sender, EventArgs e)
        {
            Response.Redirect("SupManagment.aspx");
        }

        protected void LinkButtonOM_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderManagment.aspx");
        }

        protected void LinkButtonOrderData_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderDATA.aspx");
        }
    }
}