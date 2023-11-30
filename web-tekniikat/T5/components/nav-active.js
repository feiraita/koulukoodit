var kuva = document.getElementsByClassName("bg-img")
var url = window.location.toString().split("/");
var sivu = url[url.length -1];

if (sivu == 'index.html') {
    console.log("iffin sisällä")
    $('#yleista').addClass('active');
    document.getElementById("otsikko").innerHTML = "Yleistä";
    document.getElementById("alaotsikko").innerHTML = "<span>El</span>ectronics done <span>well</span>";
}

else if (sivu == 'joustorahoitus.html') {
    $('#joustorahoitus').addClass('active');
    document.getElementById("otsikko").innerHTML = "Joustorahoitus";
    document.getElementById("alaotsikko").innerHTML = "Lorem";
}

else if (sivu == 'palvelut.html') {
    $('#palvelut').addClass('active');
    document.getElementById("otsikko").innerHTML = "Palvelut";
    document.getElementById("alaotsikko").innerHTML = "Asennukset ja tarvikkeet";
    kuva[0].style.backgroundImage = "linear-gradient(to bottom, rgba(21, 26, 57, 0.559), rgba(13, 18, 49, 0.52)), url('kuvat/Electrical-installation-915075-scaledd.jpg')";
}

else if (sivu == 'yhteystiedot.html') {
    $('#yhteystiedot').addClass('active');
    document.getElementById("otsikko").innerHTML = "Yhteystiedot";
    document.getElementById("alaotsikko").innerHTML = "El-Well Oy";
    kuva[0].style.backgroundImage = "linear-gradient(to bottom, rgba(21, 26, 57, 0.559), rgba(13, 18, 49, 0.52)), url(kuvat/Engineer-in-a-server-room-1076176-scaledd.jpg)";
}
