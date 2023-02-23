using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abhay_final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearData()
        {
            txtLogin.Text = "";
            txtPassword.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connection);
            try
            {
                DataTable dt = new DataTable();
                //Sql query to validate the detail
                string query = "Select * from  emp Where username='" + txtLogin.Text + "' and Password='" + txtPassword.Text + "';";
                //Execute the query
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Login Successfully Done..");
                    this.Hide();
                    Form4 ss = new Form4();
                    ss.Show();
                }
                else
                {
                    MessageBox.Show("No such user found..");
                }
                //After login clear the fields
                ClearData();
            }
            catch
            {
                MessageBox.Show("Error occured...");
            }
            finally
            {
                con.Close();
            }
        }
    }
}
