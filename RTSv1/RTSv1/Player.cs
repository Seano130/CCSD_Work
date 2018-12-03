using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RTSv1
{
    public class Player
    {
        protected List<IMob> mobs = new List<IMob>(); // every mob in the game
        protected List<Building> buildings = new List<Building>(); // every building the player has bought
        public string TeamName;
    }
}
