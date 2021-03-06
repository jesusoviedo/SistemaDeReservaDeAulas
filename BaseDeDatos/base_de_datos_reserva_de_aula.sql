USE [ReservaDeAula]
GO
/****** Object:  Table [dbo].[Aula]    Script Date: 7/26/2018 9:07:57 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Aula_nro_aula] UNIQUE NONCLUSTERED 
(
	[nro_aula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 7/26/2018 9:07:57 AM ******/
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
/****** Object:  Table [dbo].[Departamento]    Script Date: 7/26/2018 9:07:57 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Departamento_nombre_dpto] UNIQUE NONCLUSTERED 
(
	[nombre_dpto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleCurso]    Script Date: 7/26/2018 9:07:57 AM ******/
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
/****** Object:  Table [dbo].[DetalleReserva]    Script Date: 7/26/2018 9:07:57 AM ******/
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
/****** Object:  Table [dbo].[DetalleRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleRol](
	[id_rol] [int] NOT NULL,
	[id_permiso] [int] NOT NULL,
 CONSTRAINT [PK_DetalleRol_id_rol_id_permiso] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC,
	[id_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Dia_cod_dia] UNIQUE NONCLUSTERED 
(
	[cod_dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Dia_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadoReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadoReserva](
	[id_estado_reserva] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_EstadoReserva_id_estado_reserva] PRIMARY KEY CLUSTERED 
(
	[id_estado_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_EstadoReserva_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facultad]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Facultad_nombre_facultad] UNIQUE NONCLUSTERED 
(
	[nombre_facultad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Insumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Insumo_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Materia_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Permiso_nombre_permiso] UNIQUE NONCLUSTERED 
(
	[nombre_permiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 7/26/2018 9:07:58 AM ******/
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
 CONSTRAINT [PK_Persona_id_persona] PRIMARY KEY CLUSTERED 
