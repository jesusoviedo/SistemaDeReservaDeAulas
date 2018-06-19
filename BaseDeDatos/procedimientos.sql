USE ReservaDeAula
GO

-----------PROCEDIMIENTO ALMACENADO-----------
--EstadoReserva
--DROP PROCEDURE SpInsertarEstadoReserva
CREATE PROCEDURE SpInsertarEstadoReserva
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO EstadoReserva VALUES(@descripcion)
END
GO

--DROP PROCEDURE SpConsultarEstadoReserva
CREATE PROCEDURE SpConsultarEstadoReserva
	@id_estado_reserva INT
AS
BEGIN 
	SELECT * FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva OR @id_estado_reserva=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarEstadoReserva
CREATE PROCEDURE SpActualizarEstadoReserva
	@descripcion VARCHAR(50),
	@id_estado_reserva INT
AS
BEGIN 
	UPDATE EstadoReserva  
	SET descripcion=@descripcion
	WHERE id_estado_reserva=@id_estado_reserva
END
GO

--DROP PROCEDURE SpEliminarEstadoReserva
CREATE PROCEDURE SpEliminarEstadoReserva
	@id_estado_reserva INT
AS
BEGIN 
	DELETE FROM EstadoReserva 
	WHERE id_estado_reserva=@id_estado_reserva
END
GO

--TipoInsumo
--DROP PROCEDURE SpInsertarTipoInsumo
CREATE PROCEDURE SpInsertarTipoInsumo
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoInsumo VALUES(@descripcion)
END
GO

--DROP PROCEDURE SpConsultarTipoInsumo
CREATE PROCEDURE SpConsultarTipoInsumo
	@id_tip_insumo INT
AS
BEGIN 
	SELECT * FROM TipoInsumo 
	WHERE id_tip_insumo=@id_tip_insumo OR @id_tip_insumo=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarTipoInsumo
CREATE PROCEDURE SpActualizarTipoInsumo 
	@descripcion VARCHAR(50),
	@id_tip_insumo INT
AS
BEGIN 
	UPDATE TipoInsumo  
	SET descripcion=@descripcion
	WHERE id_tip_insumo=@id_tip_insumo
END
GO

--DROP PROCEDURE SpEliminarTipoInsumo
CREATE PROCEDURE SpEliminarTipoInsumo 
	@id_tip_insumo INT
AS
BEGIN 
	DELETE FROM TipoInsumo 
	WHERE id_tip_insumo=@id_tip_insumo
END
GO

--Piso
--DROP PROCEDURE SpInsertarPiso
CREATE PROCEDURE SpInsertarPiso
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO Piso VALUES(@descripcion)
END
GO

--DROP PROCEDURE SpConsultarPiso
CREATE PROCEDURE SpConsultarPiso
	@id_piso INT
AS
BEGIN 
	SELECT * FROM Piso 
	WHERE id_piso=@id_piso OR @id_piso=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarPiso
CREATE PROCEDURE SpActualizarPiso
	@descripcion VARCHAR(50),
	@id_piso INT
AS
BEGIN 
	UPDATE Piso  
	SET descripcion=@descripcion
	WHERE id_piso=@id_piso
END
GO

--DROP PROCEDURE SpEliminarPiso
CREATE PROCEDURE SpEliminarPiso
	@id_piso INT
AS
BEGIN 
	DELETE FROM Piso 
	WHERE id_piso=@id_piso
END
GO

--Facultad
--DROP PROCEDURE SpInsertarFacultad
CREATE PROCEDURE SpInsertarFacultad
    @nombre_facultad VARCHAR(250)
AS
BEGIN 
	INSERT INTO Facultad VALUES(@nombre_facultad)
END
GO

--DROP PROCEDURE SpConsultarFacultad
CREATE PROCEDURE SpConsultarFacultad
	@id_facultad INT
AS
BEGIN 
	SELECT * FROM Facultad 
	WHERE id_facultad=@id_facultad OR @id_facultad=0
	ORDER BY nombre_facultad
END
GO

--DROP PROCEDURE SpActualizarFacultad
CREATE PROCEDURE SpActualizarFacultad
	@nombre_facultad VARCHAR(250),
	@id_facultad INT
AS
BEGIN 
	UPDATE Facultad  
	SET nombre_facultad=@nombre_facultad
	WHERE id_facultad=@id_facultad
END
GO

