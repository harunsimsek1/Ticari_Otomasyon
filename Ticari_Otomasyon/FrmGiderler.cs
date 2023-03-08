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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            giderlistesi();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER  (AY,YIL,ELEKTIRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Cmbay.Text);
            komut.Parameters.AddWithValue("@P2", Cmbyıl.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse( txtelektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtmaas.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(Txtekstra.Text));
            komut.Parameters.AddWithValue("@P9", Rchnotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Tabloya eklendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            temizle();
        }

        void temizle()
        {
            txtdogalgaz.Text = "";
            txtelektrik.Text = "";
            txtinternet.Text = "";
            txtmaas.Text = "";
            txtsu.Text = "";
            Txtekstra.Text = "";
            TxtId.Text = "";
            Rchnotlar.Text = "";
            Cmbay.Text = "";
            Cmbyıl.Text = "";
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtId.Text = dr["ID"].ToString();
                Cmbay.Text = dr["AY"].ToString();
                Cmbyıl.Text = dr["YIL"].ToString();
                txtelektrik.Text = dr["ELEKTIRIK"].ToString();
                txtsu.Text = dr["SU"].ToString();
                txtdogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtinternet.Text = dr["INTERNET"].ToString();
                txtmaas.Text = dr["MAASLAR"].ToString();
                Txtekstra.Text = dr["EKSTRA"].ToString();
                Rchnotlar.Text = dr["NOTLAR"].ToString();
                

            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from TBL_GIDERLER where ID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            giderlistesi();
            MessageBox.Show("Gider Listeden silindi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER SET AY=@P1,YIL=@P2,ELEKTIRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@p10",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Cmbay.Text);
            komut.Parameters.AddWithValue("@P2", Cmbyıl.Text);
            komut.Parameters.AddWithValue("@P3", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@P4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@P5", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(txtmaas.Text));
            komut.Parameters.AddWithValue("@P8", decimal.Parse(Txtekstra.Text));
            komut.Parameters.AddWithValue("@P9", Rchnotlar.Text);
            komut.Parameters.AddWithValue("@p10", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Tablosu Güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            giderlistesi();
            temizle();
        }
    }
}
