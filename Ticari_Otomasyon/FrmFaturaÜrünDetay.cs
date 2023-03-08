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
    public partial class FrmFaturaÜrünDetay : Form
    {
        public FrmFaturaÜrünDetay()
        {
            InitializeComponent();
        }
        public string id;
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURADETAY where FATURAID='" + id + "'", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmFaturaÜrünDetay_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaÜrünDüzünleme fr = new FrmFaturaÜrünDüzünleme();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.ürünid = dr["FATURAURUNID"].ToString();
            }
            fr.Show();
        }
    }
}
