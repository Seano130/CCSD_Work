using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    // Kenny = Zenyatta
    protected Keymaker zenyatta
    {
        get
        { // Check if Keymaker exist
            if (Session["zenyatta"] == null)
            { // if Keymaker does NOT exist, instantiate him now and place into Session
                Session["zenyatta"] = new Keymaker();
            }
            return (Keymaker)Session["zenyatta"];
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    { // Phase A


    }

    protected void btnLogin_Click(object sender, EventArgs e)
    { // Phase B
        if (zenyatta.CheckUserExists(tbUser.Text))
        {
            if (zenyatta.CheckPWMatches(tbUser.Text, tbPass.Text))
            {
                UserInfo ui = zenyatta.GetUser(tbUser.Text);
                Session["user"] = ui; // log them in by placing their credential into Session
                Response.Redirect("Products.aspx");
            }
            else
            {
                Response.Write("Incorrect Password!");
            }
        }
        else
        {
            Response.Write("Incorrect Username!");
        }


    }


    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C


    }
}