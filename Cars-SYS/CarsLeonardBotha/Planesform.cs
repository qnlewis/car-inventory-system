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
    public partial class Planesform : Form
    {
        public Planesform()
        {
            InitializeComponent();
        }
        //Creating the Connection
        OleDbConnection conn;
        OleDbCommand cmd;

        private void Planesform_Load(object sender, EventArgs e)
        {
            //In this part of the code we are connecting to the database
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steph\OneDrive\Documents\Visual Studio 2008\Projects\CarsLeonardBotha\CARS.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }

         private void ShowDB()
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Airplane"; // here we are using the SELECT FROM Statement
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        
        private void Clear()
        {
            tBPlID.Clear();
            tBPlModel.Clear();
            tBPlYear.Clear();
            tBPlPrice.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Airplane(AirplaneModel, AirplaneYear, AirplanePrice) VALUES('" + tBPlModel.Text + "','" + tBPlYear.Text.ToString() + "','" + tBPlPrice.Text.ToString() + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowDB();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Airplane"; // here we are using the SELECT FROM Statement
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Airplane SET AirplaneModel = '" + tBPlModel.Text + "', AirplaneYear = '" + tBPlYear.Text.ToString() + "', AirplanePrice = '" + tBPlPrice.Text.ToString() + "' WHERE ID = '" + tBPlID.Text.ToString() + "'";
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
            cmd.CommandText = "DELETE FROM Airplane WHERE ID = '" + tBPlID.Text.ToString() + "'";
            cmd.ExecuteNonQuery();
            conn.Close();
            ShowDB();
            Clear();
        }
    }
}
