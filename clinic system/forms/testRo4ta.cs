using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace clinic_system.forms
{
    public partial class testRo4ta : Form
    {
        ReportDocument cpr = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();

        ConnectionInfo crConnectionInfo = new ConnectionInfo();

        Tables CrTables;
        string x="";
        SqlConnection con = new SqlConnection();
        public testRo4ta()
        {
            InitializeComponent();
        }
        public testRo4ta(string x)
        {
            InitializeComponent();
            this.x = x;
        }
        private void testRo4ta_Load(object sender, EventArgs e)
        {
            string str;
            str = Stream.ReadCS();
            con.ConnectionString = str;
            //con.ConnectionString = @"Data Source=tcp:192.168.11.12,49172;Initial Catalog=clinic;user id=admin;password=242428";

           // con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True";
            string sql = string.Concat(" SELECT  patient.name AS [إسم المريض], doctor.Dname AS [إسم الدكتور], check_up.date AS [تاريخ الكشف], check_up.age AS السن, check_up.weight AS الوزن, check_up.case_mul AS [الحاله المرضيه], treatment.treatment_name AS [إسم العلاج],   [check-up_treatment].dose AS الجرعه, [check-up_treatment].duration AS التكرار , check_up.nots AS   ملاحظات   from check_up,patient,doctor,treatment,[check-up_treatment] where  patient.Pid=check_up.Pid and doctor.Did=check_up.Did and treatment.TTid=[check-up_treatment].TTid and check_up.Cid=[check-up_treatment].Cid and check_up.Cid=", x);
            //   string sql = "  SELECT  patient.name AS [إسم المريض], doctor.Dname AS [إسم الدكتور], check_up.date AS [تاريخ الكشف], check_up.age AS السن, check_up.weight AS الوزن, check_up.case_mul AS [الحاله المرضيه], treatment.treatment_name AS [إسم العلاج],   [check-up_treatment].dose AS الجرعه, [check-up_treatment].duration AS التكرار,     check_up.nots AS   ملاحظات  FROM   check_up INNER JOIN       [check-up_lx] ON check_up.Cid = [check-up_lx].Cid INNER JOIN              [check-up_treatment] ON check_up.Cid = [check-up_treatment].Cid INNER JOIN                         doctor ON check_up.Did = doctor.Did INNER JOIN                         organization ON [check-up_lx].Oid = organization.Oid INNER JOIN                         patient ON check_up.Pid = patient.Pid INNER JOIN                         rays_labs ON organization.OOid = rays_labs.OOid AND organization.OOid = rays_labs.OOid INNER JOIN        treatment ON [check-up_treatment].TTid = treatment.TTid where check_up.Cid="+x;
            DataSet1 ds = new DataSet1();
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);
            dad.Fill(ds.Tables["ro4ta2"]);
            CrystalRo4ta1 cr = new CrystalRo4ta1();
            string path;
            path = Application.StartupPath + @"\\CrystalRo4ta1.rpt";
            cpr.Load(path);

            crConnectionInfo.ServerName = Stream.ReadIP();

            crConnectionInfo.DatabaseName = "Clinic";

            crConnectionInfo.UserID = "admin";

            crConnectionInfo.Password = "242428";

            // Here 
            CrTables = cpr.Database.Tables;

            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {

                crtableLogoninfo = CrTable.LogOnInfo;

                crtableLogoninfo.ConnectionInfo = crConnectionInfo;

                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            cr.SetDataSource(ds.Tables["ro4ta2"]);
            crystalReportViewer2.ReportSource = cr;
            crystalReportViewer2.Refresh();
        }
    }
}
