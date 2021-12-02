using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebApplication4.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: DonHang
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(DonHang DH)
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen");
            if (ModelState.IsValid)
            {
                db.DonHangs.Add(DH);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            DonHang DH = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (DH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen", DH.MaKH);
            return View(DH);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang DH, FormCollection f)
        {
            ViewBag.MaKH = new SelectList(db.KhachHangs.ToList().OrderBy(n => n.MaKH), "MaKH", "HoTen", DH.MaKH);
            DH.NgayDat = Convert.ToDateTime(f["txtNgayDat"].ToString());
            DH.NgayGiao = Convert.ToDateTime(f["txtNgayGiao"].ToString());
            if (ModelState.IsValid)
            {
                db.Entry(DH).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaDonHang)
        {

            DonHang DH = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (DH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(DH);
        }
        // xóa sách
        public ActionResult Xoa(int MaDonHang)
        {

            DonHang DH = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (DH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(DH);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaDonHang)
        {

            DonHang DH = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (DH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ChiTietDonHang> timkiemDH = db.ChiTietDonHangs.Where(n => n.DonHang.MaDonHang == MaDonHang).ToList();
            if (timkiemDH.Count != 0)
            {
                ViewBag.ThongBaoKT = "Vẫn còn chi tiết đơn hàng của đơn hàng này trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View(DH);
            }
            db.DonHangs.Remove(DH);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult XemChiTietDonHang(int MaDonHang)
        {

            DonHang DH = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (DH == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<ChiTietDonHang> dh = db.ChiTietDonHangs.OrderBy(n=>n.MaSach).Where(n => n.MaDonHang == MaDonHang).ToList();
            return View(dh);
        }
        public ActionResult DoanhThu()
        {
            return View();
        }
        public ActionResult KQDT(int? page , FormCollection f)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            Session["DoanhThu"] = 0;
            double tongdoanhthu = 0;
            try
            {
                DateTime ngayxuatphat = DateTime.Parse(f["txtNgay1"].ToString());
                string.Format("{0:MM/dd/yyyy}", ngayxuatphat);
                DateTime ngayketthuc = DateTime.Parse(f["txtNgay2"].ToString());
                string.Format("{0:MM/dd/yyyy}", ngayketthuc);
                List<DonHang> dh = db.DonHangs.Where(n => n.NgayDat >= ngayxuatphat && n.NgayDat <= ngayketthuc).ToList();
                foreach(DonHang item in dh)
                {
                    List<ChiTietDonHang> ctdt = db.ChiTietDonHangs.Where(n => n.MaDonHang == item.MaDonHang).ToList();
                    if(ctdt==null)
                    {
                        ViewBag.TBL = "Dữ liệu đầu vào bị lỗi => mong bạn kiểm tra lại định dạnh ngày nhập ...";
                        return RedirectToAction("DoanhThu");
                    }
                    foreach(ChiTietDonHang items in ctdt)
                    {
                        tongdoanhthu = tongdoanhthu + int.Parse(items.SoLuong.ToString())* int.Parse(items.DonGia.ToString());
                    }
                }
                Session["NgayDen"] = ngayxuatphat;
                Session["NgayDi"] = ngayketthuc;
                Session["DoanhThu"] = tongdoanhthu;
                return View(db.DonHangs.Where(n => n.NgayDat >= ngayxuatphat && n.NgayDat <= ngayketthuc).ToList().OrderBy(n=>n.MaDonHang).ToPagedList(pageNumber, pageSize));
            }
            catch {
                ViewBag.TBL = "Dữ liệu đầu vào bị lỗi => mong bạn kiểm tra lại định dạnh ngày nhập ...";
                return RedirectToAction("DoanhThu");
            }
            
        }
    }
}