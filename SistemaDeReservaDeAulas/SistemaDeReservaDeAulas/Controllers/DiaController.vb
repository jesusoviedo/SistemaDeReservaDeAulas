﻿Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DiaController
        Inherits Controller

        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtDia As New DataTable
                dtDia = Dia.RecuperarDia()
                ViewData("Dias") = dtDia.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(descripcion As String, cod_dia As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDia As New Dia
                With vDia
                    .pDescripcion = descripcion
                    .pCod_dia = cod_dia
                    .InsertarDia()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDia As New Dia
                vDia = vDia.RecuperarDia(id)
                Return Json(JsonConvert.SerializeObject(vDia))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_dia As Integer, descripcion As String, cod_dia As Char) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDia As New Dia
                With vDia
                    .pId_dia = id_dia
                    .pDescripcion = descripcion
                    .pCod_dia = cod_dia
                    .ActualizarDia()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vDia As New Dia
                With vDia
                    .pId_dia = id
                    .EliminarDia()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace