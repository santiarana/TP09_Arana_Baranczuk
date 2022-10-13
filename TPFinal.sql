USE [master]
GO
/****** Object:  Database [TPFINAL]    Script Date: 13/10/2022 10:20:57 ******/
CREATE DATABASE [TPFINAL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPFINAL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TPFINAL.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TPFINAL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TPFINAL_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TPFINAL] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPFINAL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPFINAL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPFINAL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPFINAL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPFINAL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPFINAL] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPFINAL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPFINAL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPFINAL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPFINAL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPFINAL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPFINAL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPFINAL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPFINAL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPFINAL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPFINAL] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPFINAL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPFINAL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPFINAL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPFINAL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPFINAL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPFINAL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPFINAL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPFINAL] SET RECOVERY FULL 
GO
ALTER DATABASE [TPFINAL] SET  MULTI_USER 
GO
ALTER DATABASE [TPFINAL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPFINAL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPFINAL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPFINAL] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPFINAL] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TPFINAL', N'ON'
GO
ALTER DATABASE [TPFINAL] SET QUERY_STORE = OFF
GO
USE [TPFINAL]
GO
/****** Object:  User [alumno]    Script Date: 13/10/2022 10:20:57 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 13/10/2022 10:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FotoColor] [varchar](1000) NOT NULL,
	[IdTela] [int] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 13/10/2022 10:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](100) NOT NULL,
	[FotoProducto] [varchar](1000) NOT NULL,
	[IdTela] [int] NOT NULL,
	[IdColor] [int] NOT NULL,
	[FechaDeIngreso] [date] NOT NULL,
	[CantidadDisponible] [int] NOT NULL,
	[Peso] [float] NOT NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tela]    Script Date: 13/10/2022 10:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tela](
	[IdTela] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[FotoTela] [varchar](1000) NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdTela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/10/2022 10:20:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([IdColor], [Nombre], [FotoColor], [IdTela]) VALUES (1, N'Azul', N'https://i.ytimg.com/vi/6L4D6Enbvsc/maxresdefault.jpg', 2)
INSERT [dbo].[Color] ([IdColor], [Nombre], [FotoColor], [IdTela]) VALUES (2, N'Verde', N'https://i.ytimg.com/vi/iNk9yNYIdOw/maxresdefault.jpg', 2)
INSERT [dbo].[Color] ([IdColor], [Nombre], [FotoColor], [IdTela]) VALUES (3, N'Rojo', N'https://i.ytimg.com/vi/1nYsaP79Dlg/maxresdefault.jpg', 3)
INSERT [dbo].[Color] ([IdColor], [Nombre], [FotoColor], [IdTela]) VALUES (4, N'Rosa', N'data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAARwAAACxCAMAAAAh3/JWAAAAA1BMVEX/tsFHHvIvAAAASElEQVR4nO3BMQEAAADCoPVPbQ0PoAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIALA8UNAAFusnLHAAAAAElFTkSuQmCC', 4)
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (3, N'Ladrillo', N'https://orientfashion.pl/userdata/public/gfx/3401/3.jpg', 3, 3, CAST(N'2022-08-10' AS Date), 5, 22)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (7, N'Chicle', N'https://d2r9epyceweg5n.cloudfront.net/stores/905/256/products/96311-a64f76d5bd4521333c15427491317460-1024-1024.jpg', 1, 4, CAST(N'2022-10-11' AS Date), 15, 20)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (9, N'Marino', N'https://i.pinimg.com/736x/78/d3/b1/78d3b1088485020db41c0807003f6714.jpg', 5, 1, CAST(N'2022-09-23' AS Date), 3, 21)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (10, N'Verde militar', N'https://telasxmetro.vteximg.com.br/arquivos/ids/163299-1000-1000/verde-militar2.jpg?v=637268912604300000', 4, 2, CAST(N'2022-10-21' AS Date), 2, 20)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Tela] ON 

INSERT [dbo].[Tela] ([IdTela], [Nombre], [FotoTela], [Precio]) VALUES (1, N'Interlock', N'https://d2r9epyceweg5n.cloudfront.net/stores/905/256/products/57711-eff15b3558b79fcb0c15427491305396-1024-1024.jpg', 4000)
INSERT [dbo].[Tela] ([IdTela], [Nombre], [FotoTela], [Precio]) VALUES (3, N'Jersey', N'https://http2.mlstatic.com/D_NQ_NP_908303-MLA49204490283_022022-W.jpg', 4130)
INSERT [dbo].[Tela] ([IdTela], [Nombre], [FotoTela], [Precio]) VALUES (4, N'Poliester', N'https://comprarmimaquinadecoser.com/wp-content/uploads/2020/04/que-es-la-tela-de-poliester-1.jpg', 2500)
INSERT [dbo].[Tela] ([IdTela], [Nombre], [FotoTela], [Precio]) VALUES (5, N'Algodon', N'https://http2.mlstatic.com/D_NQ_NP_954249-MLA46588788112_072021-W.jpg', 1000)
SET IDENTITY_INSERT [dbo].[Tela] OFF
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Color] FOREIGN KEY([IdColor])
REFERENCES [dbo].[Color] ([IdColor])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Modelo_Color]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Producto] FOREIGN KEY([IdTela])
REFERENCES [dbo].[Tela] ([IdTela])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Modelo_Producto]
GO
USE [master]
GO
ALTER DATABASE [TPFINAL] SET  READ_WRITE 
GO
