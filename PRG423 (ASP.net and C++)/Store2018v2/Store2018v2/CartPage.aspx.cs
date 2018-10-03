using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["cart"] != null)
        {

            Cart c = (Cart)Session["cart"];
            foreach (KeyValuePair<Product, int> kvp in c.Items)
            {
                Product p = kvp.Key;
                int qty = kvp.Value;
                Response.Write(p.ID + "<br/>" 
                    + p.Mfg + "<br/>" 
                    + p.Model + "<br/>" 
                    + p.Part + "<br/>"
                    + p.Price + "<br/>"
                    + "Qty: " + qty + "<br/><br/><br/>");
            }
        }
    }
}