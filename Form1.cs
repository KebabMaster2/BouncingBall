﻿using System;
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
        
    }
}
