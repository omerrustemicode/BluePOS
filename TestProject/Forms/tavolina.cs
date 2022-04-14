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
namespace TestProject.Forms
{
    public partial class tavolina : Form
    {
        MySqlConnection conn = new MySqlConnection(insert.connect);
        public tavolina()
        {
            InitializeComponent();
            addtable();
        }
        #region addtable

        public void addtable()
        {
           
           
            conn.Open();

            string query = string.Format("SELECT * from tavolina");

            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dt);

            ds.Tables.Add(dt);

            int top = 200;
            int left = 0;
            int X = 50;
            int Y = 10;
            foreach (DataRow dr in dt.Rows)
            {
                Button button = new Button();
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.Gold;
                button.Text = dr[1].ToString();
                button.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
                button.Size = new Size(170, 85);
                button.Location = new Point(X, Y);
                button.Left += left;
                button.Top += top;
                flowLayoutPanel1.Controls.Add(button);
                top += button.Height + 2;
                button.Click += (sender, args) =>
                {
                    global.tableid = Convert.ToInt32(dr[1].ToString());
                    porosia ps = new porosia();
                   
                    ps.Show();
                    this.Close();

                };
                conn.Close();
                conn.Open();
                #region ndrysho ngjyren nese eshte e zene

                string selectQuery = "SELECT * FROM papaguar where tavolina='" + dr[1].ToString() + "'";
                
                MySqlCommand command = new MySqlCommand(selectQuery, conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    button.BackColor = Color.Red;
                }
                else
                {
                    button.BackColor = Color.Gold;
                }
                #endregion
            }
          
        }

        #endregion
       
        private void tavolina_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            addtable();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
