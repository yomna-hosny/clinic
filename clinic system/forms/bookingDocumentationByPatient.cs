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
    public partial class bookingDocumentationByPatient : Form
    {
        ReportDocument cpr = new ReportDocument();
        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();

        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();

        ConnectionInfo crConnectionInfo = new ConnectionInfo();

        Tables CrTables;

        string x;
        SqlConnection con = new SqlConnection();
        DateTime xx, y;
        public bookingDocumentationByPatient()
        {
            InitializeComponent();
        }
        public bookingDocumentationByPatient(string x, DateTime xx, DateTime y)
        {
            InitializeComponent();
            this.x = x;
            this.xx = xx;
            this.y = y;
        }
        private void bookingDocumentationByPatient_Load(object sender, EventArgs e)
        {
            string str;
            str = Stream.ReadCS();
            con.ConnectionString = str;
           //  con.ConnectionString = @"Data Source=192.168.11.12,49172;Initial Catalog=clinic;user id=admin;password=242428";

          // con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True";
     //       string sql = "SELECT   patient.name AS [إسم المريض], doctor.Dname AS [إسم الدكتور], check_up.date AS [تاريخ الحجز], check_up.tybe AS [نوع الحجز], check_up.start_from AS [يبدأ من], check_up.end_to AS [ينتهي في], organization.org_name AS [إسم المؤسسه],  organization.tybe AS [نوع المؤسسه], rays_labs.org_lx_name AS [إسم الإجراء المطلوب], CASE WHEN check_up.tybe =N'كشف جديد مستعجل'THEN  doctor.Dquick_book_cost*COUNT( check_up.tybe) WHEN check_up.tybe=N'إعاده كشف' THEN doctor.Drebook_cost*COUNT( check_up.tybe)	else doctor.Dnew_book_cost*COUNT( check_up.tybe) END AS [تكلفه الحجوزات] FROM            check_up INNER JOIN [check-up_lx] ON check_up.Cid = [check-up_lx].Cid INNER JOIN    doctor ON check_up.Did = doctor.Did INNER JOIN    patient ON check_up.Pid = patient.Pid INNER JOIN    organization ON [check-up_lx].Oid = organization.Oid INNER JOIN  rays_labs ON [check-up_lx].OOid = rays_labs.OOid where patient.name like N'" + x + "'AND check_up.date  BETWEEN N'" + xx + "' AND N'" + y + "'  group by doctor.Dname , patient.name,check_up.tybe,doctor.Dnew_book_cost,doctor.Dquick_book_cost,doctor.Drebook_cost,check_up.date,check_up.start_from,check_up.end_to,organization.org_name,organization.tybe,rays_labs.org_lx_name";
             string sql = "SELECT   patient.name AS [إسم المريض], doctor.Dname AS [إسم الدكتور], check_up.date AS [تاريخ الحجز], check_up.tybe AS [نوع الحجز], check_up.start_from AS [يبدأ من], check_up.end_to AS [ينتهي في], CASE WHEN check_up.tybe =N'كشف جديد مستعجل'THEN  doctor.Dquick_book_cost*COUNT( check_up.tybe) WHEN check_up.tybe=N'إعاده كشف' THEN doctor.Drebook_cost*COUNT( check_up.tybe)	else doctor.Dnew_book_cost*COUNT( check_up.tybe) END AS [تكلفه الحجوزات] FROM            check_up  INNER JOIN    doctor ON check_up.Did = doctor.Did INNER JOIN    patient ON check_up.Pid = patient.Pid  where patient.name like N'" + x + "'AND check_up.date  BETWEEN N'" + xx + "' AND N'" + y + "'  group by doctor.Dname , patient.name,check_up.tybe,doctor.Dnew_book_cost,doctor.Dquick_book_cost,doctor.Drebook_cost,check_up.date,check_up.start_from,check_up.end_to";

            DataSet1 ds = new DataSet1();
            SqlDataAdapter dad = new SqlDataAdapter(sql, con);
            dad.Fill(ds.Tables["bDoc"]);
            CrystalBookingByPatient cpr = new CrystalBookingByPatient();

            string path;
            path = Application.StartupPath + @"\\bookingDocumentationByPatient.rpt";
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
            cpr.SetDataSource(ds.Tables["bDoc"]);
            crystalReportViewer1.ReportSource = cpr;
            crystalReportViewer1.Refresh();
        }
    }
}
