using ProyectoCountertext4.Models;
namespace ProyectoCountertext4.Repositories.interfaz
{
    public interface ITokens
    {
        Task<List<Tokens>> GetTokens();
        Task<bool> PostTokens(Tokens tokens);
        Task<bool> PutTokens(Tokens tokens);
        Task<bool> DeleteTokens(Tokens tokens);
    }
}
