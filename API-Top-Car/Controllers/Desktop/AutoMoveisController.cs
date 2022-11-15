using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Top_Car.Controllers.Desktop
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoMoveisController : ControllerBase
    {
        private readonly IAutomoveisRepository _automoveisRepository;
        public AutoMoveisController(IAutomoveisRepository automoveisRepository)
        {
            _automoveisRepository = automoveisRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AutomoveisModel>>> BuscarTodosAutomoveis()
        {
            List<AutomoveisModel> automoveis = await _automoveisRepository.BuscarTodosAutomoveis();
            return Ok(automoveis);
        }

        [HttpGet("{id}")]//Buscar Automovel Por Id
        public async Task<ActionResult<AutomoveisModel>> BuscarAutomoveisPorId(int id)
        {
            AutomoveisModel automovel = await _automoveisRepository.BuscarAutomoveisPorId(id);
            return Ok(automovel);
        }

        [HttpPost]//Adicionar
        public async Task<ActionResult<AutomoveisModel>> AdicionarAutoMoveis([FromBody] AutomoveisModel automoveisModel)
        {
            AutomoveisModel automovel = await _automoveisRepository.AdicionarAutoMoveis(automoveisModel);
            return Ok(automovel);
        }

        [HttpPut]//Aualizar
        public async Task<ActionResult<AutomoveisModel>> AtualizarAutoMoveis([FromBody] AutomoveisModel automoveis, int idAutomovel)
        {
            automoveis.IdVeiculo = idAutomovel;
            AutomoveisModel autoMovel = await _automoveisRepository.AtualizarAutoMoveis(automoveis, idAutomovel);
            return Ok(autoMovel);

        }

        [HttpDelete("{id}")]// Deletar Por Id
        public async Task<ActionResult<AutomoveisModel>> ApagarAutoMoveis(int id)
        {
            bool apagado = await _automoveisRepository.ApagarAutoMoveis(id);
            return Ok(apagado);
        }
    }
}
