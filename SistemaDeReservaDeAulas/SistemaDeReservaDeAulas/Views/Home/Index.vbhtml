@Code
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

@If Session("rol") = "Profesor" Then
    @<h4>Mis reservas</h4>
    @<br />
Else
    @<h4>Reservas del departamento de @Session("nombre_dpto")</h4>
    @<br />
End If

@If True Then
    @<div Class="row" >
        <div Class="col-md-3 market-update-gd" id="btnreservaSol">
            <div Class="market-update-block clr-block-1">
                <div Class="col-md-8 market-update-left">
                    <h3 id="pendienteN">0</h3>
                    <h4> Pendiente</h4>
                </div>

                <div class="clearfix"> </div>
            </div>
        </div>
         <div Class="col-md-3 market-update-gd" id="btnreservaRec">
             <div Class="market-update-block clr-block-2">
                 <div Class="col-md-8 market-update-left">
                     <h3 id="rechazadoN">0</h3>
                     <h4>Rechazado</h4>
                 </div>

                 <div class="clearfix"> </div>
             </div>
         </div>
         <div Class="col-md-3 market-update-gd" id="btnreservaApr">
             <div Class="market-update-block clr-block-3">
                 <div Class="col-md-8 market-update-left">
                     <h3 id="reservadoN"> 0</h3>
                     <h4> Reservado</h4>
                 </div>
                 <div class="clearfix"> </div>
             </div>
         </div>
        @If Session("rol") = "Profesor" Then
         @<div Class="col-md-3 market-update-gd" id="btnreservaAnu">
             <div Class="market-update-block clr-block btn-outline-dark" >
                 <div Class="col-md-8 market-update-left">
                     <h3 id = "anuladoN" > 0</h3>
                     <h4> Anulado</h4>
                 </div>

                 <div Class="clearfix"> </div>
             </div>
         </div>
        @<div Class="clearfix"> </div>
        End If
    </div>
    @<br />
    @<br />
End If

@If True Then
    @<Table Class="table table-hover table-bordered" id="reservaSol">
        <thead>
            <tr>
                <th> Fecha solicitud</th>
                <th> Fecha reserva</th>
                <th> Horario</th>
                <th> Estado</th>
                <th> Aula</th>
                <th> N° Curso</th>
                <th> Materia</th>
                @If Session("rol") = "Profesor" Then
                    @<th> Acciones</th>
                End If
                
            </tr>
        </thead>
        <tbody>
            @For Each vReservaSolicita In ViewData("ReservasSolicitas")
                @<tr>
                    <td>@vReservaSolicita("fecha_solicitud")</td>
                    <td>@vReservaSolicita("fecha_reserva")</td>
                    <td>@vReservaSolicita("hora_inicio") - @vReservaSolicita("hora_fin")</td>
                    <td>@vReservaSolicita("estado_reserva")</td>
                    <td>@vReservaSolicita("aula")</td>
                    <td>@vReservaSolicita("nro_curso")</td>
                    <td>@vReservaSolicita("nombre_materia")</td>

                     @If Session("rol") = "Profesor" Then
                        @<td>
                        <a Class="btn btn-outline-danger" href="javascript:ConfirmarAnulacion(@vReservaSolicita("id_reserva"))">Anular reserva</a>
                        </td>
                     End If

                </tr>
            Next
        <tbody>
    </Table>

    @<table class="table table-hover table-bordered" id="reservaApr">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Estado</th>
                <th>Aula</th>
                <th>N° Curso</th>
                <th>Materia</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaAprovada In ViewData("ReservasAprovadas")
                @<tr>
                    <td>@vReservaAprovada("fecha_solicitud")</td>
                    <td>@vReservaAprovada("fecha_reserva")</td>
                    <td>@vReservaAprovada("hora_inicio") - @vReservaAprovada("hora_fin")</td>
                    <td>@vReservaAprovada("estado_reserva")</td>
                    <td>@vReservaAprovada("aula")</td>
                    <td>@vReservaAprovada("nro_curso")</td>
                    <td>@vReservaAprovada("nombre_materia")</td>
                </tr>
            Next
        <tbody>
    </table>

    @<table class="table table-hover table-bordered" id="reservaRec">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Estado</th>
                <th>Aula</th>
                <th>N° Curso</th>
                <th>Materia</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaRechazada In ViewData("ReservasRechazadas")
                @<tr>
                    <td>@vReservaRechazada("fecha_solicitud")</td>
                    <td>@vReservaRechazada("fecha_reserva")</td>
                    <td>@vReservaRechazada("hora_inicio") - @vReservaRechazada("hora_fin")</td>
                    <td>@vReservaRechazada("estado_reserva")</td>
                    <td>@vReservaRechazada("aula")</td>
                    <td>@vReservaRechazada("nro_curso")</td>
                    <td>@vReservaRechazada("nombre_materia")</td>
                </tr>
            Next
        <tbody>
    </table>


    @If Session("rol") = "Profesor" Then
    @<table class="table table-hover table-bordered" id="reservaAnu">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Estado</th>
                <th>Aula</th>
                <th>N° Curso</th>
                <th>Materia</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaAnulada In ViewData("ReservasAnuladas")
                @<tr>
                    <td>@vReservaAnulada("fecha_solicitud")</td>
                    <td>@vReservaAnulada("fecha_reserva")</td>
                    <td>@vReservaAnulada("hora_inicio") - @vReservaAnulada("hora_fin")</td>
                    <td>@vReservaAnulada("estado_reserva")</td>
                    <td>@vReservaAnulada("aula")</td>
                    <td>@vReservaAnulada("nro_curso")</td>
                    <td>@vReservaAnulada("nombre_materia")</td>
                </tr>
            Next
        <tbody>
    </table>
    End If
