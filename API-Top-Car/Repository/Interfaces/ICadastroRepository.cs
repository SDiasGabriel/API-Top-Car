using API_Top_Car.Models;

namespace API_Top_Car.Repository.Interfaces
{
    public interface ICadastroRepository
    {
        Task<List<CadastrosModel>> BuscarTodosCadastros();
        Task<CadastrosModel> BuscarCadastroPorId(int idCadastros);
        Task<CadastrosModel> AdicionarCadastros(CadastrosModel cadastros);
        Task<CadastrosModel> AtualizarCadastros(CadastrosModel cadastros, int idCadastros);
        Task<bool> ApagarCadastro(int idCadastros);
    }
}
