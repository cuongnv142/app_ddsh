USE [master]
GO
/****** Object:  Database [CSDLDongThucVat]    Script Date: 2023/12/26 3:00:08 AM ******/
CREATE DATABASE [CSDLDongThucVat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CSDLDongThucVat', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CSDLDongThucVat.mdf' , SIZE = 9280KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CSDLDongThucVat_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\CSDLDongThucVat_log.ldf' , SIZE = 5824KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CSDLDongThucVat] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CSDLDongThucVat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CSDLDongThucVat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET ARITHABORT OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [CSDLDongThucVat] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [CSDLDongThucVat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CSDLDongThucVat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CSDLDongThucVat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CSDLDongThucVat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CSDLDongThucVat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CSDLDongThucVat] SET  MULTI_USER 
GO
ALTER DATABASE [CSDLDongThucVat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CSDLDongThucVat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CSDLDongThucVat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CSDLDongThucVat] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [CSDLDongThucVat]
GO
/****** Object:  StoredProcedure [dbo].[DeleteLoai]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteLoai]
    @id INT
AS
BEGIN
    DELETE FROM HinhAnhLoai WHERE id_dtv_loai = @id
    DELETE FROM Loai WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @UserID INT
AS
BEGIN
    DELETE FROM [user] WHERE id = @UserID;
END
GO
/****** Object:  StoredProcedure [dbo].[HienThi]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[HienThi]
	@id INT
AS
BEGIN
    SELECT
		l.name AS TenTiengViet,
        l.name_latinh AS TenLatinh,
        l.ten_khac AS TenKhac,
        h.name AS Ho,
        b.name AS Bo,
        lp.name AS Lop,
        n.name AS Nganh,
        l.muc_do_bao_ton_iucn,
        l.muc_do_bao_ton_sdvn,
        l.muc_do_bao_ton_ndcp,
        l.muc_do_bao_ton_nd64cp,
        l.dac_diem,
        l.gia_tri_su_dung,
        l.phan_bo
    FROM 
        Nganh n
    JOIN 
        Lop lp ON n.id = lp.id_dtv_nganh
    JOIN 
        Bo b ON lp.id = b.id_dtv_lop
    JOIN 
        Ho h ON b.id = h.id_dtv_bo
    JOIN 
        Loai l ON h.id = l.id_dtv_ho
    WHERE l.id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[InsertBo]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertBo]
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @loai BIT,
    @id_dtv_lop INT,
    @status BIT,
    @created_at DATETIME,
    @created_by INT
AS
BEGIN
    INSERT INTO Bo (name, name_latinh, loai, id_dtv_lop, status, created_at, created_by)
    VALUES (@name, @name_latinh, @loai, @id_dtv_lop, @status, @created_at, @created_by)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertHo]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertHo]
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @loai BIT,
    @id_dtv_bo INT,
    @status BIT,
    @created_at DATETIME,
    @created_by INT
AS
BEGIN
    INSERT INTO Ho (name, name_latinh, loai, id_dtv_bo, status, created_at, created_by)
    VALUES (@name, @name_latinh, @loai, @id_dtv_bo, @status, @created_at, @created_by)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLoai]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertLoai]
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @loai BIT,
    @id_dtv_ho INT,
    @ten_khac NVARCHAR(255),
    @dac_diem NVARCHAR(MAX),
    @gia_tri_su_dung NVARCHAR(MAX),
    @phan_bo NVARCHAR(MAX),
    @nguon_tai_lieu NVARCHAR(255),
    @muc_do_bao_ton_iucn NVARCHAR(50),
    @muc_do_bao_ton_sdvn NVARCHAR(50),
    @muc_do_bao_ton_ndcp NVARCHAR(50),
    @muc_do_bao_ton_nd64cp NVARCHAR(50),
    @status BIT,
    @created_at DATETIME,
    @created_by INT
AS
BEGIN
    INSERT INTO Loai (
        name, name_latinh, loai, id_dtv_ho, ten_khac, dac_diem, gia_tri_su_dung, phan_bo,
        nguon_tai_lieu, muc_do_bao_ton_iucn, muc_do_bao_ton_sdvn,
        muc_do_bao_ton_ndcp, muc_do_bao_ton_nd64cp, status, created_at, created_by
    )
    VALUES (
        @name, @name_latinh, @loai, @id_dtv_ho, @ten_khac, @dac_diem, @gia_tri_su_dung,
        @phan_bo, @nguon_tai_lieu, @muc_do_bao_ton_iucn,
        @muc_do_bao_ton_sdvn, @muc_do_bao_ton_ndcp, @muc_do_bao_ton_nd64cp,
        @status, @created_at, @created_by
    )
END
GO
/****** Object:  StoredProcedure [dbo].[InsertLop]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertLop]
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @loai INT,
    @id_dtv_nganh INT,
    @status BIT,
    @created_at DATETIME,
    @created_by INT
AS
BEGIN
    INSERT INTO Lop (name, name_latinh, loai, id_dtv_nganh, status, created_at, created_by)
    VALUES (@name, @name_latinh, @loai, @id_dtv_nganh, @status, @created_at, @created_by)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertNganh]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertNganh]
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @loai BIT,
    @status BIT,
    @created_at DATETIME,
    @created_by INT
AS
BEGIN
    INSERT INTO Nganh (name, name_latinh, loai, status, created_at, created_by)
    VALUES (@name, @name_latinh, @loai, @status, @created_at, @created_by)
END
GO
/****** Object:  StoredProcedure [dbo].[InsertUser]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertUser]
    @Address NVARCHAR(255),
    @Name NVARCHAR(255),
    @Password NVARCHAR(128),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(255),
    @Gender NVARCHAR(10),
    @Dob DATE,
    @CreatedAt DATETIME,
    @IsAdmin BIT,
    @Status BIT
AS
BEGIN
    INSERT INTO [user] (address, name, password, email, phone, gender, dob, created_at, is_admin, status)
    VALUES (@Address, @Name, @Password, @Email, @Phone, @Gender, @Dob, @CreatedAt, @IsAdmin, @Status)
END
GO
/****** Object:  StoredProcedure [dbo].[Search]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Search]
	@loai BIT,
	@name NVARCHAR(255),
	@name_latinh NVARCHAR(255),
	@id_dtv_nganh INT = NULL,
	@id_dtv_lop INT = NULL,
	@id_dtv_bo INT = NULL,
	@id_dtv_ho INT = NULL,
	@muc_do_bao_ton_iucn NVARCHAR(50) = NULL,
    @muc_do_bao_ton_sdvn NVARCHAR(50) = NULL,
    @muc_do_bao_ton_ndcp NVARCHAR(50) = NULL,
    @muc_do_bao_ton_nd64cp NVARCHAR(50) = NULL
AS
BEGIN
    SELECT
		l.id AS ID,
		l.name AS TenTiengViet,
        l.name_latinh AS TenLatinh,
        l.ten_khac AS TenKhac,
        h.name AS Ho,
        b.name AS Bo,
        lp.name AS Lop,
        n.name AS Nganh
    FROM 
        Nganh n
    JOIN 
        Lop lp ON n.id = lp.id_dtv_nganh
    JOIN 
        Bo b ON lp.id = b.id_dtv_lop
    JOIN 
        Ho h ON b.id = h.id_dtv_bo
    JOIN 
        Loai l ON h.id = l.id_dtv_ho
    WHERE 
	(l.loai = @loai OR @loai IS NULL)
    AND (l.name LIKE '%' + ISNULL(@name, '') + '%' OR @name IS NULL)
    AND (l.name_latinh LIKE '%' + ISNULL(@name_latinh, '') + '%' OR @name_latinh IS NULL)
    AND (n.id = @id_dtv_nganh OR @id_dtv_nganh IS NULL)
    AND (lp.id = @id_dtv_lop OR @id_dtv_lop IS NULL)
    AND (b.id = @id_dtv_bo OR @id_dtv_bo IS NULL)
    AND (h.id = @id_dtv_ho OR @id_dtv_ho IS NULL)
    AND (l.muc_do_bao_ton_iucn = @muc_do_bao_ton_iucn OR @muc_do_bao_ton_iucn IS NULL OR @muc_do_bao_ton_iucn = '')
    AND (l.muc_do_bao_ton_sdvn = @muc_do_bao_ton_sdvn OR @muc_do_bao_ton_sdvn IS NULL OR @muc_do_bao_ton_sdvn = '')
    AND (l.muc_do_bao_ton_ndcp = @muc_do_bao_ton_ndcp OR @muc_do_bao_ton_ndcp IS NULL OR @muc_do_bao_ton_ndcp = '')
    AND (l.muc_do_bao_ton_nd64cp = @muc_do_bao_ton_nd64cp OR @muc_do_bao_ton_nd64cp IS NULL OR @muc_do_bao_ton_nd64cp = '')
END
GO
/****** Object:  StoredProcedure [dbo].[SuaNganh]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SuaNganh]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Nganh
    SET name = @name,
        name_latinh = @name_latinh,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBo]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBo]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @id_dtv_lop INT,
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Bo
    SET name = @name,
        name_latinh = @name_latinh,
        id_dtv_lop = @id_dtv_lop,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateHo]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateHo]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @id_dtv_bo INT,
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Ho
    SET name = @name,
        name_latinh = @name_latinh,
        id_dtv_bo = @id_dtv_bo,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLoai]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLoai]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @id_dtv_ho INT,
    @ten_khac NVARCHAR(255),
    @dac_diem NVARCHAR(MAX),
    @gia_tri_su_dung NVARCHAR(MAX),
    @phan_bo NVARCHAR(MAX),
    @nguon_tai_lieu NVARCHAR(255),
    @muc_do_bao_ton_iucn NVARCHAR(50),
    @muc_do_bao_ton_sdvn NVARCHAR(50),
    @muc_do_bao_ton_ndcp NVARCHAR(50),
    @muc_do_bao_ton_nd64cp NVARCHAR(50),
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Loai
    SET
        name = @name,
        name_latinh = @name_latinh,
        id_dtv_ho = @id_dtv_ho,
        ten_khac = @ten_khac,
        dac_diem = @dac_diem,
        gia_tri_su_dung = @gia_tri_su_dung,
        phan_bo = @phan_bo,
        nguon_tai_lieu = @nguon_tai_lieu,
        muc_do_bao_ton_iucn = @muc_do_bao_ton_iucn,
        muc_do_bao_ton_sdvn = @muc_do_bao_ton_sdvn,
        muc_do_bao_ton_ndcp = @muc_do_bao_ton_ndcp,
        muc_do_bao_ton_nd64cp = @muc_do_bao_ton_nd64cp,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLop]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateLop]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @id_dtv_nganh INT,
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Lop
    SET name = @name,
        name_latinh = @name_latinh,
        id_dtv_nganh = @id_dtv_nganh,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateNganh]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateNganh]
    @id INT,
    @name NVARCHAR(255),
    @name_latinh NVARCHAR(255),
    @status BIT,
    @updated_at DATETIME,
    @updated_by INT
AS
BEGIN
    UPDATE Nganh
    SET name = @name,
        name_latinh = @name_latinh,
        status = @status,
        updated_at = @updated_at,
        updated_by = @updated_by
    WHERE id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateThongTin]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateThongTin]
	@id INT,
	@logo NVARCHAR(MAX),
	@tieude NVARCHAR(255),
	@text_effect NVARCHAR(255),
	@noidung NVARCHAR(MAX)
AS
BEGIN
	UPDATE ThongTin
	SET 
		logo = @logo,
		tieude = @tieude,
		text_effect = @text_effect,
		noidung = @noidung
	WHERE id = @id;
END;

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
	@Id INT,
    @Address NVARCHAR(255),
    @Name NVARCHAR(255),
    @Password NVARCHAR(128),
    @Email NVARCHAR(255),
    @Phone NVARCHAR(255),
    @Gender NVARCHAR(10),
    @Dob DATE,
    @UpdatedAt DATETIME,
    @IsAdmin BIT,
    @Status BIT
AS
BEGIN
    UPDATE [user]
    SET address = @Address, name = @Name, password = @Password, email = @Email, phone = @Phone, gender = @Gender,
        dob = @Dob, updated_at = @UpdatedAt, is_admin = @IsAdmin, status = @Status
    WHERE id = @Id
END
GO
/****** Object:  Table [dbo].[Bo]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[name_latinh] [varchar](255) NULL,
	[loai] [bit] NULL,
	[id_dtv_lop] [int] NULL,
	[status] [bit] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL,
 CONSTRAINT [PK_dtv_bo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HinhAnhLoai]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhLoai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_dtv_loai] [int] NOT NULL,
	[hinhanh] [nvarchar](max) NULL,
 CONSTRAINT [pk1] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[id_dtv_loai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ho]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ho](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[name_latinh] [nvarchar](255) NULL,
	[loai] [bit] NULL,
	[id_dtv_bo] [int] NULL,
	[status] [bit] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Loai]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Loai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[name_latinh] [nvarchar](255) NULL,
	[loai] [bit] NULL,
	[id_dtv_ho] [int] NULL,
	[ten_khac] [nvarchar](255) NULL,
	[dac_diem] [nvarchar](max) NULL,
	[gia_tri_su_dung] [nvarchar](max) NULL,
	[phan_bo] [nvarchar](max) NULL,
	[nguon_tai_lieu] [nvarchar](255) NULL,
	[muc_do_bao_ton_iucn] [nvarchar](50) NULL,
	[muc_do_bao_ton_sdvn] [nvarchar](50) NULL,
	[muc_do_bao_ton_ndcp] [nvarchar](50) NULL,
	[muc_do_bao_ton_nd64cp] [nvarchar](50) NULL,
	[status] [bit] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lop]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lop](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[name_latinh] [nvarchar](255) NULL,
	[loai] [bit] NULL,
	[id_dtv_nganh] [int] NULL,
	[status] [bit] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL,
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Nganh]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nganh](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NULL,
	[name_latinh] [nvarchar](255) NULL,
	[loai] [bit] NULL,
	[status] [bit] NULL,
	[created_at] [datetime] NULL,
	[created_by] [int] NULL DEFAULT (NULL),
	[updated_at] [datetime] NULL,
	[updated_by] [int] NULL DEFAULT (NULL),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThongTin]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[is_image] [bit] NULL,
	[logo] [nvarchar](max) NULL,
	[tieude] [nvarchar](255) NULL,
	[text_effect] [nvarchar](255) NULL,
	[noidung] [nvarchar](max) NULL,
	[hinhanh] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 2023/12/26 3:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[address] [nvarchar](255) NULL,
	[name] [nvarchar](255) NULL,
	[password] [nvarchar](128) NULL,
	[email] [nvarchar](255) NULL,
	[phone] [nvarchar](255) NULL,
	[gender] [nvarchar](10) NULL,
	[dob] [date] NULL,
	[created_at] [datetime] NOT NULL DEFAULT ('1900-01-01T00:00:00'),
	[updated_at] [datetime] NOT NULL DEFAULT ('1900-01-01T00:00:00'),
	[last_signined_time] [datetime] NULL,
	[is_admin] [bit] NOT NULL DEFAULT ((0)),
	[status] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Bo] ON 

INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'ôi dôi ôi', N'oidoioi', 0, 1, 1, CAST(N'2023-12-01 19:11:56.000' AS DateTime), 0, CAST(N'2023-12-01 19:30:18.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (3, N'Trung Nguyên', N'nguyennguyen', 0, 2, 1, CAST(N'2023-12-01 19:17:24.000' AS DateTime), 0, CAST(N'2023-12-01 19:30:37.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (4, N'B? không dây không s?ng', N'khongdaykhongsong', 0, 1, 1, CAST(N'2023-12-01 19:20:29.697' AS DateTime), 0, CAST(N'2023-12-02 02:56:49.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (5, N'Trung Nguyên', N'trungnguyen', 0, 2, 0, CAST(N'2023-12-01 19:25:18.000' AS DateTime), 0, CAST(N'2023-12-02 02:57:54.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (9, N'B? có dây s?ng', N'codaysong', 0, 4, 1, CAST(N'2023-12-02 00:14:12.000' AS DateTime), 0, CAST(N'2023-12-02 02:58:37.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (11, N'B? có dây s?ng 1', N'codaysong1', 0, 4, 0, CAST(N'2023-12-02 00:18:42.000' AS DateTime), 0, CAST(N'2023-12-02 02:58:58.000' AS DateTime), 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (12, N'B? không dây s?ng', N'khongdaysong', 0, 5, 0, CAST(N'2023-12-02 03:03:23.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (13, N'B? KHÔNG DÂY S?NG', N'khongdaysong', 0, 5, 0, CAST(N'2023-12-02 03:03:42.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (14, N'B? CÓ DÂY KHÔNG S?NG', N'', 0, 6, 1, CAST(N'2023-12-02 03:03:58.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (25, N'B? 1', N'Latinh 1', 1, 48, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-12 08:13:27.953' AS DateTime), 10)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (26, N'Bò 2', N'Latinh 2', 0, 1, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (27, N'B? 3', N'Latinh 3', 1, 48, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-12 07:33:49.753' AS DateTime), 10)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (28, N'Bò 4', N'Latinh 4', 0, 52, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (29, N'Bò 5', N'Latinh 5', 1, 53, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (30, N'Bò 6', N'Latinh 6', 0, 53, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (31, N'Bò 7', N'Latinh 7', 1, 54, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (32, N'Bò 8', N'Latinh 8', 0, 54, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (33, N'Bò 9', N'Latinh 9', 1, 55, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (34, N'Bò 10', N'Latinh 10', 0, 55, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (35, N'Bò 11', N'Latinh 11', 1, 56, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (36, N'Bò 12', N'Latinh 12', 0, 56, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (37, N'Bò 13', N'Latinh 13', 1, 57, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (38, N'Bò 14', N'Latinh 14', 0, 57, 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (39, N'Bò 15', N'Latinh 15', 1, 48, 0, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1, CAST(N'2023-12-07 01:37:54.520' AS DateTime), 1)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (40, N'Trung Nguyên 1', N'test thêm', 0, 2, 1, CAST(N'2023-12-07 02:39:17.913' AS DateTime), 6, NULL, NULL)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (44, N'B? d?ng v?t m?i', N'bodvmoi', 0, 4, 1, CAST(N'2023-12-12 08:26:48.193' AS DateTime), 10, CAST(N'2023-12-12 08:37:27.567' AS DateTime), 10)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (45, N'B? th?c v?t m?i', N'botvmoi', 1, 65, 1, CAST(N'2023-12-12 08:35:15.527' AS DateTime), 10, CAST(N'2023-12-12 08:35:35.057' AS DateTime), 10)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (46, N'B? d?ng v?t 007', N'animal 7', 0, 1, 1, CAST(N'2023-12-20 14:57:12.047' AS DateTime), 10, CAST(N'2023-12-20 14:57:44.123' AS DateTime), 10)
INSERT [dbo].[Bo] ([id], [name], [name_latinh], [loai], [id_dtv_lop], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (47, N'B? 007', N'bo007', 1, 66, 1, CAST(N'2023-12-20 15:09:45.090' AS DateTime), 10, CAST(N'2023-12-20 15:09:54.367' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[Bo] OFF
SET IDENTITY_INSERT [dbo].[HinhAnhLoai] ON 

INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (23, 6, N'D:\Images\gg.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1015, 1008, N'D:\Images\jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1016, 1008, N'D:\Images\Linkedin Banner.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1017, 1008, N'D:\Images\Screenshot 2023-03-02 121946.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1018, 1008, N'D:\Images\wallpaper1.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1019, 1008, N'D:\Images\wallpaper2.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1025, 1009, N'D:\Images\tkb.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1026, 1009, N'D:\Images\u̷s̷hio̷.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1027, 1009, N'D:\Images\wallpaper1.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1028, 1009, N'D:\Images\wallpaper2.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1032, 1010, N'D:\Images\jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1033, 1010, N'D:\Images\gg.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1054, 1012, N'C:\Picture\wallpaper1.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1055, 1012, N'C:\Picture\wallpaper2.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1058, 1015, N'C:\Picture\log1638159210_1596.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1059, 1015, N'C:\Picture\tim_kiem.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1100, 1016, N'jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1101, 1016, N'log1638159210_1596.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1102, 1047, N'wallpaper1.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1103, 1047, N'wallpaper2.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1104, 1046, N'IMG_7021.JPG')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1105, 1046, N'jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1106, 1046, N'wallpaper1.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1107, 1046, N'wallpaper2.png')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1108, 1034, N'jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[HinhAnhLoai] ([id], [id_dtv_loai], [hinhanh]) VALUES (1109, 1034, N'log1638159210_1596.png')
SET IDENTITY_INSERT [dbo].[HinhAnhLoai] OFF
SET IDENTITY_INSERT [dbo].[Ho] ON 

INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'Họ có dây sống', N'codaysong', 0, 9, 1, CAST(N'2023-12-02 05:00:00.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (2, N'Họ không dây sống', N'khongdaysong', 0, 12, 1, CAST(N'2023-12-02 05:00:38.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (3, N'Họ không dây không sống', N'', 0, 4, 1, CAST(N'2023-12-02 05:01:01.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (4, N'Họ có dây không sống', N'', 0, 14, 1, CAST(N'2023-12-02 05:01:31.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (5, N'Họ Trung Nguyên', N'trungnguyen', 0, 3, 1, CAST(N'2023-12-02 05:01:53.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (7, N'Họ có dây sống 1', N'codaysong1', 0, 11, 1, CAST(N'2023-12-02 05:02:39.000' AS DateTime), 0, NULL, 0)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (40, N'H? 1', N'Latinh 1', 1, 1, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (41, N'H? 2', N'Latinh 2', 0, 1, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (42, N'H? 3', N'Latinh 3', 1, 5, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (43, N'H? 4', N'Latinh 4', 0, 3, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (44, N'H? 5', N'Latinh 5', 1, 5, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (45, N'H? 6', N'Latinh 6', 0, 5, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (46, N'H? 7', N'Latinh 7', 1, 4, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (47, N'H? 8', N'Latinh 8', 0, 4, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (48, N'H? 9', N'Latinh 9', 1, 5, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (49, N'H? 10', N'Latinh 10', 0, 25, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (50, N'H? 11', N'Latinh 11', 1, 9, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (51, N'H? 12', N'Latinh 12', 0, 9, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (52, N'H? 13', N'Latinh 13', 1, 25, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (53, N'H? 14', N'Latinh 14', 0, 14, 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (54, N'H? 15', N'Latinh 15', 1, 11, 0, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1, CAST(N'2023-12-07 01:39:59.650' AS DateTime), 1)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (57, N'Họ thực vật mới', N'hotvmoi', 1, 45, 1, CAST(N'2023-12-12 08:37:51.937' AS DateTime), 10, CAST(N'2023-12-12 08:38:11.220' AS DateTime), 10)
INSERT [dbo].[Ho] ([id], [name], [name_latinh], [loai], [id_dtv_bo], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (59, N'Họ 007', N'ho007', 1, 47, 1, CAST(N'2023-12-20 15:10:20.113' AS DateTime), 10, CAST(N'2023-12-20 15:10:28.467' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[Ho] OFF
SET IDENTITY_INSERT [dbo].[Loai] ON 

INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'LOÀI CÓ DÂY SỐNG', N'CODAYSONG', 0, 1, N'', N'Có dây', N'sống', N'Hướng Hóa', N'Sách đỏ VN', N'', N'', N'Nhóm IB', N'Nhóm IB', 0, CAST(N'2023-12-03 21:26:59.917' AS DateTime), 1, CAST(N'2023-12-07 10:06:46.347' AS DateTime), 6)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (2, N'LOÀI KHÔNG DÂY SỐNG', N'KHONGDAYSONG', 0, 1, N'', N'Không dây', N's?ng', N'Qu?ng Tr?', N'Sách d? Vi?t Nam', N'EX-Tuy?t ch?ng', N'EX-Tuy?t ch?ng', N'Nhóm IIB', N'Nhóm IIB', 1, CAST(N'2023-12-03 21:28:01.520' AS DateTime), 1, CAST(N'2023-12-03 21:28:01.520' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (3, N'Test thêm loài', N'loai moi', 0, 2, N'loaimoi', N'đặc điểm', N'công dụng', N'VN', N'SDVN', N'', N'', N'', N'', 0, CAST(N'2023-12-07 10:04:23.580' AS DateTime), 6, CAST(N'2023-12-07 10:05:55.557' AS DateTime), 6)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (4, N'Loài thực vật 1', N'thucvat1', 1, 40, N'thucvat', N'dfsdsff', N'sfsdfds', N'VN', N'IUCN', N'EN-Nguy cấp', N'VU-Sẽ nguy cấp', N'Nhóm IIB', N'Nhóm IB', 1, CAST(N'2023-12-07 10:09:58.813' AS DateTime), 6, NULL, NULL)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (6, N'Ngành mới', N'nganhmoi', 0, 41, N'nganh1.0', N'đặc điểm', N'cong dung', N'VN', N'SDVN', N'EW-Tuyệt chủng ngoài thiên nhiên', N'EW-Tuyệt chủng ngoài thiên nhiên', N'Nhóm IB', N'Nhóm IIB', 1, CAST(N'2023-12-07 11:28:02.963' AS DateTime), 6, CAST(N'2023-12-07 12:13:58.110' AS DateTime), 6)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (7, N'Loài thực vật 2', N'thucvat2', 1, 42, N'tv2', N'dsfds', N'dfasdf', N'VN', N'SDVN', N'EX-Tuyệt chủng', N'EX-Tuyệt chủng', N'Nhóm IIB', N'Nhóm IIB', 1, CAST(N'2023-12-07 12:14:56.630' AS DateTime), 6, NULL, NULL)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1008, N'Loài mới', N'loài thực vật', 1, 40, N'fdsfasf', N'ádĐẤ', N'dsadas', N'sfasdfas', N'dsfdafaf', N'EX-Tuyệt chủng', N'EW-Tuyệt chủng ngoài thiên nhiên', N'Nhóm IB', N'Nhóm IB', 1, CAST(N'2023-12-10 09:26:12.470' AS DateTime), 6, CAST(N'2023-12-10 09:26:22.627' AS DateTime), 6)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1009, N'Động vật mới', N'new animal', 0, 1, N'123', N'sdafdsfasd', N'ffdfsadf', N'Vn', N'sdfds', N'EW-Tuyệt chủng ngoài thiên nhiên', N'CR-Rất nguy cấp', N'Nhóm IB', N'Nhóm IB', 1, CAST(N'2023-12-10 22:26:46.973' AS DateTime), 10, CAST(N'2023-12-10 22:27:59.607' AS DateTime), 10)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1010, N'Loài thực vật mớii', N'loaitvmoii', 1, 57, N'tvmoii', N'Đặc điểm hình thái', N'Giá trị sử dụng', N'Việt Nam', N'Sách đỏ Việt Nam', N'EW-Tuyệt chủng ngoài thiên nhiên', N'CR-Rất nguy cấp', N'Nhóm IIB', N'Nhóm IIB', 1, CAST(N'2023-12-12 08:39:16.253' AS DateTime), 10, CAST(N'2023-12-12 08:40:33.343' AS DateTime), 10)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1012, N'Loài động vật mới 7', N'new animal', 0, 1, N'nwnml', N'ádfasdfdsa', N'adsfadsf', N'Việt Nam', N'Sách đỏ VN', N'CR-Rất nguy cấp', N'EN-Nguy cấp', N'Nhóm IIB', N'Nhóm IB', 1, CAST(N'2023-12-19 19:13:51.633' AS DateTime), 10, CAST(N'2023-12-19 22:34:47.117' AS DateTime), 10)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1015, N'Loài 007', N'loai007', 1, 59, N'007', N'Đặc điểm 007', N'Công dụng 007', N'VN', N'Sách đỏ VN', N'EN-Nguy cấp', N'VU-Sẽ nguy cấp', N'Nhóm IB', N'Nhóm IIB', 1, CAST(N'2023-12-20 15:11:37.823' AS DateTime), 10, CAST(N'2023-12-20 15:11:58.320' AS DateTime), 10)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1016, N'Loài động vật mới 008', N'new 008', 0, 3, N'008', N'Đặc điểm sinh thái', N'Giá trị sử dụng', N'VN', N'Sách đỏ VN', N'', N'', N'', N'', 1, CAST(N'2023-12-20 19:32:35.950' AS DateTime), 14, CAST(N'2023-12-25 12:55:47.357' AS DateTime), 14)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1018, N'Loai 1', N'loai1', 0, 1, N'ten_khac_1', N'dac_diem_1', N'gia_tri_su_dung_1', N'phan_bo_1', N'nguon_tai_lieu_1', N'muc_do_bao_ton_iucn_1', N'muc_do_bao_ton_sdvn_1', N'muc_do_bao_ton_ndcp_1', N'muc_do_bao_ton_nd64cp_1', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1019, N'Loai 2', N'loai2', 0, 2, N'ten_khac_2', N'dac_diem_2', N'gia_tri_su_dung_2', N'phan_bo_2', N'nguon_tai_lieu_2', N'muc_do_bao_ton_iucn_2', N'muc_do_bao_ton_sdvn_2', N'muc_do_bao_ton_ndcp_2', N'muc_do_bao_ton_nd64cp_2', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1020, N'Loai 3', N'loai3', 0, 3, N'ten_khac_3', N'dac_diem_3', N'gia_tri_su_dung_3', N'phan_bo_3', N'nguon_tai_lieu_3', N'muc_do_bao_ton_iucn_3', N'muc_do_bao_ton_sdvn_3', N'muc_do_bao_ton_ndcp_3', N'muc_do_bao_ton_nd64cp_3', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1021, N'Loai 4', N'loai4', 0, 4, N'ten_khac_4', N'dac_diem_4', N'gia_tri_su_dung_4', N'phan_bo_4', N'nguon_tai_lieu_4', N'muc_do_bao_ton_iucn_4', N'muc_do_bao_ton_sdvn_4', N'muc_do_bao_ton_ndcp_4', N'muc_do_bao_ton_nd64cp_4', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1022, N'Loai 5', N'loai5', 0, 1, N'ten_khac_5', N'dac_diem_5', N'gia_tri_su_dung_5', N'phan_bo_5', N'nguon_tai_lieu_5', N'muc_do_bao_ton_iucn_5', N'muc_do_bao_ton_sdvn_5', N'muc_do_bao_ton_ndcp_5', N'muc_do_bao_ton_nd64cp_5', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1023, N'Loai 6', N'loai6', 0, 2, N'ten_khac_6', N'dac_diem_6', N'gia_tri_su_dung_6', N'phan_bo_6', N'nguon_tai_lieu_6', N'muc_do_bao_ton_iucn_6', N'muc_do_bao_ton_sdvn_6', N'muc_do_bao_ton_ndcp_6', N'muc_do_bao_ton_nd64cp_6', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1024, N'Loai 7', N'loai7', 0, 3, N'ten_khac_7', N'dac_diem_7', N'gia_tri_su_dung_7', N'phan_bo_7', N'nguon_tai_lieu_7', N'muc_do_bao_ton_iucn_7', N'muc_do_bao_ton_sdvn_7', N'muc_do_bao_ton_ndcp_7', N'muc_do_bao_ton_nd64cp_7', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1025, N'Loai 8', N'loai8', 0, 4, N'ten_khac_8', N'dac_diem_8', N'gia_tri_su_dung_8', N'phan_bo_8', N'nguon_tai_lieu_8', N'muc_do_bao_ton_iucn_8', N'muc_do_bao_ton_sdvn_8', N'muc_do_bao_ton_ndcp_8', N'muc_do_bao_ton_nd64cp_8', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1026, N'Loai 9', N'loai9', 0, 1, N'ten_khac_9', N'dac_diem_9', N'gia_tri_su_dung_9', N'phan_bo_9', N'nguon_tai_lieu_9', N'muc_do_bao_ton_iucn_9', N'muc_do_bao_ton_sdvn_9', N'muc_do_bao_ton_ndcp_9', N'muc_do_bao_ton_nd64cp_9', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1027, N'Loai 10', N'loai10', 0, 2, N'ten_khac_10', N'dac_diem_10', N'gia_tri_su_dung_10', N'phan_bo_10', N'nguon_tai_lieu_10', N'muc_do_bao_ton_iucn_10', N'muc_do_bao_ton_sdvn_10', N'muc_do_bao_ton_ndcp_10', N'muc_do_bao_ton_nd64cp_10', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1028, N'Loai 11', N'loai11', 0, 1, N'ten_khac_11', N'dac_diem_11', N'gia_tri_su_dung_11', N'phan_bo_11', N'nguon_tai_lieu_11', N'muc_do_bao_ton_iucn_11', N'muc_do_bao_ton_sdvn_11', N'muc_do_bao_ton_ndcp_11', N'muc_do_bao_ton_nd64cp_11', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1029, N'Loai 12', N'loai12', 0, 2, N'ten_khac_12', N'dac_diem_12', N'gia_tri_su_dung_12', N'phan_bo_12', N'nguon_tai_lieu_12', N'muc_do_bao_ton_iucn_12', N'muc_do_bao_ton_sdvn_12', N'muc_do_bao_ton_ndcp_12', N'muc_do_bao_ton_nd64cp_12', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1030, N'Loai 13', N'loai13', 0, 3, N'ten_khac_13', N'dac_diem_13', N'gia_tri_su_dung_13', N'phan_bo_13', N'nguon_tai_lieu_13', N'muc_do_bao_ton_iucn_13', N'muc_do_bao_ton_sdvn_13', N'muc_do_bao_ton_ndcp_13', N'muc_do_bao_ton_nd64cp_13', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1031, N'Loai 14', N'loai14', 0, 4, N'ten_khac_14', N'dac_diem_14', N'gia_tri_su_dung_14', N'phan_bo_14', N'nguon_tai_lieu_14', N'muc_do_bao_ton_iucn_14', N'muc_do_bao_ton_sdvn_14', N'muc_do_bao_ton_ndcp_14', N'muc_do_bao_ton_nd64cp_14', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1032, N'Loai 15', N'loai15', 0, 1, N'ten_khac_15', N'dac_diem_15', N'gia_tri_su_dung_15', N'phan_bo_15', N'nguon_tai_lieu_15', N'muc_do_bao_ton_iucn_15', N'muc_do_bao_ton_sdvn_15', N'muc_do_bao_ton_ndcp_15', N'muc_do_bao_ton_nd64cp_15', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1033, N'Loai 16', N'loai16', 0, 2, N'ten_khac_16', N'dac_diem_16', N'gia_tri_su_dung_16', N'phan_bo_16', N'nguon_tai_lieu_16', N'muc_do_bao_ton_iucn_16', N'muc_do_bao_ton_sdvn_16', N'muc_do_bao_ton_ndcp_16', N'muc_do_bao_ton_nd64cp_16', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1034, N'Loai 17', N'loai17', 0, 3, N'ten_khac_17', N'dac_diem_17', N'gia_tri_su_dung_17', N'phan_bo_17', N'nguon_tai_lieu_17', N'EX-Tuyệt chủng', N'EW-Tuyệt chủng ngoài thiên nhiên', N'Nhóm IB', N'Nhóm IB', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:53:02.753' AS DateTime), 14)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1035, N'Loai 18', N'loai18', 0, 4, N'ten_khac_18', N'dac_diem_18', N'gia_tri_su_dung_18', N'phan_bo_18', N'nguon_tai_lieu_18', N'muc_do_bao_ton_iucn_18', N'muc_do_bao_ton_sdvn_18', N'muc_do_bao_ton_ndcp_18', N'muc_do_bao_ton_nd64cp_18', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1036, N'Loai 19', N'loai19', 0, 1, N'ten_khac_19', N'dac_diem_19', N'gia_tri_su_dung_19', N'phan_bo_19', N'nguon_tai_lieu_19', N'muc_do_bao_ton_iucn_19', N'muc_do_bao_ton_sdvn_19', N'muc_do_bao_ton_ndcp_19', N'muc_do_bao_ton_nd64cp_19', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1037, N'Loai 20', N'loai20', 0, 2, N'ten_khac_20', N'dac_diem_20', N'gia_tri_su_dung_20', N'phan_bo_20', N'nguon_tai_lieu_20', N'muc_do_bao_ton_iucn_20', N'muc_do_bao_ton_sdvn_20', N'muc_do_bao_ton_ndcp_20', N'muc_do_bao_ton_nd64cp_20', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1038, N'Loai 21', N'loai21', 0, 3, N'ten_khac_21', N'dac_diem_21', N'gia_tri_su_dung_21', N'phan_bo_21', N'nguon_tai_lieu_21', N'muc_do_bao_ton_iucn_21', N'muc_do_bao_ton_sdvn_21', N'muc_do_bao_ton_ndcp_21', N'muc_do_bao_ton_nd64cp_21', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1039, N'Loai 22', N'loai22', 0, 4, N'ten_khac_22', N'dac_diem_22', N'gia_tri_su_dung_22', N'phan_bo_22', N'nguon_tai_lieu_22', N'muc_do_bao_ton_iucn_22', N'muc_do_bao_ton_sdvn_22', N'muc_do_bao_ton_ndcp_22', N'muc_do_bao_ton_nd64cp_22', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1040, N'Loai 23', N'loai23', 0, 1, N'ten_khac_23', N'dac_diem_23', N'gia_tri_su_dung_23', N'phan_bo_23', N'nguon_tai_lieu_23', N'muc_do_bao_ton_iucn_23', N'muc_do_bao_ton_sdvn_23', N'muc_do_bao_ton_ndcp_23', N'muc_do_bao_ton_nd64cp_23', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1041, N'Loai 24', N'loai24', 0, 2, N'ten_khac_24', N'dac_diem_24', N'gia_tri_su_dung_24', N'phan_bo_24', N'nguon_tai_lieu_24', N'muc_do_bao_ton_iucn_24', N'muc_do_bao_ton_sdvn_24', N'muc_do_bao_ton_ndcp_24', N'muc_do_bao_ton_nd64cp_24', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1042, N'Loai 25', N'loai25', 0, 3, N'ten_khac_25', N'dac_diem_25', N'gia_tri_su_dung_25', N'phan_bo_25', N'nguon_tai_lieu_25', N'muc_do_bao_ton_iucn_25', N'muc_do_bao_ton_sdvn_25', N'muc_do_bao_ton_ndcp_25', N'muc_do_bao_ton_nd64cp_25', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1043, N'Loai 26', N'loai26', 0, 4, N'ten_khac_26', N'dac_diem_26', N'gia_tri_su_dung_26', N'phan_bo_26', N'nguon_tai_lieu_26', N'muc_do_bao_ton_iucn_26', N'muc_do_bao_ton_sdvn_26', N'muc_do_bao_ton_ndcp_26', N'muc_do_bao_ton_nd64cp_26', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1044, N'Loai 27', N'loai27', 0, 1, N'ten_khac_27', N'dac_diem_27', N'gia_tri_su_dung_27', N'phan_bo_27', N'nguon_tai_lieu_27', N'muc_do_bao_ton_iucn_27', N'muc_do_bao_ton_sdvn_27', N'muc_do_bao_ton_ndcp_27', N'muc_do_bao_ton_nd64cp_27', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1045, N'Loai 28', N'loai28', 0, 2, N'ten_khac_28', N'dac_diem_28', N'gia_tri_su_dung_28', N'phan_bo_28', N'nguon_tai_lieu_28', N'muc_do_bao_ton_iucn_28', N'muc_do_bao_ton_sdvn_28', N'muc_do_bao_ton_ndcp_28', N'muc_do_bao_ton_nd64cp_28', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1046, N'Loai 29', N'loai29', 0, 3, N'ten_khac_29', N'dac_diem_29', N'gia_tri_su_dung_29', N'phan_bo_29', N'nguon_tai_lieu_29', N'CR-Rất nguy cấp', N'EX-Tuyệt chủng', N'Nhóm IIB', N'Nhóm IB', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:52:44.810' AS DateTime), 14)
INSERT [dbo].[Loai] ([id], [name], [name_latinh], [loai], [id_dtv_ho], [ten_khac], [dac_diem], [gia_tri_su_dung], [phan_bo], [nguon_tai_lieu], [muc_do_bao_ton_iucn], [muc_do_bao_ton_sdvn], [muc_do_bao_ton_ndcp], [muc_do_bao_ton_nd64cp], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1047, N'Loai 30', N'loai30', 0, 4, N'ten_khac_30', N'dac_diem_30', N'gia_tri_su_dung_30', N'phan_bo_30', N'nguon_tai_lieu_30', N'EX-Tuyệt chủng', N'EX-Tuyệt chủng', N'Nhóm IB', N'Nhóm IIB', 1, CAST(N'2023-12-26 02:50:34.823' AS DateTime), 1, CAST(N'2023-12-26 02:52:26.960' AS DateTime), 14)
SET IDENTITY_INSERT [dbo].[Loai] OFF
SET IDENTITY_INSERT [dbo].[Lop] ON 

INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'Lớp không dây không sống', N'khongdaykhongsong', 0, 8, 0, CAST(N'2023-12-01 17:27:48.660' AS DateTime), 0, CAST(N'2023-12-02 01:45:21.000' AS DateTime), 0)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (2, N'Trung Nguyên', N'trungnguyen', 0, 1, 0, CAST(N'2023-12-01 17:29:25.793' AS DateTime), 0, CAST(N'2023-12-02 01:46:41.000' AS DateTime), 0)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (4, N'Lớp có dây sống', N'lopcodaysong', 0, 1, 1, CAST(N'2023-12-01 18:20:11.000' AS DateTime), 0, CAST(N'2023-12-02 01:46:46.000' AS DateTime), 0)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (5, N'Lớp không dây sống', N'khongdaysong', 0, 2, 0, CAST(N'2023-12-01 18:21:27.000' AS DateTime), 0, CAST(N'2023-12-02 01:44:41.000' AS DateTime), 0)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (6, N'Lớp có dây không sống', N'codaykhongsong', 0, 7, 0, CAST(N'2023-12-02 01:44:11.000' AS DateTime), 0, CAST(N'2023-12-02 01:44:23.000' AS DateTime), 0)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (48, N'L?p 1', N'Latinh 1', 1, 1, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (49, N'L?p 2', N'Latinh 2', 0, 1, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (50, N'L?p 3', N'Latinh 3', 1, 2, 0, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (51, N'L?p 4', N'Latinh 4', 0, 2, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (52, N'L?p 5', N'Latinh 5', 1, 10, 0, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (53, N'L?p 6', N'Latinh 6', 0, 16, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (54, N'L?p 7', N'Latinh 7', 1, 15, 0, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (55, N'L?p 8', N'Latinh 8', 0, 18, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (56, N'L?p 9', N'Latinh 9', 1, 19, 0, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (57, N'L?p 10', N'Latinh 10', 0, 2, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (59, N'L?p 12', N'Latinh 12', 0, 7, 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1, CAST(N'2023-12-07 01:36:41.767' AS DateTime), 1)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (60, N'Test thêm lớp thực vật', N'them', 1, 17, 1, CAST(N'2023-12-07 02:25:32.593' AS DateTime), 6, CAST(N'2023-12-12 07:17:48.130' AS DateTime), 10)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (65, N'Lớp thực vật mới', N'loptvmoi', 1, 42, 0, CAST(N'2023-12-12 08:23:18.293' AS DateTime), 10, NULL, NULL)
INSERT [dbo].[Lop] ([id], [name], [name_latinh], [loai], [id_dtv_nganh], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (66, N'Lớp 007', N'lop007', 1, 44, 0, CAST(N'2023-12-20 15:09:10.953' AS DateTime), 10, CAST(N'2023-12-20 15:09:19.460' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[Lop] OFF
SET IDENTITY_INSERT [dbo].[Nganh] ON 

INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (1, N'NGÀNH CÓ DÂY SỐNG', N'CHORDATA', 0, 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (2, N'NGÀNH KHÔNG DÂY SỐNG', N'KHONGDAYSONG', 0, 1, NULL, NULL, CAST(N'2023-12-03 11:22:48.000' AS DateTime), 2)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (7, N'NGÀNH CÓ DÂY KHÔNG SỐNG', N'CHORDATA2', 0, 1, CAST(N'2023-12-02 01:32:30.000' AS DateTime), 0, CAST(N'2023-12-02 01:33:11.000' AS DateTime), 0)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (8, N'NGÀNH KHÔNG DÂY KHÔNG SỐNG', N'CHORDATA3', 0, 0, CAST(N'2023-12-02 01:34:00.000' AS DateTime), 0, CAST(N'2023-12-02 01:35:23.000' AS DateTime), 0)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (10, N'TEST UPDATE', N'test sql 1', 0, 0, CAST(N'2023-12-03 09:59:43.390' AS DateTime), 1, CAST(N'2023-12-03 11:24:19.000' AS DateTime), 2)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (14, N'NGÀNH MỚI', N'Sửa ngành mới', 0, 0, CAST(N'2023-12-03 11:23:45.000' AS DateTime), 2, CAST(N'2023-12-07 02:01:47.350' AS DateTime), 6)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (15, N'TEST SỬA', N'TEST SỬA', 0, 0, CAST(N'2023-12-03 11:29:12.000' AS DateTime), 2, CAST(N'2023-12-03 12:08:19.000' AS DateTime), 2)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (16, N'TEST TÊN DÀIIIIIIIIIIIIIIIIIIII DÀIIIIIIIIIIIIIIIIIIII', N'TENDAII', 0, 1, CAST(N'2023-12-03 14:32:07.000' AS DateTime), 0, CAST(N'2023-12-03 14:33:04.000' AS DateTime), 0)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (17, N'Ngành 1', N'Latinh 1', 1, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (18, N'Ngành 2', N'Latinh 2', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (19, N'Ngành 3', N'Latinh 3', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (20, N'Ngành 4', N'Latinh 4', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (21, N'Ngành 5', N'Latinh 5', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (22, N'Ngành 6', N'Latinh 6', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (23, N'Ngành 7', N'Latinh 7', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (24, N'Ngành 8', N'Latinh 8', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (25, N'Ngành 9', N'Latinh 9', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (26, N'Ngành 10', N'Latinh 10', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (27, N'Ngành 11', N'Latinh 11', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (28, N'Ngành 12', N'Latinh 12', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (29, N'Ngành 13', N'Latinh 13', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (30, N'Ngành 14', N'Latinh 14', 0, 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (31, N'Ngành 15', N'Latinh 15', 1, 0, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1, CAST(N'2023-12-07 01:32:51.377' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (32, N'Ngành 8', N'Latinh 8', 0, 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (33, N'Ngành 9', N'Latinh 9', 1, 0, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (34, N'Ngành 10', N'Latinh 10', 0, 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (35, N'Ngành 11', N'Latinh 11', 1, 0, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (37, N'Ngành 13', N'Latinh 13', 1, 0, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1, CAST(N'2023-12-07 01:33:24.910' AS DateTime), 1)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (42, N'Ngành thực vật mới', N'Thucvatmoi', 1, 1, CAST(N'2023-12-12 06:41:19.500' AS DateTime), 10, CAST(N'2023-12-12 06:41:54.063' AS DateTime), 10)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (43, N'Ngành động vật mới', N'nganhdvmoi', 0, 1, CAST(N'2023-12-12 08:21:45.807' AS DateTime), 10, CAST(N'2023-12-12 08:22:02.897' AS DateTime), 10)
INSERT [dbo].[Nganh] ([id], [name], [name_latinh], [loai], [status], [created_at], [created_by], [updated_at], [updated_by]) VALUES (44, N'Ngành 007', N'nganh007', 1, 0, CAST(N'2023-12-20 15:08:31.367' AS DateTime), 10, CAST(N'2023-12-20 15:08:41.550' AS DateTime), 10)
SET IDENTITY_INSERT [dbo].[Nganh] OFF
SET IDENTITY_INSERT [dbo].[ThongTin] ON 

INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (1, 0, N'log1638159210_1596.png', N'BAN QUẢN LÝ KHU BẢO TỒN THIÊN NHIÊN
BẮC HƯỚNG HOÁ', N'CƠ SỞ DỮ LIỆU ĐỘNG THỰC VẬT', N'Khu BTTN Bắc Hướng Hóa nằm về phía Tây của tỉnh Quảng Trị và thuộc phía Nam của dải Trường Sơn Bắc, cách thành phố Đông Hà khoảng 100 km theo quốc lộ 9 đến thị trấn Khe Sanh và đường Hồ Chí Minh nhánh Tây.

- Vị trí tọa độ địa lý:

       + Từ 16 043''22’’ - 16059’55’’ vĩ độ Bắc.

       + Từ 106033'' - 106047’03’’ kinh độ Đông', NULL)
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (80, 1, NULL, NULL, NULL, NULL, N'gg.png')
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (81, 1, NULL, NULL, NULL, NULL, N'IMG_7020.JPG')
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (82, 1, NULL, NULL, NULL, NULL, N'jay-rock-64364971-10158241244339368-2150942290674188288-o.jpg')
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (83, 1, NULL, NULL, NULL, NULL, N'tkb.png')
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (84, 1, NULL, NULL, NULL, NULL, N'wallpaper1.png')
INSERT [dbo].[ThongTin] ([id], [is_image], [logo], [tieude], [text_effect], [noidung], [hinhanh]) VALUES (85, 1, NULL, NULL, NULL, NULL, N'wallpaper2.png')
SET IDENTITY_INSERT [dbo].[ThongTin] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (1, N'Bắc Hướng Hóa', N'Admin Bắc Hướng Hoá', N'123', N'admin@bachuonghoa.com', N'0978111003', N'Nam', CAST(N'1999-05-18' AS Date), CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'2023-12-03 20:18:02.000' AS DateTime), NULL, 1, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (2, N'Bắc Hướng Hóa', N'Admin Bắc Hướng Hoá', N'123456', N'admin@bachuonghoa.com', N'0978111003', N'Nam', CAST(N'1999-05-20' AS Date), CAST(N'2023-12-03 02:58:59.667' AS DateTime), CAST(N'2023-12-03 20:36:53.000' AS DateTime), NULL, 1, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (3, N'Hướng Hóa, Quảng Trị', N'Nhân Viên', N'123456', N'nhanvien@bachuonghoa.com', N'0977711003', N'Khác', CAST(N'2001-11-30' AS Date), CAST(N'2023-12-03 03:04:03.017' AS DateTime), CAST(N'2023-12-12 07:13:55.247' AS DateTime), CAST(N'2023-12-12 06:58:20.223' AS DateTime), 0, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (8, N'Hà Nội', N'Nhân viên mới', N'123456', N'nvm@gmail.com', N'05466768898', N'Nữ', CAST(N'2019-05-14' AS Date), CAST(N'2023-12-03 20:38:33.000' AS DateTime), CAST(N'2023-12-03 20:45:10.000' AS DateTime), NULL, 0, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (10, N'Thanh Xuân', N'Admin 1', N'1', N'1', N'0973956942', N'Nam', CAST(N'2002-02-02' AS Date), CAST(N'2023-12-10 15:27:17.447' AS DateTime), CAST(N'2023-12-12 06:57:26.007' AS DateTime), CAST(N'2023-12-25 17:02:00.063' AS DateTime), 1, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (11, N'Địa chỉ 2', N'Nhân viên 2', N'2', N'2', N'SĐT 2', N'Khác', CAST(N'2023-11-11' AS Date), CAST(N'2023-12-12 06:53:41.367' AS DateTime), CAST(N'2023-12-12 06:57:36.397' AS DateTime), NULL, 0, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (14, N'', N'', N'3', N'3', N'', N'', CAST(N'2023-12-12' AS Date), CAST(N'2023-12-12 07:16:56.693' AS DateTime), CAST(N'2023-12-20 19:28:13.230' AS DateTime), CAST(N'2023-12-26 02:58:08.233' AS DateTime), 1, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (15, N'4', N'4', N'4', N'4', N'4', N'Khác', CAST(N'2023-12-19' AS Date), CAST(N'2023-12-19 20:40:20.950' AS DateTime), CAST(N'1900-01-01 00:00:00.000' AS DateTime), CAST(N'2023-12-19 21:02:24.030' AS DateTime), 1, 1)
INSERT [dbo].[user] ([id], [address], [name], [password], [email], [phone], [gender], [dob], [created_at], [updated_at], [last_signined_time], [is_admin], [status]) VALUES (17, N'5', N'5', N'5', N'5', N'5', N'Khác', CAST(N'2000-07-14' AS Date), CAST(N'2023-12-19 21:15:31.763' AS DateTime), CAST(N'2023-12-19 21:15:42.853' AS DateTime), CAST(N'2023-12-20 14:42:48.037' AS DateTime), 1, 1)
SET IDENTITY_INSERT [dbo].[user] OFF
ALTER TABLE [dbo].[Bo]  WITH CHECK ADD  CONSTRAINT [fk2] FOREIGN KEY([id_dtv_lop])
REFERENCES [dbo].[Lop] ([id])
GO
ALTER TABLE [dbo].[Bo] CHECK CONSTRAINT [fk2]
GO
ALTER TABLE [dbo].[HinhAnhLoai]  WITH CHECK ADD  CONSTRAINT [fk5] FOREIGN KEY([id_dtv_loai])
REFERENCES [dbo].[Loai] ([id])
GO
ALTER TABLE [dbo].[HinhAnhLoai] CHECK CONSTRAINT [fk5]
GO
ALTER TABLE [dbo].[Ho]  WITH CHECK ADD  CONSTRAINT [fk3] FOREIGN KEY([id_dtv_bo])
REFERENCES [dbo].[Bo] ([id])
GO
ALTER TABLE [dbo].[Ho] CHECK CONSTRAINT [fk3]
GO
ALTER TABLE [dbo].[Loai]  WITH CHECK ADD  CONSTRAINT [fk4] FOREIGN KEY([id_dtv_ho])
REFERENCES [dbo].[Ho] ([id])
GO
ALTER TABLE [dbo].[Loai] CHECK CONSTRAINT [fk4]
GO
ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [fk1] FOREIGN KEY([id_dtv_nganh])
REFERENCES [dbo].[Nganh] ([id])
GO
ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [fk1]
GO
USE [master]
GO
ALTER DATABASE [CSDLDongThucVat] SET  READ_WRITE 
GO
