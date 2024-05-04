CREATE DATABASE QLKDDoUong
use QLKDDoUong
drop database QLKDDoUong
CREATE TABLE tblNhanVien
(
    sMaNV varchar(50) PRIMARY KEY,
    sTenNV nvarchar(50),
    sGioiTinh nvarchar(5),
    sDiaChi nvarchar(50),
    dNgaySinh date,
    sTrangThai nvarchar(50),
    sSoDienThoai varchar(255)
);
SELECT * FROM tblNhanVien ORDER BY sTenNV DESC

--ALTER TABLE tblNhanVien
--ADD sChucVu nvarchar(50)

ALTER TABLE tblNhanVien
ADD CONSTRAINT FK_NV_Account FOREIGN KEY (sMaNV) REFERENCES tblAccount (sMaNV)
ALTER TABLE tblNhanVien
drop constraint FK_NV_Account
CREATE TABLE tblAccount
(
	sMaNV varchar(50) PRIMARY KEY,
	sMatKhau varchar(50) ,
	sLoaiTK nvarchar(50)
)
SELECT * FROM tblAccount

-- PROC Add Account
CREATE PROCEDURE sp_Them_tblAccount
	@sMaNV varchar(50),
	@sMatKhau varchar(50),
	@sLoaiTK nvarchar(50)
AS
BEGIN
	INSERT INTO tblAccount(sMaNV, sMatKhau, sLoaiTK)
	VALUES (@sMaNV, @sMatKhau, @sLoaiTK);
END;
--PROC Delete Account by sTaiKhoan 
CREATE PROCEDURE sp_Xoa_tblAccount
	@sMaNV varchar(50)
AS
BEGIN
	DELETE FROM tblAccount
	WHERE sMaNV = sMaNV;
END;
--PROC Update data account
CREATE PROCEDURE sp_Sua_tblAccount
	@sMaNV varchar(50),
	@sMatKhau varchar(50),
	@sLoaiTK nvarchar(50)
AS
BEGIN
	UPDATE tblAccount
	SET sMatKhau = @sMatKhau, sLoaiTK = @sLoaiTK
	WHERE sMaNV = @sMaNV;
END;

CREATE TABLE tblKhachHang
(
    iMaKH int IDENTITY(1,1) PRIMARY KEY,
    sTenKH nvarchar(255),
    sDiaChi nvarchar(255),
    sSoDienThoai varchar(255),
    sGioiTinh nvarchar(5)
);
SELECT * FROM tblKhachHang

CREATE TABLE tblDoUong
(
    sMaDoUong varchar(10) PRIMARY KEY,
    sTenDoUong nvarchar(255),
	fGiaGoc float
);


CREATE TABLE tblHoaDon
(
    iMaHD int IDENTITY(1,1) PRIMARY KEY,
    sMaNV varchar(50) REFERENCES tblNhanVien(sMaNV),
	iMaKH int REFERENCES tblKhachHang(iMaKH),
    dNgayBan date,
	fTongTienThanhToan float DEFAULT 0,
	sTrangThaiHD nvarchar(50)
);
--alter table tblHoaDon drop column fTongTienThanhToan, sTrangThaiHD
alter table tblHoaDon add constraint Uq_sMaHD unique(sMaHD);

CREATE TABLE tblSize(
	sSizeDoUong varchar(3) PRIMARY KEY,
	fTiSoGiaSize float
)

CREATE TABLE tblChiTietHD
(
    iMaHD int not null,
    sMaDoUong varchar(10) NOT NULL,
	sSizeDoUong varchar(3),
    iSoLuongBan float,
    fMucGiamGia float,
	fGiaBan float
);
alter table tblChiTietHD add fGiaBan float;

ALTER TABLE tblChiTietHD
ADD CONSTRAINT PK_ChiTietHD PRIMARY KEY(iMaHD, sMaDoUong),
CONSTRAINT FK_CTHD_HD FOREIGN KEY(iMaHD) REFERENCES tblHoaDon(iMaHD),
CONSTRAINT FK_CTHD_MH FOREIGN KEY(sMaDoUong) REFERENCES tblDoUong(sMaDoUong),
CONSTRAINT FK_Size_CTHD FOREIGN KEY (sSizeDoUong) REFERENCES tblSize(sSizeDoUong);
alter table tblChiTietHD drop constraint PK_ChiTietHD

