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
    public partial class productform : Form
    {
        public productform()
        {
            InitializeComponent();
        }

        private void productform_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {

                conn.Open();
                string query = "INSERT INTO Products (productname, category, price) OUTPUT INSERTED.ProductId VALUES (@p, @c, @r)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p", textBox1.Text);
                cmd.Parameters.AddWithValue("@c", textBox2.Text);
                cmd.Parameters.AddWithValue("@r", textBox3.Text);

                int productId = Convert.ToInt32(cmd.ExecuteScalar());


                SqlCommand cmdTrans = new SqlCommand("INSERT INTO Transactions (productID, quantity, type, date) VALUES (@ProductId, @Quantity, @Type, @Date)", conn);
                cmdTrans.Parameters.AddWithValue("@ProductId", productId);
                cmdTrans.Parameters.AddWithValue("@Quantity", nump.Value);
                cmdTrans.Parameters.AddWithValue("@Type", "ورود");
                cmdTrans.Parameters.AddWithValue("@Date", DateTime.Now);


                try
                {
                    cmd.ExecuteNonQuery();
                    cmdTrans.ExecuteNonQuery();
                    MessageBox.Show("This item successfully registered");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error: " + ex.Message);
                }
                conn.Close();
            }
        }

        private void productform_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
