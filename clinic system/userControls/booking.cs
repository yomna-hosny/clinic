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
    public partial class booking : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();
        int bookId = 0;
        public booking()
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
        private void view()
        {
            var book = from ch in clinic.check_ups
                       join doc in clinic.doctors on ch.Did equals doc.Did
                       join pat in clinic.patients on ch.Pid equals pat.Pid
                       let التكلفه = (ch.tybe == "كشف جديد مستعجل" ? doc.Dquick_book_cost :
                       ch.tybe == "إعاده كشف" ? doc.Drebook_cost :
                        doc.Dnew_book_cost)
                     where ch.date == DateTime.Now.Date && ch.done==false
                       let إسم_المريض = pat.name
                       let إسم_الدكتور = doc.Dname
                       let نوع_الكشف = ch.tybe
                       let من = ch.start_from
                       let إلي = ch.end_to
                       let رقم_الهاتف = pat.phone_number
                       let ضغط = pat.da8t
                       let سكر = pat.suger
                       let فيروس = pat.virus
                       let عمليات_مسبقه = pat.surgery
                       select new { ch.Cid, pat.Pid, إسم_المريض, إسم_الدكتور, التكلفه, نوع_الكشف, من, إلي, رقم_الهاتف, ضغط, سكر, فيروس, عمليات_مسبقه };
            dataGridView1.DataSource = book;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            //dataGridView1.Columns[9].Visible = false;
            //dataGridView1.Columns[10].Visible = false;
            //dataGridView1.Columns[11].Visible = false;
            //dataGridView1.Columns[12].Visible = false;
            searchcontent.Clear();
        }

        private void clearAll()
        {
            comboBox1.SelectedIndex=-1;
            comboBox2.SelectedIndex=-1;           
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;

        }
        private void finshing()
        {
           clinic.SubmitChanges();
            view();
            clearAll();
            MessageBox.Show(" تم إدخال البيانات بنجاح");
        }
        private void addToDataBasepat(patient pat)
        {   
            pat.name = comboBox2.Text;
            pat.phone_number = textBox6.Text;
            if (checkBox1.Checked == true)
            {
                pat.da8t =true;
            }
            else { pat.da8t = false; }
            if (checkBox2.Checked == true)
            {
                pat.suger = true;
            }
            else { pat.suger = false; }
            if (checkBox3.Checked == true)
            {
                pat.virus = true;
            }
            else { pat.virus = false; }
            if (checkBox4.Checked == true)
            {
                pat.surgery = true;
            }
            else { pat.surgery = false; }
        }
        private void addToDataBase1(check_up ch , doctor doc , patient pat)
        {
            ch.start_from = textBox7.Text;
            ch.end_to = textBox5.Text;
           ch.tybe  = (radioButton2.Checked==true ? radioButton2.Text :
                       radioButton3.Checked==true? radioButton3.Text :
                         radioButton1.Text  );
           ch.Did = doc.Did;
           ch.Pid = pat.Pid;
           ch.date = DateTime.Now.Date;
         decimal cost = (ch.tybe == "كشف جديد مستعجل" ? doc.Dquick_book_cost :
                          ch.tybe == "إعاده كشف" ? doc.Drebook_cost :
                           doc.Dnew_book_cost);

         ch.cost = cost;
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (searchBox.Text == "")
            {
                view();
            }
            else if (searchBox.Text == "رقم الهاتف")
            {
                var book = from ch in clinic.check_ups
                           join doc in clinic.doctors on ch.Did equals doc.Did
                           join pat in clinic.patients on ch.Pid equals pat.Pid
                           let التكلفه = (ch.tybe == "كشف جديد مستعجل" ? doc.Dquick_book_cost :
                           ch.tybe == "إعاده كشف" ? doc.Drebook_cost :
                            doc.Dnew_book_cost)
                           where ch.date == DateTime.Now.Date && pat.phone_number.Contains(searchcontent.Text)
                           let إسم_المريض = pat.name
                           let إسم_الدكتور = doc.Dname
                           let نوع_الكشف = ch.tybe
                           let من = ch.start_from
                           let إلي = ch.end_to
                           let رقم_الهاتف = pat.phone_number
                           let ضغط = pat.da8t
                           let سكر = pat.suger
                           let فيروس = pat.virus
                           let عمليات_مسبقه = pat.surgery
                           select new { ch.Cid, pat.Pid, إسم_المريض, إسم_الدكتور, التكلفه, نوع_الكشف, من, إلي, رقم_الهاتف, ضغط, سكر, فيروس, عمليات_مسبقه };

                dataGridView1.DataSource = book;
                searchcontent.Clear();
            }
            else if (searchBox.Text == "إسم المريض")
            {
                var book = from ch in clinic.check_ups
                           join doc in clinic.doctors on ch.Did equals doc.Did
                           join pat in clinic.patients on ch.Pid equals pat.Pid
                           let التكلفه = (ch.tybe == "كشف جديد مستعجل" ? doc.Dquick_book_cost :
                           ch.tybe == "إعاده كشف" ? doc.Drebook_cost :
                            doc.Dnew_book_cost)
                           where ch.date == DateTime.Now.Date && pat.name.Contains(searchcontent.Text)
                           let إسم_المريض = pat.name
                           let إسم_الدكتور = doc.Dname
                           let نوع_الكشف = ch.tybe
                           let من = ch.start_from
                           let إلي = ch.end_to
                           let رقم_الهاتف = pat.phone_number
                           let ضغط = pat.da8t
                           let سكر = pat.suger
                           let فيروس = pat.virus
                           let عمليات_مسبقه = pat.surgery
                           select new { ch.Cid, pat.Pid, إسم_المريض, إسم_الدكتور, التكلفه, نوع_الكشف, من, إلي, رقم_الهاتف, ضغط, سكر, فيروس, عمليات_مسبقه };

                dataGridView1.DataSource = book;
                searchcontent.Clear();
            }
            else if (searchBox.Text == "إسم الدكتور")
            {
                var book = from ch in clinic.check_ups
                           join doc in clinic.doctors on ch.Did equals doc.Did
                           join pat in clinic.patients on ch.Pid equals pat.Pid
                           let التكلفه = (ch.tybe == "كشف جديد مستعجل" ? doc.Dquick_book_cost :
                           ch.tybe == "إعاده كشف" ? doc.Drebook_cost :
                            doc.Dnew_book_cost)
                           where ch.date == DateTime.Now.Date && doc.Dname.Contains(searchcontent.Text)
                           let إسم_المريض = pat.name
                           let إسم_الدكتور = doc.Dname
                           let نوع_الكشف = ch.tybe
                           let من = ch.start_from
                           let إلي = ch.end_to
                           let رقم_الهاتف = pat.phone_number
                           let ضغط = pat.da8t
                           let سكر = pat.suger
                           let فيروس = pat.virus
                           let عمليات_مسبقه = pat.surgery
                           select new { ch.Cid, pat.Pid, إسم_المريض, إسم_الدكتور, التكلفه, نوع_الكشف, من, إلي, رقم_الهاتف, ضغط, سكر, فيروس, عمليات_مسبقه };

                dataGridView1.DataSource = book;
                searchcontent.Clear();
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
            doctor doc = clinic.doctors.Single(d => d.Dname == comboBox1.Text);

           
             if (comboBox2.Text == "")
            {
                MessageBox.Show("أرجو إدخال إسم المريض");
                textBox6.Focus();}
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("أرجو إدخال  إسم الطبيب");
                textBox6.Focus();
            }
            else if (radioButton2.Checked == false && radioButton1.Checked == false && radioButton3.Checked == false) { MessageBox.Show("أرجو تحديد نوع الكشف"); }
            else
            {
                if (button3.Text == "إضافه")
                {
                   
                    check_up ch = new check_up();
                    if (radioButton4.Checked == true)
                    {
                        if (textBox6.Text == "")
                        {
                            MessageBox.Show("أرجو إدخال رقم الهاتف");
                            textBox6.Focus();
                        }
                        else
                        {
                            patient pat = new patient();

                            addToDataBasepat(pat);
                            clinic.patients.InsertOnSubmit(pat);
                            clinic.SubmitChanges();
                            addToDataBase1(ch, doc, pat);
                            clinic.check_ups.InsertOnSubmit(ch);
                            finshing();
                            loadPatient();
                        }
                    }
                    else
                    {

                        patient pat = clinic.patients.FirstOrDefault(p => p.name == comboBox2.Text);
                        addToDataBase1(ch, doc, pat);
                        clinic.check_ups.InsertOnSubmit(ch);
                        finshing();
                    }
                }
                else
                {
                    check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    if (radioButton4.Checked == true)
                    {
                        patient pat = new patient();
                        addToDataBasepat(pat);
                        clinic.patients.InsertOnSubmit(pat);
                        clinic.SubmitChanges();
                        addToDataBase1(ch, doc, pat);
                        finshing();
                        button3.Text = "إضافه";
                    }
                    else
                    {
                        patient pat = clinic.patients.FirstOrDefault(p => p.Pid == int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
                        addToDataBasepat(pat);
                        addToDataBase1(ch, doc, pat);
                        finshing();
                        button3.Text = "إضافه";
                    }

                }
            }
            }
           catch
           {
               MessageBox.Show("أرجو مراجعه البيانات المدخله");
           }
        }
    

        private void booking_Load(object sender, EventArgs e)
        {
            loadPatient();
            loadDoc();
        }
        private void loadPatient()
        {
            var p = from tt in clinic.patients
                    orderby tt.name
                    select new { tt.name };
            foreach (var i in p)
            {
                comboBox2.Items.Add(i.name);
            }
        }
        private void loadDoc()
        {
            var d = from tt in clinic.doctors
                    orderby tt.Dname
                    select new { tt.Dname };
            foreach (var i in d)
            {
                comboBox1.Items.Add(i.Dname);
            }
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                button3.Text = "إضافه";

               check_up ch= clinic.check_ups.Single(c => c.Cid ==bookId);
                clinic.check_ups.DeleteOnSubmit(ch);
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

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //try
            //{
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    bookId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == radioButton1.Text)
                    { radioButton1.Checked = true; }
                    else if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == radioButton2.Text)
                    { radioButton2.Checked = true; }
                    else { radioButton3.Checked = true; }
                    textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                     if (dataGridView1.CurrentRow.Cells[9].Value.ToString() == "True") { checkBox1.Checked = true; }
                    else { checkBox1.Checked = false; }
                    if (dataGridView1.CurrentRow.Cells[10].Value.ToString() == "True") { checkBox2.Checked = true; }
                    else { checkBox2.Checked = false; }
                    if (dataGridView1.CurrentRow.Cells[11].Value.ToString() == "True") { checkBox3.Checked = true; }
                    else { checkBox3.Checked = false; }
                    if (dataGridView1.CurrentRow.Cells[12].Value.ToString() == "True") { checkBox4.Checked = true; }
                    else { checkBox4.Checked = false; }
                    button3.Text = "تعديل";

                }
            //}
            //catch { };
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //label3.Visible = true;
            //textBox3.Visible = true;
            //comboBox2.Visible = false;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //label3.Visible = true;
            //textBox3.Visible = false;
            //comboBox2.Visible = true;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.FillRecordNo();
        }

       
        private void down(KeyEventArgs e, TextBox t)
        {
            if (e.KeyCode == Keys.Enter)
            {
                t.Focus();
            }
        }
        private void comboBox2_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, textBox6);
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, textBox7);
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, textBox5);
        }

        private void searchcontent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               button5.Focus();
            }
        }
    }
}
