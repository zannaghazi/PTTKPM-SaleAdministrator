-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th5 12, 2020 lúc 10:26 AM
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
-- Cấu trúc bảng cho bảng `comment`
--
-- Tạo: Th5 12, 2020 lúc 04:18 AM
--

DROP TABLE IF EXISTS `comment`;
CREATE TABLE IF NOT EXISTS `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_id` int(11) NOT NULL,
  `customer_id` int(100) NOT NULL,
  `status` int(11) NOT NULL,
  `detail` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4;

--
-- RELATIONSHIPS FOR TABLE `comment`:
--

--
-- Đang đổ dữ liệu cho bảng `comment`
--

INSERT INTO `comment` (`id`, `product_id`, `customer_id`, `status`, `detail`) VALUES
(12, 6, 9, 0, 'Hàng rất ngon lành cành đào, phù hợp cho anh em nào có điều kiện để sỡ hữu một con chip khủng nhất ở thời điểm hiện tại'),
(13, 6, 10, 0, 'Mình được tư vấn mua con này về tặng cho người yêu của mình như quà tạ lỗi việc mình hay không nghe lời anh ấy, nhận được quà anh ấy cảm ơn mình rối rít quên luôn cả chuyện giậ nhờn :v'),
(14, 7, 14, 0, 'Hàng chất lượng tốt mỗi tội dán bảo hành hơi ngu, nhận được hàng không tháo tem bảo hành là không biết làm sao lắp vào mainboard luôn các bác ạ T.T'),
(15, 6, 11, 0, 'Các bác cho em hỏi máy em xài tản atc 700 với main board b360 nguồn 550W 1660Ti thì chạy nổi con này không vậy ạ! Vùa mới trúng mánh vô được cục tiền ấm quá mà sợ mua về không chạy hết được hiệu năng. Hu hu'),
(16, 6, 12, 0, 'Trang này toàn bán đồ dỏm không thôi các bác ạ, trước em mua con tản nhiệt Corshair ở đây về xài được tháng thì rap nước bị xì, liên hệ đòi bảo hành thì họ bảo phải liên hệ với nhà cung cấp chứ bên đây không có trách nhiệm gì cả'),
(17, 7, 15, 0, 'Hàng chuyển tới ngon hơn cả trong hình các bác ạ, sync hẳn hoi với ram và tản nhiệt, giờ case em nó cứ lung linh là lên luôn, ai nhìn vào cũng mê mệt'),
(18, 7, 16, 0, 'Sao thấy trang này bán hàng mắc hơn mấy trang khác vậy nhỉ, lại còn ít khuyến mãi nữa :v'),
(19, 6, 13, 0, 'Cho tôi hỏi có kèm keo tản nhiệt không vậy shop . tôi ở Thuận giao , Thuận an , Bình dương thì có giao tận nhà ko vậy'),
(20, 7, 17, 0, 'Cho tôi hỏi có hỗ trợ lắp đặt tại nhà không vậy, nghe bạn bảo main này xài vip lắm, lại đẹp nữa mỗi tội thân con gái không rành mấy cái này'),
(21, 7, 18, 0, 'Sản phẩm nào khi vào đặt mua cũng nói là chỉ giao hàng tại sài gòn và hà nội cần thơ nếu vậy thì quảng cáo chi rộng vậy mât công'),
(22, 8, 19, 0, 'Có ship về Bình Chánh không vậy shop ơi, nếu có thì mất khoảng bao nhiêu ngày vậy'),
(23, 8, 20, 0, 'Hàng đặt cả tuần lễ rồi chưa thấy giao, gọi điện hỏi thì trả lời hời hợt, chả hiểu mấy ông làm ăn kiểu gì'),
(24, 8, 21, 0, 'Sao mua về lắp vào không chạy được vậy shop, hàng có lỗi không vậy'),
(25, 8, 22, 0, 'Đồ bán thì dỏm, bán thì đắt, nhân viên thì bố láo bố lếu, chuyển hàng thì lâu, nổ địa chỉ tao qua t trị từng thằng'),
(26, 8, 23, 0, 'https://asdaswerzc.com nhận hack like facebook hack comment giá uy tính chất lượng'),
(27, 4, 1, 0, 'Ram này mua tầm 4 con về lắp vào 4 khe xong dùn rgb fugushion chạy mượt cực kì còn hơn gái 18'),
(28, 4, 2, 0, 'Hình như ram này phải lắp chung với main aorus mới sync được đúng không vậy shop'),
(29, 4, 3, 0, 'Ram này lắp với ram burst thấp hơn thì không biết nó chạy có ổn áp không ta, hay là giờ phải vứt 2 em ram ở nhà mà mua 4 em này thì phí quá không'),
(30, 4, 4, 0, 'Mẫu này còn hàng không vậy shop ơi, mình muốn quất khoảng tầm 4 con này'),
(31, 4, 5, 0, 'Cửa hàng có mở không ạ hay chỉ bán online vậy ạ'),
(32, 5, 6, 0, 'Định mua vì được tặng chuột bây giờ hết khuyến mãi rồi chán quá trời quá đất'),
(33, 5, 7, 0, 'Chip yếu nguồn yếu làm sao đua con này đây, mua về chắc toàn nghẽn cổ chai tối ngày'),
(34, 5, 8, 0, 'Con này với con 2060Ti thì nên mua con nào vậy các bác, có ai có link phân tích hiệu suất của con này không ạ');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
