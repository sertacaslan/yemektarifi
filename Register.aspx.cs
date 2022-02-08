using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;//veritabanı bağlantısı için
using System.Data;//veritabanı bağlantısı için
using System.Configuration;//veritabanı bağlantısı için

namespace FinalOdevi2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)//temizle butonuna basıldığında textboxları temizler
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
        protected void kontrol()//textboxları string nesnesinin isnullorwhitespace metoduyla kontrolünü sağlar
        {
            if (string.IsNullOrWhiteSpace(TextBox1.Text)||
                string.IsNullOrWhiteSpace(TextBox2.Text) ||
                string.IsNullOrWhiteSpace(TextBox3.Text) ||
                string.IsNullOrWhiteSpace(TextBox4.Text) ||
                string.IsNullOrWhiteSpace(TextBox5.Text))
                Label1.Text = "Lütfen Tüm alanları doğru bir şekilde doldurunuz";//alanlar boş veya null ise label1 uyarı atar
            else
            {
                gonder();
            }
        }
        protected void gonder()
        {
            SQLiteConnection baglanti;
            SQLiteCommand komut;
            string baglanStr = "Data Source=" + Server.MapPath(@"~\finalodev.db") + ";Version=3;";
            //string baglanStr = ConfigurationManager.ConnectionStrings["finalodevdbBaglantisi"].ConnectionString;
            baglanti = new SQLiteConnection(baglanStr);
            try
            {
                komut = new SQLiteCommand("INSERT INTO Tbl_user (ad, syd, mail, usern, pass) VALUES (@ad,@syd,@mail,@usern,@pass)", baglanti);
                komut.Parameters.AddWithValue("@ad", TextBox1.Text);
                komut.Parameters.AddWithValue("@syd", TextBox2.Text);
                komut.Parameters.AddWithValue("@mail", TextBox3.Text);
                komut.Parameters.AddWithValue("@usern", TextBox4.Text);
                komut.Parameters.AddWithValue("@pass", TextBox5.Text);
                baglanti.Open();
                komut.ExecuteNonQuery();
                Label1.Text = "Üyelik İşlemi Başarı İle Tamamlandı";
            }
            catch (Exception e)
            {
                Label1.Text = "Hata oluştu, kaydedilemedi. " + e;
            }
            finally
            {
                baglanti.Close();
                Response.Redirect("Login.aspx?durum=1");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            kontrol();
        }
    }
}