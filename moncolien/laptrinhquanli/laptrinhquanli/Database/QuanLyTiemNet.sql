-- =============================================================
-- SCRIPT TẠO CƠ SỞ DỮ LIỆU: QuanLyTiemNet
-- HỆ QUẢN TRỊ CSDL: Microsoft SQL Server
-- =============================================================

USE master;
GO

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyTiemNet')
BEGIN
    CREATE DATABASE QuanLyTiemNet;
END
GO

USE QuanLyTiemNet;
GO

-- XÓA BẢNG NẾU ĐÃ TỒN TẠI THEO THỨ TỰ RÀNG BUỘC KHÓA NGOẠI
IF OBJECT_ID(N'dbo.ChamCong', N'U') IS NOT NULL DROP TABLE dbo.ChamCong;
IF OBJECT_ID(N'dbo.LichLamViec', N'U') IS NOT NULL DROP TABLE dbo.LichLamViec;
IF OBJECT_ID(N'dbo.CaLamViec', N'U') IS NOT NULL DROP TABLE dbo.CaLamViec;
IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.ChiTietDichVu', N'U') IS NOT NULL DROP TABLE dbo.ChiTietDichVu;
IF OBJECT_ID(N'dbo.PhienSuDung', N'U') IS NOT NULL DROP TABLE dbo.PhienSuDung;
IF OBJECT_ID(N'dbo.DichVu', N'U') IS NOT NULL DROP TABLE dbo.DichVu;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
IF OBJECT_ID(N'dbo.MayTinh', N'U') IS NOT NULL DROP TABLE dbo.MayTinh;
IF OBJECT_ID(N'dbo.TaiKhoan', N'U') IS NOT NULL DROP TABLE dbo.TaiKhoan;
IF OBJECT_ID(N'dbo.NhanVien', N'U') IS NOT NULL DROP TABLE dbo.NhanVien;
GO

-- 1. BẢNG NHÂN VIÊN
CREATE TABLE dbo.NhanVien (
    MaNV NVARCHAR(20) NOT NULL CONSTRAINT PK_NhanVien PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    VaiTro NVARCHAR(50) NOT NULL CONSTRAINT DF_NhanVien_VaiTro DEFAULT N'Nhân viên',
    Luong DECIMAL(18, 0) NOT NULL CONSTRAINT DF_NhanVien_Luong DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_NhanVien_TrangThai DEFAULT N'Đang làm việc',
    CONSTRAINT CK_NhanVien_VaiTro CHECK (VaiTro IN (N'Quản lý', N'Nhân viên')),
    CONSTRAINT CK_NhanVien_TrangThai CHECK (TrangThai IN (N'Đang làm việc', N'Đã nghỉ việc')),
    CONSTRAINT CK_NhanVien_Luong CHECK (Luong >= 0)
);
GO

-- 2. BẢNG TÀI KHOẢN
CREATE TABLE dbo.TaiKhoan (
    TenDangNhap NVARCHAR(50) NOT NULL CONSTRAINT PK_TaiKhoan PRIMARY KEY,
    MatKhau NVARCHAR(100) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL,
    VaiTro NVARCHAR(50) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_TaiKhoan_TrangThai DEFAULT N'Hoạt động',
    CONSTRAINT FK_TaiKhoan_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE CASCADE,
    CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN (N'Quản lý', N'Nhân viên')),
    CONSTRAINT CK_TaiKhoan_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);
GO

-- 3. BẢNG MÁY TÍNH
CREATE TABLE dbo.MayTinh (
    MaMay NVARCHAR(20) NOT NULL CONSTRAINT PK_MayTinh PRIMARY KEY,
    TenMay NVARCHAR(50) NOT NULL CONSTRAINT UQ_MayTinh_TenMay UNIQUE,
    LoaiMay NVARCHAR(50) NOT NULL CONSTRAINT DF_MayTinh_LoaiMay DEFAULT N'Thường',
    DonGiaGio DECIMAL(18, 0) NOT NULL CONSTRAINT DF_MayTinh_DonGiaGio DEFAULT 10000,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_MayTinh_TrangThai DEFAULT N'Trống',
    CONSTRAINT CK_MayTinh_LoaiMay CHECK (LoaiMay IN (N'Thường', N'VIP')),
    CONSTRAINT CK_MayTinh_TrangThai CHECK (TrangThai IN (N'Trống', N'Đang sử dụng', N'Bảo trì')),
    CONSTRAINT CK_MayTinh_DonGiaGio CHECK (DonGiaGio >= 0)
);
GO

