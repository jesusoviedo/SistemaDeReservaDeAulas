Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class PersonaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            Dim dtPersona As New DataTable
            dtPersona = Persona.RecuperarPersona()
            ViewData("Personas") = dtPersona.AsEnumerable

            Dim dtTipoDocumento As New DataTable
            dtTipoDocumento = TipoDocumento.RecuperarTipoDocumento()
            ViewData("TiposDocumentos") = dtTipoDocumento.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(nombre As String, apellido As String, documento As String, id_tipo_doc As Integer, fecha_naci As DateTime, email As String) As JsonResult
            Dim vPersona As New Persona
            With vPersona
                .pNombre = nombre
                .pApellido = apellido
                .pDocumento = documento
                .pId_tipo_doc = id_tipo_doc
                .pFecha_naci = fecha_naci
                .pEmail = email
                .InsertarPersona()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vPersona As New Persona
            vPersona = vPersona.RecuperarPersona(id)
            Return Json(JsonConvert.SerializeObject(vPersona))
        End Function

        <HttpPost()>
        Function Edit(id_persona As Integer, nombre As String, apellido As String, documento As String, id_tipo_doc As Integer, fecha_naci As DateTime, email As String) As JsonResult
            Dim vPersona As New Persona
            With vPersona
                .pId_persona = id_persona
                .pNombre = nombre
                .pApellido = apellido
                .pDocumento = documento
                .pId_tipo_doc = id_tipo_doc
                .pFecha_naci = fecha_naci
                .pEmail = email
                .ActualizarPersona()
            End With
            Return Json("")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vPersona As New Persona
            With vPersona
                .pId_persona = id
                .EliminarPersona()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace