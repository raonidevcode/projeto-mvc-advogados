using Dominio;
using Repositorio.Implementacao;
using Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Mappers;
using Web.ViewModels;

namespace Web.Controllers
{
	//[Authorize]
	public class AdvogadoController : Controller
	{
		private readonly IAdvogadoRepositorio _advogadoRepositorio;

		public AdvogadoController() : this(new AdvogadoRepositorio())
		{
		}

		public AdvogadoController(IAdvogadoRepositorio advogadoRepositorio)
		{
			_advogadoRepositorio = advogadoRepositorio;
		}

		
		public ActionResult Index()
		{
			var lista = _advogadoRepositorio
				.Listar()
				.Select(AdvogadoMapper.MapearParaViewModel)
				.ToList();

			return View(lista);
		}

		
		public ActionResult Formulario(int? id)
		{
			if (!id.HasValue)
				return View(new AdvogadoViewModel());

			var advogado = _advogadoRepositorio.ObterPorId(id.Value);

			if (advogado == null)
				return HttpNotFound();

			return View(AdvogadoMapper.MapearParaViewModel(advogado));
		}

		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Formulario(AdvogadoViewModel viewModel)
		{
			if (!ModelState.IsValid)
				return View(viewModel);

			try
			{
				var advogado = AdvogadoMapper.MapearParaEntidade(viewModel);

				if (viewModel.Id == 0)
					_advogadoRepositorio.Incluir(advogado);
				else
					_advogadoRepositorio.Atualizar(advogado);

				return RedirectToAction("Index");
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Erro ao salvar o advogado.");
				return View(viewModel);
			}
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Excluir(int id)
		{
			try
			{
				_advogadoRepositorio.Excluir(id);
			}
			catch (Exception)
			{
				ModelState.AddModelError("", "Erro ao excluir o advogado.");
			}

			return RedirectToAction("Index");
		}
	}
}