using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{

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
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        Session["user"] = null; // log them out if necessary
    }
    

    protected void btnRegister_Click(object sender, EventArgs e)
    { // Phase B
        int age = Convert.ToInt32(tbAge.Text);
        bool isMale = rbMale.Checked;


        UserInfo ui = new UserInfo(tbUser.Text, tbPassword.Text, 
            tbFirst.Text, tbLast.Text, tbEmail.Text, age, 
            isMale, AdminRights.User);


        zenyatta.CreateNewUser(ui);
        Response.Redirect("Login.aspx");

        


    }


    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C

    }
}