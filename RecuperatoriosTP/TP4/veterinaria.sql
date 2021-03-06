USE [master]
GO
/****** Object:  Database [Veterinaria]    Script Date: 7/19/2022 2:38:37 AM ******/
CREATE DATABASE [Veterinaria]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Veterinaria', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Veterinaria.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Veterinaria_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Veterinaria_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
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
/****** Object:  Table [dbo].[Atenciones]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Atenciones](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MascotaId] [bigint] NOT NULL,
	[Llegada] [datetime] NOT NULL,
	[Salida] [datetime] NOT NULL,
	[PesoActual] [decimal](10, 2) NOT NULL,
	[Observacion] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Visita] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Dni] [bigint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellido] [varchar](50) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EstadosTurno]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EstadosTurno](
	[Id] [smallint] NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadosTurno] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Mascotas]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Mascotas](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ClienteId] [bigint] NOT NULL,
	[TipoMascotaId] [smallint] NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Peso] [decimal](10, 2) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_Mascotas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TiposMascota]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TiposMascota](
	[Id] [smallint] NOT NULL,
	[Tipo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TiposMascota] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Turnos]    Script Date: 7/19/2022 2:38:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Turnos](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MascotaId] [bigint] NOT NULL,
	[Fecha] [date] NOT NULL,
	[HoraInicio] [time](0) NOT NULL,
	[HoraFin] [time](0) NOT NULL,
	[Comentario] [varchar](500) NOT NULL,
	[EstadoTurnoId] [smallint] NOT NULL,
 CONSTRAINT [PK_Turnos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Atenciones] ON 

INSERT [dbo].[Atenciones] ([Id], [MascotaId], [Llegada], [Salida], [PesoActual], [Observacion]) VALUES (14, 31, CAST(N'2022-07-18 01:06:00.000' AS DateTime), CAST(N'2022-07-18 03:06:00.000' AS DateTime), CAST(0.02 AS Decimal(10, 2)), N'primera')
INSERT [dbo].[Atenciones] ([Id], [MascotaId], [Llegada], [Salida], [PesoActual], [Observacion]) VALUES (15, 34, CAST(N'2022-07-01 18:50:00.000' AS DateTime), CAST(N'2022-07-01 19:10:00.000' AS DateTime), CAST(6.00 AS Decimal(10, 2)), N'primera visita')
INSERT [dbo].[Atenciones] ([Id], [MascotaId], [Llegada], [Salida], [PesoActual], [Observacion]) VALUES (16, 34, CAST(N'2022-07-06 01:51:00.000' AS DateTime), CAST(N'2022-07-06 01:59:00.000' AS DateTime), CAST(6.60 AS Decimal(10, 2)), N'segunda visita')
INSERT [dbo].[Atenciones] ([Id], [MascotaId], [Llegada], [Salida], [PesoActual], [Observacion]) VALUES (17, 35, CAST(N'2022-02-08 12:51:00.000' AS DateTime), CAST(N'2022-02-08 16:34:00.000' AS DateTime), CAST(10.00 AS Decimal(10, 2)), N'llego a revision')
SET IDENTITY_INSERT [dbo].[Atenciones] OFF
SET IDENTITY_INSERT [dbo].[Clientes] ON 

INSERT [dbo].[Clientes] ([Id], [Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion], [Activo]) VALUES (100, 30451123, N'juan', N'perez', CAST(N'2004-07-01' AS Date), N'calle 12', 1)
INSERT [dbo].[Clientes] ([Id], [Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion], [Activo]) VALUES (101, 50456987, N'Albert', N'Yama', CAST(N'1999-06-15' AS Date), N'123 av', 1)
INSERT [dbo].[Clientes] ([Id], [Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion], [Activo]) VALUES (102, 20222211, N'Rosa', N'Riso', CAST(N'1980-02-27' AS Date), N'Quilmes', 0)
INSERT [dbo].[Clientes] ([Id], [Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion], [Activo]) VALUES (103, 99999999, N'Julian', N'Rodriguez', CAST(N'2000-04-13' AS Date), N'CABA', 0)
INSERT [dbo].[Clientes] ([Id], [Dni], [Nombre], [Apellido], [FechaNacimiento], [Direccion], [Activo]) VALUES (104, 10123456, N'Maria', N'Juliet', CAST(N'2001-03-21' AS Date), N'San martin 34', 1)
SET IDENTITY_INSERT [dbo].[Clientes] OFF
INSERT [dbo].[EstadosTurno] ([Id], [Descripcion]) VALUES (1, N'Vigente')
INSERT [dbo].[EstadosTurno] ([Id], [Descripcion]) VALUES (2, N'Atendido')
INSERT [dbo].[EstadosTurno] ([Id], [Descripcion]) VALUES (3, N'Cancelado')
SET IDENTITY_INSERT [dbo].[Mascotas] ON 

INSERT [dbo].[Mascotas] ([Id], [ClienteId], [TipoMascotaId], [Nombre], [Peso], [FechaNacimiento], [Activo]) VALUES (31, 100, 2, N'ROM', CAST(0.10 AS Decimal(10, 2)), CAST(N'2022-07-01' AS Date), 1)
INSERT [dbo].[Mascotas] ([Id], [ClienteId], [TipoMascotaId], [Nombre], [Peso], [FechaNacimiento], [Activo]) VALUES (32, 101, 1, N'YUMI', CAST(2.00 AS Decimal(10, 2)), CAST(N'2022-06-01' AS Date), 1)
INSERT [dbo].[Mascotas] ([Id], [ClienteId], [TipoMascotaId], [Nombre], [Peso], [FechaNacimiento], [Activo]) VALUES (33, 104, 2, N'MARA', CAST(10.00 AS Decimal(10, 2)), CAST(N'2022-03-01' AS Date), 1)
INSERT [dbo].[Mascotas] ([Id], [ClienteId], [TipoMascotaId], [Nombre], [Peso], [FechaNacimiento], [Activo]) VALUES (34, 104, 1, N'UMA', CAST(5.00 AS Decimal(10, 2)), CAST(N'2021-11-24' AS Date), 1)
INSERT [dbo].[Mascotas] ([Id], [ClienteId], [TipoMascotaId], [Nombre], [Peso], [FechaNacimiento], [Activo]) VALUES (35, 104, 1, N'TOBIAS', CAST(15.20 AS Decimal(10, 2)), CAST(N'2020-06-10' AS Date), 1)
SET IDENTITY_INSERT [dbo].[Mascotas] OFF
INSERT [dbo].[TiposMascota] ([Id], [Tipo]) VALUES (1, N'Perro')
INSERT [dbo].[TiposMascota] ([Id], [Tipo]) VALUES (2, N'Gato')
SET IDENTITY_INSERT [dbo].[Turnos] ON 

INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (43, 31, CAST(N'2022-07-30' AS Date), CAST(N'14:00:00' AS Time), CAST(N'20:30:00' AS Time), N'vacuna 1', 3)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (44, 32, CAST(N'2022-07-27' AS Date), CAST(N'11:00:00' AS Time), CAST(N'11:30:00' AS Time), N'atencion 1', 3)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (45, 35, CAST(N'2022-07-30' AS Date), CAST(N'11:30:00' AS Time), CAST(N'13:30:00' AS Time), N'vacuna 1', 1)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (46, 35, CAST(N'2022-08-16' AS Date), CAST(N'11:30:00' AS Time), CAST(N'12:30:00' AS Time), N'vacuna 2', 2)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (47, 34, CAST(N'2022-07-30' AS Date), CAST(N'19:30:00' AS Time), CAST(N'22:00:00' AS Time), N'operacion', 1)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (48, 32, CAST(N'2022-08-31' AS Date), CAST(N'12:30:00' AS Time), CAST(N'14:30:00' AS Time), N'viene ', 1)
INSERT [dbo].[Turnos] ([Id], [MascotaId], [Fecha], [HoraInicio], [HoraFin], [Comentario], [EstadoTurnoId]) VALUES (49, 32, CAST(N'2022-08-25' AS Date), CAST(N'11:30:00' AS Time), CAST(N'12:00:00' AS Time), N'vacunas 3', 1)
SET IDENTITY_INSERT [dbo].[Turnos] OFF
ALTER TABLE [dbo].[Atenciones]  WITH CHECK ADD  CONSTRAINT [FK_Atenciones_Mascota] FOREIGN KEY([MascotaId])
REFERENCES [dbo].[Mascotas] ([Id])
GO
ALTER TABLE [dbo].[Atenciones] CHECK CONSTRAINT [FK_Atenciones_Mascota]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_Clientes] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_Clientes]
GO
ALTER TABLE [dbo].[Mascotas]  WITH CHECK ADD  CONSTRAINT [FK_Mascotas_TipoMascota] FOREIGN KEY([TipoMascotaId])
REFERENCES [dbo].[TiposMascota] ([Id])
GO
ALTER TABLE [dbo].[Mascotas] CHECK CONSTRAINT [FK_Mascotas_TipoMascota]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_EstadoTurno] FOREIGN KEY([EstadoTurnoId])
REFERENCES [dbo].[EstadosTurno] ([Id])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_EstadoTurno]
GO
ALTER TABLE [dbo].[Turnos]  WITH CHECK ADD  CONSTRAINT [FK_Turnos_Mascota] FOREIGN KEY([MascotaId])
REFERENCES [dbo].[Mascotas] ([Id])
GO
ALTER TABLE [dbo].[Turnos] CHECK CONSTRAINT [FK_Turnos_Mascota]
GO
USE [master]
GO
ALTER DATABASE [Veterinaria] SET  READ_WRITE 
GO
