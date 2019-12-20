using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdv2
{
    public partial class Form1 : Form
    {
        Player bird;
        TheWall wall1;
        TheWall wall2;
        float gravity;
        public Form1()
        {
            InitializeComponent();
            Init();
            timer1.Interval = 10;
            timer1.Tick += new EventHandler(update);
            this.Text = "Flappy Bird Score: 0";
            Invalidate();
        }

        public void Init()
        {
            bird = new Player(200,200);
            wall1 = new TheWall(550, -200, true);
            wall2 = new TheWall(550, 300);
            timer1.Start();
        }

        private void update(object sender, EventArgs e)
        {
            if (bird.y >600)
            {
                bird.isAlive = false;
                this.Text = "Flappy Bird Score: 0";
                timer1.Stop();
                Init();
                gravity = 0;
            }
            if (Collide(bird, wall1) || Collide(bird, wall2))
            {
                bird.isAlive = false;
                this.Text = "Flappy Bird Score: 0";   
                timer1.Stop();
                Init();
            }

            if (bird.GravityValue != 0.1f)
                    bird.GravityValue += 0.005f;
                gravity += bird.GravityValue;
                bird.y += gravity; 
            if (bird.isAlive)
            {
                MoveWalls();
            }
            Invalidate();
        }

        private void CreateNewWall()
        {
            if (wall1.x < bird.x - 400 )
            {
                Random r = new Random();
                int y1;
                int u;
                y1 = r.Next(-200, -100);
                u = r.Next(450, 600);
                wall1 = new TheWall(450, y1, true);
                wall2 = new TheWall(450, y1 + u);
                bird.score++;
                this.Text = "Flappy Bird Score: "+ bird.score;
            }
        }

        private bool Collide(Player player, TheWall wall)

        {
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (wall.x + wall.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (wall.y + wall.sizeY / 2);
            if (Math.Abs(delta.X) <= bird.size / 2 + wall.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + wall.sizeY / 2)
                {

                    return true;
                }
            }
            return false;

        }



        private void MoveWalls()
        {
            wall1.x -= 3;
            wall2.x -= 3;
            CreateNewWall();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            graphics.DrawImage(bird.birdImg, bird.x, bird.y,bird.size, bird.size);

     
            graphics.DrawImage(wall1.wallImg, wall1.x, wall1.y , wall1.sizeX, wall1.sizeY);
            

            graphics.DrawImage(wall2.wallImg, wall2.x, wall2.y , wall2.sizeX, wall2.sizeY);
        }



        private void Button1_Click(object sender, EventArgs e)
        {
        if (bird.isAlive)
            {  
                gravity = 0;
                bird.GravityValue = -0.125f;
            }
        else
                timer1.Stop();
        }
    }
}
