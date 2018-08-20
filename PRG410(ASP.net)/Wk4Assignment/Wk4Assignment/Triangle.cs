
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Triangle : IShape {

    public Triangle() {

    }

    private double mWidth;

    private double mHeight;


    public double Area()
    {
        return mWidth * mHeight / 2;

    }


    public double Perimeter()
    {
        double diagSq = mHeight * mHeight + mWidth * mWidth;
        double diag = Math.Sqrt(diagSq);
        return (diag + mHeight + mWidth);
    }

 
    public  Triangle(Width width, Height height)
    {
        mWidth = width.Value;
        mHeight = height.Value;
    }

 


    public String Type() {
        return "Right Triangle";
    }

}