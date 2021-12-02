using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Drawing;

namespace WebApplication4.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        // Lấy giỏ hàng
        #region giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)   // nếu giỏ hàng chưa tồn tại thì tạo ra listgiohang
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        // thêm giỏ hàng
        public ActionResult ThemGioHang(int iMaSach, string strURL)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang Sach = listGioHang.Find(n => n.iMaSach == iMaSach);
            if (Sach == null)
            {
                Sach = new GioHang(iMaSach);
                listGioHang.Add(Sach);
                return Redirect(strURL);
            }
            else
            {
                Sach.iSoLuong++;
                return Redirect(strURL);
            }
        }
        // cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int iMaSach, FormCollection f)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.iMaSach == iMaSach);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return RedirectToAction("GioHang");

        }
        // Xóa giỏ hàng
        public ActionResult XoaGioHang(int iMaSach)
        {
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            if (sach == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.iMaSach == iMaSach);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.iMaSach == iMaSach);

            }
            if (listGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");
        }
        // xây dựng giỏ hàng
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listGioHang = LayGioHang();

            return View(listGioHang);
        }
        // tinh tong so luong va tong tien
        public double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                dTongTien = listGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> lstGioHang = Session["GioHang"] as List<GioHang>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        // Tạo Parial Giỏ Hàng
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        // xây dựng 1 view cho người  dùng chình sửa giỏ hàng
        public ActionResult SuaGioHang()
        {

            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listGioHang = LayGioHang();

            return View(listGioHang);
        }
        #endregion
        #region đặt hàng
        // xây dựng giỏ hàng
        double tongtien = 0;
        [HttpPost]
        public ActionResult DatHang()
        {
            try
            {
                // kiểm tra đăng nhập
                if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == null)
                {
                    return RedirectToAction("DangNhap", "DangKyDangNhap");
                }
                // kiểm tra giỏ hàng
                if (Session["GioHang"] == null || Session["GioHang"] == "")
                {
                    return RedirectToAction("Index", "Home");
                }
                // thêm đơn hàng
                DonHang dh = new DonHang();
                KhachHang kh = (KhachHang)Session["TaiKhoan"];
                List<GioHang> gh = LayGioHang();
                if (kh != null)
                {
                    dh.MaKH = kh.MaKH;
                    dh.NgayDat = DateTime.Now;
                }
                db.DonHangs.Add(dh);
                db.SaveChanges();
                foreach (var item in gh)
                {
                    ChiTietDonHang ctdh = new ChiTietDonHang();
                    ctdh.MaDonHang = dh.MaDonHang;
                    ctdh.MaSach = item.iMaSach;
                    ctdh.SoLuong = item.iSoLuong;
                    ctdh.DonGia = item.dDonGia.ToString();
                    db.ChiTietDonHangs.Add(ctdh);
                    tongtien += item.dDonGia*item.iSoLuong;
                }
                db.SaveChanges();
                GuiMailDatHang(kh, dh.MaDonHang);
                return RedirectToAction("DatHangThanhCong");
            }catch { return View(); }
        }
        
        string nguoigui = "Quan96kun@gmail.com";
        string matkhau = "Quan19101996";
        string nguoinhan = "";
        string tieude1 = "";
        string tieude2 = "";
        string tinnhan = "";
        void GuiMailDatHang(KhachHang kh,int madonhang,Attachment file = null)
        {
            nguoinhan = kh.Email;
            tieude1 = "Thông tin đơn đặt hàng từ khách hàng " + kh.HoTen+" -Shop Bán sách NVQ";
            tieude2 = "Đơn hàng mới từ khách hàng " + kh.HoTen + " -Shop Bán sách NVQ";
            string filenameImage = @"D:\hinh anh web ban sach\hình ảnh về trang liên kết\h2.jpg";
            tinnhan ="\nThông tin đơn đặt hàng :\nHọ Tên :"+kh.HoTen+"\nĐịa chỉ : "+kh.DiaChi+"\nSố điện thoại : "+kh.DienThoai+"\nMã đơn hàng : "+madonhang+"\nTổng giá trị đơn hàng : "+tongtien+"\n\n\n\n\nShop bán sách NVQ-Niềm vui mua sắm cho mọi người\nĐịa chỉ : 134 Trương Định - Hai Bà Trưng , Hà Nội ";
            MailMessage message1 = new MailMessage(nguoigui, nguoinhan, tieude1, tinnhan);
            MailMessage message2 = new MailMessage(nguoigui, nguoigui, tieude2, tinnhan);
            message1.Attachments.Add(new Attachment(filenameImage));
            message2.Attachments.Add(new Attachment(filenameImage));
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(nguoigui, matkhau);
            client.Send(message1);
            client.Send(message2);
        }
        void GuiMailDatHang_co_file_dinh_kem(KhachHang kh, int madonhang, Attachment file = null)
        {
            nguoinhan = kh.Email;
            tieude1 = "Thông tin đơn đặt hàng từ khách hàng " + kh.HoTen + " -Shop Bán sách NVQ";
            tieude2 = "Đơn hàng mới từ khách hàng " + kh.HoTen + " -Shop Bán sách NVQ";
            string filenameImage = @"D:\hinh anh web ban sach\hình ảnh về trang liên kết\h2.jpg";
            tinnhan ="\nThông tin đơn đặt hàng :\nHọ Tên :" + kh.HoTen + "\nĐịa chỉ : " + kh.DiaChi + "\nSố điện thoại : " + kh.DienThoai + "\nMã đơn hàng : " + madonhang + "\nTổng giá trị đơn hàng : " + tongtien + "\n\n\n\n\nShop bán sách NVQ-Niềm vui mua sắm cho mọi người\nĐịa chỉ : 134 Trương Định - Hai Bà Trưng , Hà Nội ";
            

            using (MailMessage mail1= new MailMessage())
            {
                mail1.From = new MailAddress(nguoigui);
                mail1.To.Add(nguoigui);
                mail1.Subject = tieude1;
                mail1.Body = tinnhan;
                mail1.Attachments.Add(new Attachment(filenameImage));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(nguoigui, matkhau);
                client.Send(mail1);

            }
            using (MailMessage mail2 = new MailMessage())
            {
                mail2.From = new MailAddress(nguoigui);
                mail2.To.Add(nguoinhan);
                mail2.Subject = tieude2;
                mail2.Body = tinnhan;
                mail2.IsBodyHtml = true;
                mail2.Attachments.Add(new Attachment(filenameImage));
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(nguoigui, matkhau);
                client.Send(mail2);

            }
            
        }
        public ActionResult DatHangThanhCong()
        {
            Session["GioHang"] = null;
            return View();
        }
        public ActionResult DangNhapPartial()
        {
            return PartialView();
        }
        #endregion
    }
}