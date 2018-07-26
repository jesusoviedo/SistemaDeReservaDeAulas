Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class CursoController
        Inherits Controller

        Function Index() As ActionResult

            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtaula As New DataTable
            dtaula = Aula.RecuperarAula()
            ViewData("Aulas") = dtaula.AsEnumerable

            Dim dtmateria As New DataTable
            dtaula = Materia.RecuperarMateria()
            ViewData("Materias") = dtaula.AsEnumerable

            Dim dtturno As New DataTable
            dtturno = Turno.RecuperarTurno()
            ViewData("Turnos") = dtturno.AsEnumerable

            '-----FALTA CLASE PROFESOR-----
            Dim dtprofesor As New DataTable
            'dtprofesor = Profesor.RecuperarProfesor()
            'ViewData("Profesores") = dtaula.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(id_aula As Integer, id_materia As Integer, id_turno As Integer, id_profesor As Integer, cant_inscriptos As Integer, anho_lectivo As Integer) As JsonResult
            Dim vCurso As New Curso
            With vCurso
                .pId_aula = id_aula
                .pId_materia = id_materia
                .pId_turno = id_turno
                .pId_profesor = id_profesor
                .pCant_inscriptos = cant_inscriptos
                .pAnho_lectivo = anho_lectivo
                .InsertarCurso()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vCurso As New Curso
            vCurso = vCurso.RecuperarCurso(id)
            Return Json(JsonConvert.SerializeObject(vCurso))
        End Function

        <HttpPost()>
        Function Edit(nro_curso As Integer, id_aula As Integer, id_materia As Integer, id_turno As Integer, id_profesor As Integer, cant_inscriptos As Integer, anho_lectivo As Integer) As JsonResult
            Dim vCurso As New Curso
            With vCurso
                .pNro_curso = nro_curso
                .pId_aula = id_aula
                .pId_materia = id_materia
                .pId_turno = id_turno
                .pId_profesor = id_profesor
                .pCant_inscriptos = cant_inscriptos
                .pAnho_lectivo = anho_lectivo
                .ActualizarCurso()
            End With
            Return Json("")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vCurso As New Curso
            With vCurso
                .pNro_curso = id
                .EliminarCurso()
            End With
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace