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
    public class QuanLyNXBController : Controller
    {
        // GET: QuanLyNXB
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.NhaXuatBans.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize));
        }
        // thêm mới
        [HttpGet]
        public ActionResult ThemMoi()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ThemMoi(NhaXuatBan NXB)
        {
            NhaXuatBan timkiemNXB = db.NhaXuatBans.SingleOrDefault(n => n.TenNXB == NXB.TenNXB);
            if (timkiemNXB != null)
            {
                ViewBag.ThongBaoKT = "Tên nhà xuất bản đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(NXB);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        // chinh sửa săn phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaNXB)
        {

            NhaXuatBan NXB = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
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
        public ActionResult ChinhSua(NhaXuatBan NXB,FormCollection f)
        {
            NhaXuatBan timkiemsach = db.NhaXuatBans.SingleOrDefault(n => n.TenNXB == NXB.TenNXB);
            if (timkiemsach != null)
            {
                NhaXuatBan sachtk = db.NhaXuatBans.SingleOrDefault(n => n.TenNXB == NXB.TenNXB && n.MaNXB==NXB.MaNXB&&n.DiaChi==NXB.DiaChi&&n.DienThoai==NXB.DienThoai);
                if (sachtk == null)
                {
                    ViewBag.ThongBaoKT = "Tên sách đã tồn tại trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                    return View(timkiemsach);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(NXB).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }
        // thêm mới sách
        public ActionResult HienThi(int MaNXB)
        {

            NhaXuatBan NXB = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        // xóa sách
        public ActionResult Xoa(int MaNXB)
        {

            NhaXuatBan NXB = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(NXB);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult XacNhanXoa(int MaNXB)
        {

            NhaXuatBan NXB = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (NXB == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> timkiemsach = db.Saches.Where(n => n.NhaXuatBan.MaNXB==MaNXB).ToList();
            if (timkiemsach.Count!=0)
            {
                ViewBag.ThongBaoKT = "Vẫn còn sách của nhà xuất bản này trong cơ sở dữ liệu , xin vui lòng kiểm tra lại !";
                return View(NXB);
            }
            db.NhaXuatBans.Remove(NXB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}