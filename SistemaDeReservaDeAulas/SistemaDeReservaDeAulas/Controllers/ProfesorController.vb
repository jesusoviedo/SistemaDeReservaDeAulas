Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class ProfesorController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtProfesor As New DataTable
            dtProfesor = Profesor.RecuperarProfesor()
            ViewData("Profesores") = dtProfesor.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vProfesor As New Profesor
            With vProfesor
                .pId_persona = form("txtId_persona")
                .pNombre = form("txtINombre")
                .pApellido = form("txtApellido")
                .pDocumento = form("txtDocumento")
                .pId_tipo_doc = form("txtId_tipo_doc")
                .pFecha_naci = form("txtFecha_naci")
                .pEmail = form("txtEmail")
                .InsertarProfesor()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim vProfesor As New Profesor
            vProfesor = vProfesor.RecuperarProfesor(id)

            Return View(vProfesor)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vProfesor As New Profesor
            With vProfesor
                .pId_profesor = form("txtId_profesor")
                .pId_persona = form("txtId_persona")
                .pNombre = form("txtINombre")
                .pApellido = form("txtApellido")
                .pDocumento = form("txtDocumento")
                .pId_tipo_doc = form("txtId_tipo_doc")
                .pFecha_naci = form("txtFecha_naci")
                .pEmail = form("txtEmail")
                .ActualizarProfesor()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vProfesor As New Profesor
            With vProfesor
                .pId_profesor = id
                .EliminarProfesor()
            End With
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace