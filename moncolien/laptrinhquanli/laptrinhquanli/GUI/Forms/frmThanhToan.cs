using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmThanhToan : Form
    {
        private readonly int _maPhien;
        private readonly IPhienSuDungDAL _phienDAL;
        private readonly IChiTietDichVuDAL _chiTietDichVuDAL;
        private readonly IHoaDonDAL _hoaDonDAL;
        private readonly IKhachHangDAL _khachHangDAL;

        private PhienSuDung _phien;
        private decimal _tienMay;
        private decimal _tienDichVu;
        private decimal _tongTien;
        private DateTime _thoiGianKetThuc;

        public frmThanhToan(int maPhien)
        {
            InitializeComponent();
            _maPhien = maPhien;
            _phienDAL = new PhienSuDungDAL();
            _chiTietDichVuDAL = new ChiTietDichVuDAL();
            _hoaDonDAL = new HoaDonDAL();
            _khachHangDAL = new KhachHangDAL();
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            cmbPhuongThuc.SelectedIndex = 0; // Tiền mặt
            TaiDuLieuThanhToan();
        }

        private void TaiDuLieuThanhToan()
        {
            try
            {
                _phien = _phienDAL.GetById(_maPhien);
                if (_phien == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin phiên sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                _thoiGianKetThuc = DateTime.Now;
                _phien.ThoiGianKetThuc = _thoiGianKetThuc;

                // Tính toán chính xác thời gian và tiền
                TimeSpan duration = _phien.ThoiGianSuDung;
                _tienMay = _phien.TinhTienMayHienTai();
                _tienDichVu = _chiTietDichVuDAL.TinhTongTienDichVuCuaPhien(_maPhien);
                _tongTien = _tienMay + _tienDichVu;

                // Hiển thị lên giao diện
                lblValMay.Text = _phien.TenMay;
                lblValKhachHang.Text = _phien.TenKhachHang;
                lblValBatDau.Text = _phien.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
                lblValKetThuc.Text = _thoiGianKetThuc.ToString("dd/MM/yyyy HH:mm:ss");
                lblValThoiGianSuDung.Text = $"{duration.Hours:D2} giờ {duration.Minutes:D2} phút {duration.Seconds:D2} giây";

                lblValTienMay.Text = $"{_tienMay:N0} đ";
                lblValTienDichVu.Text = $"{_tienDichVu:N0} đ";
                lblValTongTien.Text = $"{_tongTien:N0} đ";

                // Tải chi tiết dịch vụ
                var listDV = _chiTietDichVuDAL.GetByMaPhien(_maPhien);
                dgvDichVu.DataSource = null;
                dgvDichVu.AutoGenerateColumns = false;
                dgvDichVu.DataSource = listDV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhanThanhToan_Click(object sender, EventArgs e)
        {
            if (_phien == null) return;

            string phuongThuc = cmbPhuongThuc.SelectedItem?.ToString() ?? "Tiền mặt";
            string ghiChu = txtGhiChu.Text.Trim();
            string maNV = CurrentUser.MaNV ?? _phien.MaNV ?? "NV01";

            DialogResult dr = MessageBox.Show($"Xác nhận thanh toán cho máy [{_phien.TenMay}]\nTổng tiền thu: {_tongTien:N0} VNĐ\nPhương thức: {phuongThuc}?",
                "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // 1. Đóng phiên sử dụng và đưa máy về trạng thái Trống
                    bool dongPhienThanhCong = _phienDAL.DongPhien(_maPhien, _thoiGianKetThuc, _tienMay, _tienDichVu, _tongTien);

                    if (dongPhienThanhCong)
                    {
                        // 2. Tạo hóa đơn thanh toán
                        HoaDon hd = new HoaDon
                        {
                            MaPhien = _maPhien,
                            MaNV = maNV,
                            NgayTao = DateTime.Now,
                            TienMay = _tienMay,
                            TienDichVu = _tienDichVu,
                            TongTien = _tongTien,
                            PhuongThucThanhToan = phuongThuc,
                            GhiChu = ghiChu
                        };
                        int maHD = _hoaDonDAL.ThemHoaDon(hd);

                        // 3. Nếu khách hàng có số dư và muốn trừ tiền tài khoản
                        var kh = _khachHangDAL.GetById(_phien.MaKH);
                        if (kh != null && kh.SoDu >= _tongTien && phuongThuc == "Tiền mặt")
                        {
                            DialogResult drTru = MessageBox.Show($"Khách hàng có số dư: {kh.SoDu:N0} đ. Bạn có muốn trừ trực tiếp vào số dư tài khoản không?",
                                "Trừ tài khoản khách", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (drTru == DialogResult.Yes)
                            {
                                _khachHangDAL.TruTien(kh.MaKH, _tongTien);
                            }
                        }

                        MessageBox.Show($"Thanh toán thành công!\nMã hóa đơn: {maHD}\nMáy [{_phien.TenMay}] đã được chuyển về trạng thái TRỐNG.",
                            "Thanh toán hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đóng phiên sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xử lý thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
