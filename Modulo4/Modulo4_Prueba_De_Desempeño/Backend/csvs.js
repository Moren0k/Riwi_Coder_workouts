const fs = require('fs');
const path = require('path');
const csv = require('csv-parser');
const db = require('./db'); //DataBase Connection

const uploadClients = () => { //Function for upload CSV Clients
    const result = [];
    const filePath = path.join(__dirname, './CSV/clients.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) => {result.push(row)})
    .on('end', () => {
        result.forEach((client) => {
            const query = `INSERT INTO clients (name, lastname, identification, address, phone, email)
                VALUES (?, ?, ?, ?, ?, ?)`;

            const values = [
                client.name,
                client.lastname,
                client.identification,
                client.address,
                client.phone,
                client.email
            ];

            db.query(query, values, (err, result) => {
                if (err) {
                    console.error("Error al insertar un cliente.", err);
                } else {
                    console.log(`Cliente agregado correctamente: ${result.insertId}`);
                };
            });
        });
    });
};

const uploadInvoices = () => { //Function for upload CSV Invoices
    const result = [];
    const filePath = path.join(__dirname, './CSV/invoices.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) => {result.push(row)})
    .on('end', () => {
        result.forEach((invoice) => {
            const query = `INSERT INTO invoices (client_id, invoice_number, billing_period, billed_amount, paid_amount)
                VALUES (?, ?, ?, ?, ?)`;

            const values = [
                invoice.client_id,
                invoice.invoice_number,
                invoice.billing_period,
                invoice.billed_amount,
                invoice.paid_amount,
            ];

            db.query(query, values, (err, result) => {
                if (err) {
                    console.error("Error al insertar una factura.", err);
                } else {
                    console.log(`Factura agregada correctamente: ${result.insertId}`);
                };
            });
        });
    });
};

const uploadTransactions = () => { //Function for upload CSV Transactions
    const result = [];
    const filePath = path.join(__dirname, './CSV/transactions.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) => {result.push(row)})
    .on('end', () => {
        result.forEach((transaction) => {
            const query = `INSERT INTO transactions (invoice_id, status_id, type_id, platform_id, transaction_code, transaction_datetime, amount)
                VALUES (?, ?, ?, ?, ?, ?, ?)`;

            const values = [
            transaction.invoice_id,
            transaction.status_id,
            transaction.type_id,
            transaction.platform_id,
            transaction.transaction_code,
            transaction.transaction_datetime,
            transaction.amount
            ];

            db.query(query, values, (err, result) => {
                if (err) {
                    console.error("Error al insertar una transaccion.", err);
                } else {
                    console.log(`Transaccion agregada correctamente: ${result.insertId}`);
                };
            });
        });
    });
};
module.exports = {uploadClients, uploadInvoices, uploadTransactions};