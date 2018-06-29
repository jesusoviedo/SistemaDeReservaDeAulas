@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Turno</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Turno</a>
    <input type="hidden" id="id_turno" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Código</th>
                <th>Descripción</th>
                <th>Hora inicio</th>
                <th>Hora fin</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vTurno In ViewData("Turnos")
                @<tr>
                    <td>@vTurno("id_turno")</td>
                    <td>@vTurno("descripcion")</td>
                    <td>@vTurno("hora_inicio")</td>
                    <td>@vTurno("hora_fin")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vTurno("id_turno"))"><ion-icon name="document"></ion-icon></a>
                        <a class="btn btn-outline-danger" href="javascript:Confirmar(@vTurno("id_turno"))"><ion-icon name="trash"></ion-icon></a>
                    </td>
                </tr>
            Next
        <tbody>
    </table>
</div>


<!-- Modal para eliminar -->
<div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Turno</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Turno</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        @*<label class="form">Descripción:</label>*@
                        <input class="form-control" type="text" name="txtDescripcion" id="Descripcion" placeholder="Descripción" required />
                    </div>

                    <div class="form-group">
                        @*<label class="form">Hora inicio:</label>*@
                        <input class="form-control" type="time" name="txtHora_inicio" id="HoraInicio" placeholder="Hora inicio" required />
                    </div>

                    <div class="form-group">
                        @*<label class="form">Hora fin:</label>*@
                        <input class="form-control" type="time" name="txtHora_fin" id="HoraFin" placeholder="Hora fin" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Turno</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_turno" id="pId_turno" required />
                    
                    <div class="form-group">
                        <label class="form" for="pDescripcion">Descripción:</label>
                        <input class="form-control" type="text" name="pDescripcion" id="pDescripcion" placeholder="Descripción" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Hora inicio:</label>
                        <input class="form-control" type="time" name="pHora_inicio" id="pHora_inicio" placeholder="Hora inicio" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Hora fin:</label>
                        <input class="form-control" type="time" name="pHora_fin" id="pHora_fin" placeholder="Hora fin" required />
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
            $('#id_turno').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Turno/Delete',
                data: {
                    id: $('#id_turno').val()
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
                descripcion: $("#Descripcion").val(),
                hora_inicio: $("#HoraInicio").val(),
                hora_fin: $("#HoraFin").val()
            };

            $.ajax({
                type: "POST",
                url: '/Turno/Create',
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
                url: '/Turno/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_turno").val(datos.pId_turno);
                    $("#pDescripcion").val(datos.pDescripcion);
                    $("#pHora_inicio").val(datos.pHora_inicio);
                    $("#pHora_fin").val(datos.pHora_fin);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_turno: $("#pId_turno").val(),
                descripcion: $("#pDescripcion").val(),
                hora_inicio: $("#pHora_inicio").val(),
                hora_fin: $("#pHora_fin").val()
            };

            $.ajax({
                type: "POST",
                url: '/Turno/Edit',
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

