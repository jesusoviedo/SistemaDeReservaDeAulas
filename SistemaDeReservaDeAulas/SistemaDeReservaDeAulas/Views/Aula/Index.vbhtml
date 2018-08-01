@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Aula</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nueva Aula</a>
    <br />
    <br />
    <input type="hidden" id="id_aula" />
    <div class="table-responsive">
        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>N° de Aula</th>
                    <th>Tipo de Aula</th>
                    <th>Piso</th>
                    <th>Posee proyector</th>
                    <th>Capacidad</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each vAula In ViewData("Aulas")
                    @<tr>
                        <td>@vAula("id_aula")</td>
                        <td>@vAula("nro_aula")</td>
                        <td>@vAula("nombre_tipo_aula")</td>
                        <td>@vAula("nombre_piso")</td>
                        <td>@vAula("posee_proyector")</td>
                        <td>@vAula("capacidad")</td>
                        <td>
                            <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vAula("id_aula"))"><ion-icon name="document"></ion-icon></a>
                            <a class="btn btn-outline-danger" href="javascript:Confirmar(@vAula("id_aula"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Aula</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Aula</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        <label class="form">N° de Aula:</label>
                        <input class="form-control" type="number" name="txtNro_aula" id="Nro_aula" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Tipo de Aula:</label>
                        <select class="form-control" type="text" name="txtId_tipo_aula" id="Id_tipo_aula" placeholder="" required>
                            @For Each row In ViewData("TiposAulas")
                                @<option value="@row("id_tipo_aula")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Piso:</label>
                        <select class="form-control" type="text" name="txtId_piso" id="Id_piso" placeholder="" required>
                            @For Each row In ViewData("Pisos")
                                @<option value="@row("id_piso")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Posee proyector:</label>
                        <select class="form-control" type="text" name="txtPosee_proyector" id="Posee_proyector" placeholder="" required>
                            <option value="S">Si</option>
                            <option value="N" selected>No</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Capacidad:</label>
                        <input class="form-control" type="number" name="txtCapacidad" id="Capacidad" placeholder="" maxlength="1" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Aula</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_aula" id="pId_aula" required />

                    <div class="form-group">
                        <label class="form">N° de Aula:</label>
                        <input class="form-control" type="number" name="txtNro_aula" id="pNro_aula" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Tipo de Aula:</label>
                        <select class="form-control" type="text" name="txtId_tipo_aula" id="pId_tipo_aula" placeholder="" required>
                            @For Each row In ViewData("TiposAulas")
                                @<option value="@row("id_tipo_aula")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Piso:</label>
                        <select class="form-control" type="text" name="txtId_piso" id="pId_piso" placeholder="" required>
                            @For Each row In ViewData("Pisos")
                                @<option value="@row("id_piso")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Posee proyector:</label>
                        <select class="form-control" type="text" name="txtPosee_proyector" id="pPosee_proyector" placeholder="" required>
                            <option value="S">Si</option>
                            <option value="N">No</option>
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Capacidad:</label>
                        <input class="form-control" type="number" name="txtCapacidad" id="pCapacidad" placeholder="" maxlength="1" required />
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
            $('#id_aula').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Aula/Delete',
                data: {
                    id: $('#id_aula').val()
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
                nro_aula: $("#Nro_aula").val(),
                id_tipo_aula: $("#Id_tipo_aula").val(),
                id_piso: $("#Id_piso").val(),
                posee_proyector: $("#Posee_proyector").val(),
                capacidad: $("#Capacidad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Aula/Create',
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
                url: '/Aula/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_aula").val(datos.pId_aula);
                    $("#pNro_aula").val(datos.pNro_aula);
                    $("#pId_tipo_aula").val(datos.pId_tipo_aula);
                    $("#pId_piso").val(datos.pId_piso);

                    var str = datos.pPosee_proyector;
                    var res = str.substring(0, 1);
                    $("#pPosee_proyector").val(res);

                    $("#pCapacidad").val(datos.pCapacidad);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_aula: $("#pId_aula").val(),
                nro_aula: $("#pNro_aula").val(),
                id_tipo_aula: $("#pId_tipo_aula").val(),
                id_piso: $("#pId_piso").val(),
                posee_proyector: $("#pPosee_proyector").val(),
                capacidad: $("#pCapacidad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Aula/Edit',
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