using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.IO;
using System.Configuration;
using TestProject.myclass;

namespace TestProject.Forms
{
    public partial class database : Form
    {
       

        public database()
        {
            InitializeComponent();
        }

        private void database_Load(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};port={1};Initial Catalog={2};User Id={3};password={4};SslMode=none;", serverTxt.Text,portTxt.Text, dbTxt.Text, userTxt.Text, PassTxt.Text);
            try
            {
                connections conns = new connections(connectionString);
                if (conns.isConnection)
                    MessageBox.Show("Connected to database","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};port={1};Initial Catalog={2};User Id={3};password={4};SslMode=none;", serverTxt.Text, portTxt.Text, dbTxt.Text, userTxt.Text, PassTxt.Text);
            try
            {
                connections conns = new connections(connectionString);
                if (conns.isConnection)
                {
                    savedb setting = new savedb();
                    setting.saveconn("conn",connectionString);
                    MessageBox.Show("Te Dhenat u ruajten me sukses", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
