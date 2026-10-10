using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IChiTietDichVuDAL
    {
        List<ChiTietDichVu> GetByMaPhien(int maPhien);
        bool ThemChiTiet(ChiTietDichVu ct);
        bool XoaChiTiet(int maCTDV);
        decimal TinhTongTienDichVuCuaPhien(int maPhien);
    }
}
