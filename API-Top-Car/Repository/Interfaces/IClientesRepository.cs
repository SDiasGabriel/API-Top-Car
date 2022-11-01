using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IClientesRepository
    { 
        Task<List<ClientesModel>> BuscarTodosClientes();
        Task<List<ClientesModel>> BuscarClientesPorId(int IdClientes);
        Task<List<ClientesModel>> AdicionarClientes(ClientesModel clientes);
        Task<List<ClientesModel>> AtualizarClientes(ClientesModel clientes, int IdClientes);
        Task<bool> Apagar(int IdClientes);
    }
}
