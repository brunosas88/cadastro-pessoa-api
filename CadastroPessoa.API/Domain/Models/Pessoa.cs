using System;

namespace CadastroPessoa.API.Domain.Models
{
	public abstract class Pessoa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public bool EstaAtivo { get; set; }
		public DateTime CriadoEm { get; set; }
		public DateTime AtualizadoEm { get; set; }
		public Endereco Endereco { get; set; }
	}
}
