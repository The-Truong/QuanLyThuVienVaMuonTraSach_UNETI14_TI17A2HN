using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class TaiKhoan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaTaiKhoan { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(50)]
        public string TenDangNhap { get; set; } = null!;

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(255)]
        public string MatKhau { get; set; } = null!;

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100)]
        public string HoTen { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Required]
        public int VaiTro { get; set; } // 1: Admin, 2: Thủ thư, 3: Bạn đọc

        [Required]
        public bool TrangThai { get; set; } = true; // true: Hoạt động, false: Khóa

        // Navigation properties
        public virtual BanDoc? BanDoc { get; set; }
        public virtual ICollection<PhieuMuon> PhieuMuons { get; set; } = new List<PhieuMuon>();
    }
}
