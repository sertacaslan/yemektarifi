using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;//veritabanı bağlantısı için
using System.Configuration;//veritabanı bağlantısı için
using System.Data.SQLite;


namespace FinalOdevi2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["durum"] == "1")
            {
                Label1.Text = "Üyelik işlemi başarılı, lütfen kullanıcı adı ve şifreniz ile giriş yapın.";
                Label1.ForeColor = System.Drawing.Color.Green;
            }
            else if (Request["durum"] == "2")
            {
                Label1.Text = "Bu özelliği kullanabilmek için lütfen kullanıcı adı ve şifreniz ile giriş yapın.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
        protected void login()
        {
            string kullanici = TextBox1.Text;
            string sifre = TextBox2.Text;

            SQLiteConnection baglanti;
            SQLiteCommand komut;
            string baglanStr = "Data Source=" + Server.MapPath(@"~\finalodev.db") + ";Version=3;Pooling=True;Max Pool Size=100;";
            //string baglanStr = ConfigurationManager.ConnectionStrings["finalodevdbBaglantisi"].ConnectionString;
            using (baglanti = new SQLiteConnection(baglanStr)) {
                komut = new SQLiteCommand("SELECT * FROM Tbl_user WHERE usern=@username AND pass=@password", baglanti);

            komut.Parameters.AddWithValue("@username", kullanici);
            komut.Parameters.AddWithValue("@password", sifre);

            baglanti.Open();
            SQLiteDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {

                Session["user"] = oku["usern"].ToString();
                Session["userid"] = oku["id"].ToString();
                Session.Timeout = 20;
                Label1.Text = Session["user"].ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = "Kullanıcı adı yada şifre hatalı!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            oku.Close();
            baglanti.Close();
            baglanti.Dispose(); }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Lütfen kullanıcı adı ve şifrenizi yazınız.";
            }
            else
            {
                login();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");//üyelik sayfasına yönlendirir
        }
    }
}