@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Insumo</h3><br />
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Insumo</a>
    <input type="hidden" id="id_insumo" />
    <br />
    <br />
    <div class="table-responsive">
        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Código</th>
                    <th>Descripción</th>
                    <th>Tipo de Insumo</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                @For Each vInsumo In ViewData("Insumos")
                    @<tr>
                        <td>@vInsumo("id_insumo")</td>
                        <td>@vInsumo("descripcion")</td>
                        <td>@vInsumo("nombre_tip_insumo")</td>
                        <td>
                            <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vInsumo("id_insumo"))"><ion-icon name="document"></ion-icon></a>
                            <a class="btn btn-outline-danger" href="javascript:Confirmar(@vInsumo("id_insumo"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Insumo</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Insumo</h5>
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

                    <div class="form-group">
                        <label class="form">Tipo de Insumo:</label>
                        <select class="form-control" type="text" name="txtIdTipInsumo" id="IdTipInsumo" placeholder="" required>
                            @For Each row In ViewData("TiposInsumos")
                                @<option value="@row("id_tip_insumo")">@row("descripcion")</option>
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Insumo</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pId_insumo" id="pId_insumo" required />

                    <div class="form-group">
                        <label class="form" for="pDescripcion">Descripción:</label>
                        <input class="form-control" type="text" name="pDescripcion" id="pDescripcion" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form" for="pId_tip_insumo">Tipo de Insumo:</label>
                        <select class="form-control" type="text" name="pId_tip_insumo" id="pId_tip_insumo" placeholder="" required>
                            @For Each row In ViewData("TiposInsumos")
                                @<option value="@row("id_tip_insumo")">@row("descripcion")</option>
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
            $('#id_insumo').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Insumo/Delete',
                data: {
                    id: $('#id_insumo').val()
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
                id_tip_insumo: $("#IdTipInsumo").val()
            };

            $.ajax({
                type: "POST",
                url: '/Insumo/Create',
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
                url: '/Insumo/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_insumo").val(datos.pId_insumo);
                    $("#pDescripcion").val(datos.pDescripcion);
                    $("#pId_tip_insumo").val(datos.pId_tip_insumo);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_insumo: $("#pId_insumo").val(),
                descripcion: $("#pDescripcion").val(),
                id_tip_insumo: $("#pId_tip_insumo").val()
            };

            $.ajax({
                type: "POST",
                url: '/Insumo/Edit',
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