using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class ClientesRepository : IClientesRepository
    {
        private readonly SistemasSegurosDBContext _dbContext;
        public ClientesRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContext = sistemasSegurosDBContext;
        }

        public async Task<ClientesModel> AdicionarClientes(ClientesModel clientes)
        {
            await _dbContext.Clientes.AddAsync(clientes);
            await _dbContext.SaveChangesAsync();
            return clientes;
        }

        public async Task<bool> ApagarClientes(int IdClientes)
        {
            ClientesModel clientePorID = await BuscarClientesPorId(IdClientes);

            if (clientePorID == null)
            {
                throw new Exception($"ID: {IdClientes} cliente Não foi encontrado no Banco de Dados");
            }

            _dbContext.Clientes.Remove(clientePorID);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ClientesModel> AtualizarClientes(ClientesModel clientes, int IdClientes)
        {
            ClientesModel clientePorID = await BuscarClientesPorId(IdClientes);

            if (clientePorID == null)
            {
                throw new Exception($"ID: {IdClientes} cliente Não foi encontrado no Banco de Dados");
            }
            clientePorID.Nome = clientes.Nome;
            clientePorID.CPF = clientes.CPF;
            clientePorID.NumeroCasa = clientes.NumeroCasa;
            clientePorID.Idade = clientes.Idade;
            clientePorID.Rua = clientes.Rua;
            clientePorID.Bairro = clientes.Bairro;

            _dbContext.Clientes.Update(clientePorID);
            await _dbContext.SaveChangesAsync();

            return clientePorID;
        }

        public async Task<ClientesModel> BuscarClientesPorId(int IdClientes)
        {
            return await _dbContext.Clientes.FirstOrDefaultAsync(x => x.IdClientes == IdClientes);
        }

        public async Task<List<ClientesModel>> BuscarTodosClientes()
        {
            return await _dbContext.Clientes.ToListAsync();
        }
    }
}
