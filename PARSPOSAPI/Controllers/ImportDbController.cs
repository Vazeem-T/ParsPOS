using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;

namespace PARSPOSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDbController : ControllerBase
    {
        private readonly IDbConnection _connection;

        public ImportDbController(IDbConnection connection)
        {
            _connection = connection;
        }
        [HttpGet("InvItm")]
        public async Task<IActionResult> GetInvItm(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;

                string sqlQuery = $"SELECT * FROM InvItm ORDER BY ItemId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                var invItems = await _connection.QueryAsync<dynamic>(sqlQuery);

                var invItemsList = invItems.AsList();

                return Ok(invItemsList);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the query execution
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetInvItemCount")]
        public async Task<int> GetInvItemCount()
        {
            string sqlQuery = $" Select count (*) from InvItm";

            var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

            return invItems;
        }
    }
}
