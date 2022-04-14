using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestProject.Forms;
using TestProject.myclass;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace TestProject
{
    public partial class Form1 : Form
    {
        //Konektimi ne DATABAZE
        //static string mconn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        //
        string UserRole;
        public Form1()
        {
            InitializeComponent();
            selectuser();
            timer1.Start();
        }

        #region selektouserin
    public void selectuser()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(insert.connect);

                string selectQuery = "SELECT username FROM user";
                connection.Open();
                MySqlCommand command = new MySqlCommand(selectQuery, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   comboBox1.Items.Add(reader.GetString("username"));
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

        #region loginuser
        public void loginuser()
        {
            int i = 0;
            
            MySqlConnection connection = new MySqlConnection(insert.connect);
            connection.Open();
            string selectQuery = "SELECT * FROM user where username='"+comboBox1.Text+"' and password='"+txtPassword.Text+"';";
            MySqlCommand command = new MySqlCommand(selectQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
           
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            DataTable dt = new DataTable();
            connection.Close();

            da.Fill(dt);

            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (dt.Rows.Count == 1)
            {
                UserRole = dt.Rows[0][7].ToString().Trim();
                if (UserRole == "admin")
                {
                    global.userid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    global.username = dt.Rows[0]["username"].ToString();
                    global.uType = dt.Rows[0]["utype"].ToString();
                    this.Hide();
                    Forms.admin.panel adminpanel = new Forms.admin.panel();
                    adminpanel.Show();


                }
                else
                {
                    global.userid = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    global.username = dt.Rows[0]["username"].ToString();
                    global.uType = dt.Rows[0]["utype"].ToString();

                    this.Hide();
                    tavolina tv = new tavolina();
                    tv.Show();

                }

            }
            else
            {
             
                MessageBox.Show("Fjalkalimi Gabim!", "Gabim", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Items.Clear();
                txtPassword.Text = "";
                selectuser();

            }
           
        }
        #endregion
        private void button13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkHide_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHide.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void button11_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
 
        }

        private void button14_Click(object sender, EventArgs e)
        {
            database db = new database();
          
            db.Show();
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtPassword.Text += "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label4.Text = datetime.ToString("dddd , dd MMM yyyy,hh:mm:ss tt", new System.Globalization.CultureInfo("sq-AL")).ToUpper();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                loginuser();
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            loginuser();
        }
    }
}
