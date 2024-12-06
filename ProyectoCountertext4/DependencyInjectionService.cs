using ProyectoCountertext4.Repositories;
using ProyectoCountertext4.Repositories.interfaz;
using Microsoft.EntityFrameworkCore;
using ProyectoCountertext4.Data;
using ProyectoCountertext4.Data.interfaz;

namespace ProyectoCountertext4;
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = "";
            connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IAdministrador, IAdministrador>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IEmpleado, IEmpleado>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProvedor, IProvedor>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IRegistro, IRegistro>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ISatelite, ISatelite>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITokens, ITokens>();
            services.AddDbContext<CounterTexDBContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUsuarios, IUsuarios>();
        return services;
        }
    }

