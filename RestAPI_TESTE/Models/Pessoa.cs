using System.ComponentModel.DataAnnotations;
using RestAPI_TESTE.Models.Enums;

namespace RestAPI_TESTE.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public DateTime? BirthDate { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public SexoEnum SexoPessoa { get; set; }

        public void CpfReplace()
        {
            Cpf = Cpf!.Replace(".", "").Replace("-", "");
        }
    }
}
