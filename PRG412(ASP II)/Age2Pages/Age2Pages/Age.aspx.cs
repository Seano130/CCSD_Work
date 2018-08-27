using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Age : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { //Phase A
        if (Session["user"] == null)
        {
            Response.Redirect("Login.aspx"); // bounce them out
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    { //Phase B

        Session["user"] = null;
        Response.Redirect("Login.aspx"); // send them back to login page

    }

    protected void btnSubtract_Click(object sender, EventArgs e)
    { //Phase B

        if(Session["user"] != null)
        {
            UserInfo ui = (UserInfo)Session["user"];
            if(ui.Age > 0)
            {
                ui.Age--;
                Session["user"] = ui;
            }
        }


    }

    protected void btnAdd_Click(object sender, EventArgs e)
    { //Phase B

        if(Session["user"] != null)
        {
            UserInfo ui = (UserInfo)Session["user"];
            ui.Age++;
            Session["user"] = ui;
        }


    }

    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
       
        if(Session["user"] != null)
        {
            UserInfo ui = (UserInfo)Session["user"];
            lblMsg.Text = "Hello, " + ui.Username + ", you are now" + ui.Age + " yrs old.";

        }
        

    }
}