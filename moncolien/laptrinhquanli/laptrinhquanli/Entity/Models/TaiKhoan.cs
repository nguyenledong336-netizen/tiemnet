using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string MaNV { get; set; }
        public string VaiTro { get; set; }
        public string TrangThai { get; set; }

        public TaiKhoan()
        {
            TrangThai = "Hoạt động";
        }

        public TaiKhoan(string tenDangNhap, string matKhau, string maNV, string vaiTro, string trangThai)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            MaNV = maNV;
            VaiTro = vaiTro;
            TrangThai = trangThai;
        }
    }
}
