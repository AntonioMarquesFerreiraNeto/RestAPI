using RestAPI_TESTE.Models;

namespace RestAPI_TESTE.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        void CreatePessoa(Pessoa pessoa);
        void UpdatePessoa(Pessoa pessoa, int id); 
        void DeletePessoa(int id);
        Pessoa GetPessoaById(int id);
        List<Pessoa> GetAllPessoas();
    }
}
