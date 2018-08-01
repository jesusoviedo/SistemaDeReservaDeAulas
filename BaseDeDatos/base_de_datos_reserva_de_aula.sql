USE [master]
GO
/****** Object:  Database [ReservaDeAula]    Script Date: 8/1/2018 2:04:02 AM ******/
CREATE DATABASE [ReservaDeAula]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ReservaDeAula', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ReservaDeAula.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ReservaDeAula_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\ReservaDeAula_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [ReservaDeAula] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ReservaDeAula].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ReservaDeAula] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ReservaDeAula] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ReservaDeAula] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ReservaDeAula] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ReservaDeAula] SET ARITHABORT OFF 
GO
ALTER DATABASE [ReservaDeAula] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [ReservaDeAula] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ReservaDeAula] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ReservaDeAula] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ReservaDeAula] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ReservaDeAula] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ReservaDeAula] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ReservaDeAula] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ReservaDeAula] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ReservaDeAula] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ReservaDeAula] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ReservaDeAula] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ReservaDeAula] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ReservaDeAula] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ReservaDeAula] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ReservaDeAula] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ReservaDeAula] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ReservaDeAula] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ReservaDeAula] SET  MULTI_USER 
GO
ALTER DATABASE [ReservaDeAula] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ReservaDeAula] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ReservaDeAula] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ReservaDeAula] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ReservaDeAula] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ReservaDeAula] SET QUERY_STORE = OFF
GO
USE [ReservaDeAula]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [ReservaDeAula]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aula](
	[id_aula] [int] IDENTITY(1,1) NOT NULL,
	[nro_aula] [varchar](50) NOT NULL,
	[id_tipo_aula] [int] NOT NULL,
	[id_piso] [int] NOT NULL,
	[posee_proyector] [char](1) NOT NULL,
	[capacidad] [int] NOT NULL,
 CONSTRAINT [PK_Aula_id_aula] PRIMARY KEY CLUSTERED 
(
	[id_aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[nro_curso] [int] IDENTITY(1,1) NOT NULL,
	[id_aula] [int] NOT NULL,
	[id_materia] [int] NOT NULL,
	[id_turno] [int] NOT NULL,
	[id_profesor] [int] NOT NULL,
	[cant_inscriptos] [int] NOT NULL,
	[anho_lectivo] [int] NOT NULL,
 CONSTRAINT [PK_Curso_nro_curso] PRIMARY KEY CLUSTERED 
(
	[nro_curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departamento]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departamento](
	[id_dpto] [int] IDENTITY(1,1) NOT NULL,
	[nombre_dpto] [varchar](250) NOT NULL,
	[id_facultad] [int] NOT NULL,
 CONSTRAINT [PK_Departamento_id_dpto] PRIMARY KEY CLUSTERED 
(
	[id_dpto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCurso]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleCurso](
	[nro_curso] [int] NOT NULL,
	[id_dia] [int] NOT NULL,
 CONSTRAINT [PK_DetalleCurso_nro_curso_id_dia] PRIMARY KEY CLUSTERED 
(
	[nro_curso] ASC,
	[id_dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleReserva]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleReserva](
	[id_reserva] [bigint] NOT NULL,
	[id_insumo] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_DetalleReserva_id_reserva_id_insumo] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC,
	[id_insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleRol]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRol](
	[id_rol] [varchar](5) NOT NULL,
	[id_permiso] [int] NOT NULL,
 CONSTRAINT [PK_DetalleRol_id_rol_id_permiso] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dia]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dia](
	[id_dia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[cod_dia] [char](1) NOT NULL,
 CONSTRAINT [PK_Dia_id_dia] PRIMARY KEY CLUSTERED 
(
	[id_dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoReserva]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoReserva](
	[id_estado_reserva] [nvarchar](1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EstadoReserva_id_estado_reserva] PRIMARY KEY CLUSTERED 
(
	[id_estado_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultad]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultad](
	[id_facultad] [int] IDENTITY(1,1) NOT NULL,
	[nombre_facultad] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Facultad_id_facultad] PRIMARY KEY CLUSTERED 
(
	[id_facultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Insumo](
	[id_insumo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[id_tip_insumo] [int] NOT NULL,
 CONSTRAINT [PK_Insumo_id_insumo] PRIMARY KEY CLUSTERED 
(
	[id_insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 8/1/2018 2:04:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materia](
	[id_materia] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](250) NOT NULL,
	[id_dpto] [int] NOT NULL,
 CONSTRAINT [PK_Materia_id_materia] PRIMARY KEY CLUSTERED 
(
	[id_materia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permiso](
	[id_permiso] [int] IDENTITY(1,1) NOT NULL,
	[nombre_permiso] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Permiso_id_permiso] PRIMARY KEY CLUSTERED 
(
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[id_persona] [int] IDENTITY(1,1) NOT NULL,
	[documento] [varchar](50) NOT NULL,
	[id_tipo_doc] [int] NOT NULL,
	[nombre] [varchar](250) NOT NULL,
	[apellido] [varchar](250) NOT NULL,
	[fecha_naci] [date] NOT NULL,
	[email] [varchar](250) NOT NULL,
	[profesorSN] [varchar](2) NULL,
 CONSTRAINT [PK_Persona_id_persona] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Piso](
	[id_piso] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Piso_id_piso] PRIMARY KEY CLUSTERED 
(
	[id_piso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesor](
	[id_profesor] [int] IDENTITY(1,1) NOT NULL,
	[id_persona] [int] NOT NULL,
 CONSTRAINT [PK_Profesor_id_profesor] PRIMARY KEY CLUSTERED 
(
	[id_profesor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[id_reserva] [bigint] IDENTITY(1,1) NOT NULL,
	[fecha_reserva] [date] NOT NULL,
	[id_aula] [int] NOT NULL,
	[nro_curso] [int] NOT NULL,
	[observacion] [varchar](650) NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NOT NULL,
	[id_estado_reserva] [nvarchar](1) NOT NULL,
	[id_usuario] [int] NOT NULL,
	[fecha_solicitud] [datetime] NOT NULL,
	[fecha_rechazo] [datetime] NULL,
	[fecha_autorizacion] [datetime] NULL,
	[fecha_anulacion] [datetime] NULL,
 CONSTRAINT [PK_Reserva_id_reserva] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id_rol] [varchar](5) NOT NULL,
	[nombre_rol] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Rol_id_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoAula](
	[id_tipo_aula] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoAula_id_tipo_aula] PRIMARY KEY CLUSTERED 
(
	[id_tipo_aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoDocumento](
	[id_tipo_doc] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoDocumento_id_tipo_doc] PRIMARY KEY CLUSTERED 
(
	[id_tipo_doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoInsumo](
	[id_tip_insumo] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TipoInsumo_id_tip_insumo] PRIMARY KEY CLUSTERED 
(
	[id_tip_insumo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[id_turno] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
	[hora_inicio] [time](7) NOT NULL,
	[hora_fin] [time](7) NOT NULL,
 CONSTRAINT [PK_Turno_id_turno] PRIMARY KEY CLUSTERED 
(
	[id_turno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [varchar](5) NOT NULL,
	[id_persona] [int] NOT NULL,
	[user_name] [varchar](250) NOT NULL,
	[password] [varbinary](max) NOT NULL,
	[id_dpto] [int] NULL,
 CONSTRAINT [PK_Usuario_id_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Aula] ON 

INSERT [dbo].[Aula] ([id_aula], [nro_aula], [id_tipo_aula], [id_piso], [posee_proyector], [capacidad]) VALUES (2, N'100', 7, 1, N'N', 150)
INSERT [dbo].[Aula] ([id_aula], [nro_aula], [id_tipo_aula], [id_piso], [posee_proyector], [capacidad]) VALUES (3, N'301', 3, 7, N'S', 30)
INSERT [dbo].[Aula] ([id_aula], [nro_aula], [id_tipo_aula], [id_piso], [posee_proyector], [capacidad]) VALUES (4, N'451', 3, 8, N'N', 25)
INSERT [dbo].[Aula] ([id_aula], [nro_aula], [id_tipo_aula], [id_piso], [posee_proyector], [capacidad]) VALUES (5, N'201', 6, 5, N'N', 35)
SET IDENTITY_INSERT [dbo].[Aula] OFF
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([nro_curso], [id_aula], [id_materia], [id_turno], [id_profesor], [cant_inscriptos], [anho_lectivo]) VALUES (4, 3, 2, 3, 3, 30, 2018)
INSERT [dbo].[Curso] ([nro_curso], [id_aula], [id_materia], [id_turno], [id_profesor], [cant_inscriptos], [anho_lectivo]) VALUES (5, 5, 9, 4, 1, 45, 2018)
INSERT [dbo].[Curso] ([nro_curso], [id_aula], [id_materia], [id_turno], [id_profesor], [cant_inscriptos], [anho_lectivo]) VALUES (6, 3, 7, 1, 3, 12, 2018)
INSERT [dbo].[Curso] ([nro_curso], [id_aula], [id_materia], [id_turno], [id_profesor], [cant_inscriptos], [anho_lectivo]) VALUES (7, 4, 6, 1, 3, 40, 2018)
SET IDENTITY_INSERT [dbo].[Curso] OFF
SET IDENTITY_INSERT [dbo].[Departamento] ON 

INSERT [dbo].[Departamento] ([id_dpto], [nombre_dpto], [id_facultad]) VALUES (1, N'Informatica', 1)
INSERT [dbo].[Departamento] ([id_dpto], [nombre_dpto], [id_facultad]) VALUES (4, N'Economia', 2)
SET IDENTITY_INSERT [dbo].[Departamento] OFF
INSERT [dbo].[DetalleCurso] ([nro_curso], [id_dia]) VALUES (4, 2)
INSERT [dbo].[DetalleCurso] ([nro_curso], [id_dia]) VALUES (5, 3)
INSERT [dbo].[DetalleCurso] ([nro_curso], [id_dia]) VALUES (5, 4)
INSERT [dbo].[DetalleReserva] ([id_reserva], [id_insumo], [cantidad]) VALUES (21, 7, 1)
INSERT [dbo].[DetalleReserva] ([id_reserva], [id_insumo], [cantidad]) VALUES (21, 9, 2)
INSERT [dbo].[DetalleReserva] ([id_reserva], [id_insumo], [cantidad]) VALUES (22, 8, 1)
INSERT [dbo].[DetalleReserva] ([id_reserva], [id_insumo], [cantidad]) VALUES (24, 8, 2)
INSERT [dbo].[DetalleRol] ([id_rol], [id_permiso]) VALUES (N'PROFE', 1)
INSERT [dbo].[DetalleRol] ([id_rol], [id_permiso]) VALUES (N'PROFE', 2)
INSERT [dbo].[DetalleRol] ([id_rol], [id_permiso]) VALUES (N'SUPER', 4)
SET IDENTITY_INSERT [dbo].[Dia] ON 

INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (1, N'Lunes', N'L')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (2, N'Martes', N'M')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (3, N'Miercoles', N'X')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (4, N'Jueves', N'J')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (5, N'Viernes', N'V')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (6, N'Sábado', N'S')
INSERT [dbo].[Dia] ([id_dia], [descripcion], [cod_dia]) VALUES (7, N'Domingo', N'D')
SET IDENTITY_INSERT [dbo].[Dia] OFF
INSERT [dbo].[EstadoReserva] ([id_estado_reserva], [descripcion]) VALUES (N'X', N'Anulado')
INSERT [dbo].[EstadoReserva] ([id_estado_reserva], [descripcion]) VALUES (N'A', N'Autorizado')
INSERT [dbo].[EstadoReserva] ([id_estado_reserva], [descripcion]) VALUES (N'P', N'Pendiente')
INSERT [dbo].[EstadoReserva] ([id_estado_reserva], [descripcion]) VALUES (N'R', N'Rechazado')
SET IDENTITY_INSERT [dbo].[Facultad] ON 

INSERT [dbo].[Facultad] ([id_facultad], [nombre_facultad]) VALUES (2, N'FACULTAD DE CIENCIAS ECONÓMICAS Y EMPRESARIALES')
INSERT [dbo].[Facultad] ([id_facultad], [nombre_facultad]) VALUES (1, N'FACULTAD DE CIENCIAS Y TECNOLOGÍA')
SET IDENTITY_INSERT [dbo].[Facultad] OFF
SET IDENTITY_INSERT [dbo].[Insumo] ON 

INSERT [dbo].[Insumo] ([id_insumo], [descripcion], [id_tip_insumo]) VALUES (7, N'Borrador', 3)
INSERT [dbo].[Insumo] ([id_insumo], [descripcion], [id_tip_insumo]) VALUES (8, N'Proyector', 1)
INSERT [dbo].[Insumo] ([id_insumo], [descripcion], [id_tip_insumo]) VALUES (9, N'Marcador', 3)
SET IDENTITY_INSERT [dbo].[Insumo] OFF
SET IDENTITY_INSERT [dbo].[Materia] ON 

INSERT [dbo].[Materia] ([id_materia], [descripcion], [id_dpto]) VALUES (2, N'Visual Avanzado', 1)
INSERT [dbo].[Materia] ([id_materia], [descripcion], [id_dpto]) VALUES (6, N'SQL', 1)
INSERT [dbo].[Materia] ([id_materia], [descripcion], [id_dpto]) VALUES (7, N'Logica 1', 1)
INSERT [dbo].[Materia] ([id_materia], [descripcion], [id_dpto]) VALUES (9, N'Contabilidad 1', 4)
SET IDENTITY_INSERT [dbo].[Materia] OFF
SET IDENTITY_INSERT [dbo].[Permiso] ON 

INSERT [dbo].[Permiso] ([id_permiso], [nombre_permiso]) VALUES (1, N'Curso')
INSERT [dbo].[Permiso] ([id_permiso], [nombre_permiso]) VALUES (4, N'Reserva')
INSERT [dbo].[Permiso] ([id_permiso], [nombre_permiso]) VALUES (2, N'Universidad')
SET IDENTITY_INSERT [dbo].[Permiso] OFF
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([id_persona], [documento], [id_tipo_doc], [nombre], [apellido], [fecha_naci], [email], [profesorSN]) VALUES (1, N'4530246', 1, N'Jesus', N'Oviedo Riquelme', CAST(N'1992-09-23' AS Date), N'reservaaula2018@gmail.com', N'S')
INSERT [dbo].[Persona] ([id_persona], [documento], [id_tipo_doc], [nombre], [apellido], [fecha_naci], [email], [profesorSN]) VALUES (8, N'45845', 1, N'Javier ', N'Amarilla', CAST(N'1985-03-04' AS Date), N'j92riquelme@gmail.com', N'S')
SET IDENTITY_INSERT [dbo].[Persona] OFF
SET IDENTITY_INSERT [dbo].[Piso] ON 

INSERT [dbo].[Piso] ([id_piso], [descripcion]) VALUES (5, N'2')
INSERT [dbo].[Piso] ([id_piso], [descripcion]) VALUES (7, N'3')
INSERT [dbo].[Piso] ([id_piso], [descripcion]) VALUES (8, N'4')
INSERT [dbo].[Piso] ([id_piso], [descripcion]) VALUES (1, N'A')
SET IDENTITY_INSERT [dbo].[Piso] OFF
SET IDENTITY_INSERT [dbo].[Profesor] ON 

INSERT [dbo].[Profesor] ([id_profesor], [id_persona]) VALUES (1, 1)
INSERT [dbo].[Profesor] ([id_profesor], [id_persona]) VALUES (3, 8)
SET IDENTITY_INSERT [dbo].[Profesor] OFF
SET IDENTITY_INSERT [dbo].[Reserva] ON 

INSERT [dbo].[Reserva] ([id_reserva], [fecha_reserva], [id_aula], [nro_curso], [observacion], [hora_inicio], [hora_fin], [id_estado_reserva], [id_usuario], [fecha_solicitud], [fecha_rechazo], [fecha_autorizacion], [fecha_anulacion]) VALUES (20, CAST(N'2018-08-01' AS Date), 5, 6, N'', CAST(N'09:00:00' AS Time), CAST(N'10:00:00' AS Time), N'A', 11, CAST(N'2018-07-31T23:29:22.920' AS DateTime), NULL, CAST(N'2018-07-31T23:35:24.883' AS DateTime), NULL)
INSERT [dbo].[Reserva] ([id_reserva], [fecha_reserva], [id_aula], [nro_curso], [observacion], [hora_inicio], [hora_fin], [id_estado_reserva], [id_usuario], [fecha_solicitud], [fecha_rechazo], [fecha_autorizacion], [fecha_anulacion]) VALUES (21, CAST(N'2018-08-02' AS Date), 4, 7, N'', CAST(N'08:00:00' AS Time), CAST(N'09:00:00' AS Time), N'X', 11, CAST(N'2018-07-31T23:36:43.450' AS DateTime), NULL, NULL, CAST(N'2018-07-31T23:38:22.843' AS DateTime))
INSERT [dbo].[Reserva] ([id_reserva], [fecha_reserva], [id_aula], [nro_curso], [observacion], [hora_inicio], [hora_fin], [id_estado_reserva], [id_usuario], [fecha_solicitud], [fecha_rechazo], [fecha_autorizacion], [fecha_anulacion]) VALUES (22, CAST(N'2018-08-03' AS Date), 5, 5, N'', CAST(N'16:00:00' AS Time), CAST(N'17:00:00' AS Time), N'A', 13, CAST(N'2018-07-31T23:40:31.673' AS DateTime), NULL, CAST(N'2018-07-31T23:42:29.130' AS DateTime), NULL)
INSERT [dbo].[Reserva] ([id_reserva], [fecha_reserva], [id_aula], [nro_curso], [observacion], [hora_inicio], [hora_fin], [id_estado_reserva], [id_usuario], [fecha_solicitud], [fecha_rechazo], [fecha_autorizacion], [fecha_anulacion]) VALUES (23, CAST(N'2018-08-04' AS Date), 3, 5, N'', CAST(N'09:30:00' AS Time), CAST(N'11:00:00' AS Time), N'A', 13, CAST(N'2018-07-31T23:41:19.543' AS DateTime), NULL, CAST(N'2018-07-31T23:42:32.260' AS DateTime), NULL)
INSERT [dbo].[Reserva] ([id_reserva], [fecha_reserva], [id_aula], [nro_curso], [observacion], [hora_inicio], [hora_fin], [id_estado_reserva], [id_usuario], [fecha_solicitud], [fecha_rechazo], [fecha_autorizacion], [fecha_anulacion]) VALUES (24, CAST(N'2018-08-06' AS Date), 2, 5, N'Estan invitados alumnos de las UCA', CAST(N'18:00:00' AS Time), CAST(N'22:00:00' AS Time), N'R', 13, CAST(N'2018-07-31T23:59:32.433' AS DateTime), CAST(N'2018-08-01T00:04:37.383' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Reserva] OFF
INSERT [dbo].[Rol] ([id_rol], [nombre_rol]) VALUES (N'PROFE', N'Profesor')
INSERT [dbo].[Rol] ([id_rol], [nombre_rol]) VALUES (N'SUPER', N'Supervisor')
SET IDENTITY_INSERT [dbo].[TipoAula] ON 

INSERT [dbo].[TipoAula] ([id_tipo_aula], [descripcion]) VALUES (5, N'Invertida')
INSERT [dbo].[TipoAula] ([id_tipo_aula], [descripcion]) VALUES (6, N'Laboratorio')
INSERT [dbo].[TipoAula] ([id_tipo_aula], [descripcion]) VALUES (3, N'Normal')
INSERT [dbo].[TipoAula] ([id_tipo_aula], [descripcion]) VALUES (7, N'Salon')
SET IDENTITY_INSERT [dbo].[TipoAula] OFF
SET IDENTITY_INSERT [dbo].[TipoDocumento] ON 

INSERT [dbo].[TipoDocumento] ([id_tipo_doc], [descripcion]) VALUES (1, N'Cedula de Identidad')
INSERT [dbo].[TipoDocumento] ([id_tipo_doc], [descripcion]) VALUES (3, N'D.N.I')
INSERT [dbo].[TipoDocumento] ([id_tipo_doc], [descripcion]) VALUES (4, N'Pasaporte')
SET IDENTITY_INSERT [dbo].[TipoDocumento] OFF
SET IDENTITY_INSERT [dbo].[TipoInsumo] ON 

INSERT [dbo].[TipoInsumo] ([id_tip_insumo], [descripcion]) VALUES (1, N'Ofimatica')
INSERT [dbo].[TipoInsumo] ([id_tip_insumo], [descripcion]) VALUES (3, N'Utiles')
SET IDENTITY_INSERT [dbo].[TipoInsumo] OFF
SET IDENTITY_INSERT [dbo].[Turno] ON 

INSERT [dbo].[Turno] ([id_turno], [descripcion], [hora_inicio], [hora_fin]) VALUES (1, N'Noche', CAST(N'19:00:00' AS Time), CAST(N'21:50:00' AS Time))
INSERT [dbo].[Turno] ([id_turno], [descripcion], [hora_inicio], [hora_fin]) VALUES (3, N'Mañana', CAST(N'08:00:00' AS Time), CAST(N'10:50:00' AS Time))
INSERT [dbo].[Turno] ([id_turno], [descripcion], [hora_inicio], [hora_fin]) VALUES (4, N'Tarde', CAST(N'16:00:00' AS Time), CAST(N'18:50:00' AS Time))
SET IDENTITY_INSERT [dbo].[Turno] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id_usuario], [id_rol], [id_persona], [user_name], [password], [id_dpto]) VALUES (6, N'SUPER', 1, N'joviedosup', 0x6A6F766965646F737570, 1)
INSERT [dbo].[Usuario] ([id_usuario], [id_rol], [id_persona], [user_name], [password], [id_dpto]) VALUES (11, N'PROFE', 8, N'javierpro', 0x6A617669657270726F, 1)
INSERT [dbo].[Usuario] ([id_usuario], [id_rol], [id_persona], [user_name], [password], [id_dpto]) VALUES (13, N'PROFE', 8, N'japro', 0x6A6170726F, 4)
INSERT [dbo].[Usuario] ([id_usuario], [id_rol], [id_persona], [user_name], [password], [id_dpto]) VALUES (16, N'SUPER', 1, N'jesussup', 0x6A65737573737570, 4)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Aula_nro_aula]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Aula] ADD  CONSTRAINT [UC_Aula_nro_aula] UNIQUE NONCLUSTERED 
(
	[nro_aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Departamento_nombre_dpto]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Departamento] ADD  CONSTRAINT [UC_Departamento_nombre_dpto] UNIQUE NONCLUSTERED 
(
	[nombre_dpto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Dia_cod_dia]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Dia] ADD  CONSTRAINT [UC_Dia_cod_dia] UNIQUE NONCLUSTERED 
(
	[cod_dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Dia_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Dia] ADD  CONSTRAINT [UC_Dia_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_EstadoReserva_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[EstadoReserva] ADD  CONSTRAINT [UC_EstadoReserva_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Facultad_nombre_facultad]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Facultad] ADD  CONSTRAINT [UC_Facultad_nombre_facultad] UNIQUE NONCLUSTERED 
(
	[nombre_facultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Insumo_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Insumo] ADD  CONSTRAINT [UC_Insumo_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Materia_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Materia] ADD  CONSTRAINT [UC_Materia_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Permiso_nombre_permiso]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Permiso] ADD  CONSTRAINT [UC_Permiso_nombre_permiso] UNIQUE NONCLUSTERED 
(
	[nombre_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Persona_documento_id_tipo_doc]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Persona] ADD  CONSTRAINT [UC_Persona_documento_id_tipo_doc] UNIQUE NONCLUSTERED 
(
	[documento] ASC,
	[id_tipo_doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Piso_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Piso] ADD  CONSTRAINT [UC_Piso_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Rol_nombre_rol]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Rol] ADD  CONSTRAINT [UC_Rol_nombre_rol] UNIQUE NONCLUSTERED 
(
	[nombre_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TipoAula_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[TipoAula] ADD  CONSTRAINT [UC_TipoAula_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TipoDocumento_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[TipoDocumento] ADD  CONSTRAINT [UC_TipoDocumento_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_TipoInsumo_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[TipoInsumo] ADD  CONSTRAINT [UC_TipoInsumo_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UC_Turno_descripcion]    Script Date: 8/1/2018 2:04:03 AM ******/
ALTER TABLE [dbo].[Turno] ADD  CONSTRAINT [UC_Turno_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Aula]  WITH CHECK ADD  CONSTRAINT [FK_Aula_id_piso] FOREIGN KEY([id_piso])
REFERENCES [dbo].[Piso] ([id_piso])
GO
ALTER TABLE [dbo].[Aula] CHECK CONSTRAINT [FK_Aula_id_piso]
GO
ALTER TABLE [dbo].[Aula]  WITH CHECK ADD  CONSTRAINT [FK_Aula_id_tipo_aula] FOREIGN KEY([id_tipo_aula])
REFERENCES [dbo].[TipoAula] ([id_tipo_aula])
GO
ALTER TABLE [dbo].[Aula] CHECK CONSTRAINT [FK_Aula_id_tipo_aula]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_id_aula] FOREIGN KEY([id_aula])
REFERENCES [dbo].[Aula] ([id_aula])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_id_aula]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_id_materia] FOREIGN KEY([id_materia])
REFERENCES [dbo].[Materia] ([id_materia])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_id_materia]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_id_profesor] FOREIGN KEY([id_profesor])
REFERENCES [dbo].[Profesor] ([id_profesor])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_id_profesor]
GO
ALTER TABLE [dbo].[Curso]  WITH CHECK ADD  CONSTRAINT [FK_Curso_id_turno] FOREIGN KEY([id_turno])
REFERENCES [dbo].[Turno] ([id_turno])
GO
ALTER TABLE [dbo].[Curso] CHECK CONSTRAINT [FK_Curso_id_turno]
GO
ALTER TABLE [dbo].[Departamento]  WITH CHECK ADD  CONSTRAINT [FK_Departamento_id_facultad] FOREIGN KEY([id_facultad])
REFERENCES [dbo].[Facultad] ([id_facultad])
GO
ALTER TABLE [dbo].[Departamento] CHECK CONSTRAINT [FK_Departamento_id_facultad]
GO
ALTER TABLE [dbo].[DetalleCurso]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCurso_id_dia] FOREIGN KEY([id_dia])
REFERENCES [dbo].[Dia] ([id_dia])
GO
ALTER TABLE [dbo].[DetalleCurso] CHECK CONSTRAINT [FK_DetalleCurso_id_dia]
GO
ALTER TABLE [dbo].[DetalleCurso]  WITH CHECK ADD  CONSTRAINT [FK_DetalleCurso_nro_curso] FOREIGN KEY([nro_curso])
REFERENCES [dbo].[Curso] ([nro_curso])
GO
ALTER TABLE [dbo].[DetalleCurso] CHECK CONSTRAINT [FK_DetalleCurso_nro_curso]
GO
ALTER TABLE [dbo].[DetalleReserva]  WITH CHECK ADD  CONSTRAINT [FK_DetalleReserva_id_insumo] FOREIGN KEY([id_insumo])
REFERENCES [dbo].[Insumo] ([id_insumo])
GO
ALTER TABLE [dbo].[DetalleReserva] CHECK CONSTRAINT [FK_DetalleReserva_id_insumo]
GO
ALTER TABLE [dbo].[DetalleReserva]  WITH CHECK ADD  CONSTRAINT [FK_DetalleReserva_id_reserva] FOREIGN KEY([id_reserva])
REFERENCES [dbo].[Reserva] ([id_reserva])
GO
ALTER TABLE [dbo].[DetalleReserva] CHECK CONSTRAINT [FK_DetalleReserva_id_reserva]
GO
ALTER TABLE [dbo].[DetalleRol]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRol_id_permiso] FOREIGN KEY([id_permiso])
REFERENCES [dbo].[Permiso] ([id_permiso])
GO
ALTER TABLE [dbo].[DetalleRol] CHECK CONSTRAINT [FK_DetalleRol_id_permiso]
GO
ALTER TABLE [dbo].[DetalleRol]  WITH CHECK ADD  CONSTRAINT [FK_DetalleRol_id_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id_rol])
GO
ALTER TABLE [dbo].[DetalleRol] CHECK CONSTRAINT [FK_DetalleRol_id_rol]
GO
ALTER TABLE [dbo].[Insumo]  WITH CHECK ADD  CONSTRAINT [FK_Insumo_id_tip_insumo] FOREIGN KEY([id_tip_insumo])
REFERENCES [dbo].[TipoInsumo] ([id_tip_insumo])
GO
ALTER TABLE [dbo].[Insumo] CHECK CONSTRAINT [FK_Insumo_id_tip_insumo]
GO
ALTER TABLE [dbo].[Materia]  WITH CHECK ADD  CONSTRAINT [FK_Materia_id_departamento] FOREIGN KEY([id_dpto])
REFERENCES [dbo].[Departamento] ([id_dpto])
GO
ALTER TABLE [dbo].[Materia] CHECK CONSTRAINT [FK_Materia_id_departamento]
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_id_tipo_doc] FOREIGN KEY([id_tipo_doc])
REFERENCES [dbo].[TipoDocumento] ([id_tipo_doc])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_id_tipo_doc]
GO
ALTER TABLE [dbo].[Profesor]  WITH CHECK ADD  CONSTRAINT [FK_Profesor_id_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Profesor] CHECK CONSTRAINT [FK_Profesor_id_persona]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_id_aula] FOREIGN KEY([id_aula])
REFERENCES [dbo].[Aula] ([id_aula])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_id_aula]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_id_estado_reserva] FOREIGN KEY([id_estado_reserva])
REFERENCES [dbo].[EstadoReserva] ([id_estado_reserva])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_id_estado_reserva]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuario] ([id_usuario])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_id_usuario]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_nro_curso] FOREIGN KEY([nro_curso])
REFERENCES [dbo].[Curso] ([nro_curso])
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_nro_curso]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK__Usuario__id_dpto__1C873BEC] FOREIGN KEY([id_dpto])
REFERENCES [dbo].[Departamento] ([id_dpto])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__id_dpto__1C873BEC]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_id_persona] FOREIGN KEY([id_persona])
REFERENCES [dbo].[Persona] ([id_persona])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_id_persona]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_id_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[Rol] ([id_rol])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_id_rol]
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarAula
CREATE PROCEDURE [dbo].[SpActualizarAula]
	@nro_aula VARCHAR(50),
	@id_tipo_aula INT,
	@id_piso INT,
	@posee_proyector CHAR(1),
	@capacidad INT,
	@id_aula INT
