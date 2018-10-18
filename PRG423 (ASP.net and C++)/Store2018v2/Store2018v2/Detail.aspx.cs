using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // need this for Path.Combine() function
using System.Drawing; // need this for RAM-based Image manipulation

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

        if(Session["Product"] == null)
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
        //now form an "absolute" path to the moonshine.jpg (image of product) file...
        string absPathImg = Path.Combine(Server.MapPath(""), relPathImg);
        System.Drawing.Image imgRam = System.Drawing.Image.FromFile(absPathImg);
        imgProduct.Width = imgRam.Width; // make Img Control dimensions match original...
        imgProduct.Height = imgRam.Height;

    }

    protected void btnProducts_Click(object sender, EventArgs e)
    { //Phase B
        Response.Redirect("Products.aspx"); // user wants to return to Products page
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    { //Phase B
        // need to get cart here...
        int id = (int)Session["product"];
        Product p = zenyatta.GetProductChoice(id); // grab full info of Product based on this ID
        int qty = Convert.ToInt16(tbQty.Text); // int qty captures what's being passed in as int
        if (qty > 0)
        {

            if (Session["cart"] == null) // double check that Cart actually exists
            { //ONLY IF cart DOES NOT already exist, then create a brand new empty cart..
                Session["cart"] = new Cart();
            }
            Cart c = (Cart)Session["cart"];
            c.Add(p, qty);
            if (qty == 1)
            {
                Response.Write("One " + p.Part + " was added to your cart<br/>");
            }
            else
            {
                Response.Write(qty.ToString() + " " + p.Part + "'s was added to your Cart<br/>");
            }

        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { // Phase C

    }
}