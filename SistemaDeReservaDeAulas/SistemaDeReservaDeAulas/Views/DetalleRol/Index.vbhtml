@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code


<div class="container">
    <h3>Detalle de Rol</h3>
    <br />
    <div class="form-group">
        @*<label class="form">Roles:</label>*@
        <select class="form-control" type="text" name="txtId_rol" id="txtId_rol" placeholder="" onchange="recuperar_permisoPorRol()" required>
            @For Each row In ViewData("Roles")
                @<option value="@row("id_rol")">@row("nombre_rol")</option>
            Next
        </select>
    </div>



    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Agregar permiso a Rol</a>
    <br />
    <br />
    <input type="hidden" id="id_rol" />
    <input type="hidden" id="id_permiso" />
    <div class="table-responsive">
        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Rol</th>
                    <th>Permiso</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody id="DatosDetalleRol">
            <tbody>
        </table>
    </div>
</div>


<!-- Modal para eliminar -->
<div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Detalle rol</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea Eliminar el Registro?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="EliminarRegistro()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal para agregar -->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Crear Detalle rol</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form">Roles:</label>
                        <select class="form-control" type="text" name="pId_rol" id="pId_rol" placeholder="" required disabled>
                            @For Each row In ViewData("Roles")
                                @<option value="@row("id_rol")">@row("nombre_rol")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Permiso:</label>
                        <select class="form-control" type="text" name="pId_permiso" id="pId_permiso" placeholder="" required>
                            @For Each row In ViewData("Permisos")
                                @<option value="@row("id_permiso")">@row("nombre_permiso")</option>
                            Next
                        </select>
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


<script type="text/javascript">
        function Confirmar(id_rol,id_permiso) {
            $('#id_rol').val(id_rol);
            $('#id_permiso').val(id_permiso);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/DetalleRol/Delete',
                data: {
                    id_rol: $('#id_rol').val(),
                    id_permiso: $('#id_permiso').val()
                },
                type: 'POST',
                dateType: 'JSON',
                success: function (retorno) {
                    recuperar_permisoPorRol();
                    $('#modal_conf').modal('hide');
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        };

        function AgregarRegistro() {       
          
            var parametro = {
                id_rol: $("#pId_rol").val(),
                id_permiso: $("#pId_permiso").val()
            };

            $.ajax({
                type: "POST",
                url: '/DetalleRol/Create',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    recuperar_permisoPorRol();
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });            
        }


        function recuperar_permisoPorRol() {

            $("#pId_rol").val($("#txtId_rol").val());

            var parametro = {
                id: $("#txtId_rol").val()
            };
            $.ajax({
                type: "POST",
                url: '/DetalleRol/Consult',
                data: parametro,
                dataType: "json",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    var row = "";
                    for (i = 0; i < datos.length; i++) {

                        row += "<tr><td>" + datos[i].nombre_rol +
                                "</td><td>" + datos[i].nombre_permiso +
                                "<td> <a class='btn btn-outline-danger' href='javascript:Confirmar(\"" + datos[i].nombre_rol + "\"," + datos[i].id_permiso + ")'><ion-icon name='trash'></ion-icon></a>" +
                                "</td></tr>";
                    }
                    $("#DatosDetalleRol").html(row);
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }


</script>
