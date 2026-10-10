using System;
using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IHoaDonDAL
    {
        List<HoaDon> GetAll();
        HoaDon GetById(int maHD);
        HoaDon GetByMaPhien(int maPhien);
        int ThemHoaDon(HoaDon hd);
        List<HoaDon> TimKiem(DateTime? tuNgay, DateTime? denNgay, string phuongThuc);
    }
}
