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
    public partial class patientDocuments_admin : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();

        public patientDocuments_admin()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadDoctor()
        {
            var d= from tt in clinic.doctors
                    orderby tt.Dname
                    select new { tt.Dname};
            foreach (var i in d)
            {
                comboBox1.Items.Add(i.Dname);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forms.patientDocument pa = new forms.patientDocument(dateTimePicker1.Value.Date,dateTimePicker2.Value.Date);
            pa.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            forms.patientDocumentByName pn = new forms.patientDocumentByName(textBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            pn.Show();
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            forms.patientDocumentByDoctor pd = new forms.patientDocumentByDoctor(comboBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            pd.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                button3.PerformClick();
            }
        }

        private void patientDocuments_admin_Load(object sender, EventArgs e)
        {
            loadDoctor();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
