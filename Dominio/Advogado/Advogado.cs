using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
	[Serializable]
	public class Advogado
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(150)]
		public string Nome { get; set; }

		[Required]
		public SenioridadeEnum Senioridade { get; set; }

		[Required]
		[MaxLength(200)]
		public string Logradouro { get; set; }

		[Required]
		[MaxLength(100)]
		public string Bairro { get; set; }

		[Required]
		[MaxLength(2)]
		public string Estado { get; set; }

		[Required]
		[MaxLength(9)]
		public string Cep { get; set; }
				
		public int Numero { get; set; }

		[Required]
		[MaxLength(100)]
		public string Complemento { get; set; }
	}
}
