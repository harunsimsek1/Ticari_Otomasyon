using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient ;
using Ticari_Otomasyon;

namespace Icaria_Otomasyon
{
    public partial class FrmAyar : Form
    {
        public FrmAyar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADMIn",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAyar_Load(object sender, EventArgs e)
        {
            listele();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Kaydet")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values(@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni kayıt eklendi ", "BİLGİ");
                listele();
            }
            if (button1.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update TBL_ADMIN set sifre=@p2 where kullaniciad=@p1",bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", textBox1.Text);
                komut1.Parameters.AddWithValue("@p2", textBox2.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Yeni kayıt eklendi ", "BİLGİ");
                listele();
            }


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                textBox1.Text = dr["kullaniciad"].ToString();
                textBox2.Text = dr["sifre"].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text !="")
            {
                button1.Text = "Güncelle";
            }
            else
            {
                button1.Text = "Kaydet";
            }
        }
    }
}
