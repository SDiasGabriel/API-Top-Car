using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Top_Car.Controllers.Desktop
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClientesRepository _clientesRepository;

        public ClienteController(IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }

        [HttpGet]//Pesquisar Lista
        public async Task<ActionResult<List<ClientesModel>>> BuscarTodosClientes()
        {
            List<ClientesModel> clientes = await _clientesRepository.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("{id}")]// Buscar Por Id
        public async Task<ActionResult<ClientesModel>> BuscarClientesPorId(int id)
        {
            ClientesModel clientesModel = await _clientesRepository.BuscarClientesPorId(id);
            return Ok(clientesModel);
        }

        [HttpPost]//Adicionar
        public async Task<ActionResult<ClientesModel>> AdicionarClientes([FromBody] ClientesModel clientes)
        {
            ClientesModel clientesModel = await _clientesRepository.AdicionarClientes(clientes);
            return Ok(clientesModel);
        }

        [HttpPut]//Atualizar
        public async Task<ActionResult<ClientesModel>> AtualizarClientes([FromBody] ClientesModel clientesModel, int id)
        {
            clientesModel.IdClientes = id;
            ClientesModel cliente = await _clientesRepository.AtualizarClientes(clientesModel, id);
            return Ok(cliente);
        }

        [HttpDelete("{id}")]//Deletar por Id
        public async Task<ActionResult<ClientesModel>> ApagarClientes(int id)
        {
            bool apagado = await _clientesRepository.ApagarClientes(id);
            return Ok(apagado);
        }
    }
}
