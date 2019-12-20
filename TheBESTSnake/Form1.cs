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
        private int width=900;
        private int height=800;
        private int sizeOfSides = 40;
        private int corX, corY;
        private int radI, radJ;
        private PictureBox[] mouse = new PictureBox[400];
        private Label labelScore;
        private PictureBox cheese;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();

            Initialization();

        }
        private void Initialization()
        {
            this.Width = width;
            this.Height = height;
            labelScore = new Label();
            labelScore.Text = "Score: 0";
            labelScore.ForeColor = Color.White;
            labelScore.Location = new Point(810, 10);
            this.Controls.Add(labelScore);
            corX = 1;
            corY = 0;
            cheese = new PictureBox();
            cheese.Image = Properties.Resources.cheese;
            cheese.Size = new Size(sizeOfSides, sizeOfSides);
            GenerateMap();
            GenerateCheese();
            timer.Tick += new EventHandler(Update);
            timer.Interval = 500;
            timer.Start();
            mouse[0] = new PictureBox();
            mouse[0].Location = new Point(201, 201);
            mouse[0].Image = Properties.Resources.mouse;
            mouse[0].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
            this.Controls.Add(mouse[0]);
            this.KeyDown += new KeyEventHandler(KeyControl);
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
            mouse[0].Location = new Point(mouse[0].Location.X + corX * (sizeOfSides), mouse[0].Location.Y + corY * (sizeOfSides));
            EatItself();
        }
        private void Update(Object myObject, EventArgs eventsArgs)
        {
            CheckBorders();
            ToEatCheese();
            MoveMouse();
        }

        private void CheckBorders() 
            //logic of checking borders is taken from online course of c# games on website http//:videosharp.info
        {
            if (mouse[0].Location.X < 0)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(mouse[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                corX = 1;
            }
            if (mouse[0].Location.X > height)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(mouse[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                corX = -1;
            }
            if (mouse[0].Location.Y < 0)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(mouse[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                corY = 1;
            }
            if (mouse[0].Location.Y > height)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(mouse[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                corY = -1;
            }
        }

        private void GenerateCheese()
        {
            Random r = new Random();
            radI = r.Next(0, height - sizeOfSides);
            int tempI = radI % sizeOfSides;
            radI -= tempI;
            radJ = r.Next(0, height - sizeOfSides);
            int tempJ = radJ % sizeOfSides;
            radJ -= tempJ;
            radI++;
            radJ++;
            cheese.Location = new Point(radI, radJ);
            this.Controls.Add(cheese);
        }
        private void ToEatCheese()
        {
            if (mouse[0].Location.X == radI && mouse[0].Location.Y == radJ)
            {
                labelScore.Text = "Score: " + ++score;
                mouse[score] = new PictureBox();
                mouse[score].Location = new Point(mouse[score - 1].Location.X + 40 * corX,
                    mouse[score - 1].Location.Y - 40 * corY);
                mouse[score].Size = new Size(sizeOfSides - 1, sizeOfSides - 1);
                mouse[score].Image = Properties.Resources.mouse;
                this.Controls.Add(mouse[score]);
                GenerateCheese();
            }
        }
        private void EatItself()
        {
            for (int i = 1; i < score; i++)
            {
                if (mouse[0].Location == mouse[i].Location)
                {
                    for (int _j = i; _j <= score; _j++)
                        this.Controls.Remove(mouse[_j]);
                    score = score - (score - i + 1);
                    labelScore.Text = "Score: " + score;
                }
            }
        }

        private void KeyControl (object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                
                case "Right":
                    corX = 1;
                    corY = 0;
                    break;
                case "Left":
                    corX = -1;
                    corY = 0;
                    break;
                case "Up":
                    corY = -1;
                    corX = 0;
                    break;
                case "Down":
                    corY = 1;
                    corX = 0;
                    break;
            }

        }

        
    }
}
