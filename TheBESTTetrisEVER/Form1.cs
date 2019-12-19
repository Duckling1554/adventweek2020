using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheBESTTetrisEVER
{
    public partial class Form1 : Form
    {
       
            Figure currentFigure;
            int size;
            int[,] map = new int[16, 8];
            int removedLines;
            int score;
            int interval;
            public Form1()
            {
                InitializeComponent();
                this.KeyUp += new KeyEventHandler(KeyControl);
                Init();
            }

            public void Init()
            {
                size = 25;
                score = 0;
                removedLines = 0;
                currentFigure = new Figure(3, 0);
                interval = 300;
                scoreLabel.Text = "Score: " + score;
                linesLabel.Text = "Lines: " + removedLines;



                timer.Interval = interval;
                timer.Tick += new EventHandler(Update);
                timer.Start();


                Invalidate();
            }

            private void KeyControl(object sender, KeyEventArgs e)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        if (!IsIntersects())
                        {
                            ResetArea();
                            currentFigure.RotateShape();
                            Merge();
                            Invalidate();
                        }
                        break;
                    case Keys.Space:
                        timer.Interval = 10;
                        break;
                    case Keys.Right:
                        if (!CollideHor(1))
                        {
                            ResetArea();
                            currentFigure.MoveRight();
                            Merge();
                            Invalidate();
                        }
                        break;
                    case Keys.Left:
                        if (!CollideHor(-1))
                        {
                            ResetArea();
                            currentFigure.MoveLeft();
                            Merge();
                            Invalidate();
                        }
                        break;
                }
            }

            public void ShowNextShape(Graphics element)
            {
                for (int i = 0; i < currentFigure.sizeNextMatrix; i++)
                {
                    for (int j = 0; j < currentFigure.sizeNextMatrix; j++)
                    {
                        if (currentFigure.nextMatrix[i, j] == 1)
                        {
                            element.FillRectangle(Brushes.Red, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (currentFigure.nextMatrix[i, j] == 2)
                        {
                            element.FillRectangle(Brushes.Yellow, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (currentFigure.nextMatrix[i, j] == 3)
                        {
                            element.FillRectangle(Brushes.Green, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (currentFigure.nextMatrix[i, j] == 4)
                        {
                            element.FillRectangle(Brushes.Blue, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (currentFigure.nextMatrix[i, j] == 5)
                        {
                            element.FillRectangle(Brushes.Purple, new Rectangle(300 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                    }
                }
            }

            private void Update(object sender, EventArgs e)
            {
                ResetArea();
                if (!Collide())
                {
                    currentFigure.MoveDown();
                }
                else
                {
                    Merge();
                    SliceMap();
                    timer.Interval = interval;
                    currentFigure.ResetShape(3, 0);
                    if (Collide())
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                map[i, j] = 0;
                            }
                        }
                        timer.Tick -= new EventHandler(Update);
                        timer.Stop();
                        Init();
                    }
                }
                Merge();
                Invalidate();
            }

            public void SliceMap()
            {
                int count = 0;
                int curRemovedLines = 0;
                for (int i = 0; i < 16; i++)
                {
                    count = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (map[i, j] != 0)
                            count++;
                    }
                    if (count == 8)
                    {
                        curRemovedLines++;
                        for (int k = i; k >= 1; k--)
                        {
                            for (int o = 0; o < 8; o++)
                            {
                                map[k, o] = map[k - 1, o];
                            }
                        }
                    }
                }
                for (int i = 0; i < curRemovedLines; i++)
                {
                    score += 10 * (i + 1);
                }
                removedLines += curRemovedLines;

                if (removedLines % 5 == 0)
                {
                    if (interval > 60)
                        interval -= 10;
                }

                scoreLabel.Text = "Score: " + score;
                linesLabel.Text = "Lines: " + removedLines;
            }

            public bool IsIntersects()
            {
                for (int i = currentFigure.corY; i < currentFigure.corY + currentFigure.sizeMatrix; i++)
                {
                    for (int j = currentFigure.corX; j < currentFigure.corX + currentFigure.sizeMatrix; j++)
                    {
                        if (j >= 0 && j <= 7)
                        {
                            if (map[i, j] != 0 && currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX] == 0)
                                return true;
                        }
                    }
                }
                return false;
            }

            public void Merge()
            {
                for (int i = currentFigure.corY; i < currentFigure.corY + currentFigure.sizeMatrix; i++)
                {
                    for (int j = currentFigure.corX; j < currentFigure.corX + currentFigure.sizeMatrix; j++)
                    {
                        if (currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX] != 0)
                            map[i, j] = currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX];
                    }
                }
            }

            public bool Collide()
            {
                for (int i = currentFigure.corY + currentFigure.sizeMatrix - 1; i >= currentFigure.corY; i--)
                {
                    for (int j = currentFigure.corX; j < currentFigure.corX + currentFigure.sizeMatrix; j++)
                    {
                        if (currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX] != 0)
                        {
                            if (i + 1 == 16)
                                return true;
                            if (map[i + 1, j] != 0)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public bool CollideHor(int dir)
            {
                for (int i = currentFigure.corY; i < currentFigure.corY + currentFigure.sizeMatrix; i++)
                {
                    for (int j = currentFigure.corX; j < currentFigure.corX + currentFigure.sizeMatrix; j++)
                    {
                        if (currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX] != 0)
                        {
                            if (j + 1 * dir > 7 || j + 1 * dir < 0)
                                return true;

                            if (map[i, j + 1 * dir] != 0)
                            {
                                if (j - currentFigure.corX + 1 * dir >= currentFigure.sizeMatrix || j - currentFigure.corX + 1 * dir < 0)
                                {
                                    return true;
                                }
                                if (currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX + 1 * dir] == 0)
                                    return true;
                            }
                        }
                    }
                }
                return false;
            }

            public void ResetArea()
            {
                for (int i = currentFigure.corY; i < currentFigure.corY + currentFigure.sizeMatrix; i++)
                {
                    for (int j = currentFigure.corX; j < currentFigure.corX + currentFigure.sizeMatrix; j++)
                    {
                        if (i >= 0 && j >= 0 && i < 16 && j < 8)
                        {
                            if (currentFigure.matrix[i - currentFigure.corY, j - currentFigure.corX] != 0)
                            {
                                map[i, j] = 0;
                            }
                        }
                    }
                }
            }

            public void DrawMap(Graphics e)
            {
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (map[i, j] == 1)
                        {
                            e.FillRectangle(Brushes.Red, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (map[i, j] == 2)
                        {
                            e.FillRectangle(Brushes.Yellow, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (map[i, j] == 3)
                        {
                            e.FillRectangle(Brushes.Green, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (map[i, j] == 4)
                        {
                            e.FillRectangle(Brushes.Blue, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                        if (map[i, j] == 5)
                        {
                            e.FillRectangle(Brushes.Purple, new Rectangle(50 + j * (size) + 1, 50 + i * (size) + 1, size - 1, size - 1));
                        }
                    }
                }
            }

            public void DrawGrid(Graphics g)
            {
                for (int i = 0; i <= 16; i++)
                {
                    g.DrawLine(Pens.Black, new Point(50, 50 + i * size), new Point(50 + 8 * size, 50 + i * size));
                }
                for (int i = 0; i <= 8; i++)
                {
                    g.DrawLine(Pens.Black, new Point(50 + i * size, 50), new Point(50 + i * size, 50 + 16 * size));
                }
            }

            private void OnPaint(object sender, PaintEventArgs e)
            {
                DrawGrid(e.Graphics);
                DrawMap(e.Graphics);
                ShowNextShape(e.Graphics);
            }
        }
    }

