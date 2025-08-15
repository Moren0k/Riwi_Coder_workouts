/* Get elements from HTML */
//Upload Clients
const tableClients = document.getElementById('tableClients');
const btnUploadC = document.getElementById('btnUploadC');

//Upload Invoices
const tableInvoices = document.getElementById('tableInvoices');
const btnUploadI = document.getElementById('btnUploadI');

//Upload Transactions
const tableTransactions = document.getElementById('tableTransactions');
const btnUploadT = document.getElementById('btnUploadT');

//Delete All Data
const btnDeleteA = document.getElementById('btnDeleteA');

//Delete Client For Id
const inpIdDelete = document.getElementById('idDelete').value;
const btnIdDelete = document.getElementById('btnIdDelete');

/* EVENTS */
btnUploadC.addEventListener('click', ()=> { //Clients
    uploadDataC();
});

btnUploadI.addEventListener('click', ()=> { //Invoices
    uploadDataI();
});

btnUploadT.addEventListener('click', ()=> { //Transactions
    uploadDataT();
});

btnDeleteA.addEventListener('click', ()=> { //Delete All Data
    deleteAllD();
});

btnIdDelete.addEventListener('click', ()=> { //Delete Client For ID

});

/* GET */
function getClients() { //Function get table Clients
    fetch('http://localhost:3000/getClients')
    .then(res => res.json())
    .then(data => {
        tableClients.innerHTML = '';
        data.forEach(client => {
            tableClients.innerHTML += `
            <tr>
                <td>${client.client_id}</td>
                <td>${client.name}</td>
                <td>${client.lastname}</td>
                <td>${client.identification}</td>
                <td>${client.address}</td>
                <td>${client.phone}</td>
                <td>${client.email}</td>
            </tr>
            `;
        });
    });
};

function getInvoices() { //Funtion get table Invoices
    fetch('http://localhost:3000/getInvoices')
    .then(res => res.json())
    .then(data => {
        tableInvoices.innerHTML = '';
        data.forEach(invoice => {
            tableInvoices.innerHTML += `
            <tr>
                <td>${invoice.invoice_id}</td>
                <td>${invoice.client_id}</td>
                <td>${invoice.invoice_number}</td>
                <td>${invoice.billing_period}</td>
                <td>${invoice.billed_amount}</td>
                <td>${invoice.paid_amount}</td>
            </tr>
            `;
        });
    });
};

function getTransaction() { //Function get table Transactions
    fetch('http://localhost:3000/getTransactions')
    .then(res => res.json())
    .then(data => {
        tableTransactions.innerHTML = '';
        data.forEach(transaction => {
            tableTransactions.innerHTML += `
                <tr>
                    <td>${transaction.transaction_id}</td>
                    <td>${transaction.transaction_code}</td>
                    <td>${transaction.transaction_datetime}</td>
                    <td>${transaction.amount}</td>
                    <td>${transaction.status_id}</td>
                    <td>${transaction.type_id}</td>
                </tr>
            `;
        });
    });
};

/* POST */
function uploadDataC() { //Function execute endpoint for upload data clients csv
    fetch('http://localhost:3000/uploadClients', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {res.json()})
    .then(() => getClients());
};

function uploadDataI() { //Function execute endpoint for upload data invoices csv
    fetch('http://localhost:3000/uploadInvoices', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {res.json()})
    .then(() => getInvoices());
};

function uploadDataT() {
    fetch('http://localhost:3000/uploadTransactions', {
        method: 'POST',
        headers: {'Content-Type':'application/json'}
    })
    .then(res => {res.json()})
    .then(() => getTransaction());
};

/* DELETE */
function deleteAllD() {
    fetch('http://localhost:3000/delAll', {
        method: 'DELETE',
        headers: {'Content-Type':'application/json'}
    })
    .then(() => getClients())
    .then(() => getInvoices())
    .then(() => getTransaction())
};

function deleteForIdC() {
    fetch(`http://localhost:3000/delClient/:id`,{
        method: 'DELETE',
        headers: {'Content-Type':'application/json'}
    })

};

//Load tables init website
getClients();
getInvoices();
getTransaction();