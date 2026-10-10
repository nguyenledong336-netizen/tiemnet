using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmThongKe : Form
    {
        private readonly IHoaDonDAL _hoaDonDAL;
        private readonly IPhienSuDungDAL _phienDAL;

        public frmThongKe()
        {
            InitializeComponent();
            _hoaDonDAL = new HoaDonDAL();
            _phienDAL = new PhienSuDungDAL();
        }

        private void frmThongKe_Load(object sender, EventArgs e)
        {
            cmbMocThoiGian.SelectedIndex = 3; // Mặc định: Tháng này
            CapNhatThoiGianTheoPreset();
            TaiThongKe();
        }

        private void cmbMocThoiGian_SelectedIndexChanged(object sender, EventArgs e)
        {
            CapNhatThoiGianTheoPreset();
            TaiThongKe();
        }

        private void CapNhatThoiGianTheoPreset()
        {
            string preset = cmbMocThoiGian.SelectedItem?.ToString() ?? "Tháng này";
            DateTime now = DateTime.Now;

            switch (preset)
            {
                case "Hôm nay":
                    dtpTuNgay.Value = DateTime.Today;
                    dtpDenNgay.Value = DateTime.Today;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    break;
                case "Hôm qua":
                    dtpTuNgay.Value = DateTime.Today.AddDays(-1);
                    dtpDenNgay.Value = DateTime.Today.AddDays(-1);
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    break;
                case "7 ngày qua":
                    dtpTuNgay.Value = DateTime.Today.AddDays(-7);
                    dtpDenNgay.Value = DateTime.Today;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    break;
                case "Tháng này":
                    dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
                    dtpDenNgay.Value = DateTime.Today;
                    dtpTuNgay.Enabled = false;
                    dtpDenNgay.Enabled = false;
                    break;
                case "Tùy chọn":
                default:
                    dtpTuNgay.Enabled = true;
                    dtpDenNgay.Enabled = true;
                    break;
            }
        }

        private void TaiThongKe()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                var listHoaDon = _hoaDonDAL.TimKiem(tuNgay, denNgay, null);

                decimal tongTienMay = listHoaDon.Sum(h => h.TienMay);
                decimal tongTienDV = listHoaDon.Sum(h => h.TienDichVu);
                decimal tongDoanhThu = listHoaDon.Sum(h => h.TongTien);
                int soHoaDon = listHoaDon.Count;

                // Lấy số phiên hoàn tất trong kỳ
                var listPhien = _phienDAL.TimKiem(tuNgay, denNgay, null, null, null)
                                         .Where(p => p.TrangThai == "Đã thanh toán").ToList();
                int soPhien = listPhien.Count;

                // Cập nhật card tổng hợp
                lblValDoanhThu.Text = $"{tongDoanhThu:N0} đ";
                lblValTienMay.Text = $"{tongTienMay:N0} đ";
                lblValTienDV.Text = $"{tongTienDV:N0} đ";
                lblValSoPhien.Text = soPhien.ToString();
                lblValSoHoaDon.Text = soHoaDon.ToString();

                // Cập nhật bảng hóa đơn
                dgvChiTiet.DataSource = null;
                dgvChiTiet.AutoGenerateColumns = false;
                dgvChiTiet.DataSource = listHoaDon;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            TaiThongKe();
        }
    }
}
