const tableClients = document.getElementById('tableClients');
const btnUploadCSV = document.getElementById('btnUploadCSV');

btnUploadCSV.addEventListener('click', ()=>{
    uploadData();
});

//function encargada de traer mis empleados
function cargarEmpleados(){
    fetch('http://localhost:3000/getClients')
    .then(res => res.json())
    .then(data => {
        tableClients.innerHTML = '';
        data.forEach(rec => {
            tableClients.innerHTML += `
            <tr>
                <td>${rec.client_id}</td>
                <td>${rec.name}</td>
                <td>${rec.lastname}</td>
                <td>${rec.identification}</td>
                <td>${rec.address}</td>
                <td>${rec.phone}</td>
                <td>${rec.email}</td>
            </tr>
            `;
        });
    });
}

function uploadData(){
    fetch('http://localhost:3000/uploadCSV', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => res.json());
}

cargarEmpleados();