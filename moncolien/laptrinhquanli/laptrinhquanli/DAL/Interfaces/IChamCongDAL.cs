using System;
using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IChamCongDAL
    {
        List<ChamCong> GetAll();
        List<ChamCong> GetByNhanVien(string maNV);
        List<ChamCong> TimKiem(string maNV, DateTime? tuNgay, DateTime? denNgay);
        ChamCong GetChamCongHienTai(string maNV, DateTime ngay);
        bool ChamCongVao(string maNV, TimeSpan gioVao, string ghiChu);
        bool ChamCongRa(int maChamCong, TimeSpan gioRa, string ghiChu);
        bool Xoa(int maChamCong);
    }
}
