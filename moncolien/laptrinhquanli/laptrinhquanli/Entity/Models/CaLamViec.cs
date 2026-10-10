using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class CaLamViec
    {
        public string MaCa { get; set; }
        public string TenCa { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }

        public CaLamViec()
        {
        }

        public CaLamViec(string maCa, string tenCa, TimeSpan gioBatDau, TimeSpan gioKetThuc)
        {
            MaCa = maCa;
            TenCa = tenCa;
            GioBatDau = gioBatDau;
            GioKetThuc = gioKetThuc;
        }

        public override string ToString()
        {
            return $"{TenCa} ({GioBatDau:hh\\:mm} - {GioKetThuc:hh\\:mm})";
        }
    }
}
