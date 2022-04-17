using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Software_Requirement_Specification.Models
{
    public class Tep
    {
        public int Id { get; set; }
        public string TenFile { get; set; }
        public string Loai { get; set; }
        public int KichThuoc { get; set; }
 
    }
}
