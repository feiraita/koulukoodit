async function getData(file) {
    let myObject = await fetch(file);
    let myText = await myObject.text();
    
    const out = document.getElementById("out");
    out.innerHTML = myText;
}

async function getDataJson(file) {
    let myObject = await fetch(file);
    let myText = await myObject.json();
    const out = document.getElementById("out");

    let s = "";
    for(let index = 0; index < myText.features.length; index++) {
        s += myText.features[index].properties.name + "<br>";
    }

    out.innerHTML = s;
}