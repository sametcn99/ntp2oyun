﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmOyun : Form
    {
        static int sonuc, sure=30;
        Random rnd = new Random();

        public frmOyun()
        {
            InitializeComponent();

            label1.Text = "Puan";
            label2.Text = "Süre";
            tmr_sure.Start();

        }
        public string adSoyad;
        private void tmr_game_Tick(object sender, EventArgs e)
        {

            Button btn = new Button();
            btn.Size = new Size(70, 35);
            btn.Text = rnd.Next(100).ToString();
            btn.Location = new Point(rnd.Next(this.ClientSize.Width - pnlPuan.Width - btn.Width), rnd.Next(this.ClientSize.Height - btn.Height));
            this.Controls.Add(btn);
            btn.Click += btnClick;


        }

        private void frmOyun_Load(object sender, EventArgs e)
        {
            lblAdSyd.Text = adSoyad;
            tmr_game.Start();
            tmr_sure.Start();

        }

        private void tmr_sure_Tick(object sender, EventArgs e)
        {
            sure--;
            label2.Text = sure.ToString();
            if (sure == 0)
            {
                tmr_sure.Stop();
                MessageBox.Show("Oyun Bitti! Skorunuz: " + sonuc);
                string dosya_yolu = @"C:\dosya_kayit.txt";
                FileStream fs = new FileStream(dosya_yolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(sonuc);
                sw.Flush();
                sw.Close();
                fs.Close();
                DialogResult dialog = new DialogResult();
                dialog = MessageBox.Show("Tekrar oynamak ister misiniz?", "ÇIKIŞ", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                { 
                    tmr_sure.Stop();
                    sure = 30;
                    this.Hide();
                    frmOyun fo = new frmOyun();
                    fo.ShowDialog();
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void btnClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.Dispose();

            sonuc += int.Parse(b.Text);
            label1.Text = $" Puan = {sonuc}";

        }


    }
}
