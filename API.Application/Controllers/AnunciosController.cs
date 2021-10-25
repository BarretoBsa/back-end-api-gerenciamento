using System;
using System.Net;
using System.Threading.Tasks;
using API.Domain.Entities;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnunciosController : ControllerBase
    {

        private IAnuncioService _service;

        public AnunciosController(IAnuncioService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> List() {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try {

                return Ok(await _service.List());
            } catch (ArgumentException e) {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetId")]
        public async Task<ActionResult> Get(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] AnuncioEntity anuncio)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Insert(anuncio);
                if (result != null)
                    return Created(new Uri(Url.Link("GetId", new { id = result.Id })), result);

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AnuncioEntity anuncio)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.Update(anuncio);
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
                var result = await _service.Delete(id);
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
