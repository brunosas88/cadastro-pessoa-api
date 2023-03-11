using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa.API.Domain.Models
{
	[Table("PessoasJuridicas")]
	public class PessoaJuridica : Pessoa
	{
		[Required(ErrorMessage = "Campo Obrigatório")]
		[StringLength(14)]
		public string Cnpj { get; set; }
	}
}
