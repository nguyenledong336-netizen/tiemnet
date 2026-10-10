using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class KhachHangDAL : IKhachHangDAL
    {
        public List<KhachHang> GetAll()
        {
            List<KhachHang> list = new List<KhachHang>();
            string sql = "SELECT MaKH, HoTen, SoDienThoai, SoDu, TrangThai FROM dbo.KhachHang ORDER BY MaKH";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhachHang(
                    row["MaKH"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    Convert.ToDecimal(row["SoDu"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public KhachHang GetById(string maKH)
        {
            string sql = "SELECT MaKH, HoTen, SoDienThoai, SoDu, TrangThai FROM dbo.KhachHang WHERE MaKH = @MaKH";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = maKH }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new KhachHang(
                    row["MaKH"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    Convert.ToDecimal(row["SoDu"]),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public List<KhachHang> TimKiem(string keyword)
        {
            List<KhachHang> list = new List<KhachHang>();
            string sql = "SELECT MaKH, HoTen, SoDienThoai, SoDu, TrangThai FROM dbo.KhachHang " +
                         "WHERE MaKH LIKE @Keyword OR HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword ORDER BY MaKH";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhachHang(
                    row["MaKH"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    Convert.ToDecimal(row["SoDu"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public bool Them(KhachHang kh)
        {
            string sql = "INSERT INTO dbo.KhachHang (MaKH, HoTen, SoDienThoai, SoDu, TrangThai) " +
                         "VALUES (@MaKH, @HoTen, @SoDienThoai, @SoDu, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = kh.MaKH },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = kh.HoTen },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 20) { Value = (object)kh.SoDienThoai ?? DBNull.Value },
                new SqlParameter("@SoDu", SqlDbType.Decimal) { Value = kh.SoDu },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = kh.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(KhachHang kh)
        {
            string sql = "UPDATE dbo.KhachHang SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, " +
                         "SoDu = @SoDu, TrangThai = @TrangThai WHERE MaKH = @MaKH";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = kh.MaKH },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = kh.HoTen },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 20) { Value = (object)kh.SoDienThoai ?? DBNull.Value },
                new SqlParameter("@SoDu", SqlDbType.Decimal) { Value = kh.SoDu },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = kh.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CongTien(string maKH, decimal soTien)
        {
            string sql = "UPDATE dbo.KhachHang SET SoDu = SoDu + @SoTien WHERE MaKH = @MaKH";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = maKH },
                new SqlParameter("@SoTien", SqlDbType.Decimal) { Value = soTien }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool TruTien(string maKH, decimal soTien)
        {
            string sql = "UPDATE dbo.KhachHang SET SoDu = SoDu - @SoTien WHERE MaKH = @MaKH AND SoDu >= @SoTien";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = maKH },
                new SqlParameter("@SoTien", SqlDbType.Decimal) { Value = soTien }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string maKH)
        {
            string sql = "DELETE FROM dbo.KhachHang WHERE MaKH = @MaKH";
            SqlParameter[] parameters = {
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = maKH }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
