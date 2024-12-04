using Microsoft.AspNetCore.Mvc;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Data.interfaz;

namespace ProyectoCountertext4.Controllers
{
    public class Empleadocontroller : Controller
    {
        
            private readonly IEmpleado _empleado;

            public Empleadocontroller(IEmpleado empleado)
            {
                _empleado = empleado;
            }

            [HttpGet("GetAdministrador")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            public async Task<IActionResult> GetEmpleado()
            {
                var response = await _empleado.GetEmpleado();
                return Ok(response);
            }

            [HttpPost("PostEmpleado")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> PostEmpleado([FromBody] PerfilEmpleado empleado)
            {
                try
                {
                    var response = await _empleado.PostEmpleado(empleado);
                    if (response == true)
                        return Ok("ingreso correctamente");
                    else
                        return BadRequest(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }



        [HttpDelete("DeleteEmpleado/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            try
            {
                var response = await _empleado.DeleteEmpleado(id);
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

        [HttpPut("PutEmpleado")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutEmpleado([FromBody] PerfilEmpleado empleado)
        {
            try
            {
                var response = await _empleado.PutEmpleado(empleado);
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
