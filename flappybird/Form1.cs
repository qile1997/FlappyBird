using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flappybird
{
    public partial class flappy : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public flappy()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gameEventTimer(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score : " + score.ToString();

            if(pipeBottom.Left < -130)
            {
                pipeBottom.Left = 550;
                score++;
            }

            if(pipeTop.Left < -160)
            {
                pipeTop.Left = 580;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds)
               || flappyBird.Bounds.IntersectsWith(pipeTop.Bounds)
               || flappyBird.Bounds.IntersectsWith(ground.Bounds)
               || flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text = "Game Over !! ";
        }

        private void flappyBird_Click(object sender, EventArgs e)
        {

        }
    }
}
