using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class SegurosRepository : ISegurosRepository
    {
        private readonly SistemasSegurosDBContext _dbContextSeguros;
        public SegurosRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContextSeguros = sistemasSegurosDBContext;
        }

        public async Task<SegurosModel> AdicionarSeguros(SegurosModel seguros)
        {
            await _dbContextSeguros.Seguros.AddAsync(seguros);
            await _dbContextSeguros.SaveChangesAsync();
            return seguros;
        }

        public async Task<bool> ApagarSeguro(int codigoID)
        {
            SegurosModel segurosPorId = await BuscarSegurosPorCodigo(codigoID);

            if (segurosPorId == null)
            {
                throw new Exception($"ID: {codigoID} seguro Não foi encontrado no Banco de Dados");
            }

            _dbContextSeguros.Seguros.Remove(segurosPorId);
            await _dbContextSeguros.SaveChangesAsync();

            return true;
        }

        public async Task<SegurosModel> AtualizarSeguros(SegurosModel seguros, int codigoID)
        {
            SegurosModel segurosPorId = await BuscarSegurosPorCodigo(codigoID);

            if (segurosPorId == null)
            {
                throw new Exception($"ID: {codigoID} seguro Não foi encontrado no Banco de Dados");
            }
            segurosPorId.TipoSeguro = seguros.TipoSeguro;

            _dbContextSeguros.Seguros.Update(segurosPorId);
            await _dbContextSeguros.SaveChangesAsync();

            return segurosPorId;
        }

        public async Task<SegurosModel> BuscarSegurosPorCodigo(int codigoID)
        {
            return await _dbContextSeguros.Seguros.FirstOrDefaultAsync(x => x.CodigoID == codigoID);
        }

        public async Task<List<SegurosModel>> BuscarTodosSeguros()
        {
            return await _dbContextSeguros.Seguros.ToListAsync();
        }
    }
}
