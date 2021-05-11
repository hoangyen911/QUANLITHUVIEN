using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QUANLITHUVIEN.Models
{
    [Table("Sachs")]
    public class Sach
    {
        [Key]
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string TenTacGia { get; set; }
        public string MaNhaXB { get; set; }
        public string TenNhaXB { get; set; }
        public string NgonNgu { get; set; }
        public string MaKho { get; set; }
    }
}