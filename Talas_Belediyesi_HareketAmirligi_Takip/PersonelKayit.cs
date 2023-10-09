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
    public partial class FrmPersonelKayit : Form
    {
        public FrmPersonelKayit()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            if (
                  txtAdi.Text == "" || txtSoyadi.Text == "" || txtKullaniciAdi.Text == "" || txtSifre.Text == "" || cbxGuvenlikSorusu.Text == "" || txtCevabi.Text == "" ||
                  txtAdi.Text == String.Empty || txtSoyadi.Text == String.Empty || txtKullaniciAdi.Text == String.Empty || txtSifre.Text == String.Empty || cbxGuvenlikSorusu.Text == String.Empty || txtCevabi.Text == String.Empty
               )
            {
                txtAdi.BackColor = Color.Yellow;
                txtSoyadi.BackColor = Color.Yellow;
                txtKullaniciAdi.BackColor = Color.Yellow;
                txtSifre.BackColor = Color.Yellow;
                cbxGuvenlikSorusu.BackColor = Color.Yellow;
                txtCevabi.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Tbl_KullaniciGirisi (ADI,SOYADI,KULLANICIADI,SIFRE,GUVENLIKSORUSU,SORUNUNCEVABI) VALUES (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
                komut.Parameters.AddWithValue("@p1", txtAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSoyadi.Text);
                komut.Parameters.AddWithValue("@p3", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p4", txtSifre.Text);
                komut.Parameters.AddWithValue("@p5", cbxGuvenlikSorusu.Text);
                komut.Parameters.AddWithValue("@p6", txtCevabi.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kullanıcı Bilgileri Kaydedildi", "Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
