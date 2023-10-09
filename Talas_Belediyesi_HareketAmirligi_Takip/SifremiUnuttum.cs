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
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (
                  txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtAdi.Text == "" || txtSoyadi.Text == "" || cbxGuvenlikSorusu.Text == "" || txtID.Text == "" ||
                  txtKullaniciAdi.Text == String.Empty || txtSifre.Text == String.Empty || txtAdi.Text == String.Empty || txtSoyadi.Text == String.Empty || cbxGuvenlikSorusu.Text == String.Empty || txtID.Text == String.Empty
               )
            {
                txtKullaniciAdi.BackColor = Color.Yellow;
                txtSifre.BackColor = Color.Yellow;
                txtAdi.BackColor = Color.Yellow;
                txtSoyadi.BackColor = Color.Yellow;
                cbxGuvenlikSorusu.BackColor = Color.Yellow;
                txtCevabi.BackColor = Color.Yellow;
                txtID.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Tbl_KullaniciGirisi set KULLANICIADI=@P1, SIFRE=@P2, ADI=@P3, SOYADI=@P4, GUVENLIKSORUSU=@P5, SORUNUNCEVABI=@P6 WHERE ID=@P7", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.Parameters.AddWithValue("@p3", txtAdi.Text);
                komut.Parameters.AddWithValue("@p4", txtSoyadi.Text);
                komut.Parameters.AddWithValue("@p5", cbxGuvenlikSorusu.Text);
                komut.Parameters.AddWithValue("@p6", txtCevabi.Text);
                komut.Parameters.AddWithValue("@p7", txtID.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kullanıcı Bilgileri Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
                this.Controls.Clear();
                this.InitializeComponent();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }
    }
}
