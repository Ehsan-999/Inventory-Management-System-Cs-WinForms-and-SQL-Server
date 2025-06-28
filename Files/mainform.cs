using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace final
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productform pform = new productform();
            this.Hide();
            pform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stockform stockform = new stockform();
            this.Hide();
            stockform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            transactionform transactionform = new transactionform();
            this.Hide();
            transactionform.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reportform reportform = new reportform();
            this.Hide();
            reportform.Show();
        }
    }
}
