using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace PARSPOSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectDbController : ControllerBase
    {
        private readonly IDbConnection _connection;

        public DirectDbController(IDbConnection connection)
        {
            _connection = connection;
        }
        [HttpGet("QIH")]
        public async Task<float> QIH(string ItemCode)
        {
            string sqlQuery = $"SELECT cast (QtyInHand/PMult as decimal(10,3)) Qih FROM BaseItmDet B inner JOIN (select * from invitm WHERE LTrim([Item Code]) = '"+ItemCode+"') I ON I.BaseId = BaseItemId";

            var invItems = await _connection.ExecuteScalarAsync<float>(sqlQuery);

            return invItems;
        }
    }
}
