using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // need this for Path.Combine
using System.Drawing;

public partial class MgmtCreate : System.Web.UI.Page
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

        // BOUNCER CHECK
        if (Session["user"] == null) 
        { // if not logged in, then get out

            Response.Redirect("Login.aspx");
        }
        else
        {
            UserInfo ui = (UserInfo)Session["user"];
            if (ui.Rights == AdminRights.User)
            {
                //bounce uot if not a manager/owner
                Response.Redirect("Login.aspx");
            }

        }
        btnAddProduct.Visible = false; // Hide add product btn until its needed
        imgPreview.Visible = false; // Hide image ctrl until needed...
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    { // Phase B
        if (fuImage.HasFile) // make sure a file was loaded into ctrl by user
        { // build an absolute path on the server to save the file at...

            string[] extsAllowed = { ".png", ".bmp", ".jpg", ".jpeg", ".gif" };
            FileInfo fi = new FileInfo(fuImage.FileName); // object to insect details about file
            if (extsAllowed.Contains(fi.Extension))
            {
                string absTempImgPath = Path.Combine(Server.MapPath(""), "Images", fuImage.FileName);
                fuImage.SaveAs(absTempImgPath); // upload and save selected file
                string relTempPath = Path.Combine("Images", fuImage.FileName);
                imgPreview.ImageUrl = relTempPath;
                // load img into Server RAM to get Width/Height info...
                System.Drawing.Image imgRAM = System.Drawing.Image.FromFile(absTempImgPath);
                imgPreview.Width = imgRAM.Width;
                imgPreview.Height = imgRAM.Height;

            }
            else
            {

            }
        }

    }

    protected void btnAddProduct_Click(object sender, EventArgs e)
    { // Phase B


    }


    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        if (fuImage.HasFile)
        {

            if (imgPreview.ImageUrl != "")
            {
                imgPreview.Visible = true; // SEEMS like the right thing to do
            }

        }

    }
}