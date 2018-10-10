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
        PopulatePlaceHolder(); // fill the placeholder for possible future event handling below
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
        Button b = (Button)sender;
        string idAsString = b.ID.Substring(3);
        int idBtn = Convert.ToInt16(idAsString);
        int id = Convert.ToInt16(idAsString);
        
        if (Session["cart"] != null)
        {
            Cart c = (Cart)Session["cart"];     
            Product p = zenyatta.GetProductChoice(idBtn);
            foreach (Control ctrl in phMain.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox tbQty = (TextBox)ctrl;
                    string idTBAsString = tbQty.ID.Substring(2);
                    int idTB = Convert.ToInt16(idTBAsString);
                    if (idTB == idBtn)
                    {
                        string qtyAsString = tbQty.Text;
                        int qty = Convert.ToInt16(qtyAsString);
                        c.ChangeQuantity(p, qty);

                    }
                }
            }
            
            Session["cart"] = c; // upload updated Cart back into Session
        }
    }

    protected void Page_PreRender(object sender, EventArgs e)
    { //Phase C
        if (IsPostBack)
        {
            phMain.Controls.Clear(); // clear out all controls and prepare for re-population
            PopulatePlaceHolder(); // re-populate all products from cart again
        }
        Cart c = (Cart)Session["cart"];
        lblTotValue.Text = c.Total.ToString();

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
                tbQty.Text = qty.ToString(); // get the quantity of item
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