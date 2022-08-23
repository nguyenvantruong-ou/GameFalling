using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.IO;
namespace WindowsFormsApp1
{
    public partial class frm3 : Form
    {
       
        // quả trứng
        Egg e1 = new Egg();
        Egg e2 = new Egg();
        Egg e3 = new Egg(100, 2);

        // quả trứng vàng
        Egg eGold = new Egg();
        //  đồng tiền vàng
        Egg eMoney = new Egg();

        //
        Bom bom = new Bom();
        Bom bom2 = new Bom(150, -250);

        Mario mario = new Mario();

        Heart heart = new Heart(3);

        int iAYR = 600;             // trực thăng bay
        int speed = 10;

        WindowsMediaPlayer bombMusic = new WindowsMediaPlayer();
        

        System.Media.SoundPlayer music = new System.Media.SoundPlayer(@"m.wav");


        Random t = new Random();


        public frm3()
        {
            InitializeComponent();

            this.picReady.Left = 600;
            this.picReady.Visible = true;

        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"trucThang.wav");
            player.Play();

            Score.Money = 0;
            Score.Scores = 0;


            ReadName();
            time = 0;

        }
        Boolean flagReady = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.picReady.Location = new System.Drawing.Point(iAYR -= 3, 55);
            if (iAYR < 200 && iAYR > 30)
            {
                timer1.Interval = 40;
                this.picReady.Location = new System.Drawing.Point(iAYR -= 1, 55);
                //timer1.Stop();
            }
            else if (iAYR < 30)
            {
                timer1.Interval = 1;
                this.picReady.Location = new System.Drawing.Point(iAYR -= 5, 55);

            }
            else if (iAYR < -100)
            {
                timer1.Stop();
                this.picReady.Visible = false;
            }
            if (iAYR < -300 && flagReady == false)
            {
                countDown();
            }

        }
        private void musicBackground()
        {
            
            music.PlayLooping() ;
        }
        private void countDown()
        {

            System.Media.SoundPlayer countDownMusic = new System.Media.SoundPlayer(@"321.wav");
            countDownMusic.Play();
            flagReady = true;
            timer2.Enabled = true;
            lbl123.Visible = true;
            timer2.Start();
        }
        // 1 2 3 READY
        int ready = 3;
        private void timer2_Tick(object sender, EventArgs e)
        {

            ready--;
            lbl123.Text = ready.ToString();
            if (ready == 0)
            {
                lbl123.Text = "GO";
                ready--;
            }
            else if (ready < 0)
            {
                timer2.Stop();
                timer2.Enabled = false;
                lbl123.Visible = false;
                timer3.Start();


                // hiển thị bảng điểm
                grbScore.Visible = true;

                // nhạc nền 
                musicBackground();
            }
        }


        Mario m = new Mario();

        /* private void frm3_KeyDown(object sender, KeyEventArgs e)
         {
            if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && mario.CheckLocationRight(this.picMario.Left))
             {
                 mario.X = this.picMario.Left - 10;

                 // hiển thị hình ảnh
                 picMario.Image = new Bitmap(mario.GoToLeft());
             }
             else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) &&  mario.CheckLocationRight(this.picMario.Left))
             {
                 mario.X = this.picMario.Left + 10;

                 // hiển thị hình ảnh
                 picMario.Image = new Bitmap(mario.GoToRight());

             }
             this.picMario.Location = new System.Drawing.Point(mario.X, 265);


         }*/

        //public void Form3_KeyPress(object sender, KeyPressEventArgs e)
        //{

        //    if (!flagPause)
        //    {
        //        if ((e.KeyChar == 65 || e.KeyChar == 97) && mario.CheckLocationLeft(this.picMario.Left))
        //        {
        //            mario.X = this.picMario.Left - 10;

        //            // hiển thị hình ảnh
        //            picMario.Image = new Bitmap(mario.GoToLeft());
        //        }
        //        else if ((e.KeyChar == 68 || e.KeyChar == 100) && mario.CheckLocationRight(this.picMario.Left))
        //        {
        //            mario.X = this.picMario.Left + 10;

        //            // hiển thị hình ảnh
        //            picMario.Image = new Bitmap(mario.GoToRight());

        //        } 
        //    }
        //    this.picMario.Location = new System.Drawing.Point(mario.X, 459);


        //}

        
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (!flagPause)
            {
                try
                {
                    if ((keyData == Keys.A || keyData == Keys.Left) && mario.CheckLocationLeft(this.picMario.Left))
                    {
                        mario.X = this.picMario.Left - speed;
                        // hiển thị hình ảnh
                        picMario.Image = new Bitmap(mario.GoToLeft());
                    }
                    else if ((keyData == Keys.D || keyData == Keys.Right) && mario.CheckLocationRight(this.picMario.Left))
                    {
                        mario.X = this.picMario.Left + speed;

                        // hiển thị hình ảnh
                        picMario.Image = new Bitmap(mario.GoToRight());

                    }
                }
                catch (Exception)
                {
                    
                }
            }
            this.picMario.Location = new System.Drawing.Point(mario.X, 459);

            return base.ProcessDialogKey(keyData);
        }

        private void ShowScore()
        {
            lblMoney.Text = "Money   : " + Score.Money;
            lblScore.Text = "Score   : " + Score.Scores;

        }



        Boolean flagShowEgg2 = false;

        int time ;
        private void timer3_Tick(object sender, EventArgs e)
        {
            time++;
            if (time  % 1000 ==0 )
            {
                timer5.Interval += 5;
                speed++;
                timer3.Interval = 1;
                e1.SpeedEgg = e2.SpeedEgg = e3.SpeedEgg += 1;
                bom.SpeedBom = bom2.SpeedBom += 1;
                
            }
            ShowEgg1();    // quả trứng 1 rơi


            if (e1.Y > 250) flagShowEgg2 = true;   // điều kiện để quả trứng thứ 2 rơi
            if (flagShowEgg2)
            {
                ShowEgg2();
                ShowEgg3();
            }

            if (Score.Scores > 10) timer5.Start();// bom rơi

            if ((picGold.Visible == false) && (time % 900 == 0) ) //timer4.Start();
            {
                timer4.Start();
                ShowEggGold();
                
            }    
            
            if ((picMoney.Visible == false)&& (e1.X % 10 > 4)) timer7.Start();
            ShowScore();

        }
        public void showHeart()
        {
            
                switch (heart.Number)
                {

                    case 0:
                        picHeart1.Visible = false;
                        Lose();
                        break;
                    case 1:
                        picHeart2.Visible = false;
                        break;
                    case 2:
                        picHeart3.Visible = false;
                        break;
                }
            
        }

        private void ShowEgg1()
        {
            if (this.picEgg1.Visible == false) this.picEgg1.Visible = true;
            this.picEgg1.Location = new System.Drawing.Point(e1.X, e1.Y);


            e1.FallEgg(this.picMario.Left, this.picMario.Top);


            if (e1.Y <= -10)
            {
                this.picEgg1.Image = new Bitmap(@e1.Type_Egg());
            }
        }

        private void ShowEgg2()
        {
            if (this.picEgg2.Visible == false) this.picEgg2.Visible = true;
            this.picEgg2.Location = new System.Drawing.Point(e2.X, e2.Y);


            e2.FallEgg(this.picMario.Left, this.picMario.Top);


            if (e2.Y <= -10)
            {
                this.picEgg2.Image = new Bitmap(@e2.Type_Egg());
            }
        }
        private void ShowEgg3()
        {
            if (this.picEgg3.Visible == false) this.picEgg3.Visible = true;
            this.picEgg3.Location = new System.Drawing.Point(e3.X, e3.Y);


            e3.FallEgg(this.picMario.Left, this.picMario.Top);


            if (e3.Y <= -10)
            {
                this.picEgg3.Image = new Bitmap(@e3.Type_Egg());
            }
        }

        int speedEggGold = 3;
        private void ShowEggGold()
        {

            if (this.picGold.Visible == false) this.picGold.Visible = true;
            this.picGold.Location = new System.Drawing.Point(eGold.X, eGold.Y);

            eGold.FallGoldEgg(this.picMario.Left, this.picMario.Top, speedEggGold);

        }


        private void timer4_Tick(object sender, EventArgs e)
        {
            ShowEggGold();

            if (eGold.Y >= 520 || eGold.TouchGoldEgg == true)
            {
                eGold.TouchGoldEgg = false;
                timer4.Stop();
                this.picGold.Visible = false;
            }

        }

        int timeBoom = 0;
        private void showBom1()
        {
            bom.FallBom(this.picMario.Left, this.picMario.Top);

            if (this.picBom.Visible == false) this.picBom.Visible = true;
            this.picBom.Location = new System.Drawing.Point(bom.XBomb, bom.YBomb);

            if (bom.TouchBomb)
            {
                if (timeBoom == 1)
                {
                    bombMusic.URL = "boom.wav";
                    heart.Number -= 1;
                    showHeart();
                    ExplosiveBomb(picBom, picBomm1, bom);
                }
                timeBoom++;
                

                if (timeBoom >= 30)
                {
                    picBomm1.Visible = false;
                    timeBoom = 0;
                    bom.TouchBomb = false;
                }

            }
            //if (bom.YBomb <= -10)
            //{
            //    timer5.Stop();
            //}

        }

        int timeBoom2 = 0;
        private void showBom2()
        {
            bom2.FallBom(this.picMario.Left, this.picMario.Top);

            if (this.picBom2.Visible == false) this.picBom2.Visible = true;
            this.picBom2.Location = new System.Drawing.Point(bom2.XBomb, bom2.YBomb);

            if (bom2.TouchBomb)
            {
                if (timeBoom2 == 1)
                {
                    bombMusic.URL = "boom.wav";
                    heart.Number -= 1;
                    showHeart();
                    ExplosiveBomb(picBom2, picBomm2, bom2);
                }
                timeBoom2++;



                if (timeBoom2 >= 30)
                {
                    picBomm2.Visible = false;
                    bom2.TouchBomb = false;
                    timeBoom2 = 0;

                }

            }
            //if (bom2.YBomb <= -10)
            //{
            //    timer5.Stop();
            //}

        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            showBom1();
            showBom2();
        }

        private void ExplosiveBomb(Control picBom, Control bomm, Bom x)
        {

            picBom.Visible = false;
            if (bomm.Visible == false) bomm.Visible = true;
            bomm.Location = new System.Drawing.Point(x.XExplosiveBomb, x.YExplosiveBomb);
        }
        // hiệu ứng bom nổ
        
        int speedMoney = 2;
        private void MoneyGold()
        {
            if (this.picMoney.Visible == false) this.picMoney.Visible = true;
            this.picMoney.Location = new System.Drawing.Point(eMoney.X, eMoney.Y);


            eMoney.FallGoldEgg(this.picMario.Left, this.picMario.Top, speedMoney);
        }
        private void timer7_Tick(object sender, EventArgs e)
        {
            MoneyGold();

            if (eMoney.Y >= 523 || eMoney.TouchGoldEgg == true)
            {
                timer7.Stop();
                this.picMoney.Visible = false;
            }
        }

        Boolean flagPause = false;
       
        private void lbl_MouseHover(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl = (Label)sender;

            lbl.ForeColor = Color.Yellow;
            lbl.Font = new Font("Mistral", 21);

        }
        private void lbl_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl = (Label)sender;

            lbl.ForeColor = Color.Maroon;
            lbl.Font = new Font("Mistral", 20);
        }
        Boolean t1, t2, t3, t4, t5, t7;
        private void bttBack_Click(object sender, EventArgs e)
        {
            t1 = false; t2 = false; t3 = false; t4 = false; t5 = false; t7 = false;

            CheckTimer();
            panResume.Visible = true;
            panResume.Location = new System.Drawing.Point(274, 112);
            CheckPicture(panResume);


        }
        private void CheckTimer()
        {
            if (timer1.Enabled == true)
            {
                t1 = true;
                timer1.Enabled = false;
            }
            if (timer2.Enabled == true)
            {
                t2 = true;
                timer2.Enabled = false;
            }
            if (timer3.Enabled == true)
            {
                t3 = true;
                timer3.Enabled = false;
            }
            if (timer4.Enabled == true)
            {
                t4 = true;
                timer4.Enabled = false;
            }
            if (timer5.Enabled == true)
            {
                t5 = true;
                timer5.Enabled = false;
            }
            if (timer7.Enabled == true)
            {
                t7 = true;
                timer7.Enabled = false;
            }
            flagPause = true;
        }

        

        private void CheckPicture(Control con)
        {
            int x = con.Left + con.Size.Width;
            int y = con.Top + con.Size.Height;

            if (picBom.Left > con.Left - 20 && picBom.Left < x && picBom.Top > con.Top && picBom.Top < y)
                picBom.Visible = false;
            if (picBom2.Left > con.Left - 20 && picBom2.Left < x && picBom2.Top > con.Top && picBom2.Top < y)
                picBom2.Visible = false;
            if (picEgg1.Left > con.Left - 20 && picEgg1.Left < x && picEgg1.Top > con.Top && picEgg1.Top < y)
                picEgg1.Visible = false;
            if (picEgg2.Left > con.Left - 20 && picEgg2.Left < x && picEgg2.Top > con.Top && picEgg2.Top < y)
                picEgg2.Visible = false;
            if (picEgg3.Left > con.Left - 20 && picEgg3.Left < x && picEgg3.Top > con.Top && picEgg3.Top < y)
                picEgg3.Visible = false;
            if (picGold.Left > con.Left - 20 && picGold.Left < x && picGold.Top > con.Top && picGold.Top < y)
                picGold.Visible = false;
            if (picMoney.Left > con.Left - 20 && picMoney.Left < x && picMoney.Top > con.Top && picMoney.Top < y)
                picMoney.Visible = false;
        }


        private void lblResume_Click(object sender, EventArgs e)
        {
            panResume.Visible = false;
            if (t1)
                timer1.Enabled = true;
            if (t2)
                timer2.Enabled = true;
            if (t3)
                timer3.Enabled = true;
            if (t4)
                timer4.Enabled = true;
            if (t5)
                timer5.Enabled = true;
            if (t7)
                timer7.Enabled = true;

            flagPause = false;
        }

       

        private void lblExit_Click(object sender, EventArgs e)
        {
            frm2 f = new frm2();
            this.Hide();
            f.goToForm(3);

            f.Show();

            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            timer5.Stop();
            timer7.Stop();
        }

        private void lblReset_Click(object sender, EventArgs e)
        {
            
           
            frm3 f = new frm3();
            f.Show();
            this.Hide();
        }

        private void Lose()
        {
            pnlLost.Visible = true;
            pnlLost.Location = new System.Drawing.Point(274, 50);

            lblLoseScores.Text = Score.Scores.ToString();
            lblLoseGolds.Text = Score.Money.ToString();
            CheckTimer();
            //CheckPicture(pnlLost);
            pnlLost.BringToFront();
            WriteF();
        }
        string name;
        private void ReadName()
        {
            StreamReader f = new StreamReader("player.txt", true);
            name = f.ReadToEnd();
            f.Close();
        }
        string[] listName;
        private void WriteF()
        {
            try
            {

                listName = File.ReadAllLines("fm.txt");
                System.IO.File.Delete("fm.txt");
                StreamWriter f = new StreamWriter("fm.txt", true);

                if (CheckName())
                {
                    string s = name + ";" + Score.Scores + ";" + Score.Money;
                    f.WriteLine(s);
                }
                for (int i = 0; i < listName.Length; i++)
                {
                    f.WriteLine(listName[i]);
                }
                f.Close();
            }
            catch (Exception loi)
            {
                MessageBox.Show(loi.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Boolean CheckName()
        {
            for (int i = 0; i < listName.Length; i++)
                if (listName[i].Contains(name))
                {
                    listName[i] = UpdateData(listName[i]);
                    return false;
                }

            return true;
        }


        private string UpdateData(string s)
        {
            try
            {
                string oldMoney;
                // ktra điểm có cao hơn điểm cũ k
                string oldScore = s.Substring(s.IndexOf(";") + 1, s.LastIndexOf(";") - s.IndexOf(";") - 1);
                if (Convert.ToInt32(oldScore) < Score.Scores)
                {
                    s = s.Replace(oldScore, Score.Scores.ToString());
                }

                // money
                oldMoney = s.Substring(s.LastIndexOf(";") + 1);
                int money = Convert.ToInt32(oldMoney);
                money += Score.Money;

                s = s.Replace(oldMoney, money.ToString());
            }
            catch (Exception loi)
            {
                MessageBox.Show(loi.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return s;
        }
        private void lblDS_Click(object sender, EventArgs e)
        {
            frm2 f = new frm2();
            this.Hide();
            f.Show();
        }



        private void lblR_Click(object sender, EventArgs e)
        {
            frm3 f = new frm3();
            this.Hide();
            f.Show();
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {

        }

        Boolean gl = false;
        private void frm3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!gl)
            {
                pnlThoat.Visible = true;
                pnlThoat.Location = new System.Drawing.Point(280, 50);
                pnlThoat.Width = 296;
                pnlThoat.Height = 287;
                CheckTimer();
                pnlThoat.BringToFront();
                e.Cancel = true;
            }

            //if (e.CloseReason == CloseReason.UserClosing)
            //    e.Cancel = true;
            //else if (string.Equals((sender as Label).Text, @"Có")) Application.Exit();

            //e.Cancel = true;

            

            //pnlThoat.Visible = true;
            //pnlThoat.Location = new System.Drawing.Point(280, 50);
            //pnlThoat.Width = 296;
            //pnlThoat.Height = 287;
            //CheckTimer();
            //pnlThoat.BringToFront();

        }

        private void lblTCo_Click(object sender, EventArgs e)
        {
            gl = true;
            Application.Exit();
        }

        
        private void lblKhong_Click(object sender, EventArgs e)
        {
            pnlThoat.Visible = false;
            if (t1)
                timer1.Enabled = true;
            if (t2)
                timer2.Enabled = true;
            if (t3)
                timer3.Enabled = true;
            if (t4)
                timer4.Enabled = true;
            if (t5)
                timer5.Enabled = true;
            if (t7)
                timer7.Enabled = true;

            flagPause = false;
        }
        private void lblTCo_MouseHover(object sender, EventArgs e)
        {
            Label lbl ;
            lbl = (Label)sender;
            lbl.ForeColor = Color.Lime;
        }

        private void lblTCo_MouseLeave(object sender, EventArgs e)
        {
            Label lbl;
            lbl = (Label)sender;
            lbl.ForeColor = Color.Orange;
        }
    }
}