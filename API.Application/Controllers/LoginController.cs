using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Dtos.Login;
using Domain.Entities;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto, [FromServices] ILoginService loginService)
        {
            if (!ModelState.IsValid)
                return  BadRequest(ModelState);
            if(loginDto == null)
                return BadRequest();

            try
            {

                var login = await loginService.FindByLogin(loginDto);

                if (login != null)
                    return Ok(login);
                else
                    return NotFound();

            }
            catch (ArgumentException arg)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, arg.Message);
            }
        }

    }
}
