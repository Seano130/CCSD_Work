
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Rectangle : IShape {

    public Rectangle() {
    }

    private double mWidth;

    private double mHeight;

   


    public Rectangle(double width, double height)
    {
        mWidth = width;
        mHeight = height;

    }


    public double Area()
    {
        return mWidth * mHeight;

    }

 
    public double Perimeter()
    {

        return 2 * (mHeight + mWidth);
    }

    public String Type()
    {
        return "Rectangle";
    }
}