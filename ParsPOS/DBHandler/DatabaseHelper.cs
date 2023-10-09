using ParsPOS.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.DBHandler
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _db;
        public DatabaseHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            try
            {
                _db.CreateTableAsync<Invitm>();
                _db.CreateTableAsync<NetworkIP>();
            }
            catch (Exception)
            {
                App.Current.MainPage.DisplayAlert("Alert", "Creating Table...", "OK");
            }
           
        }

        public Task<int> CreateInvItm(Invitm invitm)
        {
            return _db.InsertAsync(invitm);
        }

        public Task<int> CreateNetwork(NetworkIP network)
        {
            return _db.InsertAsync(network);
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

        public Task<Invitm> EntryChk(string barcode)
        {
            return _db.Table<Invitm>().Where(x => x.BarCode == barcode || x.ItemCode == barcode).FirstOrDefaultAsync();
        }
        //Network
        public Task<List<NetworkIP>> GetAllNetwork()
        {
           return _db.Table<NetworkIP>().OrderBy(x=>x.IsConnected).ToListAsync();
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
    }
}
