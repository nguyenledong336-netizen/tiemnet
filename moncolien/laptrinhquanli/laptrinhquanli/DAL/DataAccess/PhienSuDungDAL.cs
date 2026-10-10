using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class PhienSuDungDAL : IPhienSuDungDAL
    {
        public List<PhienSuDung> GetAll()
        {
            List<PhienSuDung> list = new List<PhienSuDung>();
            string sql = @"SELECT p.MaPhien, p.MaMay, p.MaKH, p.MaNV, p.ThoiGianBatDau, p.ThoiGianKetThuc, 
                                  p.DonGiaGio, p.TienMay, p.TienDichVu, p.TongTien, p.TrangThai,
                                  m.TenMay, k.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien
                           FROM dbo.PhienSuDung p
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang k ON p.MaKH = k.MaKH
                           INNER JOIN dbo.NhanVien nv ON p.MaNV = nv.MaNV
                           ORDER BY p.MaPhien DESC";
            DataTable dt = DBConnection.ExecuteQuery(sql);
            foreach (DataRow row in dt.Rows)
            {
                var phien = new PhienSuDung(
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaMay"].ToString(),
                    row["MaKH"].ToString(),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["ThoiGianBatDau"]),
                    row["ThoiGianKetThuc"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ThoiGianKetThuc"]) : null,
                    Convert.ToDecimal(row["DonGiaGio"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["TrangThai"].ToString()
                );
                phien.TenMay = row["TenMay"].ToString();
                phien.TenKhachHang = row["TenKhachHang"].ToString();
                phien.TenNhanVien = row["TenNhanVien"].ToString();
                list.Add(phien);
            }
            return list;
        }

        public PhienSuDung GetById(int maPhien)
        {
            string sql = @"SELECT p.MaPhien, p.MaMay, p.MaKH, p.MaNV, p.ThoiGianBatDau, p.ThoiGianKetThuc, 
                                  p.DonGiaGio, p.TienMay, p.TienDichVu, p.TongTien, p.TrangThai,
                                  m.TenMay, k.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien
                           FROM dbo.PhienSuDung p
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang k ON p.MaKH = k.MaKH
                           INNER JOIN dbo.NhanVien nv ON p.MaNV = nv.MaNV
                           WHERE p.MaPhien = @MaPhien";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var phien = new PhienSuDung(
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaMay"].ToString(),
                    row["MaKH"].ToString(),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["ThoiGianBatDau"]),
                    row["ThoiGianKetThuc"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ThoiGianKetThuc"]) : null,
                    Convert.ToDecimal(row["DonGiaGio"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["TrangThai"].ToString()
                );
                phien.TenMay = row["TenMay"].ToString();
                phien.TenKhachHang = row["TenKhachHang"].ToString();
                phien.TenNhanVien = row["TenNhanVien"].ToString();
                return phien;
            }
            return null;
        }

        public PhienSuDung GetPhienHienTaiCuaMay(string maMay)
        {
            string sql = @"SELECT TOP 1 p.MaPhien, p.MaMay, p.MaKH, p.MaNV, p.ThoiGianBatDau, p.ThoiGianKetThuc, 
                                  p.DonGiaGio, p.TienMay, p.TienDichVu, p.TongTien, p.TrangThai,
                                  m.TenMay, k.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien
                           FROM dbo.PhienSuDung p
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang k ON p.MaKH = k.MaKH
                           INNER JOIN dbo.NhanVien nv ON p.MaNV = nv.MaNV
                           WHERE p.MaMay = @MaMay AND p.TrangThai = N'Đang sử dụng'
                           ORDER BY p.MaPhien DESC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = maMay }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                var phien = new PhienSuDung(
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaMay"].ToString(),
                    row["MaKH"].ToString(),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["ThoiGianBatDau"]),
                    row["ThoiGianKetThuc"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ThoiGianKetThuc"]) : null,
                    Convert.ToDecimal(row["DonGiaGio"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["TrangThai"].ToString()
                );
                phien.TenMay = row["TenMay"].ToString();
                phien.TenKhachHang = row["TenKhachHang"].ToString();
                phien.TenNhanVien = row["TenNhanVien"].ToString();
                return phien;
            }
            return null;
        }

        public int MoPhien(PhienSuDung phien)
        {
            string sql = @"
                INSERT INTO dbo.PhienSuDung (MaMay, MaKH, MaNV, ThoiGianBatDau, DonGiaGio, TienMay, TienDichVu, TongTien, TrangThai)
                VALUES (@MaMay, @MaKH, @MaNV, @ThoiGianBatDau, @DonGiaGio, 0, 0, 0, N'Đang sử dụng');
                SELECT CAST(SCOPE_IDENTITY() AS INT);
                UPDATE dbo.MayTinh SET TrangThai = N'Đang sử dụng' WHERE MaMay = @MaMay;";

            SqlParameter[] parameters = {
                new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = phien.MaMay },
                new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = phien.MaKH },
                new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = phien.MaNV },
                new SqlParameter("@ThoiGianBatDau", SqlDbType.DateTime) { Value = phien.ThoiGianBatDau },
                new SqlParameter("@DonGiaGio", SqlDbType.Decimal) { Value = phien.DonGiaGio }
            };

            object result = DBConnection.ExecuteScalar(sql, parameters);
            if (result != null && int.TryParse(result.ToString(), out int id))
            {
                return id;
            }
            return 0;
        }

        public bool CapNhatTien(int maPhien, decimal tienMay, decimal tienDichVu, decimal tongTien)
        {
            string sql = @"UPDATE dbo.PhienSuDung 
                           SET TienMay = @TienMay, TienDichVu = @TienDichVu, TongTien = @TongTien 
                           WHERE MaPhien = @MaPhien";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien },
                new SqlParameter("@TienMay", SqlDbType.Decimal) { Value = tienMay },
                new SqlParameter("@TienDichVu", SqlDbType.Decimal) { Value = tienDichVu },
                new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DongPhien(int maPhien, DateTime thoiGianKetThuc, decimal tienMay, decimal tienDichVu, decimal tongTien)
        {
            string sql = @"
                UPDATE dbo.PhienSuDung 
                SET ThoiGianKetThuc = @ThoiGianKetThuc, 
                    TienMay = @TienMay, 
                    TienDichVu = @TienDichVu, 
                    TongTien = @TongTien, 
                    TrangThai = N'Đã thanh toán' 
                WHERE MaPhien = @MaPhien;
                
                UPDATE dbo.MayTinh 
                SET TrangThai = N'Trống' 
                WHERE MaMay = (SELECT MaMay FROM dbo.PhienSuDung WHERE MaPhien = @MaPhien);";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien },
                new SqlParameter("@ThoiGianKetThuc", SqlDbType.DateTime) { Value = thoiGianKetThuc },
                new SqlParameter("@TienMay", SqlDbType.Decimal) { Value = tienMay },
                new SqlParameter("@TienDichVu", SqlDbType.Decimal) { Value = tienDichVu },
                new SqlParameter("@TongTien", SqlDbType.Decimal) { Value = tongTien }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool HuyPhien(int maPhien)
        {
            string sql = @"
                UPDATE dbo.PhienSuDung 
                SET TrangThai = N'Đã hủy', ThoiGianKetThuc = GETDATE() 
                WHERE MaPhien = @MaPhien;
                
                UPDATE dbo.MayTinh 
                SET TrangThai = N'Trống' 
                WHERE MaMay = (SELECT MaMay FROM dbo.PhienSuDung WHERE MaPhien = @MaPhien);";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien }
            };
            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public List<PhienSuDung> TimKiem(DateTime? tuNgay, DateTime? denNgay, string maMay, string maNV, string maKH)
        {
            List<PhienSuDung> list = new List<PhienSuDung>();
            string sql = @"SELECT p.MaPhien, p.MaMay, p.MaKH, p.MaNV, p.ThoiGianBatDau, p.ThoiGianKetThuc, 
                                  p.DonGiaGio, p.TienMay, p.TienDichVu, p.TongTien, p.TrangThai,
                                  m.TenMay, k.HoTen AS TenKhachHang, nv.HoTen AS TenNhanVien
                           FROM dbo.PhienSuDung p
                           INNER JOIN dbo.MayTinh m ON p.MaMay = m.MaMay
                           INNER JOIN dbo.KhachHang k ON p.MaKH = k.MaKH
                           INNER JOIN dbo.NhanVien nv ON p.MaNV = nv.MaNV
                           WHERE 1=1";

            List<SqlParameter> paramList = new List<SqlParameter>();

            if (tuNgay.HasValue)
            {
                sql += " AND p.ThoiGianBatDau >= @TuNgay";
                paramList.Add(new SqlParameter("@TuNgay", SqlDbType.DateTime) { Value = tuNgay.Value });
            }
            if (denNgay.HasValue)
            {
                sql += " AND p.ThoiGianBatDau <= @DenNgay";
                paramList.Add(new SqlParameter("@DenNgay", SqlDbType.DateTime) { Value = denNgay.Value });
            }
            if (!string.IsNullOrWhiteSpace(maMay))
            {
                sql += " AND p.MaMay = @MaMay";
                paramList.Add(new SqlParameter("@MaMay", SqlDbType.NVarChar, 20) { Value = maMay });
            }
            if (!string.IsNullOrWhiteSpace(maNV))
            {
                sql += " AND p.MaNV = @MaNV";
                paramList.Add(new SqlParameter("@MaNV", SqlDbType.NVarChar, 20) { Value = maNV });
            }
            if (!string.IsNullOrWhiteSpace(maKH))
            {
                sql += " AND p.MaKH = @MaKH";
                paramList.Add(new SqlParameter("@MaKH", SqlDbType.NVarChar, 20) { Value = maKH });
            }

            sql += " ORDER BY p.MaPhien DESC";

            DataTable dt = DBConnection.ExecuteQuery(sql, paramList.ToArray());
            foreach (DataRow row in dt.Rows)
            {
                var phien = new PhienSuDung(
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaMay"].ToString(),
                    row["MaKH"].ToString(),
                    row["MaNV"].ToString(),
                    Convert.ToDateTime(row["ThoiGianBatDau"]),
                    row["ThoiGianKetThuc"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row["ThoiGianKetThuc"]) : null,
                    Convert.ToDecimal(row["DonGiaGio"]),
                    Convert.ToDecimal(row["TienMay"]),
                    Convert.ToDecimal(row["TienDichVu"]),
                    Convert.ToDecimal(row["TongTien"]),
                    row["TrangThai"].ToString()
                );
                phien.TenMay = row["TenMay"].ToString();
                phien.TenKhachHang = row["TenKhachHang"].ToString();
                phien.TenNhanVien = row["TenNhanVien"].ToString();
                list.Add(phien);
            }
            return list;
        }
    }
}
