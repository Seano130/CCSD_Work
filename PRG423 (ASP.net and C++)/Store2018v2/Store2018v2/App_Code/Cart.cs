using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Cart
{
    public double Total
    {
        get
        {
            // for loop to calc my total

            decimal tot = 0.0M;

            foreach (KeyValuePair<Product, int> kvp in Items)
            {
                
                decimal subTot = 0.0M;
                Product p = kvp.Key;
                decimal price = p.Price;
                int qty = kvp.Value;
                subTot = price * qty;
                tot = tot + subTot;
            }

            return tot;
        }
    }
    public Dictionary<Product, int> Items;

    public Cart()
    { //Instantiate a new Dictionary that is emtpy
        Items = new Dictionary<Product, int>();
    }

    public Cart(Dictionary<Product, int> prods)
    { // create a dictionary that is filled with items passed in...
        Items = prods;

    }

    public void Add(Product p, int qty)
    {
        if(Items.ContainsKey(p))
        {
            // Product already in Cart, So simply increase its Qty...
            Items[p] += qty;
        }
        else
        {
            Items.Add(p, qty);
        }
        
    }

    public void Empty()
    {
        // Remove all items from the cart...
        Items.Clear();
        Total = 0.0;
    }

    public double GetTotal()
    { // calc the total 
        double tot = 0.0;
        return tot;
    }

    public void ChangeQuantity(Product p, int newQty)
    {   // alter the qty of tiems in my Cart...
        if (newQty > 0)
        {

 //           if (Items.ContainsKey(p))
            {
                Items[p] = newQty;
            }
        }

    }

}