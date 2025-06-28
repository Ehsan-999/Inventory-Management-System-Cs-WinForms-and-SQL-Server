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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data.Common;


namespace final
{
    public partial class reportform : Form
    {
        public reportform()
        {
            InitializeComponent();
        }

        private void reportform_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();

                string query = @"
                SELECT 
                products.productname,
                products.category,
                Transactions.quantity,
                Transactions.type,
                Transactions.date
                FROM products 
                RIGHT JOIN Transactions
                ON products.productID = Transactions.productID";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                da.Fill(result);
                dataGridView1.DataSource = result;
            }
        }

        private void reportform_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform main = new mainform();
            dataGridView1.DataSource = null;
            this.Dispose();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            dataGridView1.DataSource = null;
            this.Dispose();
            main.Show();
        }
    }
}
