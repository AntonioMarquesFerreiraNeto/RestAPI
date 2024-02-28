using System.ComponentModel.DataAnnotations;
using RestAPI_TESTE.Models.Enums;

namespace RestAPI_TESTE.Models {

    public class Pessoa {

        public Pessoa(string name, string cpf, DateTime birthDate, SexoEnum sexoPessoa, string email) {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            SexoPessoa = sexoPessoa;
            Email = email;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public SexoEnum SexoPessoa { get; private set; }

        public void CpfReplace() {
            Cpf = Cpf!.Replace(".", "").Replace("-", "");
        }
        public void CpfSetFormat() {
            Cpf = Convert.ToInt64(Cpf).ToString(@"000\.000\.000\-00");
        }
        public void UpdatePessoa(string name, string cpf, DateTime birthDate, SexoEnum sexoPessoa, string email) {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            SexoPessoa = sexoPessoa;
            Email = email;
        }
    }
}
