using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
		public int CompanyId { get; set; }
		
		public Company Company { get; set; }
	}

}
