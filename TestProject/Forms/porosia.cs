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
    public partial class porosia : Form
    {
        MySqlConnection cons = new MySqlConnection(insert.connect);
        public string totali;
        public porosia()
        {
            InitializeComponent();
            menubutton();
            binddata();
            calc();
        }
        #region kalkulimi i tavolinave
        void calc()
        {
            double cal = 00.00;
            if (dataGridView1.Rows.Count <= 0)
            {
                totallbl.Text = "Totali: 00.00 Denar";

            }
            else
            {
               
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    try
                    {
                        cal = cal + double.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()) * double.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());

                    }
                    catch { }
                    totallbl.Text = "Totali: " + cal.ToString("00.00") + " Denar";
                }
            }
        }
        #endregion
     
        #region lidhja db me dtg
        private void binddata() {
            DataTable dt = new DataTable();
          
            using (MySqlConnection cons = new MySqlConnection(insert.connect))
            {
                MySqlCommand cmd = new MySqlCommand(@"select id,emrip,sasiap,tavolina,punetori,qmimip,datap,totali from papaguar where tavolina='" + myclass.global.tableid+"'", cons);
                cons.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                if (dt.Rows.Count > 0)
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    ds.Tables.Add(dt);
                  
                    dataGridView1.DataSource = dt;
                    
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Columns[0].HeaderText = "";
                    dataGridView1.Columns[1].HeaderText = "ID";
                    dataGridView1.Columns[2].HeaderText = "Emri";
                    dataGridView1.Columns[3].HeaderText = "Sasia";
                    dataGridView1.Columns[4].HeaderText = "Tavolina";
                    dataGridView1.Columns[5].HeaderText = "Punetori";
                    dataGridView1.Columns[6].HeaderText = "Qmimi";
                    dataGridView1.Columns[7].HeaderText = "Data";
                    dataGridView1.Columns[8].HeaderText = "Totali";
                }
                    cons.Close();
            }
          
        }
        #endregion
          
        #region buttoni i produkteve
        private void menubutton()
        {
            cons.Open();
            string query = string.Format("SELECT * FROM produkt");
            MySqlCommand cmd = new MySqlCommand(query);
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, cons);
            adapter.Fill(dt);

            ds.Tables.Add(dt);
            cons.Close();
            int top = 100;
            int left = 0;
            int X = 50;
            int Y = 10;
            foreach (DataRow dr in dt.Rows)
            {
                
                NumericUpDown sasia = new NumericUpDown();

               
                //sasia.Dock = System.Windows.Forms.DockStyle.Bottom;
                sasia.Anchor = System.Windows.Forms.AnchorStyles.Left;
                sasia.Anchor = System.Windows.Forms.AnchorStyles.Left;
                
                // Shto max/min ne sasi
                sasia.Value = 1;
                sasia.Maximum = 100;
                sasia.Minimum = 1;
                
                sasia.BackColor = Color.White;

                //SHTO BUTTON PER TE GJITHA PRODUKTET
                Button button = new Button();
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.Yellow;
                button.Text = "\n" + dr[1].ToString();
                button.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
                button.Size = new Size(120, 80);
                button.Location = new Point(X, Y);
                button.Left += left;
                button.Top += top;
                flowLayoutPanel1.Controls.Add(button);
                button.Controls.Add(sasia);
                top += button.Height + 2;
                button.Click += (sender, args) =>
                {
                
                            // qmimi i produktit ne button
                            string qmimi = dr[4].ToString();
                            totali = Convert.ToString(Convert.ToInt32(qmimi) * sasia.Value);
                            //data aktuale
                            DateTime now = DateTime.Now;

                            #region ruajtja ne databaze
                            try
                            {

                                string Query = "INSERT INTO papaguar(emrip,sasiap,qmimip,datap,tavolina,punetori,totali) values('" + dr[1].ToString() + "','" + sasia.Text + "','" + qmimi.ToString() + "','" + now.ToShortDateString() + "','" + global.tableid + "','" + global.username + "','" + totali.ToString() + "');";

                                MySqlCommand MyCommand2 = new MySqlCommand(Query, cons);
                                MySqlDataReader MyReader2;
                                cons.Open();
                                MyReader2 = MyCommand2.ExecuteReader();
                                while (MyReader2.Read())
                                {

                                }
                                cons.Close();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                            #endregion

                            binddata();
                            calc();
                
                };
                
            }
        }
        #endregion
       
        private void porosia_Load(object sender, EventArgs e)
        {
            //lexon emrin e tabeles dhe emrin e perdoruesit
            tavolinabtn.Text = "Tavolina: " + global.tableid;
            userbtn.Text = "Punetori: " + global.username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            #region buttoni fshije ne dtg
            //buttoni fshije ne datagrid
            if (dataGridView1.Columns[e.ColumnIndex].Name == "delete")
            {

                try
                {
                   

                    //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    //{
                    string Query = "delete from papaguar where id='" + this.dataGridView1.Rows[e.RowIndex].Cells[1].Value + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, cons);
                    MySqlDataReader MyReader2;
                    cons.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                    }
                    cons.Close();

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                   
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                calc();
            }
            #endregion
           

        }

        private void insertBindingSource_CurrentChanged(object sender, EventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
           
        }

        private void porosia_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {

             
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
                {


                    string Query = "delete from papaguar where id='" + this.dataGridView1.Rows[i].Cells[1].Value + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, cons);
                    MySqlDataReader MyReader2;
                    cons.Open();
                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                    }
                    cons.Close();

                    dataGridView1.Rows.RemoveAt(i);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            calc();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tavolina tav = new tavolina();
            tav.Show();
            this.Close();
        }
    }
}
