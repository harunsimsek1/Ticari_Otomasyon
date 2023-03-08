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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti()) ;
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturaıd.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",Txtserino.Text);
                komut.Parameters.AddWithValue("@p2", txtsiranosu.Text);
                komut.Parameters.AddWithValue("@p3", msktarih.Text);
                komut.Parameters.AddWithValue("@p4", msksaat.Text);
                komut.Parameters.AddWithValue("@p5", txtvergid.Text);
                komut.Parameters.AddWithValue("@p6", txtalıcı.Text);
                komut.Parameters.AddWithValue("@p7", txtteden.Text);
                komut.Parameters.AddWithValue("@p8", txttalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("FaturaBilgisi sisteme kaydedildi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                listele();
            }
            if (txtfaturaıd.Text != "" && comboBox1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = fiyat * miktar;
                txttutar.Text = tutar.ToString();
                SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)",bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",txturunad.Text);
                komut.Parameters.AddWithValue("@p2", txtmiktar.Text);
                komut.Parameters.AddWithValue("@p3", txtfiyat.Text);
                komut.Parameters.AddWithValue("@p4", txttutar.Text);
                komut.Parameters.AddWithValue("@p5", txtfaturaıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();


                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set adet=adet-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmiktar.Text);
                komut4.Parameters.AddWithValue("@s2", TxtId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }


      
            if (txtfaturaıd.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = fiyat * miktar;
                txttutar.Text = tutar.ToString();
                SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txturunad.Text);
                komut.Parameters.AddWithValue("@p2", txtmiktar.Text);
                komut.Parameters.AddWithValue("@p3", txtfiyat.Text);
                komut.Parameters.AddWithValue("@p4", txttutar.Text);
                komut.Parameters.AddWithValue("@p5", txtfaturaıd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                listele();
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set adet=adet-@s1 where ID=@s2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@s1", txtmiktar.Text);
                komut4.Parameters.AddWithValue("@s2", TxtId.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya ait ürün kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        void temizle()
        {
            TxtId.Text = "";
            txtsiranosu.Text = "";
            Txtserino.Text = "";
            msktarih.Text = "";
            msksaat.Text = "";
            txtalıcı.Text = "";
            txtteden.Text = "";
            txttalan.Text = "";
            txtvergid.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["FATURABILGIID"].ToString();
                txtsiranosu.Text = dr["SIRANO"].ToString();
                Txtserino.Text = dr["SERI"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                msksaat.Text = dr["SAAT"].ToString();
                txtalıcı.Text = dr["ALICI"].ToString();
                txtteden.Text = dr["TESLIMEDEN"].ToString();
                txttalan.Text = dr["TESLIMALAN"].ToString();
                txtvergid.Text = dr["VERGIDAIRE"].ToString();

            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FATURABILGI where FATURABILGIID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgileri silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI SET SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtserino.Text);
            komut.Parameters.AddWithValue("@p2", txtsiranosu.Text);
            komut.Parameters.AddWithValue("@p3", msktarih.Text);
            komut.Parameters.AddWithValue("@p4", msksaat.Text);
            komut.Parameters.AddWithValue("@p5", txtvergid.Text);
            komut.Parameters.AddWithValue("@p6", txtalıcı.Text);
            komut.Parameters.AddWithValue("@p7", txtteden.Text);
            komut.Parameters.AddWithValue("@p8", txttalan.Text);
            komut.Parameters.AddWithValue("@p9", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("FaturaBilgisi gÜNCELLENDİ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaÜrünDetay fr = new FrmFaturaÜrünDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }
    }
}
