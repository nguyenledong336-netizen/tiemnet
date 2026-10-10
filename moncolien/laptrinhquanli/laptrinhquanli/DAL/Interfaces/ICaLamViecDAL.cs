using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface ICaLamViecDAL
    {
        List<CaLamViec> GetAll();
        CaLamViec GetById(string maCa);
        bool Them(CaLamViec ca);
        bool CapNhat(CaLamViec ca);
        bool Xoa(string maCa);
    }
}
