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
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public bool EstaAtivo { get; set; }
		public DateTime CriadoEm { get; set; }
		public DateTime AtualizadoEm { get; set; }
		public Endereco Endereco { get; set; }
		public int EnderecoId { get; set; }
	}
}
