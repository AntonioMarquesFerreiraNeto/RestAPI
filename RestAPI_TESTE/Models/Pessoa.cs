using System.ComponentModel.DataAnnotations;
using RestAPI_TESTE.Models.Enums;

namespace RestAPI_TESTE.Models {

    public class Pessoa {

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public SexoEnum SexoPessoa { get; private set; }

        public Pessoa(string name, string cpf, DateTime? birthDate, SexoEnum sexoPessoa) {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            SexoPessoa = sexoPessoa;
        }

        public void CpfReplace() {
            Cpf = Cpf!.Replace(".", "").Replace("-", "");
        }
        public void CpfSetFormat() {
            Cpf = Convert.ToInt64(Cpf).ToString(@"000\.000\.000\-00");
        }
        public void UpdatePessoa(string name, string cpf, DateTime? birthDate, SexoEnum sexoPessoa) {
            Name = name;
            Cpf = cpf;
            BirthDate = birthDate;
            SexoPessoa = sexoPessoa;
        }
    }
}
