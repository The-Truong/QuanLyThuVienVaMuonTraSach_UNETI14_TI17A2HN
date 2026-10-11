using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien_UNETI14_TI17A2HN.Models;
using System.Diagnostics;
using QuanLyThuVien_UNETI14_TI17A2HN.ViewModels;
namespace QuanLyThuVien_UNETI14_TI17A2HN.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                TongTheLoai = 5,
                TongSach = 120,
                SachKhaDung = 85,
                TongBanDoc = 30,
                TongGiaoDich = 45,
                PhieuChoDuyet = 6,
                PhieuDangMuon = 12,
                PhieuQuaHan = 3,
                TongTienPhat = 150000,
                ThongKeTheLoai = new List<TheLoaiThongKe>
        {
            new() { TenTheLoai = "Tiểu thuyết", SoDauSach = 4, SoLuong = 40 },
            new() { TenTheLoai = "Khoa học", SoDauSach = 3, SoLuong = 30 },
            new() { TenTheLoai = "Công nghệ", SoDauSach = 2, SoLuong = 50 }
        }
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
