using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string TenMonHoc { get; set; }

        public string MoTa { get; set; }
        public bool TinhTrang { get; set; }

        public int SoTaiLieuChoDuyet { get; set; }

        public List<TaiLieu> TaiLieu { get; set; }
        public List<DeThi> DeThi { get; set; }
        public List<BaiGiang> BaiGiang { get; set; }
    
    }
}
