﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Railway_Reservation_System
{
    public partial class Passenger : Form
    {
        DataTable dt = new DataTable("Table");
        int index;
        public Passenger()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-G5VD7K3\SQLEXPRESS;Initial Catalog=Railway_Reservation_System;Integrated Security=True");



        private void TBTN2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TBTN8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TBTN10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Passenger_Load(object sender, EventArgs e)
        {
            
            PNRList.DataSource = dt;
        }

        private void TInsBTN_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Passenger(PNRID,UserName,Password, FirstName,LastName,ContactNumber,DoB,Gender,Email,Address,PostCode,Picture) Values ('" + PTB.Text + "','" + PTB1.Text + "', '" + PTB2.Text + "','" + PTB3.Text + "', '" + PTB4.Text + "', '" + PTB5.Text + "', '" + this.DTP1.Text + "', '" + RCB1.Text + "','" + PTB8.Text + "', '" + PTB9.Text + "', '" + PTB10.Text + "', '" + PPB1.Image + "')", conn);
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
            PPB1.Image.Save(st, pictureBox1.Image.RawFormat);
            return st.GetBuffer();
        }

        private void PInsPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PPB1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void TDltBTN_Click(object sender, EventArgs e)
        {
            if (PNRList.SelectedRows.Count > 0)
            {
                PNRList.Rows.RemoveAt(PNRList.SelectedRows[0].Index);
            }
            String Query = "delete from Passenger where PNRID= '" + this.PTB.Text + "';";
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

        private void PNRList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = PNRList.Rows[index];
            PTB.Text = row.Cells[0].Value.ToString();
            PTB1.Text = row.Cells[1].Value.ToString();
            PTB2.Text = row.Cells[2].Value.ToString();
            PTB3.Text = row.Cells[3].Value.ToString();
            PTB4.Text = row.Cells[4].Value.ToString();
            PTB5.Text = row.Cells[5].Value.ToString();
            DateTime dateValue;
            if (DateTime.TryParse(row.Cells[6].Value.ToString(), out dateValue))
            {
                DTP1.Value = dateValue;
            }
            RCB1.Text = row.Cells[7].Value.ToString();
            PTB8.Text = row.Cells[8].Value.ToString();
            PTB9.Text = row.Cells[9].Value.ToString();
            PTB10.Text = row.Cells[10].Value.ToString();
            if (row.Cells[11].Value is Image image)
            {
                PPB1.Image = image;
            }
            PNRList.DataError += PNRList_DataError_1;

        }
        private void PNRList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("An error occurred while displaying data: " + e.Exception.Message, "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false; 
        }

        private void TShwBTN_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Rows.Clear();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Passenger", conn);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                PNRList.DataSource = null;
                da.Fill(dt);
                PNRList.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TUpdBTN_Click(object sender, EventArgs e)
        {
            String Query = "update Passenger set UserName= '" + this.PTB1.Text + "', Password= '" + this.PTB2.Text + "' , FirstName= '" + this.PTB3.Text + "', LastName= '" + this.PTB4.Text + "', ContactNumber= '" + this.PTB5.Text + "', DoB= '" + this.DTP1.Text + "', Gender= '" + this.RCB1.Text + "', Email= '" + this.PTB8.Text + "' ,Address= '" + this.PTB9.Text + "', PostCode= '" + this.PTB10.Text + "'  Where PNRID= '" + this.PTB.Text + "';";
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
                SqlCommand cmd2 = new SqlCommand("SELECT UserName, Password, FirstName, LastName, ContactNumber, DoB, Gender, Email, Address, PostCode, Picture FROM Passenger WHERE PNRID = @idpar", conn);
                cmd2.Parameters.AddWithValue("@idpar", PTB.Text.Trim()); 

                SqlDataReader myReader = cmd2.ExecuteReader();

                if (myReader.Read()) 
                {
                    PTB1.Text = myReader["UserName"].ToString();
                    PTB2.Text = myReader["Password"].ToString();
                    PTB3.Text = myReader["FirstName"].ToString();
                    PTB4.Text = myReader["LastName"].ToString();
                    PTB5.Text = myReader["ContactNumber"].ToString();

                    
                    if (myReader["DoB"] != DBNull.Value)
                        DTP1.Value = Convert.ToDateTime(myReader["DoB"]);
                    else
                        DTP1.Value = DateTime.Now; 

                    
                    RCB1.SelectedItem = myReader["Gender"].ToString();

                    PTB8.Text = myReader["Email"].ToString();
                    PTB9.Text = myReader["Address"].ToString();
                    PTB10.Text = myReader["PostCode"].ToString();

                    
                    if (myReader["Picture"] != DBNull.Value)
                    {
                        byte[] imgData = (byte[])myReader["Picture"];
                        using (MemoryStream ms = new MemoryStream(imgData))
                        {
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBox1.Image = null; 
                    }
                }
                else 
                {
                    
                    PTB1.Text = "";
                    PTB2.Text = "";
                    PTB3.Text = "";
                    PTB4.Text = "";
                    PTB5.Text = "";
                    DTP1.Value = DateTime.Now; 
                    RCB1.SelectedIndex = -1; 
                    PTB8.Text = "";
                    PTB9.Text = "";
                    PTB10.Text = "";
                    pictureBox1.Image = null; 

                    MessageBox.Show("No Data Found for the given PNR ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void PNRList_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

            
            Console.WriteLine("DataGridView Error: " + e.Exception.Message);
        }
    }
}
