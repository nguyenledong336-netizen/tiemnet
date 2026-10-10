using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using QuanLyTiemNet.DAL.DataAccess;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;
using QuanLyTiemNet.GUI.UserControls;

namespace QuanLyTiemNet.GUI.Forms
{
    public partial class frmMain : Form
    {
        private readonly IMayTinhDAL _mayTinhDAL;
        private readonly IKhachHangDAL _khachHangDAL;
        private readonly IPhienSuDungDAL _phienDAL;
        private readonly IChiTietDichVuDAL _chiTietDichVuDAL;
        private readonly IDichVuDAL _dichVuDAL;

        private List<MayTinh> _danhSachMay;
        private MayTinh _selectedMay;
        private PhienSuDung _selectedPhien;
        private ucMayTinh _selectedControl;

        public frmMain()
        {
            InitializeComponent();

            _mayTinhDAL = new MayTinhDAL();
            _khachHangDAL = new KhachHangDAL();
            _phienDAL = new PhienSuDungDAL();
            _chiTietDichVuDAL = new ChiTietDichVuDAL();
            _dichVuDAL = new DichVuDAL();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 1. Phân quyền và hiển thị thông tin người dùng
            KiemTraPhanQuyen();

            // 2. Khởi tạo combobox bộ lọc
            cmbLocTrangThai.SelectedIndex = 0;
            cmbLocLoaiMay.SelectedIndex = 0;

            // 3. Tải danh sách khách hàng cho combobox mở máy
            TaiDanhSachKhachHang();

            // 4. Tải sơ đồ máy
            TaiDanhSachMay();

            // 5. Bật timer cập nhật thời gian thực
            timerCapNhat.Start();
        }

        private void KiemTraPhanQuyen()
        {
            if (CurrentUser.IsLoggedIn)
            {
                lblUserInfo.Text = $"Xin chào: {CurrentUser.HoTen} ({CurrentUser.VaiTro})";

                if (CurrentUser.IsNhanVien)
                {
                    // Giới hạn quyền nhân viên theo yêu cầu đề bài
                    btnNhanVien.Enabled = false;
                    btnNhanVien.BackColor = Color.FromArgb(30, 40, 110);
                    btnQuanLyCa.Enabled = false;
                    btnQuanLyCa.BackColor = Color.FromArgb(30, 40, 110);
                    btnLichPhanCa.Enabled = false;
                    btnLichPhanCa.BackColor = Color.FromArgb(30, 40, 110);
                    btnThongKe.Enabled = false;
                    btnThongKe.BackColor = Color.FromArgb(30, 40, 110);
                }
            }
            else
            {
                lblUserInfo.Text = "Chưa đăng nhập";
            }
        }

