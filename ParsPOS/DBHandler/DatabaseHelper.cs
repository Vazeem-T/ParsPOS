﻿using ParsPOS.Model;
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
            _db.CreateTableAsync<User>();
            _db.CreateTableAsync<RightNode>();
            _db.CreateTableAsync<Rights>();
            _db.CreateTableAsync<PreFixTb>();
            _db.CreateTableAsync<SettingsTb>();
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
        public Task<int> CreateUser(User user)
        {
            return _db.InsertAsync(user);
        }

        public Task<int> CreateRights(Rights rights)
        {
            return _db.InsertAsync(rights);
        }
        public Task<int> CreateRightNode(RightNode rightNode) 
        {
            return _db.InsertAsync(rightNode);
        }
        public Task<int> CreatePrefixTb(PreFixTb preFixTb)
        {
            return _db.InsertAsync(preFixTb);
        }
        public Task<int> CreateSettings(SettingsTb settingsTb) 
        {
            return _db.InsertAsync(settingsTb);
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

        //User & their Rights
        public async Task<List<User>> GetAllUserDt(int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;

            return await _db.Table<User>()
                            .OrderBy(x => x.Id)
                            .Skip(skipCount)
                            .Take(pageSize)
                            .ToListAsync();
        }
        public Task<bool> GetRight(int Id, string Processcode)
        {
            return _db.ExecuteScalarAsync<bool>("SELECT RightYN FROM Rights WHERE ProcessCode = '" + Processcode + "' AND Id = " + Id + " UNION ALL SELECT defRight As Ord FROM RightNode WHERE ProcessCode = '" + Processcode + "'");
        }
        public Task<bool> GetMenus(int Id, string Processcode)
        {
            string query = "SELECT IsMenu FROM Rights WHERE ProcessCode = '" + Processcode + "' AND Id = " + Id + " UNION ALL SELECT defRight As Ord FROM RightNode WHERE ProcessCode = '" + Processcode + "'";
            return _db.ExecuteScalarAsync<bool>(query);
        }

        public Task<List<Rights>> GetRightList()
        {
            return _db.Table<Rights>().ToListAsync();
        }
        public Task<User> ReadUniqueUser(string UserId)
        {
            return _db.Table<User>().Where(x => x.UserId == UserId).FirstOrDefaultAsync();
        }
        public Task<int> GetId(string UserId)
        {
            return _db.ExecuteScalarAsync<int>("Select Id from User where UserId = '" + UserId + "'");
        }
        public Task<List<PreFixTb>> GetSalePrefixButton()
        {
            return  _db.Table<PreFixTb>().Where(x=>x.VrTypeNo == 4).ToListAsync();
        }

        public Task<PreFixTb> GetSaleVoucherName(int voucherId)
        {
            return _db.Table<PreFixTb>().Where(x => x.Id == voucherId).FirstOrDefaultAsync();
        }

        //UserLogin

        public Task<User> LoginUser(string UserId, string Password)
        {
            return _db.Table<User>().Where(x => x.UserId.ToLower() == UserId.ToLower() && x.Password == Password).FirstOrDefaultAsync();
        }

        //SettingsTb

        public Task<SettingsTb> GetLastSettings()
        {
            return _db.Table<SettingsTb>().OrderBy(x => x.Id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateSettings(SettingsTb settings) 
        {
            return _db.UpdateAsync(settings);
        }

    }

}
