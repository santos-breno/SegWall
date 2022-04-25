using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SegWallApi.DAL;
using SegWallApi.Models;
using System;

namespace SegWallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
        }

        [HttpGet("listar")]
        public IActionResult Get()
        {
            return Ok(new UsuarioDAL().Listar());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                UsuarioDAL dal = new UsuarioDAL();
                Usuario usuario = dal.Consultar(id);
                return Ok(usuario);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario Usuario)
        {
            try
            {
                UsuarioDAL dal = new UsuarioDAL();
                dal.Inserir(Usuario);

                string location =
                    Url.Link("DefaultApi", new { controller = "usuario", id = Usuario.IdUsuario });

                return Created(new Uri(location), Usuario);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                UsuarioDAL dal = new UsuarioDAL();
                dal.Excluir(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Usuario Usuario)
        {
            try
            {
                UsuarioDAL dal = new UsuarioDAL();
                dal.Alterar(Usuario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
