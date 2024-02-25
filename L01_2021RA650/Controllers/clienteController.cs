using L01_2021RA650.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L01_2021RA650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clienteController : ControllerBase
    {
        private readonly RestauranteContext restauranteContext;
        public clienteController(RestauranteContext restauranteContext)
        {
            restauranteContext = restauranteContext;
        }



        // GET: api/<clienteController>
        [HttpGet]
        public IActionResult Get()
        {
            
            
                List<Cliente> clientes = (from e in restauranteContext.Clientes
                                          select e).ToList();

                if (clientes.Count == 0)
                {
                    return NotFound();
                }
                return Ok(clientes);
            
        }

        // GET api/<clienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<clienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<clienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<clienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
