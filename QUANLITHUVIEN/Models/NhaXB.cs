using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QUANLITHUVIEN.Models
{
    [Table("NhaXBs")]
    public class NhaXB
    {
        [Key]
        public string MaNhaXB { get; set; }
        public string TenNhaXB { get; set; }
        [AllowHtml]
        public string DiaChi { get; set; }
    }
}