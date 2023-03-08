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
using Ticari_Otomasyon;

namespace Icaria_Otomasyon
{
    public partial class FrmFaturaÜrünDüzünleme : Form
    {
        public FrmFaturaÜrünDüzünleme()
        {
            InitializeComponent();
        }
        public string ürünid;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmFaturaÜrünDüzünleme_Load(object sender, EventArgs e)
        {
            txturunıd.Text = ürünid;
            SqlCommand komut = new SqlCommand("select * from TBL_FATURADETAY where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txturunıd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtfiyat.Text = dr[3].ToString();
                txtmiktar.Text = dr[2].ToString();
                txttutar.Text = dr[4].ToString();
                txturunad.Text = dr[1].ToString();
                bgl.baglanti().Close();


            }

        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY SET URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 WHERE FATURAURUNID=@P5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",txturunad.Text);
            komut.Parameters.AddWithValue("@p2", double.Parse( txtmiktar.Text));
            komut.Parameters.AddWithValue("@p3", double.Parse (txtfiyat.Text));
            komut.Parameters.AddWithValue("@p4", double.Parse( txttutar.Text));
            komut.Parameters.AddWithValue("@p5", txturunıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Üründeki değişiklikler kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FATURADETAY where FATURAURUNID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txturunıd.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
