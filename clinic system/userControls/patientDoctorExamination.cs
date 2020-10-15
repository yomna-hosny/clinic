using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace clinic_system.userControls
{
    public partial class patientDoctorExamination : UserControl
    {
        SqlConnection con = new SqlConnection();
        public patientDoctorExamination()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void patientDoctorExamination_Load(object sender, EventArgs e)
        {
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            forms.healthDocumentation hd = new forms.healthDocumentation();
            hd.Show();
        }
    }
}
