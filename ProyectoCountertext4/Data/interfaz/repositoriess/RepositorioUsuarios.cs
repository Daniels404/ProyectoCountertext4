using Microsoft.EntityFrameworkCore;
using ProyectoCountertext4.Data;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Data.interfaz;

namespace ProyectoCountertext4.Data.repositoriess
{
    public class RepositorioUsuarios : IUsuarios
    {
        private readonly CounterTexDBContext context;
        public RepositorioUsuarios(CounterTexDBContext context)
        {
            this.context = context;
        }
        public async Task<List<Usuarios>> GetUsuarios()
        {
            var data = await context.Usuarios.ToListAsync();
            return data;
        }
        public async Task<bool> PostUsuarios(Usuarios usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> PutUsuarios(Usuarios usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUsuarios(Usuarios usuario)
        {
            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteUsuarios(int id)
        {
            throw new NotImplementedException();
        }
    }
}
