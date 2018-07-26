@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Materia</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nueva Materia</a>
    <br />
    <br />
    <input type="hidden" id="id_materia" />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Código</th>
                <th>Materia</th>
                <th>Departamento</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vMateria In ViewData("Materias")
                @<tr>
                    <td>@vMateria("id_materia")</td>
                    <td>@vMateria("descripcion")</td>
                    <td>@vMateria("nombre_dpto")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vMateria("id_materia"))"><ion-icon name="document"></ion-icon></a>
                        <a class="btn btn-outline-danger" href="javascript:Confirmar(@vMateria("id_materia"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Materia</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Materia</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form">Materia:</label>
                        <input class="form-control" type="text" name="txtDescripcion" id="txtDescripcion" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Departamento:</label>
                        <select class="form-control" type="text" name="txtId_departamento" id="txtId_departamento" placeholder="" required>
                            @For Each row In ViewData("Departamentos")
                                @<option value="@row("id_dpto")">@row("nombre_dpto")</option>
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Materia</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_materia" id="pId_materia" required />

                    <div class="form-group">
                        <label class="form">Materia:</label>
                        <input class="form-control" type="text" name="pDescripcion" id="pDescripcion" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Departamento:</label>
                        <select class="form-control" type="text" name="pId_departamento" id="pId_departamento" placeholder="" required>
                            @For Each row In ViewData("Departamentos")
                                @<option value="@row("id_dpto")">@row("nombre_dpto")</option>
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
            $('#id_materia').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Materia/Delete',
                data: {
                    id: $('#id_materia').val()
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
                descripcion: $("#txtDescripcion").val(),
                id_departamento: $("#txtId_departamento").val()
            };

            $.ajax({
                type: "POST",
                url: '/Materia/Create',
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
                url: '/Materia/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_materia").val(datos.pId_materia);
                    $("#pDescripcion").val(datos.pDescripcion);
                    $("#pId_departamento").val(datos.pId_departamento);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_materia: $("#pId_materia").val(),
                descripcion: $("#pDescripcion").val(),
                id_departamento: $("#pId_departamento").val()
            };

            $.ajax({
                type: "POST",
                url: '/Materia/Edit',
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

