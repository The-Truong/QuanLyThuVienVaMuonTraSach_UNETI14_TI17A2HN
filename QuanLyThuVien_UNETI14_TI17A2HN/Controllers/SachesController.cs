using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien_UNETI14_TI17A2HN.Data;
using QuanLyThuVien_UNETI14_TI17A2HN.Models;
using QuanLyThuVien_UNETI14_TI17A2HN.ViewModels;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Controllers
{
    public class SachesController : Controller
    {
        private readonly QuanLyThuVien_UNETI14_TI17A2HNContext _context;

        public SachesController(QuanLyThuVien_UNETI14_TI17A2HNContext context)
        {
            _context = context;
        }

        private static IQueryable<Sach> ApplyFilters(IQueryable<Sach> sachs, SachQuery q)
        {
            if (!string.IsNullOrWhiteSpace(q.SearchString))
            {
                var key = q.SearchString.Trim();
                sachs = sachs.Where(s => s.TenSach.Contains(key)
                    || s.TheLoai.TenTheLoai.Contains(key)
                    || s.NhaXuatBan.TenNhaXuatBan.Contains(key));
            }
            if (q.TheLoaiId.HasValue) sachs = sachs.Where(s => s.MaTheLoai == q.TheLoaiId);
            if (q.NhaXuatBanId.HasValue) sachs = sachs.Where(s => s.MaNhaXuatBan == q.NhaXuatBanId);
            if (q.NamXuatBan.HasValue) sachs = sachs.Where(s => s.NamXuatBan == q.NamXuatBan);
            if (q.GiaTu.HasValue) sachs = sachs.Where(s => s.DonGia >= q.GiaTu.Value);
            if (q.GiaDen.HasValue) sachs = sachs.Where(s => s.DonGia <= q.GiaDen.Value);

            if (q.TrangThai == "hienthi") sachs = sachs.Where(s => s.TrangThai);
            else if (q.TrangThai == "khoa") sachs = sachs.Where(s => !s.TrangThai);

            if (q.TinhTrang == "con") sachs = sachs.Where(s => s.TrangThai && s.SoLuongCon > 0);
            else if (q.TinhTrang == "het") sachs = sachs.Where(s => !s.TrangThai || s.SoLuongCon <= 0);

            return q.SortOrder switch
            {
                "name_desc" => sachs.OrderByDescending(s => s.TenSach),
                "year" => sachs.OrderBy(s => s.NamXuatBan).ThenBy(s => s.TenSach),
                "year_desc" => sachs.OrderByDescending(s => s.NamXuatBan).ThenBy(s => s.TenSach),
                "price" => sachs.OrderBy(s => s.DonGia).ThenBy(s => s.TenSach),
                "price_desc" => sachs.OrderByDescending(s => s.DonGia).ThenBy(s => s.TenSach),
                "con" => sachs.OrderBy(s => s.SoLuongCon).ThenBy(s => s.TenSach),
                "con_desc" => sachs.OrderByDescending(s => s.SoLuongCon).ThenBy(s => s.TenSach),
                _ => sachs.OrderBy(s => s.TenSach),
            };
        }

        private async Task<(List<Sach> Items, int Page, int TotalPages, int Count)> PageAsync(IQueryable<Sach> sachs, int? pageNumber, int pageSize)
        {
            int count = await sachs.CountAsync();
            int totalPages = Math.Max(1, (int)Math.Ceiling(count / (double)pageSize));
            int page = Math.Clamp(pageNumber ?? 1, 1, totalPages);
            var items = await sachs.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(); // phân trang trên truy vấn
            return (items, page, totalPages, count);
        }

        // GET: Saches
        public async Task<IActionResult> Index([FromQuery] SachQuery q)
        {
            //var quanLyThuVien_UNETI14_TI17A2HNContext = _context.Sach.Include(s => s.NhaXuatBan).Include(s => s.TheLoai);
            //return View(await quanLyThuVien_UNETI14_TI17A2HNContext.ToListAsync());


            ViewData["TheLoaiId"] = new SelectList(_context.TheLoai.OrderBy(t => t.ThuTuHienThi), "MaTheLoai", "TenTheLoai", q.TheLoaiId);
            ViewData["NhaXuatBanId"] = new SelectList(_context.NhaXuatBan.OrderBy(n => n.TenNhaXuatBan), "MaNhaXuatBan", "TenNhaXuatBan", q.NhaXuatBanId);

            var query = ApplyFilters(_context.Sach.Include(s => s.TheLoai).Include(s => s.NhaXuatBan), q);
            var r = await PageAsync(query, q.PageNumber, 10);

            ViewData["PageNumber"] = r.Page;
            ViewData["TotalPages"] = r.TotalPages;
            ViewData["TotalCount"] = r.Count;
            ViewData["Query"] = q;
            return View(r.Items);
        }

        // GET: Saches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.NhaXuatBan)
                .Include(s => s.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // GET: Saches/Create
        public IActionResult Create()
        {
            ViewData["MaNhaXuatBan"] = new SelectList(_context.Set<NhaXuatBan>(), "MaNhaXuatBan", "TenNhaXuatBan");
            ViewData["MaTheLoai"] = new SelectList(_context.Set<TheLoai>(), "MaTheLoai", "TenTheLoai");
            return View();
        }

        // POST: Saches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSach,TenSach,MaTheLoai,MaNhaXuatBan,NamXuatBan,SoLuong,SoLuongCon,DonGia,ViTriKeSach,TrangThai,GhiChu")] Sach sach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhaXuatBan"] = new SelectList(_context.Set<NhaXuatBan>(), "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewData["MaTheLoai"] = new SelectList(_context.Set<TheLoai>(), "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Saches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach.FindAsync(id);
            if (sach == null)
            {
                return NotFound();
            }
            ViewData["MaNhaXuatBan"] = new SelectList(_context.Set<NhaXuatBan>(), "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewData["MaTheLoai"] = new SelectList(_context.Set<TheLoai>(), "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // POST: Saches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSach,TenSach,MaTheLoai,MaNhaXuatBan,NamXuatBan,SoLuong,SoLuongCon,DonGia,ViTriKeSach,TrangThai,GhiChu")] Sach sach)
        {
            if (id != sach.MaSach)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SachExists(sach.MaSach))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNhaXuatBan"] = new SelectList(_context.Set<NhaXuatBan>(), "MaNhaXuatBan", "TenNhaXuatBan", sach.MaNhaXuatBan);
            ViewData["MaTheLoai"] = new SelectList(_context.Set<TheLoai>(), "MaTheLoai", "TenTheLoai", sach.MaTheLoai);
            return View(sach);
        }

        // GET: Saches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sach
                .Include(s => s.NhaXuatBan)
                .Include(s => s.TheLoai)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: Saches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Sach.FindAsync(id);
            if (sach != null)
            {
                _context.Sach.Remove(sach);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SachExists(int id)
        {
            return _context.Sach.Any(e => e.MaSach == id);
        }
    }
}
