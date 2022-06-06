using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm19 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        int id;
        String Book_Name, Sell_Price, Format, Book_image, Book_Id;
        string send_success_id;
        int[] id_num;
        string num = "";
        int j;
        int countbooks;
        string S_order_id;
        int Check_first_time;
        static string EmailInfoAboutProuch = "";
        double total = 0;





        void SendEmail(string email, string Books_Details)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(email);
            mailMessage.From = new MailAddress("project09856@gmail.com");
            mailMessage.Subject = "New Order: Ebook-Shop";

            //      new 
            if (email == "project09856@gmail.com")
            {
                mailMessage.IsBodyHtml = true;
                string mailbody = System.IO.File.ReadAllText(Context.Server.MapPath("~/EmailAdmin.Html"));
                mailMessage.Body = mailbody.Replace("@@@", Session["tot"].ToString()).Replace("@@", Session["stringChars"].ToString()).Replace("@", Books_Details.ToString());


                //   mailMessage.Body = "Please Check New Order And Accept Statues:\n Order Id:" + Session["stringChars"].ToString() + "\n"  + Books_Details;
            }
            else
            {
                mailMessage.IsBodyHtml = true;
                string mailbody = System.IO.File.ReadAllText(Context.Server.MapPath("~/EmailCustomer.Html"));
                mailMessage.Body = mailbody.Replace("@@@", Session["tot"].ToString()).Replace("@@", Session["stringChars"].ToString()).Replace("@", Books_Details.ToString());
                //  mailMessage.Body = " Thank You For Buying at Ebook-Shop\n, Your Orders Are:" + Session["stringChars"].ToString() + "\n" + Books_Details + "\n ";
            }
            //      new 31.11.2021
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("project09856@gmail.com", "likmudxltzrquwve");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Send(mailMessage);

        }


        protected void Page_Load(object sender, EventArgs e)
        {

           
                if (Session["role"] == null || Session["role"].ToString() != "user")
                {
                    Response.Redirect("HomePage.aspx");
                }
            


            string adminemail = "project09856@gmail.com";

            // piruk
            send_success_id = Session["Deliver_id"].ToString();
            id_num = new int[send_success_id.Length];
            countbooks = int.Parse(Session["countbooks"].ToString());

            Array.Clear(id_num, 0, id_num.Length);
            j = 0;

            for (int i = 0; i < send_success_id.Length; i++)
            {
                if (send_success_id[i] != '|')
                {
                    num = num + send_success_id[i];
                    id_num[j] = int.Parse(num);
                }

                if (send_success_id[i] == '|')
                {
                    num = "";
                    j++;
                }

            }



            //for (int i = 0; i <= countbooks - 1; i++)
            //{
            //    Response.Write(" " + id_num[i]);
            //}



            //Response.Write("<br>");





            order_id1.Text = Session["stringChars"].ToString();

            S_order_id = Session["stringChars"].ToString();





            if (int.Parse(Session["Check_first_time"].ToString()) == 1)
            {

                try
                {


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO Order_tbl(Order_Id,Customer_Id,Total_Price) values(@Order_Id,@Customer_Id,@Total_Price)", con);

                    cmd.Parameters.AddWithValue("@Order_Id", S_order_id);
                    cmd.Parameters.AddWithValue("@Customer_Id", int.Parse(Session["CustomerID"].ToString()));
                    cmd.Parameters.AddWithValue("@Total_Price", int.Parse(Session["TotalPrice"].ToString()));

                    cmd.ExecuteNonQuery();

                    for (int i = 1; i <= countbooks; i++)
                    {
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO BookOrders_tbl(Order_Id,Book_Id,Order_Quntity)" +
                       "values(@Order_Id,@Book_Id,@Order_Quntity)", con);
                        cmd1.Parameters.AddWithValue("@Order_Id", S_order_id);
                        cmd1.Parameters.AddWithValue("@Book_Id", id_num[i]);
                        cmd1.Parameters.AddWithValue("@Order_Quntity", 1);

                        cmd1.ExecuteNonQuery();
                    }



                    //      new 31.11.2021
                    for (int i = 1; i <= countbooks; i++)
                    {
                        SqlCommand cmd4 = con.CreateCommand();
                        cmd4.CommandType = CommandType.Text;
                        cmd4.CommandText = "select * from Book_tbl where Book_id = '" + id_num[i] + "'";
                        cmd4.ExecuteNonQuery();
                        DataTable dt4 = new DataTable();
                        SqlDataAdapter da4 = new SqlDataAdapter(cmd4);
                        da4.Fill(dt4);
                        foreach (DataRow dr4 in dt4.Rows)
                        {
                            Book_Name = dr4["Book_Name"].ToString();
                            Sell_Price = dr4["Sell_Price"].ToString();
                            Book_Id = dr4["Book_id"].ToString();

                        }
                        total = total + Double.Parse(Sell_Price.ToString());
                        Session["tot"] = total;
                        EmailInfoAboutProuch = EmailInfoAboutProuch + "Book Name:" + Book_Name + "<br/>" + "Book Price:" + Sell_Price + "<br/>" + "Book Id:" + Book_Id + "<br/>";
                    }


                   // EmailInfoAboutProuch = EmailInfoAboutProuch + "\r\n Total Price:" + total.ToString() + "$";
                    //Response.Write(EmailInfoAboutProuch);
                    //      new 31.11.2021
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
                //      new 31.11.2021
                SendEmail(adminemail, EmailInfoAboutProuch);
                SendEmail(Session["Email"].ToString(), EmailInfoAboutProuch);
                Session["Check_first_time"] = 0;
                EmailInfoAboutProuch = "";
                total = 0;
                con.Close();
                //      new 31.11.2021



                if (Request.Cookies["aa"] != null)
                {
                    Response.Cookies["aa"].Expires = DateTime.Now.AddDays(-1);
                }

                if (Request.Cookies["bb"] != null)
                {
                    Response.Cookies["bb"].Expires = DateTime.Now.AddDays(-1);
                }
            }
        }
        protected void BackTMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void BackOrder_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerOrder.aspx");
        }
    }
}