using System;
using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IPhienSuDungDAL
    {
        List<PhienSuDung> GetAll();
        PhienSuDung GetById(int maPhien);
        PhienSuDung GetPhienHienTaiCuaMay(string maMay);
        int MoPhien(PhienSuDung phien);
        bool CapNhatTien(int maPhien, decimal tienMay, decimal tienDichVu, decimal tongTien);
        bool DongPhien(int maPhien, DateTime thoiGianKetThuc, decimal tienMay, decimal tienDichVu, decimal tongTien);
        bool HuyPhien(int maPhien);
        List<PhienSuDung> TimKiem(DateTime? tuNgay, DateTime? denNgay, string maMay, string maNV, string maKH);
    }
}
