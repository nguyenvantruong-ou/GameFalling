using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Egg
    {
        int x;
        int y;
        int type;
        int speedEgg = 2;

        public Egg()
        {
            x = 300;
            y = -10;
            type = 2;
        }
        public Egg(int type)
        {
            x = 300;
            y = -10;
            this.type = type;
        }
        public Egg(int x, int type)
        {
            this.x = x;
            this.type = type;
        }
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int T
        {
            get { return type; }
        }
        public int SpeedEgg 
        {
            get { return speedEgg; }
            set { speedEgg = value; }
        }
        public void FallEgg( int x, int y)
        {

            this.y += speedEgg;
            if (CheckEgg( x, y))
            {
                this.y = -10;
                ResetEgg();
                // cong diem
                Score.RewardScores(type);

            }
            else if (this.y >= 523)
            {
                this.y = -10;
                ResetEgg();
            }
        }

        Boolean touchGoldEgg = false;
        public Boolean TouchGoldEgg
        {
            get { return touchGoldEgg; }
            set { touchGoldEgg = value; }
        }
        public void FallGoldEgg( int x, int y, int speed)
        {
            this.y += speed;
            touchGoldEgg = CheckEgg(x, y);
            if (touchGoldEgg)
            {
                if (speed == 3)
                    Score.RewardEggGold();
                else Score.RewarGold();
                this.y = -10;

                //touchGoldEgg = false;
                ResetEgg();
            }
            else if (this.y >= 523)
            {
                this.y = -10;
                ResetEgg();

            }

        }
        // kiểm tra có hứng bóng thành công hay không
        public Boolean CheckEgg( int x, int y)
        {
            if (this.y > 429 && this.y < 432 && (this.x > x -8 && this.x < x +48) )
                return true;
            return false;
        }

        

      
        public void ResetEgg()
        {

            Random t = new Random();
            // đổi vị trí rơi
            this.x = t.Next(0, 650);
            

        }
        public string Type_Egg()
        {

            Random t = new Random();
            //random màu quả trứng rơi
            this.type = t.Next(1, 4);
            string typeIm = "";
            switch (this.type)
            {
                case 1:
                    typeIm = "egg.png";
                    break;
                case 2:
                    typeIm = "egg1.png";
                    break;
                case 3:
                    typeIm = "egg2.png";
                    break;
               
            }
            return typeIm;
        }
      
    }
}
