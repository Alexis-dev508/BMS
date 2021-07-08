$(document).ready( function () {
    $("#alert").hide();
    disabled();
    $("").DataTable();
    $.ajax({
            type:"post",
            url:"@Url.Action("FolioGastoServicio","Catalogos")" + "?id=" + "1",
            contentType:"html",
            success:function(respond){
                debugger
                $("#Folio").val(respond);
                var a = $("#Folio").val();
            }
        })
    $("#estab_list").change(function(){
        var estab = $(this).val();
        debugger
        $.ajax({
            type:"post",
            url:"@Url.Action("FolioGastoServicio","Catalogos")" + "?id=" + estab,
            contentType:"html",
            success:function(respond){
                debugger
                $("#Folio").val(respond);
                var a = $("#Folio").val();
                if(a == null || a ==""){
                    $("#alert").show(500);
                }else{
                    $("#alert").hide();
                }
            }
        })
    })
});
        function cod_prv(p, nom) {
            $("#Proveedor").val(p);
            $("#ProveedorN").val(nom);
            $("#modalDetalle").modal('hide');
        }
function equipo(){
        $("#datos").empty();
        $.ajax({
            type:"GET",
            url:"@Url.Action("EquipoGastoServicio","Catalogos")",
            success:function(data){
                $("#datos").append(data);
                $('#modalDetalle').modal('show');
            },
            error: function (xhr,ajaxOptions,thrownError){alert(xhr.responseText);}
        });
}
function prv(){
        $("#datos").empty();
        $.ajax({
            type:"GET",
            url:"@Url.Action("Proveedor","Catalogos")",
            success:function(data){
                $("#datos").append(data);
                $('#modalDetalle').modal('show');
            },
            error: function (xhr,ajaxOptions,thrownError){alert(xhr.responseText);}
        });
}

