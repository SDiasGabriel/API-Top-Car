using API_Top_Car.Enums;

namespace API_Top_Car.Models
{
    public class ApoliceModel
    {
        public int IdApolice { get; set; }
        public int CPFCliente { get; set; }
        public string? DescricaoContrato { get; set; }
        public StatusApolice Status { get; set; }
    }
}
