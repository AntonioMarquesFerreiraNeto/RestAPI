using RestAPI_TESTE.Models;

namespace RestAPI_TESTE.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa, int id); 
        Task DeletePessoa(int id);
        Task<Pessoa> GetPessoaById(int id);
        Task<List<Pessoa>> GetAllPessoas();
    }
}
