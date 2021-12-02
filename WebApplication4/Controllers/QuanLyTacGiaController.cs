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
    public class QuanLyTacGiaController : Controller
    {
        // GET: QuanLyTacGia
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.TacGias.ToList().OrderBy(n => n.MaTacGia).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(TacGia TacGia)
        {
            TacGia timkiemTacGia = db.TacGias.SingleOrDefault(n => n.TenTacGia == TacGia.TenTacGia);
            if (timkiemTacGia != null)
            {
                ViewBag.ThongBaoKT = "Tên tác giả đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.TacGias.Add(TacGia);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaTacGia)
        {
            TacGia TacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (TacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(TacGia);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(TacGia TacGia, FormCollection f)
        {
            TacGia timkiemsach = db.TacGias.SingleOrDefault(n => n.TenTacGia == TacGia.TenTacGia);
            if (timkiemsach != null)
            {
                TacGia sachtk = db.TacGias.SingleOrDefault(n => n.TenTacGia == TacGia.TenTacGia && n.MaTacGia == TacGia.MaTacGia && n.DiaChi == TacGia.DiaChi && n.DienThoai == TacGia.DienThoai && n.TieuSu == TacGia.TieuSu);
                if (sachtk == null)
                {
                    ViewBag.ThongBaoKT = "Tên tác giả này đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                    return View(timkiemsach);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(TacGia).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaTacGia)
        {

            TacGia TacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (TacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(TacGia);
        }
        // xóa sách
        public ActionResult Xoa(int MaTacGia)
        {

            TacGia TacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (TacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(TacGia);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaTacGia)
        {

            TacGia TacGia = db.TacGias.SingleOrDefault(n => n.MaTacGia == MaTacGia);
            if (TacGia == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.TacGias.Remove(TacGia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}