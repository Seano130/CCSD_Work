using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RTSv1
{
    public class Building : ILocateable
    {
        public BuildingType Type;
        public List<IMob> InQueue;

        public string Name { get;  set; } // implement Name by storing with hidden backing variable
        public Vector Pos { get; set; }

        protected int hp;
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                if(value <= 0)
                {
                    hp = 0; // do not allow hp < 0
                }
            }
        }
        protected Animation ani; // manually created backing var for Img property
        public Image Img
        {
            get
            {// use IF logic to choose which frame to return the drawer (Picasso)..
                return ani.Frame;
            }
        }

        public int Height
        {
            get
            {
                return ani.Height; // return height of CURRENT frame without indexing to next one
            }
        }

        public int Width => throw new NotImplementedException();
    }
}
