Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class PisoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtPiso As New DataTable
                dtPiso = Piso.RecuperarPiso()
                ViewData("Pisos") = dtPiso.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPiso As New Piso
                With vPiso
                    .pDescripcion = descripcion
                    .InsertarPiso()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPiso As New Piso
                vPiso = vPiso.RecuperarPiso(id)
                Return Json(JsonConvert.SerializeObject(vPiso))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_piso As Integer, descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPiso As New Piso
                With vPiso
                    .pId_piso = id_piso
                    .pDescripcion = descripcion
                    .ActualizarPiso()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vPiso As New Piso
                With vPiso
                    .pId_piso = id
                    .EliminarPiso()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace