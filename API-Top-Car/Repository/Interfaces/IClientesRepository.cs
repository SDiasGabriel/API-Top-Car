using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IClientesRepository
    { 
        Task<List<ClientesModel>> BuscarTodosClientes();
        Task<ClientesModel> BuscarClientesPorId(int IdClientes);
        Task<ClientesModel> AdicionarClientes(ClientesModel clientes);
        Task<ClientesModel> AtualizarClientes(ClientesModel clientes, int IdClientes);
        Task<bool> ApagarClientes(int IdClientes);
    }
}
