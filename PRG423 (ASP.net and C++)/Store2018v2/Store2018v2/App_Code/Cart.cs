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

            double tot = 0.0;

            foreach (KeyValuePair<Product, int> kvp in Items)
            {
                double subTot = 0.0;
                Product p = kvp.Key;
                double price = p.Price;
                int qty = kvp.Value;
                subTot = price * qty;
                tot = tot + subTot;
            }

            return tot;
        }
    }
    public Dictionary<Product, int> Items;

    public Cart(Dictionary<Product, int> prods)
    {
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

    public void Change(Product p, int newQty)
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