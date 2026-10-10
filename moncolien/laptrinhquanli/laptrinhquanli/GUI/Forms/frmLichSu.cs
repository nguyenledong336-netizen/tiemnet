using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmLichSu : Form
    {
        private readonly IPhienSuDungDAL _phienDAL;
        private readonly IMayTinhDAL _mayTinhDAL;
        private readonly IKhachHangDAL _khachHangDAL;
        private readonly INhanVienDAL _nhanVienDAL;

        private readonly string _initialMaKH;

        public frmLichSu(string maKH = null)
        {
            InitializeComponent();
            _initialMaKH = maKH;

            _phienDAL = new PhienSuDungDAL();
            _mayTinhDAL = new MayTinhDAL();
            _khachHangDAL = new KhachHangDAL();
            _nhanVienDAL = new NhanVienDAL();
        }

        private void frmLichSu_Load(object sender, EventArgs e)
        {
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);

            TaiDanhMucCombobox();
            TaiLichSu();
        }

        private void TaiDanhMucCombobox()
        {
            try
            {
                // Máy
                var listMay = new List<MayTinh> { new MayTinh { MaMay = "", TenMay = "-- Tất cả máy --" } };
                listMay.AddRange(_mayTinhDAL.GetAll());
                cmbMay.DisplayMember = "TenMay";
                cmbMay.ValueMember = "MaMay";
                cmbMay.DataSource = listMay;

                // Khách hàng
                var listKH = new List<KhachHang> { new KhachHang { MaKH = "", HoTen = "-- Tất cả khách --" } };
                listKH.AddRange(_khachHangDAL.GetAll());
                cmbKhachHang.DisplayMember = "HoTen";
                cmbKhachHang.ValueMember = "MaKH";
                cmbKhachHang.DataSource = listKH;

                if (!string.IsNullOrWhiteSpace(_initialMaKH))
                {
                    cmbKhachHang.SelectedValue = _initialMaKH;
                }

                // Nhân viên
                var listNV = new List<NhanVien> { new NhanVien { MaNV = "", HoTen = "-- Tất cả nhân viên --" } };
                listNV.AddRange(_nhanVienDAL.GetAll());
                cmbNhanVien.DisplayMember = "HoTen";
                cmbNhanVien.ValueMember = "MaNV";
                cmbNhanVien.DataSource = listNV;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TaiLichSu()
        {
            try
            {
                DateTime tuNgay = dtpTuNgay.Value.Date;
                DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

                string maMay = cmbMay.SelectedValue?.ToString();
                string maKH = cmbKhachHang.SelectedValue?.ToString();
                string maNV = cmbNhanVien.SelectedValue?.ToString();

                var list = _phienDAL.TimKiem(tuNgay, denNgay, maMay, maNV, maKH);
                dgvLichSu.DataSource = null;
                dgvLichSu.AutoGenerateColumns = false;
                dgvLichSu.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử phiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BoLoc_Changed(object sender, EventArgs e)
        {
            TaiLichSu();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            cmbMay.SelectedIndex = 0;
            cmbKhachHang.SelectedIndex = 0;
            cmbNhanVien.SelectedIndex = 0;
            dtpTuNgay.Value = DateTime.Today.AddDays(-30);
            dtpDenNgay.Value = DateTime.Today.AddDays(1);
            TaiLichSu();
        }
    }
}
