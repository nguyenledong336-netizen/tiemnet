using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class MayTinhDAL : IMayTinhDAL
    {
        public List<MayTinh> GetAll()
        {
            List<MayTinh> list = new List<MayTinh>();
            string sql = "SELECT MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai FROM dbo.MayTinh ORDER BY MaMay";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MayTinh(
                    row["MaMay"].ToString(),
                    row["TenMay"].ToString(),
                    row["LoaiMay"].ToString(),
                    Convert.ToDecimal(row["DonGiaGio"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public MayTinh GetById(string maMay)
        {
            string sql = "SELECT MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai FROM dbo.MayTinh WHERE MaMay = @MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = maMay }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new MayTinh(
                    row["MaMay"].ToString(),
                    row["TenMay"].ToString(),
                    row["LoaiMay"].ToString(),
                    Convert.ToDecimal(row["DonGiaGio"]),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public List<MayTinh> GetByTrangThai(string trangThai)
        {
            List<MayTinh> list = new List<MayTinh>();
            string sql = "SELECT MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai FROM dbo.MayTinh WHERE TrangThai = @TrangThai ORDER BY MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = trangThai }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MayTinh(
                    row["MaMay"].ToString(),
                    row["TenMay"].ToString(),
                    row["LoaiMay"].ToString(),
                    Convert.ToDecimal(row["DonGiaGio"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public List<MayTinh> GetByLoaiMay(string loaiMay)
        {
            List<MayTinh> list = new List<MayTinh>();
            string sql = "SELECT MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai FROM dbo.MayTinh WHERE LoaiMay = @LoaiMay ORDER BY MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@LoaiMay", SqlDbType.NVarChar, 50) { Value = loaiMay }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MayTinh(
                    row["MaMay"].ToString(),
                    row["TenMay"].ToString(),
                    row["LoaiMay"].ToString(),
                    Convert.ToDecimal(row["DonGiaGio"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public List<MayTinh> TimKiem(string keyword)
        {
            List<MayTinh> list = new List<MayTinh>();
            string sql = "SELECT MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai FROM dbo.MayTinh " +
                         "WHERE MaMay LIKE @Keyword OR TenMay LIKE @Keyword OR LoaiMay LIKE @Keyword ORDER BY MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@Keyword", SqlDbType.NVarChar, 100) { Value = "%" + keyword + "%" }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MayTinh(
                    row["MaMay"].ToString(),
                    row["TenMay"].ToString(),
                    row["LoaiMay"].ToString(),
                    Convert.ToDecimal(row["DonGiaGio"]),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public bool Them(MayTinh mt)
        {
            string sql = "INSERT INTO dbo.MayTinh (MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai) " +
                         "VALUES (@MaMay, @TenMay, @LoaiMay, @DonGiaGio, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = mt.MaMay },
                new SqlParameter("@TenMay", SqlDbType.NVarChar, 50) { Value = mt.TenMay },
                new SqlParameter("@LoaiMay", SqlDbType.NVarChar, 50) { Value = mt.LoaiMay },
                new SqlParameter("@DonGiaGio", SqlDbType.Decimal) { Value = mt.DonGiaGio },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = mt.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(MayTinh mt)
        {
            string sql = "UPDATE dbo.MayTinh SET TenMay = @TenMay, LoaiMay = @LoaiMay, DonGiaGio = @DonGiaGio, " +
                         "TrangThai = @TrangThai WHERE MaMay = @MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = mt.MaMay },
                new SqlParameter("@TenMay", SqlDbType.NVarChar, 50) { Value = mt.TenMay },
                new SqlParameter("@LoaiMay", SqlDbType.NVarChar, 50) { Value = mt.LoaiMay },
                new SqlParameter("@DonGiaGio", SqlDbType.Decimal) { Value = mt.DonGiaGio },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = mt.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhatTrangThai(string maMay, string trangThaiMoi)
        {
            string sql = "UPDATE dbo.MayTinh SET TrangThai = @TrangThai WHERE MaMay = @MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = maMay },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = trangThaiMoi }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string maMay)
        {
            string sql = "DELETE FROM dbo.MayTinh WHERE MaMay = @MaMay";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = maMay }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
