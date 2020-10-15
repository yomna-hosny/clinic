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
    public partial class homesec : Form
    {
        int panelWidth;
        bool isCollapsed;
        string name;
        public homesec()
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelRight.Width;
            isCollapsed = false;
            userControls.booking book = new userControls.booking();
            addControls(book);
            label9.Text = DateTime.Now.ToLongDateString();

        }
        public homesec( string name)
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelRight.Width;
            isCollapsed = false;
            userControls.booking book = new userControls.booking();
            addControls(book);
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

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(button1);
            userControls.booking book = new userControls.booking();
            addControls(book);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveSidePanel(button3);
            userControls.bookingDocumentsSec bookDoc = new userControls.bookingDocumentsSec();
            addControls(bookDoc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveSidePanel(button2);
            userControls.sec_total_booking_mony tbc = new userControls.sec_total_booking_mony();
            addControls(tbc);
        }

        private void timer1_Tick_1(object sender, EventArgs e)
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

        private void timerTime_Tick_1(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/bluemediaco");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCr6gBGlP7NpSnqlPR8GC3UQ");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/bluemediaco_com");

        }

        private void homesec_Load(object sender, EventArgs e)
        {
            label8.Text = name;
        }

    }
}
