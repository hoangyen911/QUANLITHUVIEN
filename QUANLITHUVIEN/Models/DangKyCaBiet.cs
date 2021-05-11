using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QUANLITHUVIEN.Models
{
    [Table("DangKyDacBiets")]
    public class DangKyCaBiet
    {
        [Key]
        public string MaSach { get; set; }
        public string SoDangKy { get; set; }
        public string NgayVaoSo { get; set; }
        public string MaKho { get; set; }
    }
}