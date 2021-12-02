using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(TacGiaMetadata))]

    public partial class TacGia
    {
        internal sealed class TacGiaMetadata
        {
            [DisplayName("Mã tác giả")]
            public int MaTacGia { get; set; }
            [DisplayName("Tên tác giả")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho tên tác giả")] //Kiểm tra rổng
            public string TenTacGia { get; set; }
            [DisplayName("Địa chỉ")]
            public string DiaChi { get; set; }
            [DisplayName("Tiểu sử")]
            public string TieuSu { get; set; }
            [DisplayName("Điện thoại")]
            public string DienThoai { get; set; }
        }
    }
}