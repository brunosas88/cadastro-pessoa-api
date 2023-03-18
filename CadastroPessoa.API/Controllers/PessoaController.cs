using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Services;
using Microsoft.AspNetCore.Http;
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
		public async Task<ActionResult<List<PessoaRequisicao>>> ListarPessoas()
		{
			return await _pessoaService.ListarPessoas();
		}

		[HttpGet]
		[Route("buscar/pessoa_fisica/{cpf}")]
		public async Task<ActionResult<PessoaRequisicao>> BuscarPessoaFisica(string cpf)
		{
			try
			{
				var result = await _pessoaService.BuscarPessoaFisica(cpf);				
				return result;
			}
			catch (System.Exception)
			{
				return NotFound();
			}
			
		}

		[HttpGet]
		[Route("buscar/pessoa_juridica/{cnpj}")]
		public async Task<ActionResult<PessoaRequisicao>> BuscarPessoaJuridica(string cnpj)
		{
			try
			{
				var result = await _pessoaService.BuscarPessoaJuridica(cnpj);
				return result;
			}
			catch (System.Exception)
			{
				return NotFound();
			}

		}


	}
}
