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
    public class QuanLyHinhAnhController : Controller
    {
        // GET: QuanLyHinhAnh
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.Saches.ToList().OrderBy(n => n.AnhBia).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult HienThiNguoiDung(int? page)
        {
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(db.Saches.ToList().OrderBy(n => n.AnhBia).ToPagedList(pageNumber, pageSize));
        }
    }
}