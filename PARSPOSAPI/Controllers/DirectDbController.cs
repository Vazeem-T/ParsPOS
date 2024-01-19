using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARSAcc.Model.Models;
using System.Data;
using System.Runtime.CompilerServices;

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
        [HttpGet("HealthChk")]
        public async Task<bool> HealthChk()
        {
            return true;
        }
        [HttpGet("FetchItem")]
        public async Task<dynamic> FetchItem(string Code)
        {
            string sqlQuery = $"SELECT InvItm.*, BaseItmDet.*, FraCount FROM InvItm LEFT JOIN UnitsTb ON UnitsTb.Units = InvItm.Unit LEFT JOIN BaseItmDet ON InvItm.BaseId = BaseItmDet.BaseItemId WHERE [Item Code] = '{Code}'";
            var invItems = await _connection.QueryAsync<dynamic>(sqlQuery);
            return invItems.ToList();
        }
        [HttpGet("GetProdPop")]
        public async Task<IEnumerable<InvItm>> GetItemToPopUp()
        {
            string sqlQuery = $"Select top(20) [Item Code] as ItemCode , * from InvItm";
            var invItems = await _connection.QueryAsync<InvItm>(sqlQuery);
            return invItems;
        }
    }
}
