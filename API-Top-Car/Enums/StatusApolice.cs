using System.ComponentModel;

namespace API_Top_Car.Enums
{
    public enum StatusApolice
    {
        [Description("Contratado")]
        Contratado = 1,
        [Description("Cancelado")]
        Cancelado = 2,
        [Description("Em Analise")]
        EmAnalise = 3
    }
}
