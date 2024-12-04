using ProyectoCountertext4.Models;

namespace ProyectoCountertext4.Data.interfaz
{
    public interface IRegistro
    {
        Task<List<Registro>> GetRegistro();
        Task<bool> PostRegistro(Registro registro);
        Task<bool> PutRegistro(Registro registro);
        Task<bool> DeleteRegistro(Satelite satelite);
        Task<bool> DeleteRegistro(int id);
    }
}
