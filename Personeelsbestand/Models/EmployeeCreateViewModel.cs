using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Personeelsbestand.Models
{
	public class EmployeeCreateViewModel
	{
		[Required, MaxLength(50)]
		[DisplayName("First name")]
		public string FirstName { get; set; }

		[Required, MaxLength(50)]
		[DisplayName("Last name")]
		public string LastName { get; set; }

		[DisplayName("Date of employment")]
		public DateTime Employment { get; set; }

		[DisplayName("Age")]
		public int Age { get; set; }
	}
}
