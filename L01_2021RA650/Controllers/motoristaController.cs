using L01_2021RA650.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L01_2021RA650.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class motoristaController : ControllerBase
    {
        private readonly RestauranteContext _restauranteContext;
        public motoristaController(RestauranteContext restauranteContext)
        {
            _restauranteContext = restauranteContext;
        }

        // GET: api/<motoristaController>
        [HttpGet]
        public IActionResult Get()
        {


            List<Motorista> listadoMotoristas = (from e in _restauranteContext.Motoristas
                                                 select e).ToList();

            if (listadoMotoristas.Count == 0)
            {
                return NotFound();
            }
            return Ok(listadoMotoristas);
        }

        // GET api/<motoristaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Motorista? motorista = (from e in _restauranteContext.Motoristas
                                    where e.MotoristaId == id
                                    select e).FirstOrDefault();

            if (motorista == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(motorista);
            }

        }

        // POST api/<motoristaController>
        [HttpPost]
        [Route("Add")]
        public IActionResult Post([FromBody] Motorista motorista)
        {
            {
                try
                {
                    _restauranteContext.Add(motorista);
                    _restauranteContext.SaveChanges();
                    return Ok(motorista);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        // PUT api/<motoristaController>/5
        [HttpPut]
        [Route("actualizar/{id}")]
        public IActionResult Modificarmotorizado(int id, [FromBody] Motorista motoristaModificar)
        {
            Motorista? motoristaActual = (from e in _restauranteContext.Motoristas
                                          where e.MotoristaId == id
                                          select e).FirstOrDefault();
            if (motoristaActual == null)
            {
                return NotFound();
            }
            else
            {
                motoristaActual.NombreMotorista = motoristaModificar.NombreMotorista;

            }
            _restauranteContext.Entry(motoristaActual).State = EntityState.Modified;
            _restauranteContext.SaveChanges();
            return Ok(motoristaActual);

        }

        // DELETE api/<motoristaController>/5
        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult Delete(int id)
        {
            Motorista? motorista = (from e in _restauranteContext.Motoristas
                                    where e.MotoristaId == id
                                    select e).FirstOrDefault();
            if (motorista == null)
            {
                return NotFound();
            }
            else
            {
                _restauranteContext.Motoristas.Attach(motorista);
                _restauranteContext.Motoristas.Remove(motorista);
                _restauranteContext.SaveChanges();
                return Ok(motorista);
            }

        }
        [HttpGet]
        [Route("FiltrarByName/{nombre}")]
        public IActionResult FiltrarNombre(String nombre)
        {
            List<Motorista> motoristas = (from e in _restauranteContext.Motoristas
                                 where e.NombreMotorista == nombre
                                 select e).ToList();
            if (motoristas == null)
            {
                return NotFound();
            }
            return Ok(motoristas);

        }
    }
}
