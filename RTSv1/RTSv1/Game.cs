using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace RTSv1
{
    public class Game
    {
        public Dictionary<IMob, List<ILocateable>> atlas = new Dictionary<IMob, List<ILocateable>>(); // maps for each mob
        public List<Player> players = new List<Player>();
        public List<ILocateable> Environment = new List<ILocateable>(); // every building, resource in the game
        protected DecisionTypeAnimation dta; // relates pairs of Mob/Mode with their appropriate animation


    }
}
