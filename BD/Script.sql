USE [master]
GO
/****** Object:  Database [AmarisConsulting]    Script Date: 16/11/2023 4:09:14 p. m. ******/
CREATE DATABASE [AmarisConsulting]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AmarisConsulting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AmarisConsulting.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AmarisConsulting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\AmarisConsulting_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AmarisConsulting] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AmarisConsulting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AmarisConsulting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AmarisConsulting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AmarisConsulting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AmarisConsulting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AmarisConsulting] SET ARITHABORT OFF 
GO
ALTER DATABASE [AmarisConsulting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AmarisConsulting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AmarisConsulting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AmarisConsulting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AmarisConsulting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AmarisConsulting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AmarisConsulting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AmarisConsulting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AmarisConsulting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AmarisConsulting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AmarisConsulting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AmarisConsulting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AmarisConsulting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AmarisConsulting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AmarisConsulting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AmarisConsulting] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AmarisConsulting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AmarisConsulting] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AmarisConsulting] SET  MULTI_USER 
GO
ALTER DATABASE [AmarisConsulting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AmarisConsulting] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AmarisConsulting] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AmarisConsulting] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AmarisConsulting] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AmarisConsulting] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AmarisConsulting] SET QUERY_STORE = OFF
GO
USE [AmarisConsulting]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 16/11/2023 4:09:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoTurnos]    Script Date: 16/11/2023 4:09:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoTurnos](
	[IdEstado] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoTurnos] PRIMARY KEY CLUSTERED 
(
	[IdEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursales]    Script Date: 16/11/2023 4:09:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursales](
	[IdSucursal] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NOT NULL,
	[Telefono] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED 
(
	[IdSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 16/11/2023 4:09:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turnos](
	[IdTurno] [int] IDENTITY(1,1) NOT NULL,
	[IdSucursal] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[FechaHora] [datetime] NOT NULL,
	[IdEstado] [int] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[IdTurno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/11/2023 4:09:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[Usuario] [nvarchar](50) NOT NULL,
	[Clave] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([IdCliente], [Nombres], [Apellidos], [Telefono]) VALUES (1, N'Johanna', N'Montoya', N'3206987189')
SET IDENTITY_INSERT [dbo].[Clientes] OFF
GO
SET IDENTITY_INSERT [dbo].[EstadoTurnos] ON 

INSERT [dbo].[EstadoTurnos] ([IdEstado], [Estado]) VALUES (1, N'Solicitado')
INSERT [dbo].[EstadoTurnos] ([IdEstado], [Estado]) VALUES (2, N'Cancelado')
INSERT [dbo].[EstadoTurnos] ([IdEstado], [Estado]) VALUES (3, N'Activado')
SET IDENTITY_INSERT [dbo].[EstadoTurnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Sucursales] ON 

INSERT [dbo].[Sucursales] ([IdSucursal], [Nombre], [Direccion], [Telefono]) VALUES (1, N'C.C. Santa Fé', N'Avenida 1 # 2 -3 Local 2011', N'1234567')
INSERT [dbo].[Sucursales] ([IdSucursal], [Nombre], [Direccion], [Telefono]) VALUES (2, N'C.C. Oviedo', N'Calle 32 # 56 -89 Local 111', N'5554441')
INSERT [dbo].[Sucursales] ([IdSucursal], [Nombre], [Direccion], [Telefono]) VALUES (3, N'Av. El Poblado', N'Transversal 7 # 45 -89', N'8885554')
SET IDENTITY_INSERT [dbo].[Sucursales] OFF
GO
SET IDENTITY_INSERT [dbo].[Turnos] ON 

INSERT [dbo].[Turnos] ([IdTurno], [IdSucursal], [IdCliente], [FechaHora], [IdEstado]) VALUES (1, 1, 1, CAST(N'2023-11-15T14:20:00.000' AS DateTime), 2)
INSERT [dbo].[Turnos] ([IdTurno], [IdSucursal], [IdCliente], [FechaHora], [IdEstado]) VALUES (2, 1, 1, CAST(N'2023-11-16T10:30:00.000' AS DateTime), 2)
INSERT [dbo].[Turnos] ([IdTurno], [IdSucursal], [IdCliente], [FechaHora], [IdEstado]) VALUES (3, 2, 1, CAST(N'2023-11-17T10:00:00.000' AS DateTime), 1)
INSERT [dbo].[Turnos] ([IdTurno], [IdSucursal], [IdCliente], [FechaHora], [IdEstado]) VALUES (1002, 1, 1, CAST(N'2023-11-16T15:14:49.123' AS DateTime), 2)
INSERT [dbo].[Turnos] ([IdTurno], [IdSucursal], [IdCliente], [FechaHora], [IdEstado]) VALUES (1003, 1, 1, CAST(N'2023-11-16T15:16:33.740' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Turnos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [IdCliente], [Usuario], [Clave]) VALUES (1, 1, N'jomora', N'$2a$10$09q9eHM0zZBTgY7tWmUzJ.xjHpulHFysGblLFxT/Hqj7kQl.1jdJe')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Clientes]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_EstadoTurnos] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[EstadoTurnos] ([IdEstado])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_EstadoTurnos]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Sucursales] FOREIGN KEY([IdSucursal])
REFERENCES [dbo].[Sucursales] ([IdSucursal])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Sucursales]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Clientes] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Clientes] ([IdCliente])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Clientes]
GO
USE [master]
GO
ALTER DATABASE [AmarisConsulting] SET  READ_WRITE 
GO
