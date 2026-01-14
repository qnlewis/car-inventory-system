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
    public partial class Form1 : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Form1()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steph\OneDrive\Documents\Visual Studio 2008\Projects\CarsLeonardBotha\CARS.accdb";
        }

        OleDbConnection conn;
        OleDbCommand cmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            //In this part of the code we are connecting to the database
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\steph\OneDrive\Documents\Visual Studio 2008\Projects\CarsLeonardBotha\CARS.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users WHERE Username='" + tBUsername.Text + "' AND Password='" + tBPassword.Text + "'";
                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MenuForm MnU = new MenuForm();
                    MnU.Show();
                    MessageBox.Show("Login successful!");
                    // Add code to open the main form of your application here
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!");
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}