--TRIGGER Tính fGiaTien
CREATE TRIGGER TG_Update_fGiaBan
ON tblChiTietHD
for INSERT, UPDATE
AS
BEGIN
    UPDATE tblChiTietHD
    SET fGiaBan = tblDoUong.fGiaGoc * (tblSize.fTiSoGiaSize - tblChiTietHD.fMucGiamGia) * iSoLuongBan
    FROM tblChiTietHD
    JOIN tblDoUong ON tblChiTietHD.sMaDoUong = tblDoUong.sMaDoUong
    JOIN tblSize ON tblChiTietHD.sSizeDoUong = tblSize.sSizeDoUong
    WHERE tblChiTietHD.iMaHD IN (SELECT iMaHD FROM inserted)
END;
drop trigger TG_Update_fGiaBan


--TRIGGER Tính Tổng Tiền Hoá Đơn

drop trigger Tinh_TongTienHoaDon

CREATE TRIGGER Tinh_TongTienHoaDon
ON tblChiTietHD
FOR INSERT,UPDATE
AS
BEGIN
    DECLARE @iMaHD varchar(10);
    DECLARE @fTongTienThanhToan float;

    SELECT @iMaHD = iMaHD FROM inserted;

    SELECT @fTongTienThanhToan = SUM(fGiaBan) FROM tblChiTietHD WHERE iMaHD = @iMaHD;

    UPDATE tblHoaDon
    SET fTongTienThanhToan = @fTongTienThanhToan
    WHERE iMaHD = @iMaHD;
END;
--PROC Add NhanVien
CREATE PROCEDURE sp_Them_tblNhanVien
	@sMaNV varchar(50),
	@sTenNV nvarchar(50),
	@sGioiTinh nvarchar(5),
	@sDiaChi nvarchar(50),
	@dNgaySinh date,
	@sTrangThai nvarchar(50),
	@sSoDienThoai varchar(255)
AS
BEGIN
	INSERT INTO tblNhanVien(sMaNV, sTenNV, sGioiTinh, sDiaChi, dNgaySinh, sTrangThai, sSoDienThoai)
	VALUES (@sMaNV, @sTenNV, @sGioiTinh, @sDiaChi, @dNgaySinh, @sTrangThai, @sSoDienThoai);
END;

--PROC sửa NhanVien
CREATE PROCEDURE sp_Sua_tblNhanVien
	@sMaNV varchar(50),
	@sTenNV nvarchar(50),
	@sGioiTinh nvarchar(5),
	@sDiaChi nvarchar(50),
	@dNgaySinh date,
	@sTrangThai nvarchar(50),
	@sSoDienThoai varchar(255)
AS
BEGIN
	update tblNhanVien
	set sTenNV = @sTenNV, sGioiTinh = @sGioiTinh, sDiaChi = @sDiaChi, 
	dNgaySinh = @dNgaySinh, sTrangThai = @sTrangThai, sSoDienThoai = @sSoDienThoai
	where sMaNV = @sMaNV;
END;
--PROC delete NhanVien
CREATE PROCEDURE sp_Xoa_tblNhanVien
	@sMaNV varchar(50)
AS
BEGIN
	DELETE FROM tblNhanVien
	WHERE sMaNV = @sMaNV;
END;


INSERT INTO tblAccount (sMaNV, sMatKhau, sLoaiTK)
VALUES
    ('NV1', 'password1', 'Admin'),
    ('NV2', 'password2', 'User'),
    ('NV3', 'password3', 'User');
INSERT INTO tblNhanVien (sMaNV, sTenNV, sGioiTinh, sDiaChi, dNgaySinh, sTrangThai, sSoDienThoai)
VALUES
    ('NV1', 'Nguyen Van A', N'Nam', N'123 Đường ABC', '1990-01-01', N'Hoạt động', '0123456789'),
    ('NV2', 'Tran Thi B', N'Nữ', N'456 Đường XYZ', '1985-05-15', N'Nghỉ làm', '0987654321'),
    ('NV3', 'Le Van C', N'Nam', N'789 Đường LMN', '1995-03-20', N'Hoạt động', '0369874123');
