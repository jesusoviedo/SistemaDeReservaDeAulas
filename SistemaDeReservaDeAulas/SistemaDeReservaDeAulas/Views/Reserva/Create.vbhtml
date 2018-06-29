@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Reserva de Aula</h3>
    <br />
    <br />

    <form action="/Reserva/Create" method="post">

        <div class="form-group">
            <label class="form" for="txtFecha_reserva">Fecha reserva:</label>
            <input class="form-control" type="date" name="txtFecha_reserva" id="txtFecha_reserva" placeholder="" required />
        </div>

        <div class="form-group">
            <label class="form" for="txtId_aula">Aula:</label>
            <select class="form-control" type="text" name="txtId_aula" id="txtId_aula" placeholder="" required>
                @For Each row In ViewData("Aulas")
                    @<option value="@row("id_aula")">@row("nro_aula")</option>
                Next
            </select>
        </div>

        <div class="form-group">
            <label class="form" for="txtNro_curso">Curso:</label>
            <select class="form-control" type="text" name="txtNro_curso" id="txtNro_curso" placeholder="" required>
                @For Each row In ViewData("Cursos")
                    @<option value="@row("nro_curso")">@row("nro_curso")</option>
                Next
            </select>
        </div>

        <div class="form-group">
            <label class="form" for="txtObservacion">Observación:</label>
            <textarea class="form-control" name="txtObservacion" id="txtObservacion" placeholder="" required></textarea>
        </div>

        <div class="form-group">
            <label class="form" for="txtHora_inicio">Hora inicio:</label>
            <input class="form-control" type="time" name="txtHora_inicio" id="txtHora_inicio" placeholder="" required />
        </div>

        <div class="form-group">
            <label class="form" for="txtHora_fin">Hora fin:</label>
            <input class="form-control" type="time" name="txtHora_fin" id="txtHora_fin" placeholder="" required />
        </div>

        <div class="form-group">
            <input type="submit" class="btn btn-outline-success" value="Guardar" />
            <input type="reset" class="btn btn-outline-secondary" value="Cancelar" />
        </div>
    </form>

</div>


<!-- Modal para agregar -->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Crear estado de Reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <div class="form-group">
                        @*<label class="form">Descripción:</label>*@
                        <input class="form-control" type="text" name="txtDescripcion" id="Descripcion" placeholder="Descripción" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar estado de Reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="txtId_estado_reserva" id="pId_estado_reserva" required />
                    <div class="form-group">
                        <label class="form" for="pDescripcion">Descripción:</label>
                        <input class="form-control" type="text" name="txtDescripcion" id="pDescripcion" placeholder="Descripción" required />
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

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        //function AgregarRegistro() {
        //    var parametro = {
        //        descripcion: $("#Descripcion").val()
        //    };

        //    $.ajax({
        //        type: "POST",
        //        url: '/EstadoReserva/Create',
        //        data: parametro,
        //        dataType: "JSON",
        //        success: function (msg) {
        //            location.reload();
        //        },
        //        error: function () {
        //            alert("se ha producido un error.");
        //        }
        //    });
        //}

        function ConsultarRegistro(id) {
            var parametro = {
                id: id
            };
            $.ajax({
                type: "POST",
                url: '/EstadoReserva/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pId_estado_reserva").val(datos.pId_estado_reserva);
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
                id_estado_reserva: $("#pId_estado_reserva").val(),
                descripcion: $("#pDescripcion").val()
            };

            $.ajax({
                type: "POST",
                url: '/EstadoReserva/Edit',
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

