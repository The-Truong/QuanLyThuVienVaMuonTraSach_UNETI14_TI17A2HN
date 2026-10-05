using Microsoft.AspNetCore.Mvc;
using QuanLyThuVien_UNETI14_TI17A2HN.Models;
using System.Diagnostics;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
