using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TaiKhoan
    {
        public int Id { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string MatKhau { get; set; }
        public string Gmail { get; set; }
        public string SoDienThoai { get; set; }
        public bool TrangThai { get; set; }
    }
}
