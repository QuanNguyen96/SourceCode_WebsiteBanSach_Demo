using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(KhachHangMetadata))]
    public partial class KhachHang
    {
        internal sealed class KhachHangMetadata
        {
            [Display(Name = "Mã khách hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaKH { get; set; }
            [Display(Name = "Tên khách hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập tên khách hàng .")] //Kiểm tra rổng
            public string HoTen { get; set; }
            [Display(Name = "Tài khoản")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập tài khoản .")] //Kiểm tra rổng
            public string TaiKhoan { get; set; }
            [Display(Name = "Mật khẩu")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string MatKhau { get; set; }
            [Display(Name = "E-mail")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string Email { get; set; }
            [Display(Name = "Địa chỉ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DiaChi { get; set; }
            [Display(Name = "Điện thoại")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string DienThoai { get; set; }
            [Display(Name = "Giới tính")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string GioiTinh { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày sinh")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập ngày sinh .")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgaySinh { get; set; }
        }
    }
}