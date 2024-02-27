using System.ComponentModel;

namespace RestAPI_TESTE.Models.Enums
{
    public enum SexoEnum : int
    {
        [Description("Mascúlino")]
        Masc = 0,
        [Description("Feminino")]
        Fem = 1
    }
}