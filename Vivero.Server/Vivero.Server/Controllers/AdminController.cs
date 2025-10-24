using Microsoft.AspNetCore.Mvc;
using Vivero.BD.Datos.Entity;
using Vivero.Repositorio;
using Vivero.Shared.DTO;

namespace Vivero.Server.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class AdminController : ControllerBase
    {
        private readonly IRepositorio<Administrador> repositorio;


        public AdminController(IRepositorio<Administrador> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ListaAdminDTO>>> listaAdmins()
        {
            try
            {
                var admin = await repositorio.Select();
                if (admin == null)
                {
                    return NotFound("No se encontraron administradores");
                }

                if (admin.Count == 0)
                {
                    return Ok("No existen administradores");
                }
                return Ok(admin);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ListaAdminDTO>> GetAdminById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el admnistrador con id: {id}");
            }

            return Ok(entidad);
        }


        [HttpPost]
        public async Task<ActionResult> Post(CrearAdminDTO admin)
        {
            try
            {
                Administrador entidad = new Administrador
                {
                    Id = 0,  //producto.Id,
                    Nombre = admin.Nombre!,
                    Email = admin.Email!,
                    Telefono = admin.Telefono,
                    Contraseña = admin.Contraseña!
                };


                await repositorio.Insert(entidad);

                return Ok("El administrador se ha registrado exitosamente");
            }
            catch (Exception e)
            {
                return BadRequest($"Error al registrarse: {e.Message}");
            }

        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Administrador usuario)
        {
            try
            {
                var entidad = await repositorio.Update(id, usuario);
                if (!entidad)
                {
                    return Ok($"No se pudo realizar la operación: el id no coincide o no existe.");
                }
                return Ok($"El adminstrador con el id: {id} ha sido actualizado");
            }
            catch (Exception)
            {
                return BadRequest("No se pudo realizar la operación.");
            }
        }

    }

}

