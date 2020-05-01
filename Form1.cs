using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class Form1 : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int ballStep = 3;
        bool mouseDown;
        private Point MouseDownLocation;
        private PictureBox brick = null;

        Timer mainTimer = null;

        public Form1()
        {
            InitializeComponent();
            InitializeApp();
        }
        private void InitializeApp()
        {
            verVelocity = ballStep;
            horVelocity = ballStep;
            Ball.BackColor = Color.Transparent;
            Ball.SizeMode = PictureBoxSizeMode.StretchImage;
            Ball.Image = Properties.Resources.DVD;

            this.KeyDown += new KeyEventHandler(App_KeyDown);

            UpdateBallStepLabel();
            InitializeMainTimer();
            BuildBricks(4, 6);
        }
        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Interval = 20;
            mainTimer.Start();
        }
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            MoveBall();
            BallBorderCollide();
            BallRacketCollision();
            BallBrickCollision();
        }
        private void MoveBall()
        {
            Ball.Top += verVelocity;
            Ball.Left += horVelocity;
        }
        private void BallBorderCollide()
        {
            if(Ball.Top + Ball.Height > ClientRectangle.Height || Ball.Top < 0) //collide w bottom or top
            {
                verVelocity = -verVelocity;
            }
            else if(Ball.Left < 0 || Ball.Left + Ball.Width > ClientRectangle.Width) // collide w left or right
            {
                horVelocity = -horVelocity;
            }          
        }
        private void App_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.X)
            {
                ballStep += 1;
                if (ballStep >1)
                {
                    verVelocity = ballStep * (verVelocity / Math.Abs(verVelocity));
                    horVelocity = ballStep * (horVelocity / Math.Abs(horVelocity));
                }
                else
                {
                    verVelocity = ballStep;
                    horVelocity = ballStep;
                }
                UpdateBallStepLabel();
            }
            else if (e.KeyCode == Keys.Z)
            {
                if (ballStep > 0)
                {
                    ballStep -= 1;
                    if (ballStep >1)
                    {
                        verVelocity = ballStep * (verVelocity / Math.Abs(verVelocity));
                        horVelocity = ballStep * (horVelocity / Math.Abs(horVelocity));
                    }
                    else
                    {
                        verVelocity = ballStep;
                        horVelocity = ballStep;
                    }
                }
                UpdateBallStepLabel();
            }
        }
        private void UpdateBallStepLabel()
        {
            BallStepLabel.Text = "Ball Step: " + ballStep;
        }

        private void BallRacketCollision()
        {
            {
                if (Ball.Bounds.IntersectsWith(Racket.Bounds))
                {
                    verVelocity = -verVelocity;
                }
            }
        }




        private void Racket_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void Racket_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Racket.Left = e.X + Racket.Left - MouseDownLocation.X;
                Racket.Top = e.Y + Racket.Top - MouseDownLocation.Y;
            }
        }
        private void BuildBricks(int rows, int cols)
        {
            int brickWidth = 60;
            int brickHeight = 20;
            int brickVerSpace = 5;
            int brickHorSpace = 10;

            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= cols; c++)
                {
                    brick = new PictureBox();
                    brick.BackColor = Color.RosyBrown;
                    brick.Width = brickWidth;
                    brick.Height = brickHeight;
                    brick.Left = c * (brickWidth + brickHorSpace);
                    brick.Top = r * (brickHeight + brickVerSpace);
                    brick.Tag = "brick";
                    this.Controls.Add(brick);
                }
            }
        }
        private void BallBrickCollision()
        {
            foreach(Control contr in this.Controls)
            {
                if ((string)contr.Tag == "brick") 
                {
                    if (contr.Bounds.IntersectsWith(Ball.Bounds))
                    {
                        contr.Dispose();
                        verVelocity *= -1;
                    }
                }
            }

        }

        private void Ball_Click(object sender, EventArgs e)
        {

        }
    }
}
