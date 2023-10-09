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

namespace Talas_Belediyesi_HareketAmirligi_Takip
{
    public partial class FrmTakipPaneli : Form
    {
        public FrmTakipPaneli()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Listele()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_HareketAmirligi", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Listele1()
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_HareketAmirligiHizmetler", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void FrmTakipPaneli_Load(object sender, EventArgs e)
        {
            Listele();
            Listele1();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            Listele();
            Listele1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHizmetTuru.Text= dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtToplam.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKM.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPlaka.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSoforHizmeti.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtSoforAdi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            mskCikisSaat.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            mskGelisSaat.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtAciklama.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_HareketAmirligiHizmetler where TARIH like '%" + dateTimePicker1.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void txtAra1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(bgl.Adres);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_HareketAmirligiHizmetler where HIZMETTURLERI like '%" + txtAra1.Text + "%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

    }
}
