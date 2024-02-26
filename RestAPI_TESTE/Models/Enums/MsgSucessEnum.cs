using System.ComponentModel;

namespace RestAPI_TESTE.Models.Enums {
    public enum MsgSucessEnum : int {
        [Description("Pessoa registrada com sucesso!")]
        MSGS01 = 1,
        [Description("Pessoa editada com sucesso!")]
        MSGS02 = 2,
        [Description("Pessoa deletada com sucesso!")]
        MSGS03 = 3
    }
}
