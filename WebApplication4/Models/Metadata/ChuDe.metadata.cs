using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]

    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            [DisplayName("Mã chủ đề")]
            public int MaChuDe { get; set; }
            [DisplayName("tên chủ đề")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho tên chủ đề")] //Kiểm tra rổng
            public string TenChuDe { get; set; }
        }
    }
}