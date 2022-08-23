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
    public partial class frm2 : Form
    {

        public static int flagMusic = 1;
        public frm2()
        {
            InitializeComponent();
            
        }

        private void frm2_Load(object sender, EventArgs e)
        {
           
        }
        public void goToForm(int x)
        {
            if (x != 1)
                mucsicBg();
        }
        private void mucsicBg()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"musicPo.wav");
            player.PlayLooping();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            frm1 f = new frm1();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm3 f = new frm3();
            this.Hide();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
