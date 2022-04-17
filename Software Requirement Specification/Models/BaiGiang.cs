using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class BaiGiang
    {
        public int Id { get; set; }
        public string TheLoai { get; set; }
        public string Ten { get; set; }
        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }
        public string NoiDung { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public int NguoiChinhSua { get; set; }
        public int NguoiChinhSuaCuoi { get; set; }
        public bool PheDuyet { get; set; }
        public int KichThuoc { get; set; }
    }
}
