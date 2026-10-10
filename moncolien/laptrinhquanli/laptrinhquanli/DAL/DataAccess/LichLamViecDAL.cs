using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class LichLamViecDAL : ILichLamViecDAL
    {
        public List<LichLamViec> GetAll()
        {
            List<LichLamViec> list = new List<LichLamViec>();
            string sql = @"SELECT l.MaLich, l.MaCa, l.ThuTrongTuan, l.MaNV, l.TrangThai,
                                  c.TenCa, c.GioBatDau, c.GioKetThuc, nv.HoTen AS TenNhanVien
                           FROM dbo.LichLamViec l
                           INNER JOIN dbo.CaLamViec c ON l.MaCa = c.MaCa
                           LEFT JOIN dbo.NhanVien nv ON l.MaNV = nv.MaNV
                           ORDER BY l.ThuTrongTuan, c.GioBatDau";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                var lich = new LichLamViec(
                    Convert.ToInt32(row["MaLich"]),
                    row["MaCa"].ToString(),
                    Convert.ToInt32(row["ThuTrongTuan"]),
                    row["MaNV"] != DBNull.Value ? row["MaNV"].ToString() : null,
                    row["TrangThai"].ToString()
                );
                lich.TenCa = row["TenCa"].ToString();
                lich.GioBatDau = (TimeSpan)row["GioBatDau"];
                lich.GioKetThuc = (TimeSpan)row["GioKetThuc"];
                lich.TenNhanVien = row["TenNhanVien"] != DBNull.Value ? row["TenNhanVien"].ToString() : "Chưa phân công";
                list.Add(lich);
            }
            return list;
        }

        public List<LichLamViec> GetByThu(int thuTrongTuan)
        {
            List<LichLamViec> list = new List<LichLamViec>();
            string sql = @"SELECT l.MaLich, l.MaCa, l.ThuTrongTuan, l.MaNV, l.TrangThai,
                                  c.TenCa, c.GioBatDau, c.GioKetThuc, nv.HoTen AS TenNhanVien
                           FROM dbo.LichLamViec l
                           INNER JOIN dbo.CaLamViec c ON l.MaCa = c.MaCa
                           LEFT JOIN dbo.NhanVien nv ON l.MaNV = nv.MaNV
                           WHERE l.ThuTrongTuan = @Thu
                           ORDER BY c.GioBatDau";
            SqlParameter[] parameters = {
                new SqlParameter("@Thu", SqlDbType.Int) { Value = thuTrongTuan }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                var lich = new LichLamViec(
                    Convert.ToInt32(row["MaLich"]),
                    row["MaCa"].ToString(),
                    Convert.ToInt32(row["ThuTrongTuan"]),
                    row["MaNV"] != DBNull.Value ? row["MaNV"].ToString() : null,
                    row["TrangThai"].ToString()
                );
                lich.TenCa = row["TenCa"].ToString();
                lich.GioBatDau = (TimeSpan)row["GioBatDau"];
                lich.GioKetThuc = (TimeSpan)row["GioKetThuc"];
                lich.TenNhanVien = row["TenNhanVien"] != DBNull.Value ? row["TenNhanVien"].ToString() : "Chưa phân công";
                list.Add(lich);
            }
            return list;
        }

        public bool PhanCong(string maCa, int thuTrongTuan, string maNV)
        {
            // Kiểm tra xem đã có bản ghi cho MaCa và ThuTrongTuan chưa
            string checkSql = "SELECT COUNT(*) FROM dbo.LichLamViec WHERE MaCa = @MaCa AND ThuTrongTuan = @Thu";
            SqlParameter[] checkParams = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa },
                new SqlParameter("@Thu", SqlDbType.Int) { Value = thuTrongTuan }
            };
            int count = Convert.ToInt32(DBConnection.ExecuteScalar(checkSql, checkParams));

            if (count > 0)
            {
                string updateSql = @"UPDATE dbo.LichLamViec 
                                     SET MaNV = @MaNV, TrangThai = @TrangThai 
                                     WHERE MaCa = @MaCa AND ThuTrongTuan = @Thu";
                SqlParameter[] updateParams = {
                    new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa },
                    new SqlParameter("@Thu", SqlDbType.Int) { Value = thuTrongTuan },
                    new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = (object)maNV ?? DBNull.Value },
                    new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = string.IsNullOrWhiteSpace(maNV) ? "Chưa phân công" : "Đã phân công" }
                };
                return DBConnection.ExecuteNonQuery(updateSql, updateParams) > 0;
            }
            else
            {
                string insertSql = @"INSERT INTO dbo.LichLamViec (MaCa, ThuTrongTuan, MaNV, TrangThai)
                                     VALUES (@MaCa, @Thu, @MaNV, @TrangThai)";
                SqlParameter[] insertParams = {
                    new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa },
                    new SqlParameter("@Thu", SqlDbType.Int) { Value = thuTrongTuan },
                    new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = (object)maNV ?? DBNull.Value },
                    new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = string.IsNullOrWhiteSpace(maNV) ? "Chưa phân công" : "Đã phân công" }
                };
                return DBConnection.ExecuteNonQuery(insertSql, insertParams) > 0;
            }
        }

        public bool XoaPhanCong(string maCa, int thuTrongTuan)
        {
            string sql = "UPDATE dbo.LichLamViec SET MaNV = NULL, TrangThai = N'Chưa phân công' WHERE MaCa = @MaCa AND ThuTrongTuan = @Thu";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa },
                new SqlParameter("@Thu", SqlDbType.Int) { Value = thuTrongTuan }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaTatCa()
        {
            string sql = "DELETE FROM dbo.LichLamViec";
            return DBConnection.ExecuteNonQuery(sql) >= 0;
        }
    }
}