-- 4. BẢNG KHÁCH HÀNG
CREATE TABLE dbo.KhachHang (
    MaKH NVARCHAR(20) NOT NULL CONSTRAINT PK_KhachHang PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) NULL,
    SoDu DECIMAL(18, 0) NOT NULL CONSTRAINT DF_KhachHang_SoDu DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_KhachHang_TrangThai DEFAULT N'Hoạt động',
    CONSTRAINT CK_KhachHang_SoDu CHECK (SoDu >= 0),
    CONSTRAINT CK_KhachHang_TrangThai CHECK (TrangThai IN (N'Hoạt động', N'Bị khóa'))
);
GO

-- 5. BẢNG DỊCH VỤ
CREATE TABLE dbo.DichVu (
    MaDV NVARCHAR(20) NOT NULL CONSTRAINT PK_DichVu PRIMARY KEY,
    TenDV NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18, 0) NOT NULL CONSTRAINT DF_DichVu_DonGia DEFAULT 0,
    DonViTinh NVARCHAR(50) NOT NULL CONSTRAINT DF_DichVu_DonViTinh DEFAULT N'Phần',
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_DichVu_TrangThai DEFAULT N'Còn hàng',
    CONSTRAINT CK_DichVu_DonGia CHECK (DonGia >= 0),
    CONSTRAINT CK_DichVu_TrangThai CHECK (TrangThai IN (N'Còn hàng', N'Hết hàng', N'Ngừng kinh doanh'))
);
GO

-- 6. BẢNG PHIÊN SỬ DỤNG
CREATE TABLE dbo.PhienSuDung (
    MaPhien INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PhienSuDung PRIMARY KEY,
    MaMay NVARCHAR(20) NOT NULL,
    MaKH NVARCHAR(20) NOT NULL,
    MaNV NVARCHAR(20) NOT NULL,
    ThoiGianBatDau DATETIME NOT NULL CONSTRAINT DF_PhienSuDung_ThoiGianBatDau DEFAULT GETDATE(),
    ThoiGianKetThuc DATETIME NULL,
    DonGiaGio DECIMAL(18, 0) NOT NULL DEFAULT 10000,
    TienMay DECIMAL(18, 0) NOT NULL CONSTRAINT DF_PhienSuDung_TienMay DEFAULT 0,
    TienDichVu DECIMAL(18, 0) NOT NULL CONSTRAINT DF_PhienSuDung_TienDichVu DEFAULT 0,
    TongTien DECIMAL(18, 0) NOT NULL CONSTRAINT DF_PhienSuDung_TongTien DEFAULT 0,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_PhienSuDung_TrangThai DEFAULT N'Đang sử dụng',
    CONSTRAINT FK_PhienSuDung_MayTinh FOREIGN KEY (MaMay) REFERENCES dbo.MayTinh(MaMay),
    CONSTRAINT FK_PhienSuDung_KhachHang FOREIGN KEY (MaKH) REFERENCES dbo.KhachHang(MaKH),
    CONSTRAINT FK_PhienSuDung_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT CK_PhienSuDung_TrangThai CHECK (TrangThai IN (N'Đang sử dụng', N'Đã thanh toán', N'Đã hủy'))
);
GO

-- 7. BẢNG CHI TIẾT DỊCH VỤ
CREATE TABLE dbo.ChiTietDichVu (
    MaCTDV INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChiTietDichVu PRIMARY KEY,
    MaPhien INT NOT NULL,
    MaDV NVARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL CONSTRAINT DF_ChiTietDichVu_SoLuong DEFAULT 1,
    DonGia DECIMAL(18, 0) NOT NULL CONSTRAINT DF_ChiTietDichVu_DonGia DEFAULT 0,
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    ThoiGianDat DATETIME NOT NULL CONSTRAINT DF_ChiTietDichVu_ThoiGianDat DEFAULT GETDATE(),
    CONSTRAINT FK_ChiTietDichVu_PhienSuDung FOREIGN KEY (MaPhien) REFERENCES dbo.PhienSuDung(MaPhien) ON DELETE CASCADE,
    CONSTRAINT FK_ChiTietDichVu_DichVu FOREIGN KEY (MaDV) REFERENCES dbo.DichVu(MaDV),
    CONSTRAINT CK_ChiTietDichVu_SoLuong CHECK (SoLuong > 0)
);
GO

