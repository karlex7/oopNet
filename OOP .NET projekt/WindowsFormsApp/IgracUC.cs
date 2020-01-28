using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class IgracUC : UserControl
    {
        public string Ime { get; set; }
        public string Broj { get; set; }
        public string Pozicija { get; set; }
        public Color ColorOfControl { get; set; }
        public bool Cap { get; set; }
        public string ImgPath { get; set; }
        public string defaultImgPath { get; set; }
        public IgracUC(string ime, string broj, string pozicija,bool cap)
        {
            InitializeComponent();
            Ime = ime;
            Broj = broj;
            Pozicija = pozicija;
            Cap = cap;
            defaultImgPath = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\player.jpg";
            ImgPath = defaultImgPath;
            PrikaziSliku(ImgPath,"");
        }
        public void loadData()
        {
            lbIme.Text = Ime;
            lbBroj.Text = Broj;
            lbPozicija.Text = Pozicija;
            if (Cap)
            {
                lbKapetan.Text = "Kapetan";
            }
            else
            {
                lbKapetan.Text = "";
            }
        }
        public void setHighlight()
        {
            this.BackColor = Color.Aqua;
        }
        public void setNormalBackColor()
        {
            this.BackColor = Color.White;
        }
        public override string ToString()
        {
            return Ime; 
        }
        public void setImgPath(string pathImg)
        {
            ImgPath = pathImg;
            PrikaziSliku(ImgPath, "");
        }
        public string getImgPath()
        {
            return ImgPath;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog odabranaSlika = new OpenFileDialog();
            odabranaSlika.Filter = "Slike|*.bmp;*.jpg;*.jpeg;*.png;|Sve datoteke|*.*";
            odabranaSlika.InitialDirectory = Application.StartupPath;

            if (odabranaSlika.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PrikaziSliku(odabranaSlika.FileName, odabranaSlika.SafeFileName);
                setImgPath(odabranaSlika.FileName);
            }
        }

        private void PrikaziSliku(string putanja, string datoteka)
        {
            slika.ImageLocation = putanja;
            slika.Size = new Size(58, 58);
            slika.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
