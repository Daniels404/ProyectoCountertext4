using Microsoft.EntityFrameworkCore;
using ProyectoCountertext4.Data;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Data.interfaz;

namespace ProyectoCountertext4.Data.repositories
{
    public class RepositorioRegistro : IRegistro
    {
        private readonly CounterTexDBContext context;
        public RepositorioRegistro(CounterTexDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Registro>> GetRegistro()
        {
            var data = await context.Registros.ToListAsync();
            return data;
        }
        public async Task<bool> PostRegistro(Registro registro)
        {
            await context.Registros.AddAsync(registro);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutRegistro(Registro registro)
        {
            context.Registros.Update(registro);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteRegistro(Registro registro)
        {
            context.Registros.Remove(registro);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteRegistro(Satelite satelite)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteRegistro(int id)
        {
            throw new NotImplementedException();
        }
    }
}
