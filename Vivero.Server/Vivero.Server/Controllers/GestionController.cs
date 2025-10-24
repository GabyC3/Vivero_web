using Microsoft.AspNetCore.Mvc;
using Vivero.BD.Datos;
using Vivero.BD.Datos.Entity;
using Vivero.Repositorio;
using Vivero.Shared.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vivero.Server.Controllers
{
    [ApiController]
    [Route("api/gestion")]
    public class GestionController : ControllerBase
    {
        private readonly IRepositorio<GestionProducto> repositorio;


        public GestionController(IRepositorio<GestionProducto> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaGestionDTO>>> listaProductos()
        {
            try
            {
                var GestionProd = await repositorio.Select();
                if (GestionProd == null)
                {
                    return NotFound("No se encontraron los productos");
                }

                if (GestionProd.Count == 0)
                {
                    return Ok("No existen productos");
                }
                return Ok(GestionProd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ListaGestionDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}");
            }

            return Ok(entidad);
        }


    }



}

