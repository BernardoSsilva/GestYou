using application.UseCases.Transactions;
using application.UseCases.Transactions.Interfaces;
using comunication.requests;
using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions([FromServices] IListTransactions useCase)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpGet("/byCategory")]
        public async Task<IActionResult> GetTransactionsByCategory([FromServices] IGetTransactionsByCategory useCase)
        {
            var result = await useCase.Execute();
            return Ok(result);
        }

        [HttpGet("/byPerson")]
        public async Task<IActionResult> GetTransactionsByPerson([FromServices] IGetTransactionsByPerson useCase) {
            var result = await useCase.Execute();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromServices] ICreateTransaction useCase, [FromBody] TransactionDto data)
        {
            try
            {
                await useCase.Execute(data);

                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction([FromServices] IDeleteTransaction useCase, int id)
        {
            try
            {
                await useCase.Execute(id);

                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction([FromServices] IUpdateTransaction useCase, [FromBody] TransactionDto data, int id)
        {
            try
            {
                await useCase.Execute(id, data);

                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
