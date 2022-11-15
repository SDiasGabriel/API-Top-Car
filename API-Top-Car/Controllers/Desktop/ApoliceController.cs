using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace API_Top_Car.Controllers.Desktop
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApoliceController : ControllerBase
    {
        private readonly IApolicesRepository _apolicesRepository;

        public ApoliceController(IApolicesRepository apolicesRepository)
        {
            _apolicesRepository = apolicesRepository;
        }

        [HttpGet]//Pesaquisar por Lista
        public async Task<ActionResult<List<ApoliceModel>>> BuscarTodasApolice()
        {
            List<ApoliceModel> apolices = await _apolicesRepository.BuscarTodasApolice();
            return Ok(apolices);
        }

        [HttpGet("{id}")]//Buscar Por Id
        public async Task<ActionResult<ApoliceModel>> BuscarApolicePorId(int id)
        {
            ApoliceModel apolices = await _apolicesRepository.BuscarApolicePorId(id);
            return Ok(apolices);
        }

        [HttpPost]//Adicionar
        public async Task<ActionResult<ApoliceModel>> AdicionarApolice([FromBody] ApoliceModel apoliceModel)
        {
            ApoliceModel apolice = await _apolicesRepository.AdicionarApolice(apoliceModel);
            return Ok(apolice);
        }

        [HttpPut]//Atualizar
        public async Task<ActionResult<ApoliceModel>> AtualizarApolice([FromBody] ApoliceModel apoliceModel, int idApolice)
        {
            apoliceModel.IdApolice = idApolice;
            ApoliceModel apolice = await _apolicesRepository.AtualizarApolice(apoliceModel, idApolice);
            return Ok(apolice);
        }

        [HttpDelete("{id}")]// Deletar Por Id
        public async Task<ActionResult<ApoliceModel>> ApagarApolice(int id)
        {
            bool apagado = await _apolicesRepository.ApagarApolice(id);
            return Ok(apagado);
        }

    }
}