(
	[id_persona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Persona_documento_id_tipo_doc] UNIQUE NONCLUSTERED 
(
	[documento] ASC,
	[id_tipo_doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Piso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Piso_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesor]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  Table [dbo].[Reserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	[id_estado_reserva] [int] NOT NULL,
	[id_usuario] [int] NOT NULL,
 CONSTRAINT [PK_Reserva_id_reserva] PRIMARY KEY CLUSTERED 
(
	[id_reserva] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[nombre_rol] [varchar](250) NOT NULL,
 CONSTRAINT [PK_Rol_id_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Rol_nombre_rol] UNIQUE NONCLUSTERED 
(
	[nombre_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_TipoAula_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoDocumento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_TipoDocumento_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_TipoInsumo_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 7/26/2018 9:07:58 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UC_Turno_descripcion] UNIQUE NONCLUSTERED 
(
	[descripcion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[id_rol] [int] NOT NULL,
	[id_persona] [int] NOT NULL,
	[user_name] [varchar](250) NOT NULL,
	[password] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Usuario_id_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[SpActualizarAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarDepartamento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarDetalleRol]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarDia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarEstadoReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarEstadoReserva
CREATE PROCEDURE [dbo].[SpActualizarEstadoReserva]
	@descripcion VARCHAR(50),
	@id_estado_reserva INT
AS
BEGIN 
	UPDATE EstadoReserva  
	SET descripcion=@descripcion
	WHERE id_estado_reserva=@id_estado_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarFacultad]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarMateria]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarPermiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarPersona]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarPiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarProfesor]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	@id_estado_reserva INT,
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
	id_estado_reserva=@id_estado_reserva, 
	id_usuario=@id_usuario
	WHERE id_reserva=@id_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarRol
CREATE PROCEDURE [dbo].[SpActualizarRol]
	@nombre_rol VARCHAR(250),
	@id_rol INT
AS
BEGIN 
	UPDATE Rol  
	SET nombre_rol=@nombre_rol
	WHERE id_rol=@id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoDocumento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarTipoInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarTurno]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpActualizarUsuario]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpActualizarUsuario
CREATE PROCEDURE [dbo].[SpActualizarUsuario]
	@id_rol INT,
	@id_persona INT,
	@user_name VARCHAR(250),
	--@password VARBINARY,
	@id_usuario INT
AS
BEGIN 
	UPDATE Usuario  
	SET id_rol=@id_rol, id_persona=@id_persona, user_name=@user_name--, password=@password
	WHERE id_usuario=@id_usuario
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	p.nombre,
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
/****** Object:  StoredProcedure [dbo].[SpConsultarDepartamento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarDetalleRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarDetalleRol
CREATE PROCEDURE [dbo].[SpConsultarDetalleRol]
	@id_rol INT
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
	WHERE d.id_rol=@id_rol OR @id_rol=0
	ORDER BY d.id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarDia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarEstadoReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarEstadoReserva
CREATE PROCEDURE [dbo].[SpConsultarEstadoReserva]
	@id_estado_reserva INT
AS
BEGIN 
	SELECT * FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva OR @id_estado_reserva=0
	ORDER BY descripcion
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarFacultad]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarMateria]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarPermiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarPersona]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	p.email
	FROM Persona p
	INNER JOIN TipoDocumento t on t.id_tipo_doc=p.id_tipo_doc
	WHERE p.id_persona=@id_persona OR @id_persona=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarPiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarProfesor]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	p.nombre
	FROM Profesor pr
	INNER JOIN Persona p on p.id_persona=pr.id_persona
	WHERE pr.id_profesor=@id_profesor OR @id_profesor=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	r.hora_inicio,
	r.hora_fin,
	r.id_estado_reserva,
	r.id_aula
	FROM Reserva r
	--INNER JOIN Insumo i on i.id_insumo=dr.id_insumo
	WHERE r.id_reserva=@id_reserva OR @id_reserva=0
	ORDER BY r.id_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpConsultarRol
CREATE PROCEDURE [dbo].[SpConsultarRol]
	@id_rol INT
AS
BEGIN 
	SELECT * FROM Rol 
	WHERE id_rol=@id_rol OR @id_rol=0
	ORDER BY nombre_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoDocumento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarTipoInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarTurno]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpConsultarUsuario]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	u.user_name--,
	--u.password
	FROM Usuario u
	INNER JOIN Rol r on r.id_rol=u.id_rol
	INNER JOIN Persona p on p.id_persona=u.id_persona
	WHERE u.id_usuario=@id_usuario OR @id_usuario=0
	ORDER BY p.nombre
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarDepartamento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarDetalleRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarDetalleRol
CREATE PROCEDURE [dbo].[SpEliminarDetalleRol]
	@id_rol INT,
	@id_permiso INT
AS
BEGIN 
	DELETE FROM DetalleRol 
	WHERE id_rol=@id_rol AND id_permiso=@id_permiso
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarDia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarEstadoReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarEstadoReserva
CREATE PROCEDURE [dbo].[SpEliminarEstadoReserva]
	@id_estado_reserva INT
AS
BEGIN 
	DELETE FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarFacultad]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarMateria]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarPermiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarPersona]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarPiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarProfesor]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarProfesor
CREATE PROCEDURE [dbo].[SpEliminarProfesor]
	@id_profesor INT
AS
BEGIN 
	DELETE FROM Profesor 
	WHERE id_profesor=@id_profesor
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DROP PROCEDURE SpEliminarRol
CREATE PROCEDURE [dbo].[SpEliminarRol]
	@id_rol INT
AS
BEGIN 
	DELETE FROM Rol 
	WHERE id_rol=@id_rol
END
GO
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoDocumento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarTipoInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarTurno]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpEliminarUsuario]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarDepartamento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleCurso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarDetalleRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--DetalleRol
--DROP PROCEDURE SpInsertarDetalleRol
CREATE PROCEDURE [dbo].[SpInsertarDetalleRol]
    @id_rol INT,
	@id_permiso INT
AS
BEGIN 
	INSERT INTO DetalleRol VALUES(@id_rol,@id_permiso)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarDia]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarEstadoReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-----------PROCEDIMIENTO ALMACENADO-----------
--EstadoReserva
--DROP PROCEDURE SpInsertarEstadoReserva
CREATE PROCEDURE [dbo].[SpInsertarEstadoReserva]
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO EstadoReserva VALUES(@descripcion)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarFacultad]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarMateria]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarPermiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarPersona]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	@email VARCHAR(250)
AS
BEGIN 
	INSERT INTO Persona VALUES(@documento,@id_tipo_doc,@nombre,@apellido,@fecha_naci,@email)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarPiso]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarProfesor]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarReserva]    Script Date: 7/26/2018 9:07:58 AM ******/
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
	@id_estado_reserva INT,
	@id_usuario INT
AS
BEGIN 
	INSERT INTO Reserva VALUES(@fecha_reserva,@id_aula,@nro_curso,@observacion,@hora_inicio,@hora_fin,@id_estado_reserva,@id_usuario)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarRol]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Rol
--DROP PROCEDURE SpInsertarRol
CREATE PROCEDURE [dbo].[SpInsertarRol]
    @nombre_rol VARCHAR(250)
AS
BEGIN 
	INSERT INTO Rol VALUES(@nombre_rol)
END
GO
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoAula]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoDocumento]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarTipoInsumo]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarTurno]    Script Date: 7/26/2018 9:07:58 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SpInsertarUsuario]    Script Date: 7/26/2018 9:07:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Usuario
--DROP PROCEDURE SpInsertarUsuario
CREATE PROCEDURE [dbo].[SpInsertarUsuario]
	@id_rol INT,
	@id_persona INT,
	@user_name VARCHAR(250),
	@password  VARCHAR(250)
AS
BEGIN 
	INSERT INTO Usuario VALUES(@id_rol,@id_persona,@user_name, convert(varbinary, @password))
END
GO
