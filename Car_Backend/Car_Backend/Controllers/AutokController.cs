using Car_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutokController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    return Ok(context.EladoAutos.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpGet]
        [Route("GetId")]
        public IActionResult GetId(int id)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    return Ok(context.EladoAutos.Where(a => a.EladoId == id).ToList());
                }
                catch (System.Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }
        
        [HttpGet]
        [Route("GetRendszam")]
        public IActionResult GetRendszam(string rendszam)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    return Ok(context.EladoAutos.Where(a => a.EladoRendszam == rendszam).ToList());
                }
                catch (System.Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        public IActionResult Post(EladoAuto auto)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.EladoAutos.Add(auto);
                    context.SaveChanges();
                    return Ok("Új autó adatai tárolva.");
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(EladoAuto auto)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.EladoAutos.Update(auto);
                    context.SaveChanges();
                    return Ok("Autó adatai módosítva.");
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (var context =new carcarelharitoContext())
            {
                try
                {
                    EladoAuto auto = new EladoAuto();
                    auto.EladoId = id;
                    context.EladoAutos.Remove(auto);
                    context.SaveChanges();
                    return Ok("Autó adatai törölve.");
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
