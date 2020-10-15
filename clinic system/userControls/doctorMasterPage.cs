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
using System.Data.SqlClient;

namespace clinic_system.userControls
{
    public partial class doctorMasterPage : UserControl
    {
        int Did;
        SqlConnection con = new SqlConnection();
        clinicDataContext clinic = new clinicDataContext();
        DataTable lTable = new DataTable();
        DataTable xTable = new DataTable();
        int x=0;
        bool f = false;
        public doctorMasterPage()
        {
            InitializeComponent();
            view(); 
           
        }
        public doctorMasterPage(int D)
        {
            InitializeComponent();
            this.Did = D;
            view();
            
        }

        private void view()
        {
            var patient = from ch in clinic.check_ups
                          join pat in clinic.patients on ch.Pid equals pat.Pid
                          where ch.date == DateTime.Now.Date && ch.done == false && ch.Did==this.Did
                          let إسم_المريض = pat.name
                          let نوع_الكشف = ch.tybe
                          select new { ch.Cid, pat.Pid, إسم_المريض, نوع_الكشف, pat.da8t, pat.suger, pat.virus, pat.surgery };
            dataGridView1.DataSource = patient;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            var counWait = (from ch in clinic.check_ups
                            where ch.done == false && ch.date == DateTime.Now.Date &&ch.Did==this.Did
                            select ch).Count();
            var countDone = (from ch in clinic.check_ups
                             where ch.done == true && ch.date == DateTime.Now.Date && ch.Did == this.Did
                             select ch).Count();
            label2.Text = countDone.ToString();
            label3.Text = counWait.ToString();
        }
       
        private void finshing()
        {
            clinic.SubmitChanges();
           // MessageBox.Show(" تم إدخال البيانات بنجاح");
        }


         private void addToCheckUp(check_up ch)
        {   
                ch.case_mul = richTextBox1.Text;
                if (textBox3.Text != "")
                {
                    ch.age = int.Parse(textBox3.Text);
                }
                if (textBox3.Text != "")
                {
                    ch.weight = int.Parse(textBox8.Text);
                }
                ch.nots = richTextBox5.Text;
                ch.done = true;
           
        }
         private void addToPatient(patient pat)
         {
             if (checkBox7.Checked == true) { pat.da8t = true; } else { pat.da8t = false; }
             if (checkBox6.Checked == true) { pat.suger = true; } else { pat.suger = false; }
             if (checkBox5.Checked == true) { pat.virus = true; } else { pat.virus = false; }
             if (checkBox4.Checked == true) { pat.surgery = true; } else { pat.surgery = false; }

         }
         private void addToTreatment(treatment tN, check_up_treatment cht,check_up ch)
         {
             cht.Cid = ch.Cid;
             cht.TTid = tN.TTid;
             cht.duration = comboBox5.Text;
             cht.dose = comboBox7.Text;
         }
         private void addToNewTreatment(treatment tN)
         {
             tN.treatment_name = comboBox1.Text;    
         }


         private void addToLap(check_up_lx chlx,organization or,rays_lab rl , check_up ch)
         {
             chlx.Cid = ch.Cid;
             chlx.Oid = or.Oid;
             chlx.OOid = rl.OOid;
           // or.OOid = rl.OOid;
             or.tybe = "lab";
         }
         private void addToXray(check_up_lx chlx, organization or, rays_lab rl, check_up ch)
         {
             chlx.Cid = ch.Cid;
             chlx.Oid = or.Oid;
             chlx.OOid = rl.OOid;
           //  or.OOid = rl.OOid;
             or.tybe = "x-ray";
         } 
         private void addToNewL(rays_lab rl)
         {
             rl.org_lx_name = comboBox3.Text;
             rl.type = "lab";
         }
        
         private void addToNewX(rays_lab rl)
         {
             rl.org_lx_name = comboBox4.Text;
             rl.type = "x-ray";
         }
         

