using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QUANLITHUVIEN.Models
{
    [Table("KhoSachs")]
    public class KhoSach
    {
        [Key]
        public string MaKho { get; set; }
        public string TenKho { get; set; }
        public string GhiChu { get; set; }
    }
}