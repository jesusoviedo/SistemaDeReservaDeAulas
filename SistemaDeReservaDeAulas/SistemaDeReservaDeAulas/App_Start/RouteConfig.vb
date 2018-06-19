Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Routing

Public Module RouteConfig
    Public Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        routes.MapRoute(
            name:="Default",
            url:="{controller}/{action}/{id}",
            defaults:=New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional}
        )

        routes.MapRoute(
            name:="DetalleReserva",
            url:="{controller}/{action}/{idReserva}/{idInsumo}",
            defaults:=New With {.controller = "DetalleReserva", .action = "Delete", .idReserva = UrlParameter.Optional, .idInsumo = UrlParameter.Optional}
        )

        routes.MapRoute(
            name:="DetalleRol",
            url:="{controller}/{action}/{idRol}/{idPermiso}",
            defaults:=New With {.controller = "DetalleRol", .action = "Delete", .idRol = UrlParameter.Optional, .idPermiso = UrlParameter.Optional}
        )

        routes.MapRoute(
            name:="DetalleCursoController",
            url:="{controller}/{action}/{id_nro_curso}/{id_dia}",
            defaults:=New With {.controller = "DetalleCursoController", .action = "Delete", .id_nro_curso = UrlParameter.Optional, .id_dia = UrlParameter.Optional}
        )

    End Sub
End Module