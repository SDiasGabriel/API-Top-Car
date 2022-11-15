using System.ComponentModel;

namespace API_Top_Car.Enums
{
    public enum StatusSeguros
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Inativo")]
        Inativo = 2,
        [Description("Pendente")]
        Pendente = 3
    }
}
