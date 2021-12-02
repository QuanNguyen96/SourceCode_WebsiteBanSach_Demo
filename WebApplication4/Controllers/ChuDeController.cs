using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class ChuDeController : Controller
    {
        // GET: ChuDe
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public PartialViewResult ChuDePartial()
        {
            return PartialView(db.ChuDes.Take(5).ToList());
        }
        public ViewResult SachTheoChuDe(int MaChuDe = 0)
        {
            // kiểm tra xem chủ đề có tồn tại hay không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> listsach = db.Saches.Where(n => n.MaChuDe == MaChuDe).OrderBy(n => n.GiaBan).ToList();
            if (listsach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            ViewBag.lstChuDe = db.ChuDes.ToList();
            return View(listsach);
        }
        public ViewResult DanhMucChuDe()
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int MaChuDe = int.Parse(db.ChuDes.ToList().ElementAt(0).MaChuDe.ToString());
            //Tạo 1 viewbag gán sách theo chủ đề đầu tiên trong csdl
            ViewBag.SachTheoChuDe = db.Saches.Where(n => n.MaChuDe == MaChuDe).ToList();
            return View(db.ChuDes.ToList());
        }
    }
}