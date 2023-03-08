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
using DevExpress.Charts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        sqlbaglantisi bgl = new sqlbaglantisi();
        public FrmKasa()
        {
            InitializeComponent();
        }
        void giderlistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {

        }
        void müsterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute müsterihareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void firmahareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute firmahareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }
        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            lblaktıfkullanıcı.Text = ad;
            müsterihareket();
            firmahareket();
            giderlistesi();

            SqlCommand komut1 = new SqlCommand("SELECT SUM(TUTAR) FROM TBL_FATURADETAY",bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblkasatoplam.Text = dr1[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut2 = new SqlCommand("SELECT (ELEKTIRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblödemeler.Text = dr2[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut3 = new SqlCommand("SELECT maaslar from tbl_GIDERLER order by ID asc", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblpermaas.Text = dr3[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut4 = new SqlCommand("SELECT count(*) from TBL_MUSTERILER", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblmusterisayısı.Text = dr4[0].ToString() + "TL";
            }
            bgl.baglanti().Close();

            SqlCommand komut5 = new SqlCommand("SELECT count(*) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblfirmasayısı.Text = dr5[0].ToString() ;
            }
            bgl.baglanti().Close();

            SqlCommand komut6 = new SqlCommand("SELECT count(distinct(IL)) from TBL_FIRMALAR", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehirsayısı.Text = dr6[0].ToString()  ;
            }
            bgl.baglanti().Close();


            SqlCommand komut7 = new SqlCommand("SELECT count(*) from TBL_Personel", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblpersonelsayısı.Text = dr7[0].ToString()  ;
            }
            bgl.baglanti().Close();

            SqlCommand komut8 = new SqlCommand("SELECT sum(adet) from TBL_URUNLER", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblstoksayısı.Text = dr8[0].ToString()  ;
            }
            bgl.baglanti().Close();


            SqlCommand komut10 = new SqlCommand("select top 4 ay, ELEKTIRIK from TBL_GIDERLER order by ID desc",bgl.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                chartControl1.Series["aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0],dr10[1]));
            }
            bgl.baglanti().Close();


            SqlCommand komut11 = new SqlCommand("select top 4 ay, Su from TBL_GIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl2.Series["aylar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bgl.baglanti().Close();
        }
    }
}
