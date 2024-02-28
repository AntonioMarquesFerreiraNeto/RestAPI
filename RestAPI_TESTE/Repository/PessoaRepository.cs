using Humanizer;
using Microsoft.EntityFrameworkCore;
using RestAPI_TESTE.CustomExceptions;
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
            _bancoContext.Pessoa.Add(pessoa);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task DeletePessoa(int id) {
            Pessoa dataDB = await GetPessoaById(id);
            _bancoContext.Pessoa.Remove(dataDB);
            await _bancoContext.SaveChangesAsync();
        }

        public async Task<List<Pessoa>> GetAllPessoas() {
            return await _bancoContext.Pessoa.ToListAsync() ?? throw new NotFoundException(MsgErrorEnum.MSGE01.Humanize()); ;
        }

        public async Task<Pessoa> GetPessoaById(int id) {
            return await _bancoContext.Pessoa.FirstOrDefaultAsync(x => x.Id == id) ?? throw new NotFoundException(MsgErrorEnum.MSGE01.Humanize());
        }

        public async Task UpdatePessoa(Pessoa pessoa, int id) {
            Pessoa dataDB = await GetPessoaById(id);
            dataDB.UpdatePessoa(pessoa.Name, pessoa.Cpf, pessoa.BirthDate, pessoa.SexoPessoa, pessoa.Email);
            _bancoContext.Pessoa.Update(dataDB);
            await _bancoContext.SaveChangesAsync();
        }
    }
}
