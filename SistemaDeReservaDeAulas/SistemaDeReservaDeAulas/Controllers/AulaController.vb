Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class AulaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtAula As New DataTable
                dtAula = Aula.RecuperarAula()
                ViewData("Aulas") = dtAula.AsEnumerable

                Dim dtTipoAula As New DataTable
                dtTipoAula = TipoAula.RecuperarTipoAula()
                ViewData("TiposAulas") = dtTipoAula.AsEnumerable

                Dim dtPiso As New DataTable
                dtPiso = Piso.RecuperarPiso()
                ViewData("Pisos") = dtPiso.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(nro_aula As Integer, id_tipo_aula As Integer, id_piso As Integer, posee_proyector As String, capacidad As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vAula As New Aula
                With vAula
                    .pNro_aula = nro_aula
                    .pId_tipo_aula = id_tipo_aula
                    .pId_piso = id_piso
                    .pPosee_proyector = posee_proyector
                    .pCapacidad = capacidad
                    .InsertarAula()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vAula As New Aula
                vAula = vAula.RecuperarAula(id)
                Return Json(JsonConvert.SerializeObject(vAula))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_aula As Integer, nro_aula As Integer, id_tipo_aula As Integer, id_piso As Integer, posee_proyector As String, capacidad As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vAula As New Aula
                With vAula
                    .pId_aula = id_aula
                    .pNro_aula = nro_aula
                    .pId_tipo_aula = id_tipo_aula
                    .pId_piso = id_piso
                    .pPosee_proyector = posee_proyector
                    .pCapacidad = capacidad
                    .ActualizarAula()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vAula As New Aula
                With vAula
                    .pId_aula = id
                    .EliminarAula()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace