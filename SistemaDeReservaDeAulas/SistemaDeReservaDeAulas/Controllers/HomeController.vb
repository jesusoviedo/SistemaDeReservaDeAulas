Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Util.inicializaSesion("LAPTOP-F5VFQF4J\SQLEXPRESS", "ReservaDeAula", "sa", "jesus92")
            ''Util.inicializaSesion("reservaulas.database.windows.net", "ReservaDeAulas", "r3SeRv4", "R3s3rv4$l4")
            Return View()
        End Function

    End Class
End Namespace