End If


@*@If Session("rol") = "Aprovador" Or Session("rol") = "Administrador" Then

    @<Table Class="table table-hover table-bordered" id="reservaSol">
        <thead>
            <tr>
                <th> Fecha solicitud</th>
                <th> Fecha reserva</th>
                <th> Horario</th>
                <th> Estado</th>
                <th> Aula</th>
                <th> N° Curso</th>
                <th> Materia</th>
                <th> Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaSolicita In ViewData("ReservasSolicitas")
                @<tr>
                    <td>@vReservaSolicita("fecha_solicitud")</td>
                    <td>@vReservaSolicita("fecha_reserva")</td>
                    <td>@vReservaSolicita("hora_inicio") - @vReservaSolicita("hora_fin")</td>
                    <td>@vReservaSolicita("estado_reserva")</td>
                    <td>@vReservaSolicita("aula")</td>
                    <td>@vReservaSolicita("nro_curso")</td>
                    <td>@vReservaSolicita("nombre_materia")</td>
                    <td>
                        <a class="btn btn-outline-danger" href="javascript:ConfirmarAnulacion(@vReservaSolicita("id_reserva"))">Anular reserva</a>
                    </td>
                </tr>
            Next
        <tbody>
    </Table>

    @<table class="table table-hover table-bordered" id="reservaApr">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Estado</th>
                <th>Aula</th>
                <th>N° Curso</th>
                <th>Materia</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaAprovada In ViewData("ReservasAprovadas")
                @<tr>
                    <td>@vReservaAprovada("fecha_solicitud")</td>
                    <td>@vReservaAprovada("fecha_reserva")</td>
                    <td>@vReservaAprovada("hora_inicio") - @vReservaAprovada("hora_fin")</td>
                    <td>@vReservaAprovada("estado_reserva")</td>
                    <td>@vReservaAprovada("aula")</td>
                    <td>@vReservaAprovada("nro_curso")</td>
                    <td>@vReservaAprovada("nombre_materia")</td>
                </tr>
            Next
        <tbody>
    </table>

    @<table class="table table-hover table-bordered" id="reservaRec">
        <thead>
            <tr>
                <th>Fecha solicitud</th>
                <th>Fecha reserva</th>
                <th>Horario</th>
                <th>Estado</th>
                <th>Aula</th>
                <th>N° Curso</th>
                <th>Materia</th>
            </tr>
        </thead>
        <tbody>
            @For Each vReservaRechazada In ViewData("ReservasRechazadas")
                @<tr>
                    <td>@vReservaRechazada("fecha_solicitud")</td>
                    <td>@vReservaRechazada("fecha_reserva")</td>
                    <td>@vReservaRechazada("hora_inicio") - @vReservaRechazada("hora_fin")</td>
                    <td>@vReservaRechazada("estado_reserva")</td>
                    <td>@vReservaRechazada("aula")</td>
                    <td>@vReservaRechazada("nro_curso")</td>
                    <td>@vReservaRechazada("nombre_materia")</td>
                </tr>
            Next
        <tbody>
    </table>
