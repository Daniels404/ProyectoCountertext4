using System.Security.Claims;

namespace ProyectoCountertext4.Models
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }

        // Relaciones
        public ICollection<Satelite> Satelites { get; set; }
        public string ConfirmarClave { get; internal set; }
        public object Contraseña { get; internal set; }
        public ClaimsIdentity? TipoUsuario { get; internal set; }
    }
}
