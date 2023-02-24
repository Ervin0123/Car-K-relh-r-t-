using Car_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Car_Backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MegrendeloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    return Ok(context.Megrendelos.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]

        public IActionResult Post(Megrendelo meg)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.Megrendelos.Add(meg);
                    context.SaveChanges();
                    return Ok("Új megrendelés elküldve.");
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(Megrendelo meg)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.Megrendelos.Update(meg);
                    context.SaveChanges();
                    return Ok("Megrendelés módosítva.");
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
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    Megrendelo meg = new Megrendelo();
                    meg.MegrendId = id;
                    context.Megrendelos.Remove(meg);
                    context.SaveChanges();
                    return Ok("Megrendeles törölve");

                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