--DROP PROCEDURE SpEliminarFacultad
CREATE PROCEDURE SpEliminarFacultad
	@id_facultad INT
AS
BEGIN 
	DELETE FROM Facultad 
	WHERE id_facultad=@id_facultad
END
GO

--Permiso
--DROP PROCEDURE SpInsertarPermiso
CREATE PROCEDURE SpInsertarPermiso
    @nombre_permiso VARCHAR(250)
AS
BEGIN 
	INSERT INTO Permiso VALUES(@nombre_permiso)
END
GO

--DROP PROCEDURE SpConsultarPermiso
CREATE PROCEDURE SpConsultarPermiso
	@id_permiso INT
AS
BEGIN 
	SELECT * FROM Permiso 
	WHERE id_permiso=@id_permiso OR @id_permiso=0
	ORDER BY nombre_permiso
END
GO

--DROP PROCEDURE SpActualizarPermiso
CREATE PROCEDURE SpActualizarPermiso
	@nombre_permiso VARCHAR(250),
	@id_permiso INT
AS
BEGIN 
	UPDATE Permiso  
	SET nombre_permiso=@nombre_permiso
	WHERE id_permiso=@id_permiso
END
GO

--DROP PROCEDURE SpEliminarPermiso
CREATE PROCEDURE SpEliminarPermiso
	@id_permiso INT
AS
BEGIN 
	DELETE FROM Permiso 
	WHERE id_permiso=@id_permiso
END
GO

--TipoAula
--DROP PROCEDURE SpInsertarTipoAula
CREATE PROCEDURE SpInsertarTipoAula
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoAula VALUES(@descripcion)
END
GO

--DROP PROCEDURE SpConsultarTipoAula
CREATE PROCEDURE SpConsultarTipoAula
	@id_tipo_aula INT
AS
BEGIN 
	SELECT * FROM TipoAula 
	WHERE id_tipo_aula=@id_tipo_aula OR @id_tipo_aula=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarTipoAula
CREATE PROCEDURE SpActualizarTipoAula
	@descripcion VARCHAR(50),
	@id_tipo_aula INT
AS
BEGIN 
	UPDATE TipoAula  
	SET descripcion=@descripcion
	WHERE id_tipo_aula=@id_tipo_aula
END
GO

--DROP PROCEDURE SpEliminarTipoAula
CREATE PROCEDURE SpEliminarTipoAula
	@id_tipo_aula INT
AS
BEGIN 
	DELETE FROM TipoAula 
	WHERE id_tipo_aula=@id_tipo_aula
END
GO

--Rol
--DROP PROCEDURE SpInsertarRol
CREATE PROCEDURE SpInsertarRol
    @nombre_rol VARCHAR(250)
AS
BEGIN 
	INSERT INTO Rol VALUES(@nombre_rol)
END
GO

--DROP PROCEDURE SpConsultarRol
CREATE PROCEDURE SpConsultarRol
	@id_rol INT
AS
BEGIN 
	SELECT * FROM Rol 
	WHERE id_rol=@id_rol OR @id_rol=0
	ORDER BY nombre_rol
END
GO

--DROP PROCEDURE SpActualizarRol
CREATE PROCEDURE SpActualizarRol
	@nombre_rol VARCHAR(250),
	@id_rol INT
AS
BEGIN 
	UPDATE Rol  
	SET nombre_rol=@nombre_rol
	WHERE id_rol=@id_rol
END
GO

--DROP PROCEDURE SpEliminarRol
CREATE PROCEDURE SpEliminarRol
	@id_rol INT
AS
BEGIN 
	DELETE FROM Rol 
	WHERE id_rol=@id_rol
END
GO

--TipoDocumento
--DROP PROCEDURE SpInsertarTipoDocumento
CREATE PROCEDURE SpInsertarTipoDocumento
    @descripcion VARCHAR(50)
AS
BEGIN 
	INSERT INTO TipoDocumento VALUES(@descripcion)
END
GO

--DROP PROCEDURE SpConsultarTipoDocumento
CREATE PROCEDURE SpConsultarTipoDocumento
	@id_tipo_doc INT
AS
BEGIN 
	SELECT * FROM TipoDocumento 
	WHERE id_tipo_doc=@id_tipo_doc OR @id_tipo_doc=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarTipoDocumento
CREATE PROCEDURE SpActualizarTipoDocumento
	@descripcion VARCHAR(50),
	@id_tipo_doc INT
