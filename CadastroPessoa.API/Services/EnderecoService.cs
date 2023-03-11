using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Services
{
	public class EnderecoService
	{
		private readonly DataContext _context;

		public EnderecoService(DataContext context) {  _context = context; }

		public async Task<Endereco> CriarEnderecoAsync(EnderecoDTO dto)
		{
			Endereco enderecoSalvo = ConverterDTOParaModelo(dto);
			_context.Enderecos.Add(enderecoSalvo);
			await _context.SaveChangesAsync();
			return enderecoSalvo;
		}

		private Endereco ConverterDTOParaModelo(EnderecoDTO dto)
		{
			Endereco novoEndereco = new Endereco();
			novoEndereco.Cep = dto.Cep;
			novoEndereco.Numero = dto.Numero;
			novoEndereco.Logradouro = dto.Logradouro;
			novoEndereco.Bairro = dto.Bairro;
			novoEndereco.Cidade = dto.Cidade;
			novoEndereco.Complemento = dto.Complemento;

			return novoEndereco;
		}
	}
}
