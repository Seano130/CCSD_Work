using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Paint1
{
    public partial class FrmMain : Form
    {
        protected Timer tmr;
        protected Dictionary<string, Shimada> shimadas = new Dictionary<string, Shimada>();
        protected List<Projectile> projectiles = new List<Projectile>();
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
            WindowState = FormWindowState.Maximized;
            Shimada genji = new Shimada(new Vector(800, 100), new Vector (0, 0), new Vector(0, 0), 0, 60, 10, Properties.Resources.genji);
            Shimada hanzo = new Shimada(new Vector(100, 100), new Vector(10, 0), new Vector(100, 600), 0, 40, 5, Properties.Resources.hanzo);

            shimadas.Add("genji",genji);
            shimadas.Add("hanzo",hanzo);

            tmr = new Timer();
            tmr.Interval = 16; // 16 millisec = 60 frames per sec
            tmr.Tick += Tmr_Tick;

            
            
        }

        private void Tmr_Tick(object sender, EventArgs e)
        {
            //1st determine who the enemy can see within the range...
            Vector point = shimadas["genji"].Pos - shimadas["hanzo"].Pos; // face the enemy
            double dist = point.Magnitude; // calc dist between the 2 shimadas
            List<Shimada> contacts = new List<Shimada>();
            if (dist < 400)
            {
                contacts.Add(shimadas["genji"]); // enemy can SEE us, so add us to the list of contacts
            }
            shimadas["hanzo"].Sense(contacts); // enemy senses player


            shimadas["genji"].React(0.1); // Have genji calculate his new position
            //shimadas["hanzo"].Move(0.07); // Have hanzo calc his new position in space
            Action actTaken = shimadas["hanzo"].React(0.1);
            foreach (Projectile p in projectiles)
            { // update positions of all projectiles in the air...
                p.Move(0.1);
            }
            Action actTaken = shimadas["genji"].React(0.1);// Have Vegeta calc his new position in space
            if (actTaken.Type == ActionType.Attack)
            {
                Vector pointOfAttack = actTaken.Target - saiyans["vegeta"].Pos;
                Vector unit = pointOfAttack.Unitized;
                Vector pVel = new Vector(0, 0);// start velocity at zero (not moving)
                Vector pPos = new Vector(saiyans["vegeta"].Pos.X, saiyans["vegeta"].Pos.Y);
                Vector pAcc = 400 * unit;// have firball ACCELERATE instead
                Animation ani = new Animation(Properties.Resources.Fireball, 256, 256, 0, 0, 6, 8, 0.5, 0.5, false);
                Projectile p = new Projectile(pPos, pVel, pAcc, 200,
                    50, "genji", ani);
                projectiles.Add(p);// add this projectile to the overall list
            }
            foreach (Projectile p in projectiles)
            {// update positions of all projectiles in the air...
                p.Move(0.1);
            }



            DetectCollisions();
            this.Invalidate(); // repaint the game
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics pic = e.Graphics;
            pic.Clear(Color.Gray);

          

            foreach (KeyValuePair<string, Shimada> kvp in shimadas)
            {
                Shimada s = kvp.Value;
                pic.TranslateTransform((float)s.Pos.X, (float)s.Pos.Y); // move genji in space
                pic.RotateTransform(s.Angle); // rotate genji to his proper orientation
                pic.TranslateTransform(-s.Img.Width / 2,
                    -s.Img.Height / 2); // back up slightly for centering
                pic.DrawImage(s.Img, new Point());
            }

          

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

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Vector goal = new Vector(e.X, e.Y); // set a vector pointing to the mouse click position
                shimadas["genji"].Home = goal; // make hanzo's goal be the same as te onscreen mouse click position
            }
            else if(e.Button == MouseButtons.Right)
            { // insert shuriken launch code here...
                Vector click = new Vector(e.X, e.Y);
                Vector point = click - shimadas["genji"].Pos;
                Vector unit = point.Unitized;
                Vector pVel = new Vector(0, 0); // start velocity at zero (not moving)
                Vector pPos = new Vector(shimadas["genji"].Pos.X, shimadas["genji"].Pos.Y);
                Vector pAcc = 60 * unit; // have shuriken ACCELERATE instead
                Projectile p = new Projectile(pPos, pVel, pAcc, 200, 50, "geni", Properties.Resources.shuriken);
                projectiles.Add(p); 


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


        protected void DetectCollisions()
        {
            List<int> projToDelete = new List<int>();
            // Detect collisions between Shimadas and Projectiles
            foreach (KeyValuePair<string, Shimada> kvp in shimadas)
            {
                string name = kvp.Key; // Shimada's name
                Shimada s = kvp.Value; // Shimada object
                foreach (Projectile p in projectiles)
                {
                    if(p.Owner == name)
                    { // skip this projectile in case of friendly fire
                        continue; // a continue statement restarts the foreach statement if encountered

                    }
                    Vector point = s.Pos - p.Pos;
                    double dist = point.Magnitude; // get dist between their centers
                    if(dist < s.Img.Width / 2 + p.Image.Width / 2)
                    { // we collided, so get index of proj...
                        int idx = projectiles.IndexOf(p);
                        if(!projToDelete.Contains(idx))
                        { // only add proj to delete list if not already there...
                            projToDelete.Add(idx);
                        }
                       
                    }
                }
            }

            // Now safe to delete the projectiles that have been marked for deletion...
            projToDelete.Sort();
            projToDelete.Reverse();
            foreach (int idx in projToDelete)
            { // use the proj known to remove him from the list...
                projectiles.RemoveAt(idx);
            }
        }
    }
}
