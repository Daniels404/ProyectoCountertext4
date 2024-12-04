using System.ComponentModel.DataAnnotations;

namespace ProyectoCountertext4.Models
{
    public class Registro
    {
        public int IdRegistro { get; set; }

        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Documento { get; set; } 
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
