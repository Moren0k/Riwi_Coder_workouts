import mysql from 'mysql2';
import express from 'express';

const app = express();

const connection = mysql.createConnection ({
	host: 'localhost',
	user: 'root',
	password: '',
	database: 'universidad'
})

connection.connect (
	(error) => {
		if (error) throw error;
		console.log('Conectado Correctamente')
	}
)

app.get('/estudiantes', (request, response)={
	connection.query('SELECT * FROM estudiantes', (error, result)=>{
		if(error) throw error;
		response.json(result)
	})
})

app.get('/docentes', (request, response)={
	connection.query('SELECT * FROM docentes', (error, result)=>{
		if(error) throw error;
		response.json(result)
	})
})


//Fin
app.listen(3001, (error)=>{
	if (error) throw error;
	console.log('API Corriendo en el puerto 3001')
})