using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuicklyRecycle.Models
{
	public class Company
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Por favor preencha o Campo com o Nome da Empressa correto.")]
		[Display(Name = "Nome")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Estado")]
		public string UF { get; set; }

		[Required]
		[Display(Name = "Bairro")]
		public string Neighborhood { get; set; }

		[Required]
		[Display(Name = "Logradouro")]
		public string PublicPlace { get; set; }

		[Required]
		[Display(Name = "Cidade")]
		public string City { get; set; }

		[Required(ErrorMessage = "Por favor preencha um Complemento.")]
		[Display(Name = "Complemento")]
		public string Complement { get; set; }

		[Required(ErrorMessage = "Por favor preencha o campo CNPJ.")]
		public string CNPJ { get; set; }

		[Required(ErrorMessage = "Por favor preencha o campo CEP.")]
		public string CEP { get; set; }

		[Required(ErrorMessage = "Por favor preencha o campo Telefone.")]
		[Display(Name = "Telefone")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Por favor preencha o campo Número que representa sua Empresa.")]
		[Display(Name = "Número")]
		public string Number { get; set; }

		public List<Manager> Manager { get; set; }
	}
}
