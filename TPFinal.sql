USE [master]
GO
/****** Object:  Database [TPFinal]    Script Date: 17/11/2022 11:55:56 ******/
CREATE DATABASE [TPFinal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TPFinal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TPFinal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TPFinal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\TPFinal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TPFinal] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TPFinal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TPFinal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TPFinal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TPFinal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TPFinal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TPFinal] SET ARITHABORT OFF 
GO
ALTER DATABASE [TPFinal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TPFinal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TPFinal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TPFinal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TPFinal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TPFinal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TPFinal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TPFinal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TPFinal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TPFinal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TPFinal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TPFinal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TPFinal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TPFinal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TPFinal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TPFinal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TPFinal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TPFinal] SET RECOVERY FULL 
GO
ALTER DATABASE [TPFinal] SET  MULTI_USER 
GO
ALTER DATABASE [TPFinal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TPFinal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TPFinal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TPFinal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TPFinal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TPFinal', N'ON'
GO
ALTER DATABASE [TPFinal] SET QUERY_STORE = OFF
GO
USE [TPFinal]
GO
/****** Object:  User [alumno]    Script Date: 17/11/2022 11:55:56 ******/
CREATE USER [alumno] FOR LOGIN [alumno] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Color]    Script Date: 17/11/2022 11:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[IdColor] [int] IDENTITY(1,1) NOT NULL,
	[NombreColor] [varchar](50) NULL,
	[FotoColor] [varchar](1000) NULL,
	[IdTela] [int] NOT NULL,
 CONSTRAINT [PK_Color] PRIMARY KEY CLUSTERED 
(
	[IdColor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 17/11/2022 11:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[NombreProducto] [varchar](100) NULL,
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
/****** Object:  Table [dbo].[Tela]    Script Date: 17/11/2022 11:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tela](
	[IdTela] [int] IDENTITY(1,1) NOT NULL,
	[NombreTela] [varchar](50) NOT NULL,
	[FotoTela] [varchar](1000) NOT NULL,
	[Precio] [float] NOT NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[IdTela] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 17/11/2022 11:55:56 ******/
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

INSERT [dbo].[Color] ([IdColor], [NombreColor], [FotoColor], [IdTela]) VALUES (1, N'Azul', N'azul.jpg', 1)
INSERT [dbo].[Color] ([IdColor], [NombreColor], [FotoColor], [IdTela]) VALUES (2, N'Verde', N'verde.jpg', 5)
INSERT [dbo].[Color] ([IdColor], [NombreColor], [FotoColor], [IdTela]) VALUES (3, N'Rojo', N'rojo.jpg', 3)
INSERT [dbo].[Color] ([IdColor], [NombreColor], [FotoColor], [IdTela]) VALUES (4, N'Rosa', N'rosa.jpg', 4)
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[Producto] ON 

INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (3, N'Ladrillo', N'Ladrillo.jpg', 3, 3, CAST(N'2022-08-10' AS Date), 5, 22)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (7, N'Chicle', N'Chicle.jpg', 1, 4, CAST(N'2022-10-11' AS Date), 15, 20)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (9, N'Marino', N'Marino.jpg', 5, 1, CAST(N'2022-09-23' AS Date), 10, 21)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (10, N'Verde militar', N'Militar.jpg', 4, 2, CAST(N'2022-10-21' AS Date), 2, 20)
INSERT [dbo].[Producto] ([IdProducto], [NombreProducto], [FotoProducto], [IdTela], [IdColor], [FechaDeIngreso], [CantidadDisponible], [Peso]) VALUES (29, N'Francia', N'Francia.jpg', 1, 1, CAST(N'2022-11-09' AS Date), 26, 19)
SET IDENTITY_INSERT [dbo].[Producto] OFF
GO
SET IDENTITY_INSERT [dbo].[Tela] ON 

INSERT [dbo].[Tela] ([IdTela], [NombreTela], [FotoTela], [Precio]) VALUES (1, N'Interlock', N'interlock.jpg', 4000)
INSERT [dbo].[Tela] ([IdTela], [NombreTela], [FotoTela], [Precio]) VALUES (3, N'Jersey', N'jersey.jpg', 4130)
INSERT [dbo].[Tela] ([IdTela], [NombreTela], [FotoTela], [Precio]) VALUES (4, N'Poliester', N'poliester.jpg', 2500)
INSERT [dbo].[Tela] ([IdTela], [NombreTela], [FotoTela], [Precio]) VALUES (5, N'Algodon', N'algodon.jpg', 1000)
SET IDENTITY_INSERT [dbo].[Tela] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([IdUsuario], [Clave]) VALUES (1, N'Tpfinal')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
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
ALTER DATABASE [TPFinal] SET  READ_WRITE 
GO
