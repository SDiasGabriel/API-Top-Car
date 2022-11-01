using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly SistemasSegurosDBContext _dbContext;
        public CadastroRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContext = sistemasSegurosDBContext;
        }
        public Task<List<CadastrosModel>> AdicionarCadastros(CadastrosModel cadastros)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Apagar(int idCadastros)
        {
            throw new NotImplementedException();
        }

        public Task<List<CadastrosModel>> AtualizarCadastros(CadastrosModel cadastros, int idCadastros)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CadastrosModel>> BuscarCadastroPorId(int idCadastros)
        {
            return await _dbContext.Cadastros.FirstOrDefaultAsync(x => x.IdCadastro == idCadastros);
        }

        public Task<List<CadastrosModel>> BuscarTodosCadastros()
        {
            throw new NotImplementedException();
        }
    }
}
