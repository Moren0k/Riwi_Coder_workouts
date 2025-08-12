/* CALL TO HTML ELEMENTS */
// Upload Clients
const tableClients = document.getElementById('tableClients');
const btnUploadC = document.getElementById('btnUploadC');

// Upload Invoices
const tableInvoices = document.getElementById('tableInvoices');
const btnUploadI = document.getElementById('btnUploadI');

// Upload Transactions
const tableTransaction = document.getElementById('tableTransaction');
const btnUploadT = document.getElementById('btnUploadT');

// Delete Client ID
const inpDeleteClient = document.getElementById('inpDeleteClient').value;
const btnDeleteC = document.getElementById('btnDeleteC');

// ClearAll
const clearAll = document.getElementById('clearAll');

/* EVENTS */
btnUploadC.addEventListener('click', ()=>{
    uploadDataC(); //Click Clients
});

btnUploadI.addEventListener('click', ()=>{
    uploadDataI();  //Cick Invocices
});

btnUploadT.addEventListener('click', ()=>{
    uploadDataT();
})

btnDeleteC.addEventListener('click', ()=>{
    deleteDataC(inpDeleteClient); // Click delete Client for ID
    uploadDataC();
})

clear.addEventListener('click', ()=>{
    clearAll();
})



/* GET */
//function get table Clients
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

//Funtion get table Invoices
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
};

//Function get table Transactions
function cargarTransacciones(){
    fetch('http://localhost:3000/getTransactions')
    .then(res => res.json())
    .then(data => {
        tableTransaction.innerHTML = '';
        data.forEach(rec => {
            tableTransaction.innerHTML += `
                <tr>
                    <td>${rec.transaction_code}</td>
                    <td>${rec.transaction_datetime}</td>
                    <td>${rec.amount}</td>
                    <td>${rec.status_id}</td>
                    <td>${rec.type_id}</td>
                </tr>
            `;
        });
    });
};

/* POST */
function uploadDataC(){ //Function execute endpoint for upload data clients csv
    fetch('http://localhost:3000/uploadDataClients', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarEmpleados();
    })
    .then(cargarEmpleados());
};

function uploadDataI(){ //Function execute endpoint for upload data invoices csv
    fetch('http://localhost:3000/uploadDataInvoices', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarFacturas();
    })
    .then(cargarFacturas());
}

function uploadDataT(){
    fetch('http://localhost:3000/uploadDataTransactions', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarTransacciones();
    })
    .then(cargarTransacciones())
};

function deleteDataC(){
    fetch('http://localhost:3000/deleteClients/:id', {
    method: 'DELETE',
    headers: {'Content-Type':'application/json'}
    })
    .then(res => {
        res.json()
        cargarTransacciones();
    })
    .then(cargarTransacciones())
}

cargarEmpleados();
cargarFacturas();
cargarTransacciones();