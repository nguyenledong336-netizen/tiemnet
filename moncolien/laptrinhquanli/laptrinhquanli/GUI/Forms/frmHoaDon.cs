using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmHoaDon : Form
    {
        private readonly IHoaDonDAL _hoaDonDAL;

        public frmHoaDon()
        {
            InitializeComponent();
            _hoaDonDAL = new HoaDonDAL();
        }

        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            cmbPhuongThuc.SelectedIndex = 0; // Tất cả
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);

            TaiDanhSachHoaDon();
        }

        private void TaiDanhSachHoaDon()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);
                string phuongThuc = cmbPhuongThuc.SelectedItem?.ToString() ?? "Tất cả";

                var list = _hoaDonDAL.TimKiem(tuNgay, denNgay, phuongThuc);
                dgvHoaDon.DataSource = null;
                dgvHoaDon.AutoGenerateColumns = false;
                dgvHoaDon.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BoLoc_Changed(object sender, EventArgs e)
        {
            TaiDanhSachHoaDon();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbPhuongThuc.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);
            TaiDanhSachHoaDon();
        }
    }
}
