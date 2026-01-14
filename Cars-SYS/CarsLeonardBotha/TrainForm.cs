using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;


namespace CarsLeonardBotha
{
    public partial class TrainForm : Form
    {
        public TrainForm()
        {
            InitializeComponent();
        }

        OleDbConnection conn;
        OleDbCommand cmd;

        private void TrainForm_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steph\OneDrive\Documents\Visual Studio 2008\Projects\CarsLeonardBotha\CARS.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }

        private void ShowDB()
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Train"; // here we are using the SELECT FROM Statement
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Clear()
        {
            tBTrID.Clear();
            tBTrModel.Clear();
            tBTrYear.Clear();
            tBTrPrice.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Train"; // here we are using the SELECT FROM Statement
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Train(TrainModel, TrainYear, TrainPrice) VALUES('" + tBTrModel.Text + "','" + tBTrYear.Text.ToString() + "','" + tBTrPrice.Text.ToString() + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowDB();
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Train SET TrainModel = '" + tBTrModel.Text + "', TrainYear = '" + tBTrYear.Text.ToString() + "', TrainPrice = '" + tBTrPrice.Text.ToString() + "' WHERE ID = '" + tBTrID.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowDB();
            Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM Train WHERE ID = '" + tBTrID.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowDB();
            Clear();
        }
    }
}
