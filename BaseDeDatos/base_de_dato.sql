USE master
GO

DROP DATABASE ReservaDeAula;
GO

CREATE DATABASE ReservaDeAula;
GO

USE ReservaDeAula
GO

-----TABLAS-----
CREATE TABLE TipoInsumo
(
	id_tip_insumo INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TipoInsumo_id_tip_insumo PRIMARY KEY (id_tip_insumo),
	CONSTRAINT UC_TipoInsumo_descripcion UNIQUE (descripcion)
)
GO

CREATE TABLE EstadoReserva
(
	id_estado_reserva INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NULL,
	CONSTRAINT PK_EstadoReserva_id_estado_reserva PRIMARY KEY (id_estado_reserva),
	CONSTRAINT UC_EstadoReserva_descripcion UNIQUE (descripcion)
)
GO

CREATE TABLE Piso
(
	id_piso INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Piso_id_piso PRIMARY KEY (id_piso),
	CONSTRAINT UC_Piso_descripcion UNIQUE (descripcion)
)
GO

CREATE TABLE Facultad
(
	id_facultad INT IDENTITY(1,1) NOT NULL,
	nombre_facultad VARCHAR(250) NOT NULL,
	CONSTRAINT PK_Facultad_id_facultad PRIMARY KEY (id_facultad),
	CONSTRAINT UC_Facultad_nombre_facultad UNIQUE (nombre_facultad)
)
GO

CREATE TABLE Permiso
(
	id_permiso INT IDENTITY(1,1) NOT NULL,
	nombre_permiso VARCHAR(250) NOT NULL,
	CONSTRAINT PK_Permiso_id_permiso PRIMARY KEY (id_permiso),
	CONSTRAINT UC_Permiso_nombre_permiso UNIQUE (nombre_permiso)
)
GO

CREATE TABLE TipoAula
(
	id_tipo_aula INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TipoAula_id_tipo_aula PRIMARY KEY (id_tipo_aula),
	CONSTRAINT UC_TipoAula_descripcion UNIQUE (descripcion)
)
GO

CREATE TABLE Rol
(
	id_rol INT IDENTITY(1,1) NOT NULL,
	nombre_rol VARCHAR(250) NOT NULL,
	CONSTRAINT PK_Rol_id_rol PRIMARY KEY (id_rol),
	CONSTRAINT UC_Rol_nombre_rol UNIQUE (nombre_rol)
) 
GO

CREATE TABLE TipoDocumento
(
	id_tipo_doc INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	CONSTRAINT PK_TipoDocumento_id_tipo_doc PRIMARY KEY (id_tipo_doc),
	CONSTRAINT UC_TipoDocumento_descripcion UNIQUE (descripcion)
) 
GO

CREATE TABLE Dia
(
	id_dia INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	cod_dia char(1) NOT NULL,
	CONSTRAINT PK_Dia_id_dia PRIMARY KEY (id_dia),
	CONSTRAINT UC_Dia_descripcion UNIQUE (descripcion),
	CONSTRAINT UC_Dia_cod_dia UNIQUE (cod_dia)
) 
GO

CREATE TABLE Turno
(
	id_turno INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	hora_inicio TIME NOT NULL,
	hora_fin TIME NOT NULL,
	CONSTRAINT PK_Turno_id_turno PRIMARY KEY (id_turno),
	CONSTRAINT UC_Turno_descripcion UNIQUE (descripcion)
)
GO

CREATE TABLE DetalleRol
(
	id_rol INT NOT NULL,
	id_permiso INT NOT NULL,
	CONSTRAINT PK_DetalleRol_id_rol_id_permiso PRIMARY KEY (id_rol,id_permiso),
	CONSTRAINT FK_DetalleRol_id_rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
	CONSTRAINT FK_DetalleRol_id_permiso FOREIGN KEY (id_permiso) REFERENCES Permiso(id_permiso)
) 
GO

CREATE TABLE Departamento
(
	id_dpto INT IDENTITY(1,1) NOT NULL,
	nombre_dpto VARCHAR(250) NOT NULL,
	id_facultad INT NOT NULL,
	CONSTRAINT PK_Departamento_id_dpto PRIMARY KEY (id_dpto),
	CONSTRAINT UC_Departamento_nombre_dpto UNIQUE (nombre_dpto),
	CONSTRAINT FK_Departamento_id_facultad FOREIGN KEY (id_facultad) REFERENCES Facultad(id_facultad)
) 
GO

CREATE TABLE Materia
(
	id_materia INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(250) NOT NULL,
	id_dpto INT NOT NULL,
	CONSTRAINT PK_Materia_id_materia PRIMARY KEY (id_materia),
	CONSTRAINT UC_Materia_descripcion UNIQUE (descripcion),
	CONSTRAINT FK_Materia_id_departamento FOREIGN KEY (id_dpto) REFERENCES Departamento(id_dpto)
) 
GO

CREATE TABLE Insumo
(
	id_insumo INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	id_tip_insumo INT NOT NULL,
	CONSTRAINT PK_Insumo_id_insumo PRIMARY KEY (id_insumo),
	CONSTRAINT UC_Insumo_descripcion UNIQUE (descripcion),
	CONSTRAINT FK_Insumo_id_tip_insumo FOREIGN KEY (id_tip_insumo) REFERENCES TipoInsumo(id_tip_insumo)
) 
GO

