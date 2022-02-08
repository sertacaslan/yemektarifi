using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace FinalOdevi2
{
    public partial class Addpage : System.Web.UI.Page
    {
        public string dosya = "";
        public void resimat()
        {

            if (resim.HasFile)
            {
                try
                {
                    if (resim.PostedFile.ContentType == "image/jpeg")
                    {
                        if (resim.PostedFile.ContentLength < 10200400)
                        {
                            string filename = Path.GetFileName(resim.FileName);
                            Random rnd = new Random();
                            dosya = rnd.Next(999999999).ToString();
                            if (filename != "")
                            {
                                resim.SaveAs(Server.MapPath("~/img/") + dosya+".jpg");
                                Label2.Text = filename + " dosyası yüklendi!";
                                
                            }
                        }
                        else
                            Label2.Text = "Dosya boyutu 100 KB'dan düşük olmalı!";
                    }
                    else
                        Label2.Text = "Sadece JPEG formatı kabul edilir.";
                }
                catch (Exception ex)
                {
                    Label2.Text = "Dosya yüklenemedi: " + ex.Message;
                }
            }
        }
    
        public void Gonder(int a)
        {
            SQLiteConnection baglanti2;
            SQLiteCommand komut2;
            string baglanStr = "Data Source=" + Server.MapPath(@"~\finalodev.db") + ";Version=3;Count Changes=off;Journal Mode=off;Pooling=true;Cache Size=10000;Page Size=4096;Synchronous=off";

            baglanti2 = new SQLiteConnection(baglanStr);


            komut2 = new SQLiteCommand("INSERT INTO Tbl_yemek (ad, malzeme, aciklama, resim, userid) VALUES (@ad,@malzeme,@aciklama,@resim,@userid)", baglanti2);
            komut2.Parameters.AddWithValue("@ad", adbox.Text);
            komut2.Parameters.AddWithValue("@malzeme", malzemebox.Text);
            komut2.Parameters.AddWithValue("@aciklama", tarifbox.Text);
            komut2.Parameters.AddWithValue("@userid", a);
            komut2.Parameters.AddWithValue("@resim", dosya+".jpg");
            

            baglanti2.Open();
            komut2.ExecuteNonQuery();
            Label1.Text = "gönderme İşlemi Başarı İle Tamamlandı";
            baglanti2.Close();
            Label1.Text += "Kayıt başarılı";


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label2.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = Convert.ToInt32(Session["userid"]);
            resimat();

            Gonder(userid);



        }
    }
}