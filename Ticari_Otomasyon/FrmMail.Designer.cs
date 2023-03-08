
namespace Icaria_Otomasyon
{
    partial class FrmMail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMail));
            this.label1 = new System.Windows.Forms.Label();
            this.txtmail = new DevExpress.XtraEditors.TextEdit();
            this.txtkonu = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.rchdetay = new System.Windows.Forms.RichTextBox();
            this.btngönder = new DevExpress.XtraEditors.SimpleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkonu.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mail Adresi:";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(150, 138);
            this.txtmail.Name = "txtmail";
            this.txtmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtmail.Properties.Appearance.Options.UseFont = true;
            this.txtmail.Size = new System.Drawing.Size(206, 30);
            this.txtmail.TabIndex = 1;
            // 
            // txtkonu
            // 
            this.txtkonu.Location = new System.Drawing.Point(150, 185);
            this.txtkonu.Name = "txtkonu";
            this.txtkonu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkonu.Properties.Appearance.Options.UseFont = true;
            this.txtkonu.Size = new System.Drawing.Size(206, 30);
            this.txtkonu.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Konu:";
            // 
            // rchdetay
            // 
            this.rchdetay.Location = new System.Drawing.Point(150, 230);
            this.rchdetay.Name = "rchdetay";
            this.rchdetay.Size = new System.Drawing.Size(206, 199);
            this.rchdetay.TabIndex = 4;
            this.rchdetay.Text = "";
            // 
            // btngönder
            // 
//            this.btngönder.ImageOptions.Image = global::Icaria_Otomasyon.Properties.Resources.send_32x32;
            this.btngönder.Location = new System.Drawing.Point(150, 435);
            this.btngönder.Name = "btngönder";
            this.btngönder.Size = new System.Drawing.Size(206, 35);
            this.btngönder.TabIndex = 5;
            this.btngönder.Text = "GÖNDER";
            this.btngönder.Click += new System.EventHandler(this.btngönder_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 131);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(73, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 26);
            this.label3.TabIndex = 0;
            this.label3.Text = "MAİL GÖNDERME PANELİ";
            // 
            // FrmMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 469);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btngönder);
            this.Controls.Add(this.rchdetay);
            this.Controls.Add(this.txtkonu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FrmMail";
            this.Text = "FrmMail";
            this.Load += new System.EventHandler(this.FrmMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtkonu.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtmail;
        private DevExpress.XtraEditors.TextEdit txtkonu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rchdetay;
        private DevExpress.XtraEditors.SimpleButton btngönder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
    }
}