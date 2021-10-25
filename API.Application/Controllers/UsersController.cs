using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                return Ok(await _userService.List());

            }
            catch (ArgumentException arg)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, arg.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetUserId")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            try
            {
                return Ok(await _userService.Get(id));

            }
            catch (ArgumentException arg)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, arg.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var result = await _userService.Insert(user);
                if (result != null)
                    return Created(new Uri(Url.Link("GetUserId", new { id = result.Id })), result);

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserEntity user)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.Update(user);
                if (result != null)
                    return Ok(result);

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.Delete(id);
                if (result)
                    return Ok(result);

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }





    }
}
