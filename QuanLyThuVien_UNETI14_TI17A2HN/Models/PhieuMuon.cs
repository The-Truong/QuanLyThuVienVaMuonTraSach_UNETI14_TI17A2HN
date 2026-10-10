using QuanLyThuVien_UNETI14_TI17A2HN.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class PhieuMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaPhieuMuon { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn bạn đọc")]
        public int MaBanDoc { get; set; }

        [Required]
        public DateTime NgayMuon { get; set; }

        [Required]
        public DateTime HanTra { get; set; }

        public DateTime? NgayTra { get; set; }

        [Required]
        public int TrangThai { get; set; } // 0: Chờ xử lý, 1: Đang mượn (Đang xử lý), 2: Đã trả (Hoàn thành), 3: Hủy/Từ chối

        [Range(0, double.MaxValue)]
        public decimal TienPhat { get; set; } = 0;

        [StringLength(500)]
        public string? GhiChu { get; set; }

        public int? NhanVienXuLy { get; set; }

        // Navigation properties
        [ForeignKey("MaBanDoc")]
        public virtual BanDoc BanDoc { get; set; } = null!;

        [ForeignKey("NhanVienXuLy")]
        public virtual TaiKhoan? NguoiXuLy { get; set; }

        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; } = new List<ChiTietMuon>();
    }
}
