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

        #region 
        //if(Session["user"] == null) // nobody currently logged in
        //{
        //    Session["user"] = tbUser.Text; // log them in
        //}
        //else
        //{ // someone already logged in, so log them out
        //    Session["user"] = null; // log them out

        //}
        #endregion





    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

    }

    protected void btnSubtract_Click(object sender, EventArgs e)
    {

    }

    protected void btnReload_Click(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C

        #region
        //if(Session["user"] == null)
        //{ // nobody logged in 
        //    lblTitle.Text = "Enter Username: ";
        //    tbUser.Visible = true;

        //    btnLogin.Text = "Login";

        //    btnAdd.Visible = false;
        //    btnSubtract.Visible = false;
        //}
        //else
        //{ // someone already logged in
        //    lblTitle.Text = "Hello " + (string)Session["user"];
        //    tbUser.Visible = true;
        //    btnLogin.Text = "Logout";

        //    btnAdd.Visible = true;
        //    btnSubtract.Visible = true;
        //}
        #endregion

        if()
        {
            lblTitle.Text = "Please login";
        }
        else
        {
            lblTitle.Text = "Hello Sean"; // <-- replace with actual user name
        }



    }






  
}