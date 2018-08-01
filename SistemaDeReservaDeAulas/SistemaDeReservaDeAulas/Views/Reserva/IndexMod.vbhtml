@Code
    ViewData("Title") = "Create"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Reserva de Aula</h3>
    <br />

    <form action="javascript:BuscarAulasDisponibles()">
        <table>
            @*<thead>


            </thead>*@
            <tbody>
                <tr>
                    <td>
                        <div style=" width:100%">
                            <label class="form" for="txtFechaReserva">FechaReserva:</label>
                            <input class="form-control" type="date" name="txtFecha_reserva" id="txtFecha_reserva" placeholder="" required />
                        </div>
                    </td>
                    <td>
                        <div style=" width:300px">
                            <label class="form" for="txtHora_inicio">Hora inicio:</label>
                            <input class="form-control" type="time" name="txtHora_inicio" id="txtHora_inicio" placeholder="" required />
                        </div>
                    </td>
                    <td>
                        <div style=" width:300px">
                            <label class="form" for="txtHora_fin">Hora fin:</label>
                            <input class="form-control" type="time" name="txtHora_fin" id="txtHora_fin" placeholder="" required />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div style="margin-top: 0.5rem; width:100% ">
                            <label class="form" for="txtId_tipo_aula">Tipo de Aula:</label>
                            <select class="form-control" type="text" name="txtId_tipo_aula" id="txtId_tipo_aula" placeholder="" required>
                                @For Each row In ViewData("TiposAulas")
                                    @<option value="@row("id_tipo_aula")">@row("descripcion")</option>
                                Next
                            </select>
                        </div>
                    </td>
                    <td>
                        <div style="margin-top: 0.5rem;  width:300px">
                            <label class="form" for="txtNro_curso">Curso:</label>
                            <select class="form-control" type="text" name="txtNro_curso" id="txtNro_curso" placeholder="" required>
                                @For Each row In ViewData("Cursos")
                                    @<option value="@row("nro_curso")">@row("nro_curso")</option>
                                Next
                            </select>
                        </div>
                    </td>
                    <td>
                        <div style="margin-top: 0.5rem; width:300px">
                            <label class="form" for="txtCantidad">Cantidad de Alumnos:</label>
                            <input type="text" class="form-control" name="txtCantidad" id="txtCantidad" placeholder="" required>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="col-4">
                        
                    </td>
                    <td class="col-4"></td>
                    <td class="col-4"><input type="submit" style="margin-bottom: 0.5rem;
    margin-top: 0.5rem;" class="btn btn-outline-success btn-lg" value="Buscar" " />
<input type="reset" style="margin-bottom: 0.5rem;
    margin-top: 0.5rem;" class="btn btn-outline-secondary btn-lg" value="Cancelar" /></td>
                </tr>

            <tbody>
        </table>

    </form>


        <div class="card-footer" id="listaAulas" hidden>

            <br />
            <h3>Aulas disponibles</h3>
            <br />

            <div class="form-group">
                <a class="btn btn-outline-info btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Agregar Insumo</a>
            </div>

            <div class="form-group">
                <label class="form-la" for="txtObservacion">Observación:</label>
                <textarea class="form-control" name="txtObservacion" id="txtObservacion" rows="5" placeholder=""></textarea>
            </div>

            <div class="form-group">

                <table class="table table-bordered table-hover" id="myTable">
                    <thead>
                        <tr>
                            <th>Piso</th>
                            <th>Nro. Aula</th>
                            <th>Capacidad</th>
                            <th>Proyector</th>
                            <th>Confirmar</th>
                        </tr>
                    </thead>
                    <tbody id="datosAulasDisponibles"></tbody>
                </table>
            </div>




        </div>


</div>


<!-- mensaje de confirmacion -->
<div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Reserva de Aula</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Solicitud de Reserva realizada correctamente
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal" onclick="javascript:LimpiarTodo()">Aceptar</button>
            </div>
        </div>
    </div>
</div>


