Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class TipoDocumentoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtTipoDocumento As New DataTable
                dtTipoDocumento = TipoDocumento.RecuperarTipoDocumento()
                ViewData("TiposDocumentos") = dtTipoDocumento.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTipoDocumento As New TipoDocumento
                With vTipoDocumento
                    .pDescripcion = descripcion
                    .InsertarTipoDocumento()
                End With
                Return Json("")
            End If
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTipoDocumento As New TipoDocumento
                vTipoDocumento = vTipoDocumento.RecuperarTipoDocumento(id)
                Return Json(JsonConvert.SerializeObject(vTipoDocumento))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_tipo_doc As Integer, descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTipoDocumento As New TipoDocumento
                With vTipoDocumento
                    .pId_tipo_doc = id_tipo_doc
                    .pDescripcion = descripcion
                    .ActualizarTipoDocumento()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vTipoDocumento As New TipoDocumento
                With vTipoDocumento
                    .pId_tipo_doc = id
                    .EliminarTipoDocumento()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace