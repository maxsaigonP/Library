using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class DeThi
    {
        public int Id { get; set; }
        public int LoaiFile { get; set; }

        public int MonHocId { get; set; }
        public MonHoc MonHoc { get; set; }
        public int NguoiDungId { get; set; }
        public NguoiDung NguoiDung { get; set; }
        public string HinhThuc { get; set; }

        public string NoiDung { get; set; }
        public int ThoiLuong { get; set; }
        public DateTime NgayTao { get; set; }
        public bool TinhTrang { get; set; }

        public int NguoiPheDuyet { get; set; }
        public bool PheDuyet { get; set; }
        public string GhiChu { get; set; }



        
    }
}
