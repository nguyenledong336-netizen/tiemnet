using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class ChamCongDAL : IChamCongDAL
    {
        public List<ChamCong> GetAll()
        {
            List<ChamCong> list = new List<ChamCong>();
            string sql = @"SELECT c.MaChamCong, c.MaNV, c.Ngay, c.GioVao, c.GioRa, c.TrangThai, c.GhiChu,
                                  nv.HoTen AS TenNhanVien
                           FROM dbo.ChamCong c
                           INNER JOIN dbo.NhanVien nv ON c.MaNV = nv.MaNV
                           ORDER BY c.Ngay DESC, c.GioVao DESC";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                var cc = new ChamCong(
                    Convert.ToInt32(row["MaChamCong"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["Ngay"]),
                    (TimeSpan)row["GioVao"],
                    row["GioRa"] != DBNull.Value ? (TimeSpan?)row["GioRa"] : null,
                    row["TrangThai"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                cc.TenNhanVien = row["TenNhanVien"].ToString();
                list.Add(cc);
            }
            return list;
        }

        public List<ChamCong> GetByNhanVien(string maNV)
        {
            List<ChamCong> list = new List<ChamCong>();
            string sql = @"SELECT c.MaChamCong, c.MaNV, c.Ngay, c.GioVao, c.GioRa, c.TrangThai, c.GhiChu,
                                  nv.HoTen AS TenNhanVien
                           FROM dbo.ChamCong c
                           INNER JOIN dbo.NhanVien nv ON c.MaNV = nv.MaNV
                           WHERE c.MaNV = @MaNV
                           ORDER BY c.Ngay DESC, c.GioVao DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                var cc = new ChamCong(
                    Convert.ToInt32(row["MaChamCong"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["Ngay"]),
                    (TimeSpan)row["GioVao"],
                    row["GioRa"] != DBNull.Value ? (TimeSpan?)row["GioRa"] : null,
                    row["TrangThai"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                cc.TenNhanVien = row["TenNhanVien"].ToString();
                list.Add(cc);
            }
            return list;
        }

        public List<ChamCong> TimKiem(string maNV, DateTime? tuNgay, DateTime? denNgay)
        {
            List<ChamCong> list = new List<ChamCong>();
            string sql = @"SELECT c.MaChamCong, c.MaNV, c.Ngay, c.GioVao, c.GioRa, c.TrangThai, c.GhiChu,
                                  nv.HoTen AS TenNhanVien
                           FROM dbo.ChamCong c
                           INNER JOIN dbo.NhanVien nv ON c.MaNV = nv.MaNV
                           WHERE 1=1";

            List<SqlParameter> paramList = new List<SqlParameter>();
            if (!string.IsNullOrWhiteSpace(maNV) && maNV != "Tất cả")
            {
                sql += " AND c.MaNV = @MaNV";
                paramList.Add(new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV });
            }
            if (tuNgay.HasValue)
            {
                sql += " AND c.Ngay >= @TuNgay";
                paramList.Add(new SqlParameter("@TuNgay", SqlDbType.Date) { Value = tuNgay.Value.Date });
            }
            if (denNgay.HasValue)
            {
                sql += " AND c.Ngay <= @DenNgay";
                paramList.Add(new SqlParameter("@DenNgay", SqlDbType.Date) { Value = denNgay.Value.Date });
            }

            sql += " ORDER BY c.Ngay DESC, c.GioVao DESC";

            DataTable dt = DBConnection.ExecuteQuery(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                var cc = new ChamCong(
                    Convert.ToInt32(row["MaChamCong"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["Ngay"]),
                    (TimeSpan)row["GioVao"],
                    row["GioRa"] != DBNull.Value ? (TimeSpan?)row["GioRa"] : null,
                    row["TrangThai"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                cc.TenNhanVien = row["TenNhanVien"].ToString();
                list.Add(cc);
            }
            return list;
        }

        public ChamCong GetChamCongHienTai(string maNV, DateTime ngay)
        {
            string sql = @"SELECT TOP 1 c.MaChamCong, c.MaNV, c.Ngay, c.GioVao, c.GioRa, c.TrangThai, c.GhiChu,
                                  nv.HoTen AS TenNhanVien
                           FROM dbo.ChamCong c
                           INNER JOIN dbo.NhanVien nv ON c.MaNV = nv.MaNV
                           WHERE c.MaNV = @MaNV AND c.Ngay = @Ngay AND c.TrangThai = N'Đang làm việc'
                           ORDER BY c.MaChamCong DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV },
                new SqlParameter("@Ngay", SqlDbType.Date) { Value = ngay.Date }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var cc = new ChamCong(
                    Convert.ToInt32(row["MaChamCong"]),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["Ngay"]),
                    (TimeSpan)row["GioVao"],
                    row["GioRa"] != DBNull.Value ? (TimeSpan?)row["GioRa"] : null,
                    row["TrangThai"].ToString(),
                    row["GhiChu"] != DBNull.Value ? row["GhiChu"].ToString() : ""
                );
                cc.TenNhanVien = row["TenNhanVien"].ToString();
                return cc;
            }
            return null;
        }

        public bool ChamCongVao(string maNV, TimeSpan gioVao, string ghiChu)
        {
            string sql = @"INSERT INTO dbo.ChamCong (MaNV, Ngay, GioVao, TrangThai, GhiChu)
                           VALUES (@MaNV, CAST(GETDATE() AS DATE), @GioVao, N'Đang làm việc', @GhiChu)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV },
                new SqlParameter("@GioVao", SqlDbType.Time) { Value = gioVao },
                new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) { Value = (object)ghiChu ?? DBNull.Value }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool ChamCongRa(int maChamCong, TimeSpan gioRa, string ghiChu)
        {
            string sql = @"UPDATE dbo.ChamCong 
                           SET GioRa = @GioRa, TrangThai = N'Đã hoàn thành',
                               GhiChu = CASE WHEN @GhiChu IS NOT NULL AND @GhiChu != '' THEN @GhiChu ELSE GhiChu END
                           WHERE MaChamCong = @MaChamCong";
            SqlParameter[] parameters = {
                new SqlParameter("@MaChamCong", SqlDbType.Int) { Value = maChamCong },
                new SqlParameter("@GioRa", SqlDbType.Time) { Value = gioRa },
                new SqlParameter("@GhiChu", SqlDbType.NVarChar, 255) { Value = (object)ghiChu ?? DBNull.Value }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(int maChamCong)
        {
            string sql = "DELETE FROM dbo.ChamCong WHERE MaChamCong = @MaChamCong";
            SqlParameter[] parameters = {
                new SqlParameter("@MaChamCong", SqlDbType.Int) { Value = maChamCong }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
