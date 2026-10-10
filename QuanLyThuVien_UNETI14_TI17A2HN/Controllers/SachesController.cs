using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien_UNETI14_TI17A2HN.Data;
using QuanLyThuVien_UNETI14_TI17A2HN.Models;

namespace QuanLyThuVien_UNETI14_TI17A2HN.Controllers
{
    public class SachesController : Controller
    {
        private readonly QuanLyThuVien_UNETI14_TI17A2HNContext _context;

        public SachesController(QuanLyThuVien_UNETI14_TI17A2HNContext context)
        {
            _context = context;
        }

        // GET: Saches
        public async Task<IActionResult> Index()
        {
            var quanLyThuVien_UNETI14_TI17A2HNContext = _context.Sach.Include(s => s.NhaXuatBan).Include(s => s.TheLoai);
            return View(await quanLyThuVien_UNETI14_TI17A2HNContext.ToListAsync());
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
