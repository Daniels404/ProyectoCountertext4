using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoCountertext4.Models
{
    public class PerfilEmpleado
    {
        public int IdEmpleado { get; set; }
        public int ProduccionDiaria { get; set; }
        public string TipoPrenda { get; set; }
        public string TipoOperacion { get; set; }
        public int CantidadOperacion { get; set; }
        public decimal ValorOperacion { get; set; }
        public string ConsultarInformacion { get; set; }
        public DateTime ControlHorarios { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int MetaPorCorte { get; set; }
        public string BotonAyuda { get; set; }
        public string Estadisticas { get; set; }
        public string Observaciones { get; set; }

        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
