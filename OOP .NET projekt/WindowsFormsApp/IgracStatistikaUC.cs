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
    public partial class IgracStatistikaUC : UserControl
    {
        public string Ime { get; set; }
        public string Golovi { get; set; }
        public string Zuti { get; set; }
        public string ImgPath { get; set; }
        public IgracStatistikaUC(string ime, string golovi, string zuti)
        {
            InitializeComponent();
            Ime = ime;
            Golovi = golovi;
            Zuti = zuti;
        }
        public IgracStatistikaUC()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            lblIme.Text = Ime;
            lblGolovi.Text = Golovi;
            lblZuti.Text = Zuti;
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
        private void PrikaziSliku(string putanja, string datoteka)
        {
            slika.ImageLocation = putanja;
            slika.Size = new Size(58, 58);
            slika.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
