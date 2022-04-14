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
    public partial class punetoret : Form
    {
        public punetoret()
        {
            InitializeComponent();
            shfaquserat();
            radioButton2.Checked = true;
        }
        #region shfaq userat
        public void shfaquserat()
        {
            MySqlConnection connection = new MySqlConnection(myclass.insert.connect);

            string selectQuery = "SELECT emri FROM user";
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("emri"));
            }
            connection.Close();
        }
        #endregion
        //
        #region shfaq te dhenat e userit qe ekziston nga combobox
        public void shfaqcombouser()
        {
            MySqlConnection connection = new MySqlConnection(myclass.insert.connect);

            string selectQuery = "SELECT * FROM user where emri='" + comboBox1.Text + "'";
            connection.Open();
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                emriTxt.Text = (reader["emri"].ToString());
                UserTxt.Text = (reader["username"].ToString());
                TelTxt.Text = (reader["tel"].ToString());
                ShtetiTxt.Text = (reader["shteti"].ToString());
                QytetiTxt.Text = (reader["qyteti"].ToString());
                utype.Text = (reader["utype"].ToString());
            }
            connection.Close();
        }
        #endregion 
        //
        #region update user
        public void updateuser()
        {
          
            try
            {
                string query = "UPDATE user  SET emri='" + this.emriTxt.Text + "',username='" + this.UserTxt.Text + "', password ='" + this.PassTxt.Text + "',tel ='" + this.TelTxt.Text + "', shteti ='" + this.ShtetiTxt.Text + "',qyteti ='" + this.QytetiTxt.Text + "',utype ='" + this.utype.Text + "' WHERE emri ='" + this.comboBox1.Text + "';";
                //This is  MySqlConnection here i have created the object and pass my connection string.  
                MySqlConnection MyConn2 = new MySqlConnection(myclass.insert.connect);
                MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();//Connection closed here  
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        #endregion
        //
        #region shto punetor
        public void shtopunetor()
        {

                MySqlConnection conn = new MySqlConnection(myclass.insert.connect);
                //shikon a ekziston useri

                string selectQuery = "SELECT emri,username FROM user where emri='" + emriTxt.Text + "' OR username='" + UserTxt.Text + "'";
                conn.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                 
                while (reader.Read())
                {
                   
                }
                    
                    if (reader.HasRows == true)
                    {
                         MessageBox.Show("Emri = " + emriTxt.Text + " ose Username = " + UserTxt.Text + " Ekzistojne ne listen e punetorve","Gabim",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        //shton userin
                        string qr = string.Format(@"insert into user(emri,username,password,tel,shteti,qyteti,utype) values('" + emriTxt.Text + "','" + UserTxt.Text + "','" + PassTxt.Text + "','" + TelTxt.Text + "','" + ShtetiTxt.Text + "','" + QytetiTxt.Text + "','" + utype.Text + "')");
                        MySqlCommand cmd = new MySqlCommand(qr, conn);
                        DataTable dt = new DataTable();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Punetori u shtua me sukses", "Informate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
        }
        #endregion
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            shfaqcombouser();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(PassTxt.Text))
            {
                MessageBox.Show("Fjalkalimi eshte i zbrazur");
                PassTxt.Focus();
            }
            else if(PassTxt.Text.Length < 4)
            {
                MessageBox.Show("Passwordi duhet te jete me i gjate se 4 shkronja");
                PassTxt.Focus();
            }
            else
            {
                updateuser();
            }
        }

        private void punetoret_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            shtopunetor();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.button2.Enabled = false;
                button2.BackColor = Color.Red;
                UserTxt.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                button2.BackColor = Color.Gold;
                UserTxt.Enabled = true;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
           
            if (radioButton2.Checked)
            {
                this.button1.Enabled = false;
                this.button3.Visible = false;
                comboBox1.Enabled = false;
                button1.BackColor = Color.Red;
                emriTxt.Text = UserTxt.Text = PassTxt.Text = ShtetiTxt.Text = QytetiTxt.Text = utype.Text = TelTxt.Text = "";
            }
            else
            {
                this.button1.Enabled = true;
                comboBox1.Enabled = true;
                this.button3.Visible = true;
                button1.BackColor = Color.Gold;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
               
                string Query = "delete from user where username='" + this.UserTxt.Text+ "';";
                MySqlConnection MyConn2 = new MySqlConnection(myclass.insert.connect);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Punetori u fshi");
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

        private void PassTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
