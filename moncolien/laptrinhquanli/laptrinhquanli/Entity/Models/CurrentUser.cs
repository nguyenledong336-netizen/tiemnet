using System;

namespace QuanLyTiemNet.Entity.Models
{
    public static class CurrentUser
    {
        public static TaiKhoan TaiKhoan { get; set; }
        public static NhanVien NhanVien { get; set; }

        public static string TenDangNhap => TaiKhoan?.TenDangNhap;
        public static string MaNV => NhanVien?.MaNV ?? TaiKhoan?.MaNV;
        public static string HoTen => NhanVien?.HoTen ?? "Người dùng";
        public static string VaiTro => TaiKhoan?.VaiTro ?? "Nhân viên";

        public static bool IsLoggedIn => TaiKhoan != null;

        public static bool IsQuanLy => string.Equals(VaiTro, "Quản lý", StringComparison.OrdinalIgnoreCase);

        public static bool IsNhanVien => string.Equals(VaiTro, "Nhân viên", StringComparison.OrdinalIgnoreCase);

        public static void SetUser(TaiKhoan taiKhoan, NhanVien nhanVien)
        {
            TaiKhoan = taiKhoan;
            NhanVien = nhanVien;
        }

        public static void Logout()
        {
            TaiKhoan = null;
            NhanVien = null;
        }
    }
}
