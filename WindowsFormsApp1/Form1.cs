using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class frm1 : Form
    {

        public frm1()
        {
            InitializeComponent();

            lblPlay.Parent = picPlay;
            lblPlay.Location = new Point(1, 1);

            lblHelp.Parent = picHelp;
            lblHelp.Location = new Point(1, 1);

            lblTop.Parent = picTop;
            lblTop.Location = new Point(1,1);
        }

        
        private void frm1_Load(object sender, EventArgs e)
        {
            musicBg();
            ReadName();
        }
   
        private void musicBg()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"main.wav");
            player.Play();
        }
        string name;
        private void ReadName()
        {
            StreamReader f = new StreamReader("player.txt",false);
            name = f.ReadToEnd();
            f.Close();
            lblNamePlayer.Text = name;
        }
       
        

        private void lbl_MouseHover(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl = (Label)sender;

            lbl.ForeColor = Color.Yellow;
            lbl.Font = new Font("Muyao-Softbrush",28);

        }


        private void lblPlay_Click(object sender, EventArgs e)
        {
            frm2 f = new frm2();
            f.goToForm(1);
            this.Hide();
            f.Show();
        }

        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl = (Label)sender;

            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Muyao-Softbrush", 26);
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {

        }

        private void lblTop_Click(object sender, EventArgs e)
        {

        }

        private void lblLogOut_Click(object sender, EventArgs e)
        {
            LogIn f = new LogIn();
            this.Hide();
            f.Show();

        }
    }
}
