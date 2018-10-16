using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detail : System.Web.UI.Page
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
        if(Session["user"] == null)
        { // bouncer check
            Response.Redirect("Login.aspx");
        }

        if(Session["Product"] != null)
        { // make sure a Session var exists, otherwise bounce them to Products...

            Response.Redirect("Products.aspx");
        }

        int id = (int)Session["product"]; // get id of product from Session
        Product p = zenyatta.GetProductChoice(id); // pull product info from DB
        lblPart.Text = p.Part;
        lblID.Text = p.ID.ToString();
        lblMfr.Text = p.Mfg;
        lblModel.Text = p.Model;
        lblPrice.Text = "$" + p.Price.ToString();
        tbDesc.Text = p.Description;
        // now create a "relative" path to the moonshine.jpg file...
        string relPathImg = Path.Combine("Images", "Products", p.Image);
        imgProduct.ImageUrl = relPathImg; // assign rel path to the Image ctrl

    }

    protected void btnProducts_Click(object sender, EventArgs e)
    { //Phase B

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    { //Phase B
        // need to get cart here...
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C

    }
}