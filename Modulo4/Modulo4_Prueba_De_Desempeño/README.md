# # Prueba de desempeño – Módulo 4

**Autor:** Jhos Kevin Agudelo Moreno
**Clan:** Hopper
**Correo:** [jhoskevinagudelomoreno@gmail.com](jhoskevinagudelomoreno@gmail.com)
**Documento:** CC.1035972277

---

Un Cliente puede tener muchas Facturas, las Facturas solo pueden tener un Cliente, para realizar el pago una Factura puede tener varias Transacciones pero una Transacción solo puede ser a una Factura, la Factura puede tener varios Estados, diferentes Tipos y puede ser en distintas Plataformas (Pero solo a una FACTURA).

**ID Transaccion** TXN001,
**Fecha y Hora** 2024-06-01 10:00:00,
**Monto** 38940,
**Estado** Pendiente,

**Tipo** Pago de Factura,

**Nombre** Angel Daniel,
**DNI** 149186547,
**Direccion** "USNS DavisFPO AP 78518",
**Celular** (873)222-2692x09480,
**Correo** rmiller@boyer.com,

**Plataforma** Nequi,

**Numero_Factura** FAC7068,
**Periodo Facturacion** 2024-06,
**Monto_Facturado** 39940,
**Monto_pagado** 0

Angel Daniel(DNI,DIRECCION, CELULAR, CORREO), tiene una Numero_Factura: FAC7068, del periodo 2024-06, un Monto_Facturado 39940, y un Monto_Pagado 0, Realiza una transacción de tipo Pago de Factura, con ID_Transaccion TXN001 con Fecha y Hora 2024-06-01 10:00:00 y paga un monto de 38940 y el estado de la transaccion es Pendiente.

---

En la carpeta del Backend instalamos:
(express,mysql2,csv-parser,multer,cors,dotenv)

Cree un archivo `CreateDataBase.sql` donde tengo todos los comandos para la creacion de la base de datos MySQL.

```js
    npm init -y

    npm i express mysql2 csv-parser multer cors dotenv
```

Cree un archivo `db.js` donde tengo la conección a mi base de datos MySQL (pd_jhos_agudelo_hopper).
Cree un archivo `csvs.js` donde tengo todas las funciones para leer y subir los diferentes archivos .CSV.
Cree un archivo `index.js` donde voy a tener los endpoints para enviar la data a mi base de datos.