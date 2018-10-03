using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // added for File manipulation
using System.Drawing; // needd for Image thumbnail creation
using System.Web.UI.HtmlControls; // needed for the <br/> tag in the Placeholder

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

        #region DDL
        //if (!IsPostBack)
        //{// initialize the DDL for 1st time use...
        //    ddlProducts.Items.Add(""); // add blank entry so that NOTHING is inistially selected
        //    List<Product> allProds = zenyatta.GetAllProducts();
        //    foreach (Product p in allProds)
        //    {
        //        ddlProducts.Items.Add(p.Model + " " + p.Part);
        //    }
        //}
        //ddlProducts.Visible = false;
        #endregion

        if (!IsPostBack)
        { // only on first page load, create a brand new empty cart 
            Cart c = new Cart();
            Session["cart"] = c;
        }
    }


    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
       
        UserInfo ui = (UserInfo)Session["user"]; // get out their credential from Session
        Response.Write("Welcome, " + ui.First + " " + ui.Last + "!");

        List<Product> allProds = zenyatta.GetAllProducts();
        foreach (Product p in allProds)
        {

            string imgFilenameDB = p.Image; // get the actual filename for this product
            string absImgFilename = Path.Combine(Server.MapPath(""), "Images", "Products", imgFilenameDB);

            System.Drawing.Image full = System.Drawing.Image.FromFile(absImgFilename);
            System.Drawing.Image thumb = full.GetThumbnailImage(300, 300, null, IntPtr.Zero);

            string absThumbPath = Path.Combine(Server.MapPath(""),
                "Images", "Products", "Thumbs", imgFilenameDB);

            if (!File.Exists(absThumbPath))
            {
                thumb.Save(absThumbPath); // save the thumbnail to server HD
            }
            string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);

            ImageButton imgProd = new ImageButton(); // programatic instantiation 
            imgProd.ImageUrl = relThumbPath; // assign it to a thumbnail
            imgProd.ID = "img" + p.ID; // give it a name containing the unique product ID
            imgProd.Click += ImgProd_Click;
            phMain.Controls.Add(imgProd);

            HtmlGenericControl br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

            Label lblMfr = new Label();
            lblMfr.Text = p.Mfg;
            lblMfr.Font.Bold = true;
            lblMfr.Font.Italic = true;
            lblMfr.ForeColor = Color.AliceBlue;
            lblMfr.BackColor = Color.IndianRed;
            phMain.Controls.Add(lblMfr);


            Label lblModel = new Label();
            lblModel.Text = p.Model;
            phMain.Controls.Add(lblModel);
            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

            Label lblPart = new Label();
            lblPart.Text = p.Part;
            phMain.Controls.Add(lblPart);
            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);

            Label lblQty = new Label();
            lblQty.Text = "Qty:";
            phMain.Controls.Add(lblQty);

            TextBox tbQty = new TextBox();
            tbQty.ID = "tb" + p.ID;
            tbQty.Text = "1";
            tbQty.Width = 20;
            tbQty.BackColor = Color.Aqua;
            tbQty.BorderStyle = BorderStyle.Groove;
            tbQty.BorderWidth = 5;
            phMain.Controls.Add(tbQty);

            Button btnAddToCart = new Button();
            btnAddToCart.ID = "btn" + p.ID;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.BackColor = Color.Teal;
            btnAddToCart.BorderStyle = BorderStyle.Inset;
            btnAddToCart.BorderWidth = 10;
            btnAddToCart.Click += BtnAddToCart_Click;
            phMain.Controls.Add(btnAddToCart);

            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);
            br = new HtmlGenericControl("br");
            phMain.Controls.Add(br);


        }


    }

    private void BtnAddToCart_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        string idAsString = btn.ID.Substring(3);
        int id = Convert.ToInt32(idAsString);

        //Dictionary<Product, int> chosen = new Dictionary<Product, int>();
        //chosen.Add(zenyatta.GetProductChoice(id), 1);

        if(Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];
            Product p = zenyatta.GetProductChoice(id);
            // search the list of Controls looking for the correct TextBox
            foreach (Control ctrl in phMain.Controls)
            { 
                if (ctrl is TextBox)
                { // now safe to typecast him as a Textbox...
                    TextBox tbQty = (TextBox)ctrl;
                    string idTBAsString = tbQty.ID.Substring(2);
                    int idTB = Convert.ToInt32(idTBAsString);
                    if(idTB == idProd)
                    {
                        string qtyAsString = tbQty.Text;
                        int qty = Convert.ToInt32(qtyAsString);
                        c.Add(p, qty); // finally...
                        Session["cart"] = c;
                    }

                }

            }
            Response.Redirect("CartPage.aspx");
        }
        
    }

    private void ImgProd_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton ib = (ImageButton)sender; // typecast the sender as the type that we know he is
        string idAsString = ib.ID.Substring(3);
        int id = Convert.ToInt32(idAsString); //convert it to an int for purposes of zenyatta looking it up
        Session["product"] = id; // place the id into Session, so that it can be retrieved on another page
        Response.Redirect("Detail.aspx"); // send them to a detail page
    }
}