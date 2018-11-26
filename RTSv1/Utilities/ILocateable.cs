using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // Logical reference to Image class inside system

namespace Utilities
{
    interface ILocatable
    {
        string Name { get; set; }
        Vector Pos { get; set; }
        Vector Vel { get; set; }
        Vector Acc { get; set; }
        int HP { get; set; }
        Image Img { get; }
        int Height { get; }
        int Width { get; }

    }
}
