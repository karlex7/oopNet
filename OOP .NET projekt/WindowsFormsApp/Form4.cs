using ClassLibrary;
using ClassLibrary.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            PrikaziStatistiku();
        }

        private void PrikaziStatistiku()
        {
            IRepo repo = RepoFactory.getRepo();
            List<StartingEleven> startingElevens = repo.GetGoalAndYellowStatisticForCountry("FRA");

            foreach (StartingEleven s in startingElevens)
            {
            }
        }
    }
}
