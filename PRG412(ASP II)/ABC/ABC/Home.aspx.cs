using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    { // Phase A
        if(!IsPostBack)
        {
            btnLogin.Text = "Login";
        }      
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    { // Phase B
        // Handle all future button clicks

        if(Session["user"] == null) // nobody currently logged in
        {
            Session["user"] = tbUser.Text; // log them in
        }
        else
        { // someone already logged in, so log them out
            Session["user"] = null; // log them out


        }




       //if(btnLogin.Text == "Login")
       // {
       //     if(tbUser.Text != "")
       //     {
       //         lblTitle.Text = "Welcome, " + tbUser.Text + "!";
       //         btnLogin.Text = "Logout";
       //     }                   
       // }
       //else
       // {
       //     lblTitle.Text = "Enter Username";
       //     tbUser.Visible = true;
       //     lblTitle.Text = "";
       //     btnLogin.Text = "Login";
       // }
    }

    protected void btnReload_Click(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C
        if(Session["user"] == null)
        { // nobody logged in 
            lblTitle.Text = "Enter Username: ";
            tbUser.Visible = true;
            btnLogin.Text = "Login";
        }
        else
        { // someone already logged in
            lblTitle.Text = "Hello " + (string)Session["user"];
            tbUser.Visible = false;
            btnLogin.Text = "Logout";
        }



        //if(btnLogin.Text == "Logout")
        //{
        //    tbUser.Visible = false;
        //}
    }


 
}