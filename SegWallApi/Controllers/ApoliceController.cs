using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SegWallApi.DAL;
using SegWallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegWallApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApoliceController : ControllerBase
    {

        private readonly ILogger<ApoliceController> _logger;

        public ApoliceController(ILogger<ApoliceController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Apolice Apolice)
        {
            try
            {
                ApoliceDAL dal = new ApoliceDAL();
                dal.Inserir(Apolice);

                string location =
                    Url.Link("DefaultApi", new { controller = "apolice", id = Apolice.IdApolice });

                return Created(new Uri(location), Apolice);

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
                ApoliceDAL dal = new ApoliceDAL();
                dal.Excluir(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Apolice Apolice)
        {
            try
            {
                ApoliceDAL dal = new ApoliceDAL();
                dal.Alterar(Apolice);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}