using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProyectoCountertext4.Data;

using ProyectoCountertext4.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCountertext4.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccesoController : Controller
    {
        private readonly CounterTexDBContext _counterTexDBContext;
        public AccesoController(CounterTexDBContext counterTexDBContext)
        {
            _counterTexDBContext = counterTexDBContext;
        }

        [HttpGet]
        public IActionResult Registrarse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuarios modelo)
        {
            if (modelo.Clave != modelo.ConfirmarClave)
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden XD";
                return View();
            }

            Usuarios usuario = new Usuarios()
            {
                NombreUsuario = modelo.NombreUsuario,
                Correo = modelo.Correo,
                Clave = modelo.Clave
            };

            await _counterTexDBContext.Usuarios.AddAsync(usuario);
            await _counterTexDBContext.SaveChangesAsync();

            if (usuario.IdUsuario != 0) return RedirectToAction("Login", "Acceso");

            ViewData["Mensaje"] = "No se pudo crear el usuario, error fatal";
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated) return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Usuarios modelo)
        {
            Usuarios? usuario_encontrado = await _counterTexDBContext.Usuarios
                                          .Where(u =>
                                            u.Correo == modelo.Correo &&
                                            u.Clave == modelo.Clave
                                          ).FirstOrDefaultAsync();

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encotraron coincidencias,XD";
                return View();
            }
            
            List<Claim> claims = new List<Claim>() 
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties() 
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );
            return RedirectToAction("Index", "Home");
        }
    }
}
