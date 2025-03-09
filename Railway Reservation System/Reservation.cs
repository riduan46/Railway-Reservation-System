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
    public partial class Reservation : Form
    {
        DataTable dt = new DataTable("Table");
        int index;
        string pnr;
        public Reservation()
        {
            InitializeComponent();
            LoadPNRIDs();
            LoadTrainIDs();
            LoadSchIDs();    
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");

       

        

        private void Reservation_Load(object sender, EventArgs e)
        {
            
           


        }

        private void TSrhBTN_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT PNRID, TrainID, SourceStation, DestinationStation, TravelDate, ScheduleID FROM Reservation WHERE ResID = @idpar", conn);
                cmd2.Parameters.AddWithValue("@idpar", RBTN1.Text.Trim());

                SqlDataReader myReader = cmd2.ExecuteReader();

                if (myReader.Read())
                {
                    RBTN2.Text = myReader["PNRID"].ToString();
                    RBTN3.Text = myReader["TrainID"].ToString();
                    RBTN4.Text = myReader["SourceStation"].ToString();
                    RBTN5.Text = myReader["DestinationStation"].ToString();
                    RBTN6.Text = myReader["TravelDate"].ToString();
                    RBTN7.Text = myReader["ScheduleID"].ToString();
                }
                else
                {
                    RBTN2.Text = "";
                    RBTN3.Text = "";
                    RBTN4.Text = "";
                    RBTN5.Text = "";
                    RBTN6.Text = "";
                    RBTN7.Text = "";

                    MessageBox.Show("No Data Found");
                }

                myReader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        

        private void TInsBTN_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Reservation(ResID,PNRID,TrainID, SourceStation, DestinationStation, TravelDate, ScheduleID) " +
                                                "VALUES ('" + RBTN1.Text + "','" + RBTN2.Text + "', '" + RBTN3.Text + "','" + RBTN4.Text + "', '" + RBTN5.Text + "', '" + RBTN6.Text + "', '" + RBTN7.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertion Completed");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TShwBTN_Click_1(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                conn.Open();
                SqlCommand cmd3 = new SqlCommand("select * from Reservation", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmd3);
                ResList.DataSource = null;
                da.Fill(dt);
                ResList.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DTP1_ValueChanged(object sender, EventArgs e)
        {

        }

       

        private void RBTN2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void LoadPNRIDs()
        {
            try
            {
                conn.Open();
                string query = "SELECT PNRID FROM Passenger";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                RBTN2.Items.Clear(); // Clear previous items

                while (reader.Read())
                {
                    RBTN2.Items.Add(reader["PNRID"].ToString());
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
        private void LoadTrainIDs()
        {
            try
            {
                conn.Open();
                string query = "SELECT TrainID FROM TrainList";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                RBTN3.Items.Clear();

                while (reader.Read())
                {
                    RBTN3.Items.Add(reader["TrainID"].ToString());
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
        private void LoadSchIDs()
        {
            try
            {
                conn.Open();
                string query = "SELECT ScheduleID FROM Schedule";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                RBTN7.Items.Clear(); // Clear previous items

                while (reader.Read())
                {
                    RBTN7.Items.Add(reader["ScheduleID"].ToString());
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

        private void TDltBTN_Click_1(object sender, EventArgs e)
        {
            if (ResList.SelectedRows.Count > 0)
            {
                ResList.Rows.RemoveAt(ResList.SelectedRows[0].Index);
            }
            String Query = "delete from Reservation where ResID= '" + this.RBTN1.Text + "';";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();  // Use ExecuteNonQuery for DELETE queries
                MessageBox.Show("Deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TUpdBTN_Click_1(object sender, EventArgs e)
        {
            String Query = "update Reservation set  PNRID= '" + this.RBTN2.Text + "' , TrainID= '" + this.RBTN3.Text + "', SourceStation= '" + this.RBTN4.Text + "', DestinationStation= '" + this.RBTN5.Text + "', TravelDate= '" + this.RBTN6.Text + "', ScheduleID= '" + this.RBTN7.Text + "' Where ResID= '" + this.RBTN1.Text + "';";
            SqlCommand cmd = new SqlCommand(Query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();  // Use ExecuteNonQuery for UPDATE queries
                MessageBox.Show("Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ResList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)  // Ensure valid row index
            {
                index = e.RowIndex;
                DataGridViewRow row = ResList.Rows[index];

                RBTN1.Text = row.Cells[0].Value.ToString();
                RBTN2.Text = row.Cells[1].Value.ToString();
                RBTN3.Text = row.Cells[2].Value.ToString();
                RBTN4.Text = row.Cells[3].Value.ToString();
                RBTN5.Text = row.Cells[4].Value.ToString();

                if (row.Cells[5].Value != null && row.Cells[5].Value != DBNull.Value)
                {
                    DateTime dateValue;
                    if (DateTime.TryParse(row.Cells[5].Value.ToString(), out dateValue))
                    {
                        RBTN6.Value = dateValue;  // Assuming RBTN6 is a DateTimePicker
                    }
                }

                RBTN7.Text = row.Cells[6].Value.ToString();
            }
        }
    }
}














        

        

        


