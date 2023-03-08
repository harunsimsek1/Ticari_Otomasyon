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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Turquoise;
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBL_ADMIN where kullaniciad=@p1 and sifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textEdit1.Text);
            komut.Parameters.AddWithValue("@p2", textEdit2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnamodül fr = new FrmAnamodül();
                fr.kullanici = textEdit1.Text;
                fr.Show();
                    this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Şifre Veya KullanıAdı!!!");

            }
            bgl.baglanti().Close();

        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
