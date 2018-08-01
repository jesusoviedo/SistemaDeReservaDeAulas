
@Code
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

 <div class="container">
    <h3>Estado de Reserva</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo estado de Reserva</a>
    <input type="hidden" id="id_estado_reserva" />
         <br />
         <br />

     <div class="table-responsive">
         <table class="table table-hover table-bordered" id="myTable">
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
                             <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro('@vEstadoReserva("id_estado_reserva")')"><ion-icon name="document"></ion-icon></a>
                             <a class="btn btn-outline-danger" href="javascript:Confirmar('@vEstadoReserva("id_estado_reserva")')"><ion-icon name="trash"></ion-icon></a>
                         </td>
                     </tr>
                 Next
             <tbody>
         </table>
     </div>
     </div>


    <!-- Modal para eliminar -->
    <div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Eliminar estado de Reserva</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    ¿Desea Eliminar el Registro?
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-outline-success" onclick="javascript: EliminarRegistro()">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para agregar -->
    <div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Crear estado de Reserva</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Cogido:</label>
                            <input class="form-control" type="text" name="txtCogido" id="Cogido" placeholder="" required maxlength="1"/>
                        </div>
                    </div>

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Descripción:</label>
                            <input class="form-control" type="text" name="txtDescripcion" id="Descripcion" placeholder="" required />
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-outline-success" data-dismiss="modal" onclick="AgregarRegistro()">Aceptar</button>
                </div>

            </div>
        </div>
    </div>

    <!-- Modal para editar -->
    <div class="modal fade" id="modal_edi" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modificar estado de Reserva</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>

                <div class="modal-body">

                    <div class="form">

                        <div class="form">
                            <div class="form-group">
                                <label class="form">Cogido:</label>
                                <input class="form-control" type="text" name="pId_estado_reserva" id="pId_estado_reserva" placeholder="" required disabled />
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="form" for="pDescripcion">Descripción:</label>
                            <input class="form-control" type="text" name="pDescripcion" id="pDescripcion" placeholder="" required />
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                    <button type="button" class="btn btn-outline-success" data-dismiss="modal" onclick="ActualizarRegistro()">Aceptar</button>
                </div>

            </div>
        </div>
    </div>



    <script type="text/javascript">
        function Confirmar(id) {
            $('#id_estado_reserva').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/EstadoReserva/Delete',
                data: {
                    id: $('#id_estado_reserva').val()
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
        };

        function AgregarRegistro() {
            var parametro = {
                id_estado_reserva: $("#Cogido").val(),
                descripcion: $("#Descripcion").val()               
            };

            $.ajax({
                type: "POST",
                url: '/EstadoReserva/Create',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    location.reload();
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }

        function ConsultarRegistro(id) {
            var parametro = {
                id: id
            };
            $.ajax({
                type: "POST",
                url: '/EstadoReserva/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_estado_reserva").val(datos.pId_estado_reserva);
                    $("#pDescripcion").val(datos.pDescripcion);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_estado_reserva: $("#pId_estado_reserva").val(),
                descripcion: $("#pDescripcion").val()
            };

            $.ajax({
                type: "POST",
                url: '/EstadoReserva/Edit',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    location.reload();
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }

    </script>
