@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Persona</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nueva Persona</a>
    <input type="hidden" id="id_persona" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Código</th>
                <th>Documento</th>
                <th>Nombre y Apellido</th>
                <th>Fecha nacimiento</th>
                <th>Email</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vPersona In ViewData("Personas")
                @<tr>
                    <td>@vPersona("id_persona")</td>
                    <td>@vPersona("documento")</td>
                    <td>@vPersona("nombre") @vPersona("apellido")</td>
                    <td>@vPersona("fecha_naci")</td>
                    <td>@vPersona("email")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vPersona("id_persona"))"><ion-icon name="document"></ion-icon></a>
                        <a class="btn btn-outline-danger" href="javascript:Confirmar(@vPersona("id_persona"))"><ion-icon name="trash"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Persona</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear Persona</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        <label class="form">Documento:</label>
                        <input class="form-control" type="text" name="txtDocumento" id="txtDocumento" placeholder="" required />
                    </div>
                </div>

                <div class="form-group">
                    <label class="form">Tipo de documento:</label>
                    <select class="form-control" type="text" name="txtId_tipo_doc" id="txtId_tipo_doc" placeholder="" required>
                        @For Each row In ViewData("TiposDocumentos")
                            @<option value="@row("id_tipo_doc")">@row("descripcion")</option>
                        Next
                    </select>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Nombre:</label>
                        <input class="form-control" type="text" name="txtNombre" id="txtNombre" placeholder="" required />
                    </div>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Apellido:</label>
                        <input class="form-control" type="text" name="txtApellido" id="txtApellido" placeholder="" required />
                    </div>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Fecha nacimiento:</label>
                        <input class="form-control" type="date" name="txtFecha_naci" id="txtFecha_naci" placeholder="" required />
                    </div>
                </div>

                <div class="form">
                    <div class="form-group">
                        <label class="form">Email:</label>
                        <input class="form-control" type="email" name="txtEmail" id="txtEmail" placeholder="" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Persona</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                    <input type="hidden" name="pId_persona" id="pId_persona" required />

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Documento:</label>
                            <input class="form-control" type="text" name="pDocumento" id="pDocumento" placeholder="" required />
                        </div>
                    </div>

                    <div class="form-group">
                        <label class="form">Tipo de documento:</label>
                        <select class="form-control" type="text" name="pId_tipo_doc" id="pId_tipo_doc" placeholder="" required>
                            @For Each row In ViewData("TiposDocumentos")
                                @<option value="@row("id_tipo_doc")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Nombre:</label>
                            <input class="form-control" type="text" name="pNombre" id="pNombre" placeholder="" required />
                        </div>
                    </div>

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Apellido:</label>
                            <input class="form-control" type="text" name="pApellido" id="pApellido" placeholder="" required />
                        </div>
                    </div>

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Fecha nacimiento:</label>
                            <input class="form-control" type="date" name="pFecha_naci" id="pFecha_naci" placeholder="" required />
                        </div>
                    </div>

                    <div class="form">
                        <div class="form-group">
                            <label class="form">Email:</label>
                            <input class="form-control" type="email" name="pEmail" id="pEmail" placeholder="" required />
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
        
    var fecha;

        function Confirmar(id) {
            $('#id_persona').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Persona/Delete',
                data: {
                    id: $('#id_persona').val()
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
                nombre: $("#txtNombre").val(),
                apellido: $("#txtApellido").val(),
                documento: $("#txtDocumento").val(),
                id_tipo_doc: $("#txtId_tipo_doc").val(),
                fecha_naci: $("#txtFecha_naci").val(),
                email: $("#txtEmail").val()
            };

            $.ajax({
                type: "POST",
                url: '/Persona/Create',
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
                url: '/Persona/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_persona").val(datos.pId_persona);
                    $("#pDocumento").val(datos.pDocumento);
                    $("#pId_tipo_doc").val(datos.pId_tipo_doc);
                    $("#pNombre").val(datos.pNombre);
                    $("#pApellido").val(datos.pApellido);
                    fecha = datos.pFecha_naci;
                    $("#pFecha_naci").val(fecha.substring(0, 10));
                    $("#pEmail").val(datos.pEmail);                    
                    $('#modal_edi').modal('show');                    
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                id_persona: $("#pId_persona").val(),
                nombre: $("#pNombre").val(),
                apellido: $("#pApellido").val(),
                documento: $("#pDocumento").val(),
                id_tipo_doc: $("#pId_tipo_doc").val(),
                fecha_naci: $("#pFecha_naci").val(),
                email: $("#pEmail").val()
            };

            $.ajax({
                type: "POST",
                url: '/Persona/Edit',
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
