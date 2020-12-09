using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuicklyRecycle.Data;
using QuicklyRecycle.Models;
using X.PagedList;

namespace QuicklyRecycle.Controllers
{
	
	public class ManagersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ManagersController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Managers
		public async Task<IActionResult> Index(int? pagina)

		{

			const int itensPorPagina = 10;
			int numeroPagina = (pagina ?? 1);

			
			var applicationDbContext = _context.Manager.Include(p => p.Company);
			//var test = _context.Manager.ToPagedListAsync(numeroPagina, itensPorPagina);
			return View(await _context.Manager.ToPagedListAsync(numeroPagina, itensPorPagina));
		}
		

		// GET: Managers/Create
		public IActionResult Create()
		{
			ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name");
			return View();
		}

		// POST: Managers/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Telefone,CompanyId")] Manager manager)
		{
			if (ModelState.IsValid)
			{
				_context.Add(manager);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name", manager.CompanyId);
			return View(manager);
		}

		// GET: Managers/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manager = await _context.Manager.FindAsync(id);
			if (manager == null)
			{
				return NotFound();
			}
			ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name", manager.CompanyId);
			return View(manager);
		}

		// POST: Managers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Telefone,CompanyId")] Manager manager)
		{
			if (id != manager.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(manager);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ManagerExists(manager.Id))
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
			ViewData["CompanyId"] = new SelectList(_context.Company, "Id", "Name", manager.CompanyId);
			return View(manager);
		}

		// GET: Managers/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var manager = await _context.Manager
				.Include(m => m.Company)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (manager == null)
			{
				return NotFound();
			}

			return View(manager);
		}

		// POST: Managers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var manager = await _context.Manager.FindAsync(id);
			_context.Manager.Remove(manager);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool ManagerExists(int id)
		{
			return _context.Manager.Any(e => e.Id == id);
		}
	}
}
