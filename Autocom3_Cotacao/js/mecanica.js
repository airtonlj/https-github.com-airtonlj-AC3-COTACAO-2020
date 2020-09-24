
function selectText(containerid) {
    if (document.selection) {
        var range = document.body.createTextRange();
        range.moveToElementText(document.getElementById(containerid));
        range.select();
        range.execCommand('copy')
    } else if (window.getSelection) {
        var range = document.createRange();
        range.selectNode(document.getElementById(containerid));
        window.getSelection().addRange(range);
    }
}

function formatar(src, mask) {
    var i = src.value.length;
    var saida = mask.substring(0, 1);
    var texto = mask.substring(i)
    if (texto.substring(0, 1) !== saida) {
        src.value += texto.substring(0, 1);
    }
}

function valorDecimal(obj, e) {
    var tecla = (window.event) ? e.keyCode : e.which;
    if (tecla === 8 || tecla === 0)
        return true;
    if (tecla !== 44 && tecla < 48 || tecla > 57)
        return false;
}

function SomenteNumero(e) {
    var tecla = (window.event) ? event.keyCode : e.which;
    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla === 8 || tecla === 0) return true;
        else return false;
    }
}

function valorPadrao(obj) {
    if (obj.value === "") {
        obj.value = "0";
        return true;
    }
}