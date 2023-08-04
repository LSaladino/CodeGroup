﻿using Microsoft.EntityFrameworkCore;
using PP.Core.Domain;
using PP.Data.Context;
using PP.Manager.Interfaces.Repositories;

namespace PP.Data.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly MyDataContext context;
        public PessoaRepository(MyDataContext context)
        {
            this.context = context;
        }
        public async Task<Pessoa> DeletePessoaAsync(int id)
        {

            var pessoaPesquisada = await context.Pessoas.FindAsync(id);
            if (pessoaPesquisada == null)
            {
                return null;
            }
            var pessoaRemovida = context.Pessoas.Remove(pessoaPesquisada);
            await context.SaveChangesAsync();
            return pessoaRemovida.Entity;
        }

        public async Task<Pessoa> GetPessoaAsync(int id)
        {
            return await context.Pessoas.SingleOrDefaultAsync(p => p.Id == id); 
        }

        public async Task<IEnumerable<Pessoa>> GetPessoasAsync()
        {
            return await context.Pessoas.AsNoTracking().ToListAsync();
        }

        public async Task<Pessoa> InsertPessoaAsync(Pessoa pessoa)
        {
            await context.Pessoas.AddAsync(pessoa);
            await context.SaveChangesAsync();
            return pessoa;
        }

        public async Task<Pessoa> UpdatePessoaAsync(Pessoa pessoa)
        {
            // first, exec a search to verify if exists into database
            var pessoaConsultada = await context.Pessoas.FindAsync(pessoa.Id);

            if(pessoaConsultada == null)
            {
                return null;
            }

            //pessoaConsultada.Nome = pessoa.Nome;
            //pessoaConsultada.DataNascimento = pessoa.DataNascimento;
            // better use Entry method

            context.Entry(pessoaConsultada).CurrentValues.SetValues(pessoa);

            //context.Pessoas.Update(pessoaConsultada); made in the top row 
            await context.SaveChangesAsync();
            return pessoaConsultada;

        }
    }
}