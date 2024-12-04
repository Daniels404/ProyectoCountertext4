using ProyectoCountertext4.Models;


namespace ProyectoCountertext4.Data.interfaz
{
    public interface IProvedor
    {
        Task<List<Proveedor>> GetProveedor();
        Task<bool> PostProveedor(Proveedor proveedor);
        Task<bool> PutProveedor(Proveedor proveedor);
        Task<bool> DeleteProveedor(Proveedor proveedor);
        Task<bool> DeleteProveedor(int id);
    }
}
