using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using PagedList;
using PagedList.Mvc;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public ActionResult Index(int? page)
        {
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(db.Saches.OrderBy(n=>n.TenSach).ToPagedList(pageNumber,pageSize));
        }
    }
}