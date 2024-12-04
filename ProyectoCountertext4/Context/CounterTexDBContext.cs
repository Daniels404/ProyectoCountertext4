using Microsoft.EntityFrameworkCore;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Controllers;
using System.ComponentModel.DataAnnotations;

using Microsoft.Win32;

using System;

namespace ProyectoCountertext4.Data
{
    public class CounterTexDBContext : DbContext
    {
        public CounterTexDBContext(DbContextOptions<CounterTexDBContext> options) : base(options) { }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Satelite> Satelites { get; set; }
        public DbSet<PerfilAdministrador> PerfilAdministradores { get; set; }
        public DbSet<PerfilEmpleado> PerfilEmpleados { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuración Entidad Usuario
            modelBuilder.Entity<Usuarios>(tb =>
            {
                tb.HasKey(col => col.IdUsuario);
                tb.Property(col => col.IdUsuario).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.NombreUsuario).IsRequired().HasMaxLength(50);
                tb.Property(col => col.Correo).HasMaxLength(50);
                tb.Property(col => col.Clave).HasMaxLength(50);
                tb.HasMany(col => col.Satelites).WithOne(sat => sat.Usuario)
                  .HasForeignKey(sat => sat.IdUsuario);
            });
            modelBuilder.Entity<Usuarios>().ToTable("Usuario");

            //Configuración Entidad Satélite
            modelBuilder.Entity<Satelite>(tb =>
            {
                tb.HasKey(col => col.SateliteId);
                tb.Property(col => col.SateliteId).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Fabricante).IsRequired().HasMaxLength(100);
                tb.Property(col => col.PagoPrendas).IsRequired();
                tb.Property(col => col.Ganancias).IsRequired();
                tb.Property(col => col.Operacion).IsRequired().HasMaxLength(100);
                tb.Property(col => col.PagoOperacion).IsRequired();
                tb.Property(col => col.Inventariomaquinas).IsRequired();
                tb.Property(col => col.TipoMaquina).HasMaxLength(50);
                tb.HasOne(col => col.Usuario).WithMany(u => u.Satelites)
                  .HasForeignKey(col => col.IdUsuario);
            });
            modelBuilder.Entity<Satelite>().ToTable("Satelite");

            //Configuración Entidad PerfilAdministrador
            modelBuilder.Entity<PerfilAdministrador>(tb =>
            {
                tb.HasKey(col => col.IdAdministrador);
                tb.Property(col => col.IdAdministrador).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.NombreAdministrador).HasMaxLength(100);
                tb.Property(col => col.ProduccionDiaria).IsRequired();
                tb.Property(col => col.ProduccionMensual).IsRequired();
                tb.Property(col => col.ControlPrendas).IsRequired();
                tb.Property(col => col.Registro).HasMaxLength(100);
                tb.Property(col => col.Ganancias).IsRequired();
                tb.Property(col => col.Pagos).IsRequired();
                tb.Property(col => col.Gastos).IsRequired();
                tb.Property(col => col.MetaPorCorte).IsRequired();
                tb.Property(col => col.ConsultarInformacion).IsRequired();
                tb.Property(col => col.ControlHorarios).IsRequired();
                tb.Property(col => col.ChatInterno).HasMaxLength(200);
                tb.Property(col => col.Proveedor).HasMaxLength(100);
                tb.Property(col => col.BotonAyuda).HasMaxLength(100);
                tb.HasOne(col => col.Usuario).WithOne()
                  .HasForeignKey<PerfilAdministrador>(col => col.IdUsuario);
            });
            modelBuilder.Entity<PerfilAdministrador>().ToTable("PerfilAdministrador");

            //Configuración Entidad PerfilEmpleado
            modelBuilder.Entity<PerfilEmpleado>(tb =>
            {
                tb.HasKey(col => col.IdEmpleado);
                tb.Property(col => col.IdEmpleado).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.ProduccionDiaria).IsRequired();
                tb.Property(col => col.TipoPrenda).HasMaxLength(100);
                tb.Property(col => col.TipoOperacion).HasMaxLength(100);
                tb.Property(col => col.CantidadOperacion).IsRequired();
                tb.Property(col => col.ValorOperacion).HasColumnType("decimal(18, 2)");
                tb.Property(col => col.ConsultarInformacion).HasMaxLength(100);
                tb.Property(col => col.ControlHorarios).IsRequired();
                tb.Property(col => col.HoraEntrada).IsRequired();
                tb.Property(col => col.HoraSalida).IsRequired();
                tb.Property(col => col.MetaPorCorte).IsRequired();
                tb.Property(col => col.BotonAyuda).HasMaxLength(100);
                tb.Property(col => col.Estadisticas).HasMaxLength(200);
                tb.Property(col => col.Observaciones).HasMaxLength(500);
                tb.HasOne(col => col.Usuario).WithOne()
                  .HasForeignKey<PerfilEmpleado>(col => col.IdUsuario)
                  .OnDelete(DeleteBehavior.Cascade); // Comportamiento de eliminación en cascada
            });
            modelBuilder.Entity<PerfilEmpleado>().ToTable("PerfilEmpleado");

            //Configuración Entidad Registro
            modelBuilder.Entity<Registro>(tb =>
            {
                tb.HasKey(col => col.IdRegistro);
                tb.Property(col => col.IdRegistro).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.Nombres).IsRequired().HasMaxLength(100);
                tb.Property(col => col.Apellidos).HasMaxLength(100);
                tb.Property(col => col.Documento).IsRequired();
                tb.Property(col => col.Correo).HasMaxLength(100);
                tb.Property(col => col.Contraseña).HasMaxLength(100);
                tb.Property(col => col.ConfirmarContraseña).HasMaxLength(100);
                tb.Property(col => col.FechaRegistro).IsRequired();
            });
            modelBuilder.Entity<Registro>().ToTable("Registro");

            //Configuración Entidad Proveedor
            modelBuilder.Entity<Proveedor>(tb =>
            {
                tb.HasKey(col => col.IdProveedor);
                tb.Property(col => col.IdProveedor).UseIdentityColumn().ValueGeneratedOnAdd();
                tb.Property(col => col.NombreProveedor).IsRequired().HasMaxLength(100);
                tb.Property(col => col.PrecioPrenda).HasColumnType("decimal(18, 2)");
                tb.Property(col => col.TipoPrenda).HasMaxLength(100).IsRequired();
                tb.Property(col => col.Telefono).IsRequired();
                tb.Property(col => col.NombreProveedor).HasMaxLength(150).IsRequired();
                tb.Property(col => col.Direccion).HasMaxLength(200);
                tb.Property(col => col.Ciudad).HasMaxLength(100);
                tb.Property(col => col.Localidad).HasMaxLength(100);
                tb.Property(col => col.Barrio).HasMaxLength(100);
                tb.Property(col => col.CantidadPrendas).IsRequired();
            });
            modelBuilder.Entity<Proveedor>().ToTable("Proveedor");
        }

        internal async Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
