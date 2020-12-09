using System.ComponentModel.DataAnnotations;

namespace QuicklyRecycle.Models
{
	public class Manager
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
		[Required]
		public string Telefone { get; set; }
		[Required]
		[Display(Name = "Empresa")]
		public int CompanyId { get; set; }
		public Company Company { get; set; }
	}

}
