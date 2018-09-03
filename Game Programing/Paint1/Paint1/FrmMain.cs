using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint1
{
    public partial class FrmMain : Form
    {
        protected Timer tmr;
        protected Shimada genji, hanzo;

        public FrmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
           | ControlStyles.OptimizedDoubleBuffer
           | ControlStyles.UserPaint, true);

            UpdateStyles(); // reduces flicker for high FPS
            genji = new Shimada(800, 100, 0, Properties.Resources.genji);
            hanzo = new Shimada(100, 100, 0, Properties.Resources.hanzo);
            tmr = new Timer();
            tmr.Interval = 16; // 16 millisec = 60 frames per sec
            tmr.Tick += Tmr_Tick;
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
         
            hanzo.X++;
            hanzo.Angle++;
            this.Invalidate(); // repaint the game
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics pic = e.Graphics;
            pic.Clear(Color.Gray);

            pic.TranslateTransform(genji.X, genji.Y);
            pic.RotateTransform(genji.Angle);
            pic.TranslateTransform(-Properties.Resources.genji.Width / 2,
                -Properties.Resources.genji.Height / 2); // back up slightly for centering
            pic.DrawImage(Properties.Resources.genji, new Point());

            pic.ResetTransform();
            pic.TranslateTransform(hanzo.X, hanzo.Y); // move hanzo in space
            pic.RotateTransform(hanzo.Angle); // rotate hanzo to his orientation
            pic.TranslateTransform(-Properties.Resources.hanzo.Width / 2,
                -Properties.Resources.hanzo.Height / 2); // back up slightly
            pic.DrawImage(Properties.Resources.hanzo, new Point());

        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                genji.Y -= 5;// move genji upward
            }
            else if (e.KeyCode == Keys.Down)
            {
                genji.Y += 5;// move genji downward
            }
            else if (e.KeyCode == Keys.Left)
            {
                genji.X -= 5;// move genji leftward 
            }
            else if (e.KeyCode == Keys.Right)
            {
                genji.X += 5; // move genji Rightward
            }

        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            if (tmr.Enabled == true)
            {
                tmr.Stop();
            }
            else
            {
                tmr.Start();
            }
        }
    }
}
