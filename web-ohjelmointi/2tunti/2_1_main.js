const button = document.getElementById('button');
const input = document.getElementById('teksti');
const output = document.getElementById('output');

function DoIt() {
    let teksti = input.value;
    let sanat = teksti.split(' ');

    let asana = sanat[0];
    let bsana = sanat[1];

    if(sanat[0].startsWith('min') || sanat[1].startsWith('min')) {
        asana = "s" + sanat[0].substring(1);
        bsana = "s" + sanat[0].substring(1);
    }
    output.innerHTML = "miksi" + asana + ' ' + bsana;
}