using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interface
{
	public interface IAdvogadoRepositorio
	{
		void Incluir(Advogado advogado);
		void Atualizar(Advogado advogado);
		void Excluir(int id);

		IEnumerable<Advogado> Listar();
		Advogado ObterPorId(int id);
	}
}
