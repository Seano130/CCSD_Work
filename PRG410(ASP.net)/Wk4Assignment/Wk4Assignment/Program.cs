using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = new IShape[3];
            Width w = new Width();
            Height h = new Height();
            w.Value = 2.0;
            h.Value = 4.0;
            shapes[0] = new Triangle(w, h);
            shapes[1] = new Rectangle(5.0, 4.0);
            shapes[2] = new Circle(10.0);
            for (int i = 0; i < shapes.Length; i++)
            {
                Console.WriteLine("Shape - Type = {0} - Area = {1} - Perimeter = {2}", shapes[i].Type(), shapes[i].Area(), shapes[i].Perimeter());


            }
            Console.Read();

        }
    }
}
