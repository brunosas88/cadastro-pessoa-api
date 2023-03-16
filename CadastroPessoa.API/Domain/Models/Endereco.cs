﻿using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.API.Domain.Models
{
	public class Endereco
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Campo Obrigatório")]
		[StringLength(8)]
		public string Cep { get; set; }
		public string Numero { get; set; }
		public string Logradouro { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Uf { get; set; }
		public string Complemento { get; set; }
		public Pessoa Pessoa { get; set; }
	}
}
