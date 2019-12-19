using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBESTSnake
{
    public partial class Form1 : Form
    {
        private int width = 900;
        private int height = 800;
        private int sizeOfSides = 40;
        private int dirX, dirY;
        private int rI, rJ;
        private PictureBox[] mouse = new PictureBox[400];
        private Label labelScore;
        private PictureBox cheese;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(810, 10);
            this.Controls.Add(labelScore);
            dirX = 1;
            dirY = 0;
            cheese = new PictureBox();
            cheese.BackColor = Color.Yellow;
            cheese.Size = new Size(sizeOfSides, sizeOfSides);
            GenerateMap();
            GenerateFruit();
            timer.Tick += new EventHandler(Update);
            timer.Interval = 500;
            timer.Start();
            mouse[0] = new PictureBox();
            mouse[0].Location = new Point(201, 201);
            mouse[0].Image = Properties.Resources.mouse;
            //animal[0].BackColor = Color.Red;
            mouse[0].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
            this.Controls.Add(mouse[0]);
            this.KeyDown += new KeyEventHandler(KeyControl);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        
        private void GenerateMap()
        {
            for (int i = 0; i < width / sizeOfSides; i++)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.White;
                line.Location = new Point(0, sizeOfSides * i);
                line.Size = new Size(width - 100, 1);
                this.Controls.Add(line);
            }
            for (int i = 0; i <= height / sizeOfSides; i++)
            {
                PictureBox line = new PictureBox();
                line.BackColor = Color.White;
                line.Location = new Point(sizeOfSides * i, 0);
                line.Size = new Size(1, width-100);
                this.Controls.Add(line);
            }
        }
        private void MoveMouse()
        {
            for (int i = score; i >= 1; i--)
            {
                mouse[i].Location = mouse[i - 1].Location;
            }
            mouse[0].Location = new Point(mouse[0].Location.X + dirX * (sizeOfSides), mouse[0].Location.Y + dirY * (sizeOfSides));
            EatItself();
        }
        private void Update(Object myObject, EventArgs eventsArgs)
        {
            CheckBorders();
            ToEatFruit();
            MoveMouse();
        }

        private void CheckBorders()
        {
            if (mouse[0].Location.X < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(mouse[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = 1;
            }
            if (mouse[0].Location.X > height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(mouse[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = -1;
            }
            if (mouse[0].Location.Y < 0)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(mouse[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = 1;
            }
            if (mouse[0].Location.Y > height)
            {
                for (int _i = 1; _i <= score; _i++)
                {
                    this.Controls.Remove(mouse[_i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = -1;
            }
        }

        private void GenerateFruit()
        {
            Random r = new Random();
            rI = r.Next(0, height - sizeOfSides);
            int tempI = rI % sizeOfSides;
            rI -= tempI;
            rJ = r.Next(0, height - sizeOfSides);
            int tempJ = rJ % sizeOfSides;
            rJ -= tempJ;
            rI++;
            rJ++;
            cheese.Location = new Point(rI, rJ);
            this.Controls.Add(cheese);
        }
        private void ToEatFruit()
        {
            if (mouse[0].Location.X == rI && mouse[0].Location.Y == rJ)
            {
                labelScore.Text = "Score: " + ++score;
                mouse[score] = new PictureBox();
                mouse[score].Location = new Point(mouse[score - 1].Location.X + 40 * dirX,
                    mouse[score - 1].Location.Y - 40 * dirY);
                mouse[score].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
                mouse[score].Image = Properties.Resources.mouse;
                this.Controls.Add(mouse[score]);
                GenerateFruit();
            }
        }
        private void EatItself()
        {
            for (int _i = 1; _i < score; _i++)
            {
                if (mouse[0].Location == mouse[_i].Location)
                {
                    for (int _j = _i; _j <= score; _j++)
                        this.Controls.Remove(mouse[_j]);
                    score = score - (score - _i + 1);
                    labelScore.Text = "Score: " + score;
                }
            }
        }

        private void KeyControl (object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
            }

        }

        
    }
}
