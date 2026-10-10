using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmQuanLyDichVu : Form
    {
        private readonly IDichVuDAL _dichVuDAL;

        public frmQuanLyDichVu()
        {
            InitializeComponent();
            _dichVuDAL = new DichVuDAL();
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            cmbTrangThai.SelectedIndex = 0; // Còn hàng
            TaiDanhSachDichVu();
        }

        private void TaiDanhSachDichVu()
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();
                List<DichVu> list = string.IsNullOrWhiteSpace(keyword)
                    ? _dichVuDAL.GetAll()
                    : _dichVuDAL.TimKiem(keyword);

                dgvDichVu.DataSource = null;
                dgvDichVu.AutoGenerateColumns = false;
                dgvDichVu.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDichVu.Rows.Count)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                txtMaDV.Text = row.Cells["colMaDV"].Value?.ToString();
                txtTenDV.Text = row.Cells["colTenDV"].Value?.ToString();
                if (decimal.TryParse(row.Cells["colDonGia"].Value?.ToString(), out decimal donGia))
                {
                    nudDonGia.Value = donGia;
                }
                txtDonViTinh.Text = row.Cells["colDonViTinh"].Value?.ToString();
                cmbTrangThai.SelectedItem = row.Cells["colTrangThai"].Value?.ToString();
                txtMaDV.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim();
            string tenDV = txtTenDV.Text.Trim();
            decimal donGia = nudDonGia.Value;
            string donViTinh = txtDonViTinh.Text.Trim();
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Còn hàng";

            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDV.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenDV))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return;
            }

            try
            {
                if (_dichVuDAL.GetById(maDV) != null)
                {
                    MessageBox.Show("Mã dịch vụ này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DichVu dv = new DichVu(maDV, tenDV, donGia, donViTinh, trangThai);
                if (_dichVuDAL.Them(dv))
                {
                    MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachDichVu();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim();
            string tenDV = txtTenDV.Text.Trim();
            decimal donGia = nudDonGia.Value;
            string donViTinh = txtDonViTinh.Text.Trim();
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Còn hàng";

            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenDV))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return;
            }

            try
            {
                DichVu dv = new DichVu(maDV, tenDV, donGia, donViTinh, trangThai);
                if (_dichVuDAL.CapNhat(dv))
                {
                    MessageBox.Show("Cập nhật thông tin dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachDichVu();
                }
                else
                {
                    MessageBox.Show("Cập nhật dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa dịch vụ [{maDV}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (_dichVuDAL.Xoa(maDV))
                    {
                        MessageBox.Show("Xóa dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachDichVu();
                        btnLamMoi_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dịch vụ này vì đã có trong hóa đơn/phiên sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa dịch vụ (ràng buộc khóa ngoại): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDoiTrangThai_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text.Trim();
            if (string.IsNullOrWhiteSpace(maDV))
            {
                MessageBox.Show("Vui lòng chọn dịch vụ để đổi trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string currentStatus = cmbTrangThai.SelectedItem?.ToString() ?? "Còn hàng";
            string newStatus = currentStatus == "Còn hàng" ? "Hết hàng" : "Còn hàng";

            if (_dichVuDAL.BatTatTrangThai(maDV, newStatus))
            {
                MessageBox.Show($"Đã chuyển trạng thái dịch vụ sang: [{newStatus}]!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiDanhSachDichVu();
                cmbTrangThai.SelectedItem = newStatus;
            }
            else
            {
                MessageBox.Show("Đổi trạng thái thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaDV.Clear();
            txtMaDV.ReadOnly = false;
            txtTenDV.Clear();
            nudDonGia.Value = 0;
            txtDonViTinh.Text = "Phần";
            cmbTrangThai.SelectedIndex = 0;
            txtMaDV.Focus();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TaiDanhSachDichVu();
        }
    }
}
