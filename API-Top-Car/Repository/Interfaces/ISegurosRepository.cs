using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface ISegurosRepository
    {
        Task<List<SegurosModel>> BuscarTodosSeguros();
        Task<SegurosModel> BuscarSegurosPorCodigo(int codigoID);
        Task<SegurosModel> AdicionarSeguros(SegurosModel seguros);
        Task<SegurosModel> AtualizarSeguros(SegurosModel seguros, int codigoID);
        Task<bool> ApagarSeguro(int codigoID);
    }
}
