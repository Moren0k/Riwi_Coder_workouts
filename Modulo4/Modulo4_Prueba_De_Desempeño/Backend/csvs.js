const fs = require('fs');
const path = require('path');
const csv = require('csv-parser');
const connection = require('./db');
const { on } = require('events');

const uploadClients = () => { //Funciton upload clients.csv
    const result = [];
    const filePath = path.join(__dirname, './CSV/clients.csv');

    fs.createReadStream(filePath)
        .pipe(csv())
        .on('data', (row) => {
            result.push(row);
        })
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

                connection.query(query, values, (err, result) => {
                    if (err) {
                        console.error("Error al insertar client:", err);
                    } else {
                        console.log(`Client agregado correctamente: ${result.insertId}`);
                    }
                });
            });
        });
};

const uploadInvoices = () => { //Function upload invoices.csv
    const result = [];
    const filePath = path.join(__dirname, './CSV/invoices.csv');

    fs.createReadStream(filePath)
        .pipe(csv())
        .on('data', (row) => {
            result.push(row);
        })
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

                connection.query(query, values, (err, result) => {
                    if (err) {
                        console.error("Error al insertar invoice:", err);
                    } else {
                        console.log(`Invoice agregado correctamente: ${result.insertId}`);
                    }
                });
            });
        });
};

const uploadtransaction = () => { //Function upload transaction.CSV
    const result = [];
    const filePath = path.join(__dirname, './CSV/transactions.csv');

    fs.createReadStream(filePath)
    .pipe(csv())
    .on('data', (row) => {
        result.push(row);
    })
    .on('end', () => {
        result.forEach((transaction) => {
            const query = `INSERT INTO transactions (transaction_code,transaction_datetime,amount,status_id,type_id)
            VALUES (?, ?, ?, ?, ?)`;

            const values = [
                transaction.status_id,
                transaction.transaction_code,
                transaction.transaction_datetime,
                transaction.amount,
                transaction.type_id
            ];

            connection.query(query, values, (err, result) => {
                if (err) {
                    console.log("Error al insertar transacciones", err);
                } else {
                    console.log(`Transaction agregado correctamente: ${result.insertId}`);
                }
            });
        });
    });
};
module.exports = { uploadClients, uploadInvoices, uploadtransaction};