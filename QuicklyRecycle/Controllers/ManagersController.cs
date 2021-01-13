using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using QuicklyRecycle.Data;
using QuicklyRecycle.Models;
using ReflectionIT.Mvc.Paging;

namespace QuicklyRecycle.Controllers
{
	[Authorize]
	public class ManagersController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ManagersController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: Managers

		public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Name")
		{

			var resultado = _context.Manager.AsNoTracking().AsQueryable();

			if (!string.IsNullOrWhiteSpace(filter))
			{
				resultado = resultado.Where(p => p.Name.Contains(filter));
				resultado = _context.Manager.Include(p => p.Company);
			}
			
			var model = await PagingList.CreateAsync(resultado, 10, pageindex, sort, "Name");
			model.RouteValue = new RouteValueDictionary { { "filter", filter } };
			return View(model);
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
