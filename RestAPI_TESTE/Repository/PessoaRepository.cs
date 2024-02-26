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

        public void CreatePessoa(Pessoa pessoa) {
            pessoa.CpfReplace();
            _bancoContext.Pessoa.Add(pessoa);
            _bancoContext.SaveChanges();
        }

        public void DeletePessoa(int id) {
            Pessoa dataDB = GetPessoaById(id);
            _bancoContext.Pessoa.Remove(dataDB);
            _bancoContext.SaveChanges();
        }

        public List<Pessoa> GetAllPessoas() {
            return _bancoContext.Pessoa.ToList();
        }

        public Pessoa GetPessoaById(int id) {
            return _bancoContext.Pessoa.FirstOrDefault(x => x.Id == id) ?? throw new Exception(MsgErrorEnum.MSGE01.Humanize());
        }

        public void UpdatePessoa(Pessoa pessoa, int id) {
            Pessoa dataDB = GetPessoaById(id);
            pessoa.CpfReplace();
            dataDB.Name = pessoa.Name;
            dataDB.Cpf = pessoa.Cpf;
            dataDB.BirthDate = pessoa.BirthDate;
            _bancoContext.Pessoa.Update(dataDB);
            _bancoContext.SaveChanges();
        }

    }
}
