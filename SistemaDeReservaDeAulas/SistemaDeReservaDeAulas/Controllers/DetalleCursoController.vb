Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class DetalleCursoController
        Inherits Controller

        Function Index() As ActionResult
            Dim dtDetalleCurso As New DataTable
            dtDetalleCurso = DetalleCurso.RecuperarDetalleCurso()
            ViewData("DetallesCursos") = dtDetalleCurso.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtDia As New DataTable
            dtDia = Dia.RecuperarDia()
            ViewData("Dias") = dtDia.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vDetalleCurso As New DetalleCurso
            With vDetalleCurso
                .pNro_curso = form("txtNro_curso")
                .pId_dia = form("txtId_dia")
                .InsertarDetalleCurso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtDia As New DataTable
            dtDia = Dia.RecuperarDia()
            ViewData("Dias") = dtDia.AsEnumerable

            Dim vDetalleCurso As New DetalleCurso
            vDetalleCurso = vDetalleCurso.RecuperarDetalleCurso(id)
            Return View(vDetalleCurso)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vDetalleCurso As New DetalleCurso
            With vDetalleCurso
                .pNro_curso = form("txtNro_curso")
                .pId_dia = form("txtId_dia")
                .ActualizarDetalleCurso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id_nro_curso As Integer, id_dia As Integer) As ActionResult
            Dim vDetalleCurso As New DetalleCurso
            With vDetalleCurso
                .pNro_curso = id_nro_curso
                .pId_dia = id_dia
                .EliminarDetalleCurso()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace