using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuicklyRecycle.Data;
using QuicklyRecycle.Models;
using X.PagedList;

namespace QuicklyRecycle.Controllers
{
	[Authorize]
	public class CollectorsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CollectorsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Collectors
		public async Task<IActionResult> Index(int? pagina)

		{

			const int itensPorPagina = 10;
			int numeroPagina = (pagina ?? 1);

			return View(await _context.Collector.ToPagedListAsync(numeroPagina, itensPorPagina));
		}

		// GET: Collectors/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collector = await _context.Collector
				.FirstOrDefaultAsync(m => m.Id == id);
			if (collector == null)
			{
				return NotFound();
			}

			return View(collector);
		}

		// GET: Collectors/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Collectors/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Landline,CellPhone")] Collector collector)
		{
			if (ModelState.IsValid)
			{
				_context.Add(collector);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(collector);
		}

		// GET: Collectors/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collector = await _context.Collector.FindAsync(id);
			if (collector == null)
			{
				return NotFound();
			}
			return View(collector);
		}

		// POST: Collectors/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Landline,CellPhone")] Collector collector)
		{
			if (id != collector.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(collector);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CollectorExists(collector.Id))
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
			return View(collector);
		}

		// GET: Collectors/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var collector = await _context.Collector
				.FirstOrDefaultAsync(m => m.Id == id);
			if (collector == null)
			{
				return NotFound();
			}

			return View(collector);
		}

		// POST: Collectors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var collector = await _context.Collector.FindAsync(id);
			_context.Collector.Remove(collector);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CollectorExists(int id)
		{
			return _context.Collector.Any(e => e.Id == id);
		}
	}
}
