using LakasfoglalasBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakasfoglalasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EladasokController : ControllerBase
    {

        [HttpGet("{token}")]

        public async Task<IActionResult> GetFull(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Eladasoks.ToListAsync());
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);

                }
            }
            else
            {
                return BadRequest("Nincs jogod hozzá!");
            }
        }

        [HttpGet("{id},{token}")]

        public async Task<IActionResult> GetId(int id, string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Eladasoks.FirstOrDefaultAsync(f => f.Id == id));
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);

                }
            }
            else
            {
                return BadRequest("Nincs jogod hozzá!");
            }
        }



        [HttpPost("{token}")]

        public async Task<IActionResult> Post(string token, Eladasok eladasok)
        {
            if (Program.LoggedInUsers.ContainsKey(token))
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Eladasoks.Add(eladasok);
                        cx.SaveChanges();
                        return Ok("vásárlás  rögzítve");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);

                }
            }
            else
            {
                return BadRequest("Nincs jogod hozzá!");
            }
        }

        [HttpDelete("{token},{id}")]

        public async Task<IActionResult> Delete(string token, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Eladasoks.Remove(new Eladasok { Id = id });
                        cx.SaveChangesAsync();
                        return Ok("Eladás adatai törölve");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.InnerException?.Message);

                }
            }
            else
            {
                return BadRequest("Nincs jogod hozzá!");
            }
        }

    }
}
