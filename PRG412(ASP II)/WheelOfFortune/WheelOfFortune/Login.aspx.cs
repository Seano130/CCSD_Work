using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { //Phase A

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    { // Phase B
        if(tbUser.Text.Length > 0)
        {
            UserInfo ui = new UserInfo();
            ui.Username = tbUser.Text; // grab whatever bane they typed
            Session["user"] = ui;
            Response.Redirect("Game.aspx");
        }

    }


    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C

    }

    
}