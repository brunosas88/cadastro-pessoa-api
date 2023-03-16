using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CadastroPessoa.API.Services
{
	public class PessoaService
	{
		private readonly DataContext _context;
		private readonly EnderecoService _enderecoService;

		public PessoaService(DataContext context, EnderecoService enderecoService) 
		{ 
			_context = context;
			_enderecoService = enderecoService;
		}

		public async Task<PessoaRequisicao> SalvarPessoaAsync(PessoaRequisicao requisicao)
		{
			Pessoa pessoaParaSalvar = await ConverterDTOParaModelo(requisicao);

			if (pessoaParaSalvar is PessoaFisica pessoaFisica)			
				_context.PessoasFisicas.Add(pessoaFisica);
			
			else if (pessoaParaSalvar is PessoaJuridica pessoaJuridica)
				_context.PessoasJuridicas.Add(pessoaJuridica);

			await _context.SaveChangesAsync();

			return requisicao;
		}

		private async Task<Pessoa> ConverterDTOParaModelo (PessoaRequisicao requisicao)
		{
			Endereco enderecoSalvo = await _enderecoService.CriarEnderecoAsync(requisicao.Endereco);

			if (requisicao.RegistroSocial.Length == 14)
			{
				PessoaJuridica novaPessoa = new PessoaJuridica();
				novaPessoa.Nome = requisicao.Nome;
				novaPessoa.Email = requisicao.Email;
				novaPessoa.Telefone = requisicao.Telefone;
				novaPessoa.EstaAtivo = true;
				novaPessoa.CriadoEm = DateTime.Now;
				novaPessoa.AtualizadoEm = DateTime.Now;
				novaPessoa.Endereco = enderecoSalvo;
				novaPessoa.EnderecoId = enderecoSalvo.Id;
				novaPessoa.Cnpj = requisicao.RegistroSocial;
				return novaPessoa;
			}
			else
			{
				PessoaFisica novaPessoa = new PessoaFisica();
				novaPessoa.Nome = requisicao.Nome;
				novaPessoa.Email = requisicao.Email;
				novaPessoa.Telefone = requisicao.Telefone;
				novaPessoa.EstaAtivo = true;
				novaPessoa.CriadoEm = DateTime.Now;
				novaPessoa.AtualizadoEm = DateTime.Now;
				novaPessoa.Endereco = enderecoSalvo;
				novaPessoa.EnderecoId = enderecoSalvo.Id;
				novaPessoa.Cpf = requisicao.RegistroSocial;
				return novaPessoa;
			}
		}



	}
}
