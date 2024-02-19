using SQLite;
using ParsVanSale.Model;
using System.Linq.Expressions;

namespace ParsVanSale.Helper
{
    public class DatabaseHelper : SQLiteAsyncConnection
	{
		private readonly SQLiteAsyncConnection _db;
		public DatabaseHelper(string dbPath) : base(dbPath)
		{
			_db = new SQLiteAsyncConnection(dbPath);
			InitializeTables();
		}

		private void InitializeTables()
		{
			CreateTableAsync<Invitm>().Wait();
			CreateTableAsync<NetworkIP>().Wait();
			CreateTableAsync<GrpItmTb>().Wait();
			CreateTableAsync<User>().Wait();
			CreateTableAsync<RightNode>().Wait();
			CreateTableAsync<Rights>().Wait();
			CreateTableAsync<PreFixTb>().Wait();
			CreateTableAsync<SettingsTb>().Wait();
			CreateTableAsync<BaseItmDet>().Wait();
			CreateTableAsync<UnitsTb>().Wait();
			CreateTableAsync<SuppPrdTb>().Wait();
			CreateTableAsync<AccMast>().Wait();
            CreateTableAsync<DownloadDt>().Wait();
			CreateTableAsync<PurchaseDetTb>().Wait();
			CreateTableAsync<PurchaseDetCmn>().Wait();
			CreateTableAsync<SqlServerIPSettings>().Wait();	
		}

		private async Task CreateTableAsync<T>() where T : new()
		{
			await _db.CreateTableAsync<T>().ConfigureAwait(false);
		}

		public Task<int> InsertAsync<T>(T entity)
		{
			return _db.InsertAsync(entity);
		}

		public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable, TKey>(Expression<Func<TTable, bool>>? predicate,Expression<Func<TTable, TKey>>? orderBy)where TTable : class, new()
		{
			var query = _db.Table<TTable>();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				query = query.OrderBy(orderBy);
			}

			return await query.ToListAsync();
		}

		public async Task<bool> TableExist<T>() where T : new()
		{
			var count = await _db.Table<T>().CountAsync();
			return count > 0;
		}
		public async Task<TTable> GetFirstAsync<TTable, TKey>(Expression<Func<TTable, bool>>? predicate, Expression<Func<TTable, TKey>>? orderBy) where TTable : class, new()
		{
			var query = _db.Table<TTable>();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				query = query.OrderBy(orderBy);
			}

			return await query.FirstOrDefaultAsync();
		}
		public async Task<TTable> GetLastAsync<TTable, TKey>(Expression<Func<TTable, bool>>? predicate, Expression<Func<TTable, TKey>>? orderBy) where TTable : class, new()
		{
			var query = _db.Table<TTable>();

			if (predicate != null)
			{
				query = query.Where(predicate);
			}

			if (orderBy != null)
			{
				query = query.OrderByDescending(orderBy);
			}

			return await query.FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<TTable>> GetItemsAsync<TTable>() where TTable : class, new()
		{
			var query = _db.Table<TTable>();
			return await query.Take(30).ToListAsync();
		}
		public Task<int> UpdateAsync<T>(T entity)
		{
			return _db.UpdateAsync(entity);
		}

        public Task<int> DeleteAll<T>()
        {
            return _db.DeleteAllAsync<T>();
        }

        public Task<int> DbCount<T>() where T : new()
        {
            return _db.Table<T>().CountAsync();
        }
        public Task<NetworkIP> GetActiveIP()
		{
			return _db.Table<NetworkIP>().Where(x => x.IsConnected == true).FirstOrDefaultAsync();
		}

		//DownloadDt
        public Task<DownloadDt> GetDownloadItm(string desc)
        {
            return _db.Table<DownloadDt>().Where(x => x.DownloadDescription == desc && x.IsRunning == true).FirstOrDefaultAsync();
        }
        public Task<int> UpdateDownloadProgress(int Id, int Progress)
        {
            return _db.ExecuteScalarAsync<int>("Update DownloadDt Set Progress = " + Progress + " where DownloadId = " + Id + " ");
        }
        public Task<int> UpdateDownloadComplete(int Id, bool IsSuccess)
        {
            return _db.ExecuteScalarAsync<int>("Update DownloadDt Set IsCompleted = true,IsRunning = false,IsSuccess = " + IsSuccess + " where DownloadId = " + Id + " ");
        }
        public Task<int> GetProgress(int Id)
        {
            return _db.ExecuteScalarAsync<int>("Select Progress from DownloadDt where DownloadId = " + Id + "");
        }

		public Task<List<AccMast>> GetSearchMast(string search, string selected)
		{
			var query = $"Select * from AccMast where {selected} like '%" + search + "%' LIMIT 30";
			return _db.QueryAsync<AccMast>(query);
		}
		public Task<List<Invitm>> GetSearchProd(string search, string selected)
		{
			var query = $"Select * from Invitm where {selected} like '%" + search + "%' LIMIT 30";
			return _db.QueryAsync<Invitm>(query);
		}
		public Task<PreFixTb> GetVoucherName(string vouchername)
        {
            return _db.Table<PreFixTb>().Where(x => x.VoucherName == vouchername).FirstOrDefaultAsync();
        }
        public Task<AccMast> GetMasterAccountDetail(int AccountNo)
        {
            return _db.Table<AccMast>().Where(x => x.AccountNo == AccountNo).FirstOrDefaultAsync();
        }

		public Task<User> LoginUser(string UserId, string Password)
		{
			return _db.Table<User>().Where(x => x.UserId.ToUpper() == UserId.ToUpper() && x.Password.ToUpper() == Password.ToUpper()).FirstOrDefaultAsync();
		}
	}
}