function onKeyDownEquipo(event) {

    var codigo = event.which || event.keyCode;

    if(codigo === 113){
      equipo();
    }
}
function onKeyDownPrv(event) {

    var codigo = event.which || event.keyCode;

    if(codigo === 113){
      prv();
    }
}
function onKeyDownServicio(event,serv) {
    var s = serv;
    var codigo = event.which || event.keyCode;

    if(codigo === 113){
      servicio(s);
    }
}
function servicioS(serv){
    $("#serV").val(serv);
        $("#datos").empty();
        $.ajax({
            type:"GET",
            url:"@Url.Action("Serv","Catalogos")",
            success:function(data){
                $("#datos").append(data);
                $('#modalDetalle').modal('show');
            },
            error: function (xhr,ajaxOptions,thrownError){alert(xhr.responseText);}
        });
}
function equipoGS(equipo,nombre,chofer,nombreCh,modelo,marca,serie,lectura,año,motor,placas){
    $('#Equipo').val(equipo);
    $('#EquipoN').val(nombre);
    $('#Chofer').val(chofer);
    $('#ChoferN').val(nombreCh);
    $('#Modelo').val(modelo);
    $('#Marca').val(marca);
    $('#Serie').val(serie);
    $('#Lectura').val(lectura);
    $('#Annio').val(año);
    $('#Motor').val(motor);
    $('#Placas').val(placas);
    $('#modalDetalle').modal('hide');
}
function serv1(servicio,nombre){
    var s = $("#serV").val(); //numero de servicio
    switch(s){
        case '1': 
            $('#servicio').val(servicio);
            $('#ServicioN').val(nombre);
            $('#modalDetalle').modal('hide');
            readon();
            break;
        case '2': 
            $('#servicio2').val(servicio);
            $('#ServicioN2').val(nombre);
            $('#modalDetalle').modal('hide');
            readon();
            break;
        case '3': 
            $('#servicio3').val(servicio);
            $('#ServicioN3').val(nombre);
            $('#modalDetalle').modal('hide');
            readon();
            break;
        case '4': 
            $('#servicio4').val(servicio);
            $('#ServicioN4').val(nombre);
            $('#modalDetalle').modal('hide');
            readon();
            break;
        case '5': 
            $('#servicio5').val(servicio);
            $('#ServicioN5').val(nombre);
            $('#modalDetalle').modal('hide');
            break;
    }

    
    
}
function calculos(){
    var servicio = $("#serV").val();

    var importe = $("#Importe").val();
        importe *=1;
    var importe2 = $("#Importe2").val();
        importe2 *=1;
    var importe3 = $("#Importe3").val();
        importe3 *=1;
    var importe4 = $("#Importe4").val();
        importe4 *=1;
    var importe5 = $("#Importe5").val();
        importe5 *=1;
    var descporcent = $("#DescuentoPorc").val();
        descporcent *=1;
    var descporcent2 = $("#DescuentoPorc2").val();
        descporcent2 *=1;
    var descporcent3 = $("#DescuentoPorc3").val();
        descporcent3 *=1;
    var descporcent4 = $("#DescuentoPorc4").val();
        descporcent4 *=1;
    var descporcent5 = $("#DescuentoPorc5").val();
        descporcent5 *=1;
    var descUni = $("#DescuentoUnidad").val();
        descUni *=1;
    var descUni2 = $("#DescuentoUnidad2").val();
        descUni2 *=1;
    var descUni3 = $("#DescuentoUnidad3").val();
        descUni3 *=1;
    var descUni4 = $("#DescuentoUnidad4").val();
        descUni4 *=1;
    var descUni5 = $("#DescuentoUnidad5").val();
        descUni5 *=1;
    var subneto = 0.0;
    var subneto2 = 0.0;
    var subneto3 = 0.0;
    var subneto4 = 0.0;
    var subneto5 = 0.0;
    var descuento = 0.0;
    var descuento2 = 0.0;
    var descuento3 = 0.0;
    var descuento4 = 0.0;
    var descuento5 = 0.0;
    var ISR = 0.0;
    var neto = 0.0;
    var iva = 0.0;
    var Ivaret = 0.0;
    var total = 0.0;
    
    //servicio1
    subneto = importe - descUni;
    if(descporcent * importe != 0){
        descuento = (descporcent * importe)/100;
        subneto = subneto - descuento;
    }
    
    $("#Neto1").val(subneto);
    //servicio 2
    subneto2 = importe2 - descUni2;
    if(descporcent2 * importe2 !=0){
        descuento2 =(descporcent2 * importe2)/100;
        subneto2 = subneto2 - descuento2;
    }
    $("#Neto2").val(subneto2);
    //servicio 3
    subneto3 = importe3 - descUni3;
    if(descporcent3 * importe3 !=0){
        descuento3 =(descporcent3 * importe3)/100;
        subneto3 = subneto3 - descuento3;
    }
    
    $("#Neto3").val(subneto3);
    //servicio 4
    subneto4 = importe4 - descUni4;
    if(descporcent4 * importe4 !=0){
        descuento4 =(descporcent4 * importe4)/100;
        subneto4 = subneto4 - descuento4;
    }
    
    $("#Neto4").val(subneto4);
    //servicio 5
    subneto5 = importe5 - descUni5;
    if(descporcent5 * importe5 !=0){
        descuento5 =(descporcent5 * importe5)/100;
        subneto5 = subneto5 - descuento5;
    }
    
    $("#Neto5").val(subneto5);
    //resultados
    neto = subneto + subneto2 + subneto3 + subneto4 + subneto5;
    if(neto * 16 != 0){
        iva = (neto * 16)/100;
    }
    if(neto * 10 != 0){
        ISR = (neto * 10)/100;
    }
    if((iva / 3) > 0){
        Ivaret = (iva / 3) * 2;
    }
    total = neto + iva ;
    total = total - ISR - Ivaret;
    $("#Neto").val(neto);
    $("#IVA").val(iva);
    $("#ISRRet").val(ISR);
    $("#IVARet").val(Ivaret);
    $("#total").val(total);


}
function confirm(){
    var prv = $("#Proveedor").val();
    var lect = $("#Lectura").val();
    var cant = $("#Cantidad").val();
    var importe = $("#Importe").val();
    var fol = $("#Folio").val();
    var eq = $("#Equipo").val();

    //validacion de servicio
    var servicio2 = $("#servicio2").val();
    var servicio3 = $("#servicio3").val();
    var servicio4 = $("#servicio4").val();
    var servicio5 = $("#servicio5").val();
    var lectura = $("#Lectura").val();
    var lectura2 = $("#Lectura2").val();
    var lectura3 = $("#Lectura3").val();
    var lectura4 = $("#Lectura4").val();
    var lectura5 = $("#Lectura5").val();
    var cantidad = $("#Cantidad").val();
    var cantida2 = $("#Cantidad2").val();
    var cantida3 = $("#Cantidad2").val();
    var cantida4 = $("#Cantidad2").val();
    var cantida5 = $("#Cantidad2").val();
    var importe = $("#Importe").val();
    var importe2 = $("#Importe2").val();
    var importe2 = $("#Importe3").val();
    var importe2 = $("#Importe4").val();
    var importe2 = $("#Importe5").val();

    //limpiar modal
    $("#datos1").empty();
    $("#footer").empty();
    if(fol == null || fol == ""){
        var data="<label>Seleccione un establecimiento.</label>";
            var dat ='<button type="button" class="btn btn-secondary" onclick="cerrar()">Cerrar</button>';
            $("#datos1").append(data);
            $("#footer").append(dat);
            $("#modalConfirm").modal('show');
    }else{
        if(prv == null || prv ==""){
             var data="<label>No ha seleccionado un proveedor. ¿Desea continuar?.</label>";
            var dat ='<input type="submit" value="Aceptar" class="btn btn-success my-2"/> <button type="button" class="btn btn-secondary" onclick="cerrar()">Cancelar</button>';
            $("#datos1").append(data);
            $("#footer").append(dat);
        $('#modalConfirm').modal('show');
        }else{
            if ( eq == null || eq == ""){
                var data="<label>Seleccione un Equipo.</label>";
                var dat ='<button type="button" class="btn btn-secondary" onclick="cerrar()">Cerrar</button>';
                $("#datos1").append(data);
                $("#footer").append(dat);
                $("#modalConfirm").modal('show');
            }else{
                if(servicio != null && servicio != ""){
                    if(lectura != '0'){
                        if(cantidad != '0'){
                            if(importe != '0'){
                                if(servicio2 != null && servicio2 != ""){
                                    if(lectura2 != '0'){
                                        if(cantidad2 != '0'){
                                            if(importe2 != '0'){
                                                if(servicio3 == null || servicio3 == ""){
                                                    $("#forma").submit();
                                                }else{
                                                    if(lectura3 != '0'){
                                                        if(cantidad3 != '0'){
                                                            if(importe3 != '0'){
                                                                if(servicio4 == null || servicio4 == ""){
                                                                    $("#forma").submit();
                                                                }else{
                                                                    if(lectura4 != '0'){
                                                                        if(cantidad4 != '0'){
                                                                            if(importe4 != '0'){
                                                                                if(servicio5== null || servicio5 == ""){
                                                                                    $("#forma").submit();
                                                                                }else{
                                                                                    if(cantidad5 != '0'){
                                                                                        if(lectura5 != '0'){
                                                                                            if(importe5 != '0'){
                                                                                                $("#forma").submit();
                                                                                            }else{
                                                                                                 modalSubmit('servicio5 (Importe)');
                                                                                            }
                                                                                        }else{
                                                                                            modalSubmit('servicio5 (Lectura)');
                                                                                        }
                                                                                    }else{
                                                                                        modalSubmit('servicio5 (Cantidad)');
                                                                                    }
                                                                                }
                                                                            }else{
                                                                                modalSubmit('servicio4 (Importe)');
                                                                            }
                                                                        }else{
                                                                            modalSubmit('servicio4 (Cantidad)');
                                                                        }
                                                                    }else{
                                                                        modalSubmit('servicio4 (Lectura)');
                                                                    }
                                                                }
                                                            }else{
                                                                modalSubmit('servicio3 (Importe)');
                                                            }
                                                        }else{
                                                            modalSubmit('servicio3 (Cantidad)');
                                                        }
                                                    }else{
                                                        modalSubmit('servicio3 (Lectura)');
                                                    }
                                                }
                                            }else{
                                                modalSubmit('servicio2 (Importe)');
                                            }
                                        }else{
                                            modalSubmit('servicio2 (Cantidad)');
                                        }
                                    }else{
                                        modalSubmit('servicio2 (Lectura)');
                                    }
                                }else{
                                    $("#forma").submit();
                                }
                            }else{
                                modalSubmit('servicio 1 (Importe)');
                            }
                        }else{
                            modalSubmit('servicio 1 (Cantidad)');
                        }
                    }else{
                        modalSubmit('servicio 1 (Importe)');
                    }
                    $("#forma").submit();
                }else{
                    var data="<label>Algunos campos obligatorios estan vacios Indique un servicio.</label>";
                    var dat ='<button type="button" class="btn btn-secondary" onclick="cerrar()">Cerrar</button>';
                    $("#datos1").append(data);
                    $("#footer").append(dat);
                    $("#modalConfirm").modal('show');
                }
                
            }
            
        }
    }
}
function modalSubmit(label){
    var data="<label>Algunos campos obligatorios estan vacios en el " + label + " .</label>";
    var dat ='<button type="button" class="btn btn-secondary" onclick="cerrar()">Cerrar</button>';
    $("#datos1").append(data);
    $("#footer").append(dat);
    $("#modalConfirm").modal('show');
}
function cerrar(){
    $('#modalConfirm').modal('hide');
    $("#datos1").empty();
    $("#footer").empty();
    }
