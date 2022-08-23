using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Loading : Form
    {
        Random r = new Random();
        int x;
        int flag = 1;
        public Loading()
        {
            InitializeComponent();
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pnlLoading.Width < pnlBR.Width)
            {

                x = r.Next(1, 50);
                if (pnlLoading.Width + x < pnlBR.Width)
                    pnlLoading.Width += x;
                else pnlLoading.Width = pnlBR.Width;
                lblNumber.Text = string.Format("{0} %", (int)((pnlLoading.Width * 1.0 / pnlBR.Width) * 100));
            }
            else
            {
                timer1.Stop();
                this.Hide();
                LogIn f = new LogIn();
                f.Show();
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // Loading...
            switch (flag)
            {
                case 1:
                    lblLoading.Text = "Loading.";
                    flag++;
                    break;
                case 2:
                    lblLoading.Text = "Loading..";
                    flag++;
                    break;
                case 3:
                    lblLoading.Text = "Loading...";
                    flag = 1;
                    break;
            }

            lblLoading.ForeColor = (lblLoading.ForeColor == Color.White) ? Color.LightCoral : Color.White;
        }
    
    }
}
