using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Bom 
    {
        int xBomb;
        int yBomb;
        int speedBom = 2;
        Boolean touchBomb;
        int xExplosiveBomb;
        int yExplosiveBomb;
        Random t = new Random();
        // random bom 
        public Bom()
        {
            this.xBomb = 200;
            this.yBomb = -10;
            touchBomb = false;
            
        }

        public Bom(int x, int y)
        {
            this.xBomb = x;
            this.yBomb = y;
        }
        public int XBomb
        {
            get { return xBomb; }
        }
        public int YBomb
        {
            get { return yBomb; }
        }
        public int XExplosiveBomb
        {
            get { return this.xExplosiveBomb; }
            //set { XExplosiveBomb = value; }
        }
        public int YExplosiveBomb
        {
            get { return this.yExplosiveBomb; }
            //set { YExplosiveBomb = value; }
        }
        public Boolean TouchBomb
        {
            get { return touchBomb; }
            set { touchBomb = value; }
        }
        public int SpeedBom
        {
            get { return speedBom; }
            set { speedBom = value; }
        }
        public void FallBom( int x, int y)
        {
            this.yBomb += speedBom;
            if (CheckBom(x, y))
            {
                this.xExplosiveBomb = xBomb;
                this.yExplosiveBomb = yBomb -15;
                this.yBomb = -20;
                touchBomb = true;
                ResetBom();
            }
            else if (this.yBomb >= 523)
            {
                this.yBomb = -20;
                ResetBom();
            }
        }

        private Boolean CheckBom(int x, int y)
        {
            if (this.yBomb > 432 && this.yBomb < 525 && (this.xBomb > x - 8 && this.xBomb < x + 48))
                return true;
            return false;
        }
        public void ResetBom()
        {
            // đổi vị trí rơi
            Random t = new Random();
            this.xBomb = t.Next(0, 665);

        }
    }
}
