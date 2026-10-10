using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class TheLoai
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTheLoai { get; set; }

        [Required(ErrorMessage = "Tên thể loại không được để trống")]
        [StringLength(100)]
        public string TenTheLoai { get; set; } = null!;

        [StringLength(500)]
        public string? MoTa { get; set; }

        [Required]
        public bool TrangThai { get; set; } = true;

        [Required]
        public int ThuTuHienThi { get; set; } = 0;


        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }
}
