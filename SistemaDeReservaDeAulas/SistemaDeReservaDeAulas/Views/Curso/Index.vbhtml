@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code

<div class="container">
    <h3>Curso</h3>
    <a class="btn btn-outline-primary btn-lg btn-block" href="javascript:Agregar()"><ion-icon name="add"></ion-icon>Nuevo Curso</a>
    <input type="hidden" id="nro_curso" />
    <br />
    <br />
    <table class="table table-hover table-bordered" id="myTable">
        <thead>
            <tr>
                <th>Nro curso</th>
                <th>Aula</th>
                <th>Materia</th>
                <th>turno</th>
                <th>Profesor</th>
                <th>Cant inscriptos</th>
                <th>Año lectivo</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody>
            @For Each vCurso In ViewData("Cursos")
                @<tr>
                    <td>@vCurso("nro_curso")</td>
                    <td>@vCurso("nro_aula")</td>
                    <td>@vCurso("nom_materia")</td>
                    <td>@vCurso("nom_turno")</td>
                    <td>@vCurso("nombre")</td>
                    <td>@vCurso("cant_inscriptos")</td>
                    <td>@vCurso("anho_lectivo")</td>
                    <td>
                        <a class="btn btn-outline-warning" href="javascript:ConsultarRegistro(@vCurso("nro_curso"))"><ion-icon name="document" size="large"></ion-icon></a>
                        <br />
                        <br />
                        <a class="btn btn-outline-danger" href="javascript:Confirmar(@vCurso("nro_curso"))"><ion-icon name="trash" size="large"></ion-icon></a>
                        <br />
                        <br />
                        <a class="btn btn-outline-success" href="/DetalleCurso/"><ion-icon name="albums" size="large"></ion-icon></a>
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
                <h5 class="modal-title" id="exampleModalLabel">Eliminar Curso</h5>
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
                <h5 class="modal-title" id="exampleModalLabel">Crear curso</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">


                    <div class="form-group">
                        <label class="form">Aula:</label>
                        <select class="form-control" type="text" name="id_aula" id="id_aula" placeholder="" required>
                            @For Each row In ViewData("Aulas")
                                @<option value="@row("id_aula")">@row("nro_aula")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Materia:</label>
                        <select class="form-control" type="text" name="id_materia" id="id_materia" placeholder="" required>
                            @For Each row In ViewData("Materias")
                                @<option value="@row("id_materia")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Turno:</label>
                        <select class="form-control" type="text" name="id_turno" id="id_turno" placeholder="" required>
                            @For Each row In ViewData("Turnos")
                                @<option value="@row("id_turno")">@row("descripcion")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Profesor:</label>
                        <select class="form-control" type="text" name="id_profesor" id="id_profesor" placeholder="" required>
                            @For Each row In ViewData("Profesores")
                                @<option value="@row("id_profesor")">@row("nombre")</option>
                            Next
                        </select>
                    </div>

                    <div class="form-group">
                        <label class="form">Cantidad de inscriptos:</label>
                        <input class="form-control" type="text" name="cant_inscriptos" id="cant_inscriptos" placeholder="" required />
                    </div>

                    <div class="form-group">
                        <label class="form">Año lectivo:</label>
                        <input class="form-control" type="text" name="anho_lectivo" id="anho_lectivo" placeholder="" required />
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
                <h5 class="modal-title" id="exampleModalLabel">Modificar Curso</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>

            <div class="modal-body">

                <div class="form">
                    <input type="hidden" name="pnro_curso" id="pnro_curso" required />

                    <div class="form-group">
                        <div class="form-group">
                            <label class="form">Aula:</label>
                            <select class="form-control" type="text" name="pid_aula" id="pid_aula" placeholder="" required>
                                @For Each row In ViewData("Aulas")
                                    @<option value="@row("id_aula")">@row("nro_aula")</option>
                                Next
                            </select>
                        </div>

                        <div class="form-group">
                            <label class="form">Materia:</label>
                            <select class="form-control" type="text" name="pid_materia" id="pid_materia" placeholder="" required>
                                @For Each row In ViewData("Materias")
                                    @<option value="@row("id_materia")">@row("descripcion")</option>
                                Next
                            </select>
                        </div>

                        <div class="form-group">
                            <label class="form">Turno:</label>
                            <select class="form-control" type="text" name="pid_turno" id="pid_turno" placeholder="" required>
                                @For Each row In ViewData("Turnos")
                                    @<option value="@row("id_turno")">@row("descripcion")</option>
                                Next
                            </select>
                        </div>

                        <div class="form-group">
                            <label class="form">Profesor:</label>
                            <select class="form-control" type="text" name="pid_profesor" id="pid_profesor" placeholder="" required>
                                @For Each row In ViewData("Profesores")
                                    @<option value="@row("id_profesor")">@row("nombre")</option>
                                Next
                            </select>
                        </div>

                        <div class="form-group">
                            <label class="form">Cantidad de inscriptos:</label>
                            <input class="form-control" type="text" name="pcant_inscriptos" id="pcant_inscriptos" placeholder="" required />
                        </div>

                        <div class="form-group">
                            <label class="form">Año lectivo:</label>
                            <input class="form-control" type="text" name="panho_lectivo" id="panho_lectivo" placeholder="" required />
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
</div>



 <script type="text/javascript">
        function Confirmar(id) {
            $('#nro_curso').val(id);
            $('#modal_conf').modal('show');
        };

        function Agregar() {
            $('#modal_agr').modal('show');
        };

        function EliminarRegistro() {
            $.ajax({
                url: '/Curso/Delete',
                data: {
                    id: $('#nro_curso').val()
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
                id_aula: $("#id_aula").val(),
                id_materia: $("#id_materia").val(),
                id_turno: $("#id_turno").val(),
                id_profesor: $("#id_profesor").val(),
                cant_inscriptos: $("#cant_inscriptos").val(),
                anho_lectivo: $("#anho_lectivo").val()
            };

            $.ajax({
                type: "POST",
                url: '/Curso/Create',
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
                url: '/Curso/Consult',
                data: parametro,
                dataType: "JSON",
                success: function (msg) {
                    var datos = jQuery.parseJSON(msg);
                    $("#pnro_curso").val(datos.pNro_curso);
                    $("#pid_aula").val(datos.pId_aula);
                    $("#pid_materia").val(datos.pId_materia);
                    $("#pid_turno").val(datos.pId_turno);
                    $("#pid_profesor").val(datos.pId_profesor);
                    $("#pcant_inscriptos").val(datos.pCant_inscriptos);
                    $("#panho_lectivo").val(datos.pAnho_lectivo);
                    $('#modal_edi').modal('show');
                },
                error: function () {
                    alert("se ha producido un error cargar planilla.");
                }
            });
        }

        function ActualizarRegistro() {
            var parametro = {
                nro_curso: $("#pnro_curso").val(),
                id_aula: $("#pid_aula").val(),
                id_materia: $("#pid_materia").val(),
                id_turno: $("#pid_turno").val(),
                id_profesor: $("#pid_profesor").val(),
                cant_inscriptos: $("#pcant_inscriptos").val(),
                anho_lectivo: $("#panho_lectivo").val()
            };

            $.ajax({
                type: "POST",
                url: '/Curso/Edit',
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

