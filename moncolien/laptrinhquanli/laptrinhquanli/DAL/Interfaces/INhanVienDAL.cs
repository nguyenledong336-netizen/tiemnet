using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface INhanVienDAL
    {
        List<NhanVien> GetAll();
        NhanVien GetById(string maNV);
        List<NhanVien> TimKiem(string keyword);
        bool Them(NhanVien nv);
        bool CapNhat(NhanVien nv);
        bool Xoa(string maNV);
    }
}
