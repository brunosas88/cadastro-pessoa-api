using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Repository
{
	public class EnderecoRepository
	{
		private readonly DataContext _contexto;
		public EnderecoRepository(DataContext contexto) { _contexto = contexto; }

		public async Task<Endereco> CadastrarEndereco (Endereco novoEndereco)
		{
			var enderecoCadastrado = await _contexto.Enderecos.AddAsync(novoEndereco);
			await _contexto.SaveChangesAsync();
			return enderecoCadastrado.Entity;
		}

		public async Task<Endereco> BuscarEndereco(int id)
		{
			return await _contexto.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);
		}

		public async Task ExcluirEndereco(Endereco enderecoExcluido)
		{
			_contexto.Remove(enderecoExcluido);
			await _contexto.SaveChangesAsync();
		}

		public async Task EditarEndereco(Endereco enderecoEditado)
		{
			_contexto.Update(enderecoEditado);
			await _contexto.SaveChangesAsync();
		}
	}
}
