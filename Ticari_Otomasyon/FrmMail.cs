﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Icaria_Otomasyon
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        public string mail;
        private void FrmMail_Load(object sender, EventArgs e)
        {
            txtmail.Text = mail;
        }

        private void btngönder_Click(object sender, EventArgs e)
        {
            MailMessage mesaj=new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mail", "sifre");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(rchdetay.Text);
            mesaj.From = new MailAddress(txtmail.Text);
            mesaj.Subject = txtkonu.Text;
            mesaj.Body = rchdetay.Text;
            istemci.Send(mesaj);
        }
    }
}