AS
BEGIN 
	UPDATE Aula
	SET nro_aula=@nro_aula, id_tipo_aula=@id_tipo_aula, id_piso=@id_piso, posee_proyector=@posee_proyector, capacidad=@capacidad
	WHERE id_aula=@id_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarCurso
CREATE PROCEDURE [dbo].[SpActualizarCurso]
	@id_aula INT,
	@id_materia INT,
	@id_turno INT,
	@id_profesor INT,
	@cant_inscriptos INT,
	@anho_lectivo INT,
	@nro_curso INT
AS
BEGIN 
	UPDATE Curso
	SET id_aula=@id_aula, id_materia=@id_materia, id_turno=@id_turno, id_profesor=@id_profesor, cant_inscriptos=@cant_inscriptos, anho_lectivo=@anho_lectivo
	WHERE nro_curso=@nro_curso
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarDepartamento
CREATE PROCEDURE [dbo].[SpActualizarDepartamento]
    @nombre_dpto VARCHAR(250),
	@id_facultad INT,
	@id_dpto INT
AS
BEGIN 
	UPDATE Departamento  
	SET nombre_dpto=@nombre_dpto, id_facultad=@id_facultad
	WHERE id_dpto=@id_dpto
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarDetalleCurso
CREATE PROCEDURE [dbo].[SpActualizarDetalleCurso]
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	UPDATE DetalleCurso  
	SET nro_curso=@nro_curso, id_dia=@id_dia
	WHERE nro_curso=@nro_curso AND id_dia=@id_dia
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarDetalleReserva
CREATE PROCEDURE [dbo].[SpActualizarDetalleReserva]
    @cantidad INT,
	@id_reserva INT,
	@id_insumo INT
