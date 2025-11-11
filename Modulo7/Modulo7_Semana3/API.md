https://moren0k-7570723.postman.co/workspace/My-Workspace~2fb11163-3088-4723-99e5-e0e0023b5258/collection/47359911-c663fbaf-e6cd-47aa-afca-611a138fc6ee?action=share&creator=47359911&active-environment=47359911-59e475f8-a99d-4a6c-af2b-f4ffe62b38da


# API HU3 Documentation

Base URL: `http://localhost:5046/api`

## User Endpoints

### 1. Register User
- **Method:** POST
- **Endpoint:** `/User/auth/register`
- **Body:**
```json
{
  "username": "string",
  "email": "user@example.com",
  "password": "string",
  "role": "string"
}
```
- **Description:** Crea un nuevo usuario.

### 2. Login User
- **Method:** POST
- **Endpoint:** `/User/auth/login`
- **Body:**
```json
{
  "email": "string",
  "password": "string"
}
```
- **Description:** Inicia sesión y obtiene credenciales/token.

### 3. Get All Users
- **Method:** GET
- **Endpoint:** `/User`
- **Description:** Obtiene todos los usuarios registrados.

### 4. Get User By ID
- **Method:** GET
- **Endpoint:** `/User/{id}`
- **Description:** Obtiene información de un usuario específico.

### 5. Update User
- **Method:** PUT
- **Endpoint:** `/User/{id}`
- **Body:**
```json
{
  "username": "string",
  "email": "string",
  "password": "string",
  "role": "string"
}
```
- **Description:** Actualiza los datos de un usuario específico.

### 6. Delete User
- **Method:** DELETE
- **Endpoint:** `/User/{id}`
- **Description:** Elimina un usuario específico.

### 7. Get User By Username
- **Method:** GET
- **Endpoint:** `/User/by-username/{username}`
- **Description:** Obtiene información de un usuario usando su nombre de usuario.

## Product Endpoints

### 1. Add Product
- **Method:** POST
- **Endpoint:** `/Products`
- **Body:**
```json
{
  "name": "string",
  "description": "string",
  "price": 0,
  "stock": 2147483647
}
```
- **Description:** Crea un nuevo producto.

### 2. Get All Products
- **Method:** GET
- **Endpoint:** `/Products`
- **Description:** Obtiene todos los productos.

### 3. Get Product By ID
- **Method:** GET
- **Endpoint:** `/Products/{id}`
- **Description:** Obtiene un producto específico.

### 4. Update Product
- **Method:** PUT
- **Endpoint:** `/Products/{id}`
- **Body:**
```json
{
  "name": "string",
  "description": "string",
  "price": 0,
  "stock": 2147483647
}
```
- **Description:** Actualiza un producto específico.

### 5. Delete Product
- **Method:** DELETE
- **Endpoint:** `/Products/{id}`
- **Description:** Elimina un producto específico.