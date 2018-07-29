@Code
    ViewData("Title") = "Pendiente"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Reservas Pendientes</h3>
    <input type="hidden" id="id_reserva" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Materia</th>
                <th>Profesor</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody id="reservas">

            @For Each vReserva In ViewData("ReservasPendientes")
                @<tr>
                    <td>@vReserva("fecha_solicitud")</td>
                    <td>@vReserva("fecha_reserva")</td>
                    <td>@vReserva("hora_inicio") - @vReserva("hora_fin")</td>
                    <td>@vReserva("nombre_materia")</td>
                    <td>@vReserva("nombre") @vReserva("apellido")</td>
                    <td>
                        <a class="btn btn-outline-info" href="javascript:InfoReserva(@vReserva("id_reserva"))">Ver detalle</a>
                        <a class="btn btn-outline-success" href="javascript:ConfirmarApro(@vReserva("id_reserva"))">Autorizar</a>
                        <a class="btn btn-outline-danger" href="javascript:ConfirmarRech(@vReserva("id_reserva"))">Rechazar</a>
                    </td>
                </tr>
            Next

        <tbody>
    </table>
</div>

<!-- Modal para agregar -->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Detalle de la solicitud de la reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form">Aula solicitada:</label>
                        <input class="form-control" type="text" name="txtNro_aula" id="txtNro_aula" placeholder="" required disabled />
                    </div>

                    <div class="form-group">
                        <label class="form">Capacidad del Aula:</label>
                        <input class="form-control" type="text" name="txtCapacidad" id="txtCapacidad" placeholder="" required disabled />
                    </div>

                    <div class="form-group">
                        <label class="form">Posee proyector:</label>
                        <input class="form-control" type="text" name="txtPosee_proyector" id="txtPosee_proyector" placeholder="" required disabled />
                    </div>

                    <div class="form-group">
                        <label class="form">N° Curso de la Materia:</label>
                        <input class="form-control" type="text" name="txtCurso" id="txtCurso" placeholder="" required disabled />
                    </div>

                    <div class="form-group">
                        <label class="form">Cantidad de Alumnos del Curso:</label>
                        <input class="form-control" type="text" name="txtCant_alumno" id="txtCant_alumno" placeholder="" required disabled />
                    </div>

                    <div class="form-group">
                        <label class="form">Observación:</label>
                        <input class="form-control" type="text" name="txtObservacion" id="txtObservacion" placeholder="" required disabled />
                    </div>

                    <label class="form"><b>Detalle de Insumos</b></label>
                    <table class="table table-hover table-bordered" id="myTable">
                        <thead>
                            <tr>
                                <th>Insumo</th>
                                <th>Cantidad</th>
                            </tr>
                        </thead>
                        <tbody id="detalleInsumos"><tbody>
                    </table>

                </div>
            </div>

            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
            </div>

        </div>
    </div>
</div>

<div class="modal fade" id="modal_apro" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                
                <h5 class="modal-title" id="exampleModalLabel">Autorizar Reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea autorizar esta Reserva?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="javascript:Aprobar()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="modal_rech" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Rechazar Reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea rechazar esta Reserva?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="javascript:Rechazar()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">

    function InfoReserva(idReserva) {
        $.ajax({
            url: '/Reserva/Consult',
            data: {
                id_reserva: idReserva
            },
            type: 'POST',
            dateType: 'JSON',
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                $("#txtCurso").val(datos.pNro_curso);
                ConsultarCurso(datos.pNro_curso);

                ConsultarAula(datos.pId_aula)

                $("#txtObservacion").val(datos.pObservacion);
                recuperarInsumoReserva(idReserva);
                $('#modal_agr').modal('show');
            },
            error: function () {
                alert("se ha producido un error.");
            }
        })
    }

    function ConsultarCurso(id) {
        var parametro = {
            id: id
        };
        $.ajax({
            type: "POST",
            url: '/Curso/Consult',
            data: parametro,
            dataType: "JSON",
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                //$("#pnro_curso").val(datos.pNro_curso);
                //$("#pid_aula").val(datos.pId_aula);
                //$("#pid_materia").val(datos.pId_materia);
                //$("#pid_turno").val(datos.pId_turno);
                //$("#pid_profesor").val(datos.pId_profesor);
                //$("#pid_profesor").val(1);
                $("#txtCant_alumno").val(datos.pCant_inscriptos);
                //$("#panho_lectivo").val(datos.pAnho_lectivo);
            },
            error: function () {
                alert("se ha producido un error cargar planilla.");
            }
        });
    }

    function ConsultarAula(id) {
        var parametro = {
            id: id
        };
        $.ajax({
            type: "POST",
            url: '/Aula/Consult',
            data: parametro,
            dataType: "JSON",
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                $("#txtNro_aula").val(datos.pNro_aula);
                //$("#pId_tipo_aula").val(datos.pId_tipo_aula);
                //$("#pId_piso").val(datos.pId_piso);
                $("#txtPosee_proyector").val(datos.pPosee_proyector);
                $("#txtCapacidad").val(datos.pCapacidad);
            },
            error: function () {
                alert("se ha producido un error.");
            }
        });
    }

    function ConfirmarApro(id) {
        $('#id_reserva').val(id);
        $('#modal_apro').modal('show');
    }

    function Aprobar() {
        var parametro = {
            id_reserva: $("#id_reserva").val(),
            operacion: "A"
        };

        $.ajax({
            type: "POST",
            url: '/Reserva/AprobarRechazar',
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

    function ConfirmarRech(id) {
        $('#id_reserva').val(id);
        $('#modal_rech').modal('show');
    }

    function Rechazar() {
        var parametro = {
            id_reserva: $("#id_reserva").val(),
            operacion: "R"
        };

        $.ajax({
            type: "POST",
            url: '/Reserva/AprobarRechazar',
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

    function recuperarInsumoReserva(idReserva) {

        var parametro = {
            id_reserva: idReserva
        };

        $.ajax({
            type: "POST",
            url: '/DetalleReserva/Consult',
            data: parametro,
            dataType: "json",
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                var row = "";
                for (i = 0; i < datos.length; i++) {

                    row += "<tr><td>" + datos[i].descripcion +
                            "</td><td>" + datos[i].cantidad +
                            "</td></tr>";
                }
                $("#detalleInsumos").html(row);
            },
            error: function () {
                alert("se ha producido un error cargar planilla.");
            }
        });
    }

</script>