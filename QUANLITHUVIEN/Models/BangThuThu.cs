using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QUANLITHUVIEN.Models
{
    [Table("BangThuThus")]
    public class BangThuThu
    {
        [Key]
        public string MaThuThu { get; set; }
        public string TenThuThu { get; set; }
        public string DiaChi { get; set; }
    }
}