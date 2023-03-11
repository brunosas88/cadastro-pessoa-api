using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa.API.Domain.Models
{
	[Table("PessoasFisicas")]
	public class PessoaFisica : Pessoa
	{
		[Required(ErrorMessage = "Campo Obrigatório")]
		[StringLength(11)]
		public int Cpf { get; set; }
	}
}
