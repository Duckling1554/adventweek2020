using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBESTCarRacing
{
    public partial class Form1 : Form
    {
        int gameSpeed = 0;
        int x;
        int y=0;
        int collectedCoins=0;
        PictureBox[] enemyCars;
        PictureBox[] coins;
        PictureBox[] roadLines;
        Random random = new Random();
        public Form1()
        {
            
            InitializeComponent();
            GameOver.Visible = false;
            Restart.Visible = false;
            Restart.Enabled = false;
        }
        private void Initialization()
        {
            enemyCars = new PictureBox[3] { enemy1, enemy2, enemy3 };
            coins = new PictureBox[4] { coin1, coin2, coin3, coin4 };
            roadLines = new PictureBox[4] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            
        }
        
        private void GetCoin()
        {
            for (int i = 0; i < coins.Length; i++)
            {
                if (car.Bounds.IntersectsWith(coins[i].Bounds))
                {
                    collectedCoins++;
                    Score.Text = "Score: " + collectedCoins.ToString();
                    x = random.Next(100, 250);
                    coins[i].Location = new Point(x, y);
                    CheckOverlay(coins[i], coins);
                }
            }
            
        }
        private void CheckOverlay(PictureBox item, PictureBox[] items)
        {
            for(int i=0; i<items.Length; i++)
            {
                if((item.Bounds.IntersectsWith(items[i].Bounds) ) ||
                    item.Bounds.IntersectsWith(pictureBox5.Bounds) || item.Bounds.IntersectsWith(pictureBox6.Bounds))
                {
                    x = random.Next(i * 150 / 2, 250 + (i * 48) / 2);
                   items[i].Location = new Point(x, y);
                }
            }
        }
        private void ElementControl(int speed, PictureBox[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Top >= 919)
                {
                    items[i].Top = 0;
                    x = random.Next(i*150/2, 200+(i*48)/2);
                    items[i].Location = new Point(x, y);
                    CheckOverlay(items[i], items);
                }
                else
                {
                    items[i].Top += speed;
                }
            }
            
        }
        private void MovingLines(int speed, PictureBox[] lines)
        {
            for(int i=0; i<lines?.Length; i++)
            {
                if(lines[i].Top >=500)
                {
                    lines[i].Top = 0;
                }
                else
                {
                    lines[i].Top += speed;
                }
            }
        }
        private void GameEnd()
        {
            if(car.Bounds.IntersectsWith(enemy1.Bounds) || car.Bounds.IntersectsWith(enemy2.Bounds) ||
                car.Bounds.IntersectsWith(enemy3.Bounds))
            {
                timer1.Enabled = false;
                GameOver.Visible = true;
                Restart.Visible = true;
                Restart.Enabled = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Initialization();
            MovingLines(gameSpeed, roadLines);
            ElementControl(gameSpeed, enemyCars);
            GameEnd();
            ElementControl(gameSpeed, coins);
            GetCoin();
        }

        private void KeyControl(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                if(!car.Bounds.IntersectsWith(pictureBox5.Bounds))
                car.Left -= gameSpeed;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (!car.Bounds.IntersectsWith(pictureBox6.Bounds))
                    car.Left += gameSpeed;
            }
            if (e.KeyCode == Keys.Up)
            {
                if(gameSpeed <21)
                {
                    gameSpeed++;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if(gameSpeed>0)
                {
                    gameSpeed--;
                }
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
