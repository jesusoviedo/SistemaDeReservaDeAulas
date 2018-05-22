
@Code
    Layout = Nothing
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Sistema de Reservas de Aula</title>
    <link href="~/scripts/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>

    <div class="container-fluid">

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <a class="navbar-brand" href="/">Sistema de Reservas de Aulas</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    @*<li class="nav-item active">
                            <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Link</a>
                        </li>*@
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Mantener
                        </a>
                        <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                            <a class="dropdown-item" href="/EstadoReserva">Estados de Reserva</a>
                            @*<a class="dropdown-item" href="#">Another action</a>*@
                            @*<div class="dropdown-divider"></div>
                                <a class="dropdown-item" href="#">Something else here</a>*@
                        </div>
                    </li>
                    @*<li class="nav-item">
                            <a class="nav-link disabled" href="#">Disabled</a>
                        </li>*@
                </ul>
                @*<form class="form-inline my-2 my-lg-0">
                        <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
                        <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                    </form>*@
            </div>
        </nav>

    </div>

    <div class="container">
        <h3>Lista de Estado de Reserva</h3>
 
        <input type="button" class="btn btn-success" value="Nuevo estado de Reserva" onclick="window.location.href = 'EstadoReserva/Create'" />
        <br />
        <br />

        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Descripción</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each vEstadoReserva In ViewData("EstadosReservas")
                    @<tr>
                        <td>@vEstadoReserva("id_estado_reserva")</td>
                        <td>@vEstadoReserva("descripcion")</td>
                        <td>

                            <input type="button" class="btn btn-warning" value="Modificar" onclick="window.location.href = 'EstadoReserva/Edit/@vEstadoReserva("id_estado_reserva")'" />
                            @*<a href=""></a>*@

                            <input type="button" class="btn btn-danger" value="Eliminar"  data-toggle="modal" data-target='#@vEstadoReserva("id_estado_reserva")'/>
                            @*<a href=""></a>*@
                            @*onclick="javascript:EliminarEstadoReserva(@vEstadoReserva("id_estado_reserva"))"*@
                        </td>

                    </tr>


                        @<!-- Modal -->
                        @<div Class="modal fade" id="@vEstadoReserva("id_estado_reserva")" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                            <div Class="modal-dialog modal-dialog-centered" role="document">
                                <div Class="modal-content">
                                    <div Class="modal-header">
                                        <h5 Class="modal-title" id="exampleModalCenterTitle">Eliminar registro</h5>
                                        <Button type = "button" Class="close" data-dismiss="modal" aria-label="Close">
                                            <span aria-hidden="true">&times;</span>
                                        </button>
                                    </div>
                                    <div Class="modal-body">
                                        ¿Desea eliminar el registro?
                                    </div>
                                    <div Class="modal-footer">
                                        <Button type="button" Class="btn btn-primary" onclick="javascript:EliminarEstadoReserva(@vEstadoReserva("id_estado_reserva"))">Aceptar</Button>
                                        <Button type = "button" Class="btn btn-secondary" data-dismiss="modal">Cancelar</button>                                        
                                    </div>
                                </div>
                            </div>
                        </div>

                Next
            <tbody>
        </table>
    </div>



    <script src="~/scripts/js/jquery-3.3.1.min.js"></script>
    <script src="~/scripts/js/bootstrap.min.js"></script>

    <script type="text/javascript">

        function EliminarEstadoReserva(id) {
            //if (confirm('¿Desea eliminar el registro?')) {
                $.ajax({
                    url: '/EstadoReserva/Delete',
                    data: {
                        id: id
                    },
                    type: 'GET',
                    dateType: 'JSON',
                    success: function (retorno) {
                        location.reload();
                    },
                    error: function () {
                        alert("se ha producido un error.");
                    }
                })
            //}
        };

    </script>

</body>
</html>
