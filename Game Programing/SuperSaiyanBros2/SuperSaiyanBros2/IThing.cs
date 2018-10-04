using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperSaiyanBros
{
    interface IThing
    {
        string Name
        {
            get; set;
        }

        Image Img
        {
            get; 
        }

        Vector Position
        {
            get; set;
        }

        Animation Ani
        {
            get;
        }
        

    

    }
}
