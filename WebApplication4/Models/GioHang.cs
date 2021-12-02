using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class GioHang
    {
        QuanLyBanSachEntities6 db = new QuanLyBanSachEntities6();
        public int iMaSach { get; set; }
        public string sTenSach { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }

        }
        // tạo giỏ hàng
        public GioHang(int MaSach)
        {
            iMaSach = MaSach;
            Sach sach = db.Saches.SingleOrDefault(n => n.MaSach == iMaSach);
            sTenSach = sach.TenSach;
            sAnhBia = sach.AnhBia;
            dDonGia = double.Parse(sach.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}