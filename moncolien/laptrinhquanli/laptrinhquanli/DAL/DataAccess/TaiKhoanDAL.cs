using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class TaiKhoanDAL : ITaiKhoanDAL
    {
        public List<TaiKhoan> GetAll()
        {
            List<TaiKhoan> list = new List<TaiKhoan>();
            string sql = "SELECT TenDangNhap, MatKhau, MaNV, VaiTro, TrangThai FROM dbo.TaiKhoan";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new TaiKhoan(
                    row["TenDangNhap"].ToString(),
                    row["MatKhau"].ToString(),
                    row["MaNV"].ToString(),
                    row["VaiTro"].ToString(),
                    row["TrangThai"].ToString()
                ));
            }
            return list;
        }

        public TaiKhoan GetByUsername(string username)
        {
            string sql = "SELECT TenDangNhap, MatKhau, MaNV, VaiTro, TrangThai FROM dbo.TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = username }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TaiKhoan(
                    row["TenDangNhap"].ToString(),
                    row["MatKhau"].ToString(),
                    row["MaNV"].ToString(),
                    row["VaiTro"].ToString(),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public TaiKhoan KiemTraDangNhap(string username, string password)
        {
            string sql = "SELECT TenDangNhap, MatKhau, MaNV, VaiTro, TrangThai FROM dbo.TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = username },
                new SqlParameter("@MatKhau", SqlDbType.NVarChar, 100) { Value = password }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new TaiKhoan(
                    row["TenDangNhap"].ToString(),
                    row["MatKhau"].ToString(),
                    row["MaNV"].ToString(),
                    row["VaiTro"].ToString(),
                    row["TrangThai"].ToString()
                );
            }
            return null;
        }

        public bool Them(TaiKhoan tk)
        {
            string sql = "INSERT INTO dbo.TaiKhoan (TenDangNhap, MatKhau, MaNV, VaiTro, TrangThai) VALUES (@TenDangNhap, @MatKhau, @MaNV, @VaiTro, @TrangThai)";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = tk.TenDangNhap },
                new SqlParameter("@MatKhau", SqlDbType.NVarChar, 100) { Value = tk.MatKhau },
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = tk.MaNV },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 50) { Value = tk.VaiTro },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = tk.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool CapNhat(TaiKhoan tk)
        {
            string sql = "UPDATE dbo.TaiKhoan SET MatKhau = @MatKhau, MaNV = @MaNV, VaiTro = @VaiTro, TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = tk.TenDangNhap },
                new SqlParameter("@MatKhau", SqlDbType.NVarChar, 100) { Value = tk.MatKhau },
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = tk.MaNV },
                new SqlParameter("@VaiTro", SqlDbType.NVarChar, 50) { Value = tk.VaiTro },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = tk.TrangThai }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DoiMatKhau(string username, string matKhauMoi)
        {
            string sql = "UPDATE dbo.TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = username },
                new SqlParameter("@MatKhau", SqlDbType.NVarChar, 100) { Value = matKhauMoi }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool Xoa(string username)
        {
            string sql = "DELETE FROM dbo.TaiKhoan WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = username }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool KhoaTaiKhoan(string username, bool khoa)
        {
            string sql = "UPDATE dbo.TaiKhoan SET TrangThai = @TrangThai WHERE TenDangNhap = @TenDangNhap";
            SqlParameter[] parameters = {
                new SqlParameter("@TenDangNhap", SqlDbType.NVarChar, 50) { Value = username },
                new SqlParameter("@TrangThai", SqlDbType.NVarChar, 50) { Value = khoa ? "Bị khóa" : "Hoạt động" }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }
    }
}
