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
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tboxAd.Text != "" && tboxSyd.Text != "")
            {
                MessageBox.Show("Giriş Başarılı");

                frmOyun frmoyn = new frmOyun();
                frmoyn.adSoyad = tboxAd.Text + " " + tboxSyd.Text;
                frmoyn.Show();
            }
            else
            {
                MessageBox.Show("Lütfen Ad Soyad Girin");
            }
        }
    }
}