AS
BEGIN 
	UPDATE DetalleReserva
	SET @cantidad=@cantidad
	WHERE id_reserva=@id_reserva AND id_insumo=@id_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarDetalleRol
CREATE PROCEDURE [dbo].[SpActualizarDetalleRol]
    @id_rol INT,
	@id_permiso INT
AS
BEGIN 
	UPDATE DetalleRol  
	SET id_rol=@id_rol, id_permiso=@id_permiso
	WHERE id_rol=@id_rol AND id_permiso=@id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarDia]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarDia
CREATE PROCEDURE [dbo].[SpActualizarDia]
	@descripcion VARCHAR(50),
	@cod_dia CHAR(1),
	@id_dia INT
AS
BEGIN 
	UPDATE Dia  
	SET descripcion=@descripcion, cod_dia=@cod_dia
	WHERE id_dia=@id_dia
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarEstadoReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarEstadoReserva
CREATE PROCEDURE [dbo].[SpActualizarEstadoReserva]
	@descripcion VARCHAR(50),
	@id_estado_reserva VARCHAR(1)
AS
BEGIN 
	UPDATE EstadoReserva  
	SET descripcion=@descripcion
	WHERE id_estado_reserva=@id_estado_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarFacultad]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarFacultad
CREATE PROCEDURE [dbo].[SpActualizarFacultad]
	@nombre_facultad VARCHAR(250),
	@id_facultad INT
