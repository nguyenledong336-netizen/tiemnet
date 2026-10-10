using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class MayTinh
    {
        public string MaMay { get; set; }
        public string TenMay { get; set; }
        public string LoaiMay { get; set; } // "Thường", "VIP"
        public decimal DonGiaGio { get; set; }
        public string TrangThai { get; set; } // "Trống", "Đang sử dụng", "Bảo trì"

        public MayTinh()
        {
            LoaiMay = "Thường";
            DonGiaGio = 10000;
            TrangThai = "Trống";
        }

        public MayTinh(string maMay, string tenMay, string loaiMay, decimal donGiaGio, string trangThai)
        {
            MaMay = maMay;
            TenMay = tenMay;
            LoaiMay = loaiMay;
            DonGiaGio = donGiaGio;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{TenMay} ({LoaiMay}) - {DonGiaGio:N0} đ/h";
        }
    }
}
