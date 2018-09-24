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
            System.Drawing.Image thumb = full.GetThumbnailImage(100, 100, null, IntPtr.Zero);

            string absThumbPath = Path.Combine(Server.MapPath(""),
                "Images", "Products", "Thumbs", imgFilenameDB);

            if (!File.Exists(absThumbPath))
            {
                thumb.Save(absThumbPath); // save the thumbnail to server HD
            }
            string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);
            System.Web.UI.WebControls.Image imgProd = new System.Web.UI.WebControls.Image();

            imgProd.ImageUrl = relThumbPath; // point the Image control to the thumbnail

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

            HtmlGenericControl para = new HtmlGenericControl("p");


        }


        //foreach(Product p in allProds)
        //{

        //}
    }
}