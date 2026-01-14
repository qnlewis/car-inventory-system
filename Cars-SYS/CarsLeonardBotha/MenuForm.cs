using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarsLeonardBotha
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseForm dbf = new DatabaseForm();
            dbf.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TrainForm Trains = new TrainForm();
            Trains.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAP_Click(object sender, EventArgs e)
        {
            Planesform AirPl = new Planesform();
            AirPl.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
