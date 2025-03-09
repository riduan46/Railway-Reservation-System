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

namespace Railway_Reservation_System
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
            LoadPNRIDs();
            LoadResIDs();
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }
        DataTable dt = new DataTable("Table");
        int index;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");
       


        private void TInsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Payments(PaymentID,ResID,PNRID,Amount,PaymentMethod) Values ('" + TBTN1.Text + "','" + TBTN2.Text + "', '" + TBTN3.Text + "','" + TBTN4.Text + "', '" + TBTN5.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertion Completed");
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void TDltBTN_Click(object sender, EventArgs e)
        {
            if (PayList.SelectedRows.Count > 0)
            {
                PayList.Rows.RemoveAt(PayList.SelectedRows[0].Index);
            }
            String Query = "delete from Payments where PaymentID= '" + this.TBTN1.Text + "';";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Deleted");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void PayList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = PayList.Rows[index];
            TBTN1.Text = row.Cells[0].Value.ToString();
            TBTN2.Text = row.Cells[1].Value.ToString();
            TBTN3.Text = row.Cells[2].Value.ToString();
            TBTN4.Text = row.Cells[3].Value.ToString();
            TBTN5.Text = row.Cells[4].Value.ToString();
        }

        private void TUpdBTN_Click(object sender, EventArgs e)
        {
            String Query = "update Payments set ResID= '" + this.TBTN2.Text + "' , PNRID= '" + this.TBTN3.Text + "', Amount= '" + this.TBTN4.Text + "', PaymentMethod= '" + this.TBTN5.Text + "';";
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader myReader;
            try
            {
                conn.Open();
                myReader = cmd.ExecuteReader();
                MessageBox.Show("Updated");
                while (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void TShwBTN_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Payments", conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                PayList.DataSource = null;
                da.Fill(dt);
                PayList.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSrhBTN_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Select PaymentID,ResID,PNRID,Amount,PaymentMethod from Payments where PaymentID=@idpar", conn);
            cmd2.Parameters.AddWithValue("idpar", PayList.Text.Trim());
            SqlDataReader myReader;
            myReader = cmd2.ExecuteReader();
            if (myReader.Read())
            {

                
                TBTN2.Text = myReader["ResID"].ToString();
                TBTN3.Text = myReader["PNRID"].ToString();
                TBTN4.Text = myReader["Amount"].ToString();
                TBTN5.Text = myReader["PaymentMethod"].ToString();




            }
            else
            {
                
                TBTN2.Text = "";
                TBTN3.Text = "";
                TBTN4.Text = "";
                TBTN5.Text = "";



                MessageBox.Show("No Data Found");
            }
            conn.Close();
        }
        private void LoadPNRIDs()
        {
            try
            {
                conn.Open();
                string query = "SELECT PNRID FROM Passenger";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                TBTN3.Items.Clear(); 

                while (reader.Read())
                {
                    TBTN3.Items.Add(reader["PNRID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void LoadResIDs()
        {
            try
            {
                conn.Open();
                string query = "SELECT ResID FROM Reservation";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                TBTN2.Items.Clear(); 

                while (reader.Read())
                {
                    TBTN2.Items.Add(reader["ResID"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
