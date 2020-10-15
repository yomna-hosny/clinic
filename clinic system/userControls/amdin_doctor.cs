﻿using System;
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
    public partial class amdin_doctor : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();
        int docId = 0;
        string s="";
        public amdin_doctor()
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
           
            if (searchBox.Text =="")
            {
                view();
            }
            else if(searchBox.Text =="الإسم")
            {
                var doctor = from doc in clinic.doctors
                             join log in clinic.logins on doc.logId equals log.logId
                             where doc.Dname.Contains (searchcontent.Text)
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 
                dataGridView1.DataSource = doctor; 
            }
            else if (searchBox.Text == "التخصص")
            {
                var doctor = from doc in clinic.doctors
                             join log in clinic.logins on doc.logId equals log.logId
                             where doc.Dspecialization.Contains(searchcontent.Text)
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 

                dataGridView1.DataSource = doctor; 
            }
            else if (searchBox.Text == "رقم الهاتف")
            {
                var doctor = from doc in clinic.doctors
                             join log in clinic.logins on doc.logId equals log.logId
                             where doc.Dphone_number.Contains(searchcontent.Text)
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 

                dataGridView1.DataSource = doctor; 
            }
            else if (searchBox.Text == "تاريخ التوظيف")
            {
                doctorDate.Visible = true;
                var doctor = from doc in clinic.doctors
                             where doc.Ddate_of_start_work == doctorDate.Value.Date
                             join log in clinic.logins on doc.logId equals log.logId
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 

                dataGridView1.DataSource = doctor; 
            }
            else if (searchBox.Text == "تكلفه كشف جديد عادي")
            {
                try
                {
                    var doctor = from doc in clinic.doctors
                                 join log in clinic.logins on doc.logId equals log.logId
                                 where doc.Dnew_book_cost == int.Parse(searchcontent.Text)
                                 let الإسم = doc.Dname
                                 let التخصص = doc.Dspecialization
                                 let من = doc.Dwork_from
                                 let إلي = doc.Dwork_to
                                 let تاريخ_العمل = doc.Ddate_of_start_work
                                 let تكلفه_كشف_جديد = doc.Dnew_book_cost
                                 let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                                 let تكلفه_إعاده_الكشف = doc.Drebook_cost
                                 let رقم_الهاتف = doc.Dphone_number
                                 let إسم_المستخدم = log.userName
                                 let كلمه_المرور = log.password
                                 let أيام_العمل = doc.daysOfWork
                                 select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };

                    dataGridView1.DataSource = doctor;
                }
                catch { }
            }
            else if (searchBox.Text == "تكلفه كشف جديد مستعجل")
            { try
                {
                var doctor = from doc in clinic.doctors
                             join log in clinic.logins on doc.logId equals log.logId
                             where doc.Dquick_book_cost == int.Parse(searchcontent.Text)
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 

                dataGridView1.DataSource = doctor;
                }
            catch { }
            }
            else if (searchBox.Text == "تكلفه إعاده كشف")
            {
                try
                {
                var doctor = from doc in clinic.doctors
                             join log in clinic.logins on doc.logId equals log.logId
                             where doc.Drebook_cost == int.Parse(searchcontent.Text)
                             let الإسم = doc.Dname
                             let التخصص = doc.Dspecialization
                             let من = doc.Dwork_from
                             let إلي = doc.Dwork_to
                             let تاريخ_العمل = doc.Ddate_of_start_work
                             let تكلفه_كشف_جديد = doc.Dnew_book_cost
                             let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                             let تكلفه_إعاده_الكشف = doc.Drebook_cost
                             let رقم_الهاتف = doc.Dphone_number
                             let إسم_المستخدم = log.userName
                             let كلمه_المرور = log.password
                             let أيام_العمل = doc.daysOfWork
                             select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل };

                dataGridView1.DataSource = doctor;
                }
                catch { }
            }
        }

        private void view()
        {
            var doctor = from doc in clinic.doctors
                         join log in clinic.logins on doc.logId equals log.logId
                         // select doc;
                         let الإسم = doc.Dname
                         let التخصص = doc.Dspecialization
                         let من = doc.Dwork_from
                         let إلي = doc.Dwork_to
                         let تاريخ_العمل = doc.Ddate_of_start_work
                         let تكلفه_كشف_جديد = doc.Dnew_book_cost
                         let تكلفه_كشف_جديد_مستعجل = doc.Dquick_book_cost
                         let تكلفه_إعاده_الكشف = doc.Drebook_cost
                         let رقم_الهاتف = doc.Dphone_number
                         let إسم_المستخدم = log.userName
                         let كلمه_المرور = log.password
                         let أيام_العمل = doc.daysOfWork
                         select new { doc.Did, الإسم, التخصص, من, إلي, تاريخ_العمل, تكلفه_كشف_جديد, تكلفه_كشف_جديد_مستعجل, تكلفه_إعاده_الكشف, رقم_الهاتف, log.logId, إسم_المستخدم, كلمه_المرور, أيام_العمل }; 
           dataGridView1.DataSource = doctor;
           dataGridView1.Columns[0].Visible = false;
           dataGridView1.Columns[10].Visible = false;
           dataGridView1.Columns[12].Visible = false;

           searchcontent.Clear();
        }

        private void clearAll()
        {
            DnameText.Clear();
            NewCheckUpText.Clear();
            QuiqeCheckUpText.Clear();
            ReCheckUpText.Clear();
            PhoneText.Clear();
            SpecializationText.Clear();
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

                    doctor doc = new doctor();
                    addToDataBase(doc, log);
                    clinic.doctors.InsertOnSubmit(doc);
                    finshing();
                }
                else { MessageBox.Show("أرجو مراجعه البيانات المدخله"); }
                }
                else
                {
                    if (textBox1.Text != "" && textBox2.Text != "" && DnameText.Text != "")
                    {
                        login log = clinic.logins.Single(l => l.logId == int.Parse(dataGridView1.CurrentRow.Cells[10].Value.ToString()));
                        addToLogin(log);
                        clinic.SubmitChanges();
                        doctor doc = clinic.doctors.Single(d => d.Did == docId);
                        addToDataBase(doc, log);
                        finshing();
                        button2.Text = "إضافـه";
                    }   
                    else { MessageBox.Show("أرجو مراجعه البيانات المدخله");}

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
                log.type = "طبيب";
            
        }

        private void finshing()
        {
            clinic.SubmitChanges();
            view();
            clearAll();
            MessageBox.Show(" تم إدخال البيانات بنجاح");
        }

        private void addToDataBase(doctor doc,login log)
        {
            doc.Dname = DnameText.Text;
            doc.Ddate_of_start_work = dateTimePicker1.Value.Date;
            doc.Dnew_book_cost = Convert.ToDecimal(NewCheckUpText.Text);
            doc.Dquick_book_cost = Convert.ToDecimal(QuiqeCheckUpText.Text);
            doc.Drebook_cost = Convert.ToDecimal(ReCheckUpText.Text);
            doc.Dphone_number = PhoneText.Text;
            doc.Dspecialization = SpecializationText.Text;
            doc.Dwork_from = FromText.Text;
            doc.Dwork_to = ToText.Text;
            doc.logId = log.logId;
            foreach (string x in TimeTableCheckedList.CheckedItems)
            {
                s +=","+x;
            }
            doc.daysOfWork = s;
            s = "";
        }

        private void TimeTableCheckedList_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void amdin_doctor_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    docId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    DnameText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    PhoneText.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    SpecializationText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    NewCheckUpText.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    QuiqeCheckUpText.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    ReCheckUpText.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    FromText.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    ToText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                    textBox2.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                    textBox1.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                    for (int i = 0; i < TimeTableCheckedList.Items.Count; i++)
                        if (dataGridView1.CurrentRow.Cells[13].Value.ToString().Contains(TimeTableCheckedList.Items[i].ToString()))
                        {
                            TimeTableCheckedList.SetItemChecked(i, true);
                        }else
                        {
                            TimeTableCheckedList.SetItemChecked(i, false);
                        }
                    button2.Text = "تعديل";
                }
            }
            catch { };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                button2.Text = "إضافـه";
               
                doctor doc = clinic.doctors.Single(d => d.Did == docId);
                clinic.doctors.DeleteOnSubmit(doc);
                clinic.SubmitChanges();
                login log = clinic.logins.Single(s => s.logId == int.Parse(dataGridView1.CurrentRow.Cells[10].Value.ToString()));
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

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FillRecordNo();
       
        }

        private void down(KeyEventArgs e ,TextBox t)
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
            down(e, SpecializationText);
        }

        private void SpecializationText_KeyDown(object sender, KeyEventArgs e)
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
            down(e, NewCheckUpText);
        }

        private void NewCheckUpText_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, QuiqeCheckUpText);
        }

        private void QuiqeCheckUpText_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, ReCheckUpText);
        }

        private void ReCheckUpText_KeyDown(object sender, KeyEventArgs e)
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

