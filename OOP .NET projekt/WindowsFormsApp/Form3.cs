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
    public partial class Form3 : Form
    {
        public List<StartingEleven> ListaIgraca { get; set; }
        public List<IgracUC> ListaKontrolaIgraciToOmiljeni { get; set; }
        public List<IgracUC> ListaKontrolaOmiljeniToIgraci{ get; set; }
        string path = Environment.CurrentDirectory + "/" + "favouritePlayers.txt";
        public Form3(List<StartingEleven> listaIgraca)
        {
            ListaIgraca = listaIgraca;
            ListaKontrolaIgraciToOmiljeni = new List<IgracUC>();
            ListaKontrolaOmiljeniToIgraci = new List<IgracUC>();
            InitializeComponent();
            setupPanels();
            loadIgrace();
            loadFavoriti();
        }

        private void loadFavoriti()
        {
            List<IgracUC> listaUcitanihIgraca = new List<IgracUC>();
            if (!File.Exists(path))
            {
                return;
            }
            else
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string ime = sr.ReadLine();
                        StartingEleven s = GetStartingEleven(ime);
                        IgracUC igrac = new IgracUC(s.Name, s.ShirtNumber.ToString(), s.Position.ToString(),s.Captain);
                        igrac.Name = igrac.Ime;
                        igrac.MouseDown += IgracUC_Mouse_Down_Omiljeni_To_Igraci;
                        igrac.loadData();
                        flowLayoutPanel2.Controls.Add(igrac);
                        flowLayoutPanel1.Controls.RemoveByKey(igrac.Name);
                    }
                    
                   
                }
            }
        }

        private void setupPanels()
        {

            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.WrapContents = false;

            //Eventi
            flowLayoutPanel1.AllowDrop = true;
            flowLayoutPanel2.AllowDrop = true;
            flowLayoutPanel1.DragEnter += flp1_DragEnter;
            flowLayoutPanel1.DragDrop += flp1_DragDrop;
            flowLayoutPanel2.DragEnter += flp2_DragEnter;
            flowLayoutPanel2.DragDrop += flp2_DragDrop;


        }

        private void flp2_DragDrop(object sender, DragEventArgs e)
        {
            string igracIme = e.Data.GetData(DataFormats.Text).ToString();
            StartingEleven s = GetStartingEleven(igracIme);
            IgracUC igracUC = new IgracUC(s.Name, s.ShirtNumber.ToString(), s.Position.ToString(),s.Captain);
            igracUC.Name = igracIme;
            igracUC.MouseDown += IgracUC_Mouse_Down_Omiljeni_To_Igraci;
            igracUC.loadData();
            resetFLP1Colors();
            resetFLP2Colors();
            flowLayoutPanel2.Controls.Add(igracUC);
            flowLayoutPanel1.Controls.RemoveByKey(igracIme);

            ListaKontrolaIgraciToOmiljeni.Clear();
            ListaKontrolaOmiljeniToIgraci.Clear();
        }

        private void flp2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void flp1_DragDrop(object sender, DragEventArgs e)
        {
            string igracIme = e.Data.GetData(DataFormats.Text).ToString();
            StartingEleven s = GetStartingEleven(igracIme);
            IgracUC igracUC = new IgracUC(s.Name, s.ShirtNumber.ToString(), s.Position.ToString(),s.Captain);
            igracUC.Name = igracIme;
            igracUC.MouseDown += IgracUC_Mouse_Down_Igraci_To_Omiljeni;
            igracUC.loadData();
            resetFLP1Colors();
            resetFLP2Colors();
            flowLayoutPanel1.Controls.Add(igracUC);
            flowLayoutPanel2.Controls.RemoveByKey(igracIme);

            ListaKontrolaOmiljeniToIgraci.Clear();
            ListaKontrolaIgraciToOmiljeni.Clear();
        }

        private void resetFLP1Colors()
        {
            foreach (IgracUC item in flowLayoutPanel1.Controls)
            {
                item.setNormalBackColor();
            }
        }

        private void resetFLP2Colors()
        {
            foreach (IgracUC item in flowLayoutPanel2.Controls)
            {
                item.setNormalBackColor();
            }
        }

        private void flp1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void loadIgrace()
        {
            IRepo repo = RepoFactory.getRepo();
            List<StartingEleven> starting= ListaIgraca;
            List<IgracUC> igraci = new List<IgracUC>();

            foreach (StartingEleven s in starting)
            {
                IgracUC i = new IgracUC(s.Name,s.ShirtNumber.ToString(),s.Position.ToString(),s.Captain);
                i.MouseDown += IgracUC_Mouse_Down_Igraci_To_Omiljeni;
                i.Click += IgracUC_Click;
                i.Name = s.Name;
                igraci.Add(i);
            }
            foreach (IgracUC item in igraci)
            {
                flowLayoutPanel1.Controls.Add(item);
                item.loadData();
            }

        }

        private void IgracUC_Click(object sender, EventArgs e)
        {
            IgracUC igracUC = sender as IgracUC;
            //ListaKontrolaIgraciToOmiljeni.Add(igracUC);
            //exists
            igracUC.setHighlight();
        }

        private void IgracUC_Mouse_Down_Igraci_To_Omiljeni(object sender, MouseEventArgs e)
        {
            IgracUC igracUC = sender as IgracUC;
            igracUC.DoDragDrop(igracUC.Ime, DragDropEffects.Copy);
            igracUC.setHighlight();
            string ime = igracUC.Ime;
            IgracUC premjestaj = igracUC;
            premjestaj.loadData();

            //Fix ako dragamo jednoga igraca pa ga pokusamo prebaciti jos preko menija
            //dodati na button a ne tu
            if (flowLayoutPanel2.Controls!=null)
            {
                foreach (IgracUC i in flowLayoutPanel2.Controls)
                {
                    if (i.Ime.Equals(premjestaj.Ime))
                    {
                        return;
                    }
                }
            }
            
            ListaKontrolaIgraciToOmiljeni.Add(premjestaj);
        }
        private void IgracUC_Mouse_Down_Omiljeni_To_Igraci(object sender, MouseEventArgs e)
        {
            IgracUC igracUC = sender as IgracUC;
            igracUC.DoDragDrop(igracUC.Ime, DragDropEffects.Copy);
            igracUC.setHighlight();
            string ime = igracUC.Ime;
            IgracUC premjestaj = igracUC;
            premjestaj.loadData();

            //Fix ako dragamo jednoga igraca pa ga pokusamo prebaciti jos preko menija
            /* foreach (IgracUC i in flowLayoutPanel1.Controls)
             {
                 if (i.Ime.Equals(premjestaj.Ime))
                 {
                     return;
                 }
             }*/
            if (flowLayoutPanel1.Controls != null)
            {
                foreach (IgracUC i in flowLayoutPanel1.Controls)
                {
                    if (i.Ime.Equals(premjestaj.Ime))
                    {
                        return;
                    }
                }
            }
            ListaKontrolaOmiljeniToIgraci.Add(premjestaj);
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

        private void btnIgracToOmiljeni_Click(object sender, EventArgs e)
        {
            foreach (IgracUC igrac in ListaKontrolaIgraciToOmiljeni)
            {
                StartingEleven s = GetStartingEleven(igrac.Ime);
                IgracUC igracUC = new IgracUC(s.Name, s.ShirtNumber.ToString(), s.Position.ToString(),s.Captain);
                igracUC.Name = igracUC.Ime;
                igracUC.MouseDown += IgracUC_Mouse_Down_Omiljeni_To_Igraci;//IgracUC_Mouse_Down_Igraci_To_Omiljeni;
                igracUC.setNormalBackColor();
                igracUC.loadData();
                flowLayoutPanel2.Controls.Add(igracUC);
                flowLayoutPanel1.Controls.RemoveByKey(igrac.Name);
            }

            ListaKontrolaIgraciToOmiljeni = new List<IgracUC>();
            
        }

        private void btnOmiljeniToIgraci_Click(object sender, EventArgs e)
        {

            foreach (IgracUC igrac in ListaKontrolaOmiljeniToIgraci)
            {
                StartingEleven s = GetStartingEleven(igrac.Ime);
                IgracUC igracUC = new IgracUC(s.Name, s.ShirtNumber.ToString(), s.Position.ToString(),s.Captain);
                igracUC.Name = igracUC.Ime;
                igracUC.MouseDown += IgracUC_Mouse_Down_Igraci_To_Omiljeni;
                igracUC.setNormalBackColor();
                igracUC.loadData();

                flowLayoutPanel1.Controls.Add(igracUC);
                flowLayoutPanel2.Controls.RemoveByKey(igrac.Name);
            }
            ListaKontrolaOmiljeniToIgraci = new List<IgracUC>();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                foreach (IgracUC igrac in flowLayoutPanel2.Controls)
                {
                    sw.WriteLine(igrac.ToString());
                }
            }
        }
    }
}
