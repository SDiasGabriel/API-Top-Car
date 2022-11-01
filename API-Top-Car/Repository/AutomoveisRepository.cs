using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class AutomoveisRepository : IAutomoveisRepository
    {
        private readonly SistemasSegurosDBContext _dbContext;
        public AutomoveisRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContext = sistemasSegurosDBContext;
        }

        public async Task<List<AutomoveisModel>> BuscarAutomoveisPorId(int idVeiculo)
        {
            return await _dbContext.Automoveis.FirstOrDefaultAsync(x => x.IdVeiculo == idVeiculo);
        }

        public async Task<List<AutomoveisModel>> BuscarTodosAutomoveis()
        {
            return await _dbContext.Automoveis.ToListAsync();
        }
        public async Task<List<AutomoveisModel>> AdicionarAutoMoveis(AutomoveisModel automoveis)
        {

            await _dbContext.Automoveis.AddAsync(automoveis);
            await _dbContext.SaveChangesAsync();

            return automoveis;
        }
        public async Task<List<AutomoveisModel>> AtualizarAutoMoveis(AutomoveisModel automoveis, int idVeiculo)
        {
            AutomoveisModel automoveisPorId = await BuscarAutomoveisPorId(idVeiculo);

            if (automoveisPorId == null)
            {
                throw new Exception($"Automovel para o ID: {idVeiculo} não foi encontrado.");
            }


            automoveisPorId.CorVeiculo = automoveis.CorVeiculo;
            automoveisPorId.MarcaVeiculos = automoveis.MarcaVeiculos;
            automoveisPorId.AnoFabricacao = automoveis.AnoFabricacao;
            automoveisPorId.ModeloVeiculo = automoveis.ModeloVeiculo;
            automoveisPorId.Vin = automoveis.Vin;

            _dbContext.Automoveis.Update(automoveisPorId);
            await _dbContext.SaveChangesAsync();

            return automoveisPorId;
        }

        public async Task<bool> Apagar( int idVeiculo)
        {
            AutomoveisModel automoveisPorId = await BuscarAutomoveisPorId(idVeiculo);

            if(automoveisPorId == null)
            {
                throw new Exception($"Automovel para o ID: {idVeiculo} não foi encontrado.");
            }

            _dbContext.Automoveis.Remove(automoveisPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
