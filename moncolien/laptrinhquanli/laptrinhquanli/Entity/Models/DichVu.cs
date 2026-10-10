using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class DichVu
    {
        public string MaDV { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; }
        public string TrangThai { get; set; } // "Còn hàng", "Hết hàng", "Ngừng kinh doanh"

        public DichVu()
        {
            DonGia = 0;
            DonViTinh = "Phần";
            TrangThai = "Còn hàng";
        }

        public DichVu(string maDV, string tenDV, decimal donGia, string donViTinh, string trangThai)
        {
            MaDV = maDV;
            TenDV = tenDV;
            DonGia = donGia;
            DonViTinh = donViTinh;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{TenDV} ({DonGia:N0} đ / {DonViTinh})";
        }
    }
}
