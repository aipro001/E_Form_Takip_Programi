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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        BaglantiSinifi bgl = new BaglantiSinifi();

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (
                  txtKullaniciAdi.Text == "" || txtSifre.Text == "" ||
                  txtKullaniciAdi.Text == String.Empty || txtSifre.Text == String.Empty
               )
            {
                txtKullaniciAdi.BackColor = Color.Yellow;
                txtSifre.BackColor = Color.Yellow;
                MessageBox.Show("Sarı Rekli Alanları Boş Geçemezsiniz", "Boş Alan Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection baglanti = new SqlConnection(bgl.Adres);
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Select * From Tbl_KullaniciGirisi where KULLANICIADI=@p1 and SIFRE=@p2", baglanti);
                komut.Parameters.AddWithValue("@p1", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtSifre.Text);
                komut.ExecuteNonQuery();
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    FrmTakipPaneli fr = new FrmTakipPaneli();
                    fr.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre", "Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                baglanti.Close();
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            FrmPersonelKayit fr = new FrmPersonelKayit();
            fr.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifremiUnuttum fr = new FrmSifremiUnuttum();
            fr.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}