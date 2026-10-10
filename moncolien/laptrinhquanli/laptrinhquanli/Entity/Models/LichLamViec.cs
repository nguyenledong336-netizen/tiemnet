using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class LichLamViec
    {
        public int MaLich { get; set; }
        public string MaCa { get; set; }
        public int ThuTrongTuan { get; set; } // 2 -> 8 (2: Thứ 2, ..., 8: Chủ nhật)
        public string MaNV { get; set; }
        public string TrangThai { get; set; } // "Đã phân công", "Chưa phân công"

        // Extended properties
        public string TenCa { get; set; }
        public string TenNhanVien { get; set; }
        public TimeSpan GioBatDau { get; set; }
        public TimeSpan GioKetThuc { get; set; }

        public LichLamViec()
        {
            TrangThai = "Chưa phân công";
        }

        public LichLamViec(int maLich, string maCa, int thuTrongTuan, string maNV, string trangThai)
        {
            MaLich = maLich;
            MaCa = maCa;
            ThuTrongTuan = thuTrongTuan;
            MaNV = maNV;
            TrangThai = trangThai;
        }

        public string TenThu
        {
            get
            {
                switch (ThuTrongTuan)
                {
                    case 2: return "Thứ 2";
                    case 3: return "Thứ 3";
                    case 4: return "Thứ 4";
                    case 5: return "Thứ 5";
                    case 6: return "Thứ 6";
                    case 7: return "Thứ 7";
                    case 8: return "Chủ nhật";
                    default: return "Thứ " + ThuTrongTuan;
                }
            }
        }
    }
}
