using ProyectoCountertext4.Models;

using Microsoft.EntityFrameworkCore;
using ProyectoCountertext4.Data.interfaz;
using ProyectoCountertext4.Data;

namespace ProyectoCountertext4.Data.repositories
{
    public class RepositorioSatelite : ISatelite
    {
        private readonly CounterTexDBContext context;
        public RepositorioSatelite(CounterTexDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Satelite>> Getsatelites()
        {
            var data = await context.Satelites.ToListAsync();
            return data;
        }
        public async Task<bool> PostSatelite(Satelite satelite)
        {
            await context.Satelites.AddAsync(satelite);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutSatelite(Satelite satelite)
        {
            context.Satelites.Update(satelite);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteSatelite(Satelite satelite)
        {
            context.Satelites.Remove(satelite);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<List<Satelite>> GetSatelites()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSatelite(int id)
        {
            throw new NotImplementedException();
        }
    }
}
