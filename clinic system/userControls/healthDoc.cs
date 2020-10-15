using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinic_system.userControls
{
    public partial class healthDoc : UserControl
    {
        public healthDoc()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           forms.healthDocumentation hd = new forms.healthDocumentation(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
      //forms.lx hd = new forms.lx(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

            hd.Show();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            forms.healthDocumentaionByName hdn = new forms.healthDocumentaionByName(textBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            hdn.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button4.PerformClick();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            forms.lx hd = new forms.lx(dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

            hd.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            forms.lxByName hdn = new forms.lxByName(textBox1.Text, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);
            hdn.Show();
        }
    }
}
