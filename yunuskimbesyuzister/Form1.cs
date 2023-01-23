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

namespace yunuskimbesyuzister
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public OleDbConnection bag = new OleDbConnection("Provider=Microsoft.Ace.Oledb.12.0;Data Source=sorularsql.accdb");
        public OleDbCommand kmt = new OleDbCommand();
        int[] sayilar = new int[13];
        int[] secenekSayilar = new int[2];
        Random r = new Random();
        int randomSayac = 0, soruSayac = 1, kazanilanPara = 0, uretilmeyecekSayi = 0;
        string dogruCevap, yarismaciCevap;

        void radioButonlarıGoster()
        {
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
        }
        void radioButonlarıSecme()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        void rastgeleSayi()
        {
            int rastgele;
            randomSayac = 0;
            while (randomSayac < 13)
            {
                rastgele = r.Next(1, 51);
                if (Array.IndexOf(sayilar, rastgele) == -1)
                {
                    sayilar[randomSayac] = rastgele;
                    randomSayac++;
                }
            }
        }

        void secenekRastgeleSayi()
        {
            int rastgele;
            randomSayac = 0;
            while (randomSayac < 2)
            {
                rastgele = r.Next(1, 4);
                if (Array.IndexOf(secenekSayilar, rastgele) == -1 && rastgele != uretilmeyecekSayi)
                {
                    secenekSayilar[randomSayac] = rastgele;
                    randomSayac++;
                }
            }
        }

        void soruAl(int a)
        {
            bag.Open();
            kmt.Connection = bag;
            kmt.CommandText = "Select  * from sorular where soruId=" + sayilar[a];
            OleDbDataReader oku;
            oku = kmt.ExecuteReader();
            while (oku.Read())
            {
                label13.Text = oku[1].ToString();
                radioButton1.Text = oku[2].ToString();
                radioButton2.Text = oku[3].ToString();
                radioButton3.Text = oku[4].ToString();
                radioButton4.Text = oku[5].ToString();
                dogruCevap = oku[6].ToString();
            }
            oku.Dispose();
            bag.Close();
            if (a == 1) kazanilanPara = 500;
            if (a == 2) kazanilanPara = 1000;
            if (a == 3) kazanilanPara = 2000;
            if (a == 4) kazanilanPara = 3000;
            if (a == 5) kazanilanPara = 5000;
            if (a == 6) kazanilanPara = 7500;
            if (a == 7) kazanilanPara = 15000;
            if (a == 8) kazanilanPara = 30000;
            if (a == 9) kazanilanPara = 60000;
            if (a == 10) kazanilanPara = 500000;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelRenklendir(soruSayac);
            rastgeleSayi();
            soruAl(soruSayac);
            timer1.Enabled = true;
        }
        void labelRenkSifirla()
        {
            label1.ForeColor = Color.DarkOrange;
            label1.BackColor = Color.Blue;
            label2.ForeColor = Color.White;
            label2.BackColor = Color.Blue;
            label3.ForeColor = Color.DarkOrange;
            label3.BackColor = Color.Blue;
            label4.ForeColor = Color.DarkOrange;
            label4.BackColor = Color.Blue;
            label5.ForeColor = Color.DarkOrange;
            label5.BackColor = Color.Blue;
            label6.ForeColor = Color.DarkOrange;
            label6.BackColor = Color.Blue;
            label7.ForeColor = Color.White;
            label7.BackColor = Color.Blue;
            label8.ForeColor = Color.DarkOrange;
            label8.BackColor = Color.Blue;
            label9.ForeColor = Color.DarkOrange;
            label9.BackColor = Color.Blue;
            label10.ForeColor = Color.DarkOrange;
            label10.BackColor = Color.Blue;

        }
        void labelRenklendir(int a)
        {
            if (a == 1)
            {
                label1.ForeColor = Color.Black;
                label1.BackColor = Color.DarkOrange;
            }
            if (a == 2)
            {
                label2.ForeColor = Color.Black;
                label2.BackColor = Color.DarkOrange;
                label1.ForeColor = Color.DarkOrange;
                label1.BackColor = Color.Blue;
            }
            if (a == 3)
            {
                label3.ForeColor = Color.Black;
                label3.BackColor = Color.DarkOrange;
                label2.ForeColor = Color.White;
                label2.BackColor = Color.Blue;
            }
            if (a == 4)
            {
                label4.ForeColor = Color.Black;
                label4.BackColor = Color.DarkOrange;
                label3.ForeColor = Color.DarkOrange;
                label3.BackColor = Color.Blue;
            }
            if (a == 5)
            {
                label5.ForeColor = Color.Black;
                label5.BackColor = Color.DarkOrange;
                label4.ForeColor = Color.DarkOrange;
                label4.BackColor = Color.Blue;
            }
            if (a == 6)
            {
                label6.ForeColor = Color.Black;
                label6.BackColor = Color.DarkOrange;
                label5.ForeColor = Color.DarkOrange;
                label5.BackColor = Color.Blue;
            }
            if (a == 6)
            {
                label6.ForeColor = Color.Black;
                label6.BackColor = Color.DarkOrange;
                label5.ForeColor = Color.DarkOrange;
                label5.BackColor = Color.Blue;
            }
            if (a == 7)
            {
                label7.ForeColor = Color.Black;
                label7.BackColor = Color.DarkOrange;
                label6.ForeColor = Color.DarkOrange;
                label6.BackColor = Color.Blue;
            }
            if (a == 8)
            {
                label8.ForeColor = Color.Black;
                label8.BackColor = Color.DarkOrange;
                label7.ForeColor = Color.White;
                label7.BackColor = Color.Blue;
            }
            if (a == 9)
            {
                label9.ForeColor = Color.Black;
                label9.BackColor = Color.DarkOrange;
                label8.ForeColor = Color.DarkOrange;
                label8.BackColor = Color.Blue;
            }
            if (a == 10)
            {
                label10.ForeColor = Color.Black;
                label10.BackColor = Color.DarkOrange;
                label9.ForeColor = Color.DarkOrange;
                label9.BackColor = Color.Blue;

            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dak > 0)
            {
                dak--;
                label15.Text = dak.ToString();
            }
            else
            {
                if (soruSayac <= 2) label14.Text = "Süre Doldu. 0 TL Kazandınız ...";
                if (soruSayac > 2 && soruSayac < 7) label14.Text = "Süre Doldu. 1000 TL Kazandınız ...";
                if (soruSayac >= 7) label14.Text = "Süre Doldu. 15.000 TL Kazandınız ...";
                timer1.Enabled = false;
                btnCevapla.Visible = false;
                btnTekrarOyna.Visible = true;

            }
        }





        private void btnSeyirci_Click(object sender, EventArgs e)
        {
            int rastgele;
            string seyirciCevap = "";
            rastgele = r.Next(1, 5);
            if (rastgele == 1) seyirciCevap = radioButton1.Text;
            if (rastgele == 2) seyirciCevap = radioButton2.Text;
            if (rastgele == 3) seyirciCevap = radioButton3.Text;
            if (rastgele == 4) seyirciCevap = radioButton4.Text;
            MessageBox.Show("Seyircinin en fazla vermiş olduğu cevap -- " + seyirciCevap + " -- seçeneğidir.", "Seyircinin Cevabı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSeyirci.Visible = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void btnElli_Click_1(object sender, EventArgs e)
        {
            Random r = new Random();
            string[] secenekler = new string[5];
            if (dogruCevap == radioButton1.Text) uretilmeyecekSayi = 1;
            if (dogruCevap == radioButton2.Text) uretilmeyecekSayi = 2;
            if (dogruCevap == radioButton3.Text) uretilmeyecekSayi = 3;
            if (dogruCevap == radioButton4.Text) uretilmeyecekSayi = 4;

            for (int i = 1; i < 5; i++)
            {
                if (dogruCevap != radioButton1.Text && i == 1) secenekler[i] = radioButton1.Text;
                if (dogruCevap != radioButton2.Text && i == 2) secenekler[i] = radioButton2.Text;
                if (dogruCevap != radioButton3.Text && i == 3) secenekler[i] = radioButton3.Text;
                if (dogruCevap != radioButton4.Text && i == 4) secenekler[i] = radioButton4.Text;
            }
            secenekRastgeleSayi();
            for (int i = 0; i < 2; i++)
            {
                if (secenekler[secenekSayilar[i]] == radioButton1.Text) radioButton1.Visible = false;
                if (secenekler[secenekSayilar[i]] == radioButton2.Text) radioButton2.Visible = false;
                if (secenekler[secenekSayilar[i]] == radioButton3.Text) radioButton3.Visible = false;
                if (secenekler[secenekSayilar[i]] == radioButton4.Text) radioButton4.Visible = false;
            }
            btnElli.Visible = false;
        }

        private void btnTelefon_Click_1(object sender, EventArgs e)
        {
            int rastgele;
            string seyirciCevap = "";
            rastgele = r.Next(1, 5);
            if (rastgele == 1) seyirciCevap = radioButton1.Text;
            if (rastgele == 2) seyirciCevap = radioButton2.Text;
            if (rastgele == 3) seyirciCevap = radioButton3.Text;
            if (rastgele == 4) seyirciCevap = radioButton4.Text;
            MessageBox.Show("Telefon ile bağlandığınız kişinin vermiş olduğu cevap -- " + seyirciCevap + " -- seçeneğidir.", "Telefon Cevabı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnTelefon.Visible = false;
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTekrarOyna_Click_1(object sender, EventArgs e)
        {
            Array.Clear(secenekSayilar, 0, 2);
            btnCevapla.Visible = true;
            btnTekrarOyna.Visible = false;
            soruSayac = 1;
            labelRenkSifirla();
            labelRenklendir(soruSayac);
            rastgeleSayi();
            soruAl(soruSayac);
            timer1.Enabled = true;
            btnCevapla.Enabled = true;
            radioButonlarıSecme();
            radioButonlarıGoster();
            btnElli.Visible = true;
            btnSeyirci.Visible = true;
            btnTelefon.Visible = true;
            dak = 30;
            label14.Text = "";
        }

        private void btnCevapla_Click_1(object sender, EventArgs e)
        {

            if (soruSayac < 13)
            {
                DialogResult cevap, cevap2;
                cevap = MessageBox.Show("Son Kararın Mı ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cevap == DialogResult.Yes)
                {
                    timer1.Enabled = false;
                    dak = 30;
                    label15.Text = "30";
                    if (radioButton1.Checked) yarismaciCevap = radioButton1.Text;
                    if (radioButton2.Checked) yarismaciCevap = radioButton2.Text;
                    if (radioButton3.Checked) yarismaciCevap = radioButton3.Text;
                    if (radioButton4.Checked) yarismaciCevap = radioButton4.Text;
                    if (yarismaciCevap == dogruCevap)
                    {

                        if (soruSayac == 12)
                        {
                            label14.Text = "Tebrikler " + kazanilanPara + " TL Kazandınız ...";
                            btnCevapla.Visible = false;
                            btnTekrarOyna.Visible = true;
                        }
                        else
                        {
                            cevap2 = MessageBox.Show(kazanilanPara + " TL lik Çeki Almak için Evet'e Devam Etmek için Hayır'a Tıklayınız ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (cevap2 == DialogResult.Yes)
                            {
                                label14.Text = "Tebrikler " + kazanilanPara + " TL Kazandınız ...";
                                timer1.Enabled = false;
                                btnCevapla.Visible = false;
                                btnTekrarOyna.Visible = true;
                            }
                            else
                            {
                                soruSayac++;
                                soruAl(soruSayac);
                                labelRenklendir(soruSayac);
                                timer1.Enabled = true;
                                radioButonlarıGoster();
                                radioButonlarıSecme();
                            }
                        }

                    }
                    else
                    {

                        if (soruSayac <= 2) label14.Text = "Yanlış cevap 0 TL Kazandınız ...";
                        if (soruSayac > 2 && soruSayac < 6) label14.Text = "Yanlış cevap 1000 TL Kazandınız ...";
                        if (soruSayac >= 6) label14.Text = "Yanlış cevap 15.000 TL Kazandınız ...";
                        btnCevapla.Visible = false;
                        btnTekrarOyna.Visible = true;
                        timer1.Enabled = false;
                    }
                }
            }
        }
        int dak = 30;


    }
}
