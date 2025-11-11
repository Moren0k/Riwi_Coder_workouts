use.streamhub

db.createCollection("usuarios")

db.createCollection("contenidos")

db.createCollection("listas")

db.usuarios.insertOne({
    "nombre": "Ana Gómez",
    "email": "ana@example.com",
    "pais": "Colombia",
    "generos_preferidos": ["Drama", "Acción"],
    "historial": ["Horizontes Lejanos", "Comedia en Serie"]
    }
)

db.contenidos.insertMany([{
        "titulo": "Horizontes Lejanos",
        "tipo": "película",
        "duracion": 145,
        "anio": 2023,
        "generos": ["Acción", "Aventura"],
        "reparto": ["Carlos Pinto", "Lina Ríos"],
        "valoraciones": [
            { "usuario": "Juan Pérez", "puntuacion": 5 },
            { "usuario": "Ana Gómez", "puntuacion": 4 }
        ]
    },
    {
        "titulo": "Comedia en Serie",
        "tipo": "serie",
        "duracion": 180,
        "anio": 2012,
        "generos": ["Comedia", "Aventura"],
        "reparto": ["Andres Morelo", "Camila Ríos"],
        "valoraciones": [
            { "usuario": "David Pérez", "puntuacion": 3 },
            { "usuario": "Mariana Gómez", "puntuacion": 5 }
        ]
    },
    {
        "titulo": "Nexo Temporal",
        "tipo": "serie",
        "duracion": 50,
        "anio": 2021,
        "generos": ["Drama", "Misterio"],
        "reparto": ["Ana Beltrán", "Diego Rojas"],
        "valoraciones": [
            { "usuario": "Juan Pérez", "puntuacion": 4 },
            { "usuario": "Ana Gómez", "puntuacion": 5 }
        ]
        }
])

db.listas.insertOne({
    "usuario": "Ana Gómez",
    "nombre_lista": "MisFavoritas",
    "fecha_creacion": "2025-03-03",
    "contenidos": ["Horizontes Lejanos", "Nexo Temporal"]
    }
)

db.contenidos.find({tipo:"película", duracion:{$gt:12}})

db.usuarios.find({pais:"Colombia"})

db.contenidos.find({generos:{$in:["Acción"]}})

db.usuarios.updateOne({nombre:"Ana Gómez"},{$set:{pais:"Argentina"}})

db.usuarios.updateOne({nombre:"Ana Gómez"},{$set:{generos_preferidos:["Ciencia Ficción"]}})

db.contenidos.updateOne({titulo:"Nexo Temporal","valoraciones.usuario":"Ana Gómez"},{$set:{"valoraciones.$.puntuacion":4}})

db.usuarios.deleteOne({nombre:"Ana Gómez"})

db.contenidos.deleteOne({titulo:"Nexo Temporal"})

db.listas.deleteOne({nombre_lista:"MisFavoritas"})

db.contenidos.deleteMany({generos:{$in:["Misterio"]}})

db.usuarios.aggregate([{$group:{_id:"$pais", total:{$sum:1}}}])

db.contenidos.aggregate([{$unwind:"$generos"},{$group:{_id:"$generos", promedio_duracion:{$avg:"$duracion"}}}])

db.contenidos.aggregate([{$match:{"valoraciones.1":{$exists:true}}}])

db.usuarios.createIndex({email:1})

db.contenidos.createIndex({tipo:1, anio:-1})

db.listas.createIndex({nombre_lista:1})