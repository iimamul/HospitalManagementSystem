using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalManagment
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor dr = new Doctor  ();
           dr.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient Pt = new Patient();
            Pt.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MedicineInfo Mi = new MedicineInfo();
            Mi.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bill_Info bill = new Bill_Info();
            bill.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reciption_info reciptn = new Reciption_info();
           reciptn.ShowDialog();
        }
    }
}
