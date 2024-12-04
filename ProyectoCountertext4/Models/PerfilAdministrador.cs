namespace ProyectoCountertext4.Models
{
    public class PerfilAdministrador
    {
        public int IdAdministrador { get; set; }

        public string? Nombreadministrador { get; set; }
        public object NombreAdministrador { get; internal set; }
        public int ProduccionDiaria { get; set; }
        public int ProduccionMensual { get; set; }
        public int ControlPrendas { get; set; }
        public string? Registro { get; set; }
        public int Ganancias { get; set; }
        public int Pagos { get; set; }
        public int Gastos { get; set; }
        public int MetaPorCorte { get; set; }
        public bool ConsultarInformacion { get; set; }
        public DateTime ControlHorarios { get; set; }
        public string? ChatInterno { get; set; }
        public string? Proveedor { get; set; }
        public string? BotonAyuda { get; set; }

        // Relaciones
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
