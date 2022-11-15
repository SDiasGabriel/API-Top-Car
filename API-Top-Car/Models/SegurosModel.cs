using API_Top_Car.Enums;

namespace API_Top_Car.Models
{
    public class SegurosModel
    {
        public int CodigoID { get; set; }
        public char TipoSeguro { get; set; }
        public int Vin { get; set; }
        public StatusSeguros statusSeguro { get; set; }
    }
}
