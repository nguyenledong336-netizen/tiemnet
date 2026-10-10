using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmQuanLyKhachHang : Form
    {
        private readonly IKhachHangDAL _khachHangDAL;

        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            _khachHangDAL = new KhachHangDAL();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            cmbTrangThai.SelectedIndex = 0; // Hoạt động
            TaiDanhSachKhachHang();
        }

        private void TaiDanhSachKhachHang()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                List<KhachHang> list = string.IsNullOrWhiteSpace(keyword)
                    ? _khachHangDAL.GetAll()
                    : _khachHangDAL.TimKiem(keyword);

                dgvKhachHang.DataSource = null;
                dgvKhachHang.AutoGenerateColumns = false;
                dgvKhachHang.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhachHang.Rows.Count)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = row.Cells["colMaKH"].Value?.ToString();
                txtHoTen.Text = row.Cells["colHoTen"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["colSoDienThoai"].Value?.ToString();
                if (decimal.TryParse(row.Cells["colSoDu"].Value?.ToString(), out decimal soDu))
                {
                    nudSoDu.Value = soDu;
                }
                cmbTrangThai.SelectedItem = row.Cells["colTrangThai"].Value?.ToString();
                txtMaKH.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            decimal soDu = nudSoDu.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Hoạt động";

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                if (_khachHangDAL.GetById(maKH) != null)
                {
                    MessageBox.Show("Mã khách hàng này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KhachHang kh = new KhachHang(maKH, hoTen, sdt, soDu, trangThai);
                if (_khachHangDAL.Them(kh))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachKhachHang();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            decimal soDu = nudSoDu.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Hoạt động";

            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show("Vui lòng nhập họ tên khách hàng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            try
            {
                KhachHang kh = new KhachHang(maKH, hoTen, sdt, soDu, trangThai);
                if (_khachHangDAL.CapNhat(kh))
                {
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachKhachHang();
                }
                else
                {
                    MessageBox.Show("Cập nhật khách hàng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng [{maKH}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (_khachHangDAL.Xoa(maKH))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachKhachHang();
                        btnLamMoi_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khách hàng này do đã có dữ liệu giao dịch!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa khách hàng (ràng buộc khóa ngoại): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnNapTien_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            if (string.IsNullOrWhiteSpace(maKH))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần nạp tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form fNapTien = new Form())
            {
                fNapTien.Text = $"Nạp tiền tài khoản - {txtHoTen.Text}";
                fNapTien.Size = new Size(340, 190);
                fNapTien.StartPosition = FormStartPosition.CenterParent;
                fNapTien.FormBorderStyle = FormBorderStyle.FixedDialog;
                fNapTien.MaximizeBox = false;
                fNapTien.MinimizeBox = false;

                Label lblPrompt = new Label { Text = "Nhập số tiền muốn nạp (VNĐ):", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                NumericUpDown nudTienNap = new NumericUpDown { Location = new Point(20, 48), Width = 280, Minimum = 10000, Maximum = 10000000, Increment = 10000, Value = 50000, ThousandsSeparator = true, Font = new Font("Segoe UI", 10.5F) };

                Button btnXacNhan = new Button { Text = "Nạp tiền", DialogResult = DialogResult.OK, Location = new Point(100, 95), Size = new Size(95, 32), BackColor = Color.FromArgb(46, 125, 50), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                Button btnHuy = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(205, 95), Size = new Size(95, 32), FlatStyle = FlatStyle.Flat };

                fNapTien.Controls.AddRange(new Control[] { lblPrompt, nudTienNap, btnXacNhan, btnHuy });
                fNapTien.AcceptButton = btnXacNhan;
                fNapTien.CancelButton = btnHuy;

                if (fNapTien.ShowDialog() == DialogResult.OK)
                {
                    decimal tienNap = nudTienNap.Value;
                    if (_khachHangDAL.CongTien(maKH, tienNap))
                    {
                        MessageBox.Show($"Nạp thành công {tienNap:N0} đ vào tài khoản khách hàng {txtHoTen.Text}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachKhachHang();
                        var kh = _khachHangDAL.GetById(maKH);
                        if (kh != null) nudSoDu.Value = kh.SoDu;
                    }
                    else
                    {
                        MessageBox.Show("Nạp tiền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtMaKH.ReadOnly = false;
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            nudSoDu.Value = 0;
            cmbTrangThai.SelectedIndex = 0;
            txtMaKH.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachKhachHang();
        }

        private void btnXemLichSu_Click(object sender, EventArgs e)
        {
            string maKH = txtMaKH.Text.Trim();
            frmLichSu frm = new frmLichSu(maKH);
            frm.ShowDialog();
        }
    }
}
