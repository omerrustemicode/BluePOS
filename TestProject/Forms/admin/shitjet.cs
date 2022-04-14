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
using System.Configuration;
namespace TestProject.Forms.admin
{
    public partial class shitjet : Form
    {
        public shitjet()
        {
            InitializeComponent();
            datatable();
            selectuser();
            selectproduct();
        }
        #region datatable
        public void datatable()
        {
            string query = "select emrip,sasiap,qmimip,datap,tavolina,punetori,totali from shitjet";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query,myclass.insert.connect))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                table.DataSource = dset.Tables[0];
                table.Columns[0].HeaderText = "Emri Produktit";
                table.Columns[1].HeaderText = "Sasia";
                table.Columns[2].HeaderText = "Qmimi";
                table.Columns[3].HeaderText = "Data";
                table.Columns[4].HeaderText = "Tavolina";
                table.Columns[5].HeaderText = "Punetori";
                table.Columns[6].HeaderText = "Totali";

            }
            myclass.insert.connect.Clone();
            table.Refresh();

        }
        #endregion
        #region selektouserin
        public void selectuser()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myclass.insert.connect);

                string selectQuery = "SELECT emri FROM user";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("emri"));
                    comboBox1.SelectedIndex = 0;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #endregion
        #region produktet ne combobox
        public void selectproduct()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(myclass.insert.connect);

                string selectQuery = "SELECT emriprod FROM produkt";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("emriprod"));
                
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #endregion
      
        private void shitjet_Load(object sender, EventArgs e)
        {

        }

        private void table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            #region kerko nga emri punetorit
            string query = "select emrip,sasiap,qmimip,datap,tavolina,punetori from shitjet where punetori='"+comboBox1.Text+"'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myclass.insert.connect))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                table.DataSource = dset.Tables[0];
                table.Columns[0].HeaderText = "Emri Produktit";
                table.Columns[1].HeaderText = "Sasia";
                table.Columns[2].HeaderText = "Qmimi";
                table.Columns[3].HeaderText = "Data";
                table.Columns[4].HeaderText = "Tavolina";
                table.Columns[5].HeaderText = "Punetori";


            }
            myclass.insert.connect.Clone();
            table.Refresh();
            #endregion
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            #region kerko nga data
            string query = "select emrip,sasiap,qmimip,datap,tavolina,punetori from shitjet where datap='" + dateTimePicker1.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myclass.insert.connect))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                table.DataSource = dset.Tables[0];
                table.Columns[0].HeaderText = "Emri Produktit";
                table.Columns[1].HeaderText = "Sasia";
                table.Columns[2].HeaderText = "Qmimi";
                table.Columns[3].HeaderText = "Data";
                table.Columns[4].HeaderText = "Tavolina";
                table.Columns[5].HeaderText = "Punetori";


            }
            myclass.insert.connect.Clone();
            table.Refresh();
            #endregion
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region kerko nga emri produktit
            string query = "select emrip,sasiap,qmimip,datap,tavolina,punetori from shitjet where emrip='" + comboBox2.Text + "'";

            using (MySqlDataAdapter adpt = new MySqlDataAdapter(query, myclass.insert.connect))
            {

                DataSet dset = new DataSet();

                adpt.Fill(dset);

                table.DataSource = dset.Tables[0];
                table.Columns[0].HeaderText = "Emri Produktit";
                table.Columns[1].HeaderText = "Sasia";
                table.Columns[2].HeaderText = "Qmimi";
                table.Columns[3].HeaderText = "Data";
                table.Columns[4].HeaderText = "Tavolina";
                table.Columns[5].HeaderText = "Punetori";


            }
            myclass.insert.connect.Clone();
            table.Refresh();
            #endregion
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
