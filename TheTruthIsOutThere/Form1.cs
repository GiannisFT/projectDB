using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TheTruthIsOutThere
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        dbConn db = new dbConn();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmb1.Items.Clear();
            cmb1.Items.Add("Show galaxies");
            cmb1.Items.Add("Show planets in Solar System");
            cmb1.Items.Add("Show planets size");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb1.SelectedItem)
            {
                case "Show planets in Solar System":
                    dt = db.SolarSystem();
                    dataGridView1.DataSource = dt;
                    break;
                case "Show planets size":
                    dt = db.GetPlanetsSize();
                    dataGridView1.DataSource = dt;
                    break;
                case "Show galaxies":
                    dt = db.GetGalaxies();
                    dataGridView1.DataSource = dt;
                    break;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Galaxy g = new Galaxy();
            g.Name = txtName.Text;
            g.Diameter = int.Parse(txtDiameter.Text);
            g.Stars = int.Parse(txtStars.Text);
            g.Planets = int.Parse(txtPlanets.Text);
            db.InsertGalaxy(g);
            txtName.Clear();
            txtDiameter.Clear();
            txtStars.Clear();
            txtPlanets.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
