using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using CadastroPessoa.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Services
{
	public class PessoaService
	{
		private readonly EnderecoService _enderecoService;
		private readonly PessoaRepository _pessoaRepository;

		public PessoaService(EnderecoService enderecoService, PessoaRepository pessoaRepository) 
		{ 	
			_enderecoService = enderecoService;
			_pessoaRepository = pessoaRepository;
		}

		public async Task<PessoaRequisicao> CadastrarPessoa(PessoaRequisicao requisicao)
		{
			Pessoa novaPessoa = await ConverterDTOParaModelo(requisicao);

			novaPessoa = await _pessoaRepository.CadastrarPessoa(novaPessoa);

			return ConverterModeloParaDTO(novaPessoa);
		}

		public async Task<List<PessoaRequisicao>> ListarPessoas()
		{
			List<PessoaRequisicao> listaPessoas = new List<PessoaRequisicao>();
			List<Pessoa> dadosPessoas = await _pessoaRepository.ListarPessoas();

			return dadosPessoas.Select(ConverterModeloParaDTO).ToList();
		}

		public async Task<PessoaRequisicao> BuscarPessoaFisica(string cpf)
		{
			PessoaFisica pessoaFisica = await _pessoaRepository.BuscarPessoaFisica(cpf);			
			
			return ConverterModeloParaDTO(pessoaFisica);
		}

		public async Task<PessoaRequisicao> BuscarPessoaJuridica(string cnpj)
		{
			PessoaJuridica pessoaJuridica = await _pessoaRepository.BuscarPessoaJuridica(cnpj);

			return ConverterModeloParaDTO(pessoaJuridica);
		}

		public async Task ExcluirPessoa(string registroSocial)
		{
			Pessoa pessoaExcluida = await BuscarPessoa(registroSocial);
				if (pessoaExcluida != null)
				{
					await _pessoaRepository.ExcluirPessoa(pessoaExcluida);
					await _enderecoService.ExcluirEndereco(pessoaExcluida.Endereco);
				}
		}

		private async Task<Pessoa> BuscarPessoa (string registroSocial)
		{
			if (registroSocial.Length == 14)
				return await _pessoaRepository.BuscarPessoaJuridica(registroSocial);
			else
				return await _pessoaRepository.BuscarPessoaFisica(registroSocial);			
		}

		private async Task<Pessoa> ConverterDTOParaModelo (PessoaRequisicao requisicao)
		{

			if (requisicao.RegistroSocial.Length == 14)
			{
				PessoaJuridica novaPessoaJuridica = new PessoaJuridica();
				novaPessoaJuridica = (PessoaJuridica) await CriarModeloPessoa(requisicao, novaPessoaJuridica);				
				novaPessoaJuridica.Cnpj = requisicao.RegistroSocial;		
				return novaPessoaJuridica;
			}
			else
			{
				PessoaFisica novaPessoaFisica = new PessoaFisica();
				novaPessoaFisica = (PessoaFisica) await CriarModeloPessoa(requisicao, novaPessoaFisica);
				novaPessoaFisica.Cpf = requisicao.RegistroSocial;
				return novaPessoaFisica;
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

		private async Task<Pessoa> CriarModeloPessoa(PessoaRequisicao requisicao, Pessoa novaPessoa)
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
