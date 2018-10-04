using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SuperSaiyanBros
{
    class Mob : IThing
    {
        #region Interface Properties
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        protected Vector position;
        public Vector Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        protected Animation ani;
        public Animation Ani
        {
            get
            {
                return ani;

            }
            set
            {
                ani = value;
            }
        }

       
        public Image Img
        {
            get
            {
                return ani.Frame;
            }
        }
        #endregion

        #region MobSpecificProperties
        protected RaceType race;
        public RaceType Race
        {
            get
            {
                return race;
            }
        }

        protected TraitType traid;
        public TraitType Trait
        {
            get
            {
                return Trait;
            }
        }
        #endregion

    }
}
