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
    public partial class doctorXray : UserControl
    {
        clinicDataContext clinic = new clinicDataContext();
        int rayId = 0;
        public doctorXray()
        {
            InitializeComponent();
            view();
        }
        private void view()
        {
            var ray = from r in clinic.organizations
                      where r.tybe == "x-ray"
                       let الإسم = r.org_name
                      let رقم_الهاتف = r.phoneNUMBER
                      let العنوان = r.address
                      select new { r.Oid, الإسم, رقم_الهاتف, العنوان };
            dataGridView2.DataSource = ray;
            dataGridView2.Columns[0].Visible = false;
            searchcontent2.Clear();
        }
        private void clearAll()
        {
            xRayNameText.Clear();
            textBox1.Clear();
            textBox2.Clear();

        }
        private void finshing()
        {
            clinic.SubmitChanges();
            view();
            clearAll();
            MessageBox.Show(" تم إدخال البيانات بنجاح");
        }
       
        private void addToDataBase1(organization O)
        {
            O.org_name = xRayNameText.Text;
            O.address = textBox2.Text;
            O.phoneNUMBER = textBox1.Text;
            O.tybe = "x-ray";          
        }

      

        private void add_Click_1(object sender, EventArgs e)
        {
            try
            {      
                if (add.Text == "إضافـه")
                {
                    organization O = new organization();
                    if (xRayNameText.Text != "" && textBox2.Text != "")
                 {                
                    addToDataBase1(O);
                    clinic.organizations.InsertOnSubmit(O);
                    finshing();
                 }
                    else { MessageBox.Show("أرجو مراجعه البيانات المدخله"); }          
                }
                else
                {
                    if (xRayNameText.Text != "" && textBox2.Text != "")
                    {
                        organization org = clinic.organizations.Single(l => l.Oid == rayId);
                        addToDataBase1(org);
                        finshing();
                        add.Text = "إضافـه";
                    }
                }
            }
            catch
            {
                MessageBox.Show("أرجو مراجعه البيانات المدخله");
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {

            try
            {
                add.Text = "إضافـه";

                organization org = clinic.organizations.Single(l => l.Oid == rayId);
                clinic.organizations.DeleteOnSubmit(org);
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

        private void deleteAll_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void search_Click(object sender, EventArgs e)
        {

            if (searchBox2.Text == "")
            {
                view();
            }
            else if (searchBox2.Text == "إسم المؤسسه")
            {
                var lab = from l in clinic.organizations
                          where l.tybe == "x-ray" && l.org_name.Contains(searchcontent2.Text)
                          let الإسم = l.org_name
                          let رقم_الهاتف = l.phoneNUMBER
                          let العنوان = l.address
                          select new { l.Oid, الإسم, رقم_الهاتف, العنوان }; 
                dataGridView2.DataSource = lab;
                dataGridView2.Columns[0].Visible = false;
                searchcontent2.Clear();
            }
            else if (searchBox2.SelectedIndex==1)
            {
                var lab = from l in clinic.organizations
                          where l.tybe == "x-ray" && l.phoneNUMBER.Contains(searchcontent2.Text)
                          let الإسم = l.org_name
                          let رقم_الهاتف = l.phoneNUMBER
                          let العنوان = l.address
                          select new { l.Oid, الإسم, رقم_الهاتف, العنوان };
                dataGridView2.DataSource = lab;
                dataGridView2.Columns[0].Visible = false;
                searchcontent2.Clear();
            }
            else if (searchBox2.SelectedIndex == 2)
            {
                var lab = from l in clinic.organizations
                          where l.tybe == "x-ray" && l.address.Contains(searchcontent2.Text)
                          let الإسم = l.org_name
                          let رقم_الهاتف = l.phoneNUMBER
                          let العنوان = l.address
                          select new { l.Oid, الإسم, رقم_الهاتف, العنوان };
                dataGridView2.DataSource = lab;
                dataGridView2.Columns[0].Visible = false;
                searchcontent2.Clear();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {  try
            {
            if (dataGridView2.CurrentRow.Index != -1)
            {
                rayId = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                xRayNameText.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox1.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                 
               add.Text = "تعديل";
            }           
            }
        catch { }

        }
        private void down(KeyEventArgs e, TextBox t)
        {
            if (e.KeyCode == Keys.Enter)
            {
                t.Focus();
            }
        }
        private void xRayNameText_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, textBox1);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            down(e, textBox2);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                add.PerformClick();
            }
        }

        private void searchcontent2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search.PerformClick();
            }
        }
    }
}