const mysql = require('mysql2');

const db = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'pd_jhos_agudelo_hopper'
});

db.connect(err => {
    if (err) {
        console.error("Error al conectar con la base datos", err);
        return;
    }
    console.log("Conectado correctamente a la base de datos");
});

module.exports = db;