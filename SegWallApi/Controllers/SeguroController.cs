using SegWallApi.DAL;
using SegWallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SegWallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeguroController : ControllerBase
    {
        private readonly ILogger<SeguroController> _logger;

        public SeguroController(ILogger<SeguroController> logger)
        {
            _logger = logger;
        }

        [HttpGet("listar")]
        public IActionResult Get()
        {
            return Ok(new SeguroDAL().Listar());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            try
            {
                SeguroDAL dal = new SeguroDAL();
                Seguro seguro = dal.Consultar(id);
                return Ok(seguro);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Seguro Seguro)
        {
            try
            {
                SeguroDAL dal = new SeguroDAL();
                dal.Inserir(Seguro);

                string location =
                    Url.Link("DefaultApi", new { controller = "seguro", id = Seguro.IdSeguro });

                return Created(new Uri(location), Seguro);

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
                SeguroDAL dal = new SeguroDAL();
                dal.Excluir(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Seguro Seguro)
        {
            try
            {
                SeguroDAL dal = new SeguroDAL();
                dal.Alterar(Seguro);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}