using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Products : System.Web.UI.Page
{

    protected Keymaker zenyatta
    {
        get
        { // check if keymaker exists...
            if (Session["zenyatta"] == null)
            { // if Keymaker does NOT exist, institate him
                Session["zenyatta"] = new Keymaker();

            }
            return (Keymaker)Session["zenyatta"];
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    { // Phase A
        if (Session["user"] == null) // bouncer check
        { // if not logged in, then get out
            Response.Redirect("Login.aspx");
        }

        if (!IsPostBack)
        {// initialize the DDL for 1st time use...
            ddlProducts.Items.Add(""); // add blank entry so that NOTHING is inistially selected
            List<Product> allProds = zenyatta.GetAllProducts();
            foreach (Product p in allProds)
            {
                ddlProducts.Items.Add(p.Model + " " + p.Part);
            }
        }
        ddlProducts.Visible = false;

    }

    protected void btnShow_Click(object sender, EventArgs e)
    { // Phase B
        // code to decide whether to show/hide the DDL
        ddlProducts.Visible = true;
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        Response.Write("You made it in <br/><br/>");
        UserInfo ui = (UserInfo)Session["user"]; // get out their credential from Session
        Response.Write("Welcome, " + ui.First + " " + ui.Last + "!");
        //List<Product> allProds = zenyatta.GetAllProducts();
        //foreach(Product p in allProds)
        //{
        //    Response.Write("<br/>" p.ID + "<br/>"
        //        + "Mfg: " + p.Mfg + "<br/>"
        //        + "Model: " + p.Model + "<br/>"
        //        + "Part: " + p.Part + "<br/>"
        //        + "Description: " + p.Description + "<br/>"
        //        + "Image Filename: " + p.Image + "<br/><br/><br/>");
        //}
    }
}