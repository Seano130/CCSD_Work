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
        public Vector Pos, Vel, Acc, Goal;
        public float Angle; // Orientation
        public int Speed; // how fast he can move in one timer tick
        public Image Img; // Image Representing it
        protected List<Shimada> contacts = new List<Shimada>();


        public Shimada(Vector pos, Vector vel, Vector acc, Vector goal, float angle, int spd, Image img)
        {
            Pos = pos;
            Vel = vel;
            Acc = acc;
            Goal = goal;
            Angle = angle;
            Speed = spd;
            Img = img;
        }

        public void Sense(List<Shimada> cts)
        {

            contacts = cts; // make a note of who i see around me
        }


        public void Move(double time)
        {
            if(contacts.Count > 0)
            {
                Shimada enemy = contacts[0]; // get my first enemy from my list
                Goal = enemy.Pos; // make the enemy's position my goal
           
            }
             // I see no one to attack, so go to my goal position
                Vector pointToGoal = Goal - Pos; // face my goal
            double distToGoal = pointToGoal.Magnitude;
            if (distToGoal > 10)
            {
                Vector point = Goal - Pos;
                Vector unit = point.Unitized;
                Vel = Speed * unit; // scale up velocity
            }
            else
            {
                Vel = new Vector(0, 0);
            }
            Vel = Vel + Acc * time; // calc my new Velocity
            Pos = Pos + Vel * time; // calc my new position in space 
        }

    }
}
