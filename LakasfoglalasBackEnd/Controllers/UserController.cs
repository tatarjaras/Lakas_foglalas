﻿using LakasfoglalasBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LakasfoglalasBackEnd.DTOs; 

namespace LakasfoglalasBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("{token}")]

        public async Task<IActionResult> GetFull(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token)&& Program.LoggedInUsers[token].PermissionId==9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Users.ToListAsync());
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
        [HttpGet("/EmailName/{token}")]

        public async Task<IActionResult> GetEmailName(string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Users.Select(f=> new EmailNameDTO { Email=f.Email,Name=f.Name}).ToListAsync());
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

        public async Task<IActionResult> GetId(int id,string token)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        return Ok(await cx.Users.FirstOrDefaultAsync(f => f.Id==id));
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

        public async Task<IActionResult> Post(string token,User user)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Users.Add(user);
                        cx.SaveChanges();
                        return Ok("Új felhasznaló adatai rögzítve");
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

        [HttpPut("{token}")]

        public async Task<IActionResult> Put(string token, User user)
        {
            if (Program.LoggedInUsers.ContainsKey(token) && Program.LoggedInUsers[token].PermissionId == 9)
            {
                try
                {
                    using (var cx = new LakasfoglalasContext())
                    {
                        cx.Users.Update(user);
                        cx.SaveChanges();
                        return Ok("A felhasznaló adatai módosítva");
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
                        cx.Users.Remove(new User { Id=id});
                        cx.SaveChangesAsync();
                        return Ok("A felhasznaló adatai törölve");
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
