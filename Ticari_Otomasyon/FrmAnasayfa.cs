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
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void Stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select urunad, sum(adet) as 'adet' from TBL_URUNLER group by urunad having sum(adet)<=20 order by sum(adet)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            bgl.baglanti().Close();
        }
        void ajanda()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select top 15 tarıh,saat,baslık from TBL_NOTLAR order by ID desc", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
            bgl.baglanti().Close();
        }
        void Firmalistele()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da3.Fill(dt3);
            gridControl3.DataSource = dt3;
        }
        void fhist()
        {
            DataTable dt4 = new DataTable();
            SqlDataAdapter da4 = new SqlDataAdapter("select ad,telefon1 from TBL_FIRMALAR", bgl.baglanti());
            da4.Fill(dt4);
            gridControl4.DataSource = dt4;
        }
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.cnnturk.com/feed/rss/all/news");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {
            Stoklar();
            ajanda();
            Firmalistele();
            fhist();
            haberler();
            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");
        }
    }
}
