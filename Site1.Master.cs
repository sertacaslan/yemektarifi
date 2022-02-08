using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace FinalOdevi2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                additem.Visible = false;
                Button1.Visible = false;
                itembtn.Visible = false;
            }
            else
            {
                string username = Session["user"].ToString();
                loginbtn.Visible = false;
                regisbtn.Visible = false;
                Label1.Text = "Hoşgeldiniz sayın "+username;
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("default.aspx");
        }
    }
}