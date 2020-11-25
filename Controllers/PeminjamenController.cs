using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_NIM.Models;

namespace RentalKendaraan_NIM.Controllers
{
    public class PeminjamenController : Controller
    {
        private readonly Rental_KendaraanContext _context;

        public PeminjamenController(Rental_KendaraanContext context)
        {
            _context = context;
        }

        // GET: Peminjamen
        public async Task<IActionResult> Index(string ktsd, string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            //buat liat menmyimpan ketersediaan
            var ktsdList = new List<String>();
            //query mengambil data
            var ktsdQuery = from d in _context.Peminjaman orderby d.IdKendaraanNavigation.NamaKendaraan select d.IdKendaraanNavigation.NamaKendaraan;

            ktsdList.AddRange(ktsdQuery.Distinct());

            //untuk menampilkan di view
            ViewBag.ktsd = new SelectList(ktsdList);

            // panggil db context
            var menu = from m in _context.Peminjaman.Include(p => p.IdCustomerNavigation).Include(p => p.IdJaminanNavigation).Include(p => p.IdKendaraanNavigation) select m;

            //untuk memilih dropdownlist ketersediaan
            if (!string.IsNullOrEmpty(ktsd))
            {
                //menu = menu.Where(x => x.Ketersediaan == ktsd);
            }

            //untuk search data
            if (!string.IsNullOrEmpty(searchString))
            {
                menu = menu.Where(s => s.Biaya.Contains(searchString) || s.IdCustomerNavigation.NamaCostumer.Contains(searchString) 
                || s.IdJaminanNavigation.NamaJaminan.Contains(searchString) || s.IdJaminanNavigation.NamaKendaraan.Contains(searchString));
            }

            //membuat paged list
            ViewData["CurrentSort"] = sortOrder;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            //untuk sorting
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    menu = menu.OrderByDescending(s => s.IdCustomerNavigation.NamaCostumer);
                    break;
                case "date":
                    menu = menu.OrderBy(s => s.TglPeminjaman) ;
                    break;
                case "date_desc":
                    menu = menu.OrderByDescending(s => s.TglPeminjamanr);
                    break;
                default: //name ascending
                    menu = menu.OrderBy(s => s.IdCustomerNavigation.NamaCostumer);
                    break;
            }

            ViewData["CurrentFilter"] = searchString;

            //definisi jumlah data pada halaman
            int pageSize = 5;

            return View(await PaginatedList<Peminjaman>.CreateAsync(menu.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Peminjamen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.IdPeminjaman1)
                .Include(p => p.IdPeminjaman2)
                .Include(p => p.IdPeminjaman3)
                .Include(p => p.IdPeminjamanNavigation)
                .FirstOrDefaultAsync(m => m.IdPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // GET: Peminjamen/Create
        public IActionResult Create()
        {
            ViewData["IdPeminjaman"] = new SelectList(_context.Jaminan, "IdJaminan", "NamaJaminan");
            ViewData["IdPeminjaman"] = new SelectList(_context.Kendaraan, "IdKendaraan", "Ketersediaan");
            ViewData["IdPeminjaman"] = new SelectList(_context.Pengembalian, "IdPengembalian", "IdPengembalian");
            ViewData["IdPeminjaman"] = new SelectList(_context.Customer, "IdCustomer", "Alamat");
            return View();
        }

        // POST: Peminjamen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPeminjaman,TglPeminjaman,IdKendaraan,IdCustomer,IdJaminan,Biaya")] Peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peminjaman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPeminjaman"] = new SelectList(_context.Jaminan, "IdJaminan", "NamaJaminan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Kendaraan, "IdKendaraan", "Ketersediaan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Pengembalian, "IdPengembalian", "IdPengembalian", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Customer, "IdCustomer", "Alamat", peminjaman.IdPeminjaman);
            return View(peminjaman);
        }

        // GET: Peminjamen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null)
            {
                return NotFound();
            }
            ViewData["IdPeminjaman"] = new SelectList(_context.Jaminan, "IdJaminan", "NamaJaminan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Kendaraan, "IdKendaraan", "Ketersediaan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Pengembalian, "IdPengembalian", "IdPengembalian", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Customer, "IdCustomer", "Alamat", peminjaman.IdPeminjaman);
            return View(peminjaman);
        }

        // POST: Peminjamen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPeminjaman,TglPeminjaman,IdKendaraan,IdCustomer,IdJaminan,Biaya")] Peminjaman peminjaman)
        {
            if (id != peminjaman.IdPeminjaman)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peminjaman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeminjamanExists(peminjaman.IdPeminjaman))
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
            ViewData["IdPeminjaman"] = new SelectList(_context.Jaminan, "IdJaminan", "NamaJaminan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Kendaraan, "IdKendaraan", "Ketersediaan", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Pengembalian, "IdPengembalian", "IdPengembalian", peminjaman.IdPeminjaman);
            ViewData["IdPeminjaman"] = new SelectList(_context.Customer, "IdCustomer", "Alamat", peminjaman.IdPeminjaman);
            return View(peminjaman);
        }

        // GET: Peminjamen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peminjaman = await _context.Peminjaman
                .Include(p => p.IdPeminjaman1)
                .Include(p => p.IdPeminjaman2)
                .Include(p => p.IdPeminjaman3)
                .Include(p => p.IdPeminjamanNavigation)
                .FirstOrDefaultAsync(m => m.IdPeminjaman == id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            return View(peminjaman);
        }

        // POST: Peminjamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeminjamanExists(int id)
        {
            return _context.Peminjaman.Any(e => e.IdPeminjaman == id);
        }
    }
}
