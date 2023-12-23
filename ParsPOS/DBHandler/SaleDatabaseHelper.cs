using ParsPOS.SaleModel;
using PARSPOS.SaleModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.DBHandler
{
    public class SaleDatabaseHelper : SQLiteAsyncConnection           //IAsyncDisposable
    {

        private readonly SQLiteAsyncConnection _db;


        public SaleDatabaseHelper(string dbpath) : base(dbpath) 
        {
            _db = new SQLiteAsyncConnection(dbpath);
            _db.CreateTableAsync<NizPosdet>();
            _db.CreateTableAsync<NizPoscmn>();
            _db.CreateTableAsync<DownloadDt>();
        }
        public Task<int> CreateNizPosCmn(NizPoscmn nizPoscmn)
        {
            return _db.InsertAsync(nizPoscmn);
        }
        public Task<int> CreateNizPosDet(NizPosdet nizPosdet)
        {
            return _db.InsertAsync(nizPosdet);
        }
        public Task<int> CreateDownloadDt(DownloadDt downloadDt) 
        {
            return _db.InsertAsync(downloadDt);
        }
        //NizPosCmn
        public Task<List<NizPoscmn>> GetAllNizPoscmn() 
        {
            return _db.Table<NizPoscmn>().ToListAsync();
        }
        public Task<List<NizPosdet>> GetNizdetOnHoldNo(short HoldNo)
        {
            return _db.Table<NizPosdet>().Where(x=>x.HoldNo == HoldNo).ToListAsync();
        }

        public Task<int> DeleteSelectedPoscmn(short OnHold)
        {
            return _db.ExecuteScalarAsync<int>("Delete From NizPoscmn where HoldNo = " + OnHold + "");
        }
        public Task<int> DeletenizPosdtOnHold(short OnHold)
        {
            return _db.ExecuteScalarAsync<int>("Delete From NizPosdet where HoldNo = "+OnHold+"");

        }
        //DownloadDt
        public Task<List<DownloadDt>> GetDownloadList()
        {
            return _db.Table<DownloadDt>().OrderByDescending(x=>x.DownloadId).ToListAsync();
        }
        public Task<DownloadDt> GetDownloadItm(string desc)
        {
            return _db.Table<DownloadDt>().Where(x => x.DownloadDescription == desc && x.IsRunning == true).FirstOrDefaultAsync();
        }
        public Task<int> UpdateDownloadProgress(int Id,int Progress)
        {
            return _db.ExecuteScalarAsync<int>("Update DownloadDt Set Progress = "+Progress+ " where DownloadId = "+Id+" ");
        }
        public Task<int> UpdateDownloadComplete(int Id,bool IsSuccess)
        {
            return _db.ExecuteScalarAsync<int>("Update DownloadDt Set IsCompleted = true,IsRunning = false,IsSuccess = "+IsSuccess+" where DownloadId = " + Id + " ");
        }
        public Task<int> GetProgress(int Id)
        {
            return _db.ExecuteScalarAsync<int>("Select Progress from DownloadDt where DownloadId = "+Id+"");
        }
        public Task<int> DeleteAllDownloadDt()
        {
            return _db.DeleteAllAsync<DownloadDt>();
        }



















        //private const string DbName = "PARSPOSSaleDb.db3";
        //private static string DbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);
        //private SQLiteAsyncConnection _connection;

        //private SQLiteAsyncConnection Database =>
        //    (_connection ??= new SQLiteAsyncConnection(DbPath,
        //        SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));

        //private async Task CreateTableIfNotExist<TTable>() where TTable : class , new()
        //{
        //    await Database.CreateTableAsync<TTable>();
        //}
        //private async Task<AsyncTableQuery<TTable>> GetTableAsync<TTable>() where TTable : class , new()
        //{
        //    await CreateTableIfNotExist<TTable>();
        //    return Database.Table<TTable>();
        //}
        //public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        //{
        //    var table = await GetTableAsync<TTable>();
        //    return await table.ToListAsync();
        //}
        //public async Task<IEnumerable<TTable>>GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        //{
        //    var table = await GetTableAsync<TTable>();
        //    return await table.Where(predicate).ToListAsync();
        //}

        //private async Task<TResult> Execute<TTable, TResult>(Func<Task<TResult>> action) where TTable : class, new()
        //{
        //    await CreateTableIfNotExist<TTable>();
        //    return await action();
        //}
        //public async Task<TTable> GetItemByIdAsync<TTable>(object primaryKey) where TTable : class, new()
        //{
        //    return await Execute<TTable, TTable>(async () => await Database.GetAsync<TTable>(primaryKey));
        //}
        //public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
        //{
        //    return await Execute<TTable, bool>(async () => await Database.InsertAsync(item) > 0);
        //}

        //public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
        //{
        //    await CreateTableIfNotExist<TTable>();
        //    return await Database.UpdateAsync(item) > 0;
        //}
        //public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
        //{
        //    await CreateTableIfNotExist<TTable>();
        //    return await Database.DeleteAsync(item) > 0;
        //}
        //public async Task<bool> DeleteItemByIdAsync<TTable>(object primaryKey) where TTable : class, new()
        //{
        //    await CreateTableIfNotExist<TTable>();
        //    return await Database.DeleteAsync<TTable>(primaryKey) > 0;
        //}

        //public async ValueTask DisposeAsync()
        //{
        //    await _connection?.CloseAsync();
        //}
    }
}
