using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class AutomoveisRepository : IAutomoveisRepository
    {
        private readonly SistemasSegurosDBContext _dbContextAutoMoveis;
        public AutomoveisRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContextAutoMoveis = sistemasSegurosDBContext;
        }

        public async Task<AutomoveisModel> BuscarAutomoveisPorId(int idVeiculo)
        {
            return await _dbContextAutoMoveis.Automoveis.FirstOrDefaultAsync(x => x.IdVeiculo == idVeiculo);
        }

        public async Task<List<AutomoveisModel>> BuscarTodosAutomoveis()
        {
            return await _dbContextAutoMoveis.Automoveis.ToListAsync();
        }
        public async Task<AutomoveisModel> AdicionarAutoMoveis(AutomoveisModel automoveis)
        {

            await _dbContextAutoMoveis.Automoveis.AddAsync(automoveis);
            await _dbContextAutoMoveis.SaveChangesAsync();

            return automoveis;
        }
        public async Task<AutomoveisModel> AtualizarAutoMoveis(AutomoveisModel automoveis, int idVeiculo)
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

            _dbContextAutoMoveis.Automoveis.Update(automoveisPorId);
            await _dbContextAutoMoveis.SaveChangesAsync();

            return automoveisPorId;
        }

        public async Task<bool> ApagarAutoMoveis( int idVeiculo)
        {
            AutomoveisModel automoveisPorId = await BuscarAutomoveisPorId(idVeiculo);

            if(automoveisPorId == null)
            {
                throw new Exception($"Automovel para o ID: {idVeiculo} não foi encontrado.");
            }

            _dbContextAutoMoveis.Automoveis.Remove(automoveisPorId);
            await _dbContextAutoMoveis.SaveChangesAsync();

            return true;
        }
    }
}
