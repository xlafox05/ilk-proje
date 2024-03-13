using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sahibinden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\ÖĞRENCİ\\Desktop\\Yeni klasör\\AracBilgileri.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kullanıcı = textBox1.Text;
            string sifre = textBox2.Text;
            OleDbCommand komut = new OleDbCommand("SELECT * FROM SistemKullanicilari WHERE KullaniciAdi ='" + kullanıcı + "' AND Sifre='" + sifre + "'", baglan);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Giriş başarılı,Satın alım ekranına geçiliyor");
                Form2 for2 = new Form2();
                this.Hide();
                for2.Show();
            }
            else
            {
                MessageBox.Show("Giriş Hatta oldu tekrar dene");
            }
            baglan.Close();
        }
    }
}
