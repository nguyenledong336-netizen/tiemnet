using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class HoaDon
    {
        public int MaHD { get; set; }
        public int MaPhien { get; set; }
        public string MaNV { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal TienMay { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string PhuongThucThanhToan { get; set; } // "Tiền mặt", "Chuyển khoản"
        public string GhiChu { get; set; }

        // Extended properties for display
        public string TenNhanVien { get; set; }
        public string TenMay { get; set; }
        public string TenKhachHang { get; set; }

        public HoaDon()
        {
            NgayTao = DateTime.Now;
            TienMay = 0;
            TienDichVu = 0;
            TongTien = 0;
            PhuongThucThanhToan = "Tiền mặt";
        }

        public HoaDon(int maHD, int maPhien, string maNV, DateTime ngayTao, decimal tienMay, decimal tienDichVu,
            decimal tongTien, string phuongThucThanhToan, string ghiChu)
        {
            MaHD = maHD;
            MaPhien = maPhien;
            MaNV = maNV;
            NgayTao = ngayTao;
            TienMay = tienMay;
            TienDichVu = tienDichVu;
            TongTien = tongTien;
            PhuongThucThanhToan = phuongThucThanhToan;
            GhiChu = ghiChu;
        }
    }
}
