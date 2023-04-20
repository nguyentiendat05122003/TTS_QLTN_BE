create database DoAnAll
use DoAnAll
CREATE TABLE categories(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL,
	image nVARCHAR(200),
  
)
CREATE TABLE orders(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    customer_id INT CONSTRAINT fk_customer_oder FOREIGN KEY(customer_id) REFERENCES customers(id),
    address_id INT CONSTRAINT fk_address_oder FOREIGN KEY(address_id) REFERENCES shipping_address(id) ON DELETE CASCADE,
    created_at datetime NOT NULL,
  
    status TINYINT NOT NULL,
)
CREATE TABLE detail_orders(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    order_id INT CONSTRAINT fk_order_detail FOREIGN KEY(order_id) REFERENCES orders(id) ON DELETE CASCADE,
    name NVARCHAR(250),
    option_name VARCHAR(100),
    image VARCHAR(200),
    quantity INT NOT NULL,
    price INT NOT NULL
)
Create TABLE shipping_address (
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    phone CHAR(10) NOT NULL,
    address NVARCHAR(MAX) NOT NULL,
)



create table products(
id INT IDENTITY(1,1) primary key ,
MaLoai int foreign key references categories(id) on delete cascade on update cascade NOT NULL,
TenSP NVARCHAR(350) not null,
GiaBan int,
Sale int ,
SoLuong int,
image nVARCHAR(200),
TinhTrang nvarchar(500),

)


CREATE TABLE customers(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    TenKH NVARCHAR(150) NOT NULL,
    image nVARCHAR(200),
    phone CHAR(10) NOT NULL,
    email nVARCHAR(70),
    password nVARCHAR(250) NOT NULL,
)

CREATE TABLE addresses(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    phone CHAR(10) NOT NULL,
    address NVARCHAR(MAX) NOT NULL,
    customer_id INT CONSTRAINT fk_customer_address FOREIGN KEY(customer_id) REFERENCES customers(id) ON DELETE CASCADE,
    active BIT
)

CREATE TABLE users(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    image NVARCHAR(200),
    email NVARCHAR(70) NOT NULL,
    password NVARCHAR(max) NOT NULL,
    phone char(10)
)

CREATE TABLE roles(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(MAX)
)

CREATE TABLE user_role(
    user_id int CONSTRAINT fk_role_user FOREIGN KEY(user_id) REFERENCES users(id) ON DELETE CASCADE,
    role_id int CONSTRAINT fk_user_role FOREIGN KEY(role_id) REFERENCES roles(id) ON DELETE CASCADE,
)

CREATE TABLE functions(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    name NVARCHAR(150) NOT NULL,
    url VARchar(MAX),
    parent_id INT,
    sort_order TINYINT,
    status TINYINT,
)

CREATE TABLE permissions(
    role_id INT CONSTRAINT fk_role_permission FOREIGN KEY(role_id) REFERENCES roles(id) ON DELETE CASCADE,
    function_id INT CONSTRAINT fk_function_permission FOREIGN KEY(function_id) REFERENCES functions(id) ON DELETE CASCADE,
    action_id INT
)

CREATE TABLE carts(
    id INT IDENTITY(1, 1) PRIMARY KEY,
    customer_id INT CONSTRAINT fk_customer_cart FOREIGN KEY(customer_id) REFERENCES customers(id) ON DELETE CASCADE,
    product_id  INT CONSTRAINT fk_cart_product FOREIGN KEY(product_id) REFERENCES products(id),
   
    quantity INT NOT NULL
)
CREATE TABLE TinTuc (
 id INT IDENTITY(1,1) not null primary key,
 Anh nvarchar(500)  NULL,

 NoiDung nvarchar(500)  NULL,
 NgayDang nvarchar(500)  NULL,
 
 MoTa nvarchar(3000)  NULL,
 MoTa1 nvarchar(3000)  NULL,

)
d