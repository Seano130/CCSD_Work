using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Cart
{
    public Dictionary<Product, int> Items;

    public Cart(Dictionary<Product, int> prods)
    {
        Items = prods;

    }

    public void Add(Product p, int qty)
    {
        if(Items.ContainsKey(p))
        {
            Items[p] += qty;
        }
        else
        {
            Items.Add(p, qty);
        }
        
    }
}