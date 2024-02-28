using RestAPI_TESTE.Models;
using RestAPI_TESTE.Repository.Interfaces;

namespace RestAPI_TESTE.Services {
    public class PessoaService : IPessoaService {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository) {
            _pessoaRepository = pessoaRepository;
        }

        public async Task CreatePessoa(Pessoa pessoa) {
            pessoa.CpfReplace();
            await _pessoaRepository.CreatePessoa(pessoa);
        }

        public async Task DeletePessoa(int id) {
            await _pessoaRepository.DeletePessoa(id);
        }

        public async Task<List<Pessoa>> GetAllPessoas() {
            var list = await _pessoaRepository.GetAllPessoas();
            return list.Select(pessoa => { 
                pessoa.CpfSetFormat(); 
                return pessoa; 
            }).ToList();
        }

        public async Task<Pessoa> GetPessoaById(int id) {
            Pessoa pessoa = await _pessoaRepository.GetPessoaById(id);
            pessoa.CpfSetFormat();
            return pessoa;
        }

        public async Task UpdatePessoa(Pessoa pessoa, int id) {
            pessoa.CpfReplace();
            await _pessoaRepository.UpdatePessoa(pessoa, id);
        }
    }
}
