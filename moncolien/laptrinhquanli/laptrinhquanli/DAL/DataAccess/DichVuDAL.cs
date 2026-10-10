using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class DichVuDAL : IDichVuDAL
    {
        public List<DichVu> GetAll()
        {
            List<DichVu> list = new List<DichVu>();
            string sql = "SELECT MaDV, TenDV, DonGia, DonViTinh, TrangThai FROM dbo.DichVu ORDER BY MaDV";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DichVu(
                    row["MaDV"].ToString(),
                    row["TenDV"].ToString(),
                    Convert.ToDecimal(row["DonGia"]),
                    row["DonViTinh"].ToString(),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public List<DichVu> GetConHang()
        {
            List<DichVu> list = new List<DichVu>();
            string sql = "SELECT MaDV, TenDV, DonGia, DonViTinh, TrangThai FROM dbo.DichVu WHERE TrangThai = N'Còn hàng' ORDER BY MaDV";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DichVu(
                    row["MaDV"].ToString(),
                    row["TenDV"].ToString(),
                    Convert.ToDecimal(row["DonGia"]),
                    row["DonViTinh"].ToString(),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public DichVu GetById(string maDV)
        {
            string sql = "SELECT MaDV, TenDV, DonGia, DonViTinh, TrangThai FROM dbo.DichVu WHERE MaDV = @MaDV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = maDV }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DichVu(
                    row["MaDV"].ToString(),
                    row["TenDV"].ToString(),
                    Convert.ToDecimal(row["DonGia"]),
                    row["DonViTinh"].ToString(),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public List<DichVu> TimKiem(string keyword)
        {
            List<DichVu> list = new List<DichVu>();
            string sql = "SELECT MaDV, TenDV, DonGia, DonViTinh, TrangThai FROM dbo.DichVu " +
                         "WHERE MaDV LIKE @Keyword OR TenDV LIKE @Keyword ORDER BY MaDV";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DichVu(
                    row["MaDV"].ToString(),
                    row["TenDV"].ToString(),
                    Convert.ToDecimal(row["DonGia"]),
                    row["DonViTinh"].ToString(),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public bool Them(DichVu dv)
        {
            string sql = "INSERT INTO dbo.DichVu (MaDV, TenDV, DonGia, DonViTinh, TrangThai) " +
                         "VALUES (@MaDV, @TenDV, @DonGia, @DonViTinh, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = dv.MaDV },
                new SqlParameter("@TenDV", SqlDbType.NVarChar, 100) { Value = dv.TenDV },
                new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = dv.DonGia },
                new SqlParameter("@DonViTinh", SqlDbType.NVarChar, 50) { Value = dv.DonViTinh },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = dv.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(DichVu dv)
        {
            string sql = "UPDATE dbo.DichVu SET TenDV = @TenDV, DonGia = @DonGia, DonViTinh = @DonViTinh, " +
                         "TrangThai = @TrangThai WHERE MaDV = @MaDV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = dv.MaDV },
                new SqlParameter("@TenDV", SqlDbType.NVarChar, 100) { Value = dv.TenDV },
                new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = dv.DonGia },
                new SqlParameter("@DonViTinh", SqlDbType.NVarChar, 50) { Value = dv.DonViTinh },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = dv.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool BatTatTrangThai(string maDV, string trangThaiMoi)
        {
            string sql = "UPDATE dbo.DichVu SET TrangThai = @TrangThai WHERE MaDV = @MaDV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = maDV },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = trangThaiMoi }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string maDV)
        {
            string sql = "DELETE FROM dbo.DichVu WHERE MaDV = @MaDV";
            SqlParameter[] parameters = {
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = maDV }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
