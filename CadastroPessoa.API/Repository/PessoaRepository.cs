﻿using CadastroPessoa.API.Data;
using CadastroPessoa.API.Domain.DTO;
using CadastroPessoa.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CadastroPessoa.API.Repository
{
	public class PessoaRepository
	{
		private readonly Contexto _contexto;
		public PessoaRepository(Contexto contexto) { _contexto = contexto; }


		public async Task<List<Pessoa>> ListarPessoas()
		{
			return await _contexto.Pessoas.Include(campo => campo.Endereco).ToListAsync();
		}

		public async Task<Pessoa> CadastrarPessoa(Pessoa novaPessoa)
		{
			var pessoaCadastrada = await _contexto.Pessoas.AddAsync(novaPessoa);

			await _contexto.SaveChangesAsync();

			return pessoaCadastrada.Entity;
		} 

		public async Task EditarPessoa(Pessoa pessoa)
		{
			_contexto.Pessoas.Update(pessoa);
			await _contexto.SaveChangesAsync();
		}

		public async Task<PessoaJuridica> BuscarPessoaJuridica(string cnpj)
		{
			return await _contexto.PessoasJuridicas.Include(campo => campo.Endereco).FirstOrDefaultAsync(pessoaJuridica => pessoaJuridica.Cnpj == cnpj);
		}

		public async Task<PessoaFisica> BuscarPessoaFisica(string cpf)
		{
			return await _contexto.PessoasFisicas.Include(campo => campo.Endereco).FirstOrDefaultAsync(pessoaFisica => pessoaFisica.Cpf == cpf);
		}

		public async Task ExcluirPessoa(Pessoa pessoaExcluida)
		{
			_contexto.Pessoas.Remove(pessoaExcluida);
			await _contexto.SaveChangesAsync();
		}

	}

}
