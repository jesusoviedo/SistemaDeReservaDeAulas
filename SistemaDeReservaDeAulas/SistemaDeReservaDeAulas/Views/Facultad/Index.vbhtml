@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Facultad</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nueva Facultad</a>
    <input type="hidden" id="id_facultad" />
    <br />
    <br />
    <div class="table-responsive">
        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Nombre Facultad</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each vFacultad In ViewData("Facultades")
                    @<tr>
                        <td>@vFacultad("id_facultad")</td>
                        <td>@vFacultad("nombre_facultad")</td>
                        <td>
                            <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vFacultad("id_facultad"))"><ion-icon name="document"></ion-icon></a>
                            <a class="btn btn-outline-danger" href="javascript:Confirmar(@vFacultad("id_facultad"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Facultad</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Facultad</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        <label class="form" for="txtNombre_facultad">Nombre Facultad:</label>
                        <input class="form-control" type="text" name="txtNombre_facultad" id="NombreFacultad" placeholder="" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Facultad</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_facultad" id="pId_facultad" required />

                    <div class="form-group">
                        <label class="form" for="pNombre_facultad">Nombre Facultad:</label>
                        <input class="form-control" type="text" name="pNombre_facultad" id="pNombre_facultad" placeholder="Nombre Facultad" required />
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
            $('#id_facultad').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Facultad/Delete',
                data: {
                    id: $('#id_facultad').val()
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
                nombre_facultad: $("#NombreFacultad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Facultad/Create',
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
                url: '/Facultad/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_facultad").val(datos.pId_facultad);
                    $("#pNombre_facultad").val(datos.pNombre_facultad);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_facultad: $("#pId_facultad").val(),
                nombre_facultad: $("#pNombre_facultad").val()
            };

            $.ajax({
                type: "POST",
                url: '/Facultad/Edit',
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

