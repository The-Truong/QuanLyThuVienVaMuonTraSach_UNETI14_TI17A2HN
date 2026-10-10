using QuanLyThuVien_UNETI14_TI17A2HN.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Models
{
    public class Sach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaSach { get; set; }

        [Required(ErrorMessage = "Tên sách không được để trống")]
        [StringLength(200)]
        public string TenSach { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        public int MaTheLoai { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn nhà xuất bản")]
        public int MaNhaXuatBan { get; set; }

        [Range(1000, 2100, ErrorMessage = "Năm xuất bản không hợp lệ")]
        [Display(Name = "Năm xuất bản")]
        public int? NamXuatBan { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0")]
        public int SoLuong { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng còn phải lớn hơn hoặc bằng 0")]
        public int SoLuongCon { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn hoặc bằng 0")]
        public decimal DonGia { get; set; }

        [StringLength(50)]
        public string? ViTriKeSach { get; set; }

        [Required]
        public bool TrangThai { get; set; } = true;

        [StringLength(500)]
        public string? GhiChu { get; set; }


        [ForeignKey("MaTheLoai")]
        public virtual TheLoai TheLoai { get; set; } = null!;

        [ForeignKey("MaNhaXuatBan")]
        public virtual NhaXuatBan NhaXuatBan { get; set; } = null!;

        public virtual ICollection<ChiTietMuon> ChiTietMuons { get; set; } = new List<ChiTietMuon>();
    }
}
