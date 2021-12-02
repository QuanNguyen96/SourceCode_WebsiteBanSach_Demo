﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(SachMetadata))]
    public partial class Sach
    {
        internal sealed class SachMetadata
        {

            [Display(Name = "Mã sách")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaSach { get; set; }
            [Display(Name = "Tên sách")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public string TenSach { get; set; }
            [Display(Name = "Giá bán")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<decimal> GiaBan { get; set; }
            [Display(Name = "Mô tả")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public string MoTa { get; set; }
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày cập nhật")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            [Display(Name = "Ảnh bìa")]//Thuộc tính Display dùng để đặt tên lại cho cột

            public string AnhBia { get; set; }
            [Display(Name = "Số lượng tồn")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")] //Kiểm tra rổng
            public Nullable<int> SoLuongTon { get; set; }
            [Display(Name = "Chủ đề")]//Thuộc tính Display dùng để đặt tên lại cho cột

            public Nullable<int> MaChuDe { get; set; }
            [Display(Name = "Nhà xuất bản")]//Thuộc tính Display dùng để đặt tên lại cho cột

            public Nullable<int> MaNXB { get; set; }
            [Display(Name = "Mới")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> Moi { get; set; }
        }
    }
}