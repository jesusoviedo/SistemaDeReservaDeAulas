@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code


<div class="container">
    <h3>Usuario</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Usuario</a>
    <input type="hidden" id="id_usuario" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Código</th>
                <th>Nombre</th>
                <th>Usuario</th>
                <th>Rol</th>
                <th>Departamento</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vUsuario In ViewData("Usuarios")
                @<tr>
                    <td>@vUsuario("id_usuario")</td>
                    <td>@vUsuario("nombre")</td>                     
                    <td>@vUsuario("user_name")</td>
                    <td>@vUsuario("nombre_rol")</td>
                    <td>@vUsuario("nombre_dpto")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vUsuario("id_usuario"))"><ion-icon name="document"></ion-icon></a>
                        <a class="btn btn-outline-danger" href="javascript:Confirmar(@vUsuario("id_usuario"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Usuario</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea Eliminar el Registro?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="javascript:EliminarRegistro()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal para agregar -->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Crear Usuario</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form-group">
                    <label class="form">Persona:</label>
                    <select class="form-control" type="text" name="txtId_persona" id="txtId_persona" placeholder="" required >
                        @For Each row In ViewData("Personas")
                            @<option value="@row("id_persona")">@row("nombre") @row("apellido")</option>
                        Next
                    </select>
                </div>

                <div class="form-group">
                    <label class="form">Rol:</label>
                    <select class="form-control" type="text" name="txtId_rol" id="txtId_rol" placeholder="" required>
                        @For Each row In ViewData("Roles")
                            @<option value="@row("id_rol")">@row("nombre_rol")</option>
                        Next
                    </select>
                </div>

                <div class="form-group">
                    <label class="form">Departamento:</label>
                    <select class="form-control" type="text" name="txtId_dpto" id="txtId_dpto" placeholder="" required>
                        @For Each row In ViewData("Departamentos")
                            @<option value="@row("id_dpto")">@row("nombre_dpto")</option>
                        Next
                    </select>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Usuario:</label>
                        <input class="form-control" type="text" name="txtUser_name" id="txtUser_name" placeholder="" required />
                    </div>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Contraseña:</label>
                        <input class="form-control" type="password" name="txtPassword" id="txtPassword" placeholder="" required />
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

<!-- Modal para editar-->
<div class="modal fade" id="modal_edi" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Modificar Usuario</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <input type="hidden" name="pId_usuario" id="pId_usuario" required />

                <div class="form-group">
                    <label class="form">Persona:</label>
                    <select class="form-control" type="text" name="pId_persona" id="pId_persona" placeholder="" required disabled>
                        @For Each row In ViewData("Personas")
                            @<option value="@row("id_persona")">@row("nombre") @row("apellido")</option>
                        Next
                    </select>
                </div>

                <div class="form-group">
                    <label class="form">Rol:</label>
                    <select class="form-control" type="text" name="pId_rol" id="pId_rol" placeholder="" required>
                        @For Each row In ViewData("Roles")
                            @<option value="@row("id_rol")">@row("nombre_rol")</option>
                        Next
                    </select>
                </div>

                <div class="form-group">
                    <label class="form">Departamento:</label>
                    <select class="form-control" type="text" name="pId_dpto" id="pId_dpto" placeholder="" required>
                        @For Each row In ViewData("Departamentos")
                            @<option value="@row("id_dpto")">@row("nombre_dpto")</option>
                        Next
                    </select>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Usuario:</label>
                        <input class="form-control" type="text" name="pUser_name" id="pUser_name" placeholder="" required />
                    </div>
                </div>

                @*<div class="form">
                    <div class="form-group">
                        <label class="form">Contraseña:</label>
                        <input class="form-control" type="password" name="pPassword" id="pPassword" placeholder="" required />
                    </div>
                </div>*@

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
            $('#id_usuario').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Usuario/Delete',
                data: {
                    id: $('#id_usuario').val()
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
                id_rol: $("#txtId_rol").val(),
                id_persona: $("#txtId_persona").val(),
                user_name: $("#txtUser_name").val(),
                password: $("#txtPassword").val(),
                id_dpto: $("#txtId_dpto").val()
            };

            $.ajax({
                type: "POST",
                url: '/Usuario/Create',
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
                url: '/Usuario/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_usuario").val(datos.pId_usuario);
                    $("#pId_rol").val(datos.pId_rol);
                    $("#pId_persona").val(datos.pId_persona);
                    $("#pUser_name").val(datos.pUser_name);
                    $("#pId_dpto").val(datos.pId_dpto);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_usuario: $("#pId_usuario").val(),
                id_rol: $("#pId_rol").val(),
                id_persona: $("#pId_persona").val(),
                user_name: $("#pUser_name").val(),
                id_dpto: $("#pId_dpto").val()
            };

            $.ajax({
                type: "POST",
                url: '/Usuario/Edit',
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

