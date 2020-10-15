using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq.SqlClient;
using System.Data.Linq.Mapping;
namespace clinic_system.userControls
{
    public partial class sec_total_booking_mony : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();
        public sec_total_booking_mony()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sec_total_booking_mony_Load(object sender, EventArgs e)
        {
            var countre = (from ch in clinic.check_ups
                         where ch.tybe == "إعاده كشف" &&  ch.date == DateTime.Now.Date
                         select ch).Count();
            var countnew = (from ch in clinic.check_ups
                            where ch.tybe == "كشف جديد عادي" && ch.date == DateTime.Now.Date
                           select ch).Count();
            var countquick = (from ch in clinic.check_ups
                              where ch.tybe == "كشف جديد مستعجل" && ch.date == DateTime.Now.Date
                           select ch).Count();
            var sumre = (from d in clinic.doctors
                      join ch in clinic.check_ups on d.Did equals ch.Did
                         where ch.tybe == "إعاده كشف" && ch.date == DateTime.Now.Date
                      select new { ch.cost});
            var sumnew = (from d in clinic.doctors
                        join ch in clinic.check_ups on d.Did equals ch.Did
                          where ch.tybe == "كشف جديد عادي" && ch.date == DateTime.Now.Date
                        select new { ch.cost });
            var sumqick = (from d in clinic.doctors
                        join ch in clinic.check_ups on d.Did equals ch.Did
                           where ch.tybe == "كشف جديد مستعجل" && ch.date == DateTime.Now.Date
                        select new { ch.cost });
            var sumtotal = (from d in clinic.doctors
                           join ch in clinic.check_ups on d.Did equals ch.Did
                            where ch.date == DateTime.Now.Date
                           select new { ch.cost });

            label14.Text = countre.ToString();
            label12.Text = countnew.ToString();
            label10.Text = countquick.ToString();
            label15.Text = sumre.Select(c => c.cost).Sum().ToString();
            label13.Text = sumnew.Select(c => c.cost).Sum().ToString();
            label11.Text = sumqick.Select(c => c.cost).Sum().ToString();
            label17.Text = sumtotal.Select(c => c.cost).Sum().ToString();
        
        }
    }
}
