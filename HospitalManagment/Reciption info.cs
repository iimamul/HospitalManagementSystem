using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HospitalManagment
{
    public partial class Reciption_info : Form
    {
        SqlConnection con = new SqlConnection(@"Server = KHALID;Database=Hospital;Integrated Security = true");

        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Reciption_info()
        {
            InitializeComponent();
        }
        private void Reciption_load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            loadlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "") ;
            {
                con.Open();
                cmd.CommandText = "insert into Reciption (Hscode,Hsname,StreetNo,City,website,PId) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "',')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Record Entered!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                loadlist();
            }

        }

        private void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            con.Open();
            cmd.CommandText = "select *from Login";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[0].ToString());
                    listBox3.Items.Add(dr[0].ToString());
                    listBox4.Items.Add(dr[0].ToString());
                    listBox5.Items.Add(dr[0].ToString());

                }
            }
            con.Close();


        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu mn = new Main_Menu();
            mn.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Misha\Documents\Visual Studio 2015\Projects\HospitalManagment\HospitalManagment\Reciption.md;Integrated Security=True");


            con.Open();

            cmd = new SqlCommand(" Delete from Reciption where Hscode=@textBox1.Text", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Misha\Documents\Visual Studio 2015\Projects\HospitalManagment\HospitalManagment\Reciption.md;Integrated Security=True");
            con.Open();

            cmd = new SqlCommand("update Doctor set Hsname=@ textBox2.Text, StreetNo=@textBox3.Text,city=@ textBox4.Text ,website=@ textBox5.Text ,PId=@ textBox5.Textwhere DrId=@textBox1.Text", con);

            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
