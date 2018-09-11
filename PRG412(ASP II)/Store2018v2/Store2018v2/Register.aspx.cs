using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { // Phase A
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        Session["user"] = null; // log them out if necessary
    }
    

    protected void btnRegister_Click(object sender, EventArgs e)
    { // Phase B

    }


    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C

    }
}