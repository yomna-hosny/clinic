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
    public partial class homedoc: Form
    {
        int panelWidth;
        bool isCollapsed;
        int Did;
        string name="";
         public homedoc()
        {
            InitializeComponent();
            timerTime.Start();
            panelWidth = panelRight.Width;
            isCollapsed = false;
            userControls.doctorMasterPage doc = new userControls.doctorMasterPage(this.Did);
            addControls(doc);
            //this.name = name;

        }
         public homedoc(int Did,string name)
         {
             InitializeComponent();
             timerTime.Start();
             panelWidth = panelRight.Width;
             isCollapsed = false;          
             this.Did = Did;
             userControls.doctorMasterPage doc = new userControls.doctorMasterPage(this.Did);
             addControls(doc);
             this.name = name;
         }

       

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isCollapsed)
            {
                panelRight.Width = panelRight.Width + 20;
                if(panelRight.Width>=panelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelRight.Width = panelRight.Width - 20;
                if(panelRight.Width<=60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Start();
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

        private void button1_Click(object sender, EventArgs e)
        {
            moveSidePanel(button1);
            userControls.doctorMasterPage doc = new userControls.doctorMasterPage(this.Did);
            addControls(doc);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            moveSidePanel(button2);
            userControls.healthDoc hdoc = new userControls.healthDoc();
            addControls(hdoc);
        }

       

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControls_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homedoc_Load(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();
            label8.Text = name;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToLongDateString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/bluemediaco");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCr6gBGlP7NpSnqlPR8GC3UQ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/bluemediaco_com");

        }

       

        
        
    }
}
