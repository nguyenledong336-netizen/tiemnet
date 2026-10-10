namespace QuanLyTiemNet.GUI.Forms
{
    partial class frmThanhToan
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
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblValTongTien = new System.Windows.Forms.Label();
            this.lblTxtTongTien = new System.Windows.Forms.Label();
            this.lblValTienDichVu = new System.Windows.Forms.Label();
            this.lblTxtTienDichVu = new System.Windows.Forms.Label();
            this.lblValTienMay = new System.Windows.Forms.Label();
            this.lblTxtTienMay = new System.Windows.Forms.Label();
            this.lblValThoiGianSuDung = new System.Windows.Forms.Label();
            this.lblTxtThoiGianSuDung = new System.Windows.Forms.Label();
            this.lblValKetThuc = new System.Windows.Forms.Label();
            this.lblTxtKetThuc = new System.Windows.Forms.Label();
            this.lblValBatDau = new System.Windows.Forms.Label();
            this.lblTxtBatDau = new System.Windows.Forms.Label();
            this.lblValKhachHang = new System.Windows.Forms.Label();
            this.lblTxtKhachHang = new System.Windows.Forms.Label();
            this.lblValMay = new System.Windows.Forms.Label();
            this.lblTxtMay = new System.Windows.Forms.Label();
            this.grpDichVu = new System.Windows.Forms.GroupBox();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.colTenDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnXacNhanThanhToan = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.cmbPhuongThuc = new System.Windows.Forms.ComboBox();
            this.lblPhuongThuc = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.grpThongTin.SuspendLayout();
            this.grpDichVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(634, 55);
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
            this.lblTitle.Text = "THANH TOÁN PHIÊN CHƠI";
            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblValTongTien);
            this.grpThongTin.Controls.Add(this.lblTxtTongTien);
            this.grpThongTin.Controls.Add(this.lblValTienDichVu);
            this.grpThongTin.Controls.Add(this.lblTxtTienDichVu);
            this.grpThongTin.Controls.Add(this.lblValTienMay);
            this.grpThongTin.Controls.Add(this.lblTxtTienMay);
            this.grpThongTin.Controls.Add(this.lblValThoiGianSuDung);
            this.grpThongTin.Controls.Add(this.lblTxtThoiGianSuDung);
            this.grpThongTin.Controls.Add(this.lblValKetThuc);
            this.grpThongTin.Controls.Add(this.lblTxtKetThuc);
            this.grpThongTin.Controls.Add(this.lblValBatDau);
            this.grpThongTin.Controls.Add(this.lblTxtBatDau);
            this.grpThongTin.Controls.Add(this.lblValKhachHang);
            this.grpThongTin.Controls.Add(this.lblTxtKhachHang);
            this.grpThongTin.Controls.Add(this.lblValMay);
            this.grpThongTin.Controls.Add(this.lblTxtMay);
            this.grpThongTin.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpThongTin.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTin.Location = new System.Drawing.Point(0, 55);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(634, 185);
            this.grpThongTin.TabIndex = 1;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin chi tiết phiên";
            // 
            // lblValTongTien
            // 
            this.lblValTongTien.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblValTongTien.Location = new System.Drawing.Point(430, 142);
            this.lblValTongTien.Name = "lblValTongTien";
            this.lblValTongTien.Size = new System.Drawing.Size(185, 30);
            this.lblValTongTien.TabIndex = 15;
            this.lblValTongTien.Text = "0 đ";
            this.lblValTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtTongTien
            // 
            this.lblTxtTongTien.AutoSize = true;
            this.lblTxtTongTien.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtTongTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblTxtTongTien.Location = new System.Drawing.Point(320, 148);
            this.lblTxtTongTien.Name = "lblTxtTongTien";
            this.lblTxtTongTien.Size = new System.Drawing.Size(110, 21);
            this.lblTxtTongTien.TabIndex = 14;
            this.lblTxtTongTien.Text = "TỔNG CỘNG:";
            // 
            // lblValTienDichVu
            // 
            this.lblValTienDichVu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTienDichVu.Location = new System.Drawing.Point(430, 110);
            this.lblValTienDichVu.Name = "lblValTienDichVu";
            this.lblValTienDichVu.Size = new System.Drawing.Size(185, 20);
            this.lblValTienDichVu.TabIndex = 13;
            this.lblValTienDichVu.Text = "0 đ";
            this.lblValTienDichVu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtTienDichVu
            // 
            this.lblTxtTienDichVu.AutoSize = true;
            this.lblTxtTienDichVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtTienDichVu.Location = new System.Drawing.Point(320, 113);
            this.lblTxtTienDichVu.Name = "lblTxtTienDichVu";
            this.lblTxtTienDichVu.Size = new System.Drawing.Size(75, 15);
            this.lblTxtTienDichVu.TabIndex = 12;
            this.lblTxtTienDichVu.Text = "Tiền dịch vụ:";
            // 
            // lblValTienMay
            // 
            this.lblValTienMay.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTienMay.Location = new System.Drawing.Point(430, 75);
            this.lblValTienMay.Name = "lblValTienMay";
            this.lblValTienMay.Size = new System.Drawing.Size(185, 20);
            this.lblValTienMay.TabIndex = 11;
            this.lblValTienMay.Text = "0 đ";
            this.lblValTienMay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtTienMay
            // 
            this.lblTxtTienMay.AutoSize = true;
            this.lblTxtTienMay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtTienMay.Location = new System.Drawing.Point(320, 78);
            this.lblTxtTienMay.Name = "lblTxtTienMay";
            this.lblTxtTienMay.Size = new System.Drawing.Size(58, 15);
            this.lblTxtTienMay.TabIndex = 10;
            this.lblTxtTienMay.Text = "Tiền máy:";
            // 
            // lblValThoiGianSuDung
            // 
            this.lblValThoiGianSuDung.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValThoiGianSuDung.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblValThoiGianSuDung.Location = new System.Drawing.Point(430, 35);
            this.lblValThoiGianSuDung.Name = "lblValThoiGianSuDung";
            this.lblValThoiGianSuDung.Size = new System.Drawing.Size(185, 25);
            this.lblValThoiGianSuDung.TabIndex = 9;
            this.lblValThoiGianSuDung.Text = "00:00:00";
            this.lblValThoiGianSuDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTxtThoiGianSuDung
            // 
            this.lblTxtThoiGianSuDung.AutoSize = true;
            this.lblTxtThoiGianSuDung.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtThoiGianSuDung.Location = new System.Drawing.Point(320, 40);
            this.lblTxtThoiGianSuDung.Name = "lblTxtThoiGianSuDung";
            this.lblTxtThoiGianSuDung.Size = new System.Drawing.Size(104, 15);
            this.lblTxtThoiGianSuDung.TabIndex = 8;
            this.lblTxtThoiGianSuDung.Text = "Thời gian sử dụng:";
            // 
            // lblValKetThuc
            // 
            this.lblValKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValKetThuc.Location = new System.Drawing.Point(120, 148);
            this.lblValKetThuc.Name = "lblValKetThuc";
            this.lblValKetThuc.Size = new System.Drawing.Size(180, 20);
            this.lblValKetThuc.TabIndex = 7;
            this.lblValKetThuc.Text = "--:--:--";
            // 
            // lblTxtKetThuc
            // 
            this.lblTxtKetThuc.AutoSize = true;
            this.lblTxtKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtKetThuc.Location = new System.Drawing.Point(20, 148);
            this.lblTxtKetThuc.Name = "lblTxtKetThuc";
            this.lblTxtKetThuc.Size = new System.Drawing.Size(78, 15);
            this.lblTxtKetThuc.TabIndex = 6;
            this.lblTxtKetThuc.Text = "Giờ kết thúc:";
            // 
            // lblValBatDau
            // 
            this.lblValBatDau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValBatDau.Location = new System.Drawing.Point(120, 113);
            this.lblValBatDau.Name = "lblValBatDau";
            this.lblValBatDau.Size = new System.Drawing.Size(180, 20);
            this.lblValBatDau.TabIndex = 5;
            this.lblValBatDau.Text = "--:--:--";
            // 
            // lblTxtBatDau
            // 
            this.lblTxtBatDau.AutoSize = true;
            this.lblTxtBatDau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtBatDau.Location = new System.Drawing.Point(20, 113);
            this.lblTxtBatDau.Name = "lblTxtBatDau";
            this.lblTxtBatDau.Size = new System.Drawing.Size(74, 15);
            this.lblTxtBatDau.TabIndex = 4;
            this.lblTxtBatDau.Text = "Giờ bắt đầu:";
            // 
            // lblValKhachHang
            // 
            this.lblValKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValKhachHang.Location = new System.Drawing.Point(120, 75);
            this.lblValKhachHang.Name = "lblValKhachHang";
            this.lblValKhachHang.Size = new System.Drawing.Size(180, 20);
            this.lblValKhachHang.TabIndex = 3;
            this.lblValKhachHang.Text = "Khách Vãng Lai";
            // 
            // lblTxtKhachHang
            // 
            this.lblTxtKhachHang.AutoSize = true;
            this.lblTxtKhachHang.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtKhachHang.Location = new System.Drawing.Point(20, 78);
            this.lblTxtKhachHang.Name = "lblTxtKhachHang";
            this.lblTxtKhachHang.Size = new System.Drawing.Size(73, 15);
            this.lblTxtKhachHang.TabIndex = 2;
            this.lblTxtKhachHang.Text = "Khách hàng:";
            // 
            // lblValMay
            // 
            this.lblValMay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.lblValMay.Location = new System.Drawing.Point(120, 35);
            this.lblValMay.Name = "lblValMay";
            this.lblValMay.Size = new System.Drawing.Size(180, 25);
            this.lblValMay.TabIndex = 1;
            this.lblValMay.Text = "MÁY 01";
            // 
            // lblTxtMay
            // 
            this.lblTxtMay.AutoSize = true;
            this.lblTxtMay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxtMay.Location = new System.Drawing.Point(20, 40);
            this.lblTxtMay.Name = "lblTxtMay";
            this.lblTxtMay.Size = new System.Drawing.Size(56, 15);
            this.lblTxtMay.TabIndex = 0;
            this.lblTxtMay.Text = "Máy chơi:";
            // 
            // grpDichVu
            // 
            this.grpDichVu.Controls.Add(this.dgvDichVu);
            this.grpDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDichVu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDichVu.Location = new System.Drawing.Point(0, 240);
            this.grpDichVu.Name = "grpDichVu";
            this.grpDichVu.Size = new System.Drawing.Size(634, 186);
            this.grpDichVu.TabIndex = 2;
            this.grpDichVu.TabStop = false;
            this.grpDichVu.Text = "Chi tiết các dịch vụ đã sử dụng";
            // 
            // dgvDichVu
            // 
            this.dgvDichVu.AllowUserToAddRows = false;
            this.dgvDichVu.AllowUserToDeleteRows = false;
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDichVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTenDV,
            this.colSoLuong,
            this.colDonGia,
            this.colThanhTien});
            this.dgvDichVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDichVu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDichVu.Location = new System.Drawing.Point(3, 20);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.ReadOnly = true;
            this.dgvDichVu.RowHeadersVisible = false;
            this.dgvDichVu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVu.Size = new System.Drawing.Size(628, 163);
            this.dgvDichVu.TabIndex = 0;
            // 
            // colTenDV
            // 
            this.colTenDV.DataPropertyName = "TenDV";
            this.colTenDV.FillWeight = 140F;
            this.colTenDV.HeaderText = "Dịch vụ";
            this.colTenDV.Name = "colTenDV";
            this.colTenDV.ReadOnly = true;
            // 
            // colSoLuong
            // 
            this.colSoLuong.DataPropertyName = "SoLuong";
            this.colSoLuong.FillWeight = 50F;
            this.colSoLuong.HeaderText = "SL";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.FillWeight = 80F;
            this.colDonGia.HeaderText = "Đơn giá";
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colThanhTien
            // 
            this.colThanhTien.DataPropertyName = "ThanhTien";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.colThanhTien.DefaultCellStyle = dataGridViewCellStyle1;
            this.colThanhTien.FillWeight = 90F;
            this.colThanhTien.HeaderText = "Thành tiền (đ)";
            this.colThanhTien.Name = "colThanhTien";
            this.colThanhTien.ReadOnly = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.btnHuy);
            this.pnlBottom.Controls.Add(this.btnXacNhanThanhToan);
            this.pnlBottom.Controls.Add(this.txtGhiChu);
            this.pnlBottom.Controls.Add(this.lblGhiChu);
            this.pnlBottom.Controls.Add(this.cmbPhuongThuc);
            this.pnlBottom.Controls.Add(this.lblPhuongThuc);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBottom.Location = new System.Drawing.Point(0, 426);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(634, 115);
            this.pnlBottom.TabIndex = 3;
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuy.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnHuy.FlatAppearance.BorderSize = 0;
            this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(505, 60);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(105, 38);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // btnXacNhanThanhToan
            // 
            this.btnXacNhanThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXacNhanThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanThanhToan.FlatAppearance.BorderSize = 0;
            this.btnXacNhanThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanThanhToan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanThanhToan.Location = new System.Drawing.Point(300, 60);
            this.btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
            this.btnXacNhanThanhToan.Size = new System.Drawing.Size(195, 38);
            this.btnXacNhanThanhToan.TabIndex = 4;
            this.btnXacNhanThanhToan.Text = "💳 XÁC NHẬN THU TIỀN";
            this.btnXacNhanThanhToan.UseVisualStyleBackColor = false;
            this.btnXacNhanThanhToan.Click += new System.EventHandler(this.btnXacNhanThanhToan_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(300, 18);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(310, 23);
            this.txtGhiChu.TabIndex = 3;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(240, 22);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(51, 15);
            this.lblGhiChu.TabIndex = 2;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // cmbPhuongThuc
            // 
            this.cmbPhuongThuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhuongThuc.FormattingEnabled = true;
            this.cmbPhuongThuc.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cmbPhuongThuc.Location = new System.Drawing.Point(105, 18);
            this.cmbPhuongThuc.Name = "cmbPhuongThuc";
            this.cmbPhuongThuc.Size = new System.Drawing.Size(120, 23);
            this.cmbPhuongThuc.TabIndex = 1;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.AutoSize = true;
            this.lblPhuongThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuongThuc.Location = new System.Drawing.Point(18, 22);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(81, 15);
            this.lblPhuongThuc.TabIndex = 0;
            this.lblPhuongThuc.Text = "Phương thức:";
            // 
            // frmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(634, 541);
            this.Controls.Add(this.grpDichVu);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán phiên sử dụng";
            this.Load += new System.EventHandler(this.frmThanhToan_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            this.grpDichVu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVu)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTxtMay;
        private System.Windows.Forms.Label lblValMay;
        private System.Windows.Forms.Label lblTxtKhachHang;
        private System.Windows.Forms.Label lblValKhachHang;
        private System.Windows.Forms.Label lblTxtBatDau;
        private System.Windows.Forms.Label lblValBatDau;
        private System.Windows.Forms.Label lblTxtKetThuc;
        private System.Windows.Forms.Label lblValKetThuc;
        private System.Windows.Forms.Label lblTxtThoiGianSuDung;
        private System.Windows.Forms.Label lblValThoiGianSuDung;
        private System.Windows.Forms.Label lblTxtTienMay;
        private System.Windows.Forms.Label lblValTienMay;
        private System.Windows.Forms.Label lblTxtTienDichVu;
        private System.Windows.Forms.Label lblValTienDichVu;
        private System.Windows.Forms.Label lblTxtTongTien;
        private System.Windows.Forms.Label lblValTongTien;
        private System.Windows.Forms.GroupBox grpDichVu;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTien;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblPhuongThuc;
        private System.Windows.Forms.ComboBox cmbPhuongThuc;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnXacNhanThanhToan;
        private System.Windows.Forms.Button btnHuy;
    }
}
