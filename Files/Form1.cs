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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE name=@n AND pass=@p";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", txtuser.Text);
                cmd.Parameters.AddWithValue("@p", txtpass.Text);

                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Login was successful");
                    mainform main = new mainform();
                    this.Hide();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("User name or password is wrong");
                }
                conn.Close();
            }
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            if (txtuser2.Text == "" || txtpass2.Text == "" || txtpass22.Text == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            if (txtpass2.Text != txtpass22.Text)
            {
                MessageBox.Show("password repeat is wrong");
                return;
            }
            using (SqlConnection conn = new SqlConnection("Server=.;Database=InvertoryDB;Trusted_Connection=True;"))
            {
                conn.Open();
                string query = "INSERT INTO Users (name, pass) VALUES (@n, @p)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", txtuser2.Text);
                cmd.Parameters.AddWithValue("@p", txtpass2.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Register was successful");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                conn.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
