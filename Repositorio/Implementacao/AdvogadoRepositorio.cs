using Dominio;
using Repositorio.Infraestrutura;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implementacao
{
	public class AdvogadoRepositorio : IAdvogadoRepositorio
	{
		private readonly BancoContext _contexto;

		public AdvogadoRepositorio() : this(new BancoContext())	{}

		public AdvogadoRepositorio(BancoContext contexto)
		{
			_contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
		}

		public void Incluir(Advogado advogado)
		{
			if (advogado == null)
				throw new ArgumentNullException(nameof(advogado));

			_contexto.Advogados.Add(advogado);
			_contexto.SaveChanges();
		}

		public void Atualizar(Advogado advogado)
		{
			if (advogado == null)
				throw new ArgumentNullException(nameof(advogado));

			var advogadoAtual = ObterPorId(advogado.Id);

			if (advogadoAtual == null)
				return;

			AtualizarDadosAdvogado(advogadoAtual, advogado);
			_contexto.SaveChanges();
		}

		public void Excluir(int id)
		{
			var advogado = ObterPorId(id);

			if (advogado == null)
				return;

			_contexto.Advogados.Remove(advogado);
			_contexto.SaveChanges();
		}

		public IEnumerable<Advogado> Listar()
		{
			return _contexto.Advogados
				.OrderBy(x => x.Nome)
				.ToList();
		}

		public Advogado ObterPorId(int id)
		{
			return _contexto.Advogados.FirstOrDefault(x => x.Id == id);
		}

		private static void AtualizarDadosAdvogado(Advogado destino, Advogado origem)
		{
			destino.Nome = origem.Nome;
			destino.Senioridade = origem.Senioridade;
			destino.Logradouro = origem.Logradouro;
			destino.Bairro = origem.Bairro;
			destino.Estado = origem.Estado;
			destino.Cep = origem.Cep;
			destino.Numero = origem.Numero;
			destino.Complemento = origem.Complemento;
		}
	}
}
