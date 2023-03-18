using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Controllers
{
	[ApiController]
	[Route("/pessoas")]
	public class PessoaController : ControllerBase
	{
		private readonly PessoaService _pessoaService;

		public PessoaController(PessoaService pessoaService)
		{
			_pessoaService = pessoaService;
		}

		[HttpPost]
		[Route("")]
		public async Task<ActionResult<PessoaRequisicao>> CadastrarPessoa([FromBody] PessoaRequisicao requisicao)
		{
			return await _pessoaService.CadastrarPessoa(requisicao);
		}

		[HttpGet]
		[Route("")]
		public async Task<List<PessoaRequisicao>> ListarPessoas()
		{
			return await _pessoaService.ListarPessoas();
		}
	}
}
