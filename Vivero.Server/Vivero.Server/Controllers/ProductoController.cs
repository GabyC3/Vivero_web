using Microsoft.AspNetCore.Mvc;
using Vivero.BD.Datos;
using Vivero.BD.Datos.Entity;
using Vivero.Repositorio;
using Vivero.Shared.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vivero.Server.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IRepositorio<Producto> repositorio;


        public ProductoController(IRepositorio<Producto> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaProdDTO>>> listaProductos()
        {
            try
            {
                var productos = await repositorio.Select();
                if (productos == null)
                {
                    return NotFound("No se encontraron los productos");
                }

                if (productos.Count == 0)
                {
                    return Ok("No existen productos");
                }
                return Ok(productos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ListaProdDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el producto con id: {id}");
            }

            return Ok(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CrearProductoDTO producto)
        {
            try
            {
                Producto entidad = new Producto
                {
                    Id = 0,  //producto.Id,
                    Imagen = producto.Imagen,
                    Nombre = producto.Nombre!,
                    Maceta = producto.Maceta,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Stock = producto.Stock,
                    FechaCreacion = DateTime.Now,

                };


                await repositorio.Insert(entidad);

                return Ok("El producto se ha registrado exitosamente");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al registrar el producto: {e.Message}");
            }

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Producto producto)
        {
            try
            {
                var entidad = await repositorio.Update(id, producto);
                if (!entidad)
                {
                    return Ok($"No se pudo realizar la operación: el id no coincide o no existe.");
                }
                return Ok($"El producto con el id: {id} ha sido actualizado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo realizar la operación.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> borrarProducto(int id, Producto producto)
        {
            try
            {
                producto.Activo = false;
                var entidad = await repositorio.Update(id, producto);
                if (!entidad)
                {
                    return NotFound($"No existe el producto con el id: {id}, o fue eliminado.");
                }
                return Ok($"Registro con el id: {id} fue eliminado correctamente."); ;
            }
            catch (Exception)
            {
                return BadRequest("No se pudo realizar la operación.");
            }

        }

    }



}

