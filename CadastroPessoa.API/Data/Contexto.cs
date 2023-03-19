using CadastroPessoa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroPessoa.API.Data
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto> options) : base(options) { }

		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Pessoa> Pessoas { get; set; }		
		public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
		public DbSet<PessoaFisica> PessoasFisicas { get; set; }
	}
}
