using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Web.ViewModels;

namespace Web.Mappers
{
	public static class AdvogadoMapper
	{
		public static AdvogadoViewModel MapearParaViewModel(Advogado advogado)
		{
			if (advogado == null)
				return null;

			return new AdvogadoViewModel
			{
				Id = advogado.Id,
				Nome = advogado.Nome,
				Senioridade = advogado.Senioridade,
				Logradouro = advogado.Logradouro,
				Bairro = advogado.Bairro,
				Estado = advogado.Estado,
				Cep = advogado.Cep,
				Numero = advogado.Numero,
				Complemento = advogado.Complemento
			};
		}

		public static Advogado MapearParaEntidade(AdvogadoViewModel viewModel)
		{
			if (viewModel == null)
				return null;

			return new Advogado
			{
				Id = viewModel.Id,
				Nome = viewModel.Nome,
				Senioridade = viewModel.Senioridade.Value,
				Logradouro = viewModel.Logradouro,
				Bairro = viewModel.Bairro,
				Estado = viewModel.Estado,
				Cep = RemoverMascara(viewModel.Cep),
				Numero = viewModel.Numero.Value,
				Complemento = viewModel.Complemento
			};
		}

		private static string RemoverMascara(string valor)
		{
			if (string.IsNullOrEmpty(valor))
				return valor;

			return Regex.Replace(valor, @"\D", "");
		}
	}
}