AS
BEGIN 
	UPDATE Facultad  
	SET nombre_facultad=@nombre_facultad
	WHERE id_facultad=@id_facultad
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarInsumo
CREATE PROCEDURE [dbo].[SpActualizarInsumo]
    @descripcion VARCHAR(50),
	@id_tip_insumo INT,
	@id_insumo INT
AS
BEGIN 
	UPDATE Insumo  
	SET descripcion=@descripcion, id_tip_insumo=@id_tip_insumo
	WHERE id_insumo=@id_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarMateria]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarMateria
CREATE PROCEDURE [dbo].[SpActualizarMateria]
    @descripcion VARCHAR(250),
	@id_dpto INT,
	@id_materia INT
AS
BEGIN 
	UPDATE Materia  
	SET descripcion=@descripcion, id_dpto=@id_dpto
	WHERE id_materia=@id_materia
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarPassword]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarPassword
CREATE PROCEDURE [dbo].[SpActualizarPassword]
	@id_usuario INT,
	@password  VARCHAR(250)
AS
BEGIN 
	UPDATE Usuario  
	SET password=convert(varbinary, @password)
	WHERE id_usuario=@id_usuario;
END
 
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarPermiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarPermiso
CREATE PROCEDURE [dbo].[SpActualizarPermiso]
	@nombre_permiso VARCHAR(250),
	@id_permiso INT
AS
BEGIN 
	UPDATE Permiso  
	SET nombre_permiso=@nombre_permiso
	WHERE id_permiso=@id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarPersona]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarPersona
CREATE PROCEDURE [dbo].[SpActualizarPersona]
    @documento VARCHAR(50),
	@id_tipo_doc INT,
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@fecha_naci DATE,
	@email VARCHAR(250),
	@id_persona INT
AS
BEGIN 
	UPDATE Persona  
	SET documento=@documento, id_tipo_doc=@id_tipo_doc, nombre=@nombre, apellido=@apellido, fecha_naci=@fecha_naci, email=@email
	WHERE id_persona=@id_persona
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarPiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarPiso
CREATE PROCEDURE [dbo].[SpActualizarPiso]
	@descripcion VARCHAR(50),
	@id_piso INT
AS
BEGIN 
	UPDATE Piso  
	SET descripcion=@descripcion
	WHERE id_piso=@id_piso
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarProfesor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarProfesor
CREATE PROCEDURE [dbo].[SpActualizarProfesor]
	@id_persona INT,
	@id_profesor INT
AS
BEGIN 
	UPDATE Profesor  
	SET id_persona=@id_persona
	WHERE id_profesor=@id_profesor
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarReserva
CREATE PROCEDURE [dbo].[SpActualizarReserva]
	@fecha_reserva DATE,
	@id_aula INT,
	@nro_curso INT,
	@observacion VARCHAR(650),
	@hora_inicio TIME,
	@hora_fin TIME,
	--@id_estado_reserva INT,
	@id_usuario INT,    
	@id_reserva BIGINT
AS
BEGIN 
	UPDATE Reserva
	SET fecha_reserva=@fecha_reserva, 
	id_aula=@id_aula, 
	nro_curso=@nro_curso, 
	observacion=@observacion, 
	hora_inicio=@hora_inicio, 
	hora_fin=@hora_fin, 
	--id_estado_reserva=@id_estado_reserva, 
	id_usuario=@id_usuario
	WHERE id_reserva=@id_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarRol
CREATE PROCEDURE [dbo].[SpActualizarRol]
	@nombre_rol VARCHAR(250),
	@id_rol varchar(5)
AS
BEGIN 
	UPDATE Rol  
	SET nombre_rol=@nombre_rol
	WHERE id_rol=@id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarTipoAula
CREATE PROCEDURE [dbo].[SpActualizarTipoAula]
	@descripcion VARCHAR(50),
	@id_tipo_aula INT
