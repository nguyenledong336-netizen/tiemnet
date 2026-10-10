using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class HoaDonDAL : IHoaDonDAL
    {
        public List<HoaDon> GetAll()
        {
            List<HoaDon> list = new List<HoaDon>();
            string sql = @"SELECT hd.MaHD, hd.MaPhien, hd.MaNV, hd.NgayTao, hd.TienMay, hd.TienDichVu, 
                                  hd.TongTien, hd.PhuongThucThanhToan, hd.GhiChu,
                                  nv.HoTen AS TenNhanVien, m.TenMay, kh.HoTen AS TenKhachHang
                           FROM dbo.HoaDon hd
                           INNER JOIN dbo.NhanVien nv ON hd.MaNV = nv.MaNV
                           INNER JOIN dbo.PhienSuDung p ON hd.MaPhien = p.MaPhien
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang kh ON p.MaKH = kh.MaKH
                           ORDER BY hd.MaHD DESC";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                var hd = new HoaDon(
                    Convert.ToInt32(row["MaHD"]),
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["NgayTao"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["PhuongThucThanhToan"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                hd.TenNhanVien = row["TenNhanVien"].ToString();
                hd.TenMay = row["TenMay"].ToString();
                hd.TenKhachHang = row["TenKhachHang"].ToString();
                list.Add(hd);
            }
            return list;
        }

        public HoaDon GetById(int maHD)
        {
            string sql = @"SELECT hd.MaHD, hd.MaPhien, hd.MaNV, hd.NgayTao, hd.TienMay, hd.TienDichVu, 
                                  hd.TongTien, hd.PhuongThucThanhToan, hd.GhiChu,
                                  nv.HoTen AS TenNhanVien, m.TenMay, kh.HoTen AS TenKhachHang
                           FROM dbo.HoaDon hd
                           INNER JOIN dbo.NhanVien nv ON hd.MaNV = nv.MaNV
                           INNER JOIN dbo.PhienSuDung p ON hd.MaPhien = p.MaPhien
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang kh ON p.MaKH = kh.MaKH
                           WHERE hd.MaHD = @MaHD";
            SqlParameter[] parameters = {
                new SqlParameter("@MaHD", SqlDbType.Int) { Value = maHD }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var hd = new HoaDon(
                    Convert.ToInt32(row["MaHD"]),
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["NgayTao"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["PhuongThucThanhToan"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                hd.TenNhanVien = row["TenNhanVien"].ToString();
                hd.TenMay = row["TenMay"].ToString();
                hd.TenKhachHang = row["TenKhachHang"].ToString();
                return hd;
            }
            return null;
        }

        public HoaDon GetByMaPhien(int maPhien)
        {
            string sql = @"SELECT hd.MaHD, hd.MaPhien, hd.MaNV, hd.NgayTao, hd.TienMay, hd.TienDichVu, 
                                  hd.TongTien, hd.PhuongThucThanhToan, hd.GhiChu,
                                  nv.HoTen AS TenNhanVien, m.TenMay, kh.HoTen AS TenKhachHang
                           FROM dbo.HoaDon hd
                           INNER JOIN dbo.NhanVien nv ON hd.MaNV = nv.MaNV
                           INNER JOIN dbo.PhienSuDung p ON hd.MaPhien = p.MaPhien
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang kh ON p.MaKH = kh.MaKH
                           WHERE hd.MaPhien = @MaPhien";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var hd = new HoaDon(
                    Convert.ToInt32(row["MaHD"]),
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["NgayTao"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["PhuongThucThanhToan"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                hd.TenNhanVien = row["TenNhanVien"].ToString();
                hd.TenMay = row["TenMay"].ToString();
                hd.TenKhachHang = row["TenKhachHang"].ToString();
                return hd;
            }
            return null;
        }

        public int ThemHoaDon(HoaDon hd)
        {
            string sql = @"
                INSERT INTO dbo.HoaDon (MaPhien, MaNV, NgayTao, TienMay, TienDichVu, TongTien, PhuongThucThanhToan, GhiChu)
                VALUES (@MaPhien, @MaNV, @NgayTao, @TienMay, @TienDichVu, @TongTien, @PhuongThucThanhToan, @GhiChu);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = hd.MaPhien },
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = hd.MaNV },
                new SqlParameter("@NgayTao", SqlDbType.DateTime) { Value = hd.NgayTao },
                new SqlParameter("@TienMay", SqlDbType.Decimal) { Value = hd.TienMay },
                new SqlParameter("@TienDichVu", SqlDbType.Decimal) { Value = hd.TienDichVu },
                new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = hd.TongTien },
                new SqlParameter("@PhuongThucThanhToan", SqlDbType.NVarChar, 50) { Value = hd.PhuongThucThanhToan },
                new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) { Value = (object)hd.GhiChu ?? DBNull.Value }
            };

            object result = DBConnection.ExecuteScalar(sql, parameters);
            if (result != null && int.TryParse(result.ToString(), out int id))
            {
                return id;
            }
            return 0;
        }

        public List<HoaDon> TimKiem(DateTime? tuNgay, DateTime? denNgay, string phuongThuc)
        {
            List<HoaDon> list = new List<HoaDon>();
            string sql = @"SELECT hd.MaHD, hd.MaPhien, hd.MaNV, hd.NgayTao, hd.TienMay, hd.TienDichVu, 
                                  hd.TongTien, hd.PhuongThucThanhToan, hd.GhiChu,
                                  nv.HoTen AS TenNhanVien, m.TenMay, kh.HoTen AS TenKhachHang
                           FROM dbo.HoaDon hd
                           INNER JOIN dbo.NhanVien nv ON hd.MaNV = nv.MaNV
                           INNER JOIN dbo.PhienSuDung p ON hd.MaPhien = p.MaPhien
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang kh ON p.MaKH = kh.MaKH
                           WHERE 1=1";

            List<SqlParameter> paramList = new List<SqlParameter>();
            if (tuNgay.HasValue)
            {
                sql += " AND hd.NgayTao >= @TuNgay";
                paramList.Add(new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay.Value });
            }
            if (denNgay.HasValue)
            {
                sql += " AND hd.NgayTao <= @DenNgay";
                paramList.Add(new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay.Value });
            }
            if (!string.IsNullOrWhiteSpace(phuongThuc) && phuongThuc != "Tất cả")
            {
                sql += " AND hd.PhuongThucThanhToan = @PhuongThuc";
                paramList.Add(new SqlParameter("@PhuongThuc", SqlDbType.NVarChar, 50) { Value = phuongThuc });
            }

            sql += " ORDER BY hd.MaHD DESC";

            DataTable dt = DBConnection.ExecuteQuery(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                var hd = new HoaDon(
                    Convert.ToInt32(row["MaHD"]),
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["NgayTao"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["PhuongThucThanhToan"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                hd.TenNhanVien = row["TenNhanVien"].ToString();
                hd.TenMay = row["TenMay"].ToString();
                hd.TenKhachHang = row["TenKhachHang"].ToString();
                list.Add(hd);
            }
            return list;
        }
    }
}
