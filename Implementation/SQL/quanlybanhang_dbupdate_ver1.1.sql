-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th5 11, 2020 lúc 05:45 PM
-- Phiên bản máy phục vụ: 10.4.8-MariaDB
-- Phiên bản PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `quanlybanhang`
--
CREATE DATABASE IF NOT EXISTS `quanlybanhang` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `quanlybanhang`;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `comment`
--
-- Tạo: Th5 11, 2020 lúc 01:57 PM
-- Cập nhật lần cuối: Th5 11, 2020 lúc 02:59 PM
--

DROP TABLE IF EXISTS `comment`;
CREATE TABLE `comment` (
  `id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `email` varchar(100) NOT NULL,
  `status` int(11) NOT NULL,
  `detail` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `comment`:
--

--
-- Đang đổ dữ liệu cho bảng `comment`
--

INSERT INTO `comment` (`id`, `product_id`, `email`, `status`, `detail`) VALUES
(12, 1, 'nthoang1996@gmail.com', 0, 'Hàng rất ngon lành cành đào, phù hợp cho anh em nào có điều kiện để sỡ hữu một con chip khủng nhất ở thời điểm hiện tại'),
(13, 1, 'thathu1999@gmail.com', 0, 'Mình được tư vấn mua con này về tặng cho người yêu của mình như quà tạ lỗi việc mình hay không nghe lời anh ấy, nhận được quà anh ấy cảm ơn mình rối rít quên luôn cả chuyện giậ nhờn :v'),
(14, 2, 'lxkha@gmail.com', 0, 'Hàng chất lượng tốt mỗi tội dán bảo hành hơi ngu, nhận được hàng không tháo tem bảo hành là không biết làm sao lắp vào mainboard luôn các bác ạ T.T'),
(15, 1, 'dqhuy@gmail.com', 0, 'Các bác cho em hỏi máy em xài tản atc 700 với main board b360 nguồn 550W 1660Ti thì chạy nổi con này không vậy ạ! Vùa mới trúng mánh vô được cục tiền ấm quá mà sợ mua về không chạy hết được hiệu năng. Hu hu'),
(16, 1, 'hhhao@gmail.com', 0, 'Trang này toàn bán đồ dỏm không thôi các bác ạ, trước em mua con tản nhiệt Corshair ở đây về xài được tháng thì rap nước bị xì, liên hệ đòi bảo hành thì họ bảo phải liên hệ với nhà cung cấp chứ bên đây không có trách nhiệm gì cả'),
(17, 2, 'ntdo@gmail.com', 0, 'Hàng chuyển tới ngon hơn cả trong hình các bác ạ, sync hẳn hoi với ram và tản nhiệt, giờ case em nó cứ lung linh là lên luôn, ai nhìn vào cũng mê mệt'),
(18, 2, 'tthoang@gmail.com', 0, 'Sao thấy trang này bán hàng mắc hơn mấy trang khác vậy nhỉ, lại còn ít khuyến mãi nữa :v'),
(19, 1, 'dkluan@gmail.com', 0, 'Cho tôi hỏi có kèm keo tản nhiệt không vậy shop . tôi ở Thuận giao , Thuận an , Bình dương thì có giao tận nhà ko vậy'),
(20, 2, 'thkchau@gmail.com', 0, 'Cho tôi hỏi có hỗ trợ lắp đặt tại nhà không vậy, nghe bạn bảo main này xài vip lắm, lại đẹp nữa mỗi tội thân con gái không rành mấy cái này'),
(21, 2, 'thtai@gmail.com', 0, 'Sản phẩm nào khi vào đặt mua cũng nói là chỉ giao hàng tại sài gòn và hà nội cần thơ nếu vậy thì quảng cáo chi rộng vậy mât công'),
(22, 3, 'thquoc@gmail.com', 0, 'Có ship về Bình Chánh không vậy shop ơi, nếu có thì mất khoảng bao nhiêu ngày vậy'),
(23, 3, 'nthai@gmail.com', 0, 'Hàng đặt cả tuần lễ rồi chưa thấy giao, gọi điện hỏi thì trả lời hời hợt, chả hiểu mấy ông làm ăn kiểu gì'),
(24, 3, 'nmchau@gmail.com', 0, 'Sao mua về lắp vào không chạy được vậy shop, hàng có lỗi không vậy'),
(25, 3, 'hnlong@gmail.com', 0, 'Đồ bán thì dỏm, bán thì đắt, nhân viên thì bố láo bố lếu, chuyển hàng thì lâu, nổ địa chỉ tao qua t trị từng thằng'),
(26, 3, 'pdphi@gmail.com', 0, 'https://asdaswerzc.com nhận hack like facebook hack comment giá uy tính chất lượng'),
(27, 4, 'vmhieu@gmail.com', 0, 'Ram này mua tầm 4 con về lắp vào 4 khe xong dùn rgb fugushion chạy mượt cực kì còn hơn gái 18'),
(28, 4, 'nvnghia@gmail.com', 0, 'Hình như ram này phải lắp chung với main aorus mới sync được đúng không vậy shop'),
(29, 4, 'vthieu@gmail.com', 0, 'Ram này lắp với ram burst thấp hơn thì không biết nó chạy có ổn áp không ta, hay là giờ phải vứt 2 em ram ở nhà mà mua 4 em này thì phí quá không'),
(30, 4, 'vlminh@gmail.com', 0, 'Mẫu này còn hàng không vậy shop ơi, mình muốn quất khoảng tầm 4 con này'),
(31, 4, 'cnduc@gmail.com', 0, 'Cửa hàng có mở không ạ hay chỉ bán online vậy ạ'),
(32, 5, 'vlcket@gmail.com', 0, 'Định mua vì được tặng chuột bây giờ hết khuyến mãi rồi chán quá trời quá đất'),
(33, 5, 'tdphat@gmail.com', 0, 'Chip yếu nguồn yếu làm sao đua con này đây, mua về chắc toàn nghẽn cổ chai tối ngày'),
(34, 5, 'nnanh@gmail.com', 0, 'Con này với con 2060Ti thì nên mua con nào vậy các bác, có ai có link phân tích hiệu suất của con này không ạ');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `item`
--
-- Tạo: Th5 11, 2020 lúc 03:17 AM
-- Cập nhật lần cuối: Th5 11, 2020 lúc 03:17 AM
--

DROP TABLE IF EXISTS `item`;
CREATE TABLE `item` (
  `id` int(10) UNSIGNED NOT NULL,
  `name` varchar(100) NOT NULL,
  `type` varchar(100) NOT NULL,
  `amount` int(11) NOT NULL,
  `minimum` int(11) NOT NULL,
  `provider` varchar(100) DEFAULT NULL,
  `isRequestImport` tinyint(1) DEFAULT NULL,
  `isDeleted` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `item`:
--

--
-- Đang đổ dữ liệu cho bảng `item`
--

INSERT INTO `item` (`id`, `name`, `type`, `amount`, `minimum`, `provider`, `isRequestImport`, `isDeleted`) VALUES
(1, 'Intel Core i9-9900K', 'Linh kiện máy tính', 41, 10, 'Viễn Sơn', 1, 0),
(2, 'Aorus Z390 Xtreme', 'Linh kiện máy tính', 33, 10, 'Viễn Sơn', 1, 0),
(3, 'RAM G.Skill TridentZ 16GB 3200MHz', 'Linh kiện máy tính', 8, 10, 'Viễn Sơn', 1, 0),
(4, 'RAM Aorus RGB 16GB (8GBx2) 3600MHz', 'Linh kiện máy tính', 2, 10, 'Viễn Sơn', 0, 0),
(5, 'Aorus GTX 1080TI Xtreme 11GB', 'Linh kiện máy tính', 1, 10, 'Viễn Sơn', 0, 0),
(6, 'Aorus RTX 2070 Super Xtreme 8GB', 'Linh kiện máy tính', 71, 10, 'Viễn Sơn', 0, 0),
(7, 'SSD Samsung 970 EVO 500GB', 'Linh kiện máy tính', 27, 10, 'Viễn Sơn', 0, 0),
(8, 'Thịt ba chỉ', 'Thực phẩm', 31, 20, 'Bách hoá xanh', 0, 0),
(9, 'Thịt đùi', 'Thực phẩm', 76, 20, 'Bách hoá xanh', 0, 0),
(10, 'Rau cải', 'Thực phẩm', 99, 100, 'Bách hoá xanh', 0, 0),
(11, 'Rau bó xôi', 'Thực phẩm', 131, 100, 'Bách hoá xanh', 0, 0),
(12, 'Tivi Sony 49 inch', 'Đồ gia dụng', 14, 5, 'Điện máy xanh', 0, 0),
(13, 'Tủ lạnh midea 30l', 'Đồ gia dụng', 42, 5, 'Điện máy xanh', 0, 0),
(14, 'Máy lạnh parasonic', 'Đồ gia dụng', 4, 5, 'Điện máy xanh', 0, 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `itemorder`
--
-- Tạo: Th5 11, 2020 lúc 03:17 AM
-- Cập nhật lần cuối: Th5 11, 2020 lúc 03:17 AM
--

DROP TABLE IF EXISTS `itemorder`;
CREATE TABLE `itemorder` (
  `id` int(10) UNSIGNED NOT NULL,
  `createddate` date NOT NULL,
  `owner` varchar(100) NOT NULL,
  `type` int(11) NOT NULL,
  `listItem` text DEFAULT NULL,
  `isApproved` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `itemorder`:
--

--
-- Đang đổ dữ liệu cho bảng `itemorder`
--

INSERT INTO `itemorder` (`id`, `createddate`, `owner`, `type`, `listItem`, `isApproved`) VALUES
(1, '2020-05-11', 'Tổng giám đốc', 0, '1 2 3', 0);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `user`
--
-- Tạo: Th5 11, 2020 lúc 03:17 AM
-- Cập nhật lần cuối: Th5 11, 2020 lúc 03:17 AM
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(10) UNSIGNED NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `name` varchar(100) NOT NULL,
  `role` int(11) NOT NULL,
  `isDeleted` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `user`:
--

--
-- Đang đổ dữ liệu cho bảng `user`
--

INSERT INTO `user` (`id`, `username`, `password`, `name`, `role`, `isDeleted`) VALUES
(1, 'admin', 'admin', 'Tổng giám đốc', 0, 0),
(2, 'quanly', 'quanly', 'Quản lý', 0, 0),
(3, 'banhang', 'banhang', 'Bán hàng', 1, 0),
(4, 'shipper', 'shipper', 'Người giao hàng', 2, 0),
(5, 'advertiser', 'advertiser', 'Người đăng tin', 3, 0),
(6, 'treasurer', 'treasurer', 'Thủ quỹ', 4, 0),
(7, 'zannaghazi', 'zannaghazi123', 'CEO Võ Thanh Hiếu', 0, 0);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `comment`
--
ALTER TABLE `comment`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `item`
--
ALTER TABLE `item`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `itemorder`
--
ALTER TABLE `itemorder`
  ADD PRIMARY KEY (`id`);

--
-- Chỉ mục cho bảng `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `comment`
--
ALTER TABLE `comment`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT cho bảng `item`
--
ALTER TABLE `item`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT cho bảng `itemorder`
--
ALTER TABLE `itemorder`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT cho bảng `user`
--
ALTER TABLE `user`
  MODIFY `id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
