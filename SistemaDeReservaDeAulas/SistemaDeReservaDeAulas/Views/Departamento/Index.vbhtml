@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Departamento</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Departamento</a>
    <br />
    <br />
    <input type="hidden" id="id_departamento" />
    <div class="table-responsive">


        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Departamento</th>
                    <th>Facultad</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each vDepartamento In ViewData("Departamentos")
                    @<tr>
                        <td>@vDepartamento("id_dpto")</td>
                        <td>@vDepartamento("nombre_dpto")</td>
                        <td>@vDepartamento("nombre_facultad")</td>
                        <td>
                            <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vDepartamento("id_dpto"))"><ion-icon name="document"></ion-icon></a>
                            <a class="btn btn-outline-danger" href="javascript:Confirmar(@vDepartamento("id_dpto"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Departamento</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Departamento</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form">Departamento:</label>
                        <input class="form-control" type="text" name="txtNombre_dpto" id="txtNombre_dpto" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Facultad:</label>
                        <select class="form-control" type="text" name="txtId_facultad" id="txtId_facultad" placeholder="" required>
                            @For Each row In ViewData("Facultades")
                                @<option value="@row("id_facultad")">@row("nombre_facultad")</option>
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

<!-- Modal para editar -->
<div class="modal fade" id="modal_edi" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Modificar Departamento</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_dpto" id="pId_dpto" required />

                    <div class="form-group">
                        <label class="form">Departamento:</label>
                        <input class="form-control" type="text" name="pNombre_dpto" id="pNombre_dpto" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Facultad:</label>
                        <select class="form-control" type="text" name="pId_facultad" id="pId_facultad" placeholder="" required>
                            @For Each row In ViewData("Facultades")
                                @<option value="@row("id_facultad")">@row("nombre_facultad")</option>
                            Next
                        </select>
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
            $('#id_departamento').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Departamento/Delete',
                data: {
                    id: $('#id_departamento').val()
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
                nombre_dpto: $("#txtNombre_dpto").val(),
                id_facultad: $("#txtId_facultad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Departamento/Create',
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
                url: '/Departamento/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_dpto").val(datos.pId_dpto);
                    $("#pNombre_dpto").val(datos.pNombre_dpto);
                    $("#pId_facultad").val(datos.pId_facultad);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_dpto: $("#pId_dpto").val(),
                nombre_dpto: $("#pNombre_dpto").val(),
                id_facultad: $("#pId_facultad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Departamento/Edit',
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

