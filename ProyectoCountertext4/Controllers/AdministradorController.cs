using Microsoft.AspNetCore.Mvc;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Data.interfaz;

namespace ProyectoCountertext4.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly IAdministrador _administrador;

        public AdministradorController(IAdministrador administrador)
        {
            _administrador = administrador;
        }

        [HttpGet("GetAdministrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAdministrador()
        {
            var response = await _administrador.GetAdministrador();
            return Ok(response);
        }

        [HttpPost("PostAdministrador")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAdministrador([FromBody] PerfilAdministrador administrador)
        {
            try
            {
                var response = await _administrador.PostAdministrador(administrador);
                if (response == true)
                    return Ok("perfil ingresado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteAdministrador/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAdministrador(int id)
        {
            try
            {
                var response = await _administrador.DeleteAdministrador(id);
                if (response == true)
                    return Ok("Perfil eliminado correctamente");
                else
                    return BadRequest("Error al eliminar el perfil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutAdministrador")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutAdministrador([FromBody] PerfilAdministrador administrador)
        {
            try
            {
                var response = await _administrador.PutAdministrador(administrador);
                if (response == true)
                    return Ok("Perfil actualizado correctamente");
                else
                    return BadRequest("Error al actualizar el perfil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}




