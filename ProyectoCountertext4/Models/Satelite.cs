using ProyectoCountertext4.Models;

namespace ProyectoCountertext4.Models
{
    public class Satelite
    {
        public int SateliteId { get; set; }
        public string Fabricante { get; set; }
        public int PagoPrendas { get; set; } 
        public int Ganancias{ get; set; }
        public string Operacion { get; set; }
        public int PagoOperacion { get; set; }
        public string TipoMaquina { get; set; }
        public int Inventariomaquinas { get; set; }
        // Relaciones
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
    }
}
