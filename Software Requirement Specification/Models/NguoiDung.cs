using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class NguoiDung
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }

        public int VaitroId { get; set; }
        public VaiTro VaiTro { get; set; }
        public TaiKhoan TaiKhoan { get; set; }

        public List<TaiLieu> TaiLieu { get; set; }
        public List<BaiGiang> BaiGiang { get; set; }
        public List<DeThi> DeThi { get; set; }
    }
}
