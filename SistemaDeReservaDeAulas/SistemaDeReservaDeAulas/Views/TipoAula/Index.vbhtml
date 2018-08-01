@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Tipo de Aula</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo tipo de Aula</a>
    <input type="hidden" id="id_tipo_aula" />
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
                @For Each vTipoAula In ViewData("TiposAulas")
                    @<tr>
                        <td>@vTipoAula("id_tipo_aula")</td>
                        <td>@vTipoAula("descripcion")</td>
                        <td>
                            <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vTipoAula("id_tipo_aula"))"><ion-icon name="document"></ion-icon></a>
                            <a class="btn btn-outline-danger" href="javascript:Confirmar(@vTipoAula("id_tipo_aula"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar tipo de Aula</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear tipo de Aula</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        <label class="form" for="txtDescripcion">Descripción:</label>
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar tipo de Aula</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="txtId_tipo_aula" id="pId_tipo_aula" required />
                    <div class="form-group">
                        <label class="form" for="pDescripcion">Descripción:</label>
                        <input class="form-control" type="text" name="txtDescripcion" id="pDescripcion" placeholder="" required />
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
            $('#id_tipo_aula').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/TipoAula/Delete',
                data: {
                    id: $('#id_tipo_aula').val()
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
                descripcion: $("#Descripcion").val()
            };

            $.ajax({
                type: "POST",
                url: '/TipoAula/Create',
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
                url: '/TipoAula/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_tipo_aula").val(datos.pId_tipo_aula);
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
                id_tipo_aula: $("#pId_tipo_aula").val(),
                descripcion: $("#pDescripcion").val()
            };

            $.ajax({
                type: "POST",
                url: '/TipoAula/Edit',
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


