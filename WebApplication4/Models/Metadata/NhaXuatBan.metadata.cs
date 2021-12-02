using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(NhaXuatBanMetadata))]

    public partial class NhaXuatBan
    {
        internal sealed class NhaXuatBanMetadata
        {
            [DisplayName("Mã nhà xuất bản")]
            public int MaNXB { get; set; }
            [DisplayName("Tên nhà xuất bản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho tên nhà xuất bản")] //Kiểm tra rổng
            public string TenNXB { get; set; }
            [DisplayName("Địa chỉ ")]
            public string DiaChi { get; set; }
            [DisplayName("Điện thoại")]
            public string DienThoai { get; set; }
        }
    }
}