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
    public partial class linqModifyDoctor : Form
    {
        clinicDataContext clinic = new clinicDataContext();

        public linqModifyDoctor()
        {
            InitializeComponent();
        }

        private void linqModifyDoctor_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var doctor = from doc in clinic.doctors
                         select new { doc.Dname, doc.Dspecialization, doc.Dwork_from, doc.Dwork_to, doc.Ddate_of_start_work ,doc.Dnew_book_cost ,doc.Dquick_book_cost,doc.Drebook_cost};
            dataGridView1.DataSource=doctor;
        }
    }
}
