using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter10
{
    public abstract class Enemy
    {
        // Abstract methods can only fit into abstract classes 
        // Abstract methods do not have a body (no code associated with them)
        //
        public abstract void Walk();
      

        public virtual void Talk()
        {
            Console.WriteLine("Grunt");
        }
    }

    public class BigBoss : Enemy
    {
        //<summary>
        // This is redefining the method talk we had in the class,
        // such that the child class can behave differently (So BigBoss can emit different grunt
        // instead of regular grunt). The requirements for that to take place are:
        // - Talk needs to be virtual in the parent class\
        // - Talk needs to be overriden in the "Derived" (child) class.
        //</summary>

        public override void Talk()
        {
            Console.WriteLine("Boo");
        }

    }









}
