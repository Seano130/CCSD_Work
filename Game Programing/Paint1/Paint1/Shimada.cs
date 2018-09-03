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
        public Image Img; // Image Representing it
        protected List<Shimada> contacts = new List<Shimada>();


        public Shimada(Vector pos, Vector vel, Vector acc, Vector goal, float angle, Image img)
        {
            Pos = pos;
            Vel = vel;
            Acc = acc;
            Goal = goal;
            Angle = angle;
            Img = img;
        }

        public void Sense(List<Shimada> cts)
        {

            contacts = cts; // make a not of who i see around me
        }


        public void Move(double time)
        {
            if(contacts.Count > 0)
            {
                Shimada enemy = contacts[0]; // get my first enemy from my list
                Vector point = enemy.Pos - Pos; // face my enemy
                Vector unit = point.Unitized;
                Vel = 3 * unit; // scale up my velocity according to my speed factor of 3
            }
            else
            { // I see no one to attack, so go to my goal position
                Vector point = Goal - Pos; // face my goal
                Vector unit = point.Unitized;
                Vel = 3 * unit; // scale up velocity
            }
//          Vel = Vel + Acc * time; // calc my new Velocity
            Pos = Pos + Vel * time; // calc my new position in space 
        }

    }
}
