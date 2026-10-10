using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien_UNETI14_TI17A2HN.Models;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Data
{
    public class QuanLyThuVien_UNETI14_TI17A2HNContext : DbContext
    {
        public QuanLyThuVien_UNETI14_TI17A2HNContext (DbContextOptions<QuanLyThuVien_UNETI14_TI17A2HNContext> options)
            : base(options)
        {
        }

        public DbSet<QuanLyThuVien_UNETI14_TI17A2HN.Models.Sach> Sach { get; set; } = default!;
    }
}
