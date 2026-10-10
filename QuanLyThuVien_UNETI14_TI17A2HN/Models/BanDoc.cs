using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class BanDoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaBanDoc { get; set; }

        public int? MaTaiKhoan { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100)]
        public string HoTen { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime? NgaySinh { get; set; }

        public bool? GioiTinh { get; set; } // true: Nam, false: Nữ

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(20)]
        public string? SoDienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(200)]
        public string? DiaChi { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime NgayCapThe { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HanThe { get; set; }

        [Required]
        public bool TrangThai { get; set; } = true; // true: Hoạt động, false: Khóa

        [StringLength(500)]
        public string? GhiChu { get; set; }

        // Navigation properties
        [ForeignKey("MaTaiKhoan")]
        public virtual TaiKhoan? TaiKhoan { get; set; }

        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();
    }
}
