-- =======================
-- CREATE DATABASE
-- =======================
CREATE DATABASE IF NOT EXISTS pd_jhos_agudelo_hopper;
USE pd_jhos_agudelo_hopper;

-- =======================
-- TABLE CLIENTS (CREADA)
-- =======================
CREATE TABLE clients (
    client_id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    lastname VARCHAR(100) NOT NULL,
    identification VARCHAR(20) UNIQUE NOT NULL,
    address VARCHAR(255),
    phone VARCHAR(20),
    email VARCHAR(100)
);

-- =======================
-- TABLE INVOICES (CREADA)
-- =======================
CREATE TABLE invoices (
    invoice_id INT AUTO_INCREMENT PRIMARY KEY,
    client_id INT NOT NULL,
    invoice_number VARCHAR(20) UNIQUE NOT NULL,
    billing_period CHAR(7) NOT NULL, -- Format YYYY-MM
    billed_amount DECIMAL(12,2) NOT NULL DEFAULT 0,
    paid_amount DECIMAL(12,2) NOT NULL DEFAULT 0,
    FOREIGN KEY (client_id) REFERENCES clients(client_id)
        ON UPDATE CASCADE ON DELETE RESTRICT
);

-- =======================
-- TABLE STATUS
-- =======================
CREATE TABLE status (
    status_id INT AUTO_INCREMENT PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL
);

-- =======================
-- TABLE TYPES
-- =======================
CREATE TABLE types (
    type_id INT AUTO_INCREMENT PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL
);

-- =======================
-- TABLE PLATFORMS
-- =======================
CREATE TABLE platforms (
    platform_id INT AUTO_INCREMENT PRIMARY KEY,
    platform_name VARCHAR(50) NOT NULL
);

-- =======================
-- TABLE TRANSACTIONS
-- =======================
CREATE TABLE transactions (
    transaction_id INT AUTO_INCREMENT PRIMARY KEY,
    invoice_id INT NOT NULL,
    status_id INT NOT NULL,
    type_id INT NOT NULL,
    platform_id INT NOT NULL,
    transaction_code VARCHAR(20) UNIQUE NOT NULL,
    transaction_datetime DATETIME NOT NULL,
    amount DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (invoice_id) REFERENCES invoices(invoice_id)
        ON UPDATE CASCADE ON DELETE RESTRICT,
    FOREIGN KEY (status_id) REFERENCES status(status_id)
        ON UPDATE CASCADE ON DELETE RESTRICT,
    FOREIGN KEY (type_id) REFERENCES types(type_id)
        ON UPDATE CASCADE ON DELETE RESTRICT,
    FOREIGN KEY (platform_id) REFERENCES platforms(platform_id)
        ON UPDATE CASCADE ON DELETE RESTRICT
);