AS
BEGIN 
	UPDATE TipoDocumento  
	SET descripcion=@descripcion
	WHERE id_tipo_doc=@id_tipo_doc
END
GO

--DROP PROCEDURE SpEliminarTipoDocumento
CREATE PROCEDURE SpEliminarTipoDocumento
	@id_tipo_doc INT
AS
BEGIN 
	DELETE FROM TipoDocumento 
	WHERE id_tipo_doc=@id_tipo_doc
END
GO

--Dia
--DROP PROCEDURE SpInsertarDia
CREATE PROCEDURE SpInsertarDia
    @descripcion VARCHAR(50),
	@cod_dia CHAR(1)
AS
BEGIN 
	INSERT INTO Dia VALUES(@descripcion,@cod_dia)
END
GO

--DROP PROCEDURE SpConsultarDia
CREATE PROCEDURE SpConsultarDia
	@id_dia INT
AS
BEGIN 
	SELECT * FROM Dia 
	WHERE id_dia=@id_dia OR @id_dia=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarDia
CREATE PROCEDURE SpActualizarDia
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

--DROP PROCEDURE SpEliminarDia
CREATE PROCEDURE SpEliminarDia
	@id_dia INT
AS
BEGIN 
	DELETE FROM Dia 
	WHERE id_dia=@id_dia
END
GO

--Turno
--DROP PROCEDURE SpInsertarTurno
CREATE PROCEDURE SpInsertarTurno
    @descripcion VARCHAR(50),
	@hora_inicio TIME,
	@hora_fin TIME
AS
BEGIN 
	INSERT INTO Turno VALUES(@descripcion,@hora_inicio,@hora_fin)
END
GO

--DROP PROCEDURE SpConsultarTurno
CREATE PROCEDURE SpConsultarTurno
	@id_turno INT
AS
BEGIN 
	SELECT * FROM Turno 
	WHERE id_turno=@id_turno OR @id_turno=0
	ORDER BY descripcion
END
GO

--DROP PROCEDURE SpActualizarTurno
CREATE PROCEDURE SpActualizarTurno
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

--DROP PROCEDURE SpEliminarTurno
CREATE PROCEDURE SpEliminarTurno
	@id_turno INT
AS
BEGIN 
	DELETE FROM Turno 
	WHERE id_turno=@id_turno
END
GO

--DetalleRol
--DROP PROCEDURE SpInsertarDetalleRol
CREATE PROCEDURE SpInsertarDetalleRol
    @id_rol INT,
	@id_permiso INT
AS
BEGIN 
	INSERT INTO DetalleRol VALUES(@id_rol,@id_permiso)
END
GO

--DROP PROCEDURE SpConsultarDetalleRol
CREATE PROCEDURE SpConsultarDetalleRol
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

--DROP PROCEDURE SpActualizarDetalleRol
CREATE PROCEDURE SpActualizarDetalleRol
    @id_rol INT,
	@id_permiso INT
AS
BEGIN 
	UPDATE DetalleRol  
	SET id_rol=@id_rol, id_permiso=@id_permiso
	WHERE id_rol=@id_rol AND id_permiso=@id_permiso
END
GO

--DROP PROCEDURE SpEliminarDetalleRol
CREATE PROCEDURE SpEliminarDetalleRol
	@id_rol INT,
	@id_permiso INT
AS
BEGIN 
	DELETE FROM DetalleRol 
	WHERE id_rol=@id_rol AND id_permiso=@id_permiso
END
GO

--Departamento
--DROP PROCEDURE SpInsertarDepartamento
CREATE PROCEDURE SpInsertarDepartamento
    @nombre_dpto VARCHAR(250),
	@id_facultad INT
AS
BEGIN 
	INSERT INTO Departamento VALUES(@nombre_dpto,@id_facultad)
END
GO

--DROP PROCEDURE SpConsultarDepartamento
CREATE PROCEDURE SpConsultarDepartamento
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

--DROP PROCEDURE SpActualizarDepartamento
CREATE PROCEDURE SpActualizarDepartamento
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

--DROP PROCEDURE SpEliminarDepartamento
CREATE PROCEDURE SpEliminarDepartamento
	@id_dpto INT
AS
BEGIN 
	DELETE FROM Departamento 
	WHERE id_dpto=@id_dpto
END
GO

--Materia
--DROP PROCEDURE SpInsertarMateria
CREATE PROCEDURE SpInsertarMateria
    @descripcion VARCHAR(250),
	@id_dpto INT
