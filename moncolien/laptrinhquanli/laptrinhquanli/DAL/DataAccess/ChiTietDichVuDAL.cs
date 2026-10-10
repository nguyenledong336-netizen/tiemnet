using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QuanLyTiemNet.DAL.Interfaces;
using QuanLyTiemNet.Entity.Models;

namespace QuanLyTiemNet.DAL.DataAccess
{
    public class ChiTietDichVuDAL : IChiTietDichVuDAL
    {
        public List<ChiTietDichVu> GetByMaPhien(int maPhien)
        {
            List<ChiTietDichVu> list = new List<ChiTietDichVu>();
            string sql = @"SELECT ct.MaCTDV, ct.MaPhien, ct.MaDV, ct.SoLuong, ct.DonGia, ct.ThanhTien, ct.ThoiGianDat,
                                  dv.TenDV, dv.DonViTinh
                           FROM dbo.ChiTietDichVu ct
                           INNER JOIN dbo.DichVu dv ON ct.MaDV = dv.MaDV
                           WHERE ct.MaPhien = @MaPhien
                           ORDER BY ct.MaCTDV ASC";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien }
            };
            DataTable dt = DBConnection.ExecuteQuery(sql, parameters);
            foreach (DataRow row in dt.Rows)
            {
                var ct = new ChiTietDichVu(
                    Convert.ToInt32(row["MaCTDV"]),
                    Convert.ToInt32(row["MaPhien"]),
                    row["MaDV"].ToString(),
                    Convert.ToInt32(row["SoLuong"]),
                    Convert.ToDecimal(row["DonGia"]),
                    Convert.ToDecimal(row["ThanhTien"]),
                    Convert.ToDateTime(row["ThoiGianDat"])
                );
                ct.TenDV = row["TenDV"].ToString();
                ct.DonViTinh = row["DonViTinh"].ToString();
                list.Add(ct);
            }
            return list;
        }

        public bool ThemChiTiet(ChiTietDichVu ct)
        {
            string sql = @"
                INSERT INTO dbo.ChiTietDichVu (MaPhien, MaDV, SoLuong, DonGia, ThoiGianDat)
                VALUES (@MaPhien, @MaDV, @SoLuong, @DonGia, @ThoiGianDat);

                -- Cập nhật tổng tiền dịch vụ và tổng tiền của phiên
                UPDATE dbo.PhienSuDung 
                SET TienDichVu = ISNULL((SELECT SUM(ThanhTien) FROM dbo.ChiTietDichVu WHERE MaPhien = @MaPhien), 0),
                    TongTien = TienMay + ISNULL((SELECT SUM(ThanhTien) FROM dbo.ChiTietDichVu WHERE MaPhien = @MaPhien), 0)
                WHERE MaPhien = @MaPhien;";

            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = ct.MaPhien },
                new SqlParameter("@MaDV", SqlDbType.NVarChar, 20) { Value = ct.MaDV },
                new SqlParameter("@SoLuong", SqlDbType.Int) { Value = ct.SoLuong },
                new SqlParameter("@DonGia", SqlDbType.Decimal) { Value = ct.DonGia },
                new SqlParameter("@ThoiGianDat", SqlDbType.DateTime) { Value = ct.ThoiGianDat }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool XoaChiTiet(int maCTDV)
        {
            string sql = @"
                DECLARE @MaPhien INT;
                SELECT @MaPhien = MaPhien FROM dbo.ChiTietDichVu WHERE MaCTDV = @MaCTDV;

                DELETE FROM dbo.ChiTietDichVu WHERE MaCTDV = @MaCTDV;

                IF @MaPhien IS NOT NULL
                BEGIN
                    UPDATE dbo.PhienSuDung 
                    SET TienDichVu = ISNULL((SELECT SUM(ThanhTien) FROM dbo.ChiTietDichVu WHERE MaPhien = @MaPhien), 0),
                        TongTien = TienMay + ISNULL((SELECT SUM(ThanhTien) FROM dbo.ChiTietDichVu WHERE MaPhien = @MaPhien), 0)
                    WHERE MaPhien = @MaPhien;
                END";

            SqlParameter[] parameters = {
                new SqlParameter("@MaCTDV", SqlDbType.Int) { Value = maCTDV }
            };

            return DBConnection.ExecuteNonQuery(sql, parameters) > 0;
        }

        public decimal TinhTongTienDichVuCuaPhien(int maPhien)
        {
            string sql = "SELECT ISNULL(SUM(ThanhTien), 0) FROM dbo.ChiTietDichVu WHERE MaPhien = @MaPhien";
            SqlParameter[] parameters = {
                new SqlParameter("@MaPhien", SqlDbType.Int) { Value = maPhien }
            };
            object result = DBConnection.ExecuteScalar(sql, parameters);
            if (result != null && decimal.TryParse(result.ToString(), out decimal tong))
            {
                return tong;
            }
            return 0;
        }
    }
}
