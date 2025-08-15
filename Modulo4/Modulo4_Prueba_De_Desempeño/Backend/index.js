const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors'); 
const app = express();
const db = require('./db'); //DataBase Connection
app.use(cors());
app.use(bodyParser.json());

//Functions for upload .csv
const {uploadClients} = require('./csvs');
const {uploadInvoices} = require('./csvs');
const {uploadTransactions} = require('./csvs');

/* POSTs */
//Insert New Client
app.post('/addClient', (req, res) => {
    const {name, lastname, identification, address, phone, email} = req.body;

    const query = `INSERT INTO clients (name, lastname, identification, address, phone, email)
        VALUES (?, ?, ?, ?, ?, ?)`;

    db.query(query, [name, lastname, identification, address, phone, email], (err, result) => {
        if (err) {
            console.error("Error al insertar un cliente", err);
            return res.json({error: "Error al insertar un cliente"});
        }
        res.json({message: "Client insertado correctamente", id: result.insertId});
    });
});

//Insert DataCSV Clients
app.post('/uploadClients', (req,res) => {
    uploadClients();
    res.json({result:"Base de datos (C) actualizada correctamente con datos CSV"});
});

//Insert DataCSV Invoices
app.post('/uploadInvoices', (req,res) => {
    uploadInvoices();
    res.json({result:"Base de datos (I) actualizada correctamente con datos CSV"});
})

//Insert DataCSV Transactions
app.post('/uploadTransactions', (req,res) => {
    uploadTransactions();
    res.json({result:"Base de datos (T) actualizada correctamente con datos CSV"});
})

/* GETs */
//Get all data from table clients
app.get('/getClients', (req, res) => {
    const query = 'SELECT * FROM clients';

    db.query(query, (err, result) => {
        if (err) {
            console.error("Error al obtener los clientes.", err);
            return res.json({error: "Error al obtener los clientes."});
        }
        res.json(result);
    });
});

//Get all data from table invoices
app.get('/getInvoices', (req, res) => {
    const query = 'SELECT * FROM invoices';

    db.query(query, (err, result) => {
        if (err) {
            console.error("Error al obtener las facturas.", err);
            return res.json({error: "Error al obtener las facturas."});
        }
        res.json(result);
    });
});

//Get all data from table transactions
app.get('/getTransactions', (req, res) => {
    const query = 'SELECT * FROM transactions';

    db.query(query, (err, result) => {
        if (err) {
            console.error("Error al obtener las transacciones.", err);
            return res.json({error: "Error al obtener las transacciones."});
        }
        res.json(result);
    });
});

/* DELETEs */
app.delete('/delClient/:id', (req, res) => {
    const clientID = req.params.id;
    const query = `DELETE FROM clients WHERE client_id = ?`;

    db.query(query, [clientID], (err, result) => {
        if (err) {
            console.error("Error al eliminar el cliente.", err);
            return res.json({error: "Error al eliminar el cliente"});
        }
        res.json({message: "Cliente eliminado correctamente", affectedRows: result.affectedRows });
    });
});

app.delete('/delAll', (req, res) => {
    db.query('TRUNCATE TABLE transactions');
    db.query('TRUNCATE TABLE invoices');
    db.query('TRUNCATE TABLE clients');
    res.send('Todas los datos de las tablas fueron eliminadas correctamente.');
});

//Connect to localhost
app.listen(3000, () => {
    console.log('Servidor corriendo en http://localhost:3000');
});