End If*@

<!-- Modal para eliminar -->
<div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Anular Reserva</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea anular esta Reserva?
                <input hidden type="text" id="selectId_reserva" />
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="javascript: AnularReserva()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">

    $("#btnreservaSol").click(function (i) {
        $("#reservaSol").show();
        $("#reservaApr").hide();
        $("#reservaRec").hide();
        $("#reservaAnu").hide();

        $(document).ready(function () {
            $('#reservaSol').DataTable();
        });
        $('#reservaApr').parents('div.dataTables_wrapper').first().hide();
        $('#reservaRec').parents('div.dataTables_wrapper').first().hide();
        $('#reservaAnu').parents('div.dataTables_wrapper').first().hide();
        $('#reservaSol').parents('div.dataTables_wrapper').first().show();
    });

    $("#btnreservaApr").click(function (i) {
        $("#reservaSol").hide();
        $("#reservaApr").show();
        $("#reservaRec").hide();
        $("#reservaAnu").hide();

        $(document).ready(function () {
            $('#reservaApr').DataTable();
        });
        $('#reservaSol').parents('div.dataTables_wrapper').first().hide();
        $('#reservaRec').parents('div.dataTables_wrapper').first().hide();
        $('#reservaAnu').parents('div.dataTables_wrapper').first().hide();
        $('#reservaApr').parents('div.dataTables_wrapper').first().show();
    });

    $("#btnreservaRec").click(function (i) {
        $("#reservaSol").hide();
        $("#reservaApr").hide();
        $("#reservaRec").show();
        $("#reservaAnu").hide();

        $(document).ready(function () {
            $('#reservaRec').DataTable();
        });
        $('#reservaSol').parents('div.dataTables_wrapper').first().hide();
        $('#reservaApr').parents('div.dataTables_wrapper').first().hide();
        $('#reservaAnu').parents('div.dataTables_wrapper').first().hide();
        $('#reservaRec').parents('div.dataTables_wrapper').first().show();
    });

    $("#btnreservaAnu").click(function (i) {
        $("#reservaSol").hide();
        $("#reservaApr").hide();
        $("#reservaRec").hide();
        $("#reservaAnu").show();

        $(document).ready(function () {
            $('#reservaAnu').DataTable();
        });

        $('#reservaSol').parents('div.dataTables_wrapper').first().hide();
        $('#reservaApr').parents('div.dataTables_wrapper').first().hide();
        $('#reservaRec').parents('div.dataTables_wrapper').first().hide();
        $('#reservaAnu').parents('div.dataTables_wrapper').first().show();
    });

    function ConfirmarAnulacion(id) {
        $('#selectId_reserva').val(id);
        $('#modal_conf').modal('show');
    };

    function AnularReserva() {
        $.ajax({
            url: '/Reserva/Anular',
            data: {
                id_reserva: $('#selectId_reserva').val()
            },
            type: 'POST',
            dateType: 'JSON',
            success: function (retorno) {
                location.reload();
            },
            error: function () {
                alert("se ha producido un error.");
            }
        });
    };

    function ConsultarCantidadReservas() {
        $.ajax({
            type: "POST",
            url: '/Reserva/ConsultarCantidadReserva',
            data: null,
            dataType:  "JSON",
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                console.log(datos);
                for (i = 0; i < datos.length; i++) {
                    document.getElementById("reservadoN").innerHTML = datos[i].Aprobado;
                    document.getElementById("rechazadoN").innerHTML = datos[i].Rechazado;
                    document.getElementById("pendienteN").innerHTML = datos[i].Pendiente;

                    if (datos[i].Anulado >= 0) {
                        document.getElementById("anuladoN").innerHTML = datos[i].Anulado;
                    }
                }

            },
            error: function () {
                console.log("se ha producido un error cargar planilla.");
            }
        });
    }

    window.onload = Function()
    {
        $("#reservaSol").hide();
        $("#reservaApr").hide();
        $("#reservaRec").hide();
        $("#reservaAnu").hide();
        setInterval('ConsultarCantidadReservas()', 1500);
    }

</script>