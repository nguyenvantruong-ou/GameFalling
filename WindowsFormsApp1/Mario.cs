using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Mario
    {
        int x; 
        int flagShowFigureLeft;
        int valueBeforeLeft;

        int flagShowFigureRight;

        string imageLeft;
        string imageRight;

        public Mario()
        {
            x = 0;
            flagShowFigureLeft = 3;
            valueBeforeLeft = 1;
            flagShowFigureRight = 3;
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int FlagShowFigureLeft
        {
            get { return flagShowFigureLeft; }
        }
        public int FlagShowFigureRight
        {
            get { return flagShowFigureRight; }
        }
        public string GoToLeft()
        {

            switch (flagShowFigureLeft)
            {
                case 1:
                    imageLeft = "nguoc1.png";
                    valueBeforeLeft = flagShowFigureLeft;
                    flagShowFigureLeft++;
                    break;
                case 2:
                    imageLeft = "nguoc11.png";
                    if (valueBeforeLeft == 1)
                        flagShowFigureLeft++;
                    else flagShowFigureLeft--;
                    break;
                case 3:
                    imageLeft = "nguoc2.png";
                    valueBeforeLeft = flagShowFigureLeft;
                    flagShowFigureLeft--;
                    break;
            }
            return imageLeft;
        }
        public string GoToRight()
        {
            switch (flagShowFigureRight)
            {
                 case 1:
                     imageRight = "mario4.png";
                     
                     flagShowFigureRight = 2;
                     break;
                 case 2:
                     imageRight = "mario1.png";

                    flagShowFigureRight = 3;
                    break;
                 case 3:
                     imageRight = "mario3.png";

                    flagShowFigureRight = 1;
                    break;
            }
            return imageRight;
        }
        public Boolean CheckLocationLeft(int x)
        {

            if (x < -8) return false;
            return true;
        }
        public Boolean CheckLocationRight(int x)
        {
            if (x > 750) return false;
            return true;
        }
    }
}