using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApp.ASPNETWinFormUI.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session doluysa
            if (Session["APP_KULLANICI"] != null && !Session["APP_KULLANICI"].ToString().Equals(""))
            {
                Response.Redirect("/Home.aspx");
            }
            string email = Request.QueryString["email"];
            string password  = Request.QueryString["password"];

            //veritabanı kontrol etsek varsa sessiona ekle ve anasayfaya yönlendir yoksa boş bırak uyarı döndür

            Session["APP_KULLANICI"] = "";
            Session["APP_PAROLA"] = "";
        }
    }
}