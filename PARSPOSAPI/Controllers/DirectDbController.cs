using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
		[HttpGet("GetDbUpdateDetail")]
		public async Task<UpdtdStatus4IndCntr> GetDbUpdateDetail(string date,string tablename)
        {
			string sqlQuery = "SELECT * FROM UpdtdStatus4IndCntr WHERE UpdtdTm >= @Date AND MasterStr = @TableName";
			var itmdetail = await _connection.QueryAsync<UpdtdStatus4IndCntr>(sqlQuery, new { Date = date, TableName = tablename });
			return itmdetail.FirstOrDefault();
		}

        [HttpGet("GetModiInvItm")]
        public async Task<IEnumerable<InvItm>> GetModiInvItm(string date)
        {
			string sqlQuery = "SELECT * FROM InvItm where ModiDt >= @Date";
			var itmdetail = await _connection.QueryAsync<InvItm>(sqlQuery, new { Date = date});
			return itmdetail.ToList();
		}

		[HttpGet("GetModiSupplier")]
		public async Task<IEnumerable<InvItm>> GetModiSupplier(string date)
		{
			string sqlQuery = "SELECT * FROM AccMast where ModiDt >= @Date";
			var itmdetail = await _connection.QueryAsync<InvItm>(sqlQuery, new { Date = date });
			return itmdetail.ToList();
		}

		[HttpGet("GetModiUnit")]
		public async Task<IEnumerable<InvItm>> GetModiUnit(string date)
		{
			string sqlQuery = "SELECT * FROM AccMast where UpdtdTm >= @Date";
			var itmdetail = await _connection.QueryAsync<InvItm>(sqlQuery, new { Date = date });
			return itmdetail.ToList();
		}
	}
}
