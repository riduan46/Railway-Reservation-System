using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Reservation_System
{
    public partial class Travel : Form
    {
        public Travel()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("Table");
        int index;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");
        private void TInsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Schedule(ScheduleID,ScheduleCode,TrainID, StationName,ScheduleType,DepartureTime,ArrivalTime,TrainType) Values ('" + TBTN1.Text + "','" + TBTN2.Text + "', '" + TBTN3.Text + "','" + TBTN4.Text + "', '" + TBTN5.Text + "', '" + TBTN6.Text + "', '" + this.TBTN7.Text + "', '" + TBTN8.Text + "')", conn);
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
            if (SchList.SelectedRows.Count > 0)
            {
                SchList.Rows.RemoveAt(SchList.SelectedRows[0].Index);
            }
            String Query = "delete from Schedule where ScheduleID= '" + this.TBTN1.Text + "';";
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

        private void SchList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = SchList.Rows[index];
            TBTN1.Text = row.Cells[0].Value.ToString();
            TBTN2.Text = row.Cells[1].Value.ToString();
            TBTN3.Text = row.Cells[2].Value.ToString();
            TBTN4.Text = row.Cells[3].Value.ToString();
            TBTN5.Text = row.Cells[4].Value.ToString();
            TBTN6.Text = row.Cells[5].Value.ToString();
            TBTN7.Text = row.Cells[6].Value.ToString();
            TBTN8.Text = row.Cells[7].Value.ToString();
        }

        private void TUpdBTN_Click(object sender, EventArgs e)
        {
            String Query = "update Schedule set ScheduleID= '" + this.TBTN1.Text + "', ScheduleCode= '" + this.TBTN2.Text + "' , TrainID= '" + this.TBTN3.Text + "', StationName= '" + this.TBTN4.Text + "', ScheduleType= '" + this.TBTN5.Text + "', DepartureTime= '" + this.TBTN6.Text + "', ArrivalTime= '" + this.TBTN7.Text + "', TrainType= '" + this.TBTN8.Text + "' Where ScheduleID= '" + this.TBTN1.Text + "';";
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
                SqlCommand cmd = new SqlCommand("select * from Schedule", conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                SchList.DataSource = null;
                da.Fill(dt);
                SchList.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TSrhBTN_Click(object sender, EventArgs e)
        {
            try
            {
               
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT ScheduleID, ScheduleCode, TrainID, StationName, ScheduleType, DepartureTime, ArrivalTime, TrainType FROM Schedule WHERE ScheduleID = @idpar", conn);
                cmd2.Parameters.AddWithValue("@idpar", TBTN1.Text.Trim());

               
                SqlDataReader myReader = cmd2.ExecuteReader();

               
                if (myReader.Read())
                {
                    
                    
                    TBTN2.Text = myReader["ScheduleCode"].ToString();
                    TBTN3.Text = myReader["TrainID"].ToString();
                    TBTN4.Text = myReader["StationName"].ToString();
                    TBTN5.Text = myReader["ScheduleType"].ToString();
                    TBTN6.Text = myReader["DepartureTime"].ToString();
                    TBTN7.Text = myReader["ArrivalTime"].ToString();
                    TBTN8.Text = myReader["TrainType"].ToString();
                }
                else
                {
                    
                    TBTN1.Text = "";
                    TBTN2.Text = "";
                    TBTN3.Text = "";
                    TBTN4.Text = "";
                    TBTN5.Text = "";
                    TBTN6.Text = "";
                    TBTN7.Text = "";
                    TBTN8.Text = "";

                    
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

        private void Travel_Load(object sender, EventArgs e)
        {
            SchList.DataSource = dt;
        }
    }
    
}