INSERT INTO tblKhachHang ( sTenKH, sDiaChi, sSoDienThoai, sGioiTinh)
VALUES
    ('Tran Van A', N'111 Đường PQR', '0123456789', N'Nam'),
    ('Nguyen Thi Y', N'222 Đường STU', '0987654321', N'Nữ'),
    ('Le Van Z', N'333 Đường VWX', '0369874123', N'Nam');
	delete from tblKhachHang where sTenKH = N'Ten KH'
INSERT INTO tblDoUong (sMaDoUong, sTenDoUong, fGiaGoc)
VALUES
    ('DU1', N'Cà phê sữa đá', 25000),
    ('DU2', N'Trà đào cam sả', 35000),
    ('DU3', N'Bạc xỉu', 20000);
INSERT INTO tblSize (sSizeDoUong, fTiSoGiaSize)
VALUES
    ('S', 1.0),
    ('M', 1.2),
    ('L', 1.4);
INSERT INTO tblHoaDon ( sMaNV, iMaKH, dNgayBan, sTrangThaiHD)
VALUES
    ('NV1', '1', '2023-09-19', N'Hoàn thành'),
    ('NV2', '2', '2023-09-20', N'Hoàn thành'),
    ( 'NV3', '3', '2023-09-21', N'Chưa hoàn thành');

INSERT INTO tblHoaDon ( sMaNV, iMaKH, dNgayBan, sTrangThaiHD)
VALUES
    ( 'NV1', 4, '2023-10-19', N'Hoàn thành');
	truncate table tblChiTietHD
	truncate table tblHoaDon
delete from tblHoaDon where iMaHD = 4
INSERT INTO tblChiTietHD (iMaHD, sMaDoUong, sSizeDoUong, iSoLuongBan, fMucGiamGia)
VALUES
    (2, 'DU1', 'S', 2, 0.1),
    (1, 'DU2', 'L', 1, 0.0),
    (2, 'DU2', 'S', 3, 0.05),
    (2, 'DU3', 'M', 2, 0.2),
    (3, 'DU2', 'L', 2, 0.15);
	INSERT INTO tblChiTietHD (iMaHD, sMaDoUong, sSizeDoUong, iSoLuongBan, fMucGiamGia)
VALUES
	(3, 'DU1', 'M', 2, 0.15),
	('HD7', 'DU2', 'M', 2, 0.15);
	delete from tblChiTietHD where sMaDoUong = 'DU2' and iMaHD =2
	delete from tblKhachHang where sDiaChi = ''
	delete from tblHoaDon where fTongTienThanhToan =0
select*from tblAccount
select*from tblNhanVien
select*from tblDoUong
select*from tblSize
select*from tblKhachHang
select*from tblChiTietHD
select*from tblHoaDon
delete from tblDoUong where fGiaGoc = 0
--SELECT * FROM tblNhanVien WHERE sMaNV = '' OR '1'='1'
DBCC CHECKIDENT('tblHoaDon', RESEED, 0)
DBCC CHECKIDENT('tblKhachHang', RESEED, 0)
create View VD_BienLai
as
Select sMaHD,tblHoaDon.sMaNV,tblHoaDon.sMaKH,sTenNV,sTenKH,fTongTienThanhToan,dNgayBan
from tblHoaDon,tblNhanVien,tblKhachHang
where tblHoaDon.sMaNV = tblNhanVien.sMaNV and tblHoaDon.sMaKH = tblKhachHang.sMaKH
group by sMaHD,tblHoaDon.sMaNV,tblHoaDon.sMaKH,fTongTienThanhToan,dNgayBan,sTenNV,sTenKH
select *from VD_BienLai

create proc searchmaHD
@iMaHD varchar(10)
as
begin
select iMaHD,tblHoaDon.sMaNV,tblHoaDon.iMaKH,sTenNV,sTenKH,fTongTienThanhToan,dNgayBan from  tblHoaDon,tblNhanVien,tblKhachHang
where tblHoaDon.sMaNV = tblNhanVien.sMaNV and tblHoaDon.iMaKH = tblKhachHang.iMaKH and iMaHD = @iMaHD
end
exec searchmaHD @iMaHD = '1'

