// Họ và tên: Nguyễn Hoàng Việt
// Mã sinh viên: 23103100066
// Nội dung thực hiện: Module 5 - Dashboard tổng quan

using QuanLyThuVien_UNETI14_TI17A2HN.Models;

namespace QuanLyThuVien_UNETI14_TI17A2HN.ViewModels
{
    public class TheLoaiThongKe
    {
        public string TenTheLoai { get; set; } = "";
        public int SoDauSach { get; set; }
        public int SoLuong { get; set; }
    }

    public class DashboardViewModel
    {
        public int TongTheLoai { get; set; }
        public int TongSach { get; set; }
        public int SachKhaDung { get; set; }
        public int TongBanDoc { get; set; }
        public int TongGiaoDich { get; set; }
        public int PhieuChoDuyet { get; set; }
        public int PhieuDangMuon { get; set; }
        public int PhieuQuaHan { get; set; }
        public decimal TongTienPhat { get; set; }
        public List<TheLoaiThongKe> ThongKeTheLoai { get; set; } = new();
        public List<PhieuMuon> PhieuMoiNhat { get; set; } = new();

        public int SachDangMuon => TongSach - SachKhaDung;
        public double TyLeDangMuon => TongSach == 0 ? 0 : Math.Round(SachDangMuon * 100.0 / TongSach, 1);
        public bool CoHoSoBanDoc { get; set; } = true;
        public BanDoc? BanDoc { get; set; }
        public int PhieuChoDuyetCuaToi { get; set; }
        public List<ChiTietMuon> SachDangMuonCuaToi { get; set; } = new();
    }
}