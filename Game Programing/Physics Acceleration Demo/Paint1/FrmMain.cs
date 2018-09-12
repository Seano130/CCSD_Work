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
        protected Saiyan Goku, Vegeta;
        protected List<Projectile> projectiles = new List<Projectile>();
        protected Direction dir = Direction.None;
        protected int WM_KEYUP = 0x101;
        protected int WM_KEYDOWN = 0x100;

        public FrmMain()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint, true);
            UpdateStyles();// reduces flicker for high FPS
            WindowState = FormWindowState.Maximized;
            Goku = new Saiyan(new Vector(800, 100), new Vector(0, 0),
                new Vector(0, 0), 0, 400, 10, Properties.Resources.Goku);
            Vegeta = new Saiyan(new Vector(100, 100), new Vector(10, 0),
                new Vector(100, 800), 0, 200, 5, Properties.Resources.Vegeta);
            tmr = new Timer();
            tmr.Interval = 16;// 16 millisec = 60 frames per sec
            tmr.Tick += Tmr_Tick;
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {  // 1st determine if the enemy can see Player within range...
            Vector point = Vegeta.Pos - Goku.Pos;// face the enemy
            double dist = point.Magnitude;// calc dist between the 2 saiyans
            List<Saiyan> contacts = new List<Saiyan>();
            if(dist < 400)
            {
                contacts.Add(Goku);// enemy can SEE us, so add us to list of contacts
            }
            Vegeta.Sense(contacts);// enemy now SENSES the Player

            // Calc Goku's new Velocity by checking user input...
            //if(dir == Direction.Left)
            //{
            //    Goku.Vel.X -= 5;
            //}
            //else if(dir == Direction.Right)
            //{
            //    Goku.Vel.X += 5;
            //}
            //else if(dir == Direction.Up)
            //{
            //    Goku.Vel.Y -= 5;
            //}
            //else if(dir == Direction.Down)
            //{
            //    Goku.Vel.Y += 5;
            //}
            //else if(dir == Direction.None)
            //{
            //    Goku.Vel.X = 0;// stop instantly
            //    Goku.Vel.Y = 0;
            //}
            Goku.Move(0.1);// Have Goku calc his new position in space
            Vegeta.Move(0.1);// Have Vegeta calc his new position in space
            foreach (Projectile p in projectiles)
            {// update positions of all projectiles in the air...
                p.Move(0.1);
            }
            this.Invalidate();// repaint the game
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics pic = e.Graphics;
            pic.Clear(Color.Black);

            pic.TranslateTransform((float)Goku.Pos.X, (float)Goku.Pos.Y);// move Goku in space
            pic.RotateTransform(Goku.Angle);// rotate Goku to his proper orientation
            pic.TranslateTransform(-Properties.Resources.Goku.Width / 2,
                -Properties.Resources.Goku.Height / 2);// back up slightly for centering
            pic.DrawImage(Properties.Resources.Goku, new Point());

            pic.ResetTransform();
            pic.TranslateTransform((float)Vegeta.Pos.X, (float)Vegeta.Pos.Y);//move Vegeta in space
            pic.RotateTransform(Vegeta.Angle);// rotate Vegeta to his orientation
            pic.TranslateTransform(-Properties.Resources.Vegeta.Width / 2,
                -Properties.Resources.Vegeta.Height / 2);// back up slightly
            pic.DrawImage(Properties.Resources.Vegeta, new Point());

            foreach (Projectile p in projectiles)
            {
                pic.ResetTransform();
                pic.TranslateTransform((float)p.Pos.X, (float)p.Pos.Y);
                pic.RotateTransform((float)p.Angle);
                pic.TranslateTransform(-p.Image.Width / 2, -p.Image.Height / 2);
                pic.DrawImage(p.Image, new Point());
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up || e.KeyCode == Keys.Down
                || e.KeyCode == Keys.Left ||e.KeyCode == Keys.Right)
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
                    dir = Direction.Up;
                }
                else if (keyData == Keys.Down)
                {
                    dir = Direction.Down;
                }
                else if (keyData == Keys.Left)
                {
                    dir = Direction.Left;
                }
                else if (keyData == Keys.Right)
                {
                    dir = Direction.Right;
                }
                return true;
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Vector goal = new Vector(e.X, e.Y);// set a vector pointing to the mouse click position
                Goku.Home = goal;    // make Goku's goal be the same as the onscreen mouse click position
            }
            else if(e.Button == MouseButtons.Right)
            {// insert fireball launch code here...
                Vector click = new Vector(e.X, e.Y);
                Vector point = click - Goku.Pos;
                Vector unit = point.Unitized;
                Vector pVel = new Vector(0, 0);// start velocity at zero (not moving)
                Vector pPos = new Vector(Goku.Pos.X, Goku.Pos.Y);
                Vector pAcc = 400 * unit;// have firball ACCELERATE instead
                Projectile p = new Projectile(pPos, pVel, pAcc, 200,
                    50, Properties.Resources.FireballSmall);
                projectiles.Add(p);// add this projectile to the overall list
            }
        }

        private void btnTimer_Click(object sender, EventArgs e)
        {
            if(tmr.Enabled == true)
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
