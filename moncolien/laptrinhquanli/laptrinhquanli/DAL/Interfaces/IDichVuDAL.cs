using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IDichVuDAL
    {
        List<DichVu> GetAll();
        List<DichVu> GetConHang();
        DichVu GetById(string maDV);
        List<DichVu> TimKiem(string keyword);
        bool Them(DichVu dv);
        bool CapNhat(DichVu dv);
        bool BatTatTrangThai(string maDV, string trangThaiMoi);
        bool Xoa(string maDV);
    }
}
