using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace clinic_system.userControls
{
    public partial class bookingDocumentsSec : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();

        public bookingDocumentsSec()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forms.bookingDocumentaion ba = new forms.bookingDocumentaion(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            ba.Show();
        }

        private void loadDoctor()
        {
            var d = from tt in clinic.doctors
                    orderby tt.Dname
                    select new { tt.Dname };
            foreach (var i in d)
            {
                comboBox1.Items.Add(i.Dname);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

            forms.bookingDocumentationByDoctor ba = new forms.bookingDocumentationByDoctor(comboBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            ba.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            forms.bookingDocumentationByPatient ba = new forms.bookingDocumentationByPatient(textBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            ba.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }

       

        private void bookingDocumentsSec_Load(object sender, EventArgs e)
        {
            loadDoctor();
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }
    }
}
