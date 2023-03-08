using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Icaria_Otomasyon
{
    public partial class FrmNotdetay : Form
    {
        public FrmNotdetay()
        {
            InitializeComponent();
        }
        public string metin;
        private void FrmNotdetay_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = metin;
        }
    }
}
