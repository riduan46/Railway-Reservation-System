﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railway_Reservation_System
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TBTN_Click(object sender, EventArgs e)
        {
            Trains trains = new Trains();
            trains.Show();
        }

        private void PBTN_Click(object sender, EventArgs e)
        {
            Passenger passenger = new Passenger();
            passenger.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void TvBTN_Click(object sender, EventArgs e)
        {
            Travel travel = new Travel();
            travel.Show();
        }

        private void ResBTN_Click(object sender, EventArgs e)
        {
            Reservation reservation = new Reservation();
            reservation.Show();
        }

        private void CanBTN_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
        }
    }
}
