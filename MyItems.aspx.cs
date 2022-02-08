using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalOdevi2
{
    public partial class MyItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username;
            if (Session["user"] != null)
            {
                username = Session["user"].ToString();
                string baglanStr = "Data Source=" + Server.MapPath(@"~\finalodev.db") + ";Version=3;";
                //string baglanStr = ConfigurationManager.ConnectionStrings["finalodevdbBaglantisi"].ConnectionString;
                sonuc.InnerHtml = "<br>";

                SQLiteConnection baglanti;
                SQLiteCommand komut;
                SQLiteCommand komut2;
                SQLiteCommand komut3;
                baglanti = new SQLiteConnection(baglanStr);
                komut3 = new SQLiteCommand("select id from Tbl_user where usern=@username", baglanti);//kullanıcı adına göre id alır
                komut3.Parameters.AddWithValue("@username", username);
                
                baglanti.Open();
                
                
                SQLiteDataReader dr3 = komut3.ExecuteReader();

                int userid=0;
                while (dr3.Read())
                {
                    userid = Convert.ToInt32(dr3["id"].ToString());
                }
                komut2 = new SQLiteCommand("select Count(*) from Tbl_yemek where userid=@idd", baglanti);
                komut2.Parameters.AddWithValue("@idd", userid);


                double elemansayisi = Convert.ToDouble((komut2.ExecuteScalar().ToString()));
                if(elemansayisi==0){
                    Uyar.Text = "Eklemiş olduğunuz yemek tarifi bulunamadı.";
                }
                else
                {
                    Uyar.Text = "Eklemiş olduğunuz tüm tarifler listeleniyor.";
                }
                int limit = 3;
                int sonsayfa = (int)Math.Ceiling(elemansayisi / limit);
                int sayfa = 1;
                int baslangic = 0;
                if (Request["sayfa"] != null)
                {
                    sayfa = int.Parse(Request["sayfa"]);
                    baslangic = (sayfa - 1) * limit;
                }
                if (sonsayfa >= sayfa)
                {
                    komut = new SQLiteCommand("SELECT * FROM Tbl_yemek where userid=@idd order by id desc LIMIT " + baslangic + "," + limit, baglanti);
                    komut.Parameters.AddWithValue("@idd", userid);
                    SQLiteDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        sonuc.InnerHtml += "<div class='ad'><h2>" + dr["ad"].ToString() + "</h2></div><div class='malzeme'>Malzemeler: " + dr["malzeme"].ToString() + "</div><div class='tarif'>" + "Yapılışı: " + dr["aciklama"].ToString() + "</div><div style='text-align:center'>" + "<img style='width:400px;height:400px;' src='img/" + dr["resim"].ToString() + "'></div>" + " son sayfa=" + sonsayfa + " limit=" + limit + " elemans=" + elemansayisi;
                    }
                }
                else
                {
                    komut = new SQLiteCommand("SELECT * FROM Tbl_yemek where userid=@idd order by id desc", baglanti);
                    komut.Parameters.AddWithValue("@idd", userid);
                    SQLiteDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        sonuc.InnerHtml += "<div class='ad'><h2>" + dr["ad"].ToString() + "</h2></div><div class='malzeme'>Malzemeler: " + dr["malzeme"].ToString() + "</div><div class='tarif'>" + "Yapılışı: " + dr["aciklama"].ToString() + "</div><div style='text-align:center'>" + "<img style='width:400px;height:400px;' src='img/" + dr["resim"].ToString() + "'></div>" + " son sayfa=" + sonsayfa + " limit=" + limit + " elemans=" + elemansayisi;
                    }
                }
                if (elemansayisi > limit)
                {
                    for (int i = 1; i <= sonsayfa; i++)
                    {
                        sayfalama.InnerHtml += "<a class='sayfalink' href='?sayfa=" + i + "'>" + i + "</a> ";
                    }
                }


                baglanti.Close();
            }
        }
    }
}
