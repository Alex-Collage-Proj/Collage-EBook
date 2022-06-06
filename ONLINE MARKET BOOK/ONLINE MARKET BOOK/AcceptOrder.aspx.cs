using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;


namespace ONLINE_MARKET_BOOK
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ProjDb1;Integrated Security=true");
        string con = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        string s, t, Format, Book_Name, Sell_Price, Book_image, date;
        int Book_id;
        static int order_id;
        string[] a = new string[100];
        int id;
        int Countp = 0;
        double Total = 0;
        string GlobalResualt;
        int count = 0;
        string trying;
        string send_success_id = "|";
        int count_seprate = 0;
        int countbooks;
        string num = "";
        int[] id_num;
        int j;


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["bb"] != null)
            {
                s = Convert.ToString(Request.Cookies["bb"].Value);
                string[] strArr = s.Split('.');
                for (int i = 0; i < strArr.Length; i++)
                {
                    Response.Write(strArr[i].ToString());

                }

            }
            Response.Write("Checking Ids:");
            // העברת קוקי ל סטרינג  הוצאת ה אידי ולאחר מכאן העברה למצב מספרי
            trying = "+" + Request.Cookies["bb"].Value;
            Response.Write("<br>");
            Response.Write("<br>");
            Response.Write(trying);




            Response.Write("<br>");
            Response.Write(send_success_id);
            Response.Write("--->New_id:");


        }

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["role"] == null || Session["role"].ToString() != "user")
                {
                    Response.Redirect("HomePage.aspx");
                }
            else
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Book_Name"), new DataColumn("Sell_Price"), new DataColumn("Format"), new DataColumn("Book_image"), new DataColumn("Book_id"), new DataColumn("id") });

                if (Request.Cookies["bb"] != null)
                {
                    s = Convert.ToString(Request.Cookies["bb"].Value);

                    string[] strArr = s.Split('|');

                    for (int i = 0; i < strArr.Length; i++)
                    {
                        t = Convert.ToString(strArr[i].ToString());
                        string[] strArr1 = t.Split('^');
                        for (int j = 0; j < strArr1.Length; j++)
                        {
                            a[j] = strArr1[j].ToString();
                        }


                        dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString(), i.ToString());
                        Total = Total + Convert.ToDouble(a[1].ToString());

                    }

                }

                d1.DataSource = dt;
                d1.DataBind();
                ToTCPrice.Text = Total.ToString();

                // test //
                Session["TotalPrice"] = Total.ToString();

                trying = Request.Cookies["bb"].Value;


                count_seprate = 0;
                int after_name = 0;
                for (int i = 0; i < trying.Length; i++)

                {

                    if (trying[i] != '^')
                    {
                        if (trying[i] >= '0' && trying[i] <= '9' && count_seprate == 0 && after_name > 0)
                        {
                            send_success_id = "" + send_success_id + trying[i];
                            countbooks++;
                        }

                    }

                    if (trying[i] == '|')
                    {
                        send_success_id = "" + send_success_id + "|";
                    }

                    




                    if (trying[i] == '^' && after_name == 0)
                    {
                        after_name++;
                    }

                    if (trying[i] == '^')
                    {
                        count_seprate++;
                    }

                    if (count_seprate == 4)
                    {
                        count_seprate = 0;

                    }

                    if (trying[i] == '|')
                    {

                        after_name = 0;
                    }












                }
            }
            

            



        }


        protected void Sub_Payment_Click(object sender, EventArgs e)
        {

            // פנייה לחיוב רגיל
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://gateway20.pelecard.biz/services/DebitRegularType");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            // הגדרת השדות לשליחה, יש למלא שם וסיסמה מתאימים לסביבת הטסטים
            // וכמובן פרטי חיוב, סכום, מטבע ושאר הפרמטרים כפי שמופיעים במדריך שלהם
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {


                string json = "{\"user\":\"shivukTest\"," +
                               "\"password\":\"r4FW1BDP\"," +
                               "\"terminalNumber\":\" 0962210\"," +
                              "\"shopNumber\":\"12345\"," +
                               "\"creditCard\":\"" + ccnum.Text.Trim() + "\"," + //V
                               "\"creditCardDateMmYy\":\"" + expyear.Text.Trim() + "\"," + //V                 
                              "\"token\":\"\"," +
                              "\"total\":\"" + ToTCPrice.Text.Trim()  + "\"," +                    //V
                               "\"currency\":\"2\"," +
                               "\"cvv2\":\"" + cvv.Text.Trim() + "\"," +                  //V
                              "\"id\":\"890109629\"," +               //V
                                "\"authorizationNumber\":\"\"," +
                              "\"paramX\":\"Order:P&A \"," +           //V
                              "}";


                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                // התשובה שחזרה מהשרת, כוללת קוד תשובה המציין מה היה הסטאטוס
                // ישנה רשימת סטאטוסים במדריך עם מספר לכל שגיאה וגם להצלחה
                Response.Write(result);
                int i, count = 0;
                for (i = 0; i < 4; i++)
                {
                    if (result[14 + i] == '0')
                    {
                        count += 1;
                    }
                }

                if (count == 3)
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[8];
                    var random = new Random();
                    string S_Order_id = "";
                    Session["Check_first_time"] = 1;
                    Session["countbooks"] = countbooks;
                    Session["Deliver_id"] = send_success_id;
                    Session["order_id"] = order_id;
                    for (i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                        S_Order_id = S_Order_id + stringChars[i];
                    }
                    Session["stringChars"] = S_Order_id;
                    Response.Redirect("ProuchSuccess.aspx");

                }
                else
                {
                    i = 0;
                    while (result[36 + i] != '"')
                    {

                        GlobalResualt = GlobalResualt + (result[36 + i]).ToString();
                        Session["GlobalResualt"] = GlobalResualt;
                        i = i + 1;
                    }

                    Response.Redirect("ProuchFail.aspx");
                }
            }
        }

    }


}