AS
BEGIN 
	INSERT INTO Materia VALUES(@descripcion,@id_dpto)
END
GO

--DROP PROCEDURE SpConsultarMateria
CREATE PROCEDURE SpConsultarMateria
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

--DROP PROCEDURE SpActualizarMateria
CREATE PROCEDURE SpActualizarMateria
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

--DROP PROCEDURE SpEliminarMateria
CREATE PROCEDURE SpEliminarMateria
	@id_materia INT
AS
BEGIN 
	DELETE FROM Materia 
	WHERE id_materia=@id_materia
END
GO

--Insumo
--DROP PROCEDURE SpInsertarInsumo
CREATE PROCEDURE SpInsertarInsumo
    @descripcion VARCHAR(50),
	@id_tip_insumo INT
AS
BEGIN 
	INSERT INTO Insumo VALUES(@descripcion,@id_tip_insumo)
END
GO

--DROP PROCEDURE SpConsultarInsumo
CREATE PROCEDURE SpConsultarInsumo
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

--DROP PROCEDURE SpActualizarInsumo
CREATE PROCEDURE SpActualizarInsumo
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

--DROP PROCEDURE SpEliminarInsumo
CREATE PROCEDURE SpEliminarInsumo
	@id_insumo INT
AS
BEGIN 
	DELETE FROM Insumo 
	WHERE id_insumo=@id_insumo
END
GO

--Persona
--DROP PROCEDURE SpInsertarPersona
CREATE PROCEDURE SpInsertarPersona
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

--DROP PROCEDURE SpConsultarPersona
CREATE PROCEDURE SpConsultarPersona
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
	p.fecha_naci,
	p.email
	FROM Persona p
	INNER JOIN TipoDocumento t on t.id_tipo_doc=p.id_tipo_doc
	WHERE p.id_persona=@id_persona OR @id_persona=0
	ORDER BY p.nombre
END
GO

--DROP PROCEDURE SpActualizarPersona
CREATE PROCEDURE SpActualizarPersona
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

--DROP PROCEDURE SpEliminarPersona
CREATE PROCEDURE SpEliminarPersona
	@id_persona INT
AS
BEGIN 
	DELETE FROM Persona 
	WHERE id_persona=@id_persona
END
GO

--Usuario
--DROP PROCEDURE SpInsertarUsuario
CREATE PROCEDURE SpInsertarUsuario
	@id_rol INT,
	@id_persona INT,
	@user_name VARCHAR(250),
	@password VARBINARY
AS
BEGIN 
	INSERT INTO Usuario VALUES(@id_rol,@id_persona,@user_name,@password)
END
GO

--DROP PROCEDURE SpConsultarUsuario
CREATE PROCEDURE SpConsultarUsuario
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
	u.password
	FROM Usuario u
	INNER JOIN Rol r on r.id_rol=u.id_rol
	INNER JOIN Persona p on p.id_persona=u.id_persona
	WHERE u.id_usuario=@id_usuario OR @id_usuario=0
	ORDER BY p.nombre
END
GO

--DROP PROCEDURE SpActualizarUsuario
CREATE PROCEDURE SpActualizarUsuario
	@id_rol INT,
	@id_persona INT,
	@user_name VARCHAR(250),
	@password VARBINARY,
	@id_usuario INT
AS
BEGIN 
	UPDATE Usuario  
	SET id_rol=@id_rol, id_persona=@id_persona, user_name=@user_name, password=@password
	WHERE id_usuario=@id_usuario
END
GO

--DROP PROCEDURE SpEliminarUsuario
CREATE PROCEDURE SpEliminarUsuario
	@id_usuario INT
AS
BEGIN 
	DELETE FROM Usuario 
	WHERE id_usuario=@id_usuario
END
GO

--Profesor
--DROP PROCEDURE SpInsertarProfesor
CREATE PROCEDURE SpInsertarProfesor
	@id_persona INT
AS
BEGIN 
	INSERT INTO Profesor VALUES(@id_persona)
END
GO

--DROP PROCEDURE SpConsultarProfesor
CREATE PROCEDURE SpConsultarProfesor
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

--DROP PROCEDURE SpActualizarProfesor
CREATE PROCEDURE SpActualizarProfesor
	@id_persona INT,
	@id_profesor INT
AS
BEGIN 
	UPDATE Profesor  
	SET id_persona=@id_persona
	WHERE id_profesor=@id_profesor