AS
BEGIN 
	UPDATE TipoAula  
	SET descripcion=@descripcion
	WHERE id_tipo_aula=@id_tipo_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoDocumento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarTipoDocumento
CREATE PROCEDURE [dbo].[SpActualizarTipoDocumento]
	@descripcion VARCHAR(50),
	@id_tipo_doc INT
AS
BEGIN 
	UPDATE TipoDocumento  
	SET descripcion=@descripcion
	WHERE id_tipo_doc=@id_tipo_doc
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarTipoInsumo
CREATE PROCEDURE [dbo].[SpActualizarTipoInsumo] 
	@descripcion VARCHAR(50),
	@id_tip_insumo INT
AS
BEGIN 
	UPDATE TipoInsumo  
	SET descripcion=@descripcion
	WHERE id_tip_insumo=@id_tip_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarTurno]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarTurno
CREATE PROCEDURE [dbo].[SpActualizarTurno]
	@descripcion VARCHAR(50),
	@hora_inicio TIME,
	@hora_fin TIME,
	@id_turno INT
AS
BEGIN 
	UPDATE Turno  
	SET descripcion=@descripcion, hora_inicio=@hora_inicio, hora_fin=@hora_fin
	WHERE id_turno=@id_turno
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarUsuario
CREATE PROCEDURE [dbo].[SpActualizarUsuario]
	@id_rol VARCHAR(5),
	@id_persona INT,
	@user_name VARCHAR(250),
	@id_dpto INT,
	@id_usuario INT
