using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class ChiTietDichVu
    {
        public int MaCTDV { get; set; }
        public int MaPhien { get; set; }
        public string MaDV { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
        public DateTime ThoiGianDat { get; set; }

        // Extended properties for display
        public string TenDV { get; set; }
        public string DonViTinh { get; set; }

        public ChiTietDichVu()
        {
            SoLuong = 1;
            DonGia = 0;
            ThanhTien = 0;
            ThoiGianDat = DateTime.Now;
        }

        public ChiTietDichVu(int maCTDV, int maPhien, string maDV, int soLuong, decimal donGia, decimal thanhTien, DateTime thoiGianDat)
        {
            MaCTDV = maCTDV;
            MaPhien = maPhien;
            MaDV = maDV;
            SoLuong = soLuong;
            DonGia = donGia;
            ThanhTien = thanhTien;
            ThoiGianDat = thoiGianDat;
        }
    }
}
