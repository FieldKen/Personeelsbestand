using Personeelsbestand.Domain;

namespace Personeelsbestand.Database
{
	public class EmployeeDatabase : IEmployeeDatabase
	{
		private int counter = 0;
		private List<Employee> employees;

		public EmployeeDatabase()
		{
			employees = new List<Employee>();
			Insert(new Employee
			{
				FirstName = "Ken",
				LastName = "Field",
				Employment = new DateTime(2022, 8, 9)
			});

			Insert(new Employee
			{
				FirstName = "Thomas",
				LastName = "Coppens",
				Employment = new DateTime(2021, 2, 5)
			});

			Insert(new Employee
			{
				FirstName = "Arne",
				LastName = "Moens",
				Employment = new DateTime(2017, 5, 4)
			});

			Insert(new Employee
			{
				FirstName = "Arne",
				LastName = "Verbiest",
				Employment = new DateTime(2017, 5, 5)
			});
		}

		public void Delete(int id)
		{
			var employee = employees.FirstOrDefault(x => x.Id == id);
			if (employee != null)
			{
				employees.Remove(employee);
			}
		}

		public Employee Get(int id)
		{
			return employees.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Employee> GetAll()
		{
			return employees;
		}

		public Employee Insert(Employee employee)
		{
			employee.Id = ++counter;
			employees.Add(employee);
			return employee;
		}

		public void Update(int id, Employee newEmployee)
		{
			var employee = employees.FirstOrDefault(x => x.Id == id);
			if (employee != null)
			{
				employee.FirstName = newEmployee.FirstName;
				employee.LastName = newEmployee.LastName;
				employee.Employment = newEmployee.Employment;
				employee.Age = newEmployee.Age;
			}
		}
	}
}
