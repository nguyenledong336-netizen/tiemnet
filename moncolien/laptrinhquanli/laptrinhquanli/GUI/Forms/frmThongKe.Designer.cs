namespace QuanLyTiemNet.GUI.Forms
{
    partial class frmThongKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.btnXemBaoCao = new System.Windows.Forms.Button();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.cmbMocThoiGian = new System.Windows.Forms.ComboBox();
            this.lblMocThoiGian = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.pnlCardSoHoaDon = new System.Windows.Forms.Panel();
            this.lblValSoHoaDon = new System.Windows.Forms.Label();
            this.lblTieuDeSoHD = new System.Windows.Forms.Label();
            this.pnlCardSoPhien = new System.Windows.Forms.Panel();
            this.lblValSoPhien = new System.Windows.Forms.Label();
            this.lblTieuDeSoPhien = new System.Windows.Forms.Label();
            this.pnlCardDichVu = new System.Windows.Forms.Panel();
            this.lblValTienDV = new System.Windows.Forms.Label();
            this.lblTieuDeTienDV = new System.Windows.Forms.Label();
            this.pnlCardTienMay = new System.Windows.Forms.Panel();
            this.lblValTienMay = new System.Windows.Forms.Label();
            this.lblTieuDeTienMay = new System.Windows.Forms.Label();
            this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
            this.lblValDoanhThu = new System.Windows.Forms.Label();
            this.lblTieuDeDoanhThu = new System.Windows.Forms.Label();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.colMaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienMay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTienDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhuongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.pnlCardSoHoaDon.SuspendLayout();
            this.pnlCardSoPhien.SuspendLayout();
            this.pnlCardDichVu.SuspendLayout();
            this.pnlCardTienMay.SuspendLayout();
            this.pnlCardDoanhThu.SuspendLayout();
            this.grpChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1084, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(235, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÁO CÁO VÀ THỐNG KÊ";
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.btnXemBaoCao);
            this.pnlFilter.Controls.Add(this.dtpDenNgay);
            this.pnlFilter.Controls.Add(this.lblDenNgay);
            this.pnlFilter.Controls.Add(this.dtpTuNgay);
            this.pnlFilter.Controls.Add(this.lblTuNgay);
            this.pnlFilter.Controls.Add(this.cmbMocThoiGian);
            this.pnlFilter.Controls.Add(this.lblMocThoiGian);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlFilter.Location = new System.Drawing.Point(0, 55);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1084, 55);
            this.pnlFilter.TabIndex = 1;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.btnXemBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemBaoCao.FlatAppearance.BorderSize = 0;
            this.btnXemBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemBaoCao.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Location = new System.Drawing.Point(820, 11);
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(120, 30);
            this.btnXemBaoCao.TabIndex = 6;
            this.btnXemBaoCao.Text = "📊 Xem báo cáo";
            this.btnXemBaoCao.UseVisualStyleBackColor = false;
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(620, 15);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpDenNgay.TabIndex = 5;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(555, 19);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 15);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(395, 15);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 23);
            this.dtpTuNgay.TabIndex = 3;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(335, 19);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(52, 15);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // cmbMocThoiGian
            // 
            this.cmbMocThoiGian.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMocThoiGian.FormattingEnabled = true;
            this.cmbMocThoiGian.Items.AddRange(new object[] {
            "Hôm nay",
            "Hôm qua",
            "7 ngày qua",
            "Tháng này",
            "Tùy chọn"});
            this.cmbMocThoiGian.Location = new System.Drawing.Point(145, 15);
            this.cmbMocThoiGian.Name = "cmbMocThoiGian";
            this.cmbMocThoiGian.Size = new System.Drawing.Size(150, 23);
            this.cmbMocThoiGian.TabIndex = 1;
            this.cmbMocThoiGian.SelectedIndexChanged += new System.EventHandler(this.cmbMocThoiGian_SelectedIndexChanged);
            // 
            // lblMocThoiGian
            // 
            this.lblMocThoiGian.AutoSize = true;
            this.lblMocThoiGian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMocThoiGian.Location = new System.Drawing.Point(20, 19);
            this.lblMocThoiGian.Name = "lblMocThoiGian";
            this.lblMocThoiGian.Size = new System.Drawing.Size(116, 15);
            this.lblMocThoiGian.TabIndex = 0;
            this.lblMocThoiGian.Text = "Khoảng thời gian:";
            // 
            // pnlCards
            // 
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.pnlCards.Controls.Add(this.pnlCardSoHoaDon);
            this.pnlCards.Controls.Add(this.pnlCardSoPhien);
            this.pnlCards.Controls.Add(this.pnlCardDichVu);
            this.pnlCards.Controls.Add(this.pnlCardTienMay);
            this.pnlCards.Controls.Add(this.pnlCardDoanhThu);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCards.Location = new System.Drawing.Point(0, 110);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.pnlCards.Size = new System.Drawing.Size(1084, 105);
            this.pnlCards.TabIndex = 2;
            // 
            // pnlCardSoHoaDon
            // 
            this.pnlCardSoHoaDon.BackColor = System.Drawing.Color.White;
            this.pnlCardSoHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSoHoaDon.Controls.Add(this.lblValSoHoaDon);
            this.pnlCardSoHoaDon.Controls.Add(this.lblTieuDeSoHD);
            this.pnlCardSoHoaDon.Location = new System.Drawing.Point(860, 12);
            this.pnlCardSoHoaDon.Name = "pnlCardSoHoaDon";
            this.pnlCardSoHoaDon.Size = new System.Drawing.Size(195, 80);
            this.pnlCardSoHoaDon.TabIndex = 4;
            // 
            // lblValSoHoaDon
            // 
            this.lblValSoHoaDon.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValSoHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(20)))), ((int)(((byte)(140)))));
            this.lblValSoHoaDon.Location = new System.Drawing.Point(10, 35);
            this.lblValSoHoaDon.Name = "lblValSoHoaDon";
            this.lblValSoHoaDon.Size = new System.Drawing.Size(175, 30);
            this.lblValSoHoaDon.TabIndex = 1;
            this.lblValSoHoaDon.Text = "0";
            this.lblValSoHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeSoHD
            // 
            this.lblTieuDeSoHD.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeSoHD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTieuDeSoHD.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeSoHD.Name = "lblTieuDeSoHD";
            this.lblTieuDeSoHD.Size = new System.Drawing.Size(175, 20);
            this.lblTieuDeSoHD.TabIndex = 0;
            this.lblTieuDeSoHD.Text = "SỐ HÓA ĐƠN";
            this.lblTieuDeSoHD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardSoPhien
            // 
            this.pnlCardSoPhien.BackColor = System.Drawing.Color.White;
            this.pnlCardSoPhien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSoPhien.Controls.Add(this.lblValSoPhien);
            this.pnlCardSoPhien.Controls.Add(this.lblTieuDeSoPhien);
            this.pnlCardSoPhien.Location = new System.Drawing.Point(650, 12);
            this.pnlCardSoPhien.Name = "pnlCardSoPhien";
            this.pnlCardSoPhien.Size = new System.Drawing.Size(195, 80);
            this.pnlCardSoPhien.TabIndex = 3;
            // 
            // lblValSoPhien
            // 
            this.lblValSoPhien.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValSoPhien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.lblValSoPhien.Location = new System.Drawing.Point(10, 35);
            this.lblValSoPhien.Name = "lblValSoPhien";
            this.lblValSoPhien.Size = new System.Drawing.Size(175, 30);
            this.lblValSoPhien.TabIndex = 1;
            this.lblValSoPhien.Text = "0";
            this.lblValSoPhien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeSoPhien
            // 
            this.lblTieuDeSoPhien.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeSoPhien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTieuDeSoPhien.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeSoPhien.Name = "lblTieuDeSoPhien";
            this.lblTieuDeSoPhien.Size = new System.Drawing.Size(175, 20);
            this.lblTieuDeSoPhien.TabIndex = 0;
            this.lblTieuDeSoPhien.Text = "SỐ PHIÊN HOÀN TẤT";
            this.lblTieuDeSoPhien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardDichVu
            // 
            this.pnlCardDichVu.BackColor = System.Drawing.Color.White;
            this.pnlCardDichVu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDichVu.Controls.Add(this.lblValTienDV);
            this.pnlCardDichVu.Controls.Add(this.lblTieuDeTienDV);
            this.pnlCardDichVu.Location = new System.Drawing.Point(440, 12);
            this.pnlCardDichVu.Name = "pnlCardDichVu";
            this.pnlCardDichVu.Size = new System.Drawing.Size(195, 80);
            this.pnlCardDichVu.TabIndex = 2;
            // 
            // lblValTienDV
            // 
            this.lblValTienDV.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTienDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(81)))), ((int)(((byte)(0)))));
            this.lblValTienDV.Location = new System.Drawing.Point(5, 35);
            this.lblValTienDV.Name = "lblValTienDV";
            this.lblValTienDV.Size = new System.Drawing.Size(185, 30);
            this.lblValTienDV.TabIndex = 1;
            this.lblValTienDV.Text = "0 đ";
            this.lblValTienDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeTienDV
            // 
            this.lblTieuDeTienDV.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTienDV.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTieuDeTienDV.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeTienDV.Name = "lblTieuDeTienDV";
            this.lblTieuDeTienDV.Size = new System.Drawing.Size(175, 20);
            this.lblTieuDeTienDV.TabIndex = 0;
            this.lblTieuDeTienDV.Text = "TIỀN DỊCH VỤ";
            this.lblTieuDeTienDV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardTienMay
            // 
            this.pnlCardTienMay.BackColor = System.Drawing.Color.White;
            this.pnlCardTienMay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardTienMay.Controls.Add(this.lblValTienMay);
            this.pnlCardTienMay.Controls.Add(this.lblTieuDeTienMay);
            this.pnlCardTienMay.Location = new System.Drawing.Point(230, 12);
            this.pnlCardTienMay.Name = "pnlCardTienMay";
            this.pnlCardTienMay.Size = new System.Drawing.Size(195, 80);
            this.pnlCardTienMay.TabIndex = 1;
            // 
            // lblValTienMay
            // 
            this.lblValTienMay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValTienMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.lblValTienMay.Location = new System.Drawing.Point(5, 35);
            this.lblValTienMay.Name = "lblValTienMay";
            this.lblValTienMay.Size = new System.Drawing.Size(185, 30);
            this.lblValTienMay.TabIndex = 1;
            this.lblValTienMay.Text = "0 đ";
            this.lblValTienMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeTienMay
            // 
            this.lblTieuDeTienMay.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeTienMay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTieuDeTienMay.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeTienMay.Name = "lblTieuDeTienMay";
            this.lblTieuDeTienMay.Size = new System.Drawing.Size(175, 20);
            this.lblTieuDeTienMay.TabIndex = 0;
            this.lblTieuDeTienMay.Text = "TIỀN GIỜ CHƠI";
            this.lblTieuDeTienMay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCardDoanhThu
            // 
            this.pnlCardDoanhThu.BackColor = System.Drawing.Color.White;
            this.pnlCardDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardDoanhThu.Controls.Add(this.lblValDoanhThu);
            this.pnlCardDoanhThu.Controls.Add(this.lblTieuDeDoanhThu);
            this.pnlCardDoanhThu.Location = new System.Drawing.Point(20, 12);
            this.pnlCardDoanhThu.Name = "pnlCardDoanhThu";
            this.pnlCardDoanhThu.Size = new System.Drawing.Size(195, 80);
            this.pnlCardDoanhThu.TabIndex = 0;
            // 
            // lblValDoanhThu
            // 
            this.lblValDoanhThu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblValDoanhThu.Location = new System.Drawing.Point(5, 35);
            this.lblValDoanhThu.Name = "lblValDoanhThu";
            this.lblValDoanhThu.Size = new System.Drawing.Size(185, 30);
            this.lblValDoanhThu.TabIndex = 1;
            this.lblValDoanhThu.Text = "0 đ";
            this.lblValDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeDoanhThu
            // 
            this.lblTieuDeDoanhThu.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDeDoanhThu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblTieuDeDoanhThu.Location = new System.Drawing.Point(10, 10);
            this.lblTieuDeDoanhThu.Name = "lblTieuDeDoanhThu";
            this.lblTieuDeDoanhThu.Size = new System.Drawing.Size(175, 20);
            this.lblTieuDeDoanhThu.TabIndex = 0;
            this.lblTieuDeDoanhThu.Text = "TỔNG DOANH THU";
            this.lblTieuDeDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.dgvChiTiet);
            this.grpChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpChiTiet.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTiet.Location = new System.Drawing.Point(0, 215);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Size = new System.Drawing.Size(1084, 386);
            this.grpChiTiet.TabIndex = 3;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Danh sách hóa đơn trong kỳ báo cáo";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.AllowUserToAddRows = false;
            this.dgvChiTiet.AllowUserToDeleteRows = false;
            this.dgvChiTiet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTiet.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaHD,
            this.colTenMay,
            this.colTenKH,
            this.colTenNV,
            this.colNgayTao,
            this.colTienMay,
            this.colTienDV,
            this.colTongTien,
            this.colPhuongThuc});
            this.dgvChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTiet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChiTiet.Location = new System.Drawing.Point(3, 21);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.ReadOnly = true;
            this.dgvChiTiet.RowHeadersVisible = false;
            this.dgvChiTiet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTiet.Size = new System.Drawing.Size(1078, 362);
            this.dgvChiTiet.TabIndex = 0;
            // 
            // colMaHD
            // 
            this.colMaHD.DataPropertyName = "MaHD";
            this.colMaHD.FillWeight = 50F;
            this.colMaHD.HeaderText = "Mã HĐ";
            this.colMaHD.Name = "colMaHD";
            this.colMaHD.ReadOnly = true;
            // 
            // colTenMay
            // 
            this.colTenMay.DataPropertyName = "TenMay";
            this.colTenMay.FillWeight = 70F;
            this.colTenMay.HeaderText = "Máy";
            this.colTenMay.Name = "colTenMay";
            this.colTenMay.ReadOnly = true;
            // 
            // colTenKH
            // 
            this.colTenKH.DataPropertyName = "TenKhachHang";
            this.colTenKH.FillWeight = 110F;
            this.colTenKH.HeaderText = "Khách hàng";
            this.colTenKH.Name = "colTenKH";
            this.colTenKH.ReadOnly = true;
            // 
            // colTenNV
            // 
            this.colTenNV.DataPropertyName = "TenNhanVien";
            this.colTenNV.FillWeight = 110F;
            this.colTenNV.HeaderText = "Nhân viên";
            this.colTenNV.Name = "colTenNV";
            this.colTenNV.ReadOnly = true;
            // 
            // colNgayTao
            // 
            this.colNgayTao.DataPropertyName = "NgayTao";
            this.colNgayTao.FillWeight = 110F;
            this.colNgayTao.HeaderText = "Thời gian";
            this.colNgayTao.Name = "colNgayTao";
            this.colNgayTao.ReadOnly = true;
            // 
            // colTienMay
            // 
            this.colTienMay.DataPropertyName = "TienMay";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            this.colTienMay.DefaultCellStyle = dataGridViewCellStyle1;
            this.colTienMay.FillWeight = 85F;
            this.colTienMay.HeaderText = "Tiền máy (đ)";
            this.colTienMay.Name = "colTienMay";
            this.colTienMay.ReadOnly = true;
            // 
            // colTienDV
            // 
            this.colTienDV.DataPropertyName = "TienDichVu";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.colTienDV.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTienDV.FillWeight = 85F;
            this.colTienDV.HeaderText = "Tiền DV (đ)";
            this.colTienDV.Name = "colTienDV";
            this.colTienDV.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TongTien";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle3.Format = "N0";
            this.colTongTien.DefaultCellStyle = dataGridViewCellStyle3;
            this.colTongTien.FillWeight = 95F;
            this.colTongTien.HeaderText = "Tổng tiền (đ)";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colPhuongThuc
            // 
            this.colPhuongThuc.DataPropertyName = "PhuongThucThanhToan";
            this.colPhuongThuc.FillWeight = 80F;
            this.colPhuongThuc.HeaderText = "PT Thanh toán";
            this.colPhuongThuc.Name = "colPhuongThuc";
            this.colPhuongThuc.ReadOnly = true;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1084, 601);
            this.Controls.Add(this.grpChiTiet);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo thống kê doanh thu";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.pnlCards.ResumeLayout(false);
            this.pnlCardSoHoaDon.ResumeLayout(false);
            this.pnlCardSoPhien.ResumeLayout(false);
            this.pnlCardDichVu.ResumeLayout(false);
            this.pnlCardTienMay.ResumeLayout(false);
            this.pnlCardDoanhThu.ResumeLayout(false);
            this.grpChiTiet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblMocThoiGian;
        private System.Windows.Forms.ComboBox cmbMocThoiGian;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnXemBaoCao;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.Panel pnlCardDoanhThu;
        private System.Windows.Forms.Label lblTieuDeDoanhThu;
        private System.Windows.Forms.Label lblValDoanhThu;
        private System.Windows.Forms.Panel pnlCardTienMay;
        private System.Windows.Forms.Label lblTieuDeTienMay;
        private System.Windows.Forms.Label lblValTienMay;
        private System.Windows.Forms.Panel pnlCardDichVu;
        private System.Windows.Forms.Label lblTieuDeTienDV;
        private System.Windows.Forms.Label lblValTienDV;
        private System.Windows.Forms.Panel pnlCardSoPhien;
        private System.Windows.Forms.Label lblTieuDeSoPhien;
        private System.Windows.Forms.Label lblValSoPhien;
        private System.Windows.Forms.Panel pnlCardSoHoaDon;
        private System.Windows.Forms.Label lblTieuDeSoHD;
        private System.Windows.Forms.Label lblValSoHoaDon;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayTao;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienMay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTienDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongThuc;
    }
}
