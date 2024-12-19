//Haetaan JSON
var url = getJson('questions.json');
function getJson(url) {
  return JSON.parse($.ajax({
      type: 'GET',
      url: 'questions.json',
      dataType: 'json',
      global: false,
      async:false,
      success: function(data) {
          return data;
      }
  }).responseText);
}

//Tehdään kysymyskentät
var allQuestions = url;
const createQuestion = ({ question, options }, i) => {
  const field = document.createElement('div');
  field.classList.add('card', 'w-100', 'my-4', 'p-2', 'rounded', 'd-flex', 'align-items-center');
  field.innerHTML = `<h5 class="header text-center">Question ${i}</h5>
    <p class="card-title text-center">${question}</p>
    ${options.map(option => `<div class="w-75 rounded-pill m-1">
      <input type="radio" id="option-${i}-${option}" name="question-${i}" value="${option}">
      <label class="text-center rounded" for="option-${i}-${option}">${option}</label>
    </div>`).join('')}
    `;
  return field;
}

//Luodaan quiz
const createQuizz = () => {
  const form = document.getElementById('questions');
  const quizz = allQuestions;
  const questions = Object.values(quizz);

  questions.forEach((question, i) => {
    const field = createQuestion(question, i + 1);
    form.appendChild(field);
  });
}

//Luodaan submit nappi
const createButton = () => {
  const form = document.getElementById('questions');
  form.innerHTML += "<div class='d-flex justify-content-center'><button onclick='submit()' class='w-50 py-2 mb-2 rounded'>Submit</button></div>";
}

//Ikkunan uudelleen lataus
function refresh() {
  window.location.reload();
}

//Formin lähetys
function submit() {
  const form = document.getElementById('questions');
  const questions = Object.values(allQuestions); 
  let score = 0;
  let submit = true;

  questions.forEach((question, index) => {
    const selectedOption = form.querySelector(`input[name="question-${index + 1}"]:checked`);
    if (selectedOption && selectedOption.value === question.answer) { score++; }
    if (!selectedOption) { submit = false;}
  });

  if (!submit) {
    alert("Please answer all of the questions.");
    return;
  }

  let output = document.getElementById('questions');
  if (!output) {
    output = document.createElement('div');
    output.id = 'score';
    form.appendChild(output);
  }
  output.classList.add('score', 'text-center', 'my-3');
  output.innerHTML = `<h3>Your Score: ${score}/${questions.length}</h3>
  <br>
  <div class='d-flex justify-content-center'><button onclick='refresh()' id="nappi" class='w-50 py-2 mb-2 rounded'>Try again</button></div>`;
  console.log('Your Score: ${score}/${questions.length}');
}

// Ikkunan lataus
window.onload = () => {
  createQuizz();
  createButton();
};