<!-- Modal para agregar insumos-->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Agregar Insumo</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form" for="txtId_insumo">Insumo:</label>
                        <select class="form-control" type="text" name="txtId_insumo" id="txtId_insumo" placeholder="" required >
                            @For Each row In ViewData("Insumos")
                                @<option value="@row("id_insumo")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form" for="txtCantidad">Cantidad</label>
                        <input class="form-control" type="number" name="txtCantidad" id="txtCantidad" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <table class="table table-bordered table-hover">
                            <tr>
                                <th>Insumo</th>
                                <th>Cantidad</th>
                                <th></th>
                            </tr>
                            <tbody id="datosInsumo"></tbody>
                        </table>
                    </div>

                </div>
            </div>

            <div class="modal-footer">                
                <button type="button" class="btn btn-outline-success" onclick="AgregarInsumo()">Agregar</button>
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
            </div>

        </div>
    </div>
</div>


<script type="text/javascript">

    var cont = 0;
    var array_insumo = [];
    var array_cantidad = [];

    function BuscarAulasDisponibles() {

        var parametro = {
            fecha_reserva: $("#txtFecha_reserva").val(),
            id_tipo_aula: $("#txtId_tipo_aula").val(),
            cantidadAlumno: $("#txtCantidadAlumno").val(),
            hora_inicio: $("#txtHora_inicio").val(),
            hora_fin: $("#txtHora_fin").val()
        };

        document.getElementById("listaAulas").removeAttribute("hidden");

        $.ajax({
            type: "POST",
            url: '/Reserva/ConsultarAulasDisponibles',
            data: parametro,
            dataType: "json",
            success: function (msg) {
                var datos = jQuery.parseJSON(msg);
                var row = "";
                for (i = 0; i < datos.length; i++) {

                    row += "<tr><td>" + datos[i].piso +
                            "</td><td>" + datos[i].aula +
                            "</td><td>" + datos[i].capacidad +
                            "</td><td>" + datos[i].proyector +
                            "<td> <a class='btn btn-outline-primary' href='javascript:SolicitarReserva(" + datos[i].id_aula + ")'>Solicitar</a>" +
                            "</td></tr>";
                }
                $("#datosAulasDisponibles").html(row);
            },
            error: function () {
                alert("se ha producido un error cargar planilla.");
            }
        });
    }

    function SolicitarReserva(id_aula) {   

        var parametro = {
            fecha_reserva: $("#txtFecha_reserva").val(),
            id_aula: id_aula,
            nro_curso: $("#txtNro_curso").val(),
            observacion: $("#txtObservacion").val(),
            hora_inicio: $("#txtHora_inicio").val(),
            hora_fin: $("#txtHora_fin").val(),
            insumos: array_insumo.filter(Boolean),
            cant_insumos: array_cantidad.filter(Boolean)
        };

        $.ajax({
            type: "POST",
            url: '/Reserva/Create',
            data: parametro,
            dataType: "JSON",
            success: function (msg) {
                
                $('#modal_conf').modal('show');
               
            },
            error: function () {
                alert("se ha producido un error.");
            }
        });        
    }

    function LimpiarTodo() {
        location.reload();
    };

    function Agregar() {
        $('#modal_agr').modal('show');
    };

    function AgregarInsumo() {
        
        var row = "";
        row = '<tr id="fila' + cont + '"><td>' + $('#txtId_insumo option:selected').text() +
               
            '</td><td>' + $("#txtCantidad").val() +

            '</td><td><button type="button" class="btn btn-danger" onclick="eliminarFilaInsumo(' + cont + ');" ><ion-icon name="trash"></ion-icon></button></td>' +

            '<input type="hidden" name="idArticulo" value="' + $("#txtId_insumo").val() + '">' +            

            '</td></tr>';

        $("#datosInsumo").append(row);
        array_insumo[cont] = $("#txtId_insumo").val();
        array_cantidad[cont] = $("#txtCantidad").val();
        cont++;

        $("#txtCantidad").val("");
    }

    function eliminarFilaInsumo(index) {
        $("#fila" + index).remove();
        delete array_insumo[index];
        delete array_cantidad[index];
    }

</script>

