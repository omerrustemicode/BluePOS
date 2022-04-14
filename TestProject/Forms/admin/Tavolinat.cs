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
    public partial class tavolinat : Form
    {
        MySqlConnection conn = new MySqlConnection(myclass.insert.connect);
        public tavolinat()
        {
            InitializeComponent();
            shfaqtavolinat();
        }
        #region shto tavolin
        public void shtotavolin()
        {

            
            //shikon a ekziston useri

            string selectQuery = "SELECT numri from tavolina where numri='"+numritxt.Text+"'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

            }

            if (reader.HasRows == true)
            {
                MessageBox.Show("Tavolina = " + numritxt.Text + " Ekzistojne ne listen e tavolinave", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                conn.Close();
                conn.Open();
                //shton userin
                string qr = string.Format(@"insert into tavolina(numri) values('" + numritxt.Text + "')");
                MySqlCommand cmd = new MySqlCommand(qr, conn);
                DataTable dt = new DataTable();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Tavolina u shtua me sukses", "Informate", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
        }
        #endregion
        #region update tavolina
        public void updtavolina()
        {

            try
            {
                if (String.IsNullOrEmpty(selectcomb.Text))
                {
                    MessageBox.Show("Nuk ka tavoline te selektuar.", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string query = "UPDATE tavolina  SET numri='" + this.numriupd.Text + "' WHERE numri ='" + this.selectcomb.Text + "';";
                    //This is  MySqlConnection here i have created the object and pass my connection string.  
                    MySqlConnection MyConn2 = new MySqlConnection(myclass.insert.connect);
                    MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                    MySqlDataReader MyReader2;
                    MyConn2.Open();
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Te dhenat u ndryshuan");
                    while (MyReader2.Read())
                    {
                    }
                    MyConn2.Close();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        // i shfaq tavolinat ne combobox
        #region shfaq tavolinat
        public void shfaqtavolinat()
        {
            MySqlConnection connection = new MySqlConnection(myclass.insert.connect);

            string selectQuery = "SELECT numri FROM tavolina";
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                selectcomb.Items.Add(reader.GetString("numri"));
            }
            connection.Close();
        }
        #endregion
        // i shfaq tavolinat tek textboxi qe selektohen nga combo
        #region shfaq te dhenat e tavolines qe ekziston nga combobox
        public void shfaqcombotavolin()
        {

            string selectQuery = "SELECT numri FROM tavolina where numri='"+selectcomb.Text+"'";
            conn.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
              numriupd.Text = (reader.GetString("numri"));

            }
            conn.Close();
        }
        #endregion
        //fshin tavolinen
        #region fshije tavolinen
        private void fshijetav()
        {
            try
            {

                string Query = "delete from tavolina where numri='" + this.selectcomb.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(myclass.insert.connect);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Tavolina u fshi");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
                punetoret pt = new punetoret();
                pt.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void shtobtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(numritxt.Text))
            {
                MessageBox.Show("Shenoni nje Emer te Tavolines", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                shtotavolin();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(numriupd.Text))
            {
                MessageBox.Show("Shenoni nje Emer te Tavolines", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updtavolina();
            }
        }

        private void selectcomb_SelectedIndexChanged(object sender, EventArgs e)
        {
            shfaqcombotavolin();
        }

        private void delbtn_Click(object sender, EventArgs e)
        {
            fshijetav();
        }

        private void numriupd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
