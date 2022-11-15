using API_Top_Car.Data;
using API_Top_Car.Models;
using API_Top_Car.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_Top_Car.Repository
{
    public class ApoliceRepository : IApolicesRepository
    {
        private readonly SistemasSegurosDBContext _dbContex;
        public ApoliceRepository(SistemasSegurosDBContext sistemasSegurosDBContext)
        {
            _dbContex = sistemasSegurosDBContext;
        }

        public async Task<ApoliceModel> BuscarApolicePorId(int idApolice)
        {
            return await _dbContex.Apolices.FirstOrDefaultAsync(x => x.IdApolice == idApolice);
        }

        public async Task<List<ApoliceModel>> BuscarTodasApolice()
        {
            return await _dbContex.Apolices.ToListAsync();
        }
        public async Task<ApoliceModel> AdicionarApolice(ApoliceModel apolice)
        {
            await _dbContex.Apolices.AddAsync(apolice);
            await _dbContex.SaveChangesAsync();
            return apolice;
        }
        public async Task<ApoliceModel> AtualizarApolice(ApoliceModel apolice, int idApolice)
        {
            ApoliceModel apolicePorId = await BuscarApolicePorId(idApolice);

            if(apolicePorId == null)
            {
                throw new Exception($"Apolice ID: {idApolice} Não foi encontrado no Banco de Dados");
            }
            apolicePorId.DescricaoContrato = apolice.DescricaoContrato;
            apolicePorId.CPFCliente = apolice.CPFCliente;

            _dbContex.Apolices.Update(apolicePorId);
            await _dbContex.SaveChangesAsync();

            return apolicePorId;
        }

        public async Task<bool> ApagarApolice(int idApolice)
        {
            ApoliceModel apolicePorId = await BuscarApolicePorId(idApolice);

            if (apolicePorId == null)
            {
                throw new Exception($"Apolice ID: {idApolice} Não foi encontrado no Banco de Dados");
            }

            _dbContex.Apolices.Remove(apolicePorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }

        

    }
}
