using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Heart
    {
        int number;
        public Heart(int number)
        {
            this.number = number;
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