AS
BEGIN 
	UPDATE Usuario  
	SET id_rol=@id_rol, id_persona=@id_persona, user_name=@user_name, id_dpto=@id_dpto
	WHERE id_usuario=@id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[SpAnularReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--DROP PROCEDURE SpAnularrReserva
CREATE PROCEDURE [dbo].[SpAnularReserva]
	@id_reserva BIGINT  
AS
BEGIN 

	UPDATE Reserva 
	SET id_estado_reserva='X', --Anulado
	fecha_anulacion = GETDATE()
	WHERE id_reserva=@id_reserva;

END
GO
/****** Object:  StoredProcedure [dbo].[SpAutorizarRechazarReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpAutorizarRechazarReserva
CREATE PROCEDURE [dbo].[SpAutorizarRechazarReserva]
	@id_reserva BIGINT,
	@operacion VARCHAR(1)   
AS
BEGIN 

	IF @operacion='A'
	BEGIN
			UPDATE Reserva 
			SET id_estado_reserva='A', --Autorizada
			fecha_autorizacion = GETDATE()
			WHERE id_reserva=@id_reserva;
	END 

	IF @operacion='R'
	BEGIN
			UPDATE Reserva
			SET id_estado_reserva='R', --Rechazada
			fecha_rechazo = GETDATE()
			WHERE id_reserva=@id_reserva;
	END	

END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarAula
CREATE PROCEDURE [dbo].[SpConsultarAula]
	@id_aula INT
AS
BEGIN 
	SELECT  
	a.id_aula,
	a.nro_aula,
	a.id_tipo_aula,
	t.descripcion as nombre_tipo_aula,
	a.id_piso,
	p.descripcion as nombre_piso,
	CASE a.posee_proyector WHEN 'S' THEN 'Si' WHEN 'N' THEN 'No' END as posee_proyector,
	a.capacidad
	FROM Aula a
	INNER JOIN TipoAula t on t.id_tipo_aula=a.id_tipo_aula
	INNER JOIN Piso p on p.id_piso=a.id_piso
	WHERE a.id_aula=@id_aula OR @id_aula=0
	ORDER BY a.nro_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarAulasDisponibles]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarAulasDisponibles
CREATE PROCEDURE [dbo].[SpConsultarAulasDisponibles]
	@fecha_reserva VARCHAR(25),
	@id_tipo_aula INT,
	@cantidad_alumno INT,
	@hora_inicio TIME,
	@hora_fin TIME
AS
BEGIN 
	SELECT --*
	pis.descripcion as piso,
	au.nro_aula as aula,
	au.id_aula,
	au.capacidad,
	CASE au.posee_proyector WHEN 'S' THEN 'Si' WHEN 'N' THEN 'No'  END as proyector
	FROM Aula au
	INNER JOIN Piso pis on pis.id_piso = au.id_piso
	WHERE au.id_tipo_aula = @id_tipo_aula
	AND au.capacidad >= @cantidad_alumno	
	AND NOT EXISTS (
		SELECT * FROM Reserva r 
		WHERE r.id_aula=au.id_aula 
		AND r.fecha_reserva=@fecha_reserva
		AND r.id_estado_reserva = 'A'
		AND (
			(@hora_inicio >= r.hora_inicio AND @hora_fin <= r.hora_fin)
			OR 
			(@hora_fin >= r.hora_inicio AND @hora_fin <= r.hora_fin)
			OR
			(@hora_inicio >= r.hora_inicio AND @hora_inicio <= r.hora_fin)
		)
	)
	ORDER BY au.id_piso, au.nro_aula;

END


--SELECT * FROM Reserva WHERE fecha_reserva='2018-07-31' AND id_estado_reserva = 'A'

--SELECT * FROM Aula

--select * from Aula
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarCantidadReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DROP PROCEDURE SpConsultarCantidadReserva
CREATE PROCEDURE [dbo].[SpConsultarCantidadReserva]
	@id INT,
	@tipo_consulta VARCHAR(1)
AS
BEGIN 

DECLARE @Aprovado INT; 
DECLARE @Rechazado INT; 
DECLARE @Pendiente INT; 
DECLARE @Anulado INT; 
	
	IF @tipo_consulta='S'
	BEGIN
		Select @Aprovado=COUNT(*) from Reserva r1 
		INNER JOIN Curso c on c.nro_curso=r1.nro_curso
		INNER JOIN Materia m on m.id_materia=c.id_materia 
		where r1.id_estado_reserva='A'
		and m.id_dpto=@id;

		Select @Rechazado=COUNT(*) from Reserva r2 
		INNER JOIN Curso c on c.nro_curso=r2.nro_curso
		INNER JOIN Materia m on m.id_materia=c.id_materia 
		Where r2.id_estado_reserva='R'
		and m.id_dpto=@id;

		Select @Pendiente=COUNT(*) from Reserva r3 
		INNER JOIN Curso c on c.nro_curso=r3.nro_curso
		INNER JOIN Materia m on m.id_materia=c.id_materia 
		Where r3.id_estado_reserva='P'
		and m.id_dpto=@id;

		Select @Anulado=-1;

		Select @Aprovado AS Aprobado, @Rechazado AS Rechazado, @Pendiente AS Pendiente,@Anulado AS Anulado;
	END 

	IF @tipo_consulta='P'
	BEGIN
		Select @Aprovado=COUNT(*) from Reserva r1 
		where r1.id_estado_reserva='A' 
		and r1.id_usuario=@id;

		Select @Rechazado=COUNT(*) from Reserva r2 
		Where r2.id_estado_reserva='R'
		and r2.id_usuario=@id;
			
		Select @Pendiente=COUNT(*) from Reserva r3 
		Where r3.id_estado_reserva='P'
		and r3.id_usuario=@id;

		Select @Anulado=COUNT(*) from Reserva r4 
		Where r4.id_estado_reserva='X' 
		and r4.id_usuario=@id;

		Select @Aprovado AS Aprobado, @Rechazado AS Rechazado, @Pendiente AS Pendiente,@Anulado AS Anulado;
	END 

END
 
--EXEC SpConsultarCantidadReserva  1, 'S'

--SELECT * FROM Reserva
--SELECT * FROM Usuario
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarCurso
CREATE PROCEDURE [dbo].[SpConsultarCurso]
	@nro_curso INT
AS
BEGIN 
	SELECT  
	c.nro_curso,
	c.id_aula,
	a.nro_aula,
	c.id_materia,
	m.descripcion As nom_materia,
	c.id_turno,
	t.descripcion As nom_turno,
	c.id_profesor,
	p.nombre + ' ' + p.apellido as nombre,
	c.cant_inscriptos,
	c.anho_lectivo 
	FROM Curso c
	INNER JOIN Aula a on a.id_aula=c.id_aula
	INNER JOIN Materia m on m.id_materia=c.id_materia
	INNER JOIN Turno t on t.id_turno=c.id_turno
	INNER JOIN Profesor pr on pr.id_profesor=c.id_profesor
	INNER JOIN Persona p on p.id_persona=pr.id_persona
	WHERE c.nro_curso=@nro_curso OR @nro_curso=0
	ORDER BY a.nro_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarCursoPorDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarCursoPorDepartamento
CREATE PROCEDURE [dbo].[SpConsultarCursoPorDepartamento]
	@id_dpto INT
AS
BEGIN 
	SELECT  
	c.nro_curso,
	c.id_aula,
	a.nro_aula,
	c.id_materia,
	m.descripcion As nom_materia,
	c.id_turno,
	t.descripcion As nom_turno,
	c.id_profesor,
	p.nombre + ' ' + p.apellido as nombre,
	c.cant_inscriptos,
	c.anho_lectivo 
	FROM Curso c
	INNER JOIN Aula a on a.id_aula=c.id_aula
	INNER JOIN Materia m on m.id_materia=c.id_materia
	INNER JOIN Turno t on t.id_turno=c.id_turno
	INNER JOIN Profesor pr on pr.id_profesor=c.id_profesor
	INNER JOIN Persona p on p.id_persona=pr.id_persona
	WHERE m.id_dpto=@id_dpto
	ORDER BY a.nro_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarDepartamento
CREATE PROCEDURE [dbo].[SpConsultarDepartamento]
	@id_dpto INT
AS
BEGIN 
	SELECT  
	d.id_dpto,
	d.nombre_dpto,
	d.id_facultad,
	f.nombre_facultad
	FROM Departamento d
	INNER JOIN Facultad f on f.id_facultad=d.id_facultad
	WHERE d.id_dpto=@id_dpto OR @id_dpto=0
	ORDER BY d.nombre_dpto
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarDetalleCurso
CREATE PROCEDURE [dbo].[SpConsultarDetalleCurso]
	@nro_curso INT
AS
BEGIN 
	SELECT  
	dc.nro_curso,
	m.descripcion As nom_materia,
	dc.id_dia,
	d.descripcion
	FROM DetalleCurso dc
	INNER JOIN Curso c on c.nro_curso=dc.nro_curso
	INNER JOIN Materia m on m.id_materia=c.id_materia
	INNER JOIN Dia d on d.id_dia=dc.id_dia
	WHERE dc.nro_curso=@nro_curso OR @nro_curso=0
	ORDER BY dc.id_dia
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SpConsultarDetalleReserva]
	@id_reserva INT
AS
BEGIN 
	SELECT  
	dr.id_reserva,
	dr.id_insumo,
	i.descripcion,
	dr.cantidad
	FROM DetalleReserva dr
	INNER JOIN Insumo i on i.id_insumo=dr.id_insumo
	WHERE dr.id_reserva=@id_reserva OR @id_reserva=0
	ORDER BY dr.id_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarDetalleRol
CREATE PROCEDURE [dbo].[SpConsultarDetalleRol]
	@id_rol varchar(5)
AS
BEGIN 
	SELECT  
	d.id_rol,
	r.nombre_rol,
	d.id_permiso,
	p.nombre_permiso
	FROM DetalleRol d
	INNER JOIN Rol r on r.id_rol=d.id_rol
	INNER JOIN Permiso p on p.id_permiso=d.id_permiso
	WHERE d.id_rol=@id_rol OR @id_rol='0'
	ORDER BY d.id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDia]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarDia
CREATE PROCEDURE [dbo].[SpConsultarDia]
	@id_dia INT
AS
BEGIN 
	SELECT * FROM Dia 
	WHERE id_dia=@id_dia OR @id_dia=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarEstadoReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarEstadoReserva
CREATE PROCEDURE [dbo].[SpConsultarEstadoReserva]
	@id_estado_reserva VARCHAR(1)
AS
BEGIN 
	SELECT * FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva OR @id_estado_reserva='0'
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarFacultad]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarFacultad
CREATE PROCEDURE [dbo].[SpConsultarFacultad]
	@id_facultad INT
AS
BEGIN 
	SELECT * FROM Facultad 
	WHERE id_facultad=@id_facultad OR @id_facultad=0
	ORDER BY nombre_facultad
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarInsumo
CREATE PROCEDURE [dbo].[SpConsultarInsumo]
	@id_insumo INT
AS
BEGIN 
	SELECT  
	i.id_insumo,
	i.descripcion,
	i.id_tip_insumo,
	t.descripcion AS nombre_tip_insumo
	FROM Insumo i
	INNER JOIN TipoInsumo t on t.id_tip_insumo=i.id_tip_insumo
	WHERE i.id_insumo=@id_insumo OR @id_insumo=0
	ORDER BY i.descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarMateria]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarMateria
CREATE PROCEDURE [dbo].[SpConsultarMateria]
	@id_materia INT
AS
BEGIN 
	SELECT  
	m.id_materia,
	m.descripcion,
	m.id_dpto,
	d.nombre_dpto
	FROM Materia m
	INNER JOIN Departamento d on d.id_dpto=m.id_dpto
	WHERE m.id_materia=@id_materia OR @id_materia=0
	ORDER BY m.descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarPermiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarPermiso
CREATE PROCEDURE [dbo].[SpConsultarPermiso]
	@id_permiso INT
AS
BEGIN 
	SELECT * FROM Permiso 
	WHERE id_permiso=@id_permiso OR @id_permiso=0
	ORDER BY nombre_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarPersona]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarPersona
CREATE PROCEDURE [dbo].[SpConsultarPersona]
	@id_persona INT
AS
BEGIN 
	SELECT  
	p.id_persona,
	p.documento,
	p.id_tipo_doc,
	t.descripcion,
	p.nombre,
	p.apellido,
	FORMAT(p.fecha_naci,'dd/MM/yyyy')  as fecha_naci,
	p.email,
	CASE p.profesorSN WHEN 'S' THEN 'Si' ELSE 'No' END as profesorSN
	FROM Persona p
	INNER JOIN TipoDocumento t on t.id_tipo_doc=p.id_tipo_doc
	WHERE p.id_persona=@id_persona OR @id_persona=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarPiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarPiso
CREATE PROCEDURE [dbo].[SpConsultarPiso]
	@id_piso INT
AS
BEGIN 
	SELECT * FROM Piso 
	WHERE id_piso=@id_piso OR @id_piso=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarProfesor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarProfesor
CREATE PROCEDURE [dbo].[SpConsultarProfesor]
	@id_profesor INT
AS
BEGIN 
	SELECT  
	pr.id_profesor,
	pr.id_persona,
	p.nombre + ' ' + p.apellido as nombre
	FROM Profesor pr
	INNER JOIN Persona p on p.id_persona=pr.id_persona
	WHERE pr.id_profesor=@id_profesor OR @id_profesor=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarProfesorCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--DROP PROCEDURE SpConsultarProfesorCurs
CREATE PROCEDURE [dbo].[SpConsultarProfesorCurso]
	@id_reserva INT
AS
BEGIN 
	SELECT email FROM Reserva r
	INNER JOIN Curso c on c.nro_curso = r.nro_curso
	INNER JOIN Profesor p on p.id_profesor = c.id_profesor
	INNER JOIN Persona per on per.id_persona = p.id_persona
	WHERE r.id_reserva = @id_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarReserva
CREATE PROCEDURE [dbo].[SpConsultarReserva]
	@id_reserva BIGINT
AS
BEGIN 
	SELECT  
	r.id_reserva,
	r.id_aula,
	r.nro_curso,
	r.observacion,
	FORMAT(r.fecha_reserva,'dd/MM/yyyy')  as fecha_reserva,
	CONVERT(varchar, r.hora_inicio, 108) as hora_inicio, 
	CONVERT(varchar, r.hora_fin, 108) as hora_fin,
	r.id_estado_reserva,
	r.id_aula,
	r.id_usuario
	FROM Reserva r
	--INNER JOIN Insumo i on i.id_insumo=dr.id_insumo
	WHERE r.id_reserva=@id_reserva OR @id_reserva=0
	ORDER BY r.fecha_solicitud DESC;
END

--EXEC SpConsultarReserva 1
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarReservaPendientes]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarReservaPendientes
CREATE PROCEDURE [dbo].[SpConsultarReservaPendientes]
	@id_departamento INT
AS
BEGIN 
	SELECT  
	r.id_reserva,
	r.id_aula,
	r.nro_curso,
	m.descripcion as nombre_materia,
	per.nombre,
	per.apellido,
	r.observacion,
	FORMAT(r.fecha_solicitud,'dd/MM/yyyy HH:mm')  as fecha_solicitud,
	FORMAT(r.fecha_reserva,'dd/MM/yyyy')  as fecha_reserva,
	CONVERT(VARCHAR(5), r.hora_inicio, 108)  as hora_inicio,
	CONVERT(VARCHAR(5), r.hora_fin, 108) as hora_fin,	
	r.id_estado_reserva,
	r.id_aula,
	r.id_usuario
	FROM Reserva r
	INNER JOIN Curso c on c.nro_curso=r.nro_curso
	INNER JOIN Materia m on m.id_materia = c.id_materia
	INNER JOIN Profesor pro on pro.id_profesor = c.id_profesor
	INNER JOIN Persona per on per.id_persona = pro.id_persona
	WHERE m.id_dpto = @id_departamento
	AND r.id_estado_reserva='P' -- Pendiente
	ORDER BY r.fecha_solicitud DESC
END
--el usuario tiene el departamento al cual pertenece

--SELECT * FROM Reserva ORDER BY fecha_solicitud DESC
--SELECT * FROM Curso
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarReservaPorDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarReservaPorDepartamento
CREATE PROCEDURE [dbo].[SpConsultarReservaPorDepartamento]
	@id_dpto INT,
	@id_estado_reserva VARCHAR(1)
AS
BEGIN 
	SELECT
	r.id_reserva,  
	FORMAT(r.fecha_solicitud,'dd/MM/yyyy HH:mm')  as fecha_solicitud,
	FORMAT(r.fecha_reserva,'dd/MM/yyyy')  as fecha_reserva,
	CONVERT(VARCHAR(5), r.hora_inicio, 108)  as hora_inicio,
	CONVERT(VARCHAR(5), r.hora_fin, 108) as hora_fin,
	CASE r.id_estado_reserva
		WHEN 'P' THEN 'Solicitado' 
		WHEN 'A' THEN 'Autorizado' 
		WHEN 'R' THEN 'Rechazado'
		WHEN 'X' THEN 'Anulado'
		END AS estado_reserva,
	a.nro_aula as aula,
	r.nro_curso,
	m.descripcion as nombre_materia
	FROM Reserva r
	INNER JOIN Aula a on a.id_aula=r.id_aula
	INNER JOIN Curso c on c.nro_curso=r.nro_curso
	INNER JOIN Materia m on m.id_materia = c.id_materia
	INNER JOIN Usuario u on u.id_usuario = r.id_usuario
	WHERE m.id_dpto = @id_dpto
	AND r.id_estado_reserva=@id_estado_reserva
	AND r.fecha_solicitud >= GETDATE()-15 --ultimos 15 dias
	ORDER BY r.fecha_solicitud ASC
END

--select * from Departamento
--select * from Reserva
--select * from Usuario
--EXEC [SpConsultarReservaPorDepartamento] 1,'P'  --pendientes

--EXEC [SpConsultarReservaPorDepartamento] 1,'A'  --aprobadas

--EXEC [SpConsultarReservaPorDepartamento] 1,'R'  --rechazadas

--EXEC [SpConsultarReservaPorDepartamento] 1,'X'  --anuladas
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarReservaPorUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarReservaPorUsuario
CREATE PROCEDURE [dbo].[SpConsultarReservaPorUsuario]
	@id_usuario INT,
	@id_estado_reserva VARCHAR(1)
AS
BEGIN 
	SELECT
	r.id_reserva,  
	FORMAT(r.fecha_solicitud,'dd/MM/yyyy HH:mm')  as fecha_solicitud,
	FORMAT(r.fecha_reserva,'dd/MM/yyyy')  as fecha_reserva,
	CONVERT(VARCHAR(5), r.hora_inicio, 108)  as hora_inicio,
	CONVERT(VARCHAR(5), r.hora_fin, 108) as hora_fin,
	CASE r.id_estado_reserva
		WHEN 'P' THEN 'Solicitado' 
		WHEN 'A' THEN 'Autorizado' 
		WHEN 'R' THEN 'Rechazado'
		WHEN 'X' THEN 'Anulado'
		END AS estado_reserva,
	a.nro_aula as aula,
	r.nro_curso,
	m.descripcion as nombre_materia
	FROM Reserva r
	INNER JOIN Aula a on a.id_aula=r.id_aula
	INNER JOIN Curso c on c.nro_curso=r.nro_curso
	INNER JOIN Materia m on m.id_materia = c.id_materia
	WHERE r.id_usuario = @id_usuario
	AND r.id_estado_reserva=@id_estado_reserva
	AND r.fecha_solicitud >= GETDATE()-15 --ultimos 15 dias
	ORDER BY r.fecha_solicitud ASC
END


--EXEC SpConsultarReservaPorUsuario 6,'P'  --pendientes

--EXEC SpConsultarReservaPorUsuario 6,'A'  --aprobadas

--EXEC SpConsultarReservaPorUsuario 6,'R'  --rechazadas

--EXEC SpConsultarReservaPorUsuario 6,'X'  --anuladas
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarRol
CREATE PROCEDURE [dbo].[SpConsultarRol]
	@id_rol varchar(5)
AS
BEGIN 
	SELECT * FROM Rol 
	WHERE id_rol=@id_rol OR @id_rol='0'
	ORDER BY nombre_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarSupervisor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarSupervisor
CREATE PROCEDURE [dbo].[SpConsultarSupervisor]
	@id_dpto INT
AS
BEGIN 
	SELECT email FROM Persona p
	INNER JOIN Usuario u on u.id_persona=p.id_persona 
	WHERE U.id_rol = 'SUPER'
	AND U.id_dpto = 1;
END

--EXEC SpConsultarSupervisor 1

SELECT * FROM Profesor
SELECT * FROM Persona
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarTipoAula
CREATE PROCEDURE [dbo].[SpConsultarTipoAula]
	@id_tipo_aula INT
AS
BEGIN 
	SELECT * FROM TipoAula 
	WHERE id_tipo_aula=@id_tipo_aula OR @id_tipo_aula=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoDocumento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarTipoDocumento
CREATE PROCEDURE [dbo].[SpConsultarTipoDocumento]
	@id_tipo_doc INT
AS
BEGIN 
	SELECT * FROM TipoDocumento 
	WHERE id_tipo_doc=@id_tipo_doc OR @id_tipo_doc=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarTipoInsumo
CREATE PROCEDURE [dbo].[SpConsultarTipoInsumo]
	@id_tip_insumo INT
AS
BEGIN 
	SELECT * FROM TipoInsumo 
	WHERE id_tip_insumo=@id_tip_insumo OR @id_tip_insumo=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarTurno]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarTurno
CREATE PROCEDURE [dbo].[SpConsultarTurno]
	@id_turno INT
AS
BEGIN 
	SELECT * FROM Turno 
	WHERE id_turno=@id_turno OR @id_turno=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarUsuario
CREATE PROCEDURE [dbo].[SpConsultarUsuario]
	@id_usuario INT
AS
BEGIN 
	SELECT  
	u.id_usuario,
	u.id_rol,
	r.nombre_rol,
	u.id_persona,
	p.nombre,
	u.user_name,
	u.id_dpto,
	d.nombre_dpto
	FROM Usuario u
	INNER JOIN Rol r on r.id_rol=u.id_rol
	INNER JOIN Persona p on p.id_persona=u.id_persona
	INNER JOIN Departamento d on d.id_dpto=u.id_dpto
	WHERE u.id_usuario=@id_usuario OR @id_usuario=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarAula
CREATE PROCEDURE [dbo].[SpEliminarAula]
	@id_aula INT
AS
BEGIN 
	DELETE FROM Aula 
	WHERE @id_aula=id_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarCurso
CREATE PROCEDURE [dbo].[SpEliminarCurso]
	@nro_curso INT
AS
BEGIN 
	DELETE FROM Curso 
	WHERE nro_curso=@nro_curso
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDepartamento
CREATE PROCEDURE [dbo].[SpEliminarDepartamento]
	@id_dpto INT
AS
BEGIN 
	DELETE FROM Departamento 
	WHERE id_dpto=@id_dpto
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDetalleCurso
CREATE PROCEDURE [dbo].[SpEliminarDetalleCurso]
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	DELETE FROM DetalleCurso 
	WHERE nro_curso=@nro_curso AND id_dia=@id_dia
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDetalleReserva
CREATE PROCEDURE [dbo].[SpEliminarDetalleReserva]
    @id_reserva INT,
	@id_insumo INT
AS
BEGIN 
	DELETE FROM DetalleReserva 
	WHERE id_reserva=@id_reserva AND id_insumo=@id_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDetalleRol
CREATE PROCEDURE [dbo].[SpEliminarDetalleRol]
	@id_rol varchar(5),
	@id_permiso INT
AS
BEGIN 
	DELETE FROM DetalleRol 
	WHERE id_rol=@id_rol AND id_permiso=@id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDia]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDia
CREATE PROCEDURE [dbo].[SpEliminarDia]
	@id_dia INT
AS
BEGIN 
	DELETE FROM Dia 
	WHERE id_dia=@id_dia
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarEstadoReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarEstadoReserva
CREATE PROCEDURE [dbo].[SpEliminarEstadoReserva]
	@id_estado_reserva VARCHAR(1)
AS
BEGIN 
	DELETE FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarFacultad]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarFacultad
CREATE PROCEDURE [dbo].[SpEliminarFacultad]
	@id_facultad INT
AS
BEGIN 
	DELETE FROM Facultad 
	WHERE id_facultad=@id_facultad
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarInsumo
CREATE PROCEDURE [dbo].[SpEliminarInsumo]
	@id_insumo INT
AS
BEGIN 
	DELETE FROM Insumo 
	WHERE id_insumo=@id_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarMateria]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarMateria
CREATE PROCEDURE [dbo].[SpEliminarMateria]
	@id_materia INT
AS
BEGIN 
	DELETE FROM Materia 
	WHERE id_materia=@id_materia
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarPermiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarPermiso
CREATE PROCEDURE [dbo].[SpEliminarPermiso]
	@id_permiso INT
AS
BEGIN 
	DELETE FROM Permiso 
	WHERE id_permiso=@id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarPersona]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarPersona
CREATE PROCEDURE [dbo].[SpEliminarPersona]
	@id_persona INT
AS
BEGIN 
	DELETE FROM Persona 
	WHERE id_persona=@id_persona
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarPiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarPiso
CREATE PROCEDURE [dbo].[SpEliminarPiso]
	@id_piso INT
AS
BEGIN 
	DELETE FROM Piso 
	WHERE id_piso=@id_piso
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarProfesor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarProfesor
CREATE PROCEDURE [dbo].[SpEliminarProfesor]
	@id_persona INT
AS
BEGIN 
	DELETE FROM Profesor 
	WHERE id_persona=@id_persona
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarReserva
CREATE PROCEDURE [dbo].[SpEliminarReserva]
	@id_reserva BIGINT
AS
BEGIN 
	DELETE FROM Reserva 
	WHERE id_reserva=@id_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarRol
CREATE PROCEDURE [dbo].[SpEliminarRol]
	@id_rol varchar(5)
AS
BEGIN 
	DELETE FROM Rol 
	WHERE id_rol=@id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarTipoAula
CREATE PROCEDURE [dbo].[SpEliminarTipoAula]
	@id_tipo_aula INT
AS
BEGIN 
	DELETE FROM TipoAula 
	WHERE id_tipo_aula=@id_tipo_aula
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoDocumento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarTipoDocumento
CREATE PROCEDURE [dbo].[SpEliminarTipoDocumento]
	@id_tipo_doc INT
AS
BEGIN 
	DELETE FROM TipoDocumento 
	WHERE id_tipo_doc=@id_tipo_doc
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarTipoInsumo
CREATE PROCEDURE [dbo].[SpEliminarTipoInsumo] 
	@id_tip_insumo INT
AS
BEGIN 
	DELETE FROM TipoInsumo 
	WHERE id_tip_insumo=@id_tip_insumo
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTurno]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarTurno
CREATE PROCEDURE [dbo].[SpEliminarTurno]
	@id_turno INT
AS
BEGIN 
	DELETE FROM Turno 
	WHERE id_turno=@id_turno
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarUsuario
CREATE PROCEDURE [dbo].[SpEliminarUsuario]
	@id_usuario INT
AS
BEGIN 
	DELETE FROM Usuario 
	WHERE id_usuario=@id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Aula
--DROP PROCEDURE SpInsertarAula
CREATE PROCEDURE [dbo].[SpInsertarAula]
	@nro_aula VARCHAR(50),
	@id_tipo_aula INT,
	@id_piso INT,
	@posee_proyector CHAR(1),
	@capacidad INT
AS
BEGIN 
	INSERT INTO Aula VALUES(@nro_aula,@id_tipo_aula,@id_piso,@posee_proyector,@capacidad)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Curso
--DROP PROCEDURE SpInsertarCurso
CREATE PROCEDURE [dbo].[SpInsertarCurso]
	@id_aula INT,
	@id_materia INT,
	@id_turno INT,
	@id_profesor INT,
	@cant_inscriptos INT,
	@anho_lectivo INT
AS
BEGIN 
	INSERT INTO Curso VALUES(@id_aula,@id_materia,@id_turno,@id_profesor,@cant_inscriptos,@anho_lectivo)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDepartamento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Departamento
--DROP PROCEDURE SpInsertarDepartamento
CREATE PROCEDURE [dbo].[SpInsertarDepartamento]
    @nombre_dpto VARCHAR(250),
	@id_facultad INT
AS
BEGIN 
	INSERT INTO Departamento VALUES(@nombre_dpto,@id_facultad)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleCurso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DetalleCurso
--DROP PROCEDURE SpInsertarDetalleCurso
CREATE PROCEDURE [dbo].[SpInsertarDetalleCurso]
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	INSERT INTO DetalleCurso VALUES(@nro_curso,@id_dia)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DetalleReserva
--DROP PROCEDURE SpInsertarDetalleReserva
CREATE PROCEDURE [dbo].[SpInsertarDetalleReserva]
    @id_reserva INT,
	@id_insumo INT,
	@cantidad INT
AS
BEGIN 
	INSERT INTO DetalleReserva VALUES(@id_reserva,@id_insumo,@cantidad)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DetalleRol
--DROP PROCEDURE SpInsertarDetalleRol
CREATE PROCEDURE [dbo].[SpInsertarDetalleRol]
    @id_rol varchar(5),
	@id_permiso INT
AS
BEGIN 
	INSERT INTO DetalleRol VALUES(@id_rol,@id_permiso)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDia]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Dia
--DROP PROCEDURE SpInsertarDia
CREATE PROCEDURE [dbo].[SpInsertarDia]
    @descripcion VARCHAR(50),
	@cod_dia CHAR(1)
AS
BEGIN 
	INSERT INTO Dia VALUES(@descripcion,@cod_dia)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarEstadoReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------PROCEDIMIENTO ALMACENADO-----------
--EstadoReserva
--DROP PROCEDURE SpInsertarEstadoReserva
CREATE PROCEDURE [dbo].[SpInsertarEstadoReserva]
    @id_estado_reserva VARCHAR(1),
	@descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO EstadoReserva VALUES(@id_estado_reserva,@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarFacultad]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Facultad
--DROP PROCEDURE SpInsertarFacultad
CREATE PROCEDURE [dbo].[SpInsertarFacultad]
    @nombre_facultad VARCHAR(250)
AS
BEGIN 
	INSERT INTO Facultad VALUES(@nombre_facultad)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Insumo
--DROP PROCEDURE SpInsertarInsumo
CREATE PROCEDURE [dbo].[SpInsertarInsumo]
    @descripcion VARCHAR(50),
	@id_tip_insumo INT
AS
BEGIN 
	INSERT INTO Insumo VALUES(@descripcion,@id_tip_insumo)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarMateria]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Materia
--DROP PROCEDURE SpInsertarMateria
CREATE PROCEDURE [dbo].[SpInsertarMateria]
    @descripcion VARCHAR(250),
	@id_dpto INT
AS
BEGIN 
	INSERT INTO Materia VALUES(@descripcion,@id_dpto)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarPermiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Permiso
--DROP PROCEDURE SpInsertarPermiso
CREATE PROCEDURE [dbo].[SpInsertarPermiso]
    @nombre_permiso VARCHAR(250)
AS
BEGIN 
	INSERT INTO Permiso VALUES(@nombre_permiso)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarPersona]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Persona
--DROP PROCEDURE SpInsertarPersona
CREATE PROCEDURE [dbo].[SpInsertarPersona]
	@documento VARCHAR(50),
	@id_tipo_doc INT,
	@nombre VARCHAR(250),
	@apellido VARCHAR(250),
	@fecha_naci DATE,
	@email VARCHAR(250),
	@profesorSN VARCHAR(2),
	@id_persona INT OUTPUT
AS
BEGIN 
	INSERT INTO Persona VALUES(@documento,@id_tipo_doc,@nombre,@apellido,@fecha_naci,@email,@profesorSN);
	SELECT @id_persona=IDENT_CURRENT('Persona')
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarPiso]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Piso
--DROP PROCEDURE SpInsertarPiso
CREATE PROCEDURE [dbo].[SpInsertarPiso]
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO Piso VALUES(@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarProfesor]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Profesor
--DROP PROCEDURE SpInsertarProfesor
CREATE PROCEDURE [dbo].[SpInsertarProfesor]
	@id_persona INT
AS
BEGIN 
	INSERT INTO Profesor VALUES(@id_persona)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarReserva]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Reserva
--DROP PROCEDURE SpInsertarReserva
CREATE PROCEDURE [dbo].[SpInsertarReserva]
	@fecha_reserva DATE,
	@id_aula INT,
	@nro_curso INT,
	@observacion VARCHAR(650),
	@hora_inicio TIME,
	@hora_fin TIME,
	@id_usuario INT,
	@id_reserva INT OUTPUT
AS
BEGIN 
	INSERT INTO 
		Reserva 
	VALUES(@fecha_reserva,
		@id_aula,
		@nro_curso,
		@observacion,
		CONVERT(TIME, @hora_inicio),
		CONVERT(TIME, @hora_fin),
		'P', --P solicitado
		@id_usuario,
		GETDATE(),
		NULL,
		NULL,
		NULL);

	SELECT @id_reserva=IDENT_CURRENT('Reserva')

END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarRol]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Rol
--DROP PROCEDURE SpInsertarRol
CREATE PROCEDURE [dbo].[SpInsertarRol]
	@id_rol VARCHAR(5),
    @nombre_rol VARCHAR(250)
AS
BEGIN 
	INSERT INTO Rol VALUES(@id_rol,@nombre_rol)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoAula]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--TipoAula
--DROP PROCEDURE SpInsertarTipoAula
CREATE PROCEDURE [dbo].[SpInsertarTipoAula]
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoAula VALUES(@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoDocumento]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--TipoDocumento
--DROP PROCEDURE SpInsertarTipoDocumento
CREATE PROCEDURE [dbo].[SpInsertarTipoDocumento]
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoDocumento VALUES(@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoInsumo]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--TipoInsumo
--DROP PROCEDURE SpInsertarTipoInsumo
CREATE PROCEDURE [dbo].[SpInsertarTipoInsumo]
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoInsumo VALUES(@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTurno]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Turno
--DROP PROCEDURE SpInsertarTurno
CREATE PROCEDURE [dbo].[SpInsertarTurno]
    @descripcion VARCHAR(50),
	@hora_inicio TIME,
	@hora_fin TIME
AS
BEGIN 
	INSERT INTO Turno VALUES(@descripcion,@hora_inicio,@hora_fin)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Usuario
--DROP PROCEDURE SpInsertarUsuario
CREATE PROCEDURE [dbo].[SpInsertarUsuario]
	@id_rol VARCHAR(5),
	@id_persona INT,
	@user_name VARCHAR(250),
	@password  VARCHAR(250),
	@id_dpto INT
AS
BEGIN 
	INSERT INTO Usuario VALUES(@id_rol,@id_persona,@user_name, convert(varbinary, @password), @id_dpto)
END
GO
/****** Object:  StoredProcedure [dbo].[SpLoginUsuario]    Script Date: 8/1/2018 2:04:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpLoginUsuario
CREATE PROCEDURE [dbo].[SpLoginUsuario]
	@user_name VARCHAR(250),
	@password  VARCHAR(250)
AS
BEGIN 

	SELECT  
	u.id_usuario,
	u.id_rol,
	r.nombre_rol,
	u.id_persona,
	p.nombre + ' ' + p.apellido as nombre,
	u.user_name,
	u.id_dpto,
	d.nombre_dpto
	FROM Usuario u
	INNER JOIN Rol r on r.id_rol=u.id_rol
	INNER JOIN Persona p on p.id_persona=u.id_persona
	INNER JOIN Departamento d on d.id_dpto=u.id_dpto
	WHERE u.user_name=@user_name 
	AND u.password = convert(varbinary, @password);
	
END
GO
USE [master]
GO
ALTER DATABASE [ReservaDeAula] SET  READ_WRITE 
GO
