using application.UseCases.Categories.Interfaces;
using comunication.requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromServices] IListCategories useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCategory([FromServices] ICreateCategory useCase, [FromBody] CategoryDto data)
        {
            try
            {
                await useCase.Execute(data);

                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory([FromServices] IUpdateCategory useCase, [FromBody] CategoryDto data, int id)
        {

            try
            {
                await useCase.Execute(id, data);

                return Ok();
            } catch (KeyNotFoundException)
            {
                return NotFound();
            } catch
            {
                return BadRequest();
            }

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromServices] IDeleteCategory useCase, int id)
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
            catch
            {
                return BadRequest();
            }
        }
    }
}
