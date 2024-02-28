using FluentValidation;
using Humanizer;
using RestAPI_TESTE.Models.Enums;

namespace RestAPI_TESTE.Models.Validations {
    public class PessoaValidation : AbstractValidator<Pessoa> {

        public PessoaValidation() {
            
            RuleFor(pessoa => pessoa.Name)
                .NotEmpty()
                    .WithMessage(MsgErrorEnum.MSGE03.Humanize())
                .Length(10, 70)
                    .WithMessage(MsgErrorEnum.MSGE04.Humanize())
                    .When(pessoa => !string.IsNullOrEmpty(pessoa.Name), ApplyConditionTo.CurrentValidator);

            RuleFor(pessoa => pessoa.Cpf)
                .NotEmpty()
                    .WithMessage(MsgErrorEnum.MSGE03.Humanize())
                .Must(ValidationRegexCpf)
                    .WithMessage(MsgErrorEnum.MSGE05.Humanize())
                    .When(pessoa => !string.IsNullOrEmpty(pessoa.Cpf), ApplyConditionTo.CurrentValidator);

            RuleFor(pessoa => pessoa.Email)
                .NotEmpty()
                    .WithMessage(MsgErrorEnum.MSGE03.Humanize())
                .EmailAddress()
                    .WithMessage(MsgErrorEnum.MSGE05.Humanize())
                    .When(pessoa => !string.IsNullOrEmpty(pessoa.Email), ApplyConditionTo.CurrentValidator);

            RuleFor(pessoa => pessoa.BirthDate)
                .Must(MinValidationOfLegalAge)
                    .WithMessage(MsgErrorEnum.MSGE06.Humanize())
                .Must(MaxValidationOfLegalAge)
                    .WithMessage(MsgErrorEnum.MSGE07.Humanize())
                .When(pessoa => pessoa.BirthDate != DateTime.MinValue)  
                .NotEmpty()
                    .WithMessage(MsgErrorEnum.MSGE03.Humanize());              

            RuleFor(pessoa => pessoa.SexoPessoa)
                .NotEmpty().WithMessage(MsgErrorEnum.MSGE03.Humanize());
        }

        private bool MinValidationOfLegalAge(DateTime birthDate) {
            int days = (DateTime.Now - birthDate).Days;
            int age = days / 365;
            return (age < 18 ) ? false : true;
        }
        private bool MaxValidationOfLegalAge(DateTime birthDate)
        {
            int days = (DateTime.Now - birthDate).Days;
            int age = days / 365;
            return (age > 130) ? false : true;
        }

        private bool ValidationRegexCpf(string cpf) {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf == "00000000000") return false;
            if (cpf.Length != 11) return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }
            resto = soma % 11;
            if (resto < 2) resto = 0;
            else resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }
            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
