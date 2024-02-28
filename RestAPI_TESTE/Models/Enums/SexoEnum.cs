using System.ComponentModel;

namespace RestAPI_TESTE.Models.Enums
{
    public enum SexoEnum : int
    {
        [Description("Mascúlino")]
        Masc = 1,
        [Description("Feminino")]
        Fem = 2
    }
}