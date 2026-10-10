using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmQuanLyMay : Form
    {
        private readonly IMayTinhDAL _mayTinhDAL;
        private List<MayTinh> _danhSachMay;

        public frmQuanLyMay()
        {
            InitializeComponent();
            _mayTinhDAL = new MayTinhDAL();
        }

        private void frmQuanLyMay_Load(object sender, EventArgs e)
        {
            cmbLoaiMay.SelectedIndex = 0; // Thường
            cmbTrangThai.SelectedIndex = 0; // Trống
            cmbLocTrangThai.SelectedIndex = 0; // Tất cả
            cmbLocLoai.SelectedIndex = 0; // Tất cả

            TaiDanhSachMay();
        }

        private void TaiDanhSachMay()
        {
            try
            {
                _danhSachMay = _mayTinhDAL.GetAll();
                HienThiDanhSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSach()
        {
            if (_danhSachMay == null) return;

            var query = _danhSachMay.AsEnumerable();

            string locTrangThai = cmbLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            if (locTrangThai != "Tất cả")
            {
                query = query.Where(m => m.TrangThai == locTrangThai);
            }

            string locLoai = cmbLocLoai.SelectedItem?.ToString() ?? "Tất cả";
            if (locLoai != "Tất cả")
            {
                query = query.Where(m => m.LoaiMay == locLoai);
            }

            string keyword = txtTimKiem.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(m => m.MaMay.ToLower().Contains(keyword) || m.TenMay.ToLower().Contains(keyword));
            }

            dgvMayTinh.DataSource = null;
            dgvMayTinh.AutoGenerateColumns = false;
            dgvMayTinh.DataSource = query.ToList();
        }

        private void dgvMayTinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvMayTinh.Rows.Count)
            {
                DataGridViewRow row = dgvMayTinh.Rows[e.RowIndex];
                txtMaMay.Text = row.Cells["colMaMay"].Value?.ToString();
                txtTenMay.Text = row.Cells["colTenMay"].Value?.ToString();
                cmbLoaiMay.SelectedItem = row.Cells["colLoaiMay"].Value?.ToString();
                if (decimal.TryParse(row.Cells["colDonGia"].Value?.ToString(), out decimal donGia))
                {
                    nudDonGia.Value = donGia;
                }
                cmbTrangThai.SelectedItem = row.Cells["colTrangThai"].Value?.ToString();
                txtMaMay.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maMay = txtMaMay.Text.Trim();
            string tenMay = txtTenMay.Text.Trim();
            string loaiMay = cmbLoaiMay.SelectedItem?.ToString() ?? "Thường";
            decimal donGia = nudDonGia.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Trống";

            if (string.IsNullOrWhiteSpace(maMay))
            {
                MessageBox.Show("Vui lòng nhập mã máy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMay.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenMay))
            {
                MessageBox.Show("Vui lòng nhập tên máy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMay.Focus();
                return;
            }

            try
            {
                if (_mayTinhDAL.GetById(maMay) != null)
                {
                    MessageBox.Show("Mã máy này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MayTinh mt = new MayTinh(maMay, tenMay, loaiMay, donGia, trangThai);
                if (_mayTinhDAL.Them(mt))
                {
                    MessageBox.Show("Thêm máy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachMay();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Thêm máy thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maMay = txtMaMay.Text.Trim();
            string tenMay = txtTenMay.Text.Trim();
            string loaiMay = cmbLoaiMay.SelectedItem?.ToString() ?? "Thường";
            decimal donGia = nudDonGia.Value;
            string trangThai = cmbTrangThai.SelectedItem?.ToString() ?? "Trống";

            if (string.IsNullOrWhiteSpace(maMay))
            {
                MessageBox.Show("Vui lòng chọn máy cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenMay))
            {
                MessageBox.Show("Vui lòng nhập tên máy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMay.Focus();
                return;
            }

            try
            {
                MayTinh mt = new MayTinh(maMay, tenMay, loaiMay, donGia, trangThai);
                if (_mayTinhDAL.CapNhat(mt))
                {
                    MessageBox.Show("Cập nhật thông tin máy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachMay();
                }
                else
                {
                    MessageBox.Show("Cập nhật máy thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maMay = txtMaMay.Text.Trim();
            if (string.IsNullOrWhiteSpace(maMay))
            {
                MessageBox.Show("Vui lòng chọn máy cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa máy [{maMay}] không?\nLưu ý: Không thể xóa nếu máy đã có lịch sử phiên sử dụng.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (_mayTinhDAL.Xoa(maMay))
                    {
                        MessageBox.Show("Xóa máy thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachMay();
                        btnLamMoi_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa máy này vì có thể máy đang có dữ liệu phiên sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa máy (ràng buộc dữ liệu): " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaMay.Clear();
            txtMaMay.ReadOnly = false;
            txtTenMay.Clear();
            cmbLoaiMay.SelectedIndex = 0;
            nudDonGia.Value = 10000;
            cmbTrangThai.SelectedIndex = 0;
            txtMaMay.Focus();
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
