using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroPessoa.API.Domain.Models
{
	[Table("Pessoas")]
	public abstract class Pessoa
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[MaxLength(60, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
		[MinLength(3, ErrorMessage = "Campo deve conter entre 3 e 60 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		public string Telefone { get; set; }
		public bool EstaAtivo { get; set; }
		public DateTime CriadoEm { get; set; }
		public DateTime AtualizadoEm { get; set; }
		public Endereco Endereco { get; set; }
	}
}
