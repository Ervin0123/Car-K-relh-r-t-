using Car_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SzolgaltatasokController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                   return Ok(context.Szolgaltatas.ToList());
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        
        public IActionResult Post(Szolgaltata szolg)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.Szolgaltatas.Add(szolg);
                    context.SaveChanges();
                    return Ok("Új szolgáltatás létrehozva.");
                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut]
        public IActionResult Put(Szolgaltata szolg)
        {
            using (var context = new carcarelharitoContext())
            {
                try
                {
                    context.Szolgaltatas.Update(szolg);
                    context.SaveChanges();
                    return Ok("Szolgáltatás módosítva.");
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
                    Szolgaltata szolg = new Szolgaltata();
                    szolg.SzolgId = id;
                    context.Szolgaltatas.Remove(szolg);
                    context.SaveChanges();
                    return Ok("Szolgáltatás törölve");

                }
                catch (System.Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }
    }
}
