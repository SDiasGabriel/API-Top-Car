using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface ISegurosRepository
    {
        Task<List<SegurosModel>> BuscarTodosSeguros();
        Task<List<SegurosModel>> BuscarSegurosPorCodigo(int codigo);
        Task<List<SegurosModel>> AdicionarSeguros(SegurosModel clientes);
        Task<List<SegurosModel>> AtualizarSeguros(SegurosModel clientes, int codigo);
        Task<bool> Apagar(int codigo);
    }
}
