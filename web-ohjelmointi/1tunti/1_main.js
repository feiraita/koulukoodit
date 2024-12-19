function sayHello() {
    let fname = document.getElementById("fname").value;
    let lname = document.getElementById("lname").value;

    var eka1 = fname[0];
    var iso1 = eka1.toUpperCase();
    var loput1 = fname.substring(1);

    var eka2 = lname[0];
    var iso2 = eka2.toUpperCase();
    var loput2 = lname.substring(1);

    var nimi = iso1 + loput1 + " " + iso2 + loput2

    if(fname) {
        document.getElementById("result").innerHTML = "Hello " + nimi;
    }
}