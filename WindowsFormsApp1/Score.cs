using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace WindowsFormsApp1
{
    class  Score
    {
        static int scores;
        static int money;

        public  Score() 
        {
            scores = 0;
            money = 0;

        }
        public Score(int heartNumber)
        {
            scores = 0;
            money = 0;
        }

        public static int Scores
        {
            get { return scores; }
            set { scores = value; }
        }

        public static int Money
        {
            get { return money; }
            set { money = value; }
        }
        public static void RewardScores(int type)
        {
            
            switch (type)
            {
                case 1:
                    scores += 10;
                    break;
                case 2:
                    scores += 20;
                    break;
                case 3:
                    scores += 30;
                    break;
            }

        }
        public static void RewardEggGold()
        {
            WindowsMediaPlayer goldM = new WindowsMediaPlayer();
            goldM.URL = "egg.wav";
            
            money += 20;
        }
        public static void RewarGold()
        {
            WindowsMediaPlayer moneyM = new WindowsMediaPlayer();
            moneyM.URL = "gold.wav";
            
            money += 2;
        }
    }
}
