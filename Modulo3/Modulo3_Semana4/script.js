// Save event to LocalStorage
document.getElementById('saveButton').addEventListener('click', () => {
    const nameInput = document.getElementById('name');
    const ageInput = document.getElementById('age');

    if (!nameInput || !ageInput) {
        console.error('Input elements not found');
        return;
    }

    const name = nameInput.value.trim();
    const age = parseInt(ageInput.value);

    if (name && !isNaN(age)) {
        localStorage.setItem('name', name);
        localStorage.setItem('age', age);
        displayData();
    } else {
        alert('Please enter valid name and age');
    }
});

// Function to display data after saving
function displayData() {
    const name = localStorage.getItem('name');
    const age = localStorage.getItem('age');
    const outputDiv = document.getElementById('output');

    if (name && age) {
        outputDiv.textContent = `Hola ${name}, tienes ${age} años.`;
    } else {
        outputDiv.textContent = 'No hay datos guardados.';
    }
}

// Display data on page load
window.onload = displayData;

// Inicializar contador  de interacciones en seccion storage
if (!sessionStorage.getItem('interactionCount')) {
    sessionStorage.setItem('interactionCount', 0);
}

// Actualizar contador de interacciones
function updateInteractionCount() {
    let count = parseInt(sessionStorage.getItem('interactionCount'));
    count++;
    sessionStorage.setItem('interactionCount', count);
    document.getElementById('interactionCount').textContent = `Interacciones: ${count}`;
}

// Asignar eventos al contador
document.getElementById('saveButton').addEventListener('click', updateInteractionCount);
document.getElementById('clearButton').addEventListener('click', updateInteractionCount);

// Evento to clear data from LocalStorage
document.getElementById('clearButton').addEventListener('click', () => {
    localStorage.clear();
    displayData();
});