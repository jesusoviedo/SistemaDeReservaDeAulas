@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code


<div class="container">
    <h3>Detalle de Curso</h3>
    <br />
    <div class="form-group">
        <select class="form-control" type="text" name="txtnro_curso" id="txtnro_curso" placeholder="" onchange="recuperar_diasPorCurso()" required>
            @For Each row In ViewData("Cursos")
                @<option value="@row("nro_curso")">@row("nro_curso") - @row("nom_materia")</option>
            Next
        </select>
    </div>



    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Agregar dias a Curso</a>
    <br />
    <br />
    <input type="hidden" id="nro_curso" />
    <input type="hidden" id="id_dia" />

    <div class="table-responsive">
        <table class="table table-hover table-bordered" id="myTable">
            <thead>
                <tr>
                    <th>Curso</th>
                    <th>Materia</th>
                    <th>Dia</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody id="DatosDetalleCurso">
            <tbody>
        </table>
    </div>
</div>


<!-- Modal para eliminar -->
<div class="modal fade" id="modal_conf" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Detalle curso</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                ¿Desea Eliminar el Registro?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-outline-secondary" data-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-outline-success" onclick="EliminarRegistro()">Aceptar</button>
            </div>
        </div>
    </div>
</div>

<!-- Modal para agregar -->
<div class="modal fade" id="modal_agr" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">

            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Crear Detalle curso</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">

                    <div class="form-group">
                        <label class="form">Cursos:</label>
                        <select class="form-control" type="text" name="pNro_curso" id="pNro_curso" placeholder="" required disabled>
                            @For Each row In ViewData("Cursos")
                                @<option value="@row("nro_curso")">@row("nro_curso")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Dias:</label>
                        <select class="form-control" type="text" name="pId_dia" id="pId_dia" placeholder="" required>
                            @For Each row In ViewData("Dias")
                                @<option value="@row("id_dia")">@row("descripcion")</option>
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


<script type="text/javascript">
        function Confirmar(nro_curso,id_dia) {
            $('#nro_curso').val(nro_curso);
            $('#id_dia').val(id_dia);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/DetalleCurso/Delete',
                data: {
                    nro_curso: $('#nro_curso').val(),
                    id_dia: $('#id_dia').val()
                },
                type: 'POST',
                dateType: 'JSON',
                success: function (retorno) {
                    recuperar_diasPorCurso();
                    $('#modal_conf').modal('hide');
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        };

        function AgregarRegistro() {

            var parametro = {
                nro_curso: $("#pNro_curso").val(),
                id_dia: $("#pId_dia").val()
            };

            $.ajax({
                type: "POST",
                url: '/DetalleCurso/Create',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    recuperar_diasPorCurso();
                },
                error: function () {
                    alert("se ha producido un error.");
                }
            });
        }


        function recuperar_diasPorCurso() {

            $("#pNro_curso").val($("#txtnro_curso").val());

            var parametro = {
                id: $("#pNro_curso").val()
            };
            $.ajax({
                type: "POST",
                url: '/DetalleCurso/Consult',
                data: parametro,
                dataType: "json",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    var row = "";
                    for (i = 0; i < datos.length; i++) {

                        row += "<tr><td>" + datos[i].nro_curso +
                                "</td><td>" + datos[i].nom_materia +
                                "</td><td>" + datos[i].descripcion +
                                "<td> <a class='btn btn-outline-danger' href='javascript:Confirmar(" + datos[i].nro_curso + "," + datos[i].id_dia + ")'><ion-icon name='trash'></ion-icon></a>" +
                                "</td></tr>";
                    }
                    $("#DatosDetalleCurso").html(row);
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }


</script>