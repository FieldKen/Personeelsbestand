using Microsoft.AspNetCore.Mvc;
using Personeelsbestand.Database;
using Personeelsbestand.Domain;
using Personeelsbestand.Models;

namespace Personeelsbestand.Controllers
{
	public class EmployeeController : Controller
	{
		private IEmployeeDatabase employeeDatabase;

		public EmployeeController(IEmployeeDatabase employeeDatabase)
		{
			this.employeeDatabase = employeeDatabase;
		}

		public IActionResult Index()
		{
			var vm = employeeDatabase.GetAll().Select(x => new EmployeeListViewModel
			{
				Id = x.Id,
				Employment = x.Employment,
				FirstName = x.FirstName,
				LastName = x.LastName
			});

			return View(vm);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create([FromForm] EmployeeCreateViewModel vm)
		{
			if (TryValidateModel(vm))
			{
				var employee = new Employee
				{
					FirstName = vm.FirstName,
					LastName = vm.LastName,
					Employment = vm.Employment
				};

				employeeDatabase.Insert(employee);
				return RedirectToAction(nameof(Index));
			}

			return View();
		}
	}
}
