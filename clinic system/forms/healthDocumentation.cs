using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace clinic_system.forms
{
    public partial class healthDocumentation : Form
    {
        ReportDocument cpr = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();

        ConnectionInfo crConnectionInfo = new ConnectionInfo();

        Tables CrTables;

        SqlConnection con = new SqlConnection();
        DateTime x, y;
        public healthDocumentation()
        {
            InitializeComponent();
        }

        public healthDocumentation(DateTime x, DateTime y)
        {
            InitializeComponent();
            this.x = x;
            this.y = y;
        }

        private void healthDocumentation_Load(object sender, EventArgs e)
        {
            string str;
            str = Stream.ReadCS();
            con.ConnectionString = str;
           // con.ConnectionString = @"Data Source=tcp:192.168.11.12,49172;Initial Catalog=clinic;user id=admin;password=242428";

       //   con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True";
            string sql = "SELECT  patient.name AS [إسم المريض], doctor.Dname AS [إسم الدكتور], check_up.tybe AS [نوع الكشف], check_up.case_mul AS [الحاله المرضيه], treatment.treatment_name AS [العلاج المطلوب] , check_up.nots AS ملاحظات, check_up.date AS [تاريخ الكشف] FROM  check_up   left outer JOIN   [check-up_treatment] ON check_up.Cid = [check-up_treatment].Cid INNER JOIN        doctor ON check_up.Did = doctor.Did right outer JOIN     patient ON check_up.Pid = patient.Pid left outer JOIN treatment ON [check-up_treatment].TTid = treatment.TTid  where check_up.date  BETWEEN '" + x + "' AND '" + y + "'";
            DataSet1 ds = new DataSet1();
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);
            dad.Fill(ds.Tables["hDoc"]);
            CrystalHealthDoc cpr = new CrystalHealthDoc();
            //crystalReportViewer1.ReportSource = cpr;
            //crystalReportViewer1.Refresh();


            string path;
            path = Application.StartupPath + @"\\CrystalHealthDoc.rpt";
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
            cpr.SetDataSource(ds.Tables["hDoc"]);
            crystalReportViewer1.ReportSource = cpr;
            crystalReportViewer1.Refresh();
        }
    }
}