CREATE TABLE Persona
(
	id_persona INT IDENTITY(1,1) NOT NULL,
	documento VARCHAR(50) NOT NULL,
	id_tipo_doc INT NOT NULL,
	nombre VARCHAR(250) NOT NULL,
	apellido VARCHAR(250) NOT NULL,
	fecha_naci DATE NOT NULL,
	email VARCHAR(250) NOT NULL,
	CONSTRAINT PK_Persona_id_persona PRIMARY KEY (id_persona),
	CONSTRAINT UC_Persona_documento_id_tipo_doc UNIQUE (documento,id_tipo_doc),
	CONSTRAINT FK_Persona_id_tipo_doc FOREIGN KEY (id_tipo_doc) REFERENCES TipoDocumento(id_tipo_doc)
) 
GO

CREATE TABLE Usuario
(
	id_usuario INT IDENTITY(1,1) NOT NULL,
	id_rol INT NOT NULL,
	id_persona INT NOT NULL,
	user_name VARCHAR(250) NOT NULL,
	password VARBINARY NOT NULL,
	CONSTRAINT PK_Usuario_id_usuario PRIMARY KEY (id_usuario),
	CONSTRAINT FK_Usuario_id_rol FOREIGN KEY (id_rol) REFERENCES Rol(id_rol),
	CONSTRAINT FK_Usuario_id_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
)
GO

CREATE TABLE Profesor
(
	id_profesor INT IDENTITY(1,1) NOT NULL,
	id_persona INT NOT NULL,
	CONSTRAINT PK_Profesor_id_profesor PRIMARY KEY (id_profesor),
	CONSTRAINT FK_Profesor_id_persona FOREIGN KEY (id_persona) REFERENCES Persona(id_persona)
) 
GO

CREATE TABLE Aula
(
	id_aula INT IDENTITY(1,1) NOT NULL,
	nro_aula VARCHAR(50) NOT NULL,
	id_tipo_aula INT NOT NULL,
	id_piso INT NOT NULL,
	posee_proyector CHAR(1) NOT NULL,
	capacidad INT NOT NULL,
	CONSTRAINT PK_Aula_id_aula PRIMARY KEY (id_aula),
	CONSTRAINT UC_Aula_nro_aula UNIQUE (nro_aula),
	CONSTRAINT FK_Aula_id_tipo_aula FOREIGN KEY (id_tipo_aula) REFERENCES TipoAula(id_tipo_aula),
	CONSTRAINT FK_Aula_id_piso FOREIGN KEY (id_piso) REFERENCES Piso(id_piso)
)
GO

CREATE TABLE Curso
(
	nro_curso INT IDENTITY(1,1) NOT NULL,
	id_aula INT NOT NULL,
	id_materia INT NOT NULL,
	id_turno INT NOT NULL,
	id_profesor INT NOT NULL,
	cant_inscriptos INT NOT NULL,
	anho_lectivo INT NOT NULL,
	CONSTRAINT PK_Curso_nro_curso PRIMARY KEY (nro_curso),
	CONSTRAINT FK_Curso_id_aula FOREIGN KEY (id_aula) REFERENCES Aula(id_aula),
	CONSTRAINT FK_Curso_id_materia FOREIGN KEY (id_materia) REFERENCES Materia(id_materia),
	CONSTRAINT FK_Curso_id_turno FOREIGN KEY (id_turno) REFERENCES Turno(id_turno),
	CONSTRAINT FK_Curso_id_profesor FOREIGN KEY (id_profesor) REFERENCES Profesor(id_profesor)
) 
GO

CREATE TABLE DetalleCurso
(
	nro_curso INT NOT NULL,
	id_dia INT NOT NULL,
    CONSTRAINT PK_DetalleCurso_nro_curso_id_dia PRIMARY KEY (nro_curso,id_dia),
	CONSTRAINT FK_DetalleCurso_nro_curso FOREIGN KEY (nro_curso) REFERENCES Curso(nro_curso),
	CONSTRAINT FK_DetalleCurso_id_dia FOREIGN KEY (id_dia) REFERENCES Dia(id_dia)
)
GO

CREATE TABLE Reserva
(
	id_reserva BIGINT IDENTITY(1,1) NOT NULL,
	fecha_reserva DATE NOT NULL,
	id_aula INT NOT NULL,
	nro_curso INT NOT NULL,
	observacion VARCHAR(650) NOT NULL,
	hora_inicio TIME NOT NULL,
	hora_fin TIME NOT NULL,
	id_estado_reserva INT NOT NULL,
	id_usuario INT NOT NULL,
 	CONSTRAINT PK_Reserva_id_reserva PRIMARY KEY (id_reserva),
 	CONSTRAINT FK_Reserva_id_aula FOREIGN KEY (id_aula) REFERENCES Aula(id_aula),
 	CONSTRAINT FK_Reserva_nro_curso FOREIGN KEY (nro_curso) REFERENCES Curso(nro_curso),
 	CONSTRAINT FK_Reserva_id_estado_reserva FOREIGN KEY (id_estado_reserva) REFERENCES EstadoReserva(id_estado_reserva),
 	CONSTRAINT FK_Reserva_id_usuario FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
)
GO

CREATE TABLE DetalleReserva
(
	id_reserva BIGINT NOT NULL,
	id_insumo INT NOT NULL,
	cantidad INT NOT NULL,
 	CONSTRAINT PK_DetalleReserva_id_reserva_id_insumo PRIMARY KEY (id_reserva,id_insumo),
	CONSTRAINT FK_DetalleReserva_id_reserva FOREIGN KEY (id_reserva) REFERENCES Reserva(id_reserva),
	CONSTRAINT FK_DetalleReserva_id_insumo FOREIGN KEY (id_insumo) REFERENCES Insumo(id_insumo)
) 
GO