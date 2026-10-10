using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class CaLamViecDAL : ICaLamViecDAL
    {
        public List<CaLamViec> GetAll()
        {
            List<CaLamViec> list = new List<CaLamViec>();
            string sql = "SELECT MaCa, TenCa, GioBatDau, GioKetThuc FROM dbo.CaLamViec ORDER BY MaCa";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CaLamViec(
                    row["MaCa"].ToString(),
                    row["TenCa"].ToString(),
                    (TimeSpan)row["GioBatDau"],
                    (TimeSpan)row["GioKetThuc"]
                ));
            }
            return list;
        }

        public CaLamViec GetById(string maCa)
        {
            string sql = "SELECT MaCa, TenCa, GioBatDau, GioKetThuc FROM dbo.CaLamViec WHERE MaCa = @MaCa";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new CaLamViec(
                    row["MaCa"].ToString(),
                    row["TenCa"].ToString(),
                    (TimeSpan)row["GioBatDau"],
                    (TimeSpan)row["GioKetThuc"]
                );
            }
            return null;
        }

        public bool Them(CaLamViec ca)
        {
            string sql = "INSERT INTO dbo.CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) VALUES (@MaCa, @TenCa, @GioBatDau, @GioKetThuc)";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = ca.MaCa },
                new SqlParameter("@TenCa", SqlDbType.NVarChar, 100) { Value = ca.TenCa },
                new SqlParameter("@GioBatDau", SqlDbType.Time) { Value = ca.GioBatDau },
                new SqlParameter("@GioKetThuc", SqlDbType.Time) { Value = ca.GioKetThuc }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(CaLamViec ca)
        {
            string sql = "UPDATE dbo.CaLamViec SET TenCa = @TenCa, GioBatDau = @GioBatDau, GioKetThuc = @GioKetThuc WHERE MaCa = @MaCa";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = ca.MaCa },
                new SqlParameter("@TenCa", SqlDbType.NVarChar, 100) { Value = ca.TenCa },
                new SqlParameter("@GioBatDau", SqlDbType.Time) { Value = ca.GioBatDau },
                new SqlParameter("@GioKetThuc", SqlDbType.Time) { Value = ca.GioKetThuc }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string maCa)
        {
            string sql = "DELETE FROM dbo.CaLamViec WHERE MaCa = @MaCa";
            SqlParameter[] parameters = {
                new SqlParameter("@MaCa", SqlDbType.NVarChar, 20) { Value = maCa }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
