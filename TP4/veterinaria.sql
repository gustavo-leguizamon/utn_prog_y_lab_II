USE [master]
GO

CREATE DATABASE [Veterinaria]
 CONTAINMENT = NONE
 ON  PRIMARY 

ALTER DATABASE [Veterinaria] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Veterinaria].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Veterinaria] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Veterinaria] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Veterinaria] SET ARITHABORT OFF 
GO
ALTER DATABASE [Veterinaria] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Veterinaria] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Veterinaria] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Veterinaria] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Veterinaria] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Veterinaria] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Veterinaria] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Veterinaria] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Veterinaria] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Veterinaria] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Veterinaria] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Veterinaria] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Veterinaria] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Veterinaria] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Veterinaria] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Veterinaria] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Veterinaria] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Veterinaria] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Veterinaria] SET  MULTI_USER 
GO
ALTER DATABASE [Veterinaria] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Veterinaria] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Veterinaria] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Veterinaria] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Veterinaria] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Veterinaria]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Dni] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mascotas](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DniCliente] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Peso] [float] NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turnos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[IdMascota] [bigint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Comentario] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (6, N'juan', N'peres', CAST(N'2004-06-01' AS Date), N'123')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (32, N'araiana', N'lopez', CAST(N'2000-03-15' AS Date), N'calle 1')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (43, N'raul', N'rodriguez', CAST(N'1998-06-12' AS Date), N'calle 2')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (3243, N'karen', N'suru', CAST(N'2000-10-20' AS Date), N'calle 3')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (3434, N'julia', N'isis', CAST(N'1990-02-25' AS Date), N'calle 4')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (4444, N'agustin', N'perez', CAST(N'2002-08-09' AS Date), N'calle 5')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (5555, N'roma', N'paris', CAST(N'1995-04-29' AS Date), N'calle 6')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (444444, N'uma', N'seras', CAST(N'2001-07-11' AS Date), N' calle 7')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (8678678, N'mara', N'liri', CAST(N'2001-01-20' AS Date), N'calle 8 ')
INSERT [dbo].[Clientes] ([Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion]) VALUES (99999999, N'sandy', N'po', CAST(N'2003-04-06' AS Date), N'calle 9')
SET IDENTITY_INSERT [dbo].[Mascotas] ON 

INSERT [dbo].[Mascotas] ([Id], [DniCliente], [Nombre], [Peso], [FechaNacimiento]) VALUES (1, 6, N'MARA', 0.019999999552965164, CAST(N'2022-01-10' AS Date))
INSERT [dbo].[Mascotas] ([Id], [DniCliente], [Nombre], [Peso], [FechaNacimiento]) VALUES (2, 6, N'UMA', 0.019999999552965164, CAST(N'2022-06-11' AS Date))
SET IDENTITY_INSERT [dbo].[Mascotas] OFF
SET IDENTITY_INSERT [dbo].[Turnos] ON 

INSERT [dbo].[Turnos] ([Id], [IdMascota], [Fecha], [Comentario]) VALUES (2, 1, CAST(N'2022-06-24 03:06:31.000' AS DateTime), N'ASDADADSASDAS')
INSERT [dbo].[Turnos] ([Id], [IdMascota], [Fecha], [Comentario]) VALUES (3, 1, CAST(N'2022-06-24 03:06:31.000' AS DateTime), N'ASDADADSASDAS')
INSERT [dbo].[Turnos] ([Id], [IdMascota], [Fecha], [Comentario]) VALUES (4, 2, CAST(N'2022-07-27 00:00:00.000' AS DateTime), N'revisar')
SET IDENTITY_INSERT [dbo].[Turnos] OFF
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Clientes] FOREIGN KEY([DniCliente])
REFERENCES [dbo].[Clientes] ([Dni])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Clientes]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Mascotas] FOREIGN KEY([IdMascota])
REFERENCES [dbo].[Mascotas] ([Id])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Mascotas]
GO
USE [master]
GO
ALTER DATABASE [Veterinaria] SET  READ_WRITE 
GO
