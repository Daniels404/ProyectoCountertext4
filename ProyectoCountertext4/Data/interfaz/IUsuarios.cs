using ProyectoCountertext4.Models;

namespace ProyectoCountertext4.Data.interfaz
{
    public interface IUsuarios
    {
        Task<List<Usuarios>> GetUsuarios();
        Task<bool> PostUsuarios(Usuarios usuarios);
        Task<bool> PutUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(Usuarios usuarios);
        Task<bool> DeleteUsuarios(int id);
    }
}
