﻿Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        ' GET: Home
        Function Index() As ActionResult
            Util.inicializaSesion(ConfigurationManager.AppSettings("datoServidor"), ConfigurationManager.AppSettings("datoBase"), ConfigurationManager.AppSettings("datoUsuario"), ConfigurationManager.AppSettings("datoContrasenha"))
            Return View()
        End Function

    End Class
End Namespace