-- 8. BẢNG HÓA ĐƠN
CREATE TABLE dbo.HoaDon (
    MaHD INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_HoaDon PRIMARY KEY,
    MaPhien INT NOT NULL,
    MaNV NVARCHAR(20) NOT NULL,
    NgayTao DATETIME NOT NULL CONSTRAINT DF_HoaDon_NgayTao DEFAULT GETDATE(),
    TienMay DECIMAL(18, 0) NOT NULL DEFAULT 0,
    TienDichVu DECIMAL(18, 0) NOT NULL DEFAULT 0,
    TongTien DECIMAL(18, 0) NOT NULL DEFAULT 0,
    PhuongThucThanhToan NVARCHAR(50) NOT NULL CONSTRAINT DF_HoaDon_PhuongThuc DEFAULT N'Tiền mặt',
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_HoaDon_PhienSuDung FOREIGN KEY (MaPhien) REFERENCES dbo.PhienSuDung(MaPhien),
    CONSTRAINT FK_HoaDon_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV),
    CONSTRAINT CK_HoaDon_PhuongThuc CHECK (PhuongThucThanhToan IN (N'Tiền mặt', N'Chuyển khoản'))
);
GO

-- 9. BẢNG CA LÀM VIỆC
CREATE TABLE dbo.CaLamViec (
    MaCa NVARCHAR(20) NOT NULL CONSTRAINT PK_CaLamViec PRIMARY KEY,
    TenCa NVARCHAR(100) NOT NULL,
    GioBatDau TIME(0) NOT NULL,
    GioKetThuc TIME(0) NOT NULL
);
GO

-- 10. BẢNG LỊCH LÀM VIỆC
CREATE TABLE dbo.LichLamViec (
    MaLich INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LichLamViec PRIMARY KEY,
    MaCa NVARCHAR(20) NOT NULL,
    ThuTrongTuan INT NOT NULL, -- 2: Thứ 2, 3: Thứ 3, ..., 8: Chủ nhật
    MaNV NVARCHAR(20) NULL,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_LichLamViec_TrangThai DEFAULT N'Chưa phân công',
    CONSTRAINT FK_LichLamViec_CaLamViec FOREIGN KEY (MaCa) REFERENCES dbo.CaLamViec(MaCa) ON DELETE CASCADE,
    CONSTRAINT FK_LichLamViec_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE SET NULL,
    CONSTRAINT CK_LichLamViec_Thu CHECK (ThuTrongTuan BETWEEN 2 AND 8)
);
GO

-- 11. BẢNG CHẤM CÔNG
CREATE TABLE dbo.ChamCong (
    MaChamCong INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ChamCong PRIMARY KEY,
    MaNV NVARCHAR(20) NOT NULL,
    Ngay DATE NOT NULL CONSTRAINT DF_ChamCong_Ngay DEFAULT CAST(GETDATE() AS DATE),
    GioVao TIME(0) NOT NULL,
    GioRa TIME(0) NULL,
    TrangThai NVARCHAR(50) NOT NULL CONSTRAINT DF_ChamCong_TrangThai DEFAULT N'Đang làm việc',
    GhiChu NVARCHAR(255) NULL,
    CONSTRAINT FK_ChamCong_NhanVien FOREIGN KEY (MaNV) REFERENCES dbo.NhanVien(MaNV) ON DELETE CASCADE,
    CONSTRAINT CK_ChamCong_TrangThai CHECK (TrangThai IN (N'Đang làm việc', N'Đã hoàn thành'))
);
GO

-- =============================================================
-- DỮ LIỆU MẪU (SEED DATA)
-- =============================================================

-- Nhân viên mẫu
INSERT INTO dbo.NhanVien (MaNV, HoTen, SoDienThoai, VaiTro, Luong, TrangThai) VALUES
(N'NV01', N'Trần Quản Trị', N'0901234567', N'Quản lý', 15000000, N'Đang làm việc'),
(N'NV02', N'Nguyễn Văn An', N'0912345678', N'Nhân viên', 7000000, N'Đang làm việc'),
(N'NV03', N'Trần Thị Bình', N'0923456789', N'Nhân viên', 6500000, N'Đang làm việc');

-- Tài khoản mẫu
INSERT INTO dbo.TaiKhoan (TenDangNhap, MatKhau, MaNV, VaiTro, TrangThai) VALUES
(N'admin', N'123456', N'NV01', N'Quản lý', N'Hoạt động'),
(N'nhanvien01', N'123456', N'NV02', N'Nhân viên', N'Hoạt động'),
(N'nhanvien02', N'123456', N'NV03', N'Nhân viên', N'Hoạt động'),
(N'lockuser', N'123456', N'NV03', N'Nhân viên', N'Bị khóa');

-- Máy tính mẫu (M01 - M10)
INSERT INTO dbo.MayTinh (MaMay, TenMay, LoaiMay, DonGiaGio, TrangThai) VALUES
(N'M01', N'Máy 01', N'Thường', 10000, N'Trống'),
(N'M02', N'Máy 02', N'Thường', 10000, N'Trống'),
(N'M03', N'Máy 03', N'VIP', 20000, N'Trống'),
(N'M04', N'Máy 04', N'VIP', 20000, N'Bảo trì'),
(N'M05', N'Máy 05', N'Thường', 10000, N'Trống'),
(N'M06', N'Máy 06', N'Thường', 10000, N'Trống'),
(N'M07', N'Máy 07', N'Thường', 10000, N'Trống'),
(N'M08', N'Máy 08', N'VIP', 20000, N'Trống'),
(N'M09', N'Máy 09', N'VIP', 20000, N'Trống'),
(N'M10', N'Máy 10', N'VIP', 20000, N'Trống');

