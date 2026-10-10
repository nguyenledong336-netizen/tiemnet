using System;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.UserControls
{
    public partial class ucMayTinh : UserControl
    {
        public MayTinh MayTinh { get; private set; }
        public PhienSuDung PhienHienTai { get; private set; }

        public event EventHandler<MayTinh> MayTinhClicked;

        private bool _isSelected = false;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                CapNhatMauSac();
            }
        }

        public ucMayTinh()
        {
            InitializeComponent();
            GanSuKienClick(this);
        }

        private void GanSuKienClick(Control ctrl)
        {
            ctrl.Click += (s, e) => MayTinhClicked?.Invoke(this, MayTinh);
            foreach (Control child in ctrl.Controls)
            {
                GanSuKienClick(child);
            }
        }

        public void SetData(MayTinh mt, PhienSuDung phien = null)
        {
            MayTinh = mt;
            PhienHienTai = phien;

            if (MayTinh == null) return;

            lblTenMay.Text = MayTinh.TenMay;
            lblLoaiMay.Text = MayTinh.LoaiMay == "VIP" ? "PHÒNG VIP" : "PHÒNG THƯỜNG";
            lblDonGia.Text = $"{MayTinh.DonGiaGio:N0} đ/h";
            lblTrangThai.Text = MayTinh.TrangThai.ToUpper();

            if (MayTinh.TrangThai == "Đang sử dụng" && PhienHienTai != null)
            {
                TimeSpan duration = PhienHienTai.ThoiGianSuDung;
                decimal tienMay = PhienHienTai.TinhTienMayHienTai();
                lblThongTinPhien.Text = $"{duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}\n{tienMay:N0} đ";
                lblThongTinPhien.Visible = true;
            }
            else if (MayTinh.TrangThai == "Bảo trì")
            {
                lblThongTinPhien.Text = "Tạm ngưng phục vụ";
                lblThongTinPhien.Visible = true;
            }
            else
            {
                lblThongTinPhien.Text = "Sẵn sàng phục vụ";
                lblThongTinPhien.Visible = true;
            }

            CapNhatMauSac();
        }

        public void CapNhatDongHo()
        {
            if (MayTinh != null && MayTinh.TrangThai == "Đang sử dụng" && PhienHienTai != null)
            {
                TimeSpan duration = PhienHienTai.ThoiGianSuDung;
                decimal tienMay = PhienHienTai.TinhTienMayHienTai();
                lblThongTinPhien.Text = $"{duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}\n{tienMay:N0} đ";
            }
        }

        private void CapNhatMauSac()
        {
            if (MayTinh == null) return;

            Color backColor;
            Color statusColor;
            Color borderColor;

            if (MayTinh.TrangThai == "Đang sử dụng")
            {
                // Đỏ
                backColor = Color.FromArgb(255, 235, 238);
                statusColor = Color.FromArgb(198, 40, 40);
                borderColor = _isSelected ? Color.FromArgb(183, 28, 28) : Color.FromArgb(239, 154, 154);
            }
            else if (MayTinh.TrangThai == "Bảo trì")
            {
                // Vàng
                backColor = Color.FromArgb(255, 253, 231);
                statusColor = Color.FromArgb(245, 127, 23);
                borderColor = _isSelected ? Color.FromArgb(230, 81, 0) : Color.FromArgb(255, 224, 130);
            }
            else
            {
                // Trống -> Xanh lá
                backColor = Color.FromArgb(232, 245, 233);
                statusColor = Color.FromArgb(46, 125, 50);
                borderColor = _isSelected ? Color.FromArgb(27, 94, 32) : Color.FromArgb(165, 214, 167);
            }

            this.BackColor = backColor;
            pnlStatusIndicator.BackColor = statusColor;
            lblTrangThai.ForeColor = statusColor;

            if (_isSelected)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                this.BorderStyle = BorderStyle.FixedSingle;
            }
        }
    }
}
