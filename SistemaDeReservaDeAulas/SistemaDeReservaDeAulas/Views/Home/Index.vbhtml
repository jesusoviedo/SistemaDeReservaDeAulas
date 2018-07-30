@Code
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

@If Session("rol") = "Administrador" Then

    @<div Class="row" >
        <div Class="col-md-4 market-update-gd">
            <div Class="market-update-block clr-block-1">
                <div Class="col-md-8 market-update-left">
                    <h3 id = "pendiente" > 0</h3>
                    <h4> Pendiente</h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div class="market-update-right">
                    <i class="fa fa-file-text-o"> </i>
                </div>
                <div class="clearfix"> </div>
            </div>
        </div>
        <div class="col-md-4 market-update-gd">
            <div class="market-update-block clr-block-2">
                <div class="col-md-8 market-update-left">
                    <h3 id="aprobado">0</h3>
                    <h4>Aprobado</h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div class="col-md-4 market-update-right">
                    <i class="fa fa-eye"> </i>
                </div>
                <div class="clearfix"> </div>
            </div>
        </div>
        <div class="col-md-4 market-update-gd">
            <div class="market-update-block clr-block-3">
                <div class="col-md-8 market-update-left">
                    <h3 id="rechazado">0</h3>
                    <h4>Rechazado</h4>
                    @*<h4>Other hand, we denounce</h4>*@
                </div>
                <div Class="col-md-4 market-update-right">
                    <i Class="fa fa-envelope-o"> </i>
                </div>
                <div Class="clearfix"> </div>
            </div>
        </div>
        <div Class="clearfix"> </div>
    </div>
    @<br />
    @<br />

End If

<h4>Mis reservas</h4>
<br />
<div class="btn-group btn-group-lg" role="group">
    <button type="button" class="btn btn-outline-info" id="btnreservaSol">Solicitadas</button>
    <button type="button" class="btn btn-outline-success" id="btnreservaApr">Aprovadas</button>
    <button type="button" class="btn btn-outline-danger" id="btnreservaRec">Rechazadas</button>
    <button type="button" class="btn btn-outline-dark" id="btnreservaAnu">Anuladas</button>
</div>
<br />
<br />

<table class="table table-hover table-bordered" id="reservaSol" >
    <thead>
        <tr>
            <th>Fecha solicitud</th>
            <th>Fecha reserva</th>
            <th>Horario</th>
            <th>Estado</th>
            <th>Aula</th>
            <th>N° Curso</th>
            <th>Materia</th>            
            <th>Acciones</th>
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
</table>

<table class="table table-hover table-bordered" id="reservaApr" >
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

<table class="table table-hover table-bordered" id="reservaRec" >
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

<table class="table table-hover table-bordered" id="reservaAnu" >
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
                <input hidden type="text" id="selectId_reserva"/>
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

                for (i = 0; i < datos.length; i++) {
                    document.getElementById("aprobado").innerHTML = datos[i].Aprobado;
                    document.getElementById("rechazado").innerHTML = datos[i].Rechazado;
                    document.getElementById("pendiente").innerHTML = datos[i].Pendiente;
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
        setInterval('ConsultarCantidadReservas()', 1000);
    }

</script>