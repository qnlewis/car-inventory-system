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
    public partial class DatabaseForm : Form
    {
        public DatabaseForm()
        {
            InitializeComponent();
        }
        //Creating the Connection
        OleDbConnection conn;
        OleDbCommand cmd;

        private void DatabaseForm_Load(object sender, EventArgs e)
        {
            //In this part of the code we are connecting to the database
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steph\OneDrive\Documents\Visual Studio 2008\Projects\CarsLeonardBotha\CARS.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }

        private void Show()
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CarType"; // here we are using the SELECT FROM Statement
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Clear()
        {
            tBCarName.Clear();
            tBCarColor.Clear();
            tBCarYear.Clear();
            tBCarID.Clear();
        }

        
        //below we show the whole table
        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open(); //opening the connection to the database
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from CarType"; // here we are using the SELECT FROM Statement
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
            cmd.CommandText = "INSERT INTO CarType(CarYear, CarName, CarColor) VALUES('"+ tBCarYear.Text.ToString() +"','"+ tBCarName.Text +"','"+ tBCarColor.Text +"')";
            cmd.ExecuteNonQuery();
            conn.Close();
            Show();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update CarType SET CarYear = " + tBCarYear.Text.ToString() + ", CarName = '" + tBCarName.Text + "', CarColor = '" + tBCarColor.Text + "' WHERE ID = " + tBCarID.Text.ToString() + "";
            cmd.ExecuteNonQuery();
            conn.Close();
            Show();
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM CarType WHERE ID= "+ tBCarID.Text.ToString() +"";
            cmd.ExecuteNonQuery(); 
            conn.Close();
            Show();
            Clear();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
