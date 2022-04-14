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
    public partial class produktet : Form
    {
        MySqlConnection MyConn2 = new MySqlConnection(myclass.insert.connect);
        public produktet()
        {
            InitializeComponent();
            selectproduct();
        }
        #region produktet ne combobox
        public void selectproduct()
        {
            try
            {


                string selectQuery = "SELECT emriprod FROM produkt";
                MyConn2.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, MyConn2);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("emriprod"));

                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        #endregion
        #region shfaq te dhenat e produktit qe ekziston nga combobox
        public void shfaqcomboprod()
        {


            string selectQuery = "SELECT * FROM produkt where emriprod='" + comboBox1.Text + "'";
            MyConn2.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, MyConn2);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                pershkrimiupd.Text = (reader["pershkrimi"].ToString());
                sasiaupd.Text = (reader["sasiaprod"].ToString());
                qmimiupd.Text = (reader["qmimiprod"].ToString());
                zbritjeupd.Text = (reader["zbritje"].ToString());

            }
            MyConn2.Close();
        }
        #endregion
        #region update produkt
        public void updateprodukt()
        {

            try
            {
                string query = "UPDATE produkt  SET emriprod='" + this.comboBox1.Text + "',pershkrimi='" + this.pershkrimiupd.Text + "', sasiaprod ='" + this.sasiaupd.Text + "',qmimiprod ='" + this.qmimiupd.Text + "',zbritje='" + this.zbritjeupd.Text + "' WHERE emriprod ='" + this.comboBox1.Text + "';";

                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Te Dhenat u ruajten");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        #region shto produkt
        public void shtoprodukt()
        {


            //shikon a ekziston useri
            MyConn2.Open();
            string selectQuery = "SELECT emriprod FROM produkt where emriprod='" + emriprod.Text + "'";
            MySqlCommand command = new MySqlCommand(selectQuery, MyConn2);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

            }

            if (reader.HasRows == true)
            {
                MessageBox.Show("Emri = " + emriprod.Text + " Ekzistone ne listen e produkteve", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MyConn2.Close();
                MyConn2.Open();
                //shton userin
                string qr = string.Format(@"insert into produkt(emriprod,pershkrimi,sasiaprod,qmimiprod,zbritje) values('" + emriprod.Text + "','" + pershkrimiprod.Text + "','" + SasiaProd.Text + "','" + qmimiprod.Text + "','" + zbritjeprod.Text + "')");
                MySqlCommand cmd = new MySqlCommand(qr, MyConn2);
                DataTable dt = new DataTable();
                cmd.ExecuteNonQuery();
                MyConn2.Close();
                MessageBox.Show("Produkti u shtua me sukses", "Informate", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        #endregion
        private void produktet_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            shfaqcomboprod();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateprodukt();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(emriprod.Text)|| String.IsNullOrEmpty(SasiaProd.Text) || String.IsNullOrEmpty(qmimiprod.Text))
            {
                MessageBox.Show("Emri Produktit,Sasia dhe Qmimi nuk duhet te jen te zbrazura");
               
            }
            else
            {
                shtoprodukt();
            }

        }

        private void SasiaProd_ValueChanged(object sender, EventArgs e)
        {
            SasiaProd.Minimum = 1;
            SasiaProd.Maximum = 100000;
        }

        private void qmimiprod_ValueChanged(object sender, EventArgs e)
        {
            qmimiprod.Minimum = 1;
            qmimiprod.Maximum = 1000000;
        }

        private void qmimiupd_ValueChanged(object sender, EventArgs e)
        {
            qmimiprod.Minimum = 1;
            qmimiupd.Maximum = 1000000;
        }

        private void sasiaupd_ValueChanged(object sender, EventArgs e)
        {
            sasiaupd.Minimum = 1;
            sasiaupd.Maximum = 1000000;
        }

        private void zbritjeprod_ValueChanged(object sender, EventArgs e)
        {
            zbritjeprod.Minimum = 0;
            zbritjeprod.Maximum = 100;
        }

        private void zbritjeupd_ValueChanged(object sender, EventArgs e)
        {
            zbritjeupd.Minimum = 0;
            zbritjeupd.Maximum = 100;
        }
    }
}
