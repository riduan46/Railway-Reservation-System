using control;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Railway_Reservation_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");
        DataTable dt = new DataTable();

        private void Register_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select isnull(max(cast(PNRID as int)),0)+1 from Passenger", conn);

            adapter.Fill(dt);
            RTB1.Text = dt.Rows[0][0].ToString();
        }



    private void RegInsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Passenger(PNRID,UserName,Password, FirstName,LastName,ContactNumber,DoB,Gender,Email,Address,PostCode,Picture) Values ('" + RTB1.Text + "','" + PTB1.Text + "', '" + PTB2.Text + "','" + PTB3.Text + "', '" + PTB4.Text + "', '" + PTB5.Text + "', '" + this.DTP1.Text + "', '" + RCB1.Text + "','" + PTB8.Text + "', '" + PTB9.Text + "', '" + PTB10.Text + "', '" + RPB1.Image + "')", conn);
                cmd.Parameters.AddWithValue("@Picture", getPhoto());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registration Completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
        private object getPhoto()
        {
            MemoryStream st = new MemoryStream();
            RPB1.Image.Save(st, pictureBox1.Image.RawFormat);
            return st.GetBuffer();
        }
        private void PInsPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RPB1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    } 
}