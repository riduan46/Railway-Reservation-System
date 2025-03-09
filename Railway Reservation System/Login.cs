using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Railway_Reservation_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");
        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Passenger WHERE Username = @username AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", UserTB.Text);
                    cmd.Parameters.AddWithValue("@password", PassTB.Text);

                    int userExists = (int)cmd.ExecuteScalar();

                    if (userExists > 0)
                    {
                        Main form1 = new Main();
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please enter correct Username and Password", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PassTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegBTN_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
