drop database quanlybanhang;
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
    isApproved boolean,
	isDeleted boolean default false
);
insert into ItemOrder(createddate, owner, type, listItem, isApproved)
values('2020-05-11', 'Tổng giám đốc', 0, '1 2 3', false);

create table GuaranteeItem
(
	id int unsigned auto_increment primary key,
    createdUser int,
    itemId int,
    provider varchar(100),
    status text,
    reason text,
    isApproved boolean,
    isDeleted boolean default false
);

CREATE TABLE IF NOT EXISTS `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `customer_id` int(100) NOT NULL,
  `status` int(11) NOT NULL,
  `detail` text NOT NULL,
  `time_update` datetime NOT NULL,
  `handle_type` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `comment`:
--

--
-- Đang đổ dữ liệu cho bảng `comment`
--

INSERT INTO `comment` (`id`, `product_id`, `customer_id`, `status`, `detail`, `time_update`, `handle_type`) VALUES
(12, 6, 9, 3, 'Hàng rất ngon lành cành đào, phù hợp cho anh em nào có điều kiện để sỡ hữu một con chip khủng nhất ở thời điểm hiện tại', '2020-05-13 00:00:00', 0),
(13, 6, 10, 3, 'Mình được tư vấn mua con này về tặng cho người yêu của mình như quà tạ lỗi việc mình hay không nghe lời anh ấy, nhận được quà anh ấy cảm ơn mình rối rít quên luôn cả chuyện giậ nhờn :v', '0000-00-00 00:00:00', 0),
(14, 7, 14, 3, 'Hàng chất lượng tốt mỗi tội dán bảo hành hơi ngu, nhận được hàng không tháo tem bảo hành là không biết làm sao lắp vào mainboard luôn các bác ạ T.T', '0000-00-00 00:00:00', 0),
(15, 6, 11, 0, 'Các bác cho em hỏi máy em xài tản atc 700 với main board b360 nguồn 550W 1660Ti thì chạy nổi con này không vậy ạ! Vùa mới trúng mánh vô được cục tiền ấm quá mà sợ mua về không chạy hết được hiệu năng. Hu hu', '0000-00-00 00:00:00', 0),
(16, 6, 12, 0, 'Trang này toàn bán đồ dỏm không thôi các bác ạ, trước em mua con tản nhiệt Corshair ở đây về xài được tháng thì rap nước bị xì, liên hệ đòi bảo hành thì họ bảo phải liên hệ với nhà cung cấp chứ bên đây không có trách nhiệm gì cả', '0000-00-00 00:00:00', 0),
(17, 7, 15, 0, 'Hàng chuyển tới ngon hơn cả trong hình các bác ạ, sync hẳn hoi với ram và tản nhiệt, giờ case em nó cứ lung linh là lên luôn, ai nhìn vào cũng mê mệt', '0000-00-00 00:00:00', 0),
(18, 7, 16, 0, 'Sao thấy trang này bán hàng mắc hơn mấy trang khác vậy nhỉ, lại còn ít khuyến mãi nữa :v', '0000-00-00 00:00:00', 0),
(19, 6, 13, 0, 'Cho tôi hỏi có kèm keo tản nhiệt không vậy shop . tôi ở Thuận giao , Thuận an , Bình dương thì có giao tận nhà ko vậy', '0000-00-00 00:00:00', 0),
(20, 7, 17, 0, 'Cho tôi hỏi có hỗ trợ lắp đặt tại nhà không vậy, nghe bạn bảo main này xài vip lắm, lại đẹp nữa mỗi tội thân con gái không rành mấy cái này', '0000-00-00 00:00:00', 0),
(21, 7, 18, 0, 'Sản phẩm nào khi vào đặt mua cũng nói là chỉ giao hàng tại sài gòn và hà nội cần thơ nếu vậy thì quảng cáo chi rộng vậy mât công', '0000-00-00 00:00:00', 0),
(22, 8, 19, 0, 'Có ship về Bình Chánh không vậy shop ơi, nếu có thì mất khoảng bao nhiêu ngày vậy', '0000-00-00 00:00:00', 0),
(23, 8, 20, 0, 'Hàng đặt cả tuần lễ rồi chưa thấy giao, gọi điện hỏi thì trả lời hời hợt, chả hiểu mấy ông làm ăn kiểu gì', '0000-00-00 00:00:00', 0),
(24, 8, 21, 0, 'Sao mua về lắp vào không chạy được vậy shop, hàng có lỗi không vậy', '0000-00-00 00:00:00', 0),
(25, 8, 22, 0, 'Đồ bán thì dỏm, bán thì đắt, nhân viên thì bố láo bố lếu, chuyển hàng thì lâu, nổ địa chỉ tao qua t trị từng thằng', '0000-00-00 00:00:00', 0),
(26, 8, 23, 2, 'https://asdaswerzc.com nhận hack like facebook hack comment giá uy tính chất lượng', '2020-05-13 07:17:00', 0),
(27, 4, 1, 0, 'Ram này mua tầm 4 con về lắp vào 4 khe xong dùn rgb fugushion chạy mượt cực kì còn hơn gái 18', '0000-00-00 00:00:00', 0),
(28, 4, 2, 0, 'Hình như ram này phải lắp chung với main aorus mới sync được đúng không vậy shop', '0000-00-00 00:00:00', 0),
(29, 4, 3, 0, 'Ram này lắp với ram burst thấp hơn thì không biết nó chạy có ổn áp không ta, hay là giờ phải vứt 2 em ram ở nhà mà mua 4 em này thì phí quá không', '0000-00-00 00:00:00', 0),
(30, 4, 4, 0, 'Mẫu này còn hàng không vậy shop ơi, mình muốn quất khoảng tầm 4 con này', '0000-00-00 00:00:00', 0),
(31, 4, 5, 0, 'Cửa hàng có mở không ạ hay chỉ bán online vậy ạ', '0000-00-00 00:00:00', 0),
(32, 5, 6, 1, 'Định mua vì được tặng chuột bây giờ hết khuyến mãi rồi chán quá trời quá đất', '2020-05-13 06:49:50', 1),
(33, 5, 7, 0, 'Chip yếu nguồn yếu làm sao đua con này đây, mua về chắc toàn nghẽn cổ chai tối ngày', '0000-00-00 00:00:00', 0),
(34, 5, 8, 0, 'Con này với con 2060Ti thì nên mua con nào vậy các bác, có ai có link phân tích hiệu suất của con này không ạ', '0000-00-00 00:00:00', 0);
COMMIT;

CREATE TABLE IF NOT EXISTS `customer` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `address` text NOT NULL,
  `point` int(11) NOT NULL,
  `is_banned` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `customer`:
--

--
-- Đang đổ dữ liệu cho bảng `customer`
--

INSERT INTO `customer` (`id`, `name`, `email`, `address`, `point`, `is_banned`) VALUES
(1, 'Võ Minh Hiếu', 'vmhieu@gmail.com', '85/ 65 Phạm Viết Chánh, Phường 19, Bình Thạnh, TP HCM', 0, 0),
(2, 'Nguyễn Văn Nghĩa', 'nvnghia@gmail.com', '184 Nguyễn Chí Thanh, Quận 10, TP HCM', 0, 0),
(3, 'Võ Thanh Hiếu', 'vthieu@gmail.com', '38 Tú Xương, Phường 7, Quận 3, Sài Gòn', 0, 0),
(4, 'Võ Lê Minh', 'vlminh@gmail.com', '215 Võ Thị Sáu, Phường 7, Quận 3, TP HCM', 0, 0),
(5, 'Cái Nhân Đức', 'cnduc@gmail.com', '18 Võ Văn Ngân, Thủ Đức, TP HCM', 0, 0),
(6, 'Võ Lê Công Kết', 'vlcket@gmail.com', '459B Nguyễn Đình Chiểu, Quận 3, TP HCM', 1, 0),
(7, 'Trịnh Đại Phát', 'tdphat@gmail.com', '80/76 Trần Quang Diệu, Phường14, Quận 3, TP HCM', 0, 0),
(8, 'Nguyễn Như Anh', 'nnanh@gmail.com', '838 Tú Xương, Phường 7, Quận 3, Sài Gòn', 0, 0),
(9, 'Nguyễn Thái Hoàng', 'nthoang@gmail.com', '210/18/2 Cách mạng Tháng 8, Phường 10, Quận 3, TP HCM', 0, 0),
(10, 'Trần Hoàng Anh Thư', 'thathu@gmail.com', '16/99 – 16/101 Kỳ Đồng, Phường 9, Quận 3, TP HCM', 0, 0),
(11, 'Đặng Quang Huy', 'dqhuy@gmail.com', '275/6/7 Lý Thường Kiệt, Phường 15, Quận 11', 0, 0),
(12, 'Hồ Hoàng Hảo', 'hhhao@gmail.com', '218 Phó Cơ Điền, Phường 6, Quận 11, TP HCM', 0, 0),
(13, 'Dư Kiến Luân', 'dkluan@gmail.com', '48/10 Hòa Hưng, Phường 12, Quận 10, TP HCM', 0, 0),
(14, 'Lê Xuân Kha', 'lxkha@gmail.com', '57B/500 Lê Hồng Phong, Phường 1, Quận 10, TP HCM', 0, 0),
(15, 'Nguyễn Thành Đô', 'ntdo@gmail.com', '133/ 5 Hòa Hưng, Phường 4, Quận 10, TP HCM', 0, 0),
(16, 'Trần Thiên Hoàng', 'tthoang@gmail.com', '273 Quốc Lộ 1A, Phường Bình Chiểu, Thủ Đức, TP HCM', 0, 0),
(17, 'Trần Hoàng Khánh Châu', 'thkchau@gmail.com', '24/7 đường số 1, KP.1 Phường Tam Đình, Thủ Đức, TP HCM', 0, 0),
(18, 'Trần Hưng Tài', 'thtai@gmail.com', '97 Trường Chinh, Phường 12, Tân Bình, TP HCM', 0, 0),
(19, 'Trần Hưng Quốc', 'thquoc@gmail.com', '40 Đặng văn Bi, phường Bình Thọ, Thủ Đức, TP HCM', 0, 0),
(20, 'Nguyễn Trường Hải', 'nthai@gmail.com', '122 Nguyễn Ngọc Nhựt, Phường Tân Quý, Tân Phú, TP HCM', 0, 0),
(21, 'Nguyễn Minh Châu', 'nmchau@gmail.com', '17/15/11 Gò Dầu, Phường Tân Quý, Quận Tân Phú, TP HCM', 0, 0),
(22, 'Hồ Ngọc Long', 'hnlong@gmail.com', '261/1A Đồng Đen, Phường 14, Tân Bình, TP HCM', 0, 0),
(23, 'Phan Dương Phi', 'pdphi@gmail.com', ' 96 Nguyễn Thượng Hiền, Phường 5, Gò Vấp, TP HCM', 0, 0);
COMMIT;

