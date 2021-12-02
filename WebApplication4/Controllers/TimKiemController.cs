using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<ThamGia> lstkqtk = db.ThamGias.Where(n => n.TacGia.TenTacGia.Contains(sTuKhoa)).ToList();
            int MaTacGia = 0;
            if(lstkqtk.Count!=0)
            {
                MaTacGia = lstkqtk[0].MaTacGia;
            }
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa)|| n.ChuDe.TenChuDe.Contains(sTuKhoa)|| n.NhaXuatBan.TenNXB.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa) || n.ChuDe.TenChuDe.Contains(sTuKhoa) || n.NhaXuatBan.TenNXB.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult KetQuaTimKiemAdmin(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<ThamGia> lstkqtk = db.ThamGias.Where(n => n.TacGia.TenTacGia.Contains(sTuKhoa)).ToList();
            int MaTacGia = 0;
            if (lstkqtk.Count != 0)
            {
                MaTacGia = lstkqtk[0].MaTacGia;
            }
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa) || n.ChuDe.TenChuDe.Contains(sTuKhoa) || n.NhaXuatBan.TenNXB.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiemAdmin(int? page, string sTuKhoa)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(sTuKhoa) || n.ChuDe.TenChuDe.Contains(sTuKhoa) || n.NhaXuatBan.TenNXB.Contains(sTuKhoa)).ToList();
            //Phân trang
            int pageNumber = (page ?? 1);
            int pageSize = 12;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm nào";
                return View(db.Saches.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.ThongBao = "Đã tìm thấy " + lstKQTK.Count + " kết quả!";
            return View(lstKQTK.OrderBy(n => n.TenSach).ToPagedList(pageNumber, pageSize));
        }
    }
}