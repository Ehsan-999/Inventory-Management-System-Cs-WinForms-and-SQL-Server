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
    public partial class stockform : Form
    {
        public stockform()
        {
            InitializeComponent();
        }

        private void stockform_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT category FROM products", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                comboBox1.DisplayMember = "category";
                comboBox1.ValueMember = "category";
                comboBox1.DataSource = dt;
            }

        }

        private void stockform_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform main = new mainform();
            dataGridView1.DataSource = null;
            this.Dispose();
            main.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choice one category");
                return;
            }

            string selectedCategory = comboBox1.SelectedValue.ToString();

            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();

                string query = @"
        SELECT 
            p.productID,
            p.productname,
            p.category,
            ISNULL(SUM(CASE WHEN t.type = N'ورود' THEN t.quantity ELSE 0 END), 0) -
            ISNULL(SUM(CASE WHEN t.type = N'خروج' THEN t.quantity ELSE 0 END), 0) AS stock
        FROM products p
        LEFT JOIN Transactions t ON p.productID = t.productID
        WHERE p.category = @category
        GROUP BY p.productID, p.productname, p.category";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@category", selectedCategory);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable result = new DataTable();
                da.Fill(result);

                dataGridView1.DataSource = result;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            dataGridView1.DataSource = null;
            this.Dispose();
            main.Show();
        }
    }
}
