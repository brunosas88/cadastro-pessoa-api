using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

		public async Task<List<PessoaRequisicao>> ListarPessoasAsync()
		{
			List<PessoaRequisicao> listaPessoas = new List<PessoaRequisicao>();
			var dadosPessoas = await _context.Pessoas.Include(campo => campo.Endereco).ToListAsync();

			return dadosPessoas.Select(ConverterModeloParaDTO).ToList();
		}


		private async Task<Pessoa> ConverterDTOParaModelo (PessoaRequisicao requisicao)
		{

			if (requisicao.RegistroSocial.Length == 14)
			{
				PessoaJuridica novaPessoa = new PessoaJuridica();
				novaPessoa = (PessoaJuridica) await CriarPessoa(requisicao, novaPessoa);				
				novaPessoa.Cnpj = requisicao.RegistroSocial;		
				return novaPessoa;
			}
			else
			{
				PessoaFisica novaPessoa = new PessoaFisica();
				novaPessoa = (PessoaFisica) await CriarPessoa(requisicao, novaPessoa);
				novaPessoa.Cpf = requisicao.RegistroSocial;
				return novaPessoa;
			}
		}

		private PessoaRequisicao ConverterModeloParaDTO(Pessoa modelo)
		{
			PessoaRequisicao dtoPessoa = new PessoaRequisicao();
			dtoPessoa.Nome = modelo.Nome;
			dtoPessoa.Email = modelo.Email;
			dtoPessoa.Telefone = modelo.Telefone;
			dtoPessoa.Endereco = _enderecoService.ConverterModeloParaDTO(modelo.Endereco);

			if (modelo is PessoaFisica modeloPessoaFisica)			
				dtoPessoa.RegistroSocial = modeloPessoaFisica.Cpf;			
			else if (modelo is PessoaJuridica modeloPessoaJuridica)
				dtoPessoa.RegistroSocial = modeloPessoaJuridica.Cnpj;

            return dtoPessoa;
		}



		private async Task<Pessoa> CriarPessoa(PessoaRequisicao requisicao, Pessoa novaPessoa)
		{
			Endereco enderecoSalvo = await _enderecoService.CriarEnderecoAsync(requisicao.Endereco);
			novaPessoa.Nome = requisicao.Nome;
			novaPessoa.Email = requisicao.Email;
			novaPessoa.Telefone = requisicao.Telefone;
			novaPessoa.EstaAtivo = true;
			novaPessoa.CriadoEm = DateTime.Now;
			novaPessoa.AtualizadoEm = DateTime.Now;
			novaPessoa.Endereco = enderecoSalvo;
			novaPessoa.EnderecoId = enderecoSalvo.Id;
			return novaPessoa;
		}


	}
}
