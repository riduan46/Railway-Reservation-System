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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable("Table");
        int index;
        SqlConnection conn = new SqlConnection(@"Data Source=RIDUAN-AZIZ\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");
        private void TInsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Reservation(ResID,PNRID,TrainID, ScourceStaion,DestinationStation,TravelDate,ScheduleID) Values ('" + TBTN1.Text + "','" + TBTN2.Text + "', '" + TBTN3.Text + "','" + TBTN4.Text + "', '" + TBTN5.Text + "', '"+ TBTN10.Text +"', '" + TBTN6.Text + "')", conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Insertion Completed");
                TBTN1.Text = "";
                TBTN2.Text = "";
                TBTN3.Text = "";
                TBTN4.Text = "";
                TBTN5.Text = "";
                TBTN10.Text = "";
                TBTN6.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void TDltBTN_Click(object sender, EventArgs e)
        {
            if (ResList.SelectedRows.Count > 0)
            {
                ResList.Rows.RemoveAt(ResList.SelectedRows[0].Index);
            }
            String Query = "delete from Reservation where ResID= '" + this.TBTN1.Text + "';";
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
            DataGridViewRow row = ResList.Rows[index];
            TBTN1.Text = row.Cells[0].Value.ToString();
            TBTN2.Text = row.Cells[1].Value.ToString();
            TBTN3.Text = row.Cells[2].Value.ToString();
            TBTN4.Text = row.Cells[3].Value.ToString();
            TBTN5.Text = row.Cells[4].Value.ToString();
            TBTN10.Text = row.Cells[5].Value.ToString();
            TBTN6.Text = row.Cells[6].Value.ToString();
            
        }

        private void TUpdBTN_Click(object sender, EventArgs e)
        {
            String Query = "update Reservation set ResID= '" + this.TBTN1.Text + "', PNRID= '" + this.TBTN2.Text + "' , TrainID= '" + this.TBTN3.Text + "', SourceStation= '" + this.TBTN4.Text + "', DestinationStation= '" + this.TBTN5.Text + "', TravelDate= '" + this.TBTN10.Text + "', ScheduleID= '" + this.TBTN6.Text + "' Where ResID= '" + this.TBTN1.Text + "';";
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
                SqlCommand cmd = new SqlCommand("select * from Reservation", conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ResList.DataSource = null;
                da.Fill(dt);
                ResList.DataSource = dt;
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
            SqlCommand cmd2 = new SqlCommand("Select ResID,PNRID,TrainID,SourceStation,DestinationStation,TravelDate,ScheduleID from Reservation where ResID=@idpar", conn);
            cmd2.Parameters.AddWithValue("idpar", ResList.Text.Trim());
            SqlDataReader myReader;
            myReader = cmd2.ExecuteReader();
            if (myReader.Read())
            {
                TBTN1.Text = myReader["ResID"].ToString();
                TBTN2.Text = myReader["PNRID"].ToString();
                TBTN3.Text = myReader["TrainID"].ToString();
                TBTN4.Text = myReader["SourceStation"].ToString();
                TBTN5.Text = myReader["DestinationStation"].ToString();
                TBTN10.Text = myReader["TravelDate"].ToString();
                TBTN6.Text = myReader["ScheduleID"].ToString();
                


            }
            else
            {
                TBTN1.Text = "";
                TBTN2.Text = "";
                TBTN3.Text = "";
                TBTN4.Text = "";
                TBTN5.Text = "";
                TBTN10.Text = "";
                TBTN6.Text = "";
                

                MessageBox.Show("No Data Found");
            }
            conn.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DTP1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void TBTN6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reservation_Load(object sender, EventArgs e)
        {

        }
    }
}
