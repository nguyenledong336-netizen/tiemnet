namespace QuanLyTiemNet.GUI.Forms
{
    partial class frmLichLamViec
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
            this.pnlAction = new System.Windows.Forms.Panel();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXoaPhanCong = new System.Windows.Forms.Button();
            this.btnPhanCong = new System.Windows.Forms.Button();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.cmbCa = new System.Windows.Forms.ComboBox();
            this.lblCa = new System.Windows.Forms.Label();
            this.cmbThu = new System.Windows.Forms.ComboBox();
            this.lblThu = new System.Windows.Forms.Label();
            this.grpLichTuan = new System.Windows.Forms.GroupBox();
            this.dgvLichTuan = new System.Windows.Forms.DataGridView();
            this.colCa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThu7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChuNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlAction.SuspendLayout();
            this.grpLichTuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTuan)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(35)))), ((int)(((byte)(126)))));
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1040, 55);
            this.pnlTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(262, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH PHÂN CA TRONG TUẦN";
            // 
            // pnlAction
            // 
            this.pnlAction.BackColor = System.Drawing.Color.White;
            this.pnlAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAction.Controls.Add(this.btnLamMoi);
            this.pnlAction.Controls.Add(this.btnXoaPhanCong);
            this.pnlAction.Controls.Add(this.btnPhanCong);
            this.pnlAction.Controls.Add(this.cmbNhanVien);
            this.pnlAction.Controls.Add(this.lblNhanVien);
            this.pnlAction.Controls.Add(this.cmbCa);
            this.pnlAction.Controls.Add(this.lblCa);
            this.pnlAction.Controls.Add(this.cmbThu);
            this.pnlAction.Controls.Add(this.lblThu);
            this.pnlAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlAction.Location = new System.Drawing.Point(0, 55);
            this.pnlAction.Name = "pnlAction";
            this.pnlAction.Size = new System.Drawing.Size(1040, 65);
            this.pnlAction.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderSize = 0;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Location = new System.Drawing.Point(920, 16);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 32);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXoaPhanCong
            // 
            this.btnXoaPhanCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnXoaPhanCong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaPhanCong.FlatAppearance.BorderSize = 0;
            this.btnXoaPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhanCong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnXoaPhanCong.Location = new System.Drawing.Point(800, 16);
            this.btnXoaPhanCong.Name = "btnXoaPhanCong";
            this.btnXoaPhanCong.Size = new System.Drawing.Size(110, 32);
            this.btnXoaPhanCong.TabIndex = 7;
            this.btnXoaPhanCong.Text = "❌ Hủy ca này";
            this.btnXoaPhanCong.UseVisualStyleBackColor = false;
            this.btnXoaPhanCong.Click += new System.EventHandler(this.btnXoaPhanCong_Click);
            // 
            // btnPhanCong
            // 
            this.btnPhanCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.btnPhanCong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhanCong.FlatAppearance.BorderSize = 0;
            this.btnPhanCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPhanCong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhanCong.ForeColor = System.Drawing.Color.White;
            this.btnPhanCong.Location = new System.Drawing.Point(670, 16);
            this.btnPhanCong.Name = "btnPhanCong";
            this.btnPhanCong.Size = new System.Drawing.Size(120, 32);
            this.btnPhanCong.TabIndex = 6;
            this.btnPhanCong.Text = "💾 Lưu phân công";
            this.btnPhanCong.UseVisualStyleBackColor = false;
            this.btnPhanCong.Click += new System.EventHandler(this.btnPhanCong_Click);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(460, 21);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(190, 23);
            this.cmbNhanVien.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhanVien.Location = new System.Drawing.Point(390, 25);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(66, 15);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // cmbCa
            // 
            this.cmbCa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCa.FormattingEnabled = true;
            this.cmbCa.Location = new System.Drawing.Point(235, 21);
            this.cmbCa.Name = "cmbCa";
            this.cmbCa.Size = new System.Drawing.Size(140, 23);
            this.cmbCa.TabIndex = 3;
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCa.Location = new System.Drawing.Point(180, 25);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(51, 15);
            this.lblCa.TabIndex = 2;
            this.lblCa.Text = "Ca làm:";
            // 
            // cmbThu
            // 
            this.cmbThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThu.FormattingEnabled = true;
            this.cmbThu.Items.AddRange(new object[] {
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7",
            "Chủ nhật"});
            this.cmbThu.Location = new System.Drawing.Point(55, 21);
            this.cmbThu.Name = "cmbThu";
            this.cmbThu.Size = new System.Drawing.Size(110, 23);
            this.cmbThu.TabIndex = 1;
            // 
            // lblThu
            // 
            this.lblThu.AutoSize = true;
            this.lblThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThu.Location = new System.Drawing.Point(18, 25);
            this.lblThu.Name = "lblThu";
            this.lblThu.Size = new System.Drawing.Size(32, 15);
            this.lblThu.TabIndex = 0;
            this.lblThu.Text = "Thứ:";
            // 
            // grpLichTuan
            // 
            this.grpLichTuan.Controls.Add(this.dgvLichTuan);
            this.grpLichTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLichTuan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLichTuan.Location = new System.Drawing.Point(0, 120);
            this.grpLichTuan.Name = "grpLichTuan";
            this.grpLichTuan.Padding = new System.Windows.Forms.Padding(8);
            this.grpLichTuan.Size = new System.Drawing.Size(1040, 481);
            this.grpLichTuan.TabIndex = 2;
            this.grpLichTuan.TabStop = false;
            this.grpLichTuan.Text = "Lịch phân ca trực quan (Thứ 2 -> Chủ Nhật)";
            // 
            // dgvLichTuan
            // 
            this.dgvLichTuan.AllowUserToAddRows = false;
            this.dgvLichTuan.AllowUserToDeleteRows = false;
            this.dgvLichTuan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichTuan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichTuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichTuan.ColumnHeadersHeight = 35;
            this.dgvLichTuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCa,
            this.colThu2,
            this.colThu3,
            this.colThu4,
            this.colThu5,
            this.colThu6,
            this.colThu7,
            this.colChuNhat});
            this.dgvLichTuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichTuan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLichTuan.Location = new System.Drawing.Point(8, 25);
            this.dgvLichTuan.Name = "dgvLichTuan";
            this.dgvLichTuan.ReadOnly = true;
            this.dgvLichTuan.RowHeadersVisible = false;
            this.dgvLichTuan.RowTemplate.Height = 85;
            this.dgvLichTuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLichTuan.Size = new System.Drawing.Size(1024, 448);
            this.dgvLichTuan.TabIndex = 0;
            this.dgvLichTuan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichTuan_CellClick);
            this.dgvLichTuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichTuan_CellFormatting);
            // 
            // colCa
            // 
            this.colCa.FillWeight = 110F;
            this.colCa.HeaderText = "Ca làm việc";
            this.colCa.Name = "colCa";
            this.colCa.ReadOnly = true;
            // 
            // colThu2
            // 
            this.colThu2.HeaderText = "Thứ 2";
            this.colThu2.Name = "colThu2";
            this.colThu2.ReadOnly = true;
            // 
            // colThu3
            // 
            this.colThu3.HeaderText = "Thứ 3";
            this.colThu3.Name = "colThu3";
            this.colThu3.ReadOnly = true;
            // 
            // colThu4
            // 
            this.colThu4.HeaderText = "Thứ 4";
            this.colThu4.Name = "colThu4";
            this.colThu4.ReadOnly = true;
            // 
            // colThu5
            // 
            this.colThu5.HeaderText = "Thứ 5";
            this.colThu5.Name = "colThu5";
            this.colThu5.ReadOnly = true;
            // 
            // colThu6
            // 
            this.colThu6.HeaderText = "Thứ 6";
            this.colThu6.Name = "colThu6";
            this.colThu6.ReadOnly = true;
            // 
            // colThu7
            // 
            this.colThu7.HeaderText = "Thứ 7";
            this.colThu7.Name = "colThu7";
            this.colThu7.ReadOnly = true;
            // 
            // colChuNhat
            // 
            this.colChuNhat.HeaderText = "Chủ nhật";
            this.colChuNhat.Name = "colChuNhat";
            this.colChuNhat.ReadOnly = true;
            // 
            // frmLichLamViec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1040, 601);
            this.Controls.Add(this.grpLichTuan);
            this.Controls.Add(this.pnlAction);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmLichLamViec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lịch phân ca làm việc";
            this.Load += new System.EventHandler(this.frmLichLamViec_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlAction.ResumeLayout(false);
            this.pnlAction.PerformLayout();
            this.grpLichTuan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichTuan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlAction;
        private System.Windows.Forms.Label lblThu;
        private System.Windows.Forms.ComboBox cmbThu;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.ComboBox cmbCa;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Button btnPhanCong;
        private System.Windows.Forms.Button btnXoaPhanCong;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpLichTuan;
        private System.Windows.Forms.DataGridView dgvLichTuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCa;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThu7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChuNhat;
    }
}
