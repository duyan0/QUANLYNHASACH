﻿use master
go
create database Sach
go
use Sach
go
--Bảng Admin
CREATE TABLE Admin
( 
ID INT NOT NULL,
HoTen NVARCHAR(MAX) NULL,
Email	   NCHAR(50) NULL,
DiaChi   NVARCHAR(MAX) NULL,
SoDT	   NCHAR(50) NULL,
VaiTro	NCHAR(50) NULL,
TKhoan	   NCHAR(50) NULL,
MKhau	   NCHAR(50) NULL,
PRIMARY KEY CLUSTERED(ID ASC)
);
--Bang Danh Muc san pham
CREATE TABLE DanhMuc
(
ID INT IDENTITY (1, 1) NOT NULL,
DanhMuc1 NCHAR(50) NOT NULL,
TheLoai NVARCHAR(MAX) NULL,
PRIMARY KEY CLUSTERED(ID ASC)
);
--Bang Khach Hang
CREATE TABLE KhachHang
(
IDkh INT IDENTITY (1, 1) NOT NULL,
TenKH NVARCHAR (MAX) NULL,
SoDT NVARCHAR(15) NULL,
Email NVARCHAR(MAX) NUll,
TKhoan	   NCHAR(50) NULL,
MKhau	   NCHAR(50) NULL,

PRIMARY KEY CLUSTERED (IDkh ASC)
);
--Bang San Pham
CREATE TABLE SanPham
(
IDsp INT IDENTITY (1, 1) NOT NULL,
TenSP NVARCHAR(MAX) NULL,
MoTa NVARCHAR(MAX) NULL,
TheLoai INT NULL,
GiaBan DECIMAL(18,2) NULL,
HinhAnh NVARCHAR(MAX) NULL,
TacGia NVARCHAR(MAX) NULL,
NhaXB NVARCHAR(MAX) NULL,
NamXB  DATE NULL,
SoLuong INT NULL,
PRIMARY KEY CLUSTERED (IDsp ASC),
CONSTRAINT FK_SanPham_DanhMuc FOREIGN KEY (TheLoai) REFERENCES DanhMuc (ID)
);
--Bang Don Hang
CREATE TABLE DonHang
(
IDdh INT IDENTITY (1, 1) NOT NULL,
NgayDatHang DATE NULL,
IDkh INT NULL,
DiaChi NVARCHAR (MAX) NULL,
NgayNhanHang DATE NULL,
PRIMARY KEY CLUSTERED (IDdh ASC),
FOREIGN KEY (IDkh) REFERENCES KhachHang (IDkh)
);
--Bang Don Hang Chi Tiet
CREATE TABLE DonHangCT
( 
IDdh INT IDENTITY(1,1) NOT NULL,
IDSanPham INT NULL,
IDDonHang INT NULL,
SoLuong INT NULL,
Gia FLOAT (53) NULL,
DanhGia NVARCHAR(MAX) NULL,
PRIMARY KEY CLUSTERED (IDdh ASC),
FOREIGN KEY (IDSanPham) REFERENCES SanPham (IDsp),
FOREIGN KEY (IDDonHang) REFERENCES DonHang (IDdh)
);