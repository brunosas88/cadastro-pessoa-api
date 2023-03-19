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
		public async Task<ActionResult<PessoaResposta>> CadastrarPessoa([FromBody] PessoaRequisicao requisicao)
		{
			return await _pessoaService.CadastrarPessoa(requisicao);
		}

		[HttpGet]
		[Route("")]
		public async Task<ActionResult<List<PessoaResposta>>> ListarPessoas()
		{
			return await _pessoaService.ListarPessoas();
		}

		[HttpGet]
		[Route("buscar/pessoa_fisica/{cpf}")]
		public async Task<ActionResult<PessoaResposta>> BuscarPessoaFisica(string cpf)
		{
			try
			{
				PessoaResposta result = await _pessoaService.BuscarPessoaFisica(cpf);				
				return result;
			}
			catch (System.Exception)
			{
				return NotFound();
			}
			
		}

		[HttpGet]
		[Route("buscar/pessoa_juridica/{cnpj}")]
		public async Task<ActionResult<PessoaResposta>> BuscarPessoaJuridica(string cnpj)
		{
			try
			{
				PessoaResposta result = await _pessoaService.BuscarPessoaJuridica(cnpj);
				return result;
			}
			catch (System.Exception)
			{
				return NotFound();
			}

		}

		[HttpDelete]
		[Route("excluir/{registroSocial}")]
		public async Task ExcluirPessoa (string registroSocial)
		{
			await _pessoaService.ExcluirPessoa(registroSocial);
		}


	}
}
