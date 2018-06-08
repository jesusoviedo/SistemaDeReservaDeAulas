Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class AulaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtAula As New DataTable
            dtAula = Aula.RecuperarAula()
            ViewData("Aulas") = dtAula.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult

            Dim dtTipoAula As New DataTable
            dtTipoAula = TipoAula.RecuperarTipoAula()
            ViewData("TiposAulas") = dtTipoAula.AsEnumerable

            Dim dtPiso As New DataTable
            dtPiso = Piso.RecuperarPiso()
            ViewData("Pisos") = dtPiso.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vAula As New Aula
            With vAula
                .pNro_aula = form("txtNro_aula")
                .pId_tipo_aula = form("txtId_tipo_aula")
                .pId_piso = form("txtId_piso")
                .pPosee_proyector = form("txtPosee_proyector")
                .pCapacidad = form("txtCapacidad")
                .InsertarAula()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim dtTipoAula As New DataTable
            dtTipoAula = TipoAula.RecuperarTipoAula()
            ViewData("TiposAulas") = dtTipoAula.AsEnumerable

            Dim dtPiso As New DataTable
            dtPiso = Piso.RecuperarPiso()
            ViewData("Pisos") = dtPiso.AsEnumerable

            Dim vAula As New Aula
            vAula = vAula.RecuperarAula(id)

            Return View(vAula)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vAula As New Aula
            With vAula
                .pId_piso = form("txtId_piso")
                .pNro_aula = form("txtNro_aula")
                .pId_tipo_aula = form("txtId_tipo_aula")
                .pId_piso = form("txtId_piso")
                .pPosee_proyector = form("txtPosee_proyector")
                .pCapacidad = form("txtCapacidad")
                .ActualizarAula()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vAula As New Aula
            With vAula
                .pId_aula = id
                .EliminarAula()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace