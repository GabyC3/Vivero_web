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
        public async Task<ActionResult<List<ListaGestionDTO>>> listaGestion()
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

          try {

            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}");
            }

            return Ok(entidad);

          } catch (Exception e) {
                return BadRequest($"Error al mostrar la lista: {e.Message}");
          }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearGestionDTO producto)
        {
            try
            {
                GestionProducto entidad = new GestionProducto
                {
                    Id = producto.Id,
                    AdministradorId = producto.AdministradorId,
                    ProductoId = producto.ProductoId,
                    Accion = producto.Accion,
                    Fecha = producto.Fecha

                };


                await repositorio.Insert(entidad);

                return Ok(producto.Id);
            }
            catch (Exception e)
            {
                return BadRequest($"Error al registrar el proceso: {e.Message}");
            }

        }
    }



}

