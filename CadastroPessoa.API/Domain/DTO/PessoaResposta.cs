using System;

namespace CadastroPessoa.API.Domain.DTO
{
	public class PessoaResposta
	{
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }	
		public string RegistroSocial { get; set; }
		public bool EstaAtivo { get; set; }
		public string CriadoEm { get; set; }
		public string AtualizadoEm { get; set; }
		public EnderecoDTO Endereco { get; set; }
	}
}
