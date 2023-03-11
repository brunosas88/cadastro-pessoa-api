using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Services;
using Microsoft.AspNetCore.Mvc;
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
		public async Task<ActionResult<PessoaRequisicao>> Post([FromBody] PessoaRequisicao requisicao)
		{
			return await _pessoaService.SalvarPessoaAsync(requisicao);
		}
	}
}
