using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IApolicesRepository
    {
        Task<List<ApoliceModel>> BuscarTodasApolice();
        Task<ApoliceModel> BuscarApolicePorId(int idApolice);
        Task<ApoliceModel> AdicionarApolice(ApoliceModel apolice);
        Task<ApoliceModel> AtualizarApolice(ApoliceModel apolice, int idApolice);
        Task<bool> ApagarApolice(int idApolice);
    }
}
