using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace clinic_system.forms
{
    public partial class patientDocument : Form
    {
        ReportDocument cpr = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();

        ConnectionInfo crConnectionInfo = new ConnectionInfo();

        Tables CrTables;
        //string x;
        SqlConnection con = new SqlConnection();
        DateTime x, y;

        public patientDocument()
        {
            InitializeComponent();
        }
        public patientDocument(DateTime x , DateTime y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
        }

        private void patientDocument_Load(object sender, EventArgs e)
        {
            string str;
            str = Stream.ReadCS();
            con.ConnectionString = str;
        //    con.ConnectionString = @"Data Source=tcp:192.168.11.12,49172;Initial Catalog=clinic;user id=admin;password=242428";

          //  con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True";
            string sql = "SELECT  patient.name as [إسم المريض],doctor.Dname as [إسم الدكتور],check_up.tybe as [نوع الحجز], COUNT( check_up.tybe) as [عدد الحجوزات], CASE WHEN tybe=N'كشف جديد مستعجل'THEN  doctor.Dquick_book_cost*COUNT( check_up.tybe)   WHEN tybe=N'إعاده كشف' THEN doctor.Drebook_cost*COUNT( check_up.tybe) else doctor.Dnew_book_cost*COUNT( check_up.tybe) END AS [تكلفه الحجوزات] FROM            check_up  JOIN doctor ON check_up.Did = doctor.Did  JOIN patient ON check_up.Pid = patient.Pid  where check_up.date  BETWEEN '" + x + "' AND '"+ y +"' group by doctor.Dname , patient.name,check_up.tybe,doctor.Dnew_book_cost,doctor.Dquick_book_cost,doctor.Drebook_cost ";
            DataSet1 ds = new DataSet1();
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);
            dad.Fill(ds.Tables["pDoc"]);
            crystalPatient cpr = new crystalPatient();
          //  report.Load(Application.StartupPath + "Report1.rpt");
            string path;
            path = Application.StartupPath + @"\\crystalPatient.rpt";
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
            cpr.SetDataSource(ds.Tables["pDoc"]);
            crystalReportViewer1.ReportSource = cpr;
            crystalReportViewer1.Refresh();
        }
    }
}
