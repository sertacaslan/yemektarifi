using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace FinalOdevi2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Database connection
            //string baglanStr = ConfigurationManager.ConnectionStrings["finalodevdbBaglantisi"].ConnectionString;
            string baglanStr = "Data Source="+Server.MapPath(@"~\finalodev.db")+";Version=3;";

            SQLiteConnection baglanti;
            SQLiteCommand komut;
            SQLiteCommand komut2;
            baglanti = new SQLiteConnection(baglanStr);
            //komut = new SQLiteCommand("select * from Tbl_yemek order by id desc", baglanti);
            komut2 = new SQLiteCommand("select Count(*) from Tbl_yemek", baglanti);
            baglanti.Open();
            //SQLiteDataReader dr = komut.ExecuteReader();
            #endregion
            #region Paging and listing

            
            double elemansayisi = Convert.ToDouble((komut2.ExecuteScalar().ToString()));
            int limit = 3;
            int sonsayfa = (int)Math.Ceiling(elemansayisi/limit);
            int sayfa = 1;
            int baslangic = 0;
                if (Request["sayfa"]!=null) { 
                sayfa = int.Parse(Request["sayfa"]);
                baslangic = (sayfa - 1) * limit;
                }
            if (sonsayfa >= sayfa)
            {
                komut = new SQLiteCommand("SELECT * FROM Tbl_yemek order by id desc LIMIT "+baslangic+","+limit, baglanti);
                SQLiteDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    sonuc.InnerHtml += "<div class='ad'><h2>" + dr["ad"].ToString() + "</h2></div><div class='malzeme'>Malzemeler: " + dr["malzeme"].ToString() + "</div><div class='tarif'>" + "Yapılışı: " + dr["aciklama"].ToString() + "</div><div style='text-align:center'>" + "<img style='width:400px;height:400px;' src='img/" + dr["resim"].ToString() + "'></div>";
                }
            }
            else
            {
                komut = new SQLiteCommand("SELECT * FROM Tbl_yemek order by id desc", baglanti);
                SQLiteDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    sonuc.InnerHtml += "<div class='ad'><h2>" + dr["ad"].ToString() + "</h2></div><div class='malzeme'>Malzemeler: " + dr["malzeme"].ToString() + "</div><div class='tarif'>" + "Yapılışı: " + dr["aciklama"].ToString() + "</div><div style='text-align:center'>" + "<img style='width:400px;height:400px;' src='img/" + dr["resim"].ToString() + "'></div>";
                }
            }
            if (elemansayisi > limit)
            {
                for (int i=1;i<=sonsayfa ;i++)
                {
                    sayfalama.InnerHtml+= "<a class='sayfalink' href='?sayfa="+i+"'>"+i+"</a> ";
                }
            }


            baglanti.Close();

            #endregion
            #region session check

            if (Session["user"] == null)
            {
                Label1.Text = "Uyarı:Yemek Tarifi ekleyebilmek için ise lütfen giriş yapın!";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.BackColor = System.Drawing.Color.Orange;
            }
            #endregion
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
    }
}