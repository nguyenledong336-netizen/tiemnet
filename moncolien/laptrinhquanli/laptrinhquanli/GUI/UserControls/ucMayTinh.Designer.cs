namespace QuanLyTiemNet.GUI.UserControls
{
    partial class ucMayTinh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblTenMay = new System.Windows.Forms.Label();
            this.lblLoaiMay = new System.Windows.Forms.Label();
            this.lblDonGia = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.lblThongTinPhien = new System.Windows.Forms.Label();
            this.pnlStatusIndicator = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlStatusIndicator
            // 
            this.pnlStatusIndicator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusIndicator.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusIndicator.Name = "pnlStatusIndicator";
            this.pnlStatusIndicator.Size = new System.Drawing.Size(160, 6);
            this.pnlStatusIndicator.TabIndex = 0;
            // 
            // lblTenMay
            // 
            this.lblTenMay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lblTenMay.Location = new System.Drawing.Point(5, 12);
            this.lblTenMay.Name = "lblTenMay";
            this.lblTenMay.Size = new System.Drawing.Size(150, 26);
            this.lblTenMay.TabIndex = 1;
            this.lblTenMay.Text = "MÁY 01";
            this.lblTenMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoaiMay
            // 
            this.lblLoaiMay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoaiMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblLoaiMay.Location = new System.Drawing.Point(5, 38);
            this.lblLoaiMay.Name = "lblLoaiMay";
            this.lblLoaiMay.Size = new System.Drawing.Size(150, 18);
            this.lblLoaiMay.TabIndex = 2;
            this.lblLoaiMay.Text = "Thường";
            this.lblLoaiMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblDonGia.Location = new System.Drawing.Point(5, 58);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(150, 18);
            this.lblDonGia.TabIndex = 3;
            this.lblDonGia.Text = "10,000 đ/h";
            this.lblDonGia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrangThai.Location = new System.Drawing.Point(10, 80);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(140, 24);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "TRỐNG";
            this.lblTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThongTinPhien
            // 
            this.lblThongTinPhien.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinPhien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.lblThongTinPhien.Location = new System.Drawing.Point(5, 108);
            this.lblThongTinPhien.Name = "lblThongTinPhien";
            this.lblThongTinPhien.Size = new System.Drawing.Size(150, 30);
            this.lblThongTinPhien.TabIndex = 5;
            this.lblThongTinPhien.Text = "--:-- | 0 đ";
            this.lblThongTinPhien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucMayTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblThongTinPhien);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblDonGia);
            this.Controls.Add(this.lblLoaiMay);
            this.Controls.Add(this.lblTenMay);
            this.Controls.Add(this.pnlStatusIndicator);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "ucMayTinh";
            this.Size = new System.Drawing.Size(160, 145);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlStatusIndicator;
        private System.Windows.Forms.Label lblTenMay;
        private System.Windows.Forms.Label lblLoaiMay;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.Label lblThongTinPhien;
    }
}
