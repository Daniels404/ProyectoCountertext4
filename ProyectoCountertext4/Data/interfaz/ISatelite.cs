using ProyectoCountertext4.Models;

namespace ProyectoCountertext4.Data.interfaz
{
    public interface ISatelite
    {

        Task<List<Satelite>> GetSatelites();
        Task<bool> PostSatelite(Satelite satelite);
        Task<bool> PutSatelite(Satelite satelite);
        Task<bool> DeleteSatelite(Satelite satelite);
        Task<bool> DeleteSatelite(int id);
    }

}
