function empty() {
  document.getElementById("message").value = "";
}

/* Pituus */
var slider = document.getElementById('heightSlider');
var num = document.getElementById('heightNum');
slider.addEventListener('input', function (e) {
  num.value = e.target.value;
});
num.addEventListener('input', function (e) {
  slider.value = e.target.value;
});

/* Syntymäpäivän rajaus */
var birthdate = document.getElementById('birthdate');
birthdate.max = new Date().toISOString().split("T")[0];

/* Kotimaa valikko */
var maaLista = ['Sweden', 'Norway', 'Denmark', 'Iceland'];
var maat = document.getElementById('country');

for (var i = 0; i < maaLista.length; i++) {
    var option = document.createElement("option");
    option.name = "country";
    option.value = maaLista[i];
    option.text = maaLista[i];
    maat.appendChild(option);
}

  /* Ammatti valikko */
  var ammattiLista = ['Teacher', 'Nurse', 'Plumber', 'Bureaucrat'];
  var ammatit = document.getElementById('professions');
  
  for (var j = 0; j < ammattiLista.length; j++) {
      var dataOption = document.createElement("option");
      dataOption.value = ammattiLista[j];
      dataOption.text = ammattiLista[j];
      ammatit.appendChild(dataOption);
  }