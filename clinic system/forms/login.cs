using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    

       

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (clinic_system.forms.homeadm a_h = new clinic_system.forms.homeadm())
            {
                a_h.ShowDialog();
            }

           /* using (clinic_system.linqModifyDoctor d_r = new clinic_system.linqModifyDoctor())
            {
                d_r.ShowDialog();
            }*/
        }
    }
}
