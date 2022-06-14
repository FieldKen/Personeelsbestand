using Personeelsbestand.Domain;

namespace Personeelsbestand.Database
{
	public interface IEmployeeDatabase
	{
		Employee Insert(Employee employee);
		IEnumerable<Employee> GetAll();
		Employee Get(int id);
		void Update(int id, Employee employee);
		void Delete(int id);
	}

}
