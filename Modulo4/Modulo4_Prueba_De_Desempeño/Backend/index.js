const express = require('express');
const bodyParser = require('body-parser');
const db = require('./db');
const cors = require('cors'); 
const app = express();

//Functions for upload .csv
const { uploadClients } = require('./csvs');
const { uploadInvoices } = require('./csvs');
const { uploadtransaction } = require('./csvs');

app.use(cors());
app.use(bodyParser.json());

/* POST */
//Insert New Client
app.post('/NewClient', (req, res) => {
    const { name, lastname, identification, address, phone, email } = req.body;

    const sql = `INSERT INTO clients (name, lastname, identification, address, phone, email)
    VALUES(?, ?, ?, ?, ?, ?)`;

    db.query(sql, [name, lastname, identification, address, phone, email], (err, result) => {
        if (err) {
            console.error('Error al insertar client:', err);
            return res.status(500).json({ error: 'Error al insertar client' });
        }
        res.status(201).json({ message: 'Client insertado correctamente', id: result.insertId });
    });
});

/* POST */
//Insert DataCSV Clients
app.post('/uploadDataClients', (req,res) =>{
    uploadClients();
    console.log("Funciono Clients");
    res.json({result:"Base de datos actualizada con datos CSV"});
});

//Insert DataCSV Invoices
app.post('/uploadDataInvoices', (req,res) =>{
    uploadInvoices();
    console.log("Funciono Invoices")
    res.json({result:"Base de datos actualizada con datos CSV"});
})

//Insert DataCSV Transactions
app.post('/uploadDataTransactions', (req,res) =>{
    uploadtransaction();
    console.log("Funciono Transactions")
    res.json({result:"Base de datos actualizada con datos CSV"});
})

/* GET */
// Obtener todos los clients
app.get('/getClients', (req, res) => {
    const sql = 'SELECT * FROM clients';

    db.query(sql, (err, results) => {
        if (err) {
            console.error('Error al obtener los clients:', err);
            return res.status(500).json({ error: 'Error al obtener los clients' });
        }
        res.json(results);
    });
});

// Obtener todos los invoices
app.get('/getInvoices', (req, res) => {
    const sql = 'SELECT * FROM invoices';

    db.query(sql, (err, results) => {
        if (err) {
            console.error('Error al obtener los invoices:', err);
            return res.status(500).json({ error: 'Error al obtener los invoices' });
        }
        res.json(results);
    });
});

// Obtener todos las Transactions
app.get('/getTransactions', (req, res) => {
    const sql = 'SELECT * FROM transactions';

    db.query(sql, (err, results) => {
        if (err) {
            console.error('Error al obtener las Transactions:', err);
            return res.status(500).json({ error: 'Error al obtener las Transactions' });
        }
        res.json(results);
    })
})

/* DELETE */
app.delete('/deleteClients/:id', (req, res) => {
    const clientId = req.params.id;
    const sql = 'DELETE FROM clients WHERE client_id = ?';

    db.query(sql, [clientId], (err, results) => {
        if (err) {
            console.error('Error al eliminar el cliente:', err);
            return res.status(500).json({ error: 'Error al eliminar el cliente' });
        }
        console.log("Cliente eliminado correctamente");
        res.json({ message: 'Cliente eliminado correctamente', affectedRows: results.affectedRows });
    });
});

//Conectarme
app.listen(3000, () => {
    console.log('Servidor corriendo en http://localhost:3000');
});
