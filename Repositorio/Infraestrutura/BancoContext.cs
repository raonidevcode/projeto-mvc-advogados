using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Infraestrutura
{
	public class BancoContext : DbContext
	{
		public BancoContext() : base("DefaultConnection") { }

		public DbSet<Advogado> Advogados { get; set; }
	}
}
