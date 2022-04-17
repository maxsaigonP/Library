using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class VaiTro
    {
        public int Id { get; set; }
        public string TenVaiTro { get; set; }

        public string MoTa { get; set; }
        public int DeThiId { get; set; }

   


        public int TepRiengTu { get; set; }

        public int TaiNguyen { get; set; }

     

        public string ThongBao { get; set; }
        public int PhanQuyenId { get; set; }
        public PhanQuyen PhanQuyen { get; set; }

        public List<TaiKhoan> TaiKhoan { get; set; }
        public List<NguoiDung> NguoiDung { get; set; }
        
    }
}
