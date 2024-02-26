using System.ComponentModel.DataAnnotations;

namespace RestAPI_TESTE.Models {
    public class Pessoa {
        [Required (ErrorMessage = "Obrigatório!")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public string? Cpf { get; set; }

        [Required(ErrorMessage = "Obrigatório!")]
        public DateTime? BirthDate { get; set; }

        public void CpfReplace() {
            Cpf = Cpf!.Replace(".", "").Replace("-", "");
        }
    }
}