create proc searchHD
@iMaHD varchar(10)
as
begin
select
tblHoaDon.iMaHD,tblHoaDon.sMaNV,tblHoaDon.iMaKH,sTenNV,sTenKH,tblKhachHang.sDiaChi,tblKhachHang.sSoDienThoai,tblKhachHang.sGioiTinh,
tblChiTietHD.sMaDoUong,tblDoUong.sTenDoUong,tblChiTietHD.sSizeDoUong,tblChiTietHD.iSoLuongBan,tblChiTietHD.fMucGiamGia,tblChiTietHD.fGiaBan,
dNgayBan,fTongTienThanhToan
from  tblHoaDon
INNER JOIN tblChiTietHD  ON tblHoaDon.iMaHD = tblChiTietHD.iMaHD
INNER JOIN tblKhachHang ON tblHoaDon.iMaKH = tblKhachHang.iMaKH
INNER JOIN tblDoUong ON tblChiTietHD.sMaDoUong = tblDoUong.sMaDoUong
INNER JOIN tblNhanVien ON tblHoaDon.sMaNV = tblNhanVien.sMaNV
where tblHoaDon.iMaHD = @iMaHD
end
exec searchHD @iMaHD = '4'
drop proc searchHD

ALTER PROCEDURE searchNV
AS
BEGIN
    -- Lấy ngày đầu tiên của tháng trước
    DECLARE @StartDate date = DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) - 1, 0);

    -- Lấy ngày cuối cùng của tháng trước
    DECLARE @EndDate date = DATEADD(DAY, -1, DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0));

    -- Lấy thông tin về tháng trước dưới dạng chuỗi
    DECLARE @MonthName nvarchar(50) = FORMAT(@StartDate, 'MMMM-yyyy');

    -- Tìm thông tin nhân viên theo mã và hóa đơn bán trong tháng trước
    SELECT 
        nv.*,
        COUNT(hd.iMaHD) AS TotalOrders,
        SUM(hd.fTongTienThanhToan) AS TotalSalesRevenue,
        @MonthName AS PreviousMonth
    FROM tblNhanVien nv
    LEFT JOIN tblHoaDon hd ON nv.sMaNV = hd.sMaNV
    WHERE hd.dNgayBan BETWEEN @StartDate AND @EndDate
    GROUP BY nv.sMaNV, nv.sTenNV, nv.sGioiTinh, nv.sDiaChi, nv.dNgaySinh, nv.sTrangThai, nv.sSoDienThoai;
END;

exec searchNV 
--PROC Add KhachHang
CREATE PROCEDURE sp_Them_tblKhachHang
	@sTenKH nvarchar(50),
	@sDiaChi nvarchar(50),
	@sSoDienThoai varchar(255),
	@sGioiTinh nvarchar(10)
AS
BEGIN
	INSERT INTO tblKhachHang(sTenKH, sDiaChi, sSoDienThoai, sGioiTinh)
	VALUES (@sTenKH, @sDiaChi, @sSoDienThoai, @sGioiTinh);
END;

--PROC sửa NhanVien
CREATE PROCEDURE sp_Sua_tblKhachHang
	@iMaKH int,
	@sTenKH nvarchar(50),
	@sDiaChi nvarchar(50),
	@sSoDienThoai varchar(255),
	@sGioiTinh nvarchar(10)
AS
BEGIN
	update tblKhachHang
	set sTenKH = @sTenKH, sDiaChi = @sDiaChi, 
	sSoDienThoai = @sSoDienThoai, sGioiTinh = @sGioiTinh
	where iMaKH = @iMaKH
END;
--PROC delete Khach Hang
CREATE PROCEDURE sp_Xoa_tblKhachHang
	@iMaKH int
AS
BEGIN
	DELETE FROM tblKhachHang
	WHERE iMaKH = @iMaKH;
END;

----PROC Add DoUong
CREATE PROCEDURE sp_Them_tblDoUong
	@sMaDoUong nvarchar(50),
	@sTenDoUong nvarchar(50),
	@fGiaGoc float
AS
BEGIN
	INSERT INTO tblDoUong(sMaDoUong, sTenDoUong, fGiaGoc)
	VALUES (@sMaDoUong, @sTenDoUong, @fGiaGoc);
END;

--PROC sửa DoUong
CREATE PROCEDURE sp_Sua_tblDoUong
	@sMaDoUong nvarchar(50),
	@sTenDoUong nvarchar(50),
	@fGiaGoc float