function aceptar() {
     $("#forma").submit();
}
function readon(){
    var servicio = $("#servicio").val();
    var servicio2 = $("#servicio2").val();
    var servicio3 = $("#servicio3").val();
    var servicio4 = $("#servicio4").val();
    var servicio5 = $("#servicio5").val();
    if(servicio != null && servicio != ""){
        enabledS2();
    }
    if(servicio2 != null && servicio2 != ""){
        enabledS3();
    }
    
    if(servicio3 != null && servicio3 != ""){
        enabledS4();
    }
    if(servicio4 != null && servicio4 != ""){
        enabledS5();
    }
}
function disabled(){
    $('#servicio2').prop('readonly', true);
        $('#buscar2').prop('disabled',true);
        $('#Cantidad2').prop('readonly', true);
        $('#Importe2').prop('readonly', true);
        $('#DescuentoPorc2').prop('readonly', true);
        $('#DescuentoUnidad2').prop('readonly', true);
        $('#Lectura2').prop('readonly', true);
        $('#Neto2').prop('readonly', true);
        $('#notasserv2').prop('readonly', true);
        $('#servicio3').prop('readonly', true);
        $('#buscar3').prop('disabled',true);
        $('#Cantidad3').prop('readonly', true);
        $('#Importe3').prop('readonly', true);
        $('#DescuentoPorc3').prop('readonly', true);
        $('#DescuentoUnidad3').prop('readonly', true);
        $('#Lectura3').prop('readonly', true);
        $('#Neto3').prop('readonly', true);
        $('#notasserv3').prop('readonly', true);
        $('#servicio4').prop('readonly', true);
        $('#buscar4').prop('disabled',true);
        $('#Cantidad4').prop('readonly', true);
        $('#Importe4').prop('readonly', true);
        $('#DescuentoPorc4').prop('readonly', true);
        $('#DescuentoUnidad4').prop('readonly', true);
        $('#Lectura4').prop('readonly', true);
        $('#Neto4').prop('readonly', true);
        $('#notasserv4').prop('readonly', true);
        $('#servicio5').prop('readonly', true);
        $('#buscar5').prop('disabled',true);
        $('#Cantidad5').prop('readonly', true);
        $('#Importe5').prop('readonly', true);
        $('#DescuentoPorc5').prop('readonly', true);
        $('#DescuentoUnidad5').prop('readonly', true);
        $('#Lectura5').prop('readonly', true);
        $('#Neto5').prop('readonly', true);
        $('#notasserv5').prop('readonly', true);
}
function enabledS2(){
    //servicio2 
        $('#servicio2').prop('readonly', false);
        $('#buscar2').prop('disabled',false);
        $('#Cantidad2').prop('readonly', false);
        $('#Importe2').prop('readonly', false);
        $('#DescuentoPorc2').prop('readonly', false);
        $('#DescuentoUnidad2').prop('readonly', false);
        $('#Lectura2').prop('readonly', false);
        $('#Neto2').prop('readonly', false);
        $('#notasserv2').prop('readonly', false);
}
function enabledS3(){
    //servicio3
        $('#servicio3').prop('readonly', false);
        $('#buscar3').prop('disabled',false);
        $('#Cantidad3').prop('readonly', false);
        $('#Importe3').prop('readonly', false);
        $('#DescuentoPorc3').prop('readonly', false);
        $('#DescuentoUnidad3').prop('readonly', false);
        $('#Lectura3').prop('readonly', false);
        $('#Neto3').prop('readonly', false);
        $('#notasserv3').prop('readonly', false);
}
function enabledS4(){
    //servicio4
        $('#servicio4').prop('readonly', false);
        $('#buscar4').prop('disabled',false);
        $('#Cantidad4').prop('readonly', false);
        $('#Importe4').prop('readonly', false);
        $('#DescuentoPorc4').prop('readonly', false);
        $('#DescuentoUnidad4').prop('readonly', false);
        $('#Lectura4').prop('readonly', false);
        $('#Neto4').prop('readonly', false);
        $('#notasserv4').prop('readonly', false);
}
function enabledS5(){
    //servicio5
        $('#servicio5').prop('readonly', false);
        $('#buscar5').prop('disabled',false);
        $('#Cantidad5').prop('readonly', false);
        $('#Importe5').prop('readonly', false);
        $('#DescuentoPorc5').prop('readonly', false);
        $('#DescuentoUnidad5').prop('readonly', false);
        $('#Lectura5').prop('readonly', false);
        $('#Neto5').prop('readonly', false);
        $('#notasserv5').prop('readonly', false);
}