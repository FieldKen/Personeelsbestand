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
					Employment = vm.Employment,
					Age = vm.Age
				};

				employeeDatabase.Insert(employee);
				return RedirectToAction(nameof(Index));
			}

			return View();
		}

		[HttpGet]
		public IActionResult Detail([FromRoute] int id)
		{
			var employee = employeeDatabase.Get(id);

			var vm = new EmployeeDetailViewModel
			{
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				Age = employee.Age,
				Employment = employee.Employment,
				Id = employee.Id
			};

			return View(vm);
		}
	}
}
