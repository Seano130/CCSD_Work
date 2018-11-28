using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Utilities;

namespace RTSv1
{
    public struct Pair
    {
        public Decision decision;
        public IMob mob;

        public Pair(IMob m, Decision d)
        {
            mob = m;
            decision = d;
        }
    }
    public struct DecisionTypeAnimation
    {   private Dictionary<Decision, Animation> decAnis;
        private Dictionary<IMob, int> indices;

        public DecisionTypeAnimation(Dictionary<Decision, Animation> decAnis)
        {
            this.decAnis = decAnis; // store what was handed to us by the Game object
            this.indices = new Dictionary<string, int>(); // no IMobs exist at beginning, they're added later

        }

        public void AddNewMob(IMob mob)
        {
            indices.Add(mob, 1);
        }

        public Image GetFrame(IMob mob)
        {
            // first form the Pair to use as a key...
            Pair pr = new Pair(mob, mob.Mode);

            Animation ani = decAnis[pr];


        }

    }
}
