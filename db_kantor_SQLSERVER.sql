USE [master]
GO
/****** Object:  Database [db_kantor]    Script Date: 27/06/2022 20:45:26 ******/
CREATE DATABASE [db_kantor]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'db_kantor', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_kantor.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'db_kantor_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\db_kantor_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [db_kantor] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [db_kantor].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [db_kantor] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [db_kantor] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [db_kantor] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [db_kantor] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [db_kantor] SET ARITHABORT OFF 
GO
ALTER DATABASE [db_kantor] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [db_kantor] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [db_kantor] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [db_kantor] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [db_kantor] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [db_kantor] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [db_kantor] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [db_kantor] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [db_kantor] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [db_kantor] SET  DISABLE_BROKER 
GO
ALTER DATABASE [db_kantor] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [db_kantor] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [db_kantor] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [db_kantor] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [db_kantor] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [db_kantor] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [db_kantor] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [db_kantor] SET RECOVERY FULL 
GO
ALTER DATABASE [db_kantor] SET  MULTI_USER 
GO
ALTER DATABASE [db_kantor] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [db_kantor] SET DB_CHAINING OFF 
GO
ALTER DATABASE [db_kantor] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [db_kantor] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [db_kantor] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [db_kantor] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'db_kantor', N'ON'
GO
ALTER DATABASE [db_kantor] SET QUERY_STORE = OFF
GO
USE [db_kantor]
GO
/****** Object:  Table [dbo].[tbl_absensi]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_absensi](
	[KodeAbsensi] [varchar](50) NOT NULL,
	[NIP] [varchar](50) NULL,
	[Nama] [varchar](50) NULL,
	[Jabatan] [varchar](50) NULL,
	[TanggalAbsen] [varchar](50) NULL,
	[WaktuAbsen] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_absensi] PRIMARY KEY CLUSTERED 
(
	[KodeAbsensi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_admin]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_admin](
	[KodeAdmin] [varchar](50) NOT NULL,
	[NamaAdmin] [varchar](50) NULL,
	[PwdAdmin] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_admin] PRIMARY KEY CLUSTERED 
(
	[KodeAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_golongan]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_golongan](
	[KodeGolongan] [varchar](50) NOT NULL,
	[NamaGolongan] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_golongan] PRIMARY KEY CLUSTERED 
(
	[KodeGolongan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_jabatan]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_jabatan](
	[KodeJabatan] [varchar](50) NOT NULL,
	[NamaJabatan] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_jabatan] PRIMARY KEY CLUSTERED 
(
	[KodeJabatan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_jeniscuti]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_jeniscuti](
	[KodeCuti] [varchar](50) NOT NULL,
	[JenisCuti] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_jeniscuti] PRIMARY KEY CLUSTERED 
(
	[KodeCuti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_pegawai]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pegawai](
	[NIP] [varchar](50) NOT NULL,
	[Nama] [varchar](50) NULL,
	[Jabatan] [varchar](50) NULL,
	[Golongan] [varchar](50) NULL,
	[TempatLahir] [varchar](50) NULL,
	[TanggalLahir] [date] NULL,
	[JenisKelamin] [varchar](50) NULL,
	[Agama] [varchar](50) NULL,
	[Alamat] [varchar](50) NULL,
	[Telephone] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_pegawai] PRIMARY KEY CLUSTERED 
(
	[NIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_pegawaiaktif]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pegawaiaktif](
	[NIP] [varchar](50) NOT NULL,
	[Nama] [varchar](50) NULL,
	[Jabatan] [varchar](50) NULL,
	[Golongan] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_pegawaiaktif] PRIMARY KEY CLUSTERED 
(
	[NIP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_pegawaicuti]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pegawaicuti](
	[KodePegawaiCuti] [varchar](50) NOT NULL,
	[KodePengajuanCuti] [varchar](50) NULL,
	[NIP] [varchar](50) NULL,
	[Nama] [varchar](50) NULL,
	[Jabatan] [varchar](50) NULL,
	[Golongan] [varchar](50) NULL,
	[JenisCuti] [varchar](50) NULL,
	[AlasanCuti] [varchar](50) NULL,
	[DurasiCuti] [varchar](50) NULL,
	[TanggalMulaiCuti] [varchar](50) NULL,
	[TanggalCutiSelesai] [varchar](50) NULL,
	[AlamatKetikaCuti] [varchar](150) NULL,
 CONSTRAINT [PK_tbl_pegawaicuti] PRIMARY KEY CLUSTERED 
(
	[KodePegawaiCuti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_pengajuancuti]    Script Date: 27/06/2022 20:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_pengajuancuti](
	[KodePengajuanCuti] [varchar](50) NOT NULL,
	[NIP] [varchar](50) NULL,
	[Nama] [varchar](50) NULL,
	[Jabatan] [varchar](50) NULL,
	[Golongan] [varchar](50) NULL,
	[JenisCuti] [varchar](50) NULL,
	[AlasanCuti] [varchar](150) NULL,
	[DurasiCuti] [varchar](50) NULL,
	[TanggalMulaiCuti] [date] NULL,
	[TanggalCutiSelesai] [date] NULL,
	[AlamatKetikaCuti] [varchar](150) NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_pengajuancuti] PRIMARY KEY CLUSTERED 
(
	[KodePengajuanCuti] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'121203123', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'03-06-2022', N'02:00:35', N'Tepat Waktu')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'123123123', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'03-06-2022', N'18:27:21', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'12312324124', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'03-06-2022', N'18:27:57', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'123124234', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'21-06-2022', N'17:36:26', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'1232442341234', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'21-06-2022', N'16:53:39', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'234543423425', N'19082010002', N'Izzah Tazkiyah', N'KETUA', N'21-06-2022', N'18:47:06', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'3423412312', N'19082010002', N'Izzah Tazkiyah', N'KETUA', N'21-06-2022', N'19:11:41', N'Terlambat')
INSERT [dbo].[tbl_absensi] ([KodeAbsensi], [NIP], [Nama], [Jabatan], [TanggalAbsen], [WaktuAbsen], [Status]) VALUES (N'34345345', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'09-06-2022', N'22:47:02', N'Terlambat')
GO
INSERT [dbo].[tbl_admin] ([KodeAdmin], [NamaAdmin], [PwdAdmin]) VALUES (N'ADM001', N'Fauzan', N'admin')
INSERT [dbo].[tbl_admin] ([KodeAdmin], [NamaAdmin], [PwdAdmin]) VALUES (N'admin', N'admin', N'admin')
GO
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL001', N'2B')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL002', N'3A')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL003', N'3B')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL004', N'3C')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL005', N'4B')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL006', N'4C')
INSERT [dbo].[tbl_golongan] ([KodeGolongan], [NamaGolongan]) VALUES (N'GOL007', N'1A')
GO
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JAB001', N'BOS BESAR')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB002', N'SEKRETARIS')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB003', N'HRD')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB004', N'OB')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB005', N'MANAGER')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB006', N'KEPALA BIDANG I')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB007', N'Security')
INSERT [dbo].[tbl_jabatan] ([KodeJabatan], [NamaJabatan]) VALUES (N'JB008', N'PEMBANTU')
GO
INSERT [dbo].[tbl_jeniscuti] ([KodeCuti], [JenisCuti]) VALUES (N'CUTI001', N'CUTI SAKIT')
INSERT [dbo].[tbl_jeniscuti] ([KodeCuti], [JenisCuti]) VALUES (N'CUTI002', N'CUTI HARI RAYA')
INSERT [dbo].[tbl_jeniscuti] ([KodeCuti], [JenisCuti]) VALUES (N'CUTI003', N'CUTI BESAR')
INSERT [dbo].[tbl_jeniscuti] ([KodeCuti], [JenisCuti]) VALUES (N'CUTI004', N'CUTI HARI NASIONAL')
GO
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'129312312312', N'Fahp Jelek', N'PENGHIBUR', N'IIIB', N'Surabaya', CAST(N'2022-06-26' AS Date), N'Laki-Laki', N'BUDHA', N'Kenjeran', N'0210349534')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'12931231231213', N'Fahp ganteng', N'BOS BESAR', N'2B', N'Surabaya', CAST(N'2022-06-26' AS Date), N'Laki-Laki', N'BUDHA', N'Surabaya Kenjeran', N'0213124141')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010002', N'Izzah Tazkiyah', N'KETUA', N'II/B', N'Surabaya', CAST(N'2000-12-18' AS Date), N'Laki-Laki', N'ISLAM', N'Jl.Waru, Sidoarjo, Jawa Timur', N'081287374758')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010003', N'Real Ananda Kristi', N'BENDAHARA', N'I/C', N'Surabaya', CAST(N'2001-06-13' AS Date), N'Laki-Laki', N'ISLAM', N'Jl. Rungkut Madya, Surabaya', N'08181293284')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010011', N'Upin Ipin', N'PENGHIBUR', N'IVB', N'Jakarta', CAST(N'2015-06-09' AS Date), N'Laki-Laki', N'KATOLIK', N'JL jalanan durian runtuh', N'08129384723')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010030', N'Muhammad Fachri Ali Haidar', N'KEPALA DEPARTMENT', N'II/A', N'Surabaya', CAST(N'2000-11-28' AS Date), N'Laki-Laki', N'ISLAM', N'Jl. Rungkut Madya, Surabaya, Jawa timur', N'08189283747')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'2A', N'Jakarta', CAST(N'2001-01-18' AS Date), N'Laki-Laki', N'Islam', N'Jakarta', N'081296238548')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010103', N'Muhammad Syaifullah', N'HRD', N'3C', N'Jakarta', CAST(N'1959-11-26' AS Date), N'Laki-Laki', N'ISLAM', N'Jakarta', N'0812312414123')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010108', N'Orang Utan', N'Kepala Rumah Tangga', N'VB', N'Mojokerto', CAST(N'2022-05-21' AS Date), N'Laki-Laki', N'ISLAM', N'JL jalanan mojokerto', N'081213123123')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082010109', N'Cleo', N'PEMBANTU', N'1A', N'Surabaya', CAST(N'2022-06-21' AS Date), N'Laki-Laki', N'BUDHA', N'Surabaya', N'0812973242')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'190820666', N'Testing Integrasi', N'BOS BESAR', N'2B', N'Surabaya', CAST(N'2022-05-29' AS Date), N'Laki-Laki', N'ISLAM', N'Durian Runtuh Surabaya', N'081217243')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'19082077777', N'Evan Ganteng', N'BOS BESAR', N'2B', N'Surabaya', CAST(N'1995-06-28' AS Date), N'Laki-Laki', N'ISLAM', N'Dirumah', N'0812327324')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'1908208888', N'Sayangku', N'BOS BESAR', N'2B', N'Jakarta', CAST(N'2020-02-18' AS Date), N'Perempuan', N'HINDU', N'Jakarta Monas', N'08123424234')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'190877777', N'Real Ganteng', N'BOS BESAR', N'2B', N'Surabaya', CAST(N'2022-06-23' AS Date), N'Laki-Laki', N'BUDHA', N'Rungkut Aye aye', N'021983242342')
INSERT [dbo].[tbl_pegawai] ([NIP], [Nama], [Jabatan], [Golongan], [TempatLahir], [TanggalLahir], [JenisKelamin], [Agama], [Alamat], [Telephone]) VALUES (N'199999999', N'Test dari web ke sqlserver', N'CHEF', N'VB', N'Jakarta', CAST(N'2022-06-07' AS Date), N'Laki-Laki', N'ISLAM', N'JL jalanan mojokerto', N'081213123123')
GO
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'129312312312', N'Fahp Jelek', N'PENGHIBUR', N'IIIB')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'12931231231213', N'Fahp ganteng', N'BOS BESAR', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010002', N'Izzah Tazkiyah', N'KETUA', N'II/B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010003', N'Real Ananda Kristi', N'BENDAHARA', N'I/C')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010011', N'Upin Ipin', N'PENGHIBUR', N'IVB')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010030', N'Muhammad Fachri Ali Haidar', N'KEPALA DEPARTMENT', N'II/A')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010103', N'Muhammad Syaifullah', N'HRD', N'3C')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010108', N'Orang Utan', N'Kepala Rumah Tangga', N'VB')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082010109', N'Cleo', N'PEMBANTU', N'1A')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'190820666', N'Testing Integrasi', N'BOS BESAR', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'19082077777', N'Evan Ganteng', N'BOS BESAR', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'1908208888', N'Sayangku', N'BOS BESAR', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'190877777', N'Real Ganteng', N'BOS BESAR', N'2B')
INSERT [dbo].[tbl_pegawaiaktif] ([NIP], [Nama], [Jabatan], [Golongan]) VALUES (N'199999999', N'Test dari web ke sqlserver', N'CHEF', N'VB')
GO
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'123123124', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'2B', N'CUTI SAKIT', N'COVID', N'30 Hari', CAST(N'2022-06-21' AS Date), CAST(N'2022-07-21' AS Date), N'Jakarta Timur', N'Diterima')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'20123948223', N'19082010102', N'Muhamad Fauzan Siswantoro', N'SEKRETARIS', N'I/A', N'CUTI HARI RAYA', N'Lebaran', N'30 Hari', CAST(N'2022-05-29' AS Date), CAST(N'2022-06-29' AS Date), N'Surabaya Jawa Timur', N'*Menunggu Persetujuan*')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'2012394823', N'19082010102', N'Muhamad Fauzan Siswantoro', N'SEKRETARIS', N'I/A', N'CUTI SAKIT', N'Covid-19', N'30 Hari', CAST(N'2022-05-29' AS Date), CAST(N'2022-06-29' AS Date), N'Surabaya Jawa Timur', N'*Menunggu Persetujuan*')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'203324235245234', N'19082010102', N'Muhamad Fauzan Siswantoro', N'SEKRETARIS', N'IIIB', N'CUTI BESAR', N'Capek Pak', N'30 Hari', CAST(N'2022-05-29' AS Date), CAST(N'2022-06-29' AS Date), N'Jakarta', N'')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'32312323', N'19082010102', N'Muhamad Fauzan', N'SEKRETARIS', N'2B', N'CUTI SAKIT', N'Covid-19', N'5 hari', CAST(N'2022-06-25' AS Date), CAST(N'2022-06-25' AS Date), N'jakarta', N'Diterima')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'434234222', N'19082010002', N'Izzah Tazkiyah', N'KETUA', N'II/B', N'CUTI HARI RAYA', N'Lebaran', N'30 Hari', CAST(N'2022-06-21' AS Date), CAST(N'2022-07-21' AS Date), N'Surabaya', N'Diterima')
INSERT [dbo].[tbl_pengajuancuti] ([KodePengajuanCuti], [NIP], [Nama], [Jabatan], [Golongan], [JenisCuti], [AlasanCuti], [DurasiCuti], [TanggalMulaiCuti], [TanggalCutiSelesai], [AlamatKetikaCuti], [Status]) VALUES (N'56453453244', N'19082010102', N'Muhamad Fauzan Siswantoro', N'SEKRETARIS', N'IVB', N'CUTI BESAR', N'Capek Pak', N'30 Hari', CAST(N'2022-06-21' AS Date), CAST(N'2022-07-21' AS Date), N'Jakarta', N'Diterima')
GO
USE [master]
GO
ALTER DATABASE [db_kantor] SET  READ_WRITE 
GO
