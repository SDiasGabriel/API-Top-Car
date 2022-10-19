using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface IApolicesRepository
    {
        Task<List<ApoliceModel>> BuscarTodasApolice();
        Task<ApoliceModel> BuscarPorId(int id);
        Task<ApoliceModel> Adicionar(ApoliceModel apolice);
        Task<ApoliceModel> Atualizar(ApoliceModel apolice, int id);
        Task<bool> Apagar(int id);
    }
}
