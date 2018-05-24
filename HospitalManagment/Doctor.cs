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
    public partial class Doctor : Form
    {

        SqlConnection con = new SqlConnection(@"Server = DESKTOP-PHOL1QQ;Database=Hospital;Integrated Security = true");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public Doctor()
        {
            InitializeComponent();
        }
        private void Doctor_load(object sender, EventArgs e)
        {
            cmd.Connection = con;
            loadlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & textBox5.Text != "") ;
                {
                    SqlConnection con = new SqlConnection(@"Server = DESKTOP-PHOL1QQ;Database=Hospital;Integrated Security = true");
      
                    con.Open();
                    string qury =  "insert into Doctor values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + textBox5.Text + "')";
                     SqlCommand cmd = new SqlCommand(qury,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
             
                    MessageBox.Show("Record Entered!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                //    loadlist();

                }
           
        }

        private void loadlist()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
              SqlConnection con = new SqlConnection(@"Server = DESKTOP-PHOL1QQ;Database=Hospital;Integrated Security = true");
      
            con.Open();
            cmd.CommandText = "select *from Doctor";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[1].ToString());
                    listBox3.Items.Add(dr[2].ToString());
                    listBox4.Items.Add(dr[3].ToString());
                    listBox5.Items.Add(dr[4].ToString());

                }
            }
            con.Close();


        }

        private void Doctor_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Server = DESKTOP-PHOL1QQ;Database=Hospital;Integrated Security = true");
            con.Open();
           // int phn = Convert.ToInt32(textBox4.Text);
            SqlCommand cmd = new SqlCommand("update Doctor set Drname= '" + textBox2.Text + "', Designation= '" + textBox3.Text + "', Ph_No= " + textBox4.Text + " ,Email='" + textBox5.Text + "' where DrId="+textBox1.Text+" ", con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = KHALID;Database=Hospital;Integrated Security = true");
    

            con.Open();

            SqlCommand cmd = new SqlCommand(" Delete from Doctor where DrId= "+textBox1.Text+" ", con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu mn = new Main_Menu();
            mn.ShowDialog();
        }
    }
}
