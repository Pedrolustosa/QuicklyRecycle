using QuicklyRecycle.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace QuicklyRecycle.Controllers
{
	public class DashboardsController : Controller
	{
		private readonly ApplicationDbContext _context;
		public DashboardsController( ApplicationDbContext context)
		{
			
			_context = context;

		}
			
		// GET: Dashboard
		public ActionResult Index()
		{
			int qtdManagers = _context.Manager.Count();
			int qtdCollectors = _context.Collector.Count();
			int qtdCompanies = _context.Company.Count();
			ViewData["Companies"] = qtdCompanies;
			ViewData["Managers"] = qtdManagers;
			ViewData["Collectors"] = qtdCollectors;
			return View("Index");
		}

	}
}
