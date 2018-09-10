using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { // Phase A
        if (Session["user"] == null) // bouncer check
        { // if not logged in, then get out
            Response.Redirect("Login.aspx");
        }
    }


    //insert Phase B later...



    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        Response.Write("You made it in <br/><br/>");
        UserInfo ui = (UserInfo)Session["user"]; // get out their credential from Session
        Response.Write("Welcome, " + ui.First + " " + ui.Last + "!");
    }
}