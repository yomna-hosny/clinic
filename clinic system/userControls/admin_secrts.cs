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
namespace clinic_system.userControls
{
    public partial class admin_secrts : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();
        int secId = 0;
        string s = "";
        public admin_secrts()
        {
            InitializeComponent();
            view();
        }


        private void FillRecordNo()
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        } 

        private void button5_Click(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
               view();
            }
            else if (searchBox.Text == "الإسم")
            {
                var secert = from sec in clinic.secretaries
                             join log in clinic.logins on sec.logId equals log.logId
                             where sec.Sname.Contains(searchcontent.Text)
                             let الإسم = sec.Sname
                             let رقم_الهاتف = sec.Sphone_number
                             let من = sec.Swork_from
                             let إلي = sec.Swork_to
                             let تاريخ_العمل = sec.Sdate_of_start_work
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = sec.daysOfWork
                             select new { sec.Sid, الإسم, رقم_الهاتف, من, إلي, تاريخ_العمل, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };

                dataGridView1.DataSource = secert;
            }
           
            else if (searchBox.Text == "رقم الهاتف")
            {
                var secert = from sec in clinic.secretaries
                             join log in clinic.logins on sec.logId equals log.logId
                             where sec.Sphone_number.Contains(searchcontent.Text)
                             let الإسم = sec.Sname
                             let رقم_الهاتف = sec.Sphone_number
                             let من = sec.Swork_from
                             let إلي = sec.Swork_to
                             let تاريخ_العمل = sec.Sdate_of_start_work
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = sec.daysOfWork
                             select new { sec.Sid, الإسم, رقم_الهاتف, من, إلي, تاريخ_العمل, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };

                dataGridView1.DataSource = secert;
            }
            else if (searchBox.Text == "تاريخ التوظيف")
            {
                doctorDate.Visible = true;
                var secert = from sec in clinic.secretaries
                             join log in clinic.logins on sec.logId equals log.logId
                             where sec.Sdate_of_start_work == doctorDate.Value.Date
                             let الإسم = sec.Sname
                             let رقم_الهاتف = sec.Sphone_number
                             let من = sec.Swork_from
                             let إلي = sec.Swork_to
                             let تاريخ_العمل = sec.Sdate_of_start_work
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = sec.daysOfWork
                             select new { sec.Sid, الإسم, رقم_الهاتف, من, إلي, تاريخ_العمل, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };

                dataGridView1.DataSource = secert;
            }
            
        }
        private void view()
        {
            var secert = from sec in clinic.secretaries
                         join log in clinic.logins on sec.logId equals log.logId
                        // select sec;
                         let الإسم = sec.Sname
                         let رقم_الهاتف = sec.Sphone_number
                         let من = sec.Swork_from
                         let إلي = sec.Swork_to
                         let تاريخ_العمل = sec.Sdate_of_start_work
                         let إسم_المستخدم = log.userName
                         let كلمه_المرور = log.password
                         let أيام_العمل = sec.daysOfWork
                         select new { sec.Sid, الإسم, رقم_الهاتف, من, إلي, تاريخ_العمل, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };
            dataGridView1.DataSource = secert;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            searchcontent.Clear();
        }
        private void clearAll()
        {
            DnameText.Clear();
            PhoneText.Clear();
            FromText.Clear();
            ToText.Clear();
            textBox1.Clear();
            textBox2.Clear();
            foreach (int i in TimeTableCheckedList.CheckedIndices)
            {
                TimeTableCheckedList.SetItemCheckState(i, CheckState.Unchecked);
            }
                    }

        private void searchBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (searchBox.Text == "تاريخ التوظيف")
            {
                doctorDate.Visible = true;
            }
            else
                doctorDate.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

          
        }
        private void finshing()
        {
            clinic.SubmitChanges();
            view();
            clearAll();
            MessageBox.Show(" تم إدخال البيانات بنجاح");
        }
        private void addToDataBase(secretary sec, login log)
        {
           sec.Sname = DnameText.Text;
           sec.Sdate_of_start_work = dateTimePicker1.Value.Date;
            sec.Sphone_number = PhoneText.Text;
            sec.Swork_from = FromText.Text;
            sec.Swork_to = ToText.Text;
            sec.logId = log.logId;
            foreach (string x in TimeTableCheckedList.CheckedItems)
            {
                s += "," + x;
            }
            sec.daysOfWork = s;
            s = "";
        }

         private void button4_Click(object sender, EventArgs e)
         {
             clearAll();
         }

         private void dataGridView1_DoubleClick(object sender, EventArgs e)
         {
             
         }

         private void button3_Click(object sender, EventArgs e)
         {
             try
             {
                 button2.Text = "إضافـه";
                secretary sec = clinic.secretaries.Single(s => s.Sid ==int.Parse( dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                 clinic.secretaries.DeleteOnSubmit(sec);

                 login log = clinic.logins.Single(s => s.logId == int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
                 clinic.logins.DeleteOnSubmit(log);
                 clinic.SubmitChanges();
                 view();
                 clearAll();
                 MessageBox.Show(" تم حذف البيانات بنجاح");
             }
             catch
             {
                MessageBox.Show(" أرجو تحديد الموظف المراد حذفه");
             }
         }         
      
         private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
         {
             if (dataGridView1.CurrentRow.Index != -1)
             {
                 secId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                 DnameText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                 PhoneText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                 FromText.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                 ToText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                 dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                 textBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                 textBox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

                             for (int i = 0; i < TimeTableCheckedList.Items.Count; i++)
                                 if (dataGridView1.CurrentRow.Cells[9].Value.ToString().Contains(TimeTableCheckedList.Items[i].ToString()))
                                       {
                                           TimeTableCheckedList.SetItemChecked(i, true);
                                       }
                                 else
                                 {
                                     TimeTableCheckedList.SetItemChecked(i, false);
                                 }    
                                        

                 button2.Text = "تعديل";
             }
         }

         private void button2_Click_1(object sender, EventArgs e)
         {
              try
             {

                 if (button2.Text == "إضافـه")
                 {
                     login log = new login();
                     if (textBox1.Text != "" && textBox2.Text != "" && DnameText.Text != "")
                     {
                         addToLogin(log);
                         clinic.logins.InsertOnSubmit(log);
                         clinic.SubmitChanges();

                         secretary sec = new secretary();
                         addToDataBase(sec, log);
                         clinic.secretaries.InsertOnSubmit(sec);
                         finshing();

                     }
                     else { MessageBox.Show("أرجو مراجعه البيانات المدخله"); }
                 }
                 else
                 {
                     if (textBox1.Text != "" && textBox2.Text != "" && DnameText.Text != "")
                     {
                         login log = clinic.logins.Single(l => l.logId == int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString()));
                         addToLogin(log);
                         clinic.SubmitChanges();
                         secretary sec = clinic.secretaries.Single(d => d.Sid == secId);
                         addToDataBase(sec, log);
                         finshing();
                         button2.Text = "إضافـه";
                     }
                     else { MessageBox.Show("أرجو مراجعه البيانات المدخله"); }
                 }
            }
             catch {
             MessageBox.Show("أرجو مراجعه البيانات المدخله");
             }
         }

         private void addToLogin(login log)
         {
             log.userName = textBox2.Text;
             log.password = textBox1.Text;
             log.type = "سكيرتير";
         }

         private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
         {
             FillRecordNo();
       
         }

         private void down(KeyEventArgs e, TextBox t)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 t.Focus();
             }
         }

         private void DnameText_KeyDown(object sender, KeyEventArgs e)
         {
             down(e, PhoneText);

         }

         private void PhoneText_KeyDown(object sender, KeyEventArgs e)
         {
             down(e, textBox2);

         }

         private void textBox2_KeyDown(object sender, KeyEventArgs e)
         {
             down(e, textBox1);

         }

         private void textBox1_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 dateTimePicker1.Focus();
             }
         }

         private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 TimeTableCheckedList.Focus();
             }
         }

         private void TimeTableCheckedList_KeyDown(object sender, KeyEventArgs e)
         {
             down(e, FromText);

         }

         private void FromText_KeyDown(object sender, KeyEventArgs e)
         {
             down(e, ToText);

         }

         private void ToText_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 button2.PerformClick();
             }
         }

         private void searchcontent_KeyDown(object sender, KeyEventArgs e)
         {
             if (e.KeyCode == Keys.Enter)
             {
                 button5.PerformClick();
             }
         }

      
    }
}
