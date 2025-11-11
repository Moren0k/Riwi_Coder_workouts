//Program initialization
alert("¡Bienvenido al Sitema Interactivo de Mensajes!");

//Capture user data
let name = prompt("Por favor, ingresa tu nombre: ");
let age = prompt("Por favor, ingresa tu edad: ");

//Convert age to number
age = parseInt(age);

//Validation and Message Code
if (isNaN(age)) {
    alert("¡ERROR! Por favor, ingresa una edad válida en números.");
} else if (age<18) {
    alert(`Hola ${name}, eres menor de edad. ¡Sigue Aprendiendo y disfrutando del código!`);
} else {
    alert(`Hola ${name}. eres mayor de edad. ¡Preparate para grandes oportunidades en el mundo de la promgramación!`);
}
alert(`Gracias por usar este sismtema ${name}.`)