        public void TaiDanhSachKhachHang()
        {
            try
            {
                var listKh = _khachHangDAL.GetAll();
                cmbKhachHang.DataSource = null;
                cmbKhachHang.DisplayMember = "HoTen";
                cmbKhachHang.ValueMember = "MaKH";
                cmbKhachHang.DataSource = listKh;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void TaiDanhSachMay()
        {
            try
            {
                _danhSachMay = _mayTinhDAL.GetAll();
                HienThiSoDoMay();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu máy tính từ CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiSoDoMay()
        {
            flpDanhSachMay.SuspendLayout();
            flpDanhSachMay.Controls.Clear();

            if (_danhSachMay == null || _danhSachMay.Count == 0)
            {
                lblTongSoMay.Text = "Tổng số máy: 0 máy";
                flpDanhSachMay.ResumeLayout();
                return;
            }

            string locTrangThai = cmbLocTrangThai.SelectedItem?.ToString() ?? "Tất cả";
            string locLoaiMay = cmbLocLoaiMay.SelectedItem?.ToString() ?? "Tất cả";

            var danhSachLoc = _danhSachMay.AsEnumerable();

            if (locTrangThai != "Tất cả")
            {
                danhSachLoc = danhSachLoc.Where(m => m.TrangThai == locTrangThai);
            }

            if (locLoaiMay != "Tất cả")
            {
                danhSachLoc = danhSachLoc.Where(m => m.LoaiMay == locLoaiMay);
            }

            var listHienThi = danhSachLoc.ToList();
            lblTongSoMay.Text = $"Hiển thị: {listHienThi.Count} / {_danhSachMay.Count} máy";

            ucMayTinh firstCard = null;
            ucMayTinh cardCanChonLai = null;

            foreach (var mt in listHienThi)
            {
                ucMayTinh card = new ucMayTinh();
                PhienSuDung phien = null;
                if (mt.TrangThai == "Đang sử dụng")
                {
                    phien = _phienDAL.GetPhienHienTaiCuaMay(mt.MaMay);
                }

                card.SetData(mt, phien);
                card.MayTinhClicked += OnMayTinhCardClicked;

                if (firstCard == null) firstCard = card;

                if (_selectedMay != null && _selectedMay.MaMay == mt.MaMay)
                {
                    cardCanChonLai = card;
                }

                flpDanhSachMay.Controls.Add(card);
            }

            flpDanhSachMay.ResumeLayout();

            // Khôi phục hoặc thiết lập máy được chọn
            if (cardCanChonLai != null)
            {
                ChonMay(cardCanChonLai);
            }
            else if (firstCard != null)
            {
                ChonMay(firstCard);
            }
            else
            {
                XoaChiTietMay();
            }
        }

        private void OnMayTinhCardClicked(object sender, MayTinh mt)
        {
            if (sender is ucMayTinh card)
            {
                ChonMay(card);
            }
        }

        private void ChonMay(ucMayTinh card)
        {
            if (_selectedControl != null)
            {
                _selectedControl.IsSelected = false;
            }

            _selectedControl = card;
            _selectedControl.IsSelected = true;
            _selectedMay = card.MayTinh;

            HienThiChiTietMayDuocChon();
        }

        private void HienThiChiTietMayDuocChon()
        {
            if (_selectedMay == null)
            {
                XoaChiTietMay();
                return;
            }

            // Thông tin cơ bản
            lblDetailTenMay.Text = _selectedMay.TenMay;
            lblDetailLoai.Text = "Loại máy: " + _selectedMay.LoaiMay;
            lblDetailGia.Text = $"{_selectedMay.DonGiaGio:N0} đ/h";
            lblDetailTrangThai.Text = "TRẠNG THÁI: " + _selectedMay.TrangThai.ToUpper();

            if (_selectedMay.TrangThai == "Đang sử dụng")
            {
                lblDetailTrangThai.ForeColor = Color.FromArgb(198, 40, 40);
                pnlMayTrong.Visible = false;
                pnlBaoTri.Visible = false;
                pnlDangSuDung.Visible = true;

                // Lấy phiên sử dụng hiện tại
                _selectedPhien = _phienDAL.GetPhienHienTaiCuaMay(_selectedMay.MaMay);
                if (_selectedPhien != null)
                {
                    lblValKhachHang.Text = _selectedPhien.TenKhachHang;
                    lblValGioBatDau.Text = _selectedPhien.ThoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
                    CapNhatChiTietPhienThoiGianThuc();
                    TaiDanhSachDichVuPhien(_selectedPhien.MaPhien);
                }
            }
            else if (_selectedMay.TrangThai == "Bảo trì")
            {
                lblDetailTrangThai.ForeColor = Color.FromArgb(245, 127, 23);
                pnlMayTrong.Visible = false;
                pnlDangSuDung.Visible = false;
                pnlBaoTri.Visible = true;
            }
            else
            {
                // Trống
                lblDetailTrangThai.ForeColor = Color.FromArgb(46, 125, 50);
                pnlDangSuDung.Visible = false;
                pnlBaoTri.Visible = false;
                pnlMayTrong.Visible = true;
            }
        }

        private void CapNhatChiTietPhienThoiGianThuc()
        {
            if (_selectedPhien != null && _selectedMay != null && _selectedMay.TrangThai == "Đang sử dụng")
            {
                TimeSpan duration = _selectedPhien.ThoiGianSuDung;
                decimal tienMay = _selectedPhien.TinhTienMayHienTai();
                decimal tienDichVu = _chiTietDichVuDAL.TinhTongTienDichVuCuaPhien(_selectedPhien.MaPhien);
                decimal tongTien = tienMay + tienDichVu;

                lblValThoiGianDung.Text = $"{duration.Hours:D2}:{duration.Minutes:D2}:{duration.Seconds:D2}";
                lblValTienMay.Text = $"{tienMay:N0} đ";
                lblValTienDichVu.Text = $"{tienDichVu:N0} đ";
                lblValTongTien.Text = $"{tongTien:N0} đ";
            }
        }

        private void TaiDanhSachDichVuPhien(int maPhien)
        {
            try
            {
                var list = _chiTietDichVuDAL.GetByMaPhien(maPhien);
                dgvDichVuPhien.DataSource = null;
                dgvDichVuPhien.AutoGenerateColumns = false;
                dgvDichVuPhien.Columns.Clear();

                dgvDichVuPhien.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "TenDV",
                    HeaderText = "Dịch vụ",
                    Width = 110
                });
                dgvDichVuPhien.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "SoLuong",
                    HeaderText = "SL",
                    Width = 40,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
                });
                dgvDichVuPhien.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "ThanhTien",
                    HeaderText = "Thành tiền",
                    Width = 85,
                    DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Format = "N0" }
                });

