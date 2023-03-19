using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.API.Domain.DTO
{
	public class PessoaRequisicao
	{
		[Required(ErrorMessage = "Campo Obrigatório")]
		[MaxLength(60, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
		[MinLength(3, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string Telefone { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string RegistroSocial { get; set; }

		public EnderecoDTO Endereco { get; set; }
	}
}
