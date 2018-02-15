$(function () {
    $("#btnIngresar").click(function () {
        var info = { NombreUsuario : $("#NombreUsuario").val(), Contrasenia: $("#Contrasenia").val() };
        var url = "/Ingresar/Inicio";

        $.post(url, info).done(function (data) {
            if (data.mensaje == null) {
                window.location = data.url;
            } else {
                alert(data.mensaje);
            }
        });        
    });

    $("#btnCrearActividad").click(function () {
        var info = { DescripcionActividad: $("#DescripcionActividad").val(), ActIdUsuario: $("#ActIdUsuario").val() };
        var url = "/api/actividad";

        $.post(url, info).done(function (data) {
            var fila;
            $("#cuerpoTabla").empty();
            $.each(data, function (index, item) {
                fila += '<tr><td>' + item.DescripcionActividad + '</td><td><a href="/Horas/InicioHoras/?HorAct_IdActividad=' + item.idActividad + '">Agregar Horas</a></td></tr>';
            });
            $("#cuerpoTabla").append(fila);
        });
    });


    $("#btnCrearHoras").click(function () {
        var url = "/api/AgregarHoras";
        var info = { HorAct_Fecha: $("#HorAct_Fecha").val(), HorAct_CantidadHoras: $("#HorAct_CantidadHoras").val(), HorAct_IdActividad : $("#idHorActividad").val() };

        $.post(url, info).done(function (data) {
            if (data.mensaje == null) {
                var fila;
                $("#cuerpoTabla").empty();
                $.each(data, function (index, item) {
                    fila += "<tr><td>" + item.HorAct_Fecha + "</td ><td>" + item.HorAct_CantidadHoras + "</td></tr>";
                });
                $("#cuerpoTabla").append(fila);
            } else {
                alert(data.mensaje);
            }
        })
    });



});