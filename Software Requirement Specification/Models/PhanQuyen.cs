using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class PhanQuyen
    {
        public int Id { get; set; }
        public string TenPhanQuyen { get; set; }

        public VaiTro VaiTro { get; set; }


    }
}
