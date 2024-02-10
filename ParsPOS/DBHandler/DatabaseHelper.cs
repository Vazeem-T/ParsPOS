using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using SQLite;

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
            _db.CreateTableAsync<BaseItmDet>();
            _db.CreateTableAsync<UnitsTb>();
            _db.CreateTableAsync<SuppPrdTb>();
            _db.CreateTableAsync<AccMast>();
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
        public Task<int> CreateBaseItmDet(BaseItmDet settingsTb)
        {
            return _db.InsertAsync(settingsTb);
        }
        public Task<int> CreateUnitsTb(UnitsTb unitsTb) 
        {
            return _db.InsertAsync(unitsTb);
        }
        public Task<int> CreateSupplierPrdTb(SuppPrdTb supplierPrdTb) 
        {
            return _db.InsertAsync(supplierPrdTb);
        }
        public Task<int> CreateAccMast(AccMast accMast)
        {
            return _db.InsertAsync(accMast);
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
        public Task<List<Invitm>> GetItemOnBaseId(int? BaseId)
        {
            return _db.Table<Invitm>().Where(x=>x.BaseId == BaseId).ToListAsync();
        }
        public Task<Invitm> GetItemOnItemId(int? ItemId)
        {
            return _db.Table<Invitm>().Where(x => x.ItemId == ItemId).FirstOrDefaultAsync();
        }
        public async Task<double> GetPMult(string ItemCode)
        {
            return _db.Table<Invitm>().Where(x => x.ItemCode == ItemCode).FirstOrDefaultAsync().Result.PMult;
        }
        public Task<string> GetUnitOnBaseItm(int Baseid)
        {
            return _db.ExecuteScalarAsync<string>($"Select Unit from Invitm where BaseId = {Baseid} AND ItemId = {Baseid}");
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

        public Task<List<PreFixTb>> GetPrefixItems(int VrTypeNo)
        {
            return _db.Table<PreFixTb>().Where(x=>x.VrTypeNo ==  VrTypeNo).ToListAsync();
        }
		public Task<PreFixTb> GetVoucherName(string vouchername)
		{
			return _db.Table<PreFixTb>().Where(x => x.VoucherName == vouchername).FirstOrDefaultAsync();
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



        //Popup
        public async Task<List<T>> GetItemforPopup<T>(int page, int pageSize, string popupButtons) where T : new()
        {
            if (Enum.TryParse(popupButtons, true, out PopupButtonsSelection selection))
            {
                int skipCount = (page - 1) * pageSize;
                string query = "";
                switch (selection)
                {
                    case PopupButtonsSelection.ProductCode:
                        query = $"SELECT ItemCode, Description, Unit, ActiveCost, UnitPrice, BarCode FROM InvItm ORDER BY ItemCode LIMIT {pageSize} OFFSET {skipCount}";
                        break;
                    case PopupButtonsSelection.ProductDescr:
                        query = $"SELECT A.BarCode FROM InvItm A";
                        break;
                    default:
                        return new List<T>();
                }

                var result = await _db.QueryAsync<T>(query);

                Console.WriteLine(result.ToList());
                return result.ToList();
            }
            else
            {
                return new List<T>();
            }
        }

        public Task<List<Invitm>> GetPopProductSearch(string search,string selected, int page, int pageSize)
        {
            int skipCount = (page - 1) * pageSize;
            var query = $"select ItemCode , Description, Unit, ActiveCost, UnitPrice, BarCode from Invitm where {selected} like '%{search}%' LIMIT {pageSize} OFFSET {skipCount}";
            return _db.QueryAsync<Invitm>(query);
        }

        // AccMast
        public Task<AccMast> GetMasterAccountDetail(int AccountNo)
        {
            return _db.Table<AccMast>().Where(x => x.AccountNo == AccountNo).FirstOrDefaultAsync();
        }
        public Task<int> DeleteAllBaseItm()
        {
            return _db.DeleteAllAsync<BaseItmDet>();
        }
		public Task<int> DeleteAllPrefixItm()
		{
			return _db.DeleteAllAsync<PreFixTb>();
		}
		public Task<int> DeleteAllUnitItm()
        {
            return _db.DeleteAllAsync<UnitsTb>();
        }
        public Task<int> DeleteAllSuppPrdTb()
        {
            return _db.DeleteAllAsync<SuppPrdTb>();
        }
		public Task<int> DeleteAllMasters()
		{
			return _db.DeleteAllAsync<AccMast>();
		}

	}
}
