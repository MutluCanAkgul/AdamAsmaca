using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        String[] kelimeler = {"bilgisayar","kulaklık","ekran","işlemci","anakart"};
        int kalanhak;
        int sayac;
        char[] tahmin;
        String kelime;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YeniOyun();
        }
        private void YeniOyun()
        {
         sayac = 0;
         Random rn = new Random(); 
         kelime = kelimeler[rn.Next(kelimeler.Length)];
         tahmin = new char[kelime.Length];
         kalanhak = 7;
            for(int i = 0;i<kelime.Length;i++)
            {
                tahmin[i] = '_';
            }
            button1.Enabled = true;
            EkranUpdate();
        }
        private void EkranUpdate()
        {
            label1.Text = "Kalan Hak = " + kalanhak.ToString();
            label2.Text =  string.Join(" ", tahmin);
            pictureBox1.Load("Saved Pictures/" + sayac + ".png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length == 1)
            {
                char tahminHarf = char.ToLower(textBox1.Text[0]);
                if (kelime.Contains(tahminHarf))
                {
                    if (tahmin.Contains(tahminHarf))
                    {
                        MessageBox.Show("Bu Harfi Daha Önceden Girdiniz");
                    }
                    else
                    {
                        for (int i = 0; i < kelime.Length; i++)
                        {
                            if (kelime[i] == tahminHarf)
                            {
                                tahmin[i] = tahminHarf;
                            }
                        }
                        if (!tahmin.Contains('_'))
                        {
                            MessageBox.Show("Kazandınız");
                            button1.Enabled = false;
                        }
                    }
                }
                else
                {
                    kalanhak--;
                    sayac++;
                    if (kalanhak == 0)
                    {
                        MessageBox.Show("Kaybettiniz");
                        button1.Enabled = false;
                    }
                }
                EkranUpdate();
            }
           
            else
            {
                MessageBox.Show("Sadece Harf Girin");
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            YeniOyun();
        }
    }
}
