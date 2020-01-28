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
        public IgracUC(string ime, string broj, string pozicija,bool cap)
        {
            InitializeComponent();
            Ime = ime;
            Broj = broj;
            Pozicija = pozicija;
            Cap = cap;
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


    }
}
