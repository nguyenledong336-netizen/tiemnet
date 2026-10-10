using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string VaiTro { get; set; }
        public decimal Luong { get; set; }
        public string TrangThai { get; set; }

        public NhanVien()
        {
            VaiTro = "Nhân viên";
            Luong = 0;
            TrangThai = "Đang làm việc";
        }

        public NhanVien(string maNV, string hoTen, string soDienThoai, string vaiTro, decimal luong, string trangThai)
        {
            MaNV = maNV;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            VaiTro = vaiTro;
            Luong = luong;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{MaNV} - {HoTen}";
        }
    }
}
