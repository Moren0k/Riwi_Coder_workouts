const express = require('express');
const bodyParser = require('body-parser');
const db = require('./db');
const cors = require('cors'); 
const app = express();

const { uploadClients } = require('./csvs');
const { uploadInvoices } = require('./csvs');

// Middleware para permitir CORS
app.use(cors());
app.use(bodyParser.json());

//Insert New Client
app.post('/NewClient', (req, res) => {
    const { name, lastname, identification, address, phone, email } = req.body;

    const sql = `
        INSERT INTO clients (name, lastname, identification, address, phone, email)
        VALUES(?, ?, ?, ?, ?, ?)`;

    db.query(sql, [name, lastname, identification, address, phone, email], (err, result) => {
        if (err) {
            console.error('Error al insertar client:', err);
            return res.status(500).json({ error: 'Error al insertar client' });
        }
        res.status(201).json({ message: 'Client insertado correctamente', id: result.insertId });
    });
});


//Insert DataCSV Clients
app.post('/uploadCSV', (req,res) =>{
    uploadClients();
    console.log("Funciono");
    res.json({result:"Base de datos actualizada con datos CSV"});
});

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


app.listen(3000, () => {
    console.log('Servidor corriendo en http://localhost:3000');
});
