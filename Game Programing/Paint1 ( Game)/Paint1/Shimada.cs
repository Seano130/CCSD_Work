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
        public Vector Pos, Vel, Home;
        protected Vector Acc;
        public float Angle; // Orientation
        public int Speed, Acceleration; // how fast he can move in one timer tick
        public Image Img; // Image Representing it
        protected List<Shimada> contacts = new List<Shimada>();


        public Shimada(Vector pos, Vector vel, Vector home, float angle, int spd, int acceleration, Image img)
        {
            Pos = pos;
            Vel = vel;
            
            Home = home;
            Angle = angle;
            Speed = spd;
            Acceleration = acceleration;
            Img = img;
        }

        public void Sense(List<Shimada> cts)
        {

            contacts = cts; // make a note of who i see around me
        }


        public void Move(double time)
        {
            Vector Goal;
            if(contacts.Count > 0)
            {
                Shimada enemy = contacts[0]; // get my first enemy from my list
                Goal = enemy.Pos; // make the enemy's position my goal
           
            }
            else
            {
                Goal = Home; // go home if no enemy is nearby
            }
             // I see no one to attack, so go to my goal position
                Vector pointToGoal = Goal - Pos; // face my goal
            double distToGoal = pointToGoal.Magnitude;
            if (distToGoal > 10) // only calc if not already at my goal
            {
                Vector point = Goal - Pos;// face my goal
                Vector unit = point.Unitized;
                Acc = CalcAcc2(Goal);
               
            }
            else
            {
                Acc = new Vector(0, 0);
                Vel = new Vector(0, 0);
            }
            Vel = Vel + Acc * time; // calc my new Velocity
            Pos = Pos + Vel * time; // calc my new position in space 
        }

        // Original momentum based physics
        #region ugly code
        //protected Vector CalcAcc(Vector goal)
        //{
        //    Vector accNew;

        //    double lowBound = Speed * 0.3;
        //    double highBound = Speed * 0.7;
        //    double lowDist = 150;
        //    double highDist = 300;

        //    Vector pointToGoal = goal - Pos;
        //    double distToGoal = pointToGoal.Magnitude;
        //    double currSpd = Vel.Magnitude;
        //    if((distToGoal < lowBound) && (currSpd < lowBound) 
        //        || ((distToGoal >= lowDist && distToGoal < highDist) && (currSpd >= lowBound && currSpd < highBound))
        //        || (distToGoal > highDist && currSpd > highBound))
        //    {
        //        accNew = new Vector(0, 0); // no gas, no break
        //    }
        //    else if((distToGoal < lowDist && (currSpd > lowBound && currSpd <= highBound))
        //        || (distToGoal > lowDist && distToGoal <= highDist) && currSpd > highBound)
        //    {
        //        pointToGoal = -1 * pointToGoal; // reverse direction
        //        Vector unit = pointToGoal.Unitized;
        //        accNew = 0.5 * Acceleration * unit; // only apply half braking

        //    }
        //    else if(((distToGoal > lowDist && distToGoal <= highDist) && currSpd < lowBound)
        //        || (distToGoal > highDist && currSpd > lowBound && currSpd <= highBound))
        //    {
        //        Vector unit = pointToGoal.Unitized;
        //        accNew = 0.5 * Acceleration * unit; // only apply half gas
        //    }
        //    else if (distToGoal < lowDist && currSpd > highBound)
        //    {
        //        pointToGoal = -1 * pointToGoal; // reverse direction
        //        Vector unit = pointToGoal.Unitized;
        //        accNew = 1.0 * Acceleration * unit; // apply FULL braking
        //    }
        //    else if (distToGoal > highDist && currSpd < lowBound)
        //    {

        //        Vector unit = pointToGoal.Unitized;
        //        accNew = 1.0 * Acceleration * unit; // only apply half braking
        //    }
        //    else
        //    {
        //        // should never get here
        //        throw new Exception("Fire this programmer!");
        //    }


        //    return accNew;

        //}
        #endregion


        protected Vector CalcAcc2(Vector goal)
        {
            
            Vector accDesired;
            Vector pointToGoal = goal - Pos;
            Vector unitToGoal = pointToGoal.Unitized;
            double distToGoal = pointToGoal.Magnitude;
            double speedDesired = Speed;// desire max speed by default
            if (distToGoal < 400)
            {// if close to goal, then desire less than max speed...
                speedDesired = (int)((distToGoal / 400.0) * speedDesired);
            }
            Vector velDesired = speedDesired * unitToGoal;
            accDesired = 1 * (velDesired - Vel);
            return accDesired;
        }
    }
}
