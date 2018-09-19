using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // added for File manipulation
using System.Drawing; // needd for Image thumbnail creation

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
        Product p = allProds[0]; // get me just the 1st Product from the DB
        string imgFilenameDB = p.Image; // get the actual filename for this product
        string absImgFilename = Path.Combine(Server.MapPath(""), "Images", "Products", imgFilenameDB);

        System.Drawing.Image full = System.Drawing.Image.FromFile(absImgFilename);
        System.Drawing.Image thumb = full.GetThumbnailImage(1366, 768, null, IntPtr.Zero);

        string absThumbPath = Path.Combine(Server.MapPath(""),
            "Images", "Products", "Thumbs", imgFilenameDB);

        if (!File.Exists(absThumbPath))
        {
            thumb.Save(absThumbPath); // save the thumbnail to server HD
        }
        string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);

        imgProd.ImageUrl = relThumbPath; // point the Image control to the thumbnail



        //foreach(Product p in allProds)
        //{

        //}
    }
}