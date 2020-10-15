using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace clinic_system.forms
{
    public partial class homeadm : Form
    {
        int panelWidth;
        string name;
        bool isCollapsed;
        public homeadm()
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelRight.Width;
            isCollapsed = false;
            userControls.amdin_doctor doc = new userControls.amdin_doctor();
            addControls(doc);
            label9.Text = DateTime.Now.ToLongDateString();

        }
        public homeadm(string name)
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelRight.Width;
            isCollapsed = false;
            userControls.amdin_doctor doc = new userControls.amdin_doctor();
            addControls(doc);
            label9.Text = DateTime.Now.ToLongDateString();
            this.name = name;
        }
        private void moveSidePanel(Control btn)
        {
            panelside.Top = btn.Top;
            panelside.Height = btn.Height;
        }
        private void addControls(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelside_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(button1);
            userControls.amdin_doctor doc = new userControls.amdin_doctor();
            addControls(doc);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveSidePanel(button3);
            userControls.admin_secrts sec = new userControls.admin_secrts();
            addControls(sec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveSidePanel(button2); 
            userControls.patientDocuments_admin pat = new userControls.patientDocuments_admin();
            addControls(pat);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelRight.Width = panelRight.Width + 20;
                if (panelRight.Width >= panelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelRight.Width = panelRight.Width - 20;
                if (panelRight.Width <= 60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
        }

        private void homeadm_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
            label8.Text = name;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveSidePanel(button4);
            userControls.doctorXray doc = new userControls.doctorXray();
            addControls(doc);
        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            moveSidePanel(button5);
            userControls.doctorLabs doc = new userControls.doctorLabs();
            addControls(doc);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/bluemediaco");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCr6gBGlP7NpSnqlPR8GC3UQ");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/bluemediaco_com");

        }

       
    }
}
