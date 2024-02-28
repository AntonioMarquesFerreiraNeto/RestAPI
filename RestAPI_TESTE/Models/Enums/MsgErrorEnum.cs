using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestAPI_TESTE.Models.Enums {

    public enum MsgErrorEnum  : int {

        [Description("Nenhuma pessoa foi encontrada.")]
        MSGE01 = 1,

        [Description("Desculpe, houve um conflito interno e não conseguimos processar sua solicitação.")]
        MSGE02 = 2,

        [Description("Obrigatório!")]
        MSGE03 = 3,

        [Description("Campo menor que 10 ou maior que 70.")]
        MSGE04 = 4,

        [Description("Campo inválido!")]
        MSGE05 = 5,

        [Description("Pessoa menor de idade")]
        MSGE06 = 6
    }
}
