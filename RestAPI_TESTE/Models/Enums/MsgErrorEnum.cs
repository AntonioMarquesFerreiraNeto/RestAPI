using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RestAPI_TESTE.Models.Enums {
    public enum MsgErrorEnum  : int {
        [Description("Nenhuma pessoa foi encontrada!")]
        MSGE01 = 0,

        [Description("Desculpe, houve um conflito interno e não conseguimos processar sua solicitação!")]
        MSGE02 = 1
    }
}
