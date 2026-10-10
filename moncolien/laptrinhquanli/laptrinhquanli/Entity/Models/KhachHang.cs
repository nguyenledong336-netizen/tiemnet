using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class KhachHang
    {
        public string MaKH { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public decimal SoDu { get; set; }
        public string TrangThai { get; set; }

        public KhachHang()
        {
            SoDu = 0;
            TrangThai = "Hoạt động";
        }

        public KhachHang(string maKH, string hoTen, string soDienThoai, decimal soDu, string trangThai)
        {
            MaKH = maKH;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            SoDu = soDu;
            TrangThai = trangThai;
        }

        public override string ToString()
        {
            return $"{MaKH} - {HoTen}";
        }
    }
}
