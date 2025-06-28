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
    public partial class transactionform : Form
    {
        public transactionform()
        {
            InitializeComponent();
        }

        private void transactionform_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT productID, productname FROM products", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                comboBox1.DisplayMember = "productname";
                comboBox1.ValueMember = "productID";
                comboBox1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            int productId = (int)comboBox1.SelectedValue;
            int quantity = int.Parse(textBox1.Text);
            string type = radioButton1.Checked ? "ورود" : "خروج";
            DateTime date = DateTime.Now;

            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();
                if (type == "خروج")
                {
                    SqlCommand checkStock = new SqlCommand(@"
                SELECT 
                ISNULL(SUM(CASE WHEN LTRIM(RTRIM(type)) = N'ورود' THEN quantity ELSE 0 END), 0) -
                ISNULL(SUM(CASE WHEN LTRIM(RTRIM(type)) = N'خروج' THEN quantity ELSE 0 END), 0)
                FROM Transactions
                WHERE productID = @ProductId", conn);

                    checkStock.Parameters.AddWithValue("@ProductId", productId);
                    int currentStock = Convert.ToInt32(checkStock.ExecuteScalar());

                    if (quantity > currentStock)
                    {
                        MessageBox.Show("The amount of withdrawal is greater than the amount of inventory!");
                        return;
                    }
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Transactions (productID, quantity, type, date) VALUES (@ProductId, @Quantity, @Type, @Date)", conn);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Date", date);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Transaction recorded.");
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (comboBox1.SelectedIndex == -1 || comboBox1.SelectedValue == null)
                    return;

                int productId = Convert.ToInt32(comboBox1.SelectedValue);

                using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"
            SELECT 
            ISNULL(SUM(CASE WHEN LTRIM(RTRIM(type)) = N'ورود' THEN quantity ELSE 0 END), 0) -
            ISNULL(SUM(CASE WHEN LTRIM(RTRIM(type)) = N'خروج' THEN quantity ELSE 0 END), 0)
            FROM Transactions
            WHERE productID = @productID", conn);

                SqlCommand cmd2 = new SqlCommand(@"
            SELECT 
            products.price
            FROM products 
            WHERE productID= @productID", conn);

                    cmd.Parameters.AddWithValue("@productID", productId);
                    int currentStock = Convert.ToInt32(cmd.ExecuteScalar());

                    cmd2.Parameters.AddWithValue("@productID", productId);
                    int currentStock2 = Convert.ToInt32(cmd2.ExecuteScalar());

                    label4.Text = currentStock2.ToString();
                    label1.Text = currentStock.ToString();  
                    conn.Close();
                }
          

        }

        private void textBox1_FontChanged(object sender, EventArgs e)
        {

        }

        private void transactionform_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform main = new mainform();
            this.Dispose();
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainform main = new mainform();
            this.Dispose();
            main.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int quantity;
            int pricePerUnit;

            if (int.TryParse(textBox1.Text, out quantity) && int.TryParse(label4.Text, out pricePerUnit))
            {
                int totalPrice = quantity * pricePerUnit;
                label8.Text = totalPrice.ToString();
            }
            else
            {
                label8.Text = "0";
            }
        }
    }
}
