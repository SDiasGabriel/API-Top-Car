using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface ICadastroRepository
    {
        Task<List<CadastrosModel>> BuscarTodosCadastros();
        Task<List<CadastrosModel>> BuscarCadastroPorId(int idCadastros);
        Task<List<CadastrosModel>> AdicionarCadastros(CadastrosModel cadastros);
        Task<List<CadastrosModel>> AtualizarCadastros(CadastrosModel cadastros, int idCadastros);
        Task<bool> Apagar(int idCadastros);
    }
}
