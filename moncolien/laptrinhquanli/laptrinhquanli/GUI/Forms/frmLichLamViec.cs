using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmLichLamViec : Form
    {
        private readonly ILichLamViecDAL _lichDAL;
        private readonly ICaLamViecDAL _caDAL;
        private readonly INhanVienDAL _nhanVienDAL;

        private List<CaLamViec> _danhSachCa;
        private List<LichLamViec> _danhSachLich;
        private List<NhanVien> _danhSachNV;

        public frmLichLamViec()
        {
            InitializeComponent();
            _lichDAL = new LichLamViecDAL();
            _caDAL = new CaLamViecDAL();
            _nhanVienDAL = new NhanVienDAL();
        }

        private void frmLichLamViec_Load(object sender, EventArgs e)
        {
            cmbThu.SelectedIndex = 0; // Thứ 2
            TaiDuLieuCombobox();
            TaiLichTuan();
        }

        private void TaiDuLieuCombobox()
        {
            try
            {
                // Tải ca làm
                _danhSachCa = _caDAL.GetAll();
                cmbCa.DataSource = null;
                cmbCa.DisplayMember = "TenCa";
                cmbCa.ValueMember = "MaCa";
                cmbCa.DataSource = _danhSachCa;

                // Tải nhân viên
                _danhSachNV = _nhanVienDAL.GetAll().Where(n => n.TrangThai == "Đang làm việc").ToList();
                cmbNhanVien.DataSource = null;
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaNV";
                cmbNhanVien.DataSource = _danhSachNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiLichTuan()
        {
            try
            {
                _danhSachCa = _caDAL.GetAll();
                _danhSachLich = _lichDAL.GetAll();

                dgvLichTuan.Rows.Clear();

                foreach (var ca in _danhSachCa)
                {
                    int rowIndex = dgvLichTuan.Rows.Add();
                    DataGridViewRow row = dgvLichTuan.Rows[rowIndex];

                    row.Cells["colCa"].Value = $"{ca.TenCa}\n({ca.GioBatDau:hh\\:mm} - {ca.GioKetThuc:hh\\:mm})";
                    row.Tag = ca.MaCa;

                    // Thứ 2 (2) -> Chủ nhật (8)
                    for (int thu = 2; thu <= 8; thu++)
                    {
                        string colName = thu == 8 ? "colChuNhat" : "colThu" + thu.ToString();
                        var lich = _danhSachLich.FirstOrDefault(l => l.MaCa == ca.MaCa && l.ThuTrongTuan == thu);

                        if (lich != null && !string.IsNullOrWhiteSpace(lich.MaNV))
                        {
                            row.Cells[colName].Value = $"👤 {lich.TenNhanVien}\n[ĐÃ PHÂN CÔNG]";
                        }
                        else
                        {
                            row.Cells[colName].Value = "⚠️ Chưa phân công\n(Bấm để xếp ca)";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch phân ca: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichTuan_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                string text = e.Value?.ToString() ?? "";
                if (text.Contains("Chưa phân công"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 243, 224); // Cam nhạt cảnh báo
                    e.CellStyle.ForeColor = Color.FromArgb(230, 81, 0); // Chữ cam đậm
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                }
                else if (text.Contains("ĐÃ PHÂN CÔNG"))
                {
                    e.CellStyle.BackColor = Color.FromArgb(232, 245, 233); // Xanh lá dịu
                    e.CellStyle.ForeColor = Color.FromArgb(27, 94, 32); // Chữ xanh lá đậm
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }
            else if (e.ColumnIndex == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(238, 238, 238);
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.WrapMode = DataGridViewTriState.True;
            }
        }

        private void dgvLichTuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // Xác định Thứ từ cột: colThu2 = 2, ..., colChuNhat = 8
                int thu = e.ColumnIndex + 1; // Col 1 -> Thứ 2, ..., Col 7 -> Chủ nhật (8)
                cmbThu.SelectedIndex = thu - 2;

                // Xác định Ca từ dòng
                string maCa = dgvLichTuan.Rows[e.RowIndex].Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(maCa))
                {
                    cmbCa.SelectedValue = maCa;
                }

                // Tải nhân viên đã phân công (nếu có)
                var lich = _danhSachLich.FirstOrDefault(l => l.MaCa == maCa && l.ThuTrongTuan == thu);
                if (lich != null && !string.IsNullOrWhiteSpace(lich.MaNV))
                {
                    cmbNhanVien.SelectedValue = lich.MaNV;
                }
            }
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            if (cmbCa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ca làm việc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên được phân công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maCa = cmbCa.SelectedValue.ToString();
            int thu = cmbThu.SelectedIndex + 2; // Thứ 2 = 2
            string maNV = cmbNhanVien.SelectedValue.ToString();

            if (_lichDAL.PhanCong(maCa, thu, maNV))
            {
                MessageBox.Show($"Đã phân công {cmbNhanVien.Text} vào {cmbCa.Text} ({cmbThu.Text})!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLichTuan();
            }
            else
            {
                MessageBox.Show("Phân công thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaPhanCong_Click(object sender, EventArgs e)
        {
            if (cmbCa.SelectedValue == null) return;

            string maCa = cmbCa.SelectedValue.ToString();
            int thu = cmbThu.SelectedIndex + 2;

            if (_lichDAL.XoaPhanCong(maCa, thu))
            {
                MessageBox.Show($"Đã hủy phân công ca {cmbCa.Text} ({cmbThu.Text})!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TaiLichTuan();
            }
            else
            {
                MessageBox.Show("Hủy phân công thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDuLieuCombobox();
            TaiLichTuan();
        }
    }
}
