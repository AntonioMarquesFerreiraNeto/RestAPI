using RestAPI_TESTE.Models;

namespace RestAPI_TESTE.Services {
    public interface IPessoaService {
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa, int id);
        Task DeletePessoa(int id);
        Task<List<Pessoa>> GetAllPessoas();
        Task<Pessoa> GetPessoaById(int id);
    }
}
