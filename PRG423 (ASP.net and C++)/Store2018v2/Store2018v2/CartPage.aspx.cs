using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO; // added for File manipulation
using System.Drawing; // needd for Image thumbnail creation
using System.Web.UI.HtmlControls; // needed for the <br/> tag in the Placeholder

public partial class CartPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { // Phase A
        PopulatePlaceHolder();
        if (Session["cart"] != null)
        {

            Cart c = (Cart)Session["cart"];
            foreach (KeyValuePair<Product, int> kvp in c.Items)
            {
                Product p = kvp.Key;
                int qty = kvp.Value;
               
            }
        }
    }

    protected void btnDeleteClick(object sender, EventArgs e)
    { //phase B
        
    }

    protected void btnChangeClick(object sender, EventArgs e)
    { //phase B

        

    }

    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        phMain.Controls.Clear(); // clear out all controls and prepare for re-population
        PopulatePlaceHolder(); // re-populate all products from cart again
    }

    protected void PopulatePlaceHolder()
    {
        if (Session["cart"] != null) // make sure Cart exists in Session
        {
            Cart c = (Cart)Session["cart"];
            foreach (KeyValuePair<Product, int>  kvp in c.Items)
            {
                Product p = kvp.Key; // get Product from the pair
                int qty = kvp.Value; // get the quantity assoc with that Product
                string imgFilenameDB = p.Image; // get the actual filename for this product
               

             

                string absThumbPath = Path.Combine(Server.MapPath(""),
                    "Images", "Products", "Thumbs", imgFilenameDB);              
                string relThumbPath = Path.Combine("Images", "Products", "Thumbs", imgFilenameDB);
                System.Web.UI.WebControls.Image imgProd = new System.Web.UI.WebControls.Image(); // programatic instantiation 
                imgProd.ImageUrl = relThumbPath; // assign it to a thumbnail
                imgProd.ID = "img" + p.ID; // give it a name containing the unique product ID           
                phMain.Controls.Add(imgProd);

                HtmlGenericControl br = new HtmlGenericControl("br");
                phMain.Controls.Add(br);



                Label lblPrice = new Label();
                lblPrice.Text = p.Price.ToString();
                lblPrice.Font.Bold = true;
                lblPrice.Font.Italic = true;
                lblPrice.ForeColor = Color.AliceBlue;
                lblPrice.BackColor = Color.IndianRed;
                phMain.Controls.Add(lblPrice);
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

                Button btnChange = new Button();
                btnChange.ID = "chg" + p.ID;
                btnChange.Text = "Change";
                btnChange.Click += btnChangeClick;
                phMain.Controls.Add(btnChange);

                Button btnDelete = new Button();
                btnDelete.ID = "del" + p.ID;
                btnDelete.Text = "Delete";
                btnDelete.Click += btnDeleteClick;
                phMain.Controls.Add(btnDelete);

                br = new HtmlGenericControl("br");
                phMain.Controls.Add(br);
                br = new HtmlGenericControl("br");
                phMain.Controls.Add(br);


            }
        }

    }

   
}