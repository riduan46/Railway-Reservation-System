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
    public partial class Trains : Form
    {
        DataTable dt = new DataTable("Table");
        int index;
        public Trains()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");

        private void TInsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TrainList(TrainID,TrainCode,TrainName,RouteFrom,RouteTo,TrainType,TotalSeats,DepartureTime,ArrivalTime,TicketFare) Values ('" + TTB1.Text + "','" + TTB2.Text + "', '" + TTB3.Text + "','" + TTB4.Text + "', '" + TTB5.Text + "', '" + TTB6.Text + "', '" + TTB7.Text + "', '" + TTB8.Text + "','" + TTB9.Text + "', '" + TTB10.Text + "')", conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Train Information Inserted"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();

        }

        private void Trains_Load(object sender, EventArgs e)
        {
            TrainList.DataSource = dt;
        }

        private void TTB9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void TTB8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void TTB7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TShwBTN_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from TrainList", conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                TrainList.DataSource = null;
                da.Fill(dt);
                TrainList.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TrainList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = TrainList.Rows[index];
            TTB1.Text = row.Cells[0].Value.ToString();
            TTB2.Text = row.Cells[1].Value.ToString();
            TTB3.Text = row.Cells[2].Value.ToString();
            TTB4.Text = row.Cells[3].Value.ToString();
            TTB5.Text = row.Cells[4].Value.ToString();
            TTB6.Text = row.Cells[5].Value.ToString();
            TTB7.Text = row.Cells[6].Value.ToString();
            TTB8.Text = row.Cells[7].Value.ToString();
            TTB9.Text = row.Cells[8].Value.ToString();
            TTB10.Text = row.Cells[9].Value.ToString();
        }

        private void TDltBTN_Click(object sender, EventArgs e)
        {
            if (TrainList.SelectedRows.Count > 0)
            {
                TrainList.Rows.RemoveAt(TrainList.SelectedRows[0].Index);
            }
            String Query = "delete from TrainList where TrainID= '" + this.TTB1.Text + "';";
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

        private void TUpdBTN_Click(object sender, EventArgs e)
        {
            String Query = "update TrainList set TrainCode= '" + this. TTB2.Text + "', TrainName= '" + this.TTB3.Text + "' , RouteFrom= '" + this.TTB4.Text + "', RouteTo= '" + this.TTB5.Text + "', TrainType= '" + this.TTB6.Text + "', TotalSeats= '" + this.TTB7.Text + "', DepartureTime= '" + this.TTB8.Text + "',ArrivalTime= '" + this.TTB9.Text + "' , TicketFare= '" + this.TTB10.Text + "'  Where TrainID= '" + this.TTB1.Text + "';";
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

        private void TSrhBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT TrainCode, TrainName, RouteFrom, RouteTo, TrainType, TotalSeats, DepartureTime, ArrivalTime, TicketFare FROM TrainList WHERE TrainID = @idpar", conn);
                cmd2.Parameters.AddWithValue("@idpar", TTB1.Text.Trim()); 

                SqlDataReader myReader = cmd2.ExecuteReader();

                if (myReader.Read()) 
                {
                    TTB2.Text = myReader["TrainCode"].ToString();
                    TTB3.Text = myReader["TrainName"].ToString();
                    TTB4.Text = myReader["RouteFrom"].ToString();
                    TTB5.Text = myReader["RouteTo"].ToString();
                    TTB6.Text = myReader["TrainType"].ToString();
                    TTB7.Text = myReader["TotalSeats"].ToString();
                    TTB8.Text = myReader["DepartureTime"].ToString();
                    TTB9.Text = myReader["ArrivalTime"].ToString();
                    TTB10.Text = myReader["TicketFare"].ToString();
                }
                else 
                {
                    
                    TTB2.Text = "";
                    TTB3.Text = "";
                    TTB4.Text = "";
                    TTB5.Text = "";
                    TTB6.Text = "";
                    TTB7.Text = "";
                    TTB8.Text = "";
                    TTB9.Text = "";
                    TTB10.Text = "";

                    MessageBox.Show("No Data Found for the given Train ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                myReader.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); 
            }


        }
    }
}
