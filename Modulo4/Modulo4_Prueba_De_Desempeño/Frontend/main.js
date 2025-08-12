const tableClients = document.getElementById('tableClients');
const btnUploadC = document.getElementById('btnUploadC');

const tableInvoices = document.getElementById('tableInvoices');
const btnUploadI = document.getElementById('btnUploadI');


btnUploadC.addEventListener('click', ()=>{
    uploadDataC();
});

btnUploadI.addEventListener('click', ()=>{
    uploadDataI();
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
};

function cargarFacturas(){
    fetch('http://localhost:3000/getInvoices')
    .then(res => res.json())
    .then(data => {
        tableInvoices.innerHTML = '';
        data.forEach(rec => {
            tableInvoices.innerHTML += `
            <tr>
                <td>${rec.invoice_id}</td>
                <td>${rec.client_id}</td>
                <td>${rec.invoice_number}</td>
                <td>${rec.billing_period}</td>
                <td>${rec.billed_amount}</td>
                <td>${rec.paid_amount}</td>
            </tr>
            `;
        });
    });
}

function uploadDataC(){
    fetch('http://localhost:3000/uploadCSV', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarEmpleados();
    });
};

function uploadDataI(){
    fetch('http://localhost:3000/uploadDataInvoices', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarFacturas();
    });
}

cargarEmpleados();
cargarFacturas();