using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Software_Requirement_Specification.Models;

namespace Software_Requirement_Specification.Data
{
    public class Software_Requirement_SpecificationContext : DbContext
    {
        public Software_Requirement_SpecificationContext (DbContextOptions<Software_Requirement_SpecificationContext> options)
            : base(options)
        {
        }

        public DbSet<Software_Requirement_Specification.Models.NguoiDung> NguoiDung { get; set; }

        public DbSet<Software_Requirement_Specification.Models.TruongHoc> TruongHoc { get; set; }

        public DbSet<Software_Requirement_Specification.Models.BaiGiang> BaiGiang { get; set; }

        public DbSet<Software_Requirement_Specification.Models.DeThi> DeThi { get; set; }

        public DbSet<Software_Requirement_Specification.Models.LopHoc> LopHoc { get; set; }

        public DbSet<Software_Requirement_Specification.Models.MonHoc> MonHoc { get; set; }

        public DbSet<Software_Requirement_Specification.Models.PhanQuyen> PhanQuyen { get; set; }

        public DbSet<Software_Requirement_Specification.Models.TaiKhoan> TaiKhoan { get; set; }

        public DbSet<Software_Requirement_Specification.Models.TaiLieu> TaiLieu { get; set; }

        public DbSet<Software_Requirement_Specification.Models.ThuVien> ThuVien { get; set; }

        public DbSet<Software_Requirement_Specification.Models.VaiTro> VaiTro { get; set; }
    }
}
