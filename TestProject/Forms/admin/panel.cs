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
    public partial class panel : Form
    {
        MySqlConnection con = new MySqlConnection(myclass.insert.connect);
        shitjet shitje = new shitjet();
        punetoret puntor = new punetoret();
        tavolinat tv = new tavolinat();
        produktet produkt = new produktet();
        
        public panel()
        {
            InitializeComponent();
            chartgraph();
            timer1.Start();

            shitje.TopLevel = false;
            shitje.Visible = true;
            shitje.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(shitje);
            checkutype();
        }
        private void checkutype()
        {
            if(myclass.global.uType == "manager")
            {
                punetorebtn.Enabled = false;
                produktebtn.Enabled = false;

            }
        }
        #region shfaq totalin e sasive dhe shitjeve ne Panel

        private void chartgraph()
        {
            
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select SUM(totali),SUM(sasiap) from shitjet", con);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               // totali = Convert.ToString(Convert.ToInt32(reader[0]) * Convert.ToInt32(reader[1]));
                Shitjetnr.Text = reader[0].ToString() + " Denar";
                sasianr.Text = reader[1].ToString();
            }
            con.Close();

            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("select SUM(totali) from papaguar", con);
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                // totali = Convert.ToString(Convert.ToInt32(reader[0]) * Convert.ToInt32(reader[1]));
                papaguar.Text = reader1[0].ToString() + " Denar";
            }
            con.Clone();

        }
        #endregion
        private void panel_Load(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void cartesianChart1_ChildChanged_1(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void datestart_ValueChanged(object sender, EventArgs e)
        {
            chartgraph();
        }

        private void dateend_ValueChanged(object sender, EventArgs e)
        {
            chartgraph();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }


        private void shitjebtn_Click(object sender, EventArgs e)
        {
            tv.Visible = false;
            puntor.Visible = false;
            produkt.Visible = false;
            shitje.TopLevel = false;
            shitje.Visible = true;
            shitje.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(shitje);
        }

        private void punetorebtn_Click_1(object sender, EventArgs e)
        {
            tv.Visible = false;
            shitje.Visible = false;
            produkt.Visible = false;
            puntor.TopLevel = false;
            puntor.Visible = true;
            puntor.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(puntor);
        }

        private void tavolinatbtn_Click(object sender, EventArgs e)
        {
            tv.Visible = false;
            shitje.Visible = false;
            puntor.Visible = false;
            produkt.Visible = false;
            tv.TopLevel = false;
            tv.Visible = true;
            tv.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(tv);
        }

        private void produktebtn_Click(object sender, EventArgs e)
        {

            tv.Visible = false;
            shitje.Visible = false;
            puntor.Visible = false;
            tv.Visible = false;
            produkt.TopLevel = false;
            produkt.Visible = true;
            produkt.Dock = DockStyle.Fill;
            this.splitContainer1.Panel2.Controls.Add(produkt);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.label4.Text = datetime.ToString("dddd , dd MMM  yyyy,hh:mm:ss tt", new System.Globalization.CultureInfo("sq-AL")).ToUpper();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startdate_onValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }
    }
}
