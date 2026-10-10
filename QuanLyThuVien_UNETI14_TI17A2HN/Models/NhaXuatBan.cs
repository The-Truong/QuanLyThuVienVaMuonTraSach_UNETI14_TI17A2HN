using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class NhaXuatBan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaNhaXuatBan { get; set; }

        [Required(ErrorMessage = "Tên nhà xuất bản không được để trống")]
        [StringLength(200)]
        public string TenNhaXuatBan { get; set; } = null!;

        [StringLength(200)]
        public string? DiaChi { get; set; }

        [StringLength(20)]
        public string? SoDienThoai { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        public virtual ICollection<Sach> Sachs { get; set; } = new List<Sach>();
    }
}