AS
BEGIN
	update tblDoUong
	set sTenDoUong = @sTenDoUong, fGiaGoc = @fGiaGoc
	where sMaDoUong = @sMaDoUong
END;
--PROC delete DoUong
CREATE PROCEDURE sp_Xoa_tblDoUong
	@sMaDoUong nvarchar(50)
AS
BEGIN
	DELETE FROM tblDoUong
	WHERE sMaDoUong = @sMaDoUong;
END;

----PROC Sua ChiTietHD
alter PROCEDURE sp_Sua_tblChiTietHD
	@iMaHD int,
	@sMaDoUong varchar(50),
	@sSizeDoUong varchar(10),
	@iSoLuongBan float,
	@fMucGiamGia float
AS
BEGIN
	update tblChiTietHD
	set sMaDoUong = @sMaDoUong, sSizeDoUong = @sSizeDoUong, iSoLuongBan = @iSoLuongBan, fMucGiamGia = @fMucGiamGia
	where iMaHD = @iMaHD and sMaDoUong = @sMaDoUong
END;
exec sp_Sua_tblChiTietHD 4, 'DU2', 'S', 1, 0

create PROCEDURE sp_Xoa_tblChiTietHD
	@iMaHD int,
	@sMaDoUong varchar(50),
	@sSizeDoUong varchar(10),
	@iSoLuongBan float
AS
BEGIN
	delete from tblChiTietHD
	where iMaHD = @iMaHD and sMaDoUong = @sMaDoUong and sSizeDoUong = @sSizeDoUong and iSoLuongBan = @iSoLuongBan
END;
exec sp_Xoa_tblChiTietHD 14,'DU1','S',1
select*from tblAccount
select*from tblNhanVien
select*from tblDoUong
select*from tblSize
select*from tblKhachHang
select*from tblChiTietHD
select*from tblHoaDon

DBCC CHECKIDENT('tblHoaDon', RESEED, 3)
DBCC CHECKIDENT('tblKhachHang', RESEED, 3)

alter PROCEDURE CheckDateHD
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT tblHoaDon.iMaHD, tblHoaDon.sMaNV, nv.sTenNV, tblHoaDon.iMaKH, kh.sTenKH, tblHoaDon.dNgayBan,
	tblHoaDon.fTongTienThanhToan, tblHoaDon.sTrangThaiHD, @StartDate as [StartDate], @EndDate as [EndDate]
    FROM tblHoaDon
	INNER JOIN tblNhanVien nv ON tblHoaDon.sMaNV = nv.sMaNV
    INNER JOIN tblKhachHang kh ON tblHoaDon.iMaKH = kh.iMaKH
    WHERE dNgayBan >= @StartDate
    AND dNgayBan <= @EndDate
END
drop proc CheckDateHD
exec CheckDateHD '2023-09-20', '2023-09-20'

CREATE PROCEDURE TimGia_tblDoUong
	@sTenDoUong nvarchar(50)
AS
BEGIN
	select fGiaGoc from tblDoUong
	where sTenDoUong = @sTenDoUong
END;

exec TimGia_tblDoUong N'Bạc xỉu'

CREATE PROCEDURE TimMa_tblDoUong
	@sTenDoUong nvarchar(50)
AS
BEGIN
	select sMaDoUong from tblDoUong
	where sTenDoUong = @sTenDoUong
END;

exec TimMa_tblDoUong N'Bạc xỉu'

ALTER PROCEDURE DanhSachNghiHuu 
AS
BEGIN
    DECLARE @NamNghiHuu INT = 30;
    DECLARE @NuNghiHuu INT = 35;

    SELECT 
        sTenNV, 
        dNgaySinh, 
        sGioiTinh,
        DATEDIFF(YEAR, dNgaySinh, GETDATE()) AS 'TuoiHienTai'
    FROM tblNhanVien
    WHERE
        (sGioiTinh = N'Nam' AND DATEDIFF(YEAR, dNgaySinh, GETDATE()) >= @NamNghiHuu) OR
        (sGioiTinh = N'Nữ' AND DATEDIFF(YEAR, dNgaySinh, GETDATE()) >= @NuNghiHuu);
END;


exec DanhSachNghiHuu