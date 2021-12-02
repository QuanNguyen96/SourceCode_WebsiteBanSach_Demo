using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã đơn hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaDonHang { get; set; }
            [Display(Name = "tình trạng thanh toán")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> DaThanhToan { get; set; }
            [Display(Name = "tình trạng giao hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> TinhTrangGiaoHang { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày đặt hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<System.DateTime> NgayDat { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày giao hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<System.DateTime> NgayGiao { get; set; }
            [Display(Name = "Mã khách hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> MaKH { get; set; }
        }
    }
}