using Microsoft.AspNetCore.Mvc;
using ProyectoCountertext4.Models;
using ProyectoCountertext4.Data.interfaz;

namespace  ProyectoCountertext4.Controllers

{
    public class Provedorcontroller : Controller
    {
       
            private readonly IProvedor _provedor;

            public Provedorcontroller(IProvedor provedor)
            {
                _provedor = provedor;
            }

            [HttpGet("GetProveedor")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status401Unauthorized)]
            public async Task<IActionResult> GetProveedor()
            {
                var response = await _provedor.GetProveedor();
                return Ok(response);
            }

            [HttpPost("PostProveedor")]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public async Task<IActionResult> PostProveedor([FromBody] Proveedor provedor)
            {
                try
                {
                    var response = await _provedor.PostProveedor(provedor);
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



        [HttpDelete("DeleteProveedor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            try
            {
                var response = await _provedor.DeleteProveedor(id);
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


        [HttpPut("PutProveedor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProveedor([FromBody] Proveedor provedor)
        {
            try
            {
                var response = await _provedor.PutProveedor(provedor);
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






