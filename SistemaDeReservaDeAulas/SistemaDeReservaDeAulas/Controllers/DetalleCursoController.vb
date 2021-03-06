﻿Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DetalleCursoController
        Inherits Controller

        Function Index() As ActionResult

            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtDia As New DataTable
            dtDia = Dia.RecuperarDia()
            ViewData("Dias") = dtDia.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(nro_curso As Integer, id_dia As Integer) As JsonResult
            Dim vDetalleCurso As New DetalleCurso
            With vDetalleCurso
                .pNro_curso = nro_curso
                .pId_dia = id_dia
                .InsertarDetalleCurso()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vDetalleCurso As New DataTable
            vDetalleCurso = DetalleCurso.RecuperarDetalleCurso(id)
            Return Json(JsonConvert.SerializeObject(vDetalleCurso))
        End Function

        <HttpPost()>
        Function Delete(nro_curso As Integer, id_dia As Integer) As JsonResult
            Dim vDetalleCurso As New DetalleCurso
            With vDetalleCurso
                .pNro_curso = nro_curso
                .pId_dia = id_dia
                .EliminarDetalleCurso()
            End With
            Return Json("")
        End Function

    End Class
End Namespace