using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using ProyectoCountertext4.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ProyectoCountertext4.Data;
using ProyectoCountertext4.Data.interfaz;


namespace ProyectoCountertext4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly CounterTexDBContext _context;

        public AuthController(IConfiguration configuration, CounterTexDBContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("Usuarios")]
        public IActionResult Usuarios([FromBody] Usuarios usuarios)
        {
            if (usuarios == null || string.IsNullOrEmpty(usuarios.Correo) || string.IsNullOrEmpty((string?)usuarios.Contraseña))
            {
                return BadRequest("Invalid client request");
            }

            // Verificar que el usuario existe en la base de datos
            var user = _context.Usuarios.FirstOrDefault(u => u.Correo == usuarios.Correo);

            if (user == null || user.Contraseña != usuarios.Contraseña) // Verifica si el usuario y contraseña coinciden
            {
                return Unauthorized("Invalid credentials");
            }

            // Generar el token JWT
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Correo), // Usamos el correo del usuario
                   
                },
                expires: DateTime.Now.AddMonths(3), // Establece la expiración del token
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
    }
}
