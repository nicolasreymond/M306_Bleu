using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M306_Bleu_Projet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timerGlobal_Tick(object sender, EventArgs e)
        {
            String EuropeFormat = "HH:mm";
            String USAFormat = "hh:mm";
            String HeureActive = DateTime.Now.ToString(USAFormat);

            lblTime.Text = HeureActive;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timerGlobal.Start();
        }
    }
}
