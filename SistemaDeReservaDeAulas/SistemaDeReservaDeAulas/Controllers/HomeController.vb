Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Util.inicializaSesion("LAPTOP-F5VFQF4J\SQLEXPRESS", "ReservaDeAula", "sa", "jesus92")
            Return View()
        End Function

    End Class
End Namespace