END
GO

--DROP PROCEDURE SpEliminarProfesor
CREATE PROCEDURE SpEliminarProfesor
	@id_profesor INT
AS
BEGIN 
	DELETE FROM Profesor 
	WHERE id_profesor=@id_profesor
END
GO

--Aula
--DROP PROCEDURE SpInsertarAula
CREATE PROCEDURE SpInsertarAula
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

--DROP PROCEDURE SpConsultarAula
CREATE PROCEDURE SpConsultarAula
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
	a.posee_proyector,
	a.capacidad
	FROM Aula a
	INNER JOIN TipoAula t on t.id_tipo_aula=a.id_tipo_aula
	INNER JOIN Piso p on p.id_piso=a.id_piso
	WHERE a.id_aula=@id_aula OR @id_aula=0
	ORDER BY a.nro_aula
END
GO

--DROP PROCEDURE SpActualizarAula
CREATE PROCEDURE SpActualizarAula
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

--DROP PROCEDURE SpEliminarAula
CREATE PROCEDURE SpEliminarAula
	@id_aula INT
AS
BEGIN 
	DELETE FROM Aula 
	WHERE @id_aula=id_aula
END
GO

--Curso
--DROP PROCEDURE SpInsertarCurso
CREATE PROCEDURE SpInsertarCurso
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

--DROP PROCEDURE SpConsultarCurso
CREATE PROCEDURE SpConsultarCurso
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

--DROP PROCEDURE SpActualizarCurso
CREATE PROCEDURE SpActualizarCurso
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

--DROP PROCEDURE SpEliminarCurso
CREATE PROCEDURE SpEliminarCurso
	@nro_curso INT
AS
BEGIN 
	DELETE FROM Curso 
	WHERE nro_curso=@nro_curso
END
GO

--DetalleCurso
--DROP PROCEDURE SpInsertarDetalleCurso
CREATE PROCEDURE SpInsertarDetalleCurso
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	INSERT INTO DetalleCurso VALUES(@nro_curso,@id_dia)
END
GO

--DROP PROCEDURE SpConsultarDetalleCurso
CREATE PROCEDURE SpConsultarDetalleCurso
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

--DROP PROCEDURE SpActualizarDetalleCurso
CREATE PROCEDURE SpActualizarDetalleCurso
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	UPDATE DetalleCurso  
	SET nro_curso=@nro_curso, id_dia=@id_dia
	WHERE nro_curso=@nro_curso AND id_dia=@id_dia
END
GO

--DROP PROCEDURE SpEliminarDetalleCurso
CREATE PROCEDURE SpEliminarDetalleCurso
    @nro_curso INT,
	@id_dia INT
AS
BEGIN 
	DELETE FROM DetalleCurso 
	WHERE nro_curso=@nro_curso AND id_dia=@id_dia
END
GO

--DetalleReserva
--DROP PROCEDURE SpInsertarDetalleReserva
CREATE PROCEDURE SpInsertarDetalleReserva
    @id_reserva INT,
	@id_insumo INT,
	@cantidad INT
AS
BEGIN 
	INSERT INTO DetalleReserva VALUES(@id_reserva,@id_insumo,@cantidad)
END
GO

--DROP PROCEDURE SpConsultarDetalleReserva
CREATE PROCEDURE SpConsultarDetalleReserva
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

--DROP PROCEDURE SpActualizarDetalleReserva
CREATE PROCEDURE SpActualizarDetalleReserva
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

--DROP PROCEDURE SpEliminarDetalleReserva
CREATE PROCEDURE SpEliminarDetalleReserva
    @id_reserva INT,
	@id_insumo INT
AS
BEGIN 
	DELETE FROM DetalleReserva 
	WHERE id_reserva=@id_reserva AND id_insumo=@id_insumo
END
GO

--Reserva
--DROP PROCEDURE SpInsertarReserva
CREATE PROCEDURE SpInsertarReserva
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

--DROP PROCEDURE SpConsultarReserva
CREATE PROCEDURE SpConsultarReserva
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

--DROP PROCEDURE SpActualizarReserva
CREATE PROCEDURE SpActualizarReserva
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

--DROP PROCEDURE SpEliminarReserva
CREATE PROCEDURE SpEliminarReserva
	@id_reserva BIGINT
AS
BEGIN 
	DELETE FROM Reserva 
	WHERE id_reserva=@id_reserva
END
GO