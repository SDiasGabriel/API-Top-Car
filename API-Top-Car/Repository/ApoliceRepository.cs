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

        public async Task<ApoliceModel> BuscarPorId(int id)
        {
            return await _dbContex.Apolices.FirstOrDefaultAsync(x => x.IdApolice == id);
        }

        public async Task<List<ApoliceModel>> BuscarTodasApolice()
        {
            return await _dbContex.Apolices.ToListAsync();
        }
        public async Task<ApoliceModel> Adicionar(ApoliceModel apolice)
        {
            await _dbContex.Apolices.AddAsync(apolice);
            await _dbContex.SaveChangesAsync();
            return apolice;
        }
        public async Task<ApoliceModel> Atualizar(ApoliceModel apolice, int id)
        {
            ApoliceModel apolicePorId = await BuscarPorId(id);

            if(apolicePorId == null)
            {
                throw new Exception($"Usuario para ID: {id} Não foi encontrado no Banco de Dados");
            }
            apolicePorId.DescricaoContrato = apolice.DescricaoContrato;
            apolicePorId.CPFCliente = apolice.CPFCliente;

            _dbContex.Apolices.Update(apolicePorId);
            await _dbContex.SaveChangesAsync();

            return apolicePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ApoliceModel apolicePorId = await BuscarPorId(id);

            if (apolicePorId == null)
            {
                throw new Exception($"Usuario para ID: {id} Não foi encontrado no Banco de Dados");
            }

            _dbContex.Apolices.Remove(apolicePorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }

        

    }
}
