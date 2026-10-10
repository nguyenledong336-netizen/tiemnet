using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface IMayTinhDAL
    {
        List<MayTinh> GetAll();
        MayTinh GetById(string maMay);
        List<MayTinh> GetByTrangThai(string trangThai);
        List<MayTinh> GetByLoaiMay(string loaiMay);
        List<MayTinh> TimKiem(string keyword);
        bool Them(MayTinh mt);
        bool CapNhat(MayTinh mt);
        bool CapNhatTrangThai(string maMay, string trangThaiMoi);
        bool Xoa(string maMay);
    }
}
