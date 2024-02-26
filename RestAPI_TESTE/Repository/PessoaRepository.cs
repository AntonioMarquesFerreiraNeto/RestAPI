using Humanizer;
using Microsoft.EntityFrameworkCore;
using RestAPI_TESTE.Data;
using RestAPI_TESTE.Models;
using RestAPI_TESTE.Models.Enums;
using RestAPI_TESTE.Repository.Interfaces;

namespace RestAPI_TESTE.Repository {
    public class PessoaRepository : IPessoaRepository {

        private readonly BancoContext _bancoContext;

        public PessoaRepository(BancoContext bancoContext) {
            _bancoContext = bancoContext;
        }

        public async Task CreatePessoa(Pessoa pessoa) {
            pessoa.CpfReplace();
            _bancoContext.Pessoa.Add(pessoa);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task DeletePessoa(int id) {
            Pessoa dataDB = await GetPessoaById(id);
            _bancoContext.Pessoa.Remove(dataDB);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> GetAllPessoas() {
            return  await _bancoContext.Pessoa.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaById(int id) {
            return await _bancoContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception(MsgErrorEnum.MSGE01.Humanize());
        }

        public async Task UpdatePessoa(Pessoa pessoa, int id) {
            Pessoa dataDB = await GetPessoaById(id);
            pessoa.CpfReplace();
            dataDB.Name = pessoa.Name;
            dataDB.Cpf = pessoa.Cpf;
            dataDB.BirthDate = pessoa.BirthDate;
            _bancoContext.Pessoa.Update(dataDB);
            await _bancoContext.SaveChangesAsync();
        }

    }
}
