using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmQuanLyNhanVien : Form
    {
        private readonly INhanVienDAL _nhanVienDAL;
        private readonly ITaiKhoanDAL _taiKhoanDAL;

        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            _nhanVienDAL = new NhanVienDAL();
            _taiKhoanDAL = new TaiKhoanDAL();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            cmbVaiTro.SelectedIndex = 0; // Nhân viên
            cmbTrangThai.SelectedIndex = 0; // Đang làm việc
            TaiDanhSachNhanVien();
        }

        private void TaiDanhSachNhanVien()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                List<NhanVien> list = string.IsNullOrWhiteSpace(keyword)
                    ? _nhanVienDAL.GetAll()
                    : _nhanVienDAL.TimKiem(keyword);

                dgvNhanVien.DataSource = null;
                dgvNhanVien.AutoGenerateColumns = false;
                dgvNhanVien.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvNhanVien.Rows.Count)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                string maNV = row.Cells["colMaNV"].Value?.ToString();
                txtMaNV.Text = maNV;
                txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["colSoDienThoai"].Value?.ToString();
                cmbVaiTro.SelectedItem = row.Cells["colVaiTro"].Value?.ToString();
                if (decimal.TryParse(row.Cells["colLuong"].Value?.ToString(), out decimal luong))
                {
                    nudLuong.Value = luong;
                }
                cmbTrangThai.SelectedItem = row.Cells["colTrangThai"].Value?.ToString();
                txtMaNV.ReadOnly = true;

                // Tải tài khoản liên kết nếu có
                var accounts = _taiKhoanDAL.GetAll().Where(t => t.MaNV == maNV).ToList();
                if (accounts.Count > 0)
                {
                    txtTenDangNhap.Text = accounts[0].TenDangNhap;
                    txtTenDangNhap.ReadOnly = true;
                    txtMatKhau.Text = accounts[0].MatKhau;
                }
                else
                {
                    txtTenDangNhap.Clear();
                    txtTenDangNhap.ReadOnly = false;
                    txtMatKhau.Text = "123456";
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string vaiTro = cmbVaiTro.SelectedItem?.ToString() ?? "Nhân viên";
            decimal luong = nudLuong.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Đang làm việc";

            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập để cấp tài khoản!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            try
            {
                if (_nhanVienDAL.GetById(maNV) != null)
                {
                    MessageBox.Show("Mã nhân viên này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_taiKhoanDAL.GetByUsername(username) != null)
                {
                    MessageBox.Show("Tên đăng nhập này đã được sử dụng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                NhanVien nv = new NhanVien(maNV, hoTen, sdt, vaiTro, luong, trangThai);
                if (_nhanVienDAL.Them(nv))
                {
                    // Tạo tài khoản cho nhân viên
                    TaiKhoan tk = new TaiKhoan(username, string.IsNullOrWhiteSpace(password) ? "123456" : password, maNV, vaiTro, "Hoạt động");
                    _taiKhoanDAL.Them(tk);

                    MessageBox.Show("Thêm nhân viên và cấp tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachNhanVien();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string vaiTro = cmbVaiTro.SelectedItem?.ToString() ?? "Nhân viên";
            decimal luong = nudLuong.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Đang làm việc";

            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                NhanVien nv = new NhanVien(maNV, hoTen, sdt, vaiTro, luong, trangThai);
                if (_nhanVienDAL.CapNhat(nv))
                {
                    // Cập nhật mật khẩu nếu có nhập
                    if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
                    {
                        var tk = _taiKhoanDAL.GetByUsername(username);
                        if (tk != null)
                        {
                            tk.MatKhau = password;
                            tk.VaiTro = vaiTro;
                            _taiKhoanDAL.CapNhat(tk);
                        }
                    }

                    MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachNhanVien();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (CurrentUser.MaNV == maNV)
            {
                MessageBox.Show("Không thể xóa tài khoản của chính bạn đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên [{maNV}] không?\n(Tài khoản đi kèm cũng sẽ bị xóa)",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (_nhanVienDAL.Xoa(maNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachNhanVien();
                        btnLamMoi_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên này vì đã có dữ liệu chấm công hoặc phiên thu ngân!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Clear();
            txtMaNV.ReadOnly = false;
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            cmbVaiTro.SelectedIndex = 0;
            nudLuong.Value = 6000000;
            cmbTrangThai.SelectedIndex = 0;
            txtTenDangNhap.Clear();
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.Text = "123456";
            txtMaNV.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachNhanVien();
        }
    }
}
