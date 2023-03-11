using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.API.Domain.DTO
{
	public class PessoaRequisicao
	{
		public string Nome { get; set; }	
		public string Email { get; set; }
		public string Telefone { get; set; }
		public EnderecoDTO Endereco { get; set; }
	}
}
