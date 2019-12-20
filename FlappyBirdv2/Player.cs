using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FlappyBirdv2
{

    class Player
    {
        public float x;
        public float y;
        public bool isAlive;
        public int score;
        public int size;
        public float GravityValue;
       

        public Image birdImg;

        public Player(int x, int y)
        {
            birdImg = new Bitmap("C:\\Users\\User\\OneDrive\\Рабочий стол\\birdd.png");
            this.x = x;
            this.y = y;
            size = 35;
            GravityValue =0.1f;
            isAlive = true;
        }
    }
}
