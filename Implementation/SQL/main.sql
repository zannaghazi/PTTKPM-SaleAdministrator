drop database QuanLyBanHang;
create database QuanLyBanHang;
use QuanLyBanHang;

create table User
(
	id INT unsigned auto_increment primary key,
    username varchar(100) not null unique,
    password varchar(100) not null,
    name varchar(100) not null,
    role int not null,
    isDeleted boolean
);
insert into User(username, password, name, role, isDeleted)
values('admin', 'admin', 'Tổng giám đốc', 0, false),
	('quanly', 'quanly', 'Quản lý', 0, false),
    ('banhang', 'banhang', 'Bán hàng', 1, false),
    ('shipper', 'shipper', 'Người giao hàng', 2, false),
    ('advertiser', 'advertiser', 'Người đăng tin', 3, false),
    ('treasurer', 'treasurer', 'Thủ quỹ', 4, false),
    ('zannaghazi', 'zannaghazi123', 'CEO Võ Thanh Hiếu', 0, false);

create table Item
(
	id INT unsigned auto_increment primary key,
    name varchar(100) not null,
    type varchar(100) not null,
    amount int not null,
    minimum int not null,
    provider varchar(100),
    isRequestImport boolean,
    isDeleted boolean
);
insert into Item(name, type, amount, minimum, provider, isRequestImport, isDeleted)
values('Intel Core i9-9900K', 'Linh kiện máy tính', 41, 10, 'Viễn Sơn', true, false),
	('Aorus Z390 Xtreme', 'Linh kiện máy tính', 33, 10, 'Viễn Sơn', true, false),
    ('RAM G.Skill TridentZ 16GB 3200MHz', 'Linh kiện máy tính', 8, 10, 'Viễn Sơn', true, false),
    ('RAM Aorus RGB 16GB (8GBx2) 3600MHz', 'Linh kiện máy tính', 2, 10, 'Viễn Sơn', false, false),
    ('Aorus GTX 1080TI Xtreme 11GB', 'Linh kiện máy tính', 1, 10, 'Viễn Sơn', false, false),
    ('Aorus RTX 2070 Super Xtreme 8GB', 'Linh kiện máy tính', 71, 10, 'Viễn Sơn', false, false),
    ('SSD Samsung 970 EVO 500GB', 'Linh kiện máy tính', 27, 10, 'Viễn Sơn', false, false),
    ('Thịt ba chỉ', 'Thực phẩm', 31, 20, 'Bách hoá xanh', false, false),
    ('Thịt đùi', 'Thực phẩm', 76, 20, 'Bách hoá xanh', false, false),
    ('Rau cải', 'Thực phẩm', 99, 100, 'Bách hoá xanh', false, false),
    ('Rau bó xôi', 'Thực phẩm', 131, 100, 'Bách hoá xanh', false, false),
    ('Tivi Sony 49 inch', 'Đồ gia dụng', 14, 5, 'Điện máy xanh', false, false),
    ('Tủ lạnh midea 30l', 'Đồ gia dụng', 42, 5, 'Điện máy xanh', false, false),
    ('Máy lạnh parasonic', 'Đồ gia dụng', 4, 5, 'Điện máy xanh', false, false);
    
create table ItemOrder
(
	id INT unsigned auto_increment primary key,
    createddate date not null,
    owner varchar(100) not null,
    type int not null,
    listItem text,
    isApproved boolean
);
insert into ItemOrder(createddate, owner, type, listItem, isApproved)
values('2020-05-11', 'Tổng giám đốc', 0, '1 2 3', false);
