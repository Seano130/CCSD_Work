using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class frmMain : Form
    {
        protected Timer tmr;
        protected double totalTime;
        protected bool goingForward;
        public frmMain()
        {
            InitializeComponent();
            tmr = new Timer();
            tmr.Interval = 100; // in milliseconds
            tmr.Tick += tmr_Tick; // subscribe to the timers tick event
            totalTime = 0; // start time at 0
            lblTime.Text = totalTime.ToString(); // initialize label to time zero
            goingForward = true;
        }

        void tmr_Tick(object sender, EventArgs e)
        {
            if (goingForward == true)
            {
                totalTime = totalTime + 0.1;
            }
            else
            {
                totalTime = totalTime - 0.1; //increment time
            }
            lblTime.Text = totalTime.ToString("N1"); // dump time to screen
        }

       protected void btnStart_Click(object sender, EventArgs e)
        {
            tmr.Start();

        }

       protected void btnStop_Click(object sender, EventArgs e)
        {
            tmr.Stop();
            goingForward = !goingForward;

          
        }

       
       


      

    }
}
