
function pintar() {
    var valor2 = $("#txtnumber").val();
    if (valor2 === "") {
        alert("digitalize un numero positivo valido");
    } else {
        var htmlbtn = "";
        var mycontainer = $("#containerbtn");
        for (var i = 0; i < valor2; i++) {
            htmlbtn += '<input type="button"  onclick="alertname(' + i + ');" value="Boton: ' + i + '" /> </br>';

        }
        mycontainer.html(htmlbtn);
        
    }
}
function alertname(num) {
    alert("push:" + num);
}

function imprimir()
{
    var x;
    x = "Holacomo estas?";
    alert(x);
}