                dgvDichVuPhien.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dịch vụ của phiên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XoaChiTietMay()
        {
            lblDetailTenMay.Text = "Chưa chọn máy";
            lblDetailLoai.Text = "Loại máy: --";
            lblDetailGia.Text = "0 đ/h";
            lblDetailTrangThai.Text = "TRẠNG THÁI: --";
            pnlMayTrong.Visible = false;
            pnlDangSuDung.Visible = false;
            pnlBaoTri.Visible = false;
        }

        private void timerCapNhat_Tick(object sender, EventArgs e)
        {
            // Cập nhật thẻ máy trên màn hình
            foreach (Control ctrl in flpDanhSachMay.Controls)
            {
                if (ctrl is ucMayTinh card)
                {
                    card.CapNhatDongHo();
                }
            }

            // Cập nhật panel chi tiết nếu máy đang chạy
            if (_selectedMay != null && _selectedMay.TrangThai == "Đang sử dụng" && _selectedPhien != null)
            {
                CapNhatChiTietPhienThoiGianThuc();
            }
        }

        // ==================== HÀNH ĐỘNG VỚI MÁY ====================

        private void btnMoMay_Click(object sender, EventArgs e)
        {
            if (_selectedMay == null)
            {
                MessageBox.Show("Vui lòng chọn máy cần mở!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedMay.TrangThai != "Trống")
            {
                MessageBox.Show("Chỉ có thể mở máy khi trạng thái là 'Trống'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbKhachHang.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKH = cmbKhachHang.SelectedValue.ToString();
            string maNV = CurrentUser.MaNV ?? "NV01";

            DialogResult dr = MessageBox.Show($"Xác nhận mở máy [{_selectedMay.TenMay}] cho khách hàng [{cmbKhachHang.Text}]?",
                "Xác nhận mở máy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    PhienSuDung phienMoi = new PhienSuDung
                    {
                        MaMay = _selectedMay.MaMay,
                        MaKH = maKH,
                        MaNV = maNV,
                        ThoiGianBatDau = DateTime.Now,
                        DonGiaGio = _selectedMay.DonGiaGio
                    };

                    int maPhien = _phienDAL.MoPhien(phienMoi);
                    if (maPhien > 0)
                    {
                        MessageBox.Show($"Mở máy [{_selectedMay.TenMay}] thành công! Mã phiên: {maPhien}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachMay();
                    }
                    else
                    {
                        MessageBox.Show("Không thể tạo phiên sử dụng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi mở máy: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThemKhachNhanh_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            frm.ShowDialog();
            TaiDanhSachKhachHang();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            if (_selectedPhien == null)
            {
                MessageBox.Show("Không tìm thấy phiên sử dụng hiện tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mở dialog thêm dịch vụ nhanh
            using (Form fChonDichVu = new Form())
            {
                fChonDichVu.Text = $"Thêm dịch vụ - {_selectedMay.TenMay}";
                fChonDichVu.Size = new Size(380, 220);
                fChonDichVu.StartPosition = FormStartPosition.CenterParent;
                fChonDichVu.FormBorderStyle = FormBorderStyle.FixedDialog;
                fChonDichVu.MaximizeBox = false;
                fChonDichVu.MinimizeBox = false;

                Label lblDV = new Label { Text = "Chọn món ăn / đồ uống:", Location = new Point(20, 20), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                ComboBox cmbDV = new ComboBox { Location = new Point(20, 45), Width = 320, DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 9.5F) };

                var listDV = _dichVuDAL.GetConHang();
                cmbDV.DisplayMember = "TenDV";
                cmbDV.ValueMember = "MaDV";
                cmbDV.DataSource = listDV;

                Label lblSL = new Label { Text = "Số lượng:", Location = new Point(20, 85), AutoSize = true, Font = new Font("Segoe UI", 9.5F, FontStyle.Bold) };
                NumericUpDown nudSL = new NumericUpDown { Location = new Point(100, 83), Width = 80, Minimum = 1, Maximum = 100, Value = 1, Font = new Font("Segoe UI", 9.5F) };

                Button btnOK = new Button { Text = "Thêm", DialogResult = DialogResult.OK, Location = new Point(140, 130), Size = new Size(95, 32), BackColor = Color.FromArgb(21, 101, 192), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                Button btnCancel = new Button { Text = "Hủy", DialogResult = DialogResult.Cancel, Location = new Point(245, 130), Size = new Size(95, 32), FlatStyle = FlatStyle.Flat };

                fChonDichVu.Controls.AddRange(new Control[] { lblDV, cmbDV, lblSL, nudSL, btnOK, btnCancel });
                fChonDichVu.AcceptButton = btnOK;
                fChonDichVu.CancelButton = btnCancel;

                if (fChonDichVu.ShowDialog() == DialogResult.OK && cmbDV.SelectedItem is DichVu dv)
                {
                    ChiTietDichVu ct = new ChiTietDichVu
                    {
                        MaPhien = _selectedPhien.MaPhien,
                        MaDV = dv.MaDV,
                        SoLuong = (int)nudSL.Value,
                        DonGia = dv.DonGia,
                        ThoiGianDat = DateTime.Now
                    };

                    bool success = _chiTietDichVuDAL.ThemChiTiet(ct);
                    if (success)
                    {
                        MessageBox.Show($"Đã thêm {ct.SoLuong} {dv.DonViTinh} {dv.TenDV}!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiDanhSachDichVuPhien(_selectedPhien.MaPhien);
                        CapNhatChiTietPhienThoiGianThuc();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_selectedPhien == null || _selectedMay == null)
            {
                MessageBox.Show("Vui lòng chọn máy đang sử dụng để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frmThanhToan frm = new frmThanhToan(_selectedPhien.MaPhien);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Thanh toán hoàn tất -> Tải lại sơ đồ máy
                TaiDanhSachMay();
            }
        }

        private void btnMoKhoaBaoTri_Click(object sender, EventArgs e)
        {
            if (_selectedMay == null) return;

            DialogResult dr = MessageBox.Show($"Xác nhận kết thúc bảo trì và chuyển máy [{_selectedMay.TenMay}] về trạng thái Trống?",
                "Kết thúc bảo trì", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                _mayTinhDAL.CapNhatTrangThai(_selectedMay.MaMay, "Trống");
                TaiDanhSachMay();
            }
        }

        // ==================== BỘ LỌC & LÀM MỚI ====================

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiSoDoMay();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            TaiDanhSachKhachHang();
            TaiDanhSachMay();
        }

        // ==================== MENU ĐIỀU HƯỚNG ====================

        private void btnQuanLyMay_Click(object sender, EventArgs e)
        {
            frmQuanLyMay frm = new frmQuanLyMay();
            frm.ShowDialog();
            TaiDanhSachMay();
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            frm.ShowDialog();
            TaiDanhSachKhachHang();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmQuanLyDichVu frm = new frmQuanLyDichVu();
            frm.ShowDialog();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            frmQuanLyNhanVien frm = new frmQuanLyNhanVien();
            frm.ShowDialog();
        }

        private void btnQuanLyCa_Click(object sender, EventArgs e)
        {
            frmQuanLyCa frm = new frmQuanLyCa();
            frm.ShowDialog();
        }

        private void btnLichPhanCa_Click(object sender, EventArgs e)
        {
            frmLichLamViec frm = new frmLichLamViec();
            frm.ShowDialog();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            frmChamCong frm = new frmChamCong();
            frm.ShowDialog();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            frm.ShowDialog();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmLichSu frm = new frmLichSu();
            frm.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frm = new frmThongKe();
            frm.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi hệ thống?",
                "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                CurrentUser.Logout();
                this.Hide();
                frmDangNhap login = new frmDangNhap();
                login.Show();
            }
        }
    }
}
