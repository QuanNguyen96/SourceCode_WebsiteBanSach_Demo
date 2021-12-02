-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th2 19, 2021 lúc 03:12 PM
-- Phiên bản máy phục vụ: 10.1.38-MariaDB
-- Phiên bản PHP: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `taikhoan`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `danhgia`
--

CREATE TABLE `danhgia` (
  `MaSP` int(11) NOT NULL,
  `MaKH` int(100) NOT NULL,
  `DanhGia` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `danhgia`
--

INSERT INTO `danhgia` (`MaSP`, `MaKH`, `DanhGia`) VALUES
(78, 1, 5),
(78, 0, 4);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `danhmuc`
--

CREATE TABLE `danhmuc` (
  `MaDanhMuc` int(155) NOT NULL,
  `TenDanhMuc` varchar(200) COLLATE utf8_unicode_ci NOT NULL,
  `HinhAnh` varchar(200) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `danhmuc`
--

INSERT INTO `danhmuc` (`MaDanhMuc`, `TenDanhMuc`, `HinhAnh`) VALUES
(1, 'Thời Trang Nam', 'thoitrangnam.PNG'),
(2, 'Thời Trang Nữ', 'thoitrangnu.PNG'),
(3, 'Bách Hóa Online', 'bachhoaonline.PNG'),
(4, 'Chăm Sóc Thú Cưng', 'chamsocthucung.PNG'),
(5, 'Giày Dép Nữ', 'daydepnu.PNG'),
(6, 'Điện Thoại Và Phụ Kiện', 'dienthoaivaphukien.PNG'),
(7, 'Đồ Chơi', 'dochoi.PNG'),
(8, 'Đồng Hồ', 'dongho.PNG'),
(9, 'Giặt Giũ & Chăm Sóc Nhà Cửa', 'giatdu.PNG'),
(10, 'Giày Dép Nam', 'giaydepnam.PNG'),
(11, 'Máy Ảnh & Máy Quay Phim', 'mayanhvamayquayphim.PNG'),
(12, 'Máy Tính & Lap Top', 'maytinhvalaptop.PNG'),
(13, 'Mẹ Và Bé', 'mevabe.PNG'),
(14, 'Nhà Cửa & Đời Sống', 'nhacuavadoisong.PNG'),
(15, 'Nhà Sách Online', 'nhasachonline.PNG'),
(16, 'Ô tô - Xe máy - Xe đạp', 'otoxemayxedap.PNG'),
(17, 'Phụ Kiện Thời Trang', 'phukienthoitrang.PNG'),
(18, 'Sản Phẩm Khác', 'sanphamkhac.PNG'),
(19, 'Sức Khỏa & Sắc Đẹp', 'suckhoevasacdep.PNG'),
(20, 'Thể Thao & Du Lịch', 'thethaovadulich.PNG'),
(21, 'Thiết Bị Điện Tử', 'thietbidientu.PNG'),
(22, 'Thiết Bị Gia Dụng', 'thietbigiadung.PNG'),
(23, 'Thời Trang Trẻ Em', 'thoitrangtreem.PNG'),
(24, 'Túi Ví', 'tuivi.PNG'),
(25, 'Voucher & Dịch Vụ', 'vouchordichvu.PNG');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `hinhanhsp`
--

CREATE TABLE `hinhanhsp` (
  `MaSP` int(11) NOT NULL,
  `HinhAnhSP` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `hinhanhsp`
--

INSERT INTO `hinhanhsp` (`MaSP`, `HinhAnhSP`) VALUES
(15, 's.PNG'),
(16, 'ao1.PNG'),
(17, 'ao2.PNG'),
(18, 'ao3.PNG'),
(19, 'ao4.PNG'),
(20, 'ao5.PNG'),
(21, 'ao6.PNG'),
(15, 'ao7.PNG'),
(7, 'aothun.PNG'),
(22, 'aoloi.PNG'),
(23, 'aococnam.PNG'),
(24, 'ao7.PNG'),
(25, 'a8.PNG'),
(26, 'ao1.PNG'),
(27, 'ao2.PNG'),
(28, 'ao3.PNG'),
(29, 'ao4.PNG'),
(30, 'ao5.PNG'),
(31, 'ao6.PNG'),
(32, 't1.PNG'),
(33, 't2.PNG'),
(34, 't3.PNG'),
(35, 't4.PNG'),
(36, 't5.PNG'),
(37, 't6.PNG'),
(38, 't7.PNG'),
(39, 's1.PNG'),
(40, 's2.PNG'),
(41, 's3.PNG'),
(42, 's4.PNG'),
(43, 's5.PNG'),
(44, 's6.PNG'),
(45, 's7.PNG'),
(46, 'may1.PNG'),
(47, 'may2.PNG'),
(48, 'may3.PNG'),
(49, 'may4.PNG'),
(50, 'may5.PNG'),
(51, 'may6.PNG'),
(52, 'may7.PNG'),
(53, 'l1.PNG'),
(54, 'l2.PNG'),
(55, 'l3.PNG'),
(56, 'l4.PNG'),
(57, 'l5.PNG'),
(58, 'l6.PNG'),
(59, 'l7.PNG'),
(60, 'dep1.PNG'),
(61, 'dep2.PNG'),
(62, 'dep3.PNG'),
(63, 'dep4.PNG'),
(64, 'dep5.PNG'),
(65, 'giay1.PNG'),
(66, 'giay2.PNG'),
(67, 'giay3.PNG'),
(68, 'giay4.PNG'),
(69, 'giay5.PNG'),
(70, 'giay6.PNG'),
(71, 'giay7.PNG'),
(72, 'giaydepda.PNG'),
(73, 'giaythethao.PNG'),
(74, 'dh1.PNG'),
(75, 'dh2.PNG'),
(76, 'dh3.PNG'),
(77, 'dh4.PNG'),
(78, 'dh5.PNG'),
(79, 'dh6.PNG'),
(80, 'dh7.PNG'),
(81, 'dh4.PNG'),
(82, 'sim4g.PNG'),
(83, 'sim4g2.PNG'),
(84, 'bp1.PNG'),
(85, 'bp2.PNG'),
(86, 'bp3.PNG'),
(87, 'bp4.PNG'),
(88, 'bp5.PNG'),
(89, 'bp6.PNG'),
(90, 'bp7.PNG'),
(78, 'dh6.PNG'),
(78, 'dh7.PNG'),
(78, 'dh3.PNG');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `khosp`
--

CREATE TABLE `khosp` (
  `MaSP` int(11) NOT NULL,
  `SoLuong` bigint(20) NOT NULL,
  `DaBan` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `khosp`
--

INSERT INTO `khosp` (`MaSP`, `SoLuong`, `DaBan`) VALUES
(7, 34, 23),
(15, 100, 32),
(16, 434, 34),
(17, 2323, 43),
(18, 322, 32),
(19, 322, 23),
(20, 23, 2),
(21, 33, 32),
(22, 23, 12),
(23, 32, 23),
(24, 2, 1),
(25, 23, 12),
(26, 322, 23),
(27, 232, 28),
(28, 233, 28),
(29, 32, 11),
(30, 322, 25),
(31, 232, 32),
(32, 22, 1),
(33, 300, 243),
(34, 23, 2),
(35, 434, 23),
(36, 434, 32),
(37, 43, 3),
(38, 43, 34),
(39, 32, 2),
(40, 34, 19),
(40, 323, 122),
(41, 200, 186),
(42, 78, 67),
(43, 78, 32),
(44, 200, 98),
(45, 877, 560),
(46, 545, 45),
(47, 35, 23),
(48, 434, 49),
(49, 870, 434),
(50, 23, 12),
(51, 100, 23),
(52, 100, 234),
(53, 100, 43),
(54, 100, 87),
(55, 756, 566),
(57, 65, 34),
(58, 56, 54),
(59, 45, 42),
(60, 54, 23),
(61, 555, 234),
(62, 76, 3),
(63, 100, 56),
(64, 200, 45),
(65, 300, 34),
(66, 100, 43),
(67, 340, 280),
(68, 32, 23),
(69, 300, 34),
(70, 200, 154),
(71, 200, 132),
(72, 150, 81),
(73, 65, 12),
(74, 23, 1),
(75, 233, 23),
(76, 435, 233),
(77, 200, 121),
(78, 20, 8),
(79, 50, 34),
(80, 100, 48),
(81, 100, 16),
(82, 20, 3),
(83, 300, 280),
(84, 200, 58),
(85, 100, 42),
(86, 100, 19),
(87, 100, 82),
(88, 100, 92),
(89, 100, 8),
(90, 200, 124);

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `members`
--

CREATE TABLE `members` (
  `id` int(100) NOT NULL,
  `username` varchar(65) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(65) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `members`
--

INSERT INTO `members` (`id`, `username`, `password`) VALUES
(1, 'quan', '19101996'),
(0, 'cua', 'cua123'),
(0, 'tuan123', 'hihi'),
(0, 'quansdf', '81dc9bdb52d04dc20036dbd8313ed055'),
(0, 'quansdfqw', 'c20ad4d76fe97759aa27a0c99bff6710'),
(0, 'tuan12', 'c20ad4d76fe97759aa27a0c99bff6710'),
(0, 'tuan', 'd6b8cc42803ea100735c719f1d7f5e11'),
(0, 'tuan', 'tuan');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL,
  `product_code` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `product_name` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `product_desc` tinytext COLLATE utf8_unicode_ci NOT NULL,
  `product_img_name` varchar(60) COLLATE utf8_unicode_ci NOT NULL,
  `price` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `sanpham`
--

CREATE TABLE `sanpham` (
  `MaSP` int(11) NOT NULL,
  `TenSP` text COLLATE utf8_unicode_ci NOT NULL,
  `MaDanhMuc` int(11) NOT NULL,
  `MaSanXuat` int(11) NOT NULL,
  `MaHASP` int(11) NOT NULL,
  `MABL` int(11) NOT NULL,
  `MADG` int(11) NOT NULL,
  `MoTa` longtext COLLATE utf8_unicode_ci NOT NULL,
  `SoLuong` bigint(20) NOT NULL,
  `GiaBanGoc` bigint(20) NOT NULL,
  `GiaBanHienTai` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `sanpham`
--

INSERT INTO `sanpham` (`MaSP`, `TenSP`, `MaDanhMuc`, `MaSanXuat`, `MaHASP`, `MABL`, `MADG`, `MoTa`, `SoLuong`, `GiaBanGoc`, `GiaBanHienTai`) VALUES
(7, '[SALE]Combo Áo Len Nam Cổ Tròn Kèm 3 Đôi Tất Nam Ngắn Cổ Chất Lượng Cao', 1, 0, 0, 0, 0, 'Tên sản phẩm:Combo áo len nam cổ tròn kèm 3 đôi tất nam ngắn cổ\r\nHàng Việt Nam xuất khẩu giá rẻ cho mọi người\r\nHàng 1 size cho người từ 50kg đến 70kg,cao từ 1m6-1m78\r\nMàu sắc gồm:Đen,be,xanh than,xanh dương ,đỏ đô ,xám\r\nHàng đẹp giá rẻ không đâu rẻ bằng lại dễ mặc ấm áp cho mùa đông này,nhanh tay rinh về 1 em cho tủ áo quần của mình nào\r\nSản phẩm kèm 3 đôi tất nam ngắn cổ, nếu bạn lấy mẫuu nào bạn cứ nhắn tin cho shop nhé, shop sẽ trả lời ngay cho bạn.\r\nĐến với shop nguyenphu046 bạn sẽ được tư vấn nhiệt tình cụ thể  về thông tin sản phẩm bạn cần  cũng như thông tin liên quan đến các chính sách của shopee có thể bạn chưa rõ như cách mua nhiều mặt hàng cùng lúc, chính sách freeship của shopee, hay các mã giảm giá ngành hàng thời trang nam được dùng\r\nBên cạnh đó với sự nhiệt tình trong chăm sóc khách hàng shop sẽ mang đến sự hài lòng cho khách hàng, bạn mua xong sản phẩm kèm sau đó là sự chăm sóc khách hàng sau khi mua, sau khi mua hàng nếu gặp bất cứ vấn đề gì hãy ibox cho shop bạn sẽ được phản hồi giải đáp mọi thắc mắc cho bạn.\r\nMọi thắc mắc về sản phẩm cũng như đặt hàng hãy ibox cho shop nhé.1', 20, 34340, 12120),
(15, 'Áo Hoodies Sọc', 2, 0, 0, 0, 0, '', 10, 67999, 34000),
(16, 'Áo Thun Hai Dây Video Thật Và Ảnh Thật Chèn Tên', 2, 0, 0, 0, 0, '', 200, 45450, 12120),
(17, 'Sơ Mi Trắng Siêu Rẻ Đẹp', 2, 0, 0, 0, 0, '', 300, 100000, 65000),
(18, '[Rẻ Vô Địch] Áo Len Nữ Gucci', 2, 0, 0, 0, 0, '', 200, 43230, 23330),
(19, 'Set Bộ Nút', 2, 0, 0, 0, 0, '', 120, 65550, 45500),
(20, 'SET 4 QUẦN LÓT MUJI ĐÚC THÔNG HƠI KHÔNG ĐƯỜNG MAY SIÊU THOÁNG MÁT HÀNG XUẤT NHẬT', 2, 0, 0, 0, 0, '', 340, 72000, 32000),
(21, 'Áo Khoác Thể Thao Nữ HS 56481 ( Kèm Ảnh Thật )', 2, 0, 0, 0, 0, '', 230, 230000, 150000),
(22, 'Áo Khoác Nam Dù Trẻ Trung & Năng Động Cho Các Bạn Nam 2018', 1, 0, 0, 0, 0, '', 20, 56560, 45450),
(23, 'ÁO SƠ MI NAM TAY NGẮN CỔ BẺ CAO CẤP ( Hàng Loại 1)', 1, 0, 0, 0, 0, '', 400, 65000, 45000),
(24, '[SALE]Combo Áo Len Nam Cổ Tròn Kèm 3 Đôi Tất Nam Ngắn Cổ Chất Lượng Cao', 1, 0, 0, 0, 0, '', 330, 450000, 365400),
(25, 'ÁO THUN NAM -NỮ CỔ TRÒN ÔM BODY TAY NGẮN', 1, 0, 0, 0, 0, '', 60, 34000, 23500),
(26, 'Áo Chống Nắng Nam ( Giao Màu Ngẫu Nhiên)', 1, 0, 0, 0, 0, '', 300, 36500, 12000),
(27, '{HOT} Quần Kaki Dáng Hàn Màu Đen', 1, 0, 0, 0, 0, '', 20, 360000, 300500),
(28, 'ÁO THUN NAM -NỮ CỔ TRÒN ÔM BODY IN HÌNH ( Hàng Loại 1)\r\nChưa Có ', 1, 0, 0, 0, 0, '', 320, 78000, 67400),
(29, 'ÁO LEN NAM KẺ SỌC DÀY ẤM HÀNG LOẠI 1 _ ĐỦ SIZE M - 3XL', 1, 0, 0, 0, 0, '', 50, 120000, 86000),
(30, 'Túi Đeo Chéo Đa Năng Canvas Phong Cách Hàn Quốc Unisex Sành Điệu Cá Tính - Mẫu Mới 2018', 1, 0, 0, 0, 0, '', 34, 230000, 160000),
(31, 'Áo Khoác Jeans Nam Phong Cách Hàn Quốc Đẹp Trai', 1, 0, 0, 0, 0, '', 560, 56500, 12400),
(32, 'Cân Điên Tử Mini Cầm Tay Tải 40Kg Màn Hình LCD', 21, 0, 0, 0, 0, '', 54, 56000, 35400),
(33, 'Bộ Mô Tảng Thiết Bị Điện Tử Thông Minh V2', 21, 0, 0, 0, 0, '', 45, 470000, 456500),
(34, 'Tay Rời Đo Điện Máy Cấp Nguồn INVITE', 21, 0, 0, 0, 0, '', 673, 230000, 45550),
(35, 'Bộ Vệ Sinh Thiết Bị Điện Tử JRC Đa Năng', 21, 0, 0, 0, 0, '', 455, 125400, 87000),
(36, 'Cân Điên Tử Cầm Tay 40Kg Màn Hình LCD', 21, 0, 0, 0, 0, '', 63, 162500, 120500),
(37, 'Chiết Hỏa Tử - Bật Lửa Thổi Phong Thủy', 21, 0, 0, 0, 0, '', 546, 235000, 158000),
(38, '[Nhập Mã SAMS300 Giảm Ngay 300k] Smart Tivi 4K Samsung 55 Inch UHD UA55NU7090KXXV', 21, 0, 0, 0, 0, '', 349, 65000, 48200),
(39, 'Sách - Lỡ Chúng Ta FA Cả Đời Thì Sao?', 15, 0, 0, 0, 0, '', 5643, 187000, 152000),
(40, 'Sách Truyền Cảm Hứng - Tuổi Trẻ Đáng Giá Bao Nhiêu', 15, 0, 0, 0, 0, '', 7, 81000, 69500),
(41, 'Sách - Combo Bộ Giáo Trình Hán Ngữ 1,Vở Tập Viết Chữ Hán,301 Câu Đàm Thoại Tiếng Hoa Và Tụ Học Tiếng Trung', 15, 0, 0, 0, 0, '', 335, 464565, 232333),
(42, 'Sách Mặc Kệ Thiên Hạ - Sống Như Người Nhật', 15, 0, 0, 0, 0, '', 34, 562000, 452000),
(43, 'Sách - Combo 2 Tập 365 Truyện Mẹ Kể Con Nghe (Tái Bản 2018)', 15, 0, 0, 0, 0, '', 45, 170000, 120000),
(44, 'Sách - Ông Xã Là Phúc Hắc Đại Nhân (Bản Đặc Biệt Tặng Quà Số Lượng Có Hạn)', 15, 0, 0, 0, 0, '', 21, 650000, 480000),
(45, 'Khắc Dấu Bán Hàng Online', 15, 0, 0, 0, 0, '', 23, 45000, 18000),
(46, 'Máy Xông Hơi Mặt Sokany ZJ618 Chính Hãng', 19, 0, 0, 0, 0, '', 564, 454000, 345000),
(47, 'Máy Xông Mặt 2 Cần - 2 Chức Năng Nóng Và Lạnh BH 12 Tháng (Xả Kho 1 Tuần)', 19, 0, 0, 0, 0, '', 32, 740000, 398000),
(48, 'Máy Xông Hơi Mặt Sokany ZJ618 Chính Hãng', 19, 0, 0, 0, 0, '', 34, 120000, 69000),
(49, 'Máy Xông Hơi Mặt Hoa Quả Sokany', 19, 0, 0, 0, 0, '', 68, 560000, 360000),
(50, 'Máy Xông Mặt Hơi Nóng Nano Kingdom KD 33S', 19, 0, 0, 0, 0, '', 223, 360000, 205000),
(51, 'Máy Xông Mặt Hoa Quả Maoer', 19, 0, 0, 0, 0, '', 34, 368000, 254000),
(52, 'GIÁ TỐT - MÁY XÔNG MẶT BẰNG HƠI NƯỚC KEMEI 6068 - PPL01', 19, 0, 0, 0, 0, '', 10, 120500, 65000),
(53, 'Bộ Loa Vi Tính 2.0 AX210 Cực Sang Trọng', 21, 0, 0, 0, 0, '', 5, 1530000, 1125000),
(54, '[TẶNG VÒNG ĐÁ PHONG THỦY GIÁ 99K]_LOA BLUETOOTH CHARGE 3 - ÂM BASS CỰC CHẤT - THIẾT KẾ SANG TRỌNG', 21, 0, 0, 0, 0, '', 54, 165400, 99000),
(55, 'Loa Phóng Thanh Cầm Tay Mini Megaphone', 21, 0, 0, 0, 0, '', 20, 1050000, 650000),
(56, '(Loa chất lượng cao) Loa Bluetooth A10 Mini Vỏ Nhôm Di Động - Âm Thanh Tuyệt Hay.', 21, 0, 0, 0, 0, '', 17, 340000, 260000),
(57, 'Bộ Loa Vi Tính 2.0 AX210 Cực Sang Trọng', 21, 0, 0, 0, 0, '', 10, 650000, 425000),
(58, 'LOA VI TÍNH DELL 2.0 AX210 THIẾT KẾ ĐỘC ĐÁO,KIỂU DÁNG SANG TRỌNG (ĐEN)', 21, 0, 0, 0, 0, '', 34, 99000, 42500),
(59, 'Loa Bluetooth Xách Tay MS-205BT 8W (Đen) Nghe Được Đài FM Radio Follow + Chat Now Để Nhận Voucher Giảm Giá', 21, 0, 0, 0, 0, '', 2, 34300, 29000),
(60, 'Giày Nhựa Native Jefferson - Chất Nhựa E.V.A Siêu Nhẹ, Không Thấm Nước - Mã SP: Native-Xanh.Tím', 10, 0, 0, 0, 0, '', 25, 165000, 120000),
(61, '[ TẶNG VỚ + TẶNG HỘP ] GIÀY THỂ THAO NAM NỮ UZZANG PILA TRẮNG', 10, 0, 0, 0, 0, '', 23, 230000, 125000),
(62, 'Giầy Dép Nam Nhiều Kiểu', 10, 0, 0, 0, 0, '', 5, 200000, 99000),
(63, 'Giầy Dép Nam Nữ, Giày Sneaker Nam Cá Tính,TênAX0331 - XANH', 10, 0, 0, 0, 0, '', 33, 92000, 37000),
(64, 'GIÀY DÉP NAM DOCTOR GIÁ RẺ', 10, 0, 0, 0, 0, '', 8, 140000, 99000),
(65, 'Giày Dép Nam Da Bò Cao Cấp (Bảo Hành 1 Năm) - TC0184', 10, 0, 0, 0, 0, '', 67, 340000, 185000),
(66, 'Giày Dép Nam Hàn Quốc', 10, 0, 0, 0, 0, '', 7, 21330, 11200),
(67, '[GIÀY ĐẸP RẺ NHẤT] Giày Sneaker Nam, Thể Thao Thời Trang Hàn Quốc, Giày Quảng Châu LƯỚI II 21', 10, 0, 0, 0, 0, '', 32, 120000, 69500),
(68, '[RẺ VÔ ĐICH]Giày EQT[GIÀY THỂ THAO CHẤT LƯỢNG]', 10, 0, 0, 0, 0, '', 4, 76000, 36500),
(69, '[RẺ VÔ ĐICH]Giày EQT[GIÀY THỂ THAO CHẤT LƯỢNG]', 10, 0, 0, 0, 0, '', 32, 183000, 105000),
(70, 'GIÀY NAM THỂ THAO/ GIÀY NAM MẪU MỚI / GIÀY NAM RẺ', 10, 0, 0, 0, 0, '', 38, 1620000, 690000),
(71, 'GIÀY THỂ THAO NAM, GIÀY NAM ĐẸP, GIÀY NAM THỂ THAO, GIÀY SNEAKER NAM', 10, 0, 0, 0, 0, '', 89, 48000, 39000),
(72, 'GIÀY THỂ THAO NAM, GIÀY NAM ĐẸP, GIÀY NAM THỂ THAO, GIÀY SNEAKER NAM', 10, 0, 0, 0, 0, '', 62, 97000, 78000),
(73, 'GIÀY THỂ THAO NAM, GIÀY NAM ĐẸP, GIÀY NAM THỂ THAO, GIÀY SNEAKER NAM', 10, 0, 0, 0, 0, '', 55, 330000, 275000),
(74, 'Đồng Hồ Nữ BS 01 Chính Hãng', 8, 0, 0, 0, 0, '', 4, 2100000, 1800000),
(75, 'Đồng Hồ Nam Dây Da Chống Nước SKMEI BW016 - Boss Watches', 8, 0, 0, 0, 0, '', 6, 4500000, 3600000),
(76, '[FLASH SALE] Đồng Hồ Nữ SKMEI Mặt Vuông Dây Da Màu Đỏ Thời Thượng', 8, 0, 0, 0, 0, '', 67, 360000, 123000),
(77, 'Đồng Hồ Điện Tử SKMEI Nam Thể Thao Chính Hãng Đa Chức Năng Chống Va Đập Siêu Bền SME25 - Đồng Hồ Quốc Tế', 8, 0, 0, 0, 0, '', 62, 200500, 134000),
(78, '[ Big Sale Mua 1 Nhận 4] Đồng Hồ Nữ Khoá Nam Châm Cao Cấp Mobangtuo 2018 Chính Hãng Đính Đá Hai Bên Dây Sang Trảnh', 8, 0, 0, 0, 0, '', 32, 230000, 205000),
(79, 'Đồng Hồ Nam Nibosi Cao Cấp', 8, 0, 0, 0, 0, '', 56, 3000500, 2800000),
(80, 'Đồng Hồ Đôi HALEI 8119 Dây Thép Đặc Mặt Kính Chống Xước Kiểu Dang Thanh Lịch', 8, 0, 0, 0, 0, '', 578, 1200000, 860500),
(81, 'Đồng Hồ Đôi Nam Nữ Halei Chống Nước Dây Vàng Đẹp Đẽ', 8, 0, 0, 0, 0, '', 46, 950000, 800000),
(82, 'Điện Thoại Iphone 6 Đủ Màu 16GB 32GB 64GB 128GB Lock Và Quốc Tế', 6, 0, 0, 0, 0, '', 4, 6500000, 4850000),
(83, 'Sim 4G Vina D500 5Gb/Tháng, Miễn Phí 1 Năm Ko Cần Nạp Tiền', 6, 0, 0, 0, 0, '', 43, 500000, 360000),
(84, 'BÀN PHÍM VI TÍNH CÓ DÂY KONIG KB318', 21, 0, 0, 0, 0, '', 45, 89000, 45000),
(85, '[RẺ VÔ ĐỊCH] Bộ Bàn Phím, Chuột Giả Cơ Đèn LED 7 MÀU SIÊU ĐẸP GAMING G21 PRO 2018 , CHUYÊN CHƠI GAME', 21, 0, 0, 0, 0, '', 43, 250000, 210000),
(86, 'Combo Chuyên Game Bàn Phím Chuột G21, Eweadn T02, + Tai Nghe Robot Gt-03 ( Tặng Lót Chuột ) - NK', 21, 0, 0, 0, 0, '', 344, 300000, 252000),
(87, 'Bàn Phím G21 LED Giả Cơ Game Chuyên Dụng', 21, 0, 0, 0, 0, '', 23, 56000, 36000),
(88, '[FREESHIP] Bộ Bàn Phím Giả Cơ R8 1822 Và Chuột R8 1602 Led 7 Màu(Đen) + Tặng Kèm Tấm Lót Chuột', 21, 0, 0, 0, 0, '', 23, 45000, 18500),
(89, 'Combo Chuyên Game Bàn Phím Chuột G21, Eweadn T02, + Tai Nghe Robot Gt-03 ( Tặng Lót Chuột ) - NK', 21, 0, 0, 0, 0, '', 34, 350000, 265000),
(90, 'Bàn Phím Led Giả Cơ Hacker AK8000 Chuyên Cho Game Thủ (Đã Sử Dụng)', 21, 0, 0, 0, 0, '', 38, 545000, 270000);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `danhgia`
--
ALTER TABLE `danhgia`
  ADD KEY `MaSP` (`MaSP`),
  ADD KEY `MaKH` (`MaKH`);

--
-- Chỉ mục cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  ADD PRIMARY KEY (`MaDanhMuc`);

--
-- Chỉ mục cho bảng `hinhanhsp`
--
ALTER TABLE `hinhanhsp`
  ADD KEY `MaSP` (`MaSP`);

--
-- Chỉ mục cho bảng `khosp`
--
ALTER TABLE `khosp`
  ADD KEY `MaSP` (`MaSP`);

--
-- Chỉ mục cho bảng `members`
--
ALTER TABLE `members`
  ADD KEY `id` (`id`);

--
-- Chỉ mục cho bảng `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `product_code` (`product_code`);

--
-- Chỉ mục cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD PRIMARY KEY (`MaSP`),
  ADD KEY `MaDanhMuc` (`MaDanhMuc`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `danhmuc`
--
ALTER TABLE `danhmuc`
  MODIFY `MaDanhMuc` int(155) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT cho bảng `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  MODIFY `MaSP` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=91;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `danhgia`
--
ALTER TABLE `danhgia`
  ADD CONSTRAINT `danhgia_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`),
  ADD CONSTRAINT `danhgia_ibfk_2` FOREIGN KEY (`MaKH`) REFERENCES `members` (`id`);

--
-- Các ràng buộc cho bảng `hinhanhsp`
--
ALTER TABLE `hinhanhsp`
  ADD CONSTRAINT `hinhanhsp_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`) ON DELETE NO ACTION ON UPDATE CASCADE;

--
-- Các ràng buộc cho bảng `khosp`
--
ALTER TABLE `khosp`
  ADD CONSTRAINT `khosp_ibfk_1` FOREIGN KEY (`MaSP`) REFERENCES `sanpham` (`MaSP`);

--
-- Các ràng buộc cho bảng `sanpham`
--
ALTER TABLE `sanpham`
  ADD CONSTRAINT `sanpham_ibfk_1` FOREIGN KEY (`MaDanhMuc`) REFERENCES `danhmuc` (`MaDanhMuc`) ON DELETE NO ACTION ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
