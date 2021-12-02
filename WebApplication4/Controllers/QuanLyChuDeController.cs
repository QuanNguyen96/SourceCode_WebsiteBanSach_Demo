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
    public class QuanLyChuDeController : Controller
    {
        // GET: QuanLyChuDe
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.ChuDes.ToList().OrderBy(n => n.MaChuDe).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(ChuDe ChuDe)
        {
            ChuDe timkiemNXB = db.ChuDes.SingleOrDefault(n => n.TenChuDe == ChuDe.TenChuDe);
            if (timkiemNXB != null)
            {
                ViewBag.ThongBaoKT = "Tên chủ đề đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(ChuDe);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaChuDe)
        {

            ChuDe NXB = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        //update dữ liệu chỉnh sửa
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChuDe NXB, FormCollection f)
        {
            ChuDe timkiemsach = db.ChuDes.SingleOrDefault(n => n.TenChuDe == NXB.TenChuDe);
            if (timkiemsach != null)
            {
                ViewBag.ThongBaoKT = "Tên chủ đề đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View(timkiemsach);
            }
            if (ModelState.IsValid)
            {
                db.Entry(NXB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaChuDe)
        {

            ChuDe NXB = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        // xóa sách
        public ActionResult Xoa(int MaChuDe)
        {

            ChuDe NXB = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaChuDe)
        {

            ChuDe NXB = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> timkiemsach = db.Saches.Where(n => n.ChuDe.MaChuDe == MaChuDe).ToList();
            if (timkiemsach.Count != 0)
            {
                ViewBag.ThongBaoKT = "Vẫn còn sách của chủ đề này trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View(NXB);
            }
            db.ChuDes.Remove(NXB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}