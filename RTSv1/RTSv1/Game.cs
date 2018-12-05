using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using System.Windows.Forms; // needed for Timer object

namespace RTSv1
{
    public class Game
    {
        public Dictionary<IMob, List<ILocateable>> atlas = new Dictionary<IMob, List<ILocateable>>(); // maps for each mob
        public List<Player> players = new List<Player>();
        public List<ILocateable> Environment = new List<ILocateable>(); // every building, resource in the game
        protected DecisionTypeAnimation dta; // relates pairs of Mob/Mode with their appropriate animation
        protected Timer tmr;
        public event UpdatedHandler Update; // event to notify others of game changes 

        public Game()
        {
            tmr = new Timer();
            tmr.Interval = 17;
            tmr.Tick += Tmr_Tick;
            tmr.Start(); // begin immediately
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            Play(0.017); // play out next turn of the game
            //check if anyone listening...
            if (Update != null)
            { // send out msg containing players and current atlas for Picasso to paint
                Update(atlas, players);
            }

        }

        protected void Play(double timestep)
        {
            foreach (Player p in players)
            {
                foreach(IMob me in p.Mobs)
                {
                    List<ILocateable> WhatICurrentlySee = FindWhatICanSee(me);
                    Utilities.Action act = me.Decide(WhatICurrentlySee, atlas[me]);
                    ActOnThisDecision(me, act);

                }
            }
        }

        private static void ActOnThisDecision(IMob me, Utilities.Action act)
        {
            me.Mode = act.Decision; // set this mob to current mode
            switch (act.Decision)
            {
                case Decision.Attack:
                    //...
                    break;
                case Decision.Defend:
                    //...
                    break;
                case Decision.Flee:
                    //...
                    break;
                case Decision.Gather:
                    //...
                    break;
                case Decision.Move;
                    //...
                    break;
                default:
                    throw new Exception("Fire McKenzie because he did not handle this decision");
                    break;

            }
        }

        protected List<ILocateable> FindWhatICanSee(IMob me)
        {
            // create a container to store everything I can see..
            List<ILocateable> StuffICanSee = new List<ILocateable>();
            foreach(Player p in players)
            {
                foreach(IMob other in p.Mobs)
                {
                    List<ILocateable> whatICurrentlySee = FindWhatICanSee(me);
                    Decision dec = me.Decide(whatICurrentlySee, atlas[me]);
                }

                foreach(Building bldg in p.Buildings)
                {
                    Vector pointing = bldg.Pos - me.Pos;
                    double dist = pointing.Magnitude;
                    if (dist < me.SightRange)
                    {
                        StuffICanSee.Add(bldg);
                        List<ILocateable> myMap = atlas[me];
                        if (!myMap.Contains(bldg))
                        { // only add this bldg to my map if NOT already there
                            myMap.Add(bldg);                 
                        }
                    }
                }

                foreach(ILocateable loc in Environment)
                {
                    Vector pointing = loc.Pos - me.Pos;
                    double dist = pointing.Magnitude;
                    if (loc is IResource)
                    {
                        StuffICanSee.Add(loc);
                        List<ILocateable> myMap = atlas[me];
                        if (!myMap.Contains(loc))
                        { // only add this bldg to my map if NOT already there
                            myMap.Add(loc);
                        }
                    }
                }
            }

            return StuffICanSee;

        }

    }
}
