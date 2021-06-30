$(document).ready( function () {
    $("#alert").hide();
    $("#tabla").DataTable();
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
} );
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
function onKeyDownServicio(event) {

    var codigo = event.which || event.keyCode;
     
    if(codigo === 113){
      servicio();
    }
}
function servicio(){
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
    $('#servicio').val(servicio);
    $('#ServicioN').val(nombre);
    $('#modalDetalle').modal('hide');
}
/*function cod_prv(p,nom){
    $("#Proveedor").val(p);
    $("#ProveedorN").val(nom);
    $('#modalDetalle').modal('hide');
}*/
function calculos(){
    var importe = $("#Importe").val();
    var descporcent = $("#DescuentoPorc").val();
    var descUni = $("#DescuentoUnidad").val();
    var neto = 0.0;
    var descuento = 0.0;
    var iva = 0;
    var total = 0;
    neto = importe;
    if(descporcent * importe != 0){
        descuento = (descporcent * importe)/100;
    }
    neto = neto - descuento - descUni;
    if(neto * 16 !=0){
        iva = (neto * 16)/100;
    }
    total = neto + iva;
    $("#Neto").val(neto);
    $("#Neto1").val(neto);
    $("#IVA").val(iva);
    $("#total").val(total);
}
function confirm(){
    var prv = $("#Proveedor").val();
    if(prv == "" || prv == null){
        $('#modalConfirm').modal('show');
    }else{
        $("#form").submit();
    }
}
function cerrar(){
    $('#modalConfirm').modal('hide');
}
