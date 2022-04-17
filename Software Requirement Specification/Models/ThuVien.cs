using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class ThuVien
    {
        public int Id { get; set; }
        public int TruongHocId { get; set; }
        public TruongHoc TruongHoc { get; set; }
        public string TenHeThong { get; set; }
        public string DiaChiTruyCap { get; set; }
        public string SoDienThoai { get; set; }
        public string Gmail { get; set; }
        public string NgonNguXacDinh { get; set; }
        public string NienKhoaMacDinh { get; set; }
        public bool TrangThai { get; set; }
    }
}
