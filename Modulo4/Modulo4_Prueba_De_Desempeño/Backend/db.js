const mysql = require('mysql2');

const db = mysql.createConnection({
    host:'localhost',
    user:'root',
    password:'',
    database:'pd_jhos_agudelo_hopper'
});

db.connect(err =>{
    if(err){
    console.error("Error al conectar con MYSQL", err);
    return;
    }
    console.log("Conectado a la BD");
});

module.exports = db;
