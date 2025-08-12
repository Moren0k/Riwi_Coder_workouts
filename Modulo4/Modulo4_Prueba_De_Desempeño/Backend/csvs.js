const fs = require('fs');
const path = require('path');
const csv = require('csv-parser');
const connection = require('./db');

const uploadClients = () => { // Funcion que lee el archivo csv y sube los clients
    const result=[];
    const filePath = path.join(__dirname, './CSV/clients.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) =>{
        result.push(row);
    });

    result.forEach((client) =>{
        const query = `INSERT INTO clients(name, lastname, identification, address, phone, email)
        VALUES(?, ?, ?, ?, ?, ?)`;


        const values = [
            client.name,
            client.lastname,
            client.identification,
            client.address,
            client.phone,
            client.email
        ];


    connection.query(query, values, (err, result)=>{
            if(err){
                console.error("Error al insertar client", err);
            } else {
                console.log(`"Client agregado correctamente" ${result.insertId}`);
            }
        });
    });
};
module.exports = { uploadClients };


const uploadInvoices = () => { // Funcion que lee el archivo csv y sube los invoices
    const result=[];
    const filePath = path.join(__dirname, './CSV/invoices.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) =>{
        result.push(row);
    });

    result.forEach((invoice) =>{
        const query = `INSERT INTO clients(client_id, invoice_number, billing_period, billed_amount, paid_amount)
        VALUES(?, ?, ?, ?, ?)`;


        const values = [
            invoice.client_id,
            invoice.invoice_number,
            invoice.billing_period,
            invoice.billed_amount,
            invoice.paid_amount,
        ];


    connection.query(query, values, (err, result)=>{
            if(err){
                console.error("Error al insertar invoice", err);
            } else {
                console.log(`"Invoice agregado correctamente" ${result.insertId}`);
            }
        });
    });
};
module.exports = { uploadInvoices };