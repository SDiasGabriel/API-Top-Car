
using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IAutomoveisRepository
    {
        Task<List<AutomoveisModel>> BuscarTodosAutomoveis();
        Task<List<AutomoveisModel>> BuscarAutomoveisPorId(int idVeiculo);
        Task<List<AutomoveisModel>> AdicionarAutoMoveis(AutomoveisModel automoveis);
        Task<List<AutomoveisModel>> AtualizarAutoMoveis(AutomoveisModel automoveis, int idVeiculo);
        Task<bool> Apagar(int idVeiculo); 
    }
}
