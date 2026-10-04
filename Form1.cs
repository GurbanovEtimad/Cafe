using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cafe
{
    public partial class Form1 : Form
    {
        // Səbət
        List<Yemek> sebet = new List<Yemek>();

        // Xanalar
        TextBox txtMuddet;
        TextBox txtMebleg;
        TextBox txtQaliq;
        TextBox txtHesab;

        // Səbət
        ListBox lstSebet;

        public Form1()
        {
            InitializeComponent();

            // Formun görünüşü
            this.Text = "Cafe system";
            this.Size = new Size(1000, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            ProqramiQur();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        // =====================================================
        // PROQRAMI QURURUQ
        // =====================================================

        void ProqramiQur()
        {
            // ---------------- SOL HİSSƏ ----------------

            Panel sol = new Panel();
            sol.BackColor = Color.LightGray;
            sol.Location = new Point(10, 10);
            sol.Size = new Size(230, 570);
            this.Controls.Add(sol);

            Label cafe = new Label();
            cafe.Text = "Cafe\n☕";
            cafe.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            cafe.TextAlign = ContentAlignment.MiddleCenter;
            cafe.Location = new Point(50, 20);
            cafe.Size = new Size(130, 100);
            sol.Controls.Add(cafe);


            // Müddət
            Label lblMuddet = new Label();
            lblMuddet.Text = "Müddət:";
            lblMuddet.Location = new Point(25, 140);
            lblMuddet.Size = new Size(80, 25);
            sol.Controls.Add(lblMuddet);

            txtMuddet = new TextBox();
            txtMuddet.Location = new Point(90, 137);
            txtMuddet.Size = new Size(100, 25);
            sol.Controls.Add(txtMuddet);


            // Məbləğ
            Label lblMebleg = new Label();
            lblMebleg.Text = "Məbləğ";
            lblMebleg.Location = new Point(25, 190);
            lblMebleg.Size = new Size(100, 25);
            sol.Controls.Add(lblMebleg);

            txtMebleg = new TextBox();
            txtMebleg.Location = new Point(25, 215);
            txtMebleg.Size = new Size(165, 30);
            sol.Controls.Add(txtMebleg);


            // Qalıq
            Label lblQaliq = new Label();
            lblQaliq.Text = "Qalıq";
            lblQaliq.Location = new Point(25, 260);
            lblQaliq.Size = new Size(100, 25);
            sol.Controls.Add(lblQaliq);

            txtQaliq = new TextBox();
            txtQaliq.Location = new Point(25, 285);
            txtQaliq.Size = new Size(165, 30);
            txtQaliq.ReadOnly = true;
            sol.Controls.Add(txtQaliq);


            // Hesabla
            Button btnHesabla = new Button();
            btnHesabla.Text = "Hesabla";
            btnHesabla.Location = new Point(25, 335);
            btnHesabla.Size = new Size(165, 40);
            btnHesabla.BackColor = Color.Green;
            btnHesabla.ForeColor = Color.White;
            btnHesabla.Click += Hesabla;
            sol.Controls.Add(btnHesabla);


            // Təmizlə
            Button btnTemizle = new Button();
            btnTemizle.Text = "Təmizlə";
            btnTemizle.Location = new Point(25, 390);
            btnTemizle.Size = new Size(165, 40);
            btnTemizle.BackColor = Color.Red;
            btnTemizle.ForeColor = Color.White;
            btnTemizle.Click += Temizle;
            sol.Controls.Add(btnTemizle);


            // ---------------- MENYU ----------------

            Panel menu = new Panel();
            menu.BackColor = Color.WhiteSmoke;
            menu.Location = new Point(250, 10);
            menu.Size = new Size(500, 570);
            this.Controls.Add(menu);

            Label lblMenu = new Label();
            lblMenu.Text = "MENU";
            lblMenu.Font = new Font("Arial", 25, FontStyle.Bold | FontStyle.Italic);
            lblMenu.TextAlign = ContentAlignment.MiddleCenter;
            lblMenu.Location = new Point(150, 15);
            lblMenu.Size = new Size(200, 50);
            menu.Controls.Add(lblMenu);


            // Yeməklər
            YemekDugmesi(menu, "🍰\nTort\n5 AZN", 30, 90, "Tort", 5);
            YemekDugmesi(menu, "🥤\nKola\n2 AZN", 180, 90, "Kola", 2);
            YemekDugmesi(menu, "🍹\nŞirə\n3 AZN", 330, 90, "Şirə", 3);

            YemekDugmesi(menu, "🍔\nBurger\n7 AZN", 30, 230, "Burger", 7);
            YemekDugmesi(menu, "🥪\nSendviç\n6 AZN", 180, 230, "Sendviç", 6);
            YemekDugmesi(menu, "🍕\nPizza\n8 AZN", 330, 230, "Pizza", 8);

            YemekDugmesi(menu, "🧁\nMaffin\n4 AZN", 30, 370, "Maffin", 4);
            YemekDugmesi(menu, "🌭\nHot Dog\n5 AZN", 180, 370, "Hot Dog", 5);
            YemekDugmesi(menu, "🍪\nPeçenye\n3 AZN", 330, 370, "Peçenye", 3);


            // ---------------- SAĞ HİSSƏ ----------------

            Panel sag = new Panel();
            sag.BackColor = Color.LightGray;
            sag.Location = new Point(760, 10);
            sag.Size = new Size(210, 570);
            this.Controls.Add(sag);


            Label lblSebet = new Label();
            lblSebet.Text = "Səbət";
            lblSebet.Font = new Font("Arial", 22, FontStyle.Bold | FontStyle.Italic);
            lblSebet.TextAlign = ContentAlignment.MiddleCenter;
            lblSebet.Location = new Point(40, 20);
            lblSebet.Size = new Size(130, 45);
            sag.Controls.Add(lblSebet);


            // ListBox
            lstSebet = new ListBox();
            lstSebet.Location = new Point(20, 80);
            lstSebet.Size = new Size(170, 240);
            sag.Controls.Add(lstSebet);


            // Səbətdən sil
            Button btnSil = new Button();
            btnSil.Text = "Səbətdən sil";
            btnSil.Location = new Point(20, 330);
            btnSil.Size = new Size(170, 35);
            btnSil.Click += SebetdenSil;
            sag.Controls.Add(btnSil);


            // Yenilə
            Button btnYenile = new Button();
            btnYenile.Text = "Yenilə";
            btnYenile.Location = new Point(20, 375);
            btnYenile.Size = new Size(170, 35);
            btnYenile.Click += Yenile;
            sag.Controls.Add(btnYenile);


            // Yekun hesab
            Button btnYekun = new Button();
            btnYekun.Text = "Yekun hesab";
            btnYekun.Location = new Point(20, 420);
            btnYekun.Size = new Size(170, 35);
            btnYekun.Click += YekunHesab;
            sag.Controls.Add(btnYekun);


            // Hesab
            Label lblHesab = new Label();
            lblHesab.Text = "Hesab:";
            lblHesab.Location = new Point(20, 475);
            lblHesab.Size = new Size(60, 25);
            lblHesab.Font = new Font("Arial", 10, FontStyle.Bold);
            sag.Controls.Add(lblHesab);

            txtHesab = new TextBox();
            txtHesab.Location = new Point(80, 472);
            txtHesab.Size = new Size(110, 30);
            txtHesab.ReadOnly = true;
            sag.Controls.Add(txtHesab);
        }


        // =====================================================
        // YEMƏK DÜYMƏSİ
        // =====================================================

        void YemekDugmesi(
            Panel panel,
            string yazı,
            int x,
            int y,
            string ad,
            decimal qiymet)
        {
            Button btn = new Button();

            btn.Text = yazı;
            btn.Font = new Font("Segoe UI Emoji", 13);
            btn.Location = new Point(x, y);
            btn.Size = new Size(130, 110);
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;

            btn.Click += (sender, e) =>
            {
                sebet.Add(new Yemek(ad, qiymet));

                lstSebet.Items.Add(
                    ad + " - " + qiymet.ToString("0.00") + " AZN"
                );
            };

            panel.Controls.Add(btn);
        }


        // =====================================================
        // SƏBƏTDƏN SİL
        // =====================================================

        void SebetdenSil(object sender, EventArgs e)
        {
            if (lstSebet.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Səbətdən silmək üçün yemək seçin!"
                );

                return;
            }

            int index = lstSebet.SelectedIndex;

            string yemekAdi = sebet[index].Ad;

            sebet.RemoveAt(index);

            lstSebet.Items.RemoveAt(index);

            MessageBox.Show(
                yemekAdi + " səbətdən silindi"
            );
        }


        // =====================================================
        // YENİLƏ
        // =====================================================

        void Yenile(object sender, EventArgs e)
        {
            DialogResult cavab = MessageBox.Show(
                "Xanalar sıfırlansınmı?",
                "Yenilə",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (cavab == DialogResult.Yes)
            {
                txtMebleg.Clear();
                txtQaliq.Clear();
                txtHesab.Clear();

                lstSebet.Items.Clear();
                sebet.Clear();
            }
        }


        // =====================================================
        // YEKUN HESAB
        // =====================================================

        void YekunHesab(object sender, EventArgs e)
        {
            if (sebet.Count == 0)
            {
                MessageBox.Show(
                    "Səbətdə yemək yoxdur!"
                );

                return;
            }

            decimal hesab = 0;

            foreach (Yemek yemek in sebet)
            {
                hesab += yemek.Qiymet;
            }

            txtHesab.Text = hesab.ToString("0.00") + " AZN";
        }


        // =====================================================
        // HESABLA
        // =====================================================

        void Hesabla(object sender, EventArgs e)
        {
            if (sebet.Count == 0)
            {
                MessageBox.Show(
                    "Səbətdə yemək yoxdur!"
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtHesab.Text))
            {
                MessageBox.Show(
                    "Əvvəlcə Yekun hesab düyməsinə basın!"
                );

                return;
            }

            decimal hesab = 0;
            decimal mebleg = 0;

            string hesabText =
                txtHesab.Text.Replace(" AZN", "");

            if (!decimal.TryParse(hesabText, out hesab))
            {
                MessageBox.Show(
                    "Hesab düzgün deyil!"
                );

                return;
            }

            if (!decimal.TryParse(txtMebleg.Text, out mebleg))
            {
                MessageBox.Show(
                    "Məbləği düzgün daxil edin!"
                );

                return;
            }

            if (mebleg < hesab)
            {
                MessageBox.Show(
                    "Daxil edilən məbləğ hesabdan azdır"
                );

                txtQaliq.Clear();

                return;
            }

            decimal qaliq = mebleg - hesab;

            txtQaliq.Text =
                qaliq.ToString("0.00") + " AZN";
        }


        // =====================================================
        // TƏMİZLƏ
        // =====================================================

        void Temizle(object sender, EventArgs e)
        {
            // Yalnız Məbləğ və Qalıq
            txtMebleg.Clear();
            txtQaliq.Clear();
        }
    }


    // =========================================================
    // YEMƏK CLASS-I
    // =========================================================

    public class Yemek
    {
        public string Ad { get; set; }

        public decimal Qiymet { get; set; }

        public Yemek(string ad, decimal qiymet)
        {
            Ad = ad;
            Qiymet = qiymet;
        }
    }
}