@Code
    ViewData("Title") = "Reserva de Aula"
    Layout = "~/Views/Template/Basic.vbhtml"
End Code



<div class="container">

    <h3>Aulas por piso</h3>
    <div>
        <a href="#" class="btn btn-primary">Piso 1</a>
        <a href="#" class="btn btn-primary">Piso 2</a>
        <a href="#" class="btn btn-primary">Piso 3</a>
        <a href="#" class="btn btn-primary">Piso 4</a>
        <a href="#" class="btn btn-primary">Piso 5</a>
        <a href="#" class="btn btn-primary">Piso 6</a>
        <a href="#" class="btn btn-primary">Piso 7</a>
    </div>
    <br />
    <table cellpadding="4" border="0">
        <tr>
            <th><h5>Estado</h5></th>
            <th><h5>Turno</h5></th>
        </tr>
        <tr>
            <td>
                <div class="form-group">
                    <a href="#" class="btn btn-dark">Todos</a>
                    <a href="#" class="btn btn-primary"><ion-icon name="add"></ion-icon>Disponible</a>
                    <a href="#" class="btn btn-secondary"><ion-icon name="add"></ion-icon>Reservado</a>
                    <a href="#" class="btn btn-dark"><ion-icon name="add"></ion-icon>Pendiente</a>
                    <button type="button" class="btn btn-outline-success">Fecha</button>
                    <a href="#" class="btn btn-primary">Modificar</a>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <h5>Seleccione el aula que desee verificar</h5>
    <div>
        @For Each row In ViewData("EstadosReservas")
            @if (row("descripcion") = "Disponible") Then
                @<a href="javascript:ver(@row("id_estado_reserva"),'Disponible')" Class="btn btn-primary">@row("id_estado_reserva")</a>
            ElseIf (row("descripcion") = "Reservado") Then
                @<a href="javascript:ver(@row("id_estado_reserva"),'Reservado')" Class="btn btn-secondary">@row("id_estado_reserva")</a>
            Else
                @<a href="javascript:ver(@row("id_estado_reserva"),'Pendiente')" Class="btn btn-dark">@row("id_estado_reserva")</a>
            End If
        Next
    </div>
    <br />
    <table cellpadding="4">
        <tr>
            <td class="align-top">
                <div id="1">
                    <iframe src="https://calendar.google.com/calendar/embed?height=600&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=q053spttd3e6ducss9u4aphjik%40group.calendar.google.com&amp;color=%23B1365F&amp;ctz=America%2FAsuncion" style="border-width:0" width="680" height="500" frameborder="0" scrolling="no"></iframe>
                </div>
            </td>
            <td></td>
            <td class="align-top">
                <div class="form-group">
                    <section>
                        <h4><strong>Descripción del aula Seleccionado</strong></h4>
                        <p>Esta aula cuenta con las siguientes caracteristícas</p>
                        <ul>
                            <li><strong>Aula N° : </strong><input id="tid"></li>
                            <li><strong>Cuenta con Proyector : </strong><text id="">asdasd</text></li>
                            <li><strong>Cuenta con Equipos : </strong><text id="">asdasd</text></li>
                            <li><strong>Tamaño del Aula : </strong><text id="">asdasd</text></li>
                            <li><strong>Tipo de Aula : </strong><text id="">asdasd</text></li>
                            <li><strong>Cantidad Máxima : </strong><text id="">asdasd</text></li>
                            <li><strong>Estado : </strong><input id="ss"></li>
                        </ul>
                    </section>
                    <a href="javascript:validar(ss.value)" class="btn btn-primary">Reservar</a>
                    <a href="#" class="btn btn-secondary">Cancelar</a>
                    <a href="#" class="btn btn-secondary">Salir</a>
                </div>
            </td>
        </tr>
    </table>
</div>



<script type="text/javascript">

            //Function() ver(id) {
            //    If (confirm('¿Desea ver aula '+id+'?')) {
            //        $.ajax({
            //            url: 'TipoUsuario/Delete',
            //            data: {
            //                id: id
            //            },
            //            type: 'GET',
            //            dateType: 'JSON',
            //            success: Function (retorno) {
            //                location.reload();
            //            },
            //            Error: Function () {
            //                alert("se ha producido un error.");
            //            }
            //        })
            //    }
            //}
        function ver(id,s) {
            $('#tid').val(id);
            $('#ss').val(s);
        }
       function validar(q) {
            if (q == "Reservado") {
                alert('El aula esta reservado');
            } else if (q == "Pendiente") {
                alert('La reserva esta al pendiente de aprobación');
            } else { alert('Reservado con exito!!!'); }
        }
</script>
