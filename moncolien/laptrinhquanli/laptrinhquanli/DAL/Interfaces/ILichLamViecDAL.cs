using System.Collections.Generic;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.Interfaces
{
    public interface ILichLamViecDAL
    {
        List<LichLamViec> GetAll();
        List<LichLamViec> GetByThu(int thuTrongTuan);
        bool PhanCong(string maCa, int thuTrongTuan, string maNV);
        bool XoaPhanCong(string maCa, int thuTrongTuan);
        bool XoaTatCa();
    }
}
