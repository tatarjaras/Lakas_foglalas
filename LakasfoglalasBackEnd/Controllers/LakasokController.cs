using LakasfoglalasBackEnd.DTOs;
using LakasfoglalasBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakasfoglalasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LakasokController : ControllerBase
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
                        return Ok(await cx.Lakasoks.ToListAsync());
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

        
        //////////////
        [HttpGet("{id},{token}")]

        public async Task<IActionResult> GetId(int id, string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Lakasoks.FirstOrDefaultAsync(f => f.Id == id));
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
        //////////////


        [HttpPost("{token}")]

        public async Task<IActionResult> Post(string token, Lakasok lakas)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Lakasoks.Add(lakas);
                        cx.SaveChanges();
                        return Ok("Új lakás adatai rögzítve");
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

        //////////////
        [HttpPut("{token}")]

        public async Task<IActionResult> Put(string token, Lakasok lakasok)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Lakasoks.Update(lakasok);
                        cx.SaveChanges();
                        return Ok("A lakás adatai módosítva");
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
        //////////////
        [HttpDelete("{token},{id}")]

        public async Task<IActionResult> Delete(string token, int id)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Lakasoks.Remove(new Lakasok { Id = id });
                        cx.SaveChangesAsync();
                        return Ok("A lakás adatai törölve");
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

//{
//"id": 0,
//  "utca": "string",
//  "meret": 0,
//  "szobakSzama": 0,
//  "ar": 0,
//  "leiras": "string",
//  "felhasznaloId": 1,
//  "varosId": 1
//}