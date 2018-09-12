using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Paint1
{
    public class Projectile
    {
        public Vector Pos, Vel, Acc;
        public int Speed, Damage;
        public double Angle
        {
            get
            {
                return Vel.Angle;
            }
        }
        public Image Image;

        public Projectile(Vector pos, Vector vel, Vector acc,
            int spd, int dam, Image img)
        {
            Pos = pos;
            Vel = vel;
            Acc = acc;
            Speed = spd;
            Damage = dam;
            Image = img;
        }

        public void Move(double time)
        {
            Vel = Vel + Acc * time;
            Pos = Pos + Vel * time;
        }
    }
}
