
using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IAutomoveisRepository
    {
        Task<List<AutomoveisModel>> BuscarTodosAutomoveis();
        Task<AutomoveisModel> BuscarAutomoveisPorId(int idVeiculo);
        Task<AutomoveisModel> AdicionarAutoMoveis(AutomoveisModel automoveis);
        Task<AutomoveisModel> AtualizarAutoMoveis(AutomoveisModel automoveis, int idVeiculo);
        Task<bool> ApagarAutoMoveis(int idVeiculo); 
    }
}
