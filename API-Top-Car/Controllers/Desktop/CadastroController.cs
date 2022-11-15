using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Top_Car.Controllers.Desktop
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroRepository _cadastroRepository;
        public CadastroController(ICadastroRepository cadastroRepository)
        {
            _cadastroRepository = cadastroRepository;
        }

        [HttpGet]//Pesquisar Por Lista
        public async Task<ActionResult<List<CadastrosModel>>> BuscarTodosCadastros()
        {
            List<CadastrosModel> cadastros = await _cadastroRepository.BuscarTodosCadastros();
            return Ok(cadastros);
        }

        [HttpGet("{id}")]// Buscar Cadastro Por Id
        public async Task<ActionResult<CadastrosModel>> BuscarCadastroPorId(int id)
        {
            CadastrosModel cadastro = await _cadastroRepository.BuscarCadastroPorId(id);
            return Ok(cadastro);
        }

        [HttpPost]// Adicionar
        public async Task<ActionResult<CadastrosModel>> AdicionarCadastros([FromBody] CadastrosModel cadastroModel)
        {
            CadastrosModel cadastro = await _cadastroRepository.AdicionarCadastros(cadastroModel);
            return Ok(cadastro);
        }

        [HttpPut]//Atualizar
        public async Task<ActionResult<CadastrosModel>> AtualizarCadastros([FromBody] CadastrosModel cadastro, int id)
        {
            cadastro.IdCadastro = id;
            CadastrosModel cadastrosModel = await _cadastroRepository.AtualizarCadastros(cadastro, id);
            return Ok(cadastrosModel);
        }

        [HttpDelete]// Deletar Por Id
        public async Task<ActionResult<CadastrosModel>> ApagarCadastro(int id)
        {
            bool apagado = await _cadastroRepository.ApagarCadastro(id);
            return Ok(apagado);
        }
    }
}
