using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuicklyRecycle.Models
{
	public class Collector
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Telefone Fixo")]
		public string Landline { get; set; }

		[Required]
		[Display(Name = "Telefone Celular")]
		public string CellPhone { get; set; }
	}
}
