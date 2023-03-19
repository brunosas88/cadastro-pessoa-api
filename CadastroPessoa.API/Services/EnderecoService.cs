using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using CadastroPessoa.API.Repository;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Services
{
	public class EnderecoService
	{
		private readonly EnderecoRepository _enderecoRepository;

		public EnderecoService(EnderecoRepository enderecoRepository) 
		{  
			_enderecoRepository = enderecoRepository;
		}

		public async Task<Endereco> CriarEnderecoAsync(EnderecoDTO dto)
		{
			Endereco enderecoSalvo = ConverterDTOParaModelo(dto);			
			enderecoSalvo = await _enderecoRepository.CadastrarEndereco(enderecoSalvo);

			return enderecoSalvo;
		}

		public async Task ExcluirEndereco(Endereco enderecoExcluido)
		{
			await _enderecoRepository.ExcluirEndereco(enderecoExcluido);
		}

		private Endereco ConverterDTOParaModelo(EnderecoDTO dto)
		{
			Endereco modeloEndereco = new Endereco();
			modeloEndereco.Cep = dto.Cep;
			modeloEndereco.Numero = dto.Numero;
			modeloEndereco.Logradouro = dto.Logradouro;
			modeloEndereco.Bairro = dto.Bairro;
			modeloEndereco.Cidade = dto.Cidade;
			modeloEndereco.Uf = dto.Uf;
			modeloEndereco.Complemento = dto.Complemento;

			return modeloEndereco;
		}

		public EnderecoDTO ConverterModeloParaDTO(Endereco modelo)
		{
			EnderecoDTO dtoEndereco = new EnderecoDTO();
			dtoEndereco.Cep = modelo.Cep;
			dtoEndereco.Numero = modelo.Numero;
			dtoEndereco.Logradouro = modelo.Logradouro;
			dtoEndereco.Bairro = modelo.Bairro;
			dtoEndereco.Cidade = modelo.Cidade;
			dtoEndereco.Uf = modelo.Uf;
			dtoEndereco.Complemento = modelo.Complemento;

			return dtoEndereco;
		}
	}
}
