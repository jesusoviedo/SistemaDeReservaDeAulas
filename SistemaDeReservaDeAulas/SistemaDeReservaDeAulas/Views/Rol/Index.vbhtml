@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code


<div class="container">
    <h3>Rol</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Rol</a>
    <input type="hidden" id="id_rol" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Código</th>
                <th>Descripción</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vRol In ViewData("Roles")
                @<tr>
                    <td>@vRol("id_rol")</td>
                    <td>@vRol("nombre_rol")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro('@vRol("id_rol")')"><ion-icon name="document" ></ion-icon></a>
                        <a class="btn btn-outline-danger" href="javascript:Confirmar('@vRol("id_rol")')"><ion-icon name="trash" ></ion-icon></a>
                        <a class="btn btn-outline-success" href="/DetalleRol/"><ion-icon name="albums" ></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Rol</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Rol</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        <label class="form">Cogido:</label>
                        <input class="form-control" type="text" name="txtCogido" id="Cogido" placeholder="" required max="5" min="5" />
                    </div>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Descripción:</label>
                        <input class="form-control" type="text" name="txtNombreRol" id="NombreRol" placeholder="" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Rol</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Cogido:</label>
                            <input class="form-control" type="text" name="pId_rol" id="pId_rol" placeholder="" required disabled />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="form" for="pNombre_rol">Descripción:</label>
                        <input class="form-control" type="text" name="pNombre_rol" id="pNombre_rol" placeholder="Descripción" required />
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
            $('#id_rol').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Rol/Delete',
                data: {
                    id: $('#id_rol').val()
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
                id_rol: $("#Cogido").val(),
                nombre_rol: $("#NombreRol").val()
            };

            $.ajax({
                type: "POST",
                url: '/Rol/Create',
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
                url: '/Rol/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_rol").val(datos.pId_rol);
                    $("#pNombre_rol").val(datos.pNombre_rol);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_rol: $("#pId_rol").val(),
                nombre_rol: $("#pNombre_rol").val()
            };

            $.ajax({
                type: "POST",
                url: '/Rol/Edit',
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
