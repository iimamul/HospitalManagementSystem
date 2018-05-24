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

    public partial class Bill_Info : Form
    {

        SqlConnection con = new SqlConnection(@"Server = KHALID;Database=Hospital;Integrated Security = true");

       
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Bill_Info()
        {
            InitializeComponent();
        }
        private void Bill_load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            loadlist();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "") ;
            {
                con.Open();
                cmd.CommandText = "insert into Bill (Bill_no,Amount,PId) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Record Entered!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                loadlist();
            }


        }
        private void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
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

                }
            }
            con.Close();


        }
        private void Bill_Info_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu mn = new Main_Menu();
            mn.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Misha\Documents\Visual Studio 2015\Projects\HospitalManagment\HospitalManagment\Bill.mdf;Integrated Security=True");
            con.Open();

            cmd = new SqlCommand("update Bill set Amount=@ textBox2.Text, PId=@textBox3.Text where Bill_no=@textBox1.Text", con);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C: \Users\Misha\Documents\Visual Studio 2015\Projects\HospitalManagment\HospitalManagment\Bill.mdf;Integrated Security=True");


            con.Open();

            cmd = new SqlCommand(" Delete from Doctor where Bill_no=@textBox1.Text", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
