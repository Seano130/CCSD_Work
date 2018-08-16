
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Circle : IShape {

    public Circle()
    {


    }

    private double mRadius;

    
    public double Area()
    {

        return Math.PI * mRadius * mRadius;
       
      
    }

    public double Perimeter()
    {
        return 2 * Math.PI * mRadius;
        
    }

   
    public String Type() {

        return "Circle";
    }

    public Circle(double radius) {

        mRadius = radius;
      
    }


}