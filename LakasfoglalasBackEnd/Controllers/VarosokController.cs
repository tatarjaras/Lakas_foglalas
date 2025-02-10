using LakasfoglalasBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakasfoglalasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VarosokController : ControllerBase
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
                        return Ok(await cx.Varosoks.ToListAsync());
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
                        return Ok(await cx.Varosoks.FirstOrDefaultAsync(f => f.Id == id));
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
