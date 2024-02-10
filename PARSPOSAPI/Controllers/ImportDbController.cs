using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using PARSPOSAPI.ViewModel;
using Microsoft.Identity.Client;

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
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT dbo.getTAXPer(BaseId) Taxper, *, ROW_NUMBER() OVER (ORDER BY ItemId) AS RowNum FROM invitm) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";

				string sqlQuery = $"Select dbo.getTAXPer(BaseId) Taxper, * from invitm ORDER BY ItemId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

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
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY UnqGrpId) AS RowNum FROM GrpItmTb) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";
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
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				//UserRDt user = new()
				//{
				//	User = await _connection.QueryAsync<dynamic>($"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM PassId) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}"),
				//	Rights = await _connection.QueryAsync<dynamic>($"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Id) AS RowNum FROM Rights) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}"),
				//	RightNode = await _connection.QueryAsync<dynamic>($"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY NodeId) AS RowNum FROM RightNode) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}")
				//};
				UserRDt userRDt = new ()
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
        [HttpGet("BaseItmDet")]
        public async Task<IActionResult> GetBaseItmDet(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY BaseItemId) AS RowNum FROM BaseItmDet) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";

				string sqlQuery = $"SELECT * FROM BaseItmDet ORDER BY BaseItemId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

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

        [HttpGet("GetBaseItemCount")]
        public async Task<int> GetBaseItemCount()
        {
            string sqlQuery = $" Select count (*) from BaseItmDet";

            var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

            return invItems;
        }
        [HttpGet("UnitsTbDet")]
        public async Task<IActionResult> GetUnitsTbDet(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY Units) AS RowNum FROM UnitsTb) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";

				string sqlQuery = $"SELECT * FROM UnitsTb ORDER BY Units OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

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

        [HttpGet("GetUnitCount")]
        public async Task<int> GetUnitCount()
        {
            string sqlQuery = $" Select count (*) from UnitsTb";

            var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

            return invItems;
        }
        [HttpGet("SuppPrdDt")]
        public async Task<IActionResult> SuppPrdDt(int page = 1, int pageSize = 100)
        {
            try
            {
                int skipCount = (page - 1) * pageSize;
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY ItemId) AS RowNum FROM SuppPrdTb) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";

				string sqlQuery = $"SELECT * FROM SuppPrdTb ORDER BY ItemId OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

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

        [HttpGet("SuppPrdDtCount")]
        public async Task<int> SuppPrdDtCount()
        {
            string sqlQuery = $" Select count (*) from SuppPrdTb";

            var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

            return invItems;
        }
		[HttpGet("AccMastTb")]
		public async Task<IActionResult> AccMastDt(int page = 1, int pageSize = 100)
		{
			try
			{
				int skipCount = (page - 1) * pageSize;
				int startRow = (page - 1) * pageSize + 1;
				int endRow = startRow + pageSize - 1;
				string query = $"SELECT * FROM ( SELECT *, ROW_NUMBER() OVER (ORDER BY AccountNo) AS RowNum FROM AccMast) AS Subquery WHERE RowNum BETWEEN {startRow} AND {endRow}";

				string sqlQuery = $"SELECT * FROM AccMast ORDER BY AccountNo OFFSET {skipCount} ROWS FETCH NEXT {pageSize} ROWS ONLY";

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

		[HttpGet("AccMastTbCount")]
		public async Task<int> AccMastTbCount()
		{
			string sqlQuery = $" Select count (*) from AccMast";

			var invItems = await _connection.ExecuteScalarAsync<int>(sqlQuery);

			return invItems;
		}
	}
}
