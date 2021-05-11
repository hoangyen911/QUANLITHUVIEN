using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QUANLITHUVIEN.Models
{
    [Table("MuonTras")]
    public class MuonTra
    {
        [Key]
        public string SoThuTu { get; set; }
        public string SoThe { get; set; }
        public string NgayMuon { get; set; }
        public string NgayTra { get; set; }
        public string NgayPhaiTra { get; set; }
        public string MaSach { get; set; }
        public string MaThuThu { get; set; }
    }
}