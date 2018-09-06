using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;


public class Product
{
    public int ID;
    public string Mfg; // Manufacturer
    public string Model;
    public string Part, Description;
    public string Image;


    public Product(int id, string mfg, string model, string part, string desc, string img)
    {
        ID = id;
        Mfg = mfg;
        Model = model;
        Part = part;
        Description = desc;
        Image = img;



    }
}