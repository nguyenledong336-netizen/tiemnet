using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmQuanLyCa : Form
    {
        private readonly ICaLamViecDAL _caDAL;

        public frmQuanLyCa()
        {
            InitializeComponent();
            _caDAL = new CaLamViecDAL();
        }

        private void frmQuanLyCa_Load(object sender, EventArgs e)
        {
            dtpGioBatDau.Value = DateTime.Today.AddHours(6);
            dtpGioKetThuc.Value = DateTime.Today.AddHours(14);
            TaiDanhSachCa();
        }

        private void TaiDanhSachCa()
        {
            try
            {
                var list = _caDAL.GetAll();
                dgvCaLam.DataSource = null;
                dgvCaLam.AutoGenerateColumns = false;
                dgvCaLam.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCaLam_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCaLam.Rows.Count)
            {
                DataGridViewRow row = dgvCaLam.Rows[e.RowIndex];
                txtMaCa.Text = row.Cells["colMaCa"].Value?.ToString();
                txtTenCa.Text = row.Cells["colTenCa"].Value?.ToString();
                if (TimeSpan.TryParse(row.Cells["colGioBatDau"].Value?.ToString(), out TimeSpan batDau))
                {
                    dtpGioBatDau.Value = DateTime.Today.Add(batDau);
                }
                if (TimeSpan.TryParse(row.Cells["colGioKetThuc"].Value?.ToString(), out TimeSpan ketThuc))
                {
                    dtpGioKetThuc.Value = DateTime.Today.Add(ketThuc);
                }
                txtMaCa.ReadOnly = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maCa = txtMaCa.Text.Trim();
            string tenCa = txtTenCa.Text.Trim();
            TimeSpan gioBatDau = dtpGioBatDau.Value.TimeOfDay;
            TimeSpan gioKetThuc = dtpGioKetThuc.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(maCa))
            {
                MessageBox.Show("Vui lòng nhập mã ca!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaCa.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tenCa))
            {
                MessageBox.Show("Vui lòng nhập tên ca làm việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCa.Focus();
                return;
            }

            try
            {
                if (_caDAL.GetById(maCa) != null)
                {
                    MessageBox.Show("Mã ca này đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CaLamViec ca = new CaLamViec(maCa, tenCa, gioBatDau, gioKetThuc);
                if (_caDAL.Them(ca))
                {
                    MessageBox.Show("Thêm ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachCa();
                    btnLamMoi_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Thêm ca làm việc thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm ca: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maCa = txtMaCa.Text.Trim();
            string tenCa = txtTenCa.Text.Trim();
            TimeSpan gioBatDau = dtpGioBatDau.Value.TimeOfDay;
            TimeSpan gioKetThuc = dtpGioKetThuc.Value.TimeOfDay;

            if (string.IsNullOrWhiteSpace(maCa))
            {
                MessageBox.Show("Vui lòng chọn ca cần sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tenCa))
            {
                MessageBox.Show("Vui lòng nhập tên ca làm việc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenCa.Focus();
                return;
            }

            try
            {
                CaLamViec ca = new CaLamViec(maCa, tenCa, gioBatDau, gioKetThuc);
                if (_caDAL.CapNhat(ca))
                {
                    MessageBox.Show("Cập nhật ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiDanhSachCa();
                }
                else
                {
                    MessageBox.Show("Cập nhật ca làm việc thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật ca: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maCa = txtMaCa.Text.Trim();
            if (string.IsNullOrWhiteSpace(maCa))
            {
                MessageBox.Show("Vui lòng chọn ca cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xóa ca làm [{maCa}] không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    if (_caDAL.Xoa(maCa))
                    {
                        MessageBox.Show("Xóa ca làm việc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachCa();
                        btnLamMoi_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa ca làm này vì đã có trong lịch phân ca!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa ca làm việc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaCa.Clear();
            txtMaCa.ReadOnly = false;
            txtTenCa.Clear();
            dtpGioBatDau.Value = DateTime.Today.AddHours(6);
            dtpGioKetThuc.Value = DateTime.Today.AddHours(14);
            txtMaCa.Focus();
        }
    }
}
