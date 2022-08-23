using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Gold
    {
        Random t = new Random();
        // reset vàng
        static int typeGold;
        public void fallGold(ref int xGold, ref int yGold, int x, int y, ref int money, ref Boolean isGold)
        {
            isGold = checkGold(xGold, yGold, x, y);
            yGold += 2;
            if (isGold)
            {
                yGold = -10;
                rewardMoneys(ref money);
                resetGold(ref xGold);
            }
            else if (yGold >= 328)
            {
                yGold = -10;
                resetGold(ref xGold);

            }
        
        }
        // kiểm tra có lấy vàng thành công hay không
        public Boolean checkGold(int xEgg, int yEgg, int x, int y)
        {
            if (yEgg > 241 && yEgg < 247 && (xEgg > x && xEgg < x + 48))
                return true;
            return false;
        }

        public void rewardMoneys(ref int money)
        {
            switch (typeGold)
            {
                case 1:
                    money += 10;
                    break;
                case 2:
                    money += 23;
                    break;
                case 3:
                    money += 24;
                    break;
            }

        }
        public void resetGold(ref int xEgg)
        {
            // đổi vị trí rơi
            xEgg = t.Next(0, 650);


        }
        public string type_Gold()
        {

            //random màu quả trứng rơi
            typeGold = t.Next(1, 4);
            string type = "";
            switch (typeGold)
            {
                case 1:
                    type = "C:\\C#\\project\\GAME MARIO\\WindowsFormsApp1\\Resources\\money.gif";
                    break;
                case 2:
                    type = "C:\\C#\\project\\GAME MARIO\\WindowsFormsApp1\\Resources\\money.gif";
                    break;
                case 3:
                    type = "C:\\C#\\project\\GAME MARIO\\WindowsFormsApp1\\Resources\\money.gif";
                    break;

            }
            return type;
        }
    }
}

