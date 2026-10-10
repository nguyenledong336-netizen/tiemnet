using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface ITaiKhoanDAL
    {
        List<TaiKhoan> GetAll();
        TaiKhoan GetByUsername(string username);
        TaiKhoan KiemTraDangNhap(string username, string password);
        bool Them(TaiKhoan tk);
        bool CapNhat(TaiKhoan tk);
        bool DoiMatKhau(string username, string matKhauMoi);
        bool Xoa(string username);
        bool KhoaTaiKhoan(string username, bool khoa);
    }
}
