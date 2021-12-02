using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class ChiTietDonHangMetadata
        {
            [DisplayName("Mã đơn hàng")]
            public int MaDonHang { get; set; }
            [DisplayName("Tên sách")]
            public int MaSach { get; set; }
            [DisplayName("Số lượng")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<int> SoLuong { get; set; }
            [DisplayName("Đơn giá")]
            public string DonGia { get; set; }
        }
    }
}