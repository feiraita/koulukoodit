const output = document.getElementById("output");
const input = document.getElementById("input");

function Submit() {
    let name = document.getElementById('fullName').value;
    let pass = document.getElementById('password').value;
    let word = document.getElementById('password2').value;
    let gender = document.querySelectorAll('input[name=gender]'); 
    let hobbies = document.getElementsByName('hobbies');
    let birthdate = document.getElementById('birthdate').value;
    let height = document.getElementById('heightNum').value;
    let color = document.getElementById('color').value;
    let country = document.getElementById('country');
    let profession = document.getElementById('profession').value;
    let message = document.getElementById('message').value;

    const nameError = document.getElementById("name-error");
    const passwordError = document.getElementById("password-error");
    const genderError = document.getElementById("gender-error");
    const messageError = document.getElementById("message-error");

    let isValid = true;
    output.innerHTML = "";
    var regex = /^[a-zA-Z0-9_,.\-:;?!]+$/;
    let sukupuoli = "";
    let harrastukset = [];

    let nameOutput = "<h4>Full name: </h4>";
    let passwordOutput = "<h4>Password: </h4>";
    let genderOutput = "<h4>Gender: </h4>"
    let hobbiesOutput = "<h4>Hobbies: </h4>";
    let heightOutput = "<h4>Height: </h4>";
    let birthdateOutput = "<h4>Birthdate: </h4>";
    let colorOutput = "<h4>Favorite color: </h4>" + color.toString();
    let countryOutput = "<h4>Home country: </h4>" + country.value;
    let professionOutput = "<h4>Profession: </h4>";
    let messageOutput = "<h4>Message: </h4>";

    nameError.textContent = "";
    passwordError.textContent = "";
    genderError.textContent = "";
    messageError.textContent = "";

    /*Sukupuoli */
    for(let i = 0; i < gender.length; i++) {
        if(gender[i].checked) { 
            sukupuoli = gender[i].value;
            genderOutput += sukupuoli;
            genderError.textContent = "";
            break;
        } 
        else { genderError.textContent = "Please select your gender"; }
    }

    /* Harrastukset */
    for (let hobby of hobbies) {
        if(hobby.checked) { harrastukset.push(hobby.value); }
    }
    if(harrastukset.length == 0) {
        hobbiesOutput += "Not defined";
    } else { hobbiesOutput += harrastukset.join(", "); }

    /* Syntymäpäivä */
    if(birthdate == "") {
        birthdateOutput += "Not defined";
    } else { birthdateOutput += birthdate.toString(); }

    /* Ammatti */
    if (profession === "") {
        professionOutput += "Not defined";
    } else { professionOutput += profession; }

    /* Pituus */
    if(height.length == 0) {
        heightOutput += "Not defined";
    } else { heightOutput += height + " cm"; }

    /* Nimi */
    if (name === "" || /\d/.test(name)) {
        nameError.textContent = "Please enter your name properly.";
        
    } else { nameOutput += name; }

    /* Salasana */
    if (pass.length == 0 || pass.length < 8) {
        passwordError.textContent = "Please enter a password with at least 8 characters.";
    } else if(!pass.match(regex)) {
        passwordError.textContent = "Please enter a password with the correct characters.";
    } else if (word.length == 0 || word != pass) {
        passwordError.textContent = "Please make sure the passwords match.";   
    } else { passwordOutput += word; }

    /* Viesti */
    if (message.length == 0) {
        messageError.textContent = "Please type a message.";
    } else { messageOutput += message; }

    if(nameError.innerHTML.length == 0 && passwordError.innerHTML.length == 0 && 
    genderError.innerHTML.length == 0 && messageError.innerHTML.length == 0) {
        isValid = true;
    } else { isValid = false; }

    /* Tulostus */
    if(isValid) {
        if(input.style.display == "block") {
            output.style.display = "none";
            input.style.display ="block";
        } else {
            output.style.display ="block";
            input.style.display = "none";
            output.innerHTML += "<h2>Output</h2>" +
            "<div class='row'>" +
               "<div class='column'>" +
                    nameOutput + genderOutput + 
                "</div>" +
                "<div class='column'>" +
                    passwordOutput + hobbiesOutput + 
                "</div>"+
            "</div>" + 
            "<div class='row'>" +
               "<div class='column'>" +
                    birthdateOutput + colorOutput + 
                "</div>" +
                "<div class='column'>" +
                    heightOutput +
                "</div>"+
            "</div>" + 
            "<div class='row'>"+
                "<div class='column'>" +
                    countryOutput  + 
                "</div>" +
                "<div class='column'>" +
                    professionOutput + 
                "</div>" +
            "</div>" +
            "<p>" + messageOutput + "</p>" + 
            "<button id='back' type='button' onclick='window.location.reload();'><h4>Go back</h4></button>";
        }      
    }   
}