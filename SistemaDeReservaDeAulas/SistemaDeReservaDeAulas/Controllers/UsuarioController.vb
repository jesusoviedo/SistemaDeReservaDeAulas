Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller

        ' GET: Usuario
        Function Index() As ActionResult
            Return View()
        End Function
    End Class
End Namespace