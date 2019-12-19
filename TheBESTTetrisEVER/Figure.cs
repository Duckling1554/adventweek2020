using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBESTTetrisEVER
{
    class Figure
    {
        public int corX;
        public int corY;
        public int[,] matrix;
        public int[,] nextMatrix;
        public int sizeMatrix;
        public int sizeNextMatrix;
        public int[,] lineBrick = new int[4, 4]{
            {0,0,1,0  },
            {0,0,1,0  },
            {0,0,1,0  },
            {0,0,1,0  },
        };

        public int[,] fourBrick = new int[3, 3]{
            {0,2,0  },
            {0,2,2 },
            {0,0,2 },
        };

        public int[,] tBrick = new int[3, 3]{
            {0,0,0  },
            {3,3,3 },
            {0,3,0 },
        };

        public int[,] lBrick = new int[3, 3]{
            { 4,0,0  },
            {4,0,0 },
            {4,4,0 },
        };
        public int[,] rectBrick = new int[2, 2]{
            { 5,5  },
            {5,5 },
        };
        public Figure(int x, int y)
        {
            corX = x;
            corY = y;
            matrix = GenerateMatrix();
            sizeMatrix = (int)Math.Sqrt(matrix.Length);
            nextMatrix = GenerateMatrix();
            sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);

        }
        public void MoveDown()
        {
            corY++;
        }
        public void MoveLeft()
        {
            if (corX > 0)
            {
                corX--;
            }
        }
        public void MoveRight()
        {
            if (corX < 8 - sizeMatrix)
            {
                corX++;
            }
        }
        public void ResetShape(int x, int y)
        {
            corX = x;
            corY = y;
            matrix = nextMatrix;
            sizeMatrix = (int)Math.Sqrt(matrix.Length);
            nextMatrix = GenerateMatrix();
            sizeNextMatrix = (int)Math.Sqrt(nextMatrix.Length);
        }
        public int[,] GenerateMatrix()
        {
            int[,] matrix = lineBrick;
            Random r = new Random();
            switch (r.Next(1, 6))
            {
                case 1:
                    matrix = lineBrick;
                    break;
                case 2:
                    matrix = fourBrick;
                    break;
                case 3:
                    matrix = tBrick;
                    break;
                case 4:
                    matrix = lBrick;
                    break;
                case 5:
                    matrix = rectBrick;
                    break;
            }
            return matrix;
        }

        public void RotateShape()
        {
            int[,] tempMatrix = new int[sizeMatrix, sizeMatrix];
            for (int i = 0; i < sizeMatrix; i++)
            {
                for (int j = 0; j < sizeMatrix; j++)
                {
                    tempMatrix[i, j] = matrix[j, (sizeMatrix - 1) - i];
                }
            }
            matrix = tempMatrix;
            int offset1 = (8 - (corX + sizeMatrix));
            if (offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                    MoveLeft();
            }

            if (corX < 0)
            {
                for (int i = 0; i < Math.Abs(corX) + 1; i++)
                    MoveRight();
            }

        }
    }
}
