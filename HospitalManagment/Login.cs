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
    public partial class Login : Form
    {
       
        public Login()
        {
            
            InitializeComponent();
        }
       // string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Misha\Documents\Visual Studio 2015\Projects\HospitalManagment\HospitalManagment\Login.mdf;Integrated Security=True;";
        SqlConnection con = new SqlConnection(@"Server = KHALID;Database=Hospital;Integrated Security = true");

       
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Server = KHALID;Database=Hospital;Integrated Security = true");
         
            if (user_txt.Text == "" || pass_txt.Text == "")
            {
                MessageBox.Show("Please Provide User name and Password");
                return;
            }

            try
            {
               // SqlConnection con = new SqlConnection(cs);

                SqlCommand cmd = new SqlCommand("select * from Login where USERNAME = '" + user_txt.Text + "' and PASSWORD = '" + pass_txt.Text + "'", con);
                cmd.Parameters.AddWithValue("@userid", user_txt.Text);
                cmd.Parameters.AddWithValue("@password", pass_txt.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
               
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                if (count == 1)
                {
                    MessageBox.Show("Successfully LogIn");
                    this.Hide();
                    Main_Menu mn = new Main_Menu();
                    mn.Show();

                }

                
                else
                {
                    MessageBox.Show("Login Failed !! ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

    }

}

