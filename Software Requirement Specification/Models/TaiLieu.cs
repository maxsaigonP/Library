using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class TaiLieu
    {
        public int Id { get; set; }

        public int MonHocId { get; set; }
        public MonHoc MonHocI { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }

        public bool TinhTrang { get; set; }
        public DateTime NgayGuiPheDuyet { get; set; }
    }
}
