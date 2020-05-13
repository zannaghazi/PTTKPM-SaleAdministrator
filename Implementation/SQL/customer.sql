-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th5 13, 2020 lúc 03:52 AM
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

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customer`
--
-- Tạo: Th5 13, 2020 lúc 12:32 AM
-- Cập nhật lần cuối: Th5 13, 2020 lúc 01:50 AM
--

DROP TABLE IF EXISTS `customer`;
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

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
