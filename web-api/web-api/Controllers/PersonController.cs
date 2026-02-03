using application.UseCases.Persons;
using application.UseCases.Persons.Interfaces;
using comunication.requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> ListAllPersons([FromServices] IListPersons useCase)
        {
            try
            {

            var result = await useCase.Execute();

            return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPerson([FromServices] ICreatePerson useCase, [FromBody] PersonDto data)
        {

            await useCase.Execute(data);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson([FromServices] IUpdatePerson useCase, [FromBody] PersonDto data, int id)
        {
            try
            {

            await useCase.Execute(id, data);

            return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePerson([FromServices] IDeletePerson useCase, int id)
        {
            try
            {

                await useCase.Execute(id);

                return Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex) {
                return BadRequest();
            }

        } 
    }
}
