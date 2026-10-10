using System;

namespace QuanLyTiemNet.Entity.Models
{
    public class ChamCong
    {
        public int MaChamCong { get; set; }
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public TimeSpan GioVao { get; set; }
        public TimeSpan? GioRa { get; set; }
        public string TrangThai { get; set; } // "Đang làm việc", "Đã hoàn thành"
        public string GhiChu { get; set; }

        // Extended property
        public string TenNhanVien { get; set; }

        public ChamCong()
        {
            Ngay = DateTime.Today;
            TrangThai = "Đang làm việc";
        }

        public ChamCong(int maChamCong, string maNV, DateTime ngay, TimeSpan gioVao, TimeSpan? gioRa, string trangThai, string ghiChu)
        {
            MaChamCong = maChamCong;
            MaNV = maNV;
            Ngay = ngay;
            GioVao = gioVao;
            GioRa = gioRa;
            TrangThai = trangThai;
            GhiChu = ghiChu;
        }

        public double SoGioLam
        {
            get
            {
                if (GioRa.HasValue)
                {
                    TimeSpan duration = GioRa.Value - GioVao;
                    if (duration.TotalMinutes < 0)
                    {
                        // Ca đêm qua ngày hôm sau
                        duration = duration.Add(TimeSpan.FromHours(24));
                    }
                    return Math.Round(duration.TotalHours, 2);
                }
                return 0;
            }
        }
    }
}
