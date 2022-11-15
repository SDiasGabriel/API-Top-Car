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
        public async Task<CadastrosModel> AdicionarCadastros(CadastrosModel cadastros)
        {
            await _dbContext.Cadastros.AddAsync(cadastros);
            await _dbContext.SaveChangesAsync();

            return cadastros;
        }

        public async Task<bool> ApagarCadastro(int idCadastros)
        {
            CadastrosModel cadastrosPorId = await BuscarCadastroPorId(idCadastros);

            if (cadastrosPorId == null)
            {
                throw new Exception($" O Cadastro:{idCadastros} não foi encontrado.");
            }

            _dbContext.Cadastros.Remove(cadastrosPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CadastrosModel> AtualizarCadastros(CadastrosModel cadastros, int idCadastros)
        {
            CadastrosModel cadastrosPorId = await BuscarCadastroPorId(idCadastros);

            if(cadastrosPorId == null)
            {
                throw new Exception($"Atualização de Cadastro:{idCadastros} não concluida.");
            }
            cadastrosPorId.CPF = cadastros.CPF;
            cadastrosPorId.CNPJ = cadastros.CNPJ;

            _dbContext.Cadastros.Update(cadastrosPorId);
            await _dbContext.SaveChangesAsync();

            return cadastrosPorId;
        }

        public async Task<CadastrosModel> BuscarCadastroPorId(int idCadastros)
        {
            return await _dbContext.Cadastros.FirstOrDefaultAsync(x => x.IdCadastro == idCadastros);
        }

        public async Task<List<CadastrosModel>> BuscarTodosCadastros()
        {
            return await _dbContext.Cadastros.ToListAsync();
        }
    }
}
