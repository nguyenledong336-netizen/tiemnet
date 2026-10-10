using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class NhanVienDAL : INhanVienDAL
    {
        public List<NhanVien> GetAll()
        {
            List<NhanVien> list = new List<NhanVien>();
            string sql = "SELECT MaNV, HoTen, SoDienThoai, VaiTro, Luong, TrangThai FROM dbo.NhanVien";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhanVien(
                    row["MaNV"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    row["VaiTro"].ToString(),
                    Convert.ToDecimal(row["Luong"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public NhanVien GetById(string maNV)
        {
            string sql = "SELECT MaNV, HoTen, SoDienThoai, VaiTro, Luong, TrangThai FROM dbo.NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new NhanVien(
                    row["MaNV"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    row["VaiTro"].ToString(),
                    Convert.ToDecimal(row["Luong"]),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public List<NhanVien> TimKiem(string keyword)
        {
            List<NhanVien> list = new List<NhanVien>();
            string sql = "SELECT MaNV, HoTen, SoDienThoai, VaiTro, Luong, TrangThai FROM dbo.NhanVien " +
                         "WHERE MaNV LIKE @Keyword OR HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new NhanVien(
                    row["MaNV"].ToString(),
                    row["HoTen"].ToString(),
                    row["SoDienThoai"] != DBNull.Value ? row["SoDienThoai"].ToString() : "",
                    row["VaiTro"].ToString(),
                    Convert.ToDecimal(row["Luong"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public bool Them(NhanVien nv)
        {
            string sql = "INSERT INTO dbo.NhanVien (MaNV, HoTen, SoDienThoai, VaiTro, Luong, TrangThai) " +
                         "VALUES (@MaNV, @HoTen, @SoDienThoai, @VaiTro, @Luong, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = nv.MaNV },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = nv.HoTen },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 20) { Value = (object)nv.SoDienThoai ?? DBNull.Value },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 50) { Value = nv.VaiTro },
                new SqlParameter("@Luong", SqlDbType.Decimal) { Value = nv.Luong },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = nv.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(NhanVien nv)
        {
            string sql = "UPDATE dbo.NhanVien SET HoTen = @HoTen, SoDienThoai = @SoDienThoai, VaiTro = @VaiTro, " +
                         "Luong = @Luong, TrangThai = @TrangThai WHERE MaNV = @MaNV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = nv.MaNV },
                new SqlParameter("@HoTen", SqlDbType.NVarChar, 100) { Value = nv.HoTen },
                new SqlParameter("@SoDienThoai", SqlDbType.NVarChar, 20) { Value = (object)nv.SoDienThoai ?? DBNull.Value },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 50) { Value = nv.VaiTro },
                new SqlParameter("@Luong", SqlDbType.Decimal) { Value = nv.Luong },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = nv.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string maNV)
        {
            string sql = "DELETE FROM dbo.NhanVien WHERE MaNV = @MaNV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
