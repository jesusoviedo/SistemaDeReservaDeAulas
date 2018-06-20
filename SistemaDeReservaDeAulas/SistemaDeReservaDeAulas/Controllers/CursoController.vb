Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class CursoController
        Inherits Controller

        Function Index() As ActionResult
            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult

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
            ViewData("Profesores") = dtaula.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vCurso As New Curso
            With vCurso
                .pId_aula = form("txtId_aula")
                .pId_materia = form("txtId_materia")
                .pId_turno = form("txtId_turno")
                .pId_profesor = form("txtId_profesor")
                .pCant_inscriptos = form("txtCant_Inscriptos")
                .pAnho_lectivo = form("txtAnho_lectivo")
                .InsertarCurso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim dtaula As New DataTable
            dtaula = Aula.RecuperarAula()
            ViewData("Aulas") = dtaula.AsEnumerable

            '-----FALTA CLASE MATERIA-----
            Dim dtmateria As New DataTable
            'dtaula = Materia.RecuperarMateria()
            ViewData("Materias") = dtaula.AsEnumerable

            Dim dtturno As New DataTable
            dtturno = Turno.RecuperarTurno()
            ViewData("Turnos") = dtturno.AsEnumerable

            '-----FALTA CLASE PROFESOR-----
            Dim dtprofesor As New DataTable
            'dtprofesor = Profesor.RecuperarProfesor()
            ViewData("Profesores") = dtaula.AsEnumerable

            Dim vCurso As New Curso
            vCurso = vCurso.RecuperarCurso(id)
            Return View(vCurso)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vCurso As New Curso
            With vCurso
                .pNro_curso = form("txtnro_curso")
                .pId_aula = form("txtId_aula")
                .pId_materia = form("txtId_materia")
                .pId_turno = form("txtId_turno")
                .pId_profesor = form("txtId_profesor")
                .pCant_inscriptos = form("txtCant_Inscriptos")
                .pAnho_lectivo = form("txtAnho_lectivo")
                .ActualizarCurso()
            End With
            Return RedirectToAction("Index")
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