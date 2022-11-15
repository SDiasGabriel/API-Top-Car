using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Top_Car.Controllers.Desktop
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguroController : ControllerBase
    {
        private readonly ISegurosRepository _segurosRepository;

        public SeguroController(ISegurosRepository segurosRepository)
        {
            _segurosRepository = segurosRepository;
        }

        [HttpGet]//Pesquisar Por Id
        public async Task<ActionResult<List<SegurosModel>>> BuscarTodosSeguros()
        {
            List<SegurosModel> seguros = await _segurosRepository.BuscarTodosSeguros();
            return Ok(seguros);
        }

        [HttpGet("{id}")]//Buscar Por Id
        public async Task<ActionResult<SegurosModel>> BuscarSegurosPorCodigo(int id)
        {
            SegurosModel seguros = await _segurosRepository.BuscarSegurosPorCodigo(id);
            return Ok(seguros);
        }

        [HttpPost]//Adicionar
        public async Task<ActionResult<SegurosModel>> AdicionarSeguros([FromBody] SegurosModel segurosModel)
        {
            SegurosModel seguros = await _segurosRepository.AdicionarSeguros(segurosModel);
            return Ok(seguros);
        }

        [HttpPut]//Atualizar
        public async Task<ActionResult<SegurosModel>> AtualizarSeguros([FromBody] SegurosModel segurosModel, int id)
        {
            segurosModel.CodigoID = id;
            SegurosModel seguros = await _segurosRepository.AtualizarSeguros(segurosModel, id);
            return Ok(seguros);
        }

        [HttpDelete("id")]//Deletar por Id
        public async Task<ActionResult<SegurosModel>> ApagarSeguro(int id)
        {
            bool apagado = await _segurosRepository.ApagarSeguro(id);
            return Ok(apagado);
        }

    }
}
