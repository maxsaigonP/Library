using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TruongHoc
    {
        public int Id { get; set; }
        public string TenTruong { get; set; }
        public string HieuTruong { get; set; }
        public string LoaiTruong { get; set; }
        public string WebSite { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public bool TrangThai { get; set; }
        public List<ThuVien> ThuVien { get; set; }
        public List<LopHoc> LopHoc { get; set; }
    }
}
