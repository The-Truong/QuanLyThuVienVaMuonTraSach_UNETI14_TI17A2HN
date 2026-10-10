using QuanLyThuVien_UNETI14_TI17A2HN.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.ViewModels
{
    public class ChiTietMuon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaChiTiet { get; set; }

        [Required]
        public int MaPhieuMuon { get; set; }

        [Required]
        public int MaSach { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng mượn phải lớn hơn 0")]
        public int SoLuong { get; set; }

        [StringLength(200)]
        public string? TinhTrangMuon { get; set; }

        [StringLength(200)]
        public string? TinhTrangTra { get; set; }

        public int SoNgayQuaHan { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal TienPhat { get; set; } = 0;

        [StringLength(500)]
        public string? GhiChu { get; set; }

        [ForeignKey("MaPhieuMuon")]
        public virtual PhieuMuon PhieuMuon { get; set; } = null!;

        [ForeignKey("MaSach")]
        public virtual Sach Sach { get; set; } = null!;
    }
}
