using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint1
{
    public class Shimada
    {
        public int X, Y; // Position in space
        public float Angle; // Orientation
        public Image Img; // Image Representing it


        public Shimada(int x, int y, float angle, Image img)
        {
            X = x;
            Y = y;
            Angle = angle;
            Img = img;
        }

    }
}
