using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmChamCong : Form
    {
        private readonly IChamCongDAL _chamCongDAL;
        private readonly INhanVienDAL _nhanVienDAL;

        public frmChamCong()
        {
            InitializeComponent();
            _chamCongDAL = new ChamCongDAL();
            _nhanVienDAL = new NhanVienDAL();
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            lblDongHoHienTai.Text = $"Hôm nay: {DateTime.Now:dd/MM/yyyy}\nThời gian: {DateTime.Now:HH:mm:ss}";
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);

            TaiDanhSachNhanVien();
        }

        private void TaiDanhSachNhanVien()
        {
            try
            {
                var listNV = _nhanVienDAL.GetAll();

                // Tạo danh sách bao gồm tùy chọn "Tất cả"
                var comboList = new List<NhanVien>
                {
                    new NhanVien { MaNV = "Tất cả", HoTen = "-- Tất cả nhân viên --" }
                };
                comboList.AddRange(listNV);

                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaNV";
                cmbNhanVien.DataSource = comboList;

                // Mặc định chọn nhân viên hiện tại nếu có
                if (CurrentUser.IsLoggedIn && !string.IsNullOrWhiteSpace(CurrentUser.MaNV))
                {
                    cmbNhanVien.SelectedValue = CurrentUser.MaNV;
                }
                else
                {
                    cmbNhanVien.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiDanhSachChamCong()
        {
            try
            {
                string maNV = cmbNhanVien.SelectedValue?.ToString() ?? "Tất cả";
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                List<ChamCong> list;
                if (maNV == "Tất cả")
                {
                    list = _chamCongDAL.TimKiem(null, tuNgay, denNgay);
                }
                else
                {
                    // Lọc chính xác theo nhân viên đã chọn
                    list = _chamCongDAL.TimKiem(maNV, tuNgay, denNgay);
                }

                dgvChamCong.DataSource = null;
                dgvChamCong.AutoGenerateColumns = false;
                dgvChamCong.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu chấm công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaiDanhSachChamCong();
        }

        private void BoLoc_Changed(object sender, EventArgs e)
        {
            TaiDanhSachChamCong();
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            cmbNhanVien.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);
            TaiDanhSachChamCong();
        }

        private void btnChamCongVao_Click(object sender, EventArgs e)
        {
            string maNV = CurrentUser.MaNV;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                // Nếu chưa đăng nhập nhân viên cụ thể thì dùng mã đang chọn trong combobox
                if (cmbNhanVien.SelectedValue != null && cmbNhanVien.SelectedValue.ToString() != "Tất cả")
                {
                    maNV = cmbNhanVien.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần chấm công vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Kiểm tra xem hôm nay đã có ca làm nào đang mở không
            var ccHienTai = _chamCongDAL.GetChamCongHienTai(maNV, DateTime.Today);
            if (ccHienTai != null)
            {
                MessageBox.Show($"Nhân viên [{maNV}] đã chấm công vào lúc {ccHienTai.GioVao:hh\\:mm\\:ss} và chưa chấm ra!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan gioVao = DateTime.Now.TimeOfDay;
            string ghiChu = txtGhiChu.Text.Trim();

            if (_chamCongDAL.ChamCongVao(maNV, gioVao, ghiChu))
            {
                MessageBox.Show($"Chấm công VÀO thành công cho nhân viên [{maNV}] lúc {gioVao:hh\\:mm\\:ss}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGhiChu.Clear();
                TaiDanhSachChamCong();
            }
            else
            {
                MessageBox.Show("Chấm công vào thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChamCongRa_Click(object sender, EventArgs e)
        {
            string maNV = CurrentUser.MaNV;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                if (cmbNhanVien.SelectedValue != null && cmbNhanVien.SelectedValue.ToString() != "Tất cả")
                {
                    maNV = cmbNhanVien.SelectedValue.ToString();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần chấm công ra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Tìm ca đang làm việc hôm nay
            var ccHienTai = _chamCongDAL.GetChamCongHienTai(maNV, DateTime.Today);
            if (ccHienTai == null)
            {
                MessageBox.Show($"Không tìm thấy bản ghi chấm công VÀO chưa hoàn thành của nhân viên [{maNV}]!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan gioRa = DateTime.Now.TimeOfDay;
            string ghiChu = txtGhiChu.Text.Trim();

            if (_chamCongDAL.ChamCongRa(ccHienTai.MaChamCong, gioRa, ghiChu))
            {
                TimeSpan duration = gioRa - ccHienTai.GioVao;
                if (duration.TotalMinutes < 0) duration = duration.Add(TimeSpan.FromHours(24));

                MessageBox.Show($"Chấm công RA thành công!\nGiờ vào: {ccHienTai.GioVao:hh\\:mm\\:ss}\nGiờ ra: {gioRa:hh\\:mm\\:ss}\nTổng thời gian: {duration.TotalHours:F2} giờ",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGhiChu.Clear();
                TaiDanhSachChamCong();
            }
            else
            {
                MessageBox.Show("Chấm công ra thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
