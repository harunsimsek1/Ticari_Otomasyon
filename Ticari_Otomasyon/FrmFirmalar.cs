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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void FirmaListele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();

        }
        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from TBL_KODLAR",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchkod1detay.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            TxtAd.Text = "";
            TxtId.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
            TxtMail.Text = "";
            TxtSektor.Text = "";
            Txtvergid.Text = "";
            txtYetkılı.Text = "";
            txtygorev.Text = "";
            mskfax.Text = "";
            Msktc.Text = "";
            MskTel1.Text = "";
            MskTel2.Text = "";
            msktel3.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            
            Rchdetay.Text = "";
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListele();
            temizle();
            sehirlistesi();
            carikodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
               TxtAd.Text = dr["AD"].ToString();
                txtygorev.Text = dr["YETKILISTATU"].ToString();
                txtYetkılı.Text = dr["YETKILIADSOYAD"].ToString();
                Msktc.Text = dr["YETKILITC"].ToString();
                TxtSektor.Text = dr["SEKTOR"].ToString();
                MskTel1.Text = dr["TELEFON1"].ToString();
                MskTel2.Text = dr["TELEFON2"].ToString();
                msktel3.Text = dr["TELEFON3"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                mskfax.Text = dr["FAX"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                Txtvergid.Text = dr["VARGIDAIRE"].ToString();
                Rchdetay.Text = dr["ADRES"].ToString();
                rchkod1detay.Text = dr["OZELKOD1"].ToString();
                rchkod2detay.Text = dr["OZELKOD2"].ToString();
                rchkod3detay.Text = dr["OZELKOD3"].ToString();




            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VARGIDAIRE,ADRES,OZELKOD1,OZELKOD2,OZELKOD3) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtygorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkılı.Text);
            komut.Parameters.AddWithValue("@p4", Msktc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", MskTel2.Text);
            komut.Parameters.AddWithValue("@p8", msktel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskfax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbil.Text);
            komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", Txtvergid.Text);
            komut.Parameters.AddWithValue("@p14", Rchdetay.Text);
            komut.Parameters.AddWithValue("@p15", rchkod1detay.Text);
            komut.Parameters.AddWithValue("@p16", rchkod2detay.Text);
            komut.Parameters.AddWithValue("@p17", rchkod3detay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            temizle();
          


        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_FIRMALAR where ID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            FirmaListele();
            MessageBox.Show("Firma Sistemden silimndi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR SET AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,IL=@P11,ILCE=@P12,FAX=@P10,VARGIDAIRE=@P13,ADRES=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 WHERE ID=@P18",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtygorev.Text);
            komut.Parameters.AddWithValue("@p3", txtYetkılı.Text);
            komut.Parameters.AddWithValue("@p4", Msktc.Text);
            komut.Parameters.AddWithValue("@p5", TxtSektor.Text);
            komut.Parameters.AddWithValue("@p6", MskTel1.Text);
            komut.Parameters.AddWithValue("@p7", MskTel2.Text);
            komut.Parameters.AddWithValue("@p8", msktel3.Text);
            komut.Parameters.AddWithValue("@p9", TxtMail.Text);
            komut.Parameters.AddWithValue("@p10", mskfax.Text);
            komut.Parameters.AddWithValue("@p11", Cmbil.Text);
            komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komut.Parameters.AddWithValue("@p13", Txtvergid.Text);
            komut.Parameters.AddWithValue("@p14", Rchdetay.Text);
            komut.Parameters.AddWithValue("@p15", rchkod1detay.Text);
            komut.Parameters.AddWithValue("@p16", rchkod2detay.Text);
            komut.Parameters.AddWithValue("@p17", rchkod3detay.Text);
            komut.Parameters.AddWithValue("@P18", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sistemde güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListele();
            temizle();
        }
    }
}
