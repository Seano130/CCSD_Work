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
        protected Direction dir = Direction.None;
        protected int WM_KEYUP = 0x0101;
        protected int WM_KEYDOWN = 0x0100;

        public FrmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
           | ControlStyles.OptimizedDoubleBuffer
           | ControlStyles.UserPaint, true);

            UpdateStyles(); // reduces flicker for high FPS
            genji = new Shimada(new Vector(800, 100), new Vector (0, 0), new Vector(0,0), new Vector(0, 0), 0, Properties.Resources.genji);
            hanzo = new Shimada(new Vector (100, 100), new Vector( 10, 10), new Vector(0,0), 0, Properties.Resources.hanzo);
            tmr = new Timer();
            tmr.Interval = 16; // 16 millisec = 60 frames per sec
            tmr.Tick += Tmr_Tick;
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            //1st determine who the enemy can see within the range...
            Vector point = hanzo.Pos - genji.Pos; // face the enemy
            double dist = point.Magnitude; // calc dist between the 2 shimadas
            List<Shimada> contacts = new List<Shimada>();
            if (dist < 200)
            {
                contacts.Add(genji); // enemy can SEE us, so add us to the list of contacts
            }
            hanzo.Sense(contacts);

            // Calc genji's position by checking user input
            if(dir == Direction.Left)
            {
                genji.Vel.X -= 5;
            }
            else if(dir == Direction.Right)
            {
                genji.Vel.X += 5;
            }
            else if (dir == Direction.Up)
            {
                genji.Vel.Y -= 5;
            }
            else if (dir == Direction.Down)
            {
                genji.Vel.Y += 5;
            }
            else if(dir == Direction.None)
            {
                genji.Vel.X = 0; // stop instantly
                genji.Vel.Y = 0;
            }
            genji.Move(0.1); // Have genji calculate his new position
            hanzo.Move(0.2); // Have hanzo calc his new position in space
            this.Invalidate(); // repaint the game
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics pic = e.Graphics;
            pic.Clear(Color.Gray);

            pic.TranslateTransform((float)genji.Pos.X,(float) genji.Pos.Y);
            pic.RotateTransform(genji.Angle);
            pic.TranslateTransform(-Properties.Resources.genji.Width / 2,
                -Properties.Resources.genji.Height / 2); // back up slightly for centering
            pic.DrawImage(Properties.Resources.genji, new Point());

            pic.ResetTransform();
            pic.TranslateTransform((float)hanzo.Pos.X, (float)hanzo.Pos.Y); // move hanzo in space
            pic.RotateTransform(hanzo.Angle); // rotate hanzo to his orientation
            pic.TranslateTransform(-Properties.Resources.hanzo.Width / 2,
                -Properties.Resources.hanzo.Height / 2); // back up slightly
            pic.DrawImage(Properties.Resources.hanzo, new Point());

        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                dir = Direction.None;
            }

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.Msg == WM_KEYDOWN)
            {
                if (keyData == Keys.Up)
                {
                    dir = Direction.Up; // move genji upward
                }
                else if (keyData == Keys.Down)
                {
                    dir = Direction.Down;// move genji downward
                }
                else if (keyData == Keys.Left)
                {
                    dir = Direction.Left;// move genji leftward 
                }
                else if (keyData == Keys.Right)
                {
                    dir = Direction.Right; // move genji Rightward
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