        //private void addControls(Control c)
        //{
        //   c.Dock = DockStyle.Fill;
        //    panel1.Controls.Clear();
        //    panel1.Controls.Add(c);
        //}

 
        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow.Index != -1)
                {
                    dataGridView1.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label6.Visible = false;
                    panel2.Visible = true;
                    button4.Visible = true;
                    button11.Visible = true;
                    button5.Visible = true;
                    button10.Visible = true;
                    button6.Visible = true;
                    panel3.Visible = true;
                    check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    viewTreat(ch);
                    viewLap(ch);
                    viewXray(ch);
                    if (dataGridView1.CurrentRow.Cells[4].Value.ToString() == "True") { checkBox7.Checked = true; }
                    if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "True") { checkBox6.Checked = true; }
                    if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "True") { checkBox5.Checked = true; }
                    if (dataGridView1.CurrentRow.Cells[7].Value.ToString() == "True") { checkBox4.Checked = true; }
                }
            }
            catch
            {
                MessageBox.Show("please select a valid row");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            forms.healthDocumentaionByName pn = new forms.healthDocumentaionByName(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            pn.Show();
        }
      
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.FillRecordNo();
        }
        private void FillRecordNo()
        {
            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (button1.Text == "تعديل")
            {
                deleteTreatment();
            }
            f = false;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[1].Value.ToString() == comboBox1.Text) { f = true; }

            }

            if (f && button1.Text != "تعديل")
            {
                MessageBox.Show("بيانات مكرره");
                clearTreatment();
            }
            else
            {

                try
                {
                    check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                    check_up_treatment cht = new check_up_treatment();
                    if (checkBox1.Checked == false)
                    {
                        treatment t = clinic.treatments.FirstOrDefault(tt => tt.treatment_name == comboBox1.Text);
                        addToTreatment(t, cht, ch);
                    }
                    else
                    {
                        treatment t = new treatment();
                        addToNewTreatment(t);
                        clinic.treatments.InsertOnSubmit(t);
                        clinic.SubmitChanges();
                        x = t.TTid;
                        addToTreatment(t, cht, ch);
                    }
                    clinic.check_up_treatments.InsertOnSubmit(cht);
                    clinic.SubmitChanges();

                    loadTreatment();
                    viewTreat(ch);
                    button1.Text = "إضافه علاج";
                    clearTreatment();
                }
                catch
                {
                    MessageBox.Show("أرجو مراجعه البيانات المدخله");
                    clearTreatment();
                }
            }

        }

        private void clearTreatment()
        {
            comboBox1.Text = "";
            comboBox5.Text="";
            comboBox7.Text ="";
            checkBox1.Checked = false;
        }

        private void deleteTreatment()
        {
            check_up_treatment chto = clinic.check_up_treatments.Single(c => c.TTid == int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()) && c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            clinic.check_up_treatments.DeleteOnSubmit(chto);
            clinic.SubmitChanges();
        }

        private void viewTreat(check_up ch)
        {
            var treat = from ch2 in clinic.check_ups
                        join cht2 in clinic.check_up_treatments on ch2.Cid equals cht2.Cid
                        join t in clinic.treatments on cht2.TTid equals t.TTid
                        where ch2.Cid == ch.Cid
                        let إسم_العلاج = t.treatment_name
                        let التكرار = cht2.dose
                        let الجرعه = cht2.duration
                        select new { t.TTid, إسم_العلاج, التكرار, الجرعه };
            dataGridView2.DataSource = treat;
            dataGridView2.Columns[0].Visible = false;
        }
        private void clearLap()
        {
            comboBox3.SelectedIndex = -1;
            comboBox6.Text="";
            checkBox2.Checked = false;
        }

        private void deleteLap()
        {
            check_up_lx chlap = clinic.check_up_lxes.FirstOrDefault(c => c.OOid == int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString()) && c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            clinic.check_up_lxes.DeleteOnSubmit(chlap);
            clinic.SubmitChanges();
        }

        private void viewLap(check_up ch)
        {
            var llap = from ch2 in clinic.check_ups
                        join chlap in clinic.check_up_lxes on ch2.Cid equals chlap.Cid
                        join lap in clinic.rays_labs on chlap.OOid equals lap.OOid
                        join org in clinic.organizations on chlap.Oid equals org.Oid
                       let التحليل = lap.org_lx_name
                       let المعمل = org.org_name
                       where ch2.Cid == ch.Cid && org.tybe == "lab"
                       select new { chlap.OOid, التحليل, المعمل };
            dataGridView3.DataSource = llap;
            dataGridView3.Columns[0].Visible = false;
        }

        private void clearXray()
        {
            comboBox2.SelectedIndex = -1;
            comboBox4.Text = "";
            checkBox3.Checked = false;
        }

        private void deleteXray()
        {
            check_up_lx chlap = clinic.check_up_lxes.FirstOrDefault(c => c.OOid == int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString()) && c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            clinic.check_up_lxes.DeleteOnSubmit(chlap);
            clinic.SubmitChanges();
        }

        private void viewXray(check_up ch)
        {
            var lray = from ch2 in clinic.check_ups
                       join chlap in clinic.check_up_lxes on ch2.Cid equals chlap.Cid
                       join lap in clinic.rays_labs on chlap.OOid equals lap.OOid
                       join org in clinic.organizations on chlap.Oid equals org.Oid
                       let الأشعه = lap.org_lx_name
                       let المركز = org.org_name
                       where ch2.Cid == ch.Cid && org.tybe == "x-ray"
                       select new { chlap.OOid, الأشعه, المركز };
            dataGridView4.DataSource = lray;
            dataGridView4.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "تعديل")
            {                              
                    deleteLap();            
            }
            check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            check_up_lx cht = new check_up_lx();
            try
            {
                if (checkBox2.Checked == false)
                {
                    rays_lab rl = clinic.rays_labs.FirstOrDefault(r => r.org_lx_name == comboBox3.SelectedItem.ToString());
                    if (comboBox6.Text !="")
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == comboBox6.SelectedItem.ToString());
                        addToLap(cht, or, rl, ch);
                     }
                    else
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == "" && tt.tybe == "lab");
                        addToLap(cht, or, rl, ch);
                    }                   
                }
                else
                {
                     rays_lab rl =new rays_lab();
                     addToNewL(rl);
                     clinic.rays_labs.InsertOnSubmit(rl);
                     clinic.SubmitChanges();

                     if (comboBox6.Text != null)
                     {
                         organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == comboBox6.SelectedItem.ToString());
                         addToLap(cht, or, rl, ch);
                     }
                     else
                     {
                         organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == ""&&tt.tybe == "lab");
                         addToLap(cht, or, rl, ch);           
                     }                  
                }
                
                    button8.Visible = false;
                    clinic.check_up_lxes.InsertOnSubmit(cht);
                    clinic.SubmitChanges();
                    viewLap(ch);
                    button2.Text = "إضافه تحليل";
                    clearLap();               
            }
            catch
            {
                MessageBox.Show(" أرجو ادخال بيانات صحيحه");
            }
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (button3.Text == "تعديل")
                {
                    deleteXray();
                }
                check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                check_up_lx cht = new check_up_lx();
                if (checkBox3.Checked == false)
                {
                    rays_lab rl = clinic.rays_labs.FirstOrDefault(r => r.org_lx_name == comboBox4.SelectedItem.ToString());
                    if (comboBox2.Text != "")
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == comboBox2.SelectedItem.ToString());
                        addToXray(cht, or, rl, ch);
                    }
                    else
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == "" && tt.tybe == "x-ray");
                        addToXray(cht, or, rl, ch);
                    }
                }
                else
                {
                    rays_lab rl = new rays_lab();
                    addToNewX(rl);
                    clinic.rays_labs.InsertOnSubmit(rl);
                    clinic.SubmitChanges();

                    if (comboBox2.Text != "")
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == comboBox2.SelectedItem.ToString());
                        addToXray(cht, or, rl, ch);
                    }
                    else
                    {
                        organization or = clinic.organizations.FirstOrDefault(tt => tt.org_name == "" && tt.tybe == "x-ray");
                        addToXray(cht, or, rl, ch);
                    }
                }
                clinic.check_up_lxes.InsertOnSubmit(cht);

                button9.Visible = false;
                clinic.SubmitChanges();
                viewXray(ch);
                button3.Text = "إضافه أشعه";
                clearXray();
            }
            catch { MessageBox.Show("أرجو إدخال البيانات كامله"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                endCheck_up();
                MessageBox.Show("تم إدخال البيانات بنجاح");

                try
                {
                    if (dataGridView1.CurrentRow.Index != -1)
                    {
                        view();
                        panel2.Visible = false;
                        button4.Visible = false;
                        button11.Visible = false;
                        button5.Visible = false;
                        button10.Visible = false;
                        button6.Visible = false;
                        panel3.Visible = false;
                        dataGridView1.Visible = true;
                        label1.Visible = true;
                        label2.Visible = true;
                        label3.Visible = true;
                        label6.Visible = true;
                    }
                }
                catch
                {
                    MessageBox.Show("please select a valid row");
                }
            }
            catch { MessageBox.Show("أرجو إكمال البيانات"); }
        }

        private void endCheck_up()
        {
            check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            addToCheckUp(ch);
            patient pat = clinic.patients.Single(c => c.Pid== int.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
            addToPatient(pat);
            finshing();
            richTextBox1.Clear();                  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
               // endCheck_up();
                forms.testRo4ta ro = new forms.testRo4ta (dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ro.Show();
            }
            catch { MessageBox.Show("أرجو إكمال البيانات"); }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                comboBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                comboBox7.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                comboBox5.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                button1.Text = "تعديل";
                button7.Visible = true;
                if (comboBox1.Items.Contains(dataGridView2.CurrentRow.Cells[1].Value.ToString()) == true) { checkBox1.Checked = false; }
                else { checkBox1.Checked = true; }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {            
            deleteTreatment();
            check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            viewTreat(ch);
            button7.Visible = false;
            button1.Text = "إضافه علاج";
            clearTreatment();
        }
        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow.Index != -1)
            {
                comboBox3.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                comboBox6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                button2.Text = "تعديل";
                button8.Visible = true;
                if (comboBox3.Items.Contains(dataGridView3.CurrentRow.Cells[1].Value.ToString())) { checkBox2.Checked = false; }
                else { checkBox2.Checked = true; }
            }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            deleteLap();
            check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            viewLap(ch);
            button8.Visible = false;
            button2.Text = "إضافه تحليل";
            clearLap();
        }
       
        private void button9_Click(object sender, EventArgs e)
        {
            deleteXray();
            check_up ch = clinic.check_ups.Single(c => c.Cid == int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            viewXray(ch);
            button9.Visible = false;
            button3.Text = "إضافه أشعه";
            clearXray();
        }

        private void dataGridView4_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView4.CurrentRow.Index != -1)
            {
                comboBox4.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                button3.Text = "تعديل";
                button9.Visible = true;
                if (comboBox4.Items.Contains(dataGridView4.CurrentRow.Cells[1].Value.ToString())) { checkBox3.Checked = false; }
                else { checkBox3.Checked = true; }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //endCheck_up();
                forms.labsXrays ro = new forms.labsXrays(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                ro.Show();
            }
            catch { MessageBox.Show("أرجو إكمال البيانات"); }
        }

        private void doctorMasterPage_Load(object sender, EventArgs e)
        {
            loadTreatment();
            loadOrgLaps();
            loadOrgRays();
            loadRays();
            loadLaps();
          
        }

        private void loadTreatment()
        {
            comboBox1.Items.Clear();
            var t = from tt in clinic.treatments
                    orderby tt.treatment_name
                    select new { tt.treatment_name };
            foreach (var i in t)
            {
                comboBox1.Items.Add(i.treatment_name);
            }
        }
        private void loadOrgLaps()
        {
            var l = from ll in clinic.organizations
                    orderby ll.org_name
                    where ll.tybe == "lab"
                    select new { ll.org_name};
            foreach (var i in l)
            {
                comboBox6.Items.Add(i.org_name);
            }
        }

        private void loadOrgRays()
        {
            var l = from ll in clinic.organizations
                    orderby ll.org_name
                    where ll.tybe == "x-ray"
                    select new { ll.org_name };
            foreach (var i in l)
            {
                comboBox2.Items.Add(i.org_name);
            }
        }

        private void loadLaps()
        {
            var l = from ll in clinic.rays_labs
                    orderby ll.org_lx_name
                    where ll.type == "lab"
                    select new { ll.org_lx_name };
            foreach (var i in l)
            {
                comboBox3.Items.Add(i.org_lx_name);
            }
        }

        private void loadRays()
        {
            var l = from ll in clinic.rays_labs
                    orderby ll.org_lx_name
                    where ll.type == "x-ray"
                    select new { ll.org_lx_name };
            foreach (var i in l)
            {
                comboBox4.Items.Add(i.org_lx_name);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            view();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            forms.lxByName pn = new forms.lxByName(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            pn.Show();
        }

    }
}
