namespace QuanLyTiemNet.GUI.Forms
{
    partial class frmChamCong
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpChamCongNhanh = new System.Windows.Forms.GroupBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.btnChamCongRa = new System.Windows.Forms.Button();
            this.btnChamCongVao = new System.Windows.Forms.Button();
            this.lblDongHoHienTai = new System.Windows.Forms.Label();
            this.grpDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvChamCong = new System.Windows.Forms.DataGridView();
            this.colMaChamCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioVao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGioRa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoGioLam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnXemTatCa = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpChamCongNhanh.SuspendLayout();
            this.grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(984, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHẤM CÔNG NHÂN VIÊN";
            // 
            // grpChamCongNhanh
            // 
            this.grpChamCongNhanh.Controls.Add(this.txtGhiChu);
            this.grpChamCongNhanh.Controls.Add(this.lblGhiChu);
            this.grpChamCongNhanh.Controls.Add(this.btnChamCongRa);
            this.grpChamCongNhanh.Controls.Add(this.btnChamCongVao);
            this.grpChamCongNhanh.Controls.Add(this.lblDongHoHienTai);
            this.grpChamCongNhanh.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpChamCongNhanh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChamCongNhanh.Location = new System.Drawing.Point(0, 55);
            this.grpChamCongNhanh.Name = "grpChamCongNhanh";
            this.grpChamCongNhanh.Size = new System.Drawing.Size(984, 110);
            this.grpChamCongNhanh.TabIndex = 1;
            this.grpChamCongNhanh.TabStop = false;
            this.grpChamCongNhanh.Text = "Ghi nhận giờ làm việc hôm nay";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(340, 58);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(280, 23);
            this.txtGhiChu.TabIndex = 4;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGhiChu.Location = new System.Drawing.Point(340, 35);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 15);
            this.lblGhiChu.TabIndex = 3;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // btnChamCongRa
            // 
            this.btnChamCongRa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnChamCongRa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChamCongRa.FlatAppearance.BorderSize = 0;
            this.btnChamCongRa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamCongRa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamCongRa.ForeColor = System.Drawing.Color.White;
            this.btnChamCongRa.Location = new System.Drawing.Point(800, 38);
            this.btnChamCongRa.Name = "btnChamCongRa";
            this.btnChamCongRa.Size = new System.Drawing.Size(155, 45);
            this.btnChamCongRa.TabIndex = 2;
            this.btnChamCongRa.Text = "🚪  CHẤM CÔNG RA";
            this.btnChamCongRa.UseVisualStyleBackColor = false;
            this.btnChamCongRa.Click += new System.EventHandler(this.btnChamCongRa_Click);
            // 
            // btnChamCongVao
            // 
            this.btnChamCongVao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnChamCongVao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChamCongVao.FlatAppearance.BorderSize = 0;
            this.btnChamCongVao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChamCongVao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChamCongVao.ForeColor = System.Drawing.Color.White;
            this.btnChamCongVao.Location = new System.Drawing.Point(635, 38);
            this.btnChamCongVao.Name = "btnChamCongVao";
            this.btnChamCongVao.Size = new System.Drawing.Size(155, 45);
            this.btnChamCongVao.TabIndex = 1;
            this.btnChamCongVao.Text = "⏰  CHẤM CÔNG VÀO";
            this.btnChamCongVao.UseVisualStyleBackColor = false;
            this.btnChamCongVao.Click += new System.EventHandler(this.btnChamCongVao_Click);
            // 
            // lblDongHoHienTai
            // 
            this.lblDongHoHienTai.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDongHoHienTai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.lblDongHoHienTai.Location = new System.Drawing.Point(20, 35);
            this.lblDongHoHienTai.Name = "lblDongHoHienTai";
            this.lblDongHoHienTai.Size = new System.Drawing.Size(300, 50);
            this.lblDongHoHienTai.TabIndex = 0;
            this.lblDongHoHienTai.Text = "Hôm nay: 22/09/2026\nThời gian: --:--:--";
            this.lblDongHoHienTai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpDanhSach
            // 
            this.grpDanhSach.Controls.Add(this.dgvChamCong);
            this.grpDanhSach.Controls.Add(this.pnlFilter);
            this.grpDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDanhSach.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDanhSach.Location = new System.Drawing.Point(0, 165);
            this.grpDanhSach.Name = "grpDanhSach";
            this.grpDanhSach.Size = new System.Drawing.Size(984, 436);
            this.grpDanhSach.TabIndex = 2;
            this.grpDanhSach.TabStop = false;
            this.grpDanhSach.Text = "Lịch sử chấm công";
            // 
            // dgvChamCong
            // 
            this.dgvChamCong.AllowUserToAddRows = false;
            this.dgvChamCong.AllowUserToDeleteRows = false;
            this.dgvChamCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChamCong.BackgroundColor = System.Drawing.Color.White;
            this.dgvChamCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChamCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaChamCong,
            this.colTenNV,
            this.colNgay,
            this.colGioVao,
            this.colGioRa,
            this.colSoGioLam,
            this.colTrangThai,
            this.colGhiChu});
            this.dgvChamCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChamCong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChamCong.Location = new System.Drawing.Point(3, 71);
            this.dgvChamCong.Name = "dgvChamCong";
            this.dgvChamCong.ReadOnly = true;
            this.dgvChamCong.RowHeadersVisible = false;
            this.dgvChamCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChamCong.Size = new System.Drawing.Size(978, 362);
            this.dgvChamCong.TabIndex = 1;
            // 
            // colMaChamCong
            // 
            this.colMaChamCong.DataPropertyName = "MaChamCong";
            this.colMaChamCong.FillWeight = 60F;
            this.colMaChamCong.HeaderText = "Mã";
            this.colMaChamCong.Name = "colMaChamCong";
            this.colMaChamCong.ReadOnly = true;
            // 
            // colTenNV
            // 
            this.colTenNV.DataPropertyName = "TenNhanVien";
            this.colTenNV.FillWeight = 120F;
            this.colTenNV.HeaderText = "Nhân viên";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.ReadOnly = true;
            // 
            // colNgay
            // 
            this.colNgay.DataPropertyName = "Ngay";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy";
            this.colNgay.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colGioVao
            // 
            this.colGioVao.DataPropertyName = "GioVao";
            this.colGioVao.HeaderText = "Giờ vào";
            this.colGioVao.Name = "colGioVao";
            this.colGioVao.ReadOnly = true;
            // 
            // colGioRa
            // 
            this.colGioRa.DataPropertyName = "GioRa";
            this.colGioRa.HeaderText = "Giờ ra";
            this.colGioRa.Name = "colGioRa";
            this.colGioRa.ReadOnly = true;
            // 
            // colSoGioLam
            // 
            this.colSoGioLam.DataPropertyName = "SoGioLam";
            this.colSoGioLam.FillWeight = 80F;
            this.colSoGioLam.HeaderText = "Số giờ làm";
            this.colSoGioLam.Name = "colSoGioLam";
            this.colSoGioLam.ReadOnly = true;
            // 
            // colTrangThai
            // 
            this.colTrangThai.DataPropertyName = "TrangThai";
            this.colTrangThai.HeaderText = "Trạng thái";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.ReadOnly = true;
            // 
            // colGhiChu
            // 
            this.colGhiChu.DataPropertyName = "GhiChu";
            this.colGhiChu.FillWeight = 120F;
            this.colGhiChu.HeaderText = "Ghi chú";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.ReadOnly = true;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.btnXemTatCa);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Controls.Add(this.cmbNhanVien);
            this.pnlFilter.Controls.Add(this.lblNhanVien);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.Location = new System.Drawing.Point(3, 21);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(978, 50);
            this.pnlFilter.TabIndex = 0;
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnXemTatCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemTatCa.FlatAppearance.BorderSize = 0;
            this.btnXemTatCa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemTatCa.Location = new System.Drawing.Point(760, 12);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(100, 26);
            this.btnXemTatCa.TabIndex = 6;
            this.btnXemTatCa.Text = "🔄 Xem tất cả";
            this.btnXemTatCa.UseVisualStyleBackColor = false;
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(605, 14);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpDenNgay.TabIndex = 5;
            this.dtpDenNgay.ValueChanged += new System.EventHandler(this.BoLoc_Changed);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(540, 18);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(395, 14);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpTuNgay.TabIndex = 3;
            this.dtpTuNgay.ValueChanged += new System.EventHandler(this.BoLoc_Changed);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(335, 18);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(125, 14);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(190, 23);
            this.cmbNhanVien.TabIndex = 1;
            this.cmbNhanVien.SelectedIndexChanged += new System.EventHandler(this.cmbNhanVien_SelectedIndexChanged);
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Location = new System.Drawing.Point(15, 18);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(95, 15);
            this.lblNhanVien.TabIndex = 0;
            this.lblNhanVien.Text = "Chọn nhân viên:";
            // 
            // frmChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 601);
            this.Controls.Add(this.grpDanhSach);
            this.Controls.Add(this.grpChamCongNhanh);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chấm công nhân viên";
            this.Load += new System.EventHandler(this.frmChamCong_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpChamCongNhanh.ResumeLayout(false);
            this.grpChamCongNhanh.PerformLayout();
            this.grpDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChamCong)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpChamCongNhanh;
        private System.Windows.Forms.Label lblDongHoHienTai;
        private System.Windows.Forms.Button btnChamCongVao;
        private System.Windows.Forms.Button btnChamCongRa;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.GroupBox grpDanhSach;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemTatCa;
        private System.Windows.Forms.DataGridView dgvChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaChamCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioVao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGioRa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoGioLam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGhiChu;
    }
}
