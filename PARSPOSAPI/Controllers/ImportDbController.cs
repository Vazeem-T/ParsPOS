using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using PARSPOSAPI.ViewModel;

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
        [HttpGet("Category")]
        public async Task<IActionResult> GetCategory(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;

                string sqlQuery = $"SELECT * FROM GrpItmTb ORDER BY UnqGrpId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

                var Items = await _connection.QueryAsync<dynamic>(sqlQuery);

                var ItemsList = Items.AsList();

                return Ok(ItemsList);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the query execution
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetCategoryCount")]
        public async Task<int> GetCategoryCount()
        {
            string sqlQuery = $" Select count (*) from GrpItmTb";

            var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

            return invItems;
        }

        //User Import
        [HttpGet("UserDt")]
        public async Task<IActionResult> GetUser(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;

                UserRDt userRDt = new UserRDt
                {
                    User = await _connection.QueryAsync<dynamic>($"SELECT * FROM PassId Order by Id OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY"),
                    Rights = await _connection.QueryAsync<dynamic>($"SELECT * FROM Rights Order by Id OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY"),
                    RightNode = await _connection.QueryAsync<dynamic>($"SELECT * FROM RightNode Order by NodeId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY")
                };
                return Ok(userRDt);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the query execution
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
      
        [HttpGet("UserCount")]
        public async Task<ActionResult<UserCountRViewModel>> GetUserCount()
        {
            UserCountRViewModel count = new()
            {
                UserCount = await _connection.ExecuteScalarAsync<int>($"Select count (*) from PassId"),
                RightCount = await _connection.ExecuteScalarAsync<int>($"Select count (*) from Rights"),
                RightNodeCount = await _connection.ExecuteScalarAsync<int>($"Select count (*) from RightNode")
            };
            if(count == null)
            {
                return NotFound();
            }
            return count;
        }
        [HttpGet("ImportPrefix")]
        public async Task<IActionResult> ImportPrefix()
        {
            try
            {
                string sqlQuery = $"SELECT * FROM PreFixTb";

                var Items = await _connection.QueryAsync<dynamic>(sqlQuery);

                var ItemsList = Items.AsList();

                return Ok(ItemsList);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the query execution
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
