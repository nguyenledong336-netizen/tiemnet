using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class PhienSuDung
    {
        public int MaPhien { get; set; }
        public string MaMay { get; set; }
        public string MaKH { get; set; }
        public string MaNV { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public decimal DonGiaGio { get; set; }
        public decimal TienMay { get; set; }
        public decimal TienDichVu { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; } // "Đang sử dụng", "Đã thanh toán", "Đã hủy"

        // Extended properties for display
        public string TenMay { get; set; }
        public string TenKhachHang { get; set; }
        public string TenNhanVien { get; set; }

        public PhienSuDung()
        {
            ThoiGianBatDau = DateTime.Now;
            DonGiaGio = 10000;
            TienMay = 0;
            TienDichVu = 0;
            TongTien = 0;
            TrangThai = "Đang sử dụng";
        }

        public PhienSuDung(int maPhien, string maMay, string maKH, string maNV, DateTime thoiGianBatDau,
            DateTime? thoiGianKetThuc, decimal donGiaGio, decimal tienMay, decimal tienDichVu, decimal tongTien, string trangThai)
        {
            MaPhien = maPhien;
            MaMay = maMay;
            MaKH = maKH;
            MaNV = maNV;
            ThoiGianBatDau = thoiGianBatDau;
            ThoiGianKetThuc = thoiGianKetThuc;
            DonGiaGio = donGiaGio;
            TienMay = tienMay;
            TienDichVu = tienDichVu;
            TongTien = tongTien;
            TrangThai = trangThai;
        }

        /// <summary>
        /// Tính toán thời gian đã sử dụng tính đến thời điểm hiện tại hoặc thời gian kết thúc
        /// </summary>
        public TimeSpan ThoiGianSuDung
        {
            get
            {
                DateTime end = ThoiGianKetThuc.HasValue ? ThoiGianKetThuc.Value : DateTime.Now;
                if (end < ThoiGianBatDau) return TimeSpan.Zero;
                return end - ThoiGianBatDau;
            }
        }

        /// <summary>
        /// Tính toán tiền máy chính xác dựa trên thời gian sử dụng và đơn giá giờ
        /// </summary>
        public decimal TinhTienMayHienTai()
        {
            TimeSpan duration = ThoiGianSuDung;
            double hours = duration.TotalHours;
            // Tối thiểu tính 15 phút hoặc tính chính xác theo số phút thực tế
            decimal tien = (decimal)hours * DonGiaGio;
            return Math.Round(tien, 0);
        }
    }
}
