using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IKhachHangDAL
    {
        List<KhachHang> GetAll();
        KhachHang GetById(string maKH);
        List<KhachHang> TimKiem(string keyword);
        bool Them(KhachHang kh);
        bool CapNhat(KhachHang kh);
        bool CongTien(string maKH, decimal soTien);
        bool TruTien(string maKH, decimal soTien);
        bool Xoa(string maKH);
    }
}
