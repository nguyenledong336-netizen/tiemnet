using System;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmDangNhap : Form
    {
        private readonly ITaiKhoanDAL _taiKhoanDAL;
        private readonly INhanVienDAL _nhanVienDAL;

        public frmDangNhap()
        {
            InitializeComponent();
            _taiKhoanDAL = new TaiKhoanDAL();
            _nhanVienDAL = new NhanVienDAL();

            // Default account hint
            txtTenDangNhap.Text = "admin";
            txtMatKhau.Text = "123456";
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            // 1. Kiểm tra để trống
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            try
            {
                // 2. Tìm tài khoản
                TaiKhoan tk = _taiKhoanDAL.GetByUsername(username);
                if (tk == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại trong hệ thống!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenDangNhap.SelectAll();
                    txtTenDangNhap.Focus();
                    return;
                }

                // 3. Kiểm tra mật khẩu
                if (tk.MatKhau != password)
                {
                    MessageBox.Show("Mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.SelectAll();
                    txtMatKhau.Focus();
                    return;
                }

                // 4. Kiểm tra trạng thái tài khoản
                if (tk.TrangThai == "Bị khóa")
                {
                    MessageBox.Show("Tài khoản của bạn đã bị khóa. Vui lòng liên hệ Quản trị viên!", "Tài khoản bị khóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin nhân viên liên kết
                NhanVien nv = _nhanVienDAL.GetById(tk.MaNV);

                // 5. Lưu vào CurrentUser
                CurrentUser.SetUser(tk, nv);

                // 6. Mở frmMain và ẩn frmDangNhap
                this.Hide();
                frmMain mainForm = new frmMain();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu!\nChi tiết: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
