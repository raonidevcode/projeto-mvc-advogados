using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModels
{
	[Serializable]
	public class AdvogadoViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Informe o nome do advogado.")]
		[Display(Name = "Nome do Advogado")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Selecione a senioridade.")]
		[Display(Name = "Senioridade")]
		public SenioridadeEnum? Senioridade { get; set; }

		[Required(ErrorMessage = "Informe o logradouro.")]
		public string Logradouro { get; set; }

		[Required(ErrorMessage = "Informe o bairro.")]
		public string Bairro { get; set; }

		[Required(ErrorMessage = "Selecione o estado.")]
		public string Estado { get; set; }

		[Required(ErrorMessage = "Informe o CEP.")]
		public string Cep { get; set; }

		[Required(ErrorMessage = "Informe o número.")]
		[Range(1, int.MaxValue, ErrorMessage = "Informe um número válido.")]
		public int? Numero { get; set; }

		[Required(ErrorMessage = "Informe o complemento.")]
		public string Complemento { get; set; }
	}
}