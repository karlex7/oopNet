using ClassLibrary;
using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form4 : Form
    {
        public string Fifa_Code { get; set; }
        public List<StartingEleven> ListaIgraca { get; set; }
        IRepo repo = RepoFactory.getRepo();

        string pathImg = @"C:\Users\FRIDAY\Documents\OPP .NET projekt\OOP .NET projekt\playersImg.txt";
        public Form4(string fifa_Code)
        {
            InitializeComponent();
            Fifa_Code = fifa_Code;
            ListaIgraca = repo.GetStartingElevenForCountry(Fifa_Code);
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PrikaziStatistiku();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            loadSlike();
        }

        private void PrikaziStatistiku()
        {
            IRepo repo = RepoFactory.getRepo();
            List<StartingEleven> startingElevens = repo.GetGoalAndYellowStatisticForCountry(Fifa_Code);
            List<IgracStatistikaUC> listaKontrola = new List<IgracStatistikaUC>();
            foreach (StartingEleven s in startingElevens)
            {
                IgracStatistikaUC igrac = new IgracStatistikaUC(s.Name, s.Golas.ToString(), s.NumerOfYellowCards.ToString());
                listaKontrola.Add(igrac);
            }
            List<IgracStatistikaUC> sortiranaLista = listaKontrola.OrderBy(i => i.Golovi).ToList();
            sortiranaLista.Reverse();
            foreach (IgracStatistikaUC i in sortiranaLista)
            {
                i.loadData();
                flowLayoutPanel1.Controls.Add(i);
            }
        }
        private void loadSlike()
        {
            List<IgracStatistikaUC> lista = new List<IgracStatistikaUC>();
            if (!File.Exists(pathImg))
            {
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(pathImg))
                {
                    while (!sr.EndOfStream)
                    {
                        string tekst = sr.ReadLine();
                        string[] splitaniTekst = tekst.Split('|');
                        StartingEleven s = GetStartingEleven(splitaniTekst[0]);
                        IgracStatistikaUC i = new IgracStatistikaUC(s.Name,s.Golas.ToString(),s.NumerOfYellowCards.ToString());
                        i.setImgPath(splitaniTekst[1]);
                        lista.Add(i);
                    }
                    ucitaneSlikePrikazi(lista);
                }
            }
        }
        private void ucitaneSlikePrikazi(List<IgracStatistikaUC> lista)
        {
            foreach (IgracStatistikaUC i in flowLayoutPanel1.Controls)
            {
                foreach (IgracStatistikaUC j in lista)
                {
                    if (j.Ime.Equals(i.Ime))
                    {
                        i.setImgPath(j.getImgPath());
                    }
                }
            }
        }
        public StartingEleven GetStartingEleven(string name)
        {
            StartingEleven startingEleven = new StartingEleven();
            List<StartingEleven> list = ListaIgraca;
            foreach (StartingEleven item in list)
            {
                if (item.Name.Equals(name))
                {
                    startingEleven = item;
                }
            }

            return startingEleven;
        }
    }
}