-- Khách hàng mẫu
INSERT INTO dbo.KhachHang (MaKH, HoTen, SoDienThoai, SoDu, TrangThai) VALUES
(N'KH01', N'Khách Vãng Lai', N'0000000000', 0, N'Hoạt động'),
(N'KH02', N'Nguyễn Văn Minh', N'0987654321', 150000, N'Hoạt động'),
(N'KH03', N'Lê Văn Hoàng', N'0912345678', 50000, N'Hoạt động'),
(N'KH04', N'Phạm Quang Hải', N'0933445566', 200000, N'Hoạt động');

-- Dịch vụ mẫu
INSERT INTO dbo.DichVu (MaDV, TenDV, DonGia, DonViTinh, TrangThai) VALUES
(N'DV01', N'Mì tôm trứng', 20000, N'Tô', N'Còn hàng'),
(N'DV02', N'Mì xào bò', 35000, N'Đĩa', N'Còn hàng'),
(N'DV03', N'Cơm chiên dưa bò', 40000, N'Dĩa', N'Còn hàng'),
(N'DV04', N'Bánh mì kẹp thịt', 25000, N'Ổ', N'Còn hàng'),
(N'DV05', N'Sting dâu ướp lạnh', 15000, N'Chai', N'Còn hàng'),
(N'DV06', N'Bò húc Thái', 20000, N'Lon', N'Còn hàng'),
(N'DV07', N'Trà đào cam sả', 25000, N'Ly', N'Còn hàng'),
(N'DV08', N'Nước suối Aquafina', 10000, N'Chai', N'Còn hàng');

-- Ca làm việc mẫu
INSERT INTO dbo.CaLamViec (MaCa, TenCa, GioBatDau, GioKetThuc) VALUES
(N'CA01', N'Ca Sáng', '06:00:00', '14:00:00'),
(N'CA02', N'Ca Chiều', '14:00:00', '22:00:00'),
(N'CA03', N'Ca Tối', '22:00:00', '06:00:00');

-- Lịch phân ca tuần (Thứ 2 đến Chủ nhật, mỗi ngày 3 ca)
-- Thứ 2 (2) -> Chủ nhật (8)
INSERT INTO dbo.LichLamViec (MaCa, ThuTrongTuan, MaNV, TrangThai) VALUES
(N'CA01', 2, N'NV02', N'Đã phân công'),
(N'CA02', 2, N'NV03', N'Đã phân công'),
(N'CA03', 2, NULL, N'Chưa phân công'),
(N'CA01', 3, N'NV02', N'Đã phân công'),
(N'CA02', 3, N'NV03', N'Đã phân công'),
(N'CA03', 3, NULL, N'Chưa phân công'),
(N'CA01', 4, N'NV03', N'Đã phân công'),
(N'CA02', 4, N'NV02', N'Đã phân công'),
(N'CA03', 4, NULL, N'Chưa phân công'),
(N'CA01', 5, N'NV02', N'Đã phân công'),
(N'CA02', 5, N'NV03', N'Đã phân công'),
(N'CA03', 5, NULL, N'Chưa phân công'),
(N'CA01', 6, N'NV03', N'Đã phân công'),
(N'CA02', 6, N'NV02', N'Đã phân công'),
(N'CA03', 6, NULL, N'Chưa phân công'),
(N'CA01', 7, N'NV02', N'Đã phân công'),
(N'CA02', 7, N'NV03', N'Đã phân công'),
(N'CA03', 7, NULL, N'Chưa phân công'),
(N'CA01', 8, N'NV03', N'Đã phân công'),
(N'CA02', 8, N'NV02', N'Đã phân công'),
(N'CA03', 8, NULL, N'Chưa phân công');

-- Chấm công mẫu
INSERT INTO dbo.ChamCong (MaNV, Ngay, GioVao, GioRa, TrangThai, GhiChu) VALUES
(N'NV01', CAST(GETDATE() AS DATE), '07:30:00', NULL, N'Đang làm việc', N'Ca hành chính'),
(N'NV02', CAST(GETDATE() AS DATE), '06:00:00', '14:00:00', N'Đã hoàn thành', N'Đúng giờ'),
(N'NV03', CAST(GETDATE() AS DATE), '14:00:00', NULL, N'Đang làm việc', N'Ca chiều');
GO
