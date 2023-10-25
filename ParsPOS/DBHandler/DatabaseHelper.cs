using ParsPOS.Model;
using ParsPOS.ResultModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.DBHandler
{
    public class DatabaseHelper : SQLiteAsyncConnection
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseHelper(string dbPath) : base(dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Invitm>();
            _db.CreateTableAsync<NetworkIP>();
            _db.CreateTableAsync<GrpItmTb>();
        }

        public Task<int> CreateInvItm(Invitm invitm)
        {
            return _db.InsertAsync(invitm);
        }

        public Task<int> CreateNetwork(NetworkIP network)
        {
            return _db.InsertAsync(network);
        }
        public Task<int> CreateGrpItmTb(GrpItmTb grpItmTb)
        {
            return _db.InsertAsync(grpItmTb);
        }
        //INVITM
        public Task<List<Invitm>> GetAllInvItmPaged(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;

            return _db.Table<Invitm>()
                     .OrderBy(x => x.ItemId)
                     .Skip(skipCount)
                     .Take(pageSize)
                     .ToListAsync();
        }
        public Task<int> InvitmCount()
        {
            return _db.Table<Invitm>().CountAsync();
        }
        public Task<int> DeleteAllInvItm()
        {
            return _db.DeleteAllAsync<Invitm>();
        }
        public Task<List<Invitm>> GetProductsAsync(string search)
        {
            return _db.QueryAsync<Invitm>("select * from Invitm where ItemCode like '%" + search + "%' or BarCode like '%" + search + "%' or Description like '%" + search + "%';");
        }
        public Task<Invitm> EntryChk(string barcode)
        {
            return _db.Table<Invitm>().Where(x => x.BarCode == barcode || x.ItemCode == barcode).FirstOrDefaultAsync();
        }
        //Network
        public Task<List<NetworkIP>> GetAllNetwork()
        {
            return _db.Table<NetworkIP>().OrderBy(x => x.IsConnected).ToListAsync();
        }
        public Task<int> DeleteNetworkIP(NetworkIP network)
        {
            return _db.DeleteAsync(network);
        }
        public Task<int> UpdtNetworkStatus()
        {
            return _db.ExecuteScalarAsync<int>("Update NetworkIP Set IsConnected = 'false'");
        }
        public Task<int> UpdNetworkStatusID(int Id, string Connectname, string IP, int Port)
        {
            return _db.ExecuteScalarAsync<int>("Update NetworkIP Set IsConnected = 1 ,ConnectionName = '" + Connectname + "',IPAddress = '" + IP + "',PortNumber = " + Port + " where Id = '" + Id + "' ");

        }
        //GrpItm
        public Task<int> IsGrpItmTableEmpty()
        {
            return _db.Table<GrpItmTb>().CountAsync();
        }
        public async Task<List<RGrpItmTb>> GetAllGrpItm(int page, int pageSize,int parent,int child)
        {
            int skipCount = (page - 1) * pageSize;

            string query = $"SELECT G.GrpItmCode, G.Description, P.PCode, P.PName " +
                           $"FROM GrpItmTb G " +
                           $"LEFT JOIN " +
                           $"(SELECT GrpItmCode AS PCode, Description AS PName, UnqGrpId AS Id " +
                           $"FROM GrpItmTb WHERE lcode = {parent}) P ON P.Id = G.ParentId " +
                           $"WHERE G.lcode = {child} " +
                           $"ORDER BY G.GrpItmCode " +
                           $"LIMIT {pageSize} " +
            $"OFFSET {skipCount}";
            var result = await _db.QueryAsync<RGrpItmTb>(query);
            return result;
        }
        public async Task<List<RGrpItmTb>> GetAllFirstGrpItm(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;

            string query = $"SELECT G.UnqGrpId, G.GrpItmCode, G.Description, P.PCode, P.PName " +
                           $"FROM GrpItmTb G " +
                           $"LEFT JOIN " +
                           $"(SELECT GrpItmCode AS PCode, Description AS PName, UnqGrpId AS Id " +
                           $"FROM GrpItmTb) P ON P.Id = G.ParentId " +
                           $"ORDER BY G.GrpItmCode " +
                           $"LIMIT {pageSize} " +
                           $"OFFSET {skipCount}";
            var result = await _db.QueryAsync<RGrpItmTb>(query);
            return result;
        }
        public Task<int> UpdateGrpItm(RGrpItmTb grpItmTb)
        {
            
            return _db.ExecuteScalarAsync<int>("Update GrpItmTb Set Description = '"+grpItmTb.Description+ "',GrpItmCode = '"+grpItmTb.GrpItmCode+ "',UpdtdTm = '"+DateTime.Now+ "' where UnqGrpId = '"+grpItmTb.UnqGrpId+"'");
        }
       
        public Task<int> DeleteAllGrpItm()
        {
            return _db.DeleteAllAsync<GrpItmTb>();
        }
    }
}
