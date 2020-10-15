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
namespace clinic_system.forms
{
    public partial class login2 : Form
    {
        SqlConnection con = new SqlConnection();
        clinicDataContext clinic = new clinicDataContext();

        int did;
        string name;
        public login2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                
                    str = Stream.ReadCS();
                    
                        con.ConnectionString = str;
                        // con.ConnectionString = @"Data Source=tcp:192.168.11.12,49172;Initial Catalog=clinic;user id=admin;password=242428";
                        // con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=clinic;Integrated Security=True";
                        string sql = "SELECT  * from login where userName='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
                        DataSet1 ds = new DataSet1();
                        SqlDataAdapter dad = new SqlDataAdapter(sql, con);
                    
                        dad.Fill(ds.Tables["login"]);

                        string combo = comboBox1.SelectedItem.ToString();
                    
                if (ds.login.Rows.Count > 0)
                {
                    for (int i = 0; i < ds.login.Rows.Count; i++)
                    {
                        if (ds.login.Rows[i]["type"].ToString() == combo)
                        {
                            MessageBox.Show("تم تسجيل الدخول ك" + ds.login.Rows[i][3]);
                            if (comboBox1.SelectedIndex == 0)
                            {
                                var admName = from log in clinic.logins
                                              where log.userName == textBox1.Text && log.password == textBox2.Text
                                              select log.userName;
                                
                                name = admName.FirstOrDefault();
                                forms.homeadm ha = new homeadm(name);
                                ha.Show();
                                this.Hide();
                            }
                            else if (comboBox1.SelectedIndex == 1)
                            {
                                var secName = from sec in clinic.secretaries
                                              join log in clinic.logins on sec.logId equals log.logId
                                              where log.userName == textBox1.Text && log.password == textBox2.Text
                                              select sec.Sname;
                                name = secName.FirstOrDefault();
                                forms.homesec hs = new homesec(name);
                                hs.Show();
                                this.Hide();
                            }
                            else if (comboBox1.SelectedIndex == 2)
                            {
                                var doctor = from doc in clinic.doctors
                                             join log in clinic.logins on doc.logId equals log.logId
                                             where log.userName == textBox1.Text && log.password == textBox2.Text
                                             select doc.Did;
                                var docName = from doc in clinic.doctors
                                              join log in clinic.logins on doc.logId equals log.logId
                                              where log.userName == textBox1.Text && log.password == textBox2.Text
                                              select doc.Dname;
                                did = doctor.FirstOrDefault();
                                name = docName.FirstOrDefault();
                                forms.homedoc hd = new homedoc(did,name);
                                hd.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("أرجو مراجعه البيانات ");
                }
            }
            catch { MessageBox.Show("أرجو مراجعه البيانات "); }
            //using (clinic_system.forms.homeadm a_h = new clinic_system.forms.homeadm())
            //{
            //    a_h.ShowDialog();
            //}
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void logn(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            logn(e);
        }

    
       

    }
}
