using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.Services
{
    public class PublicSevices
    {
        public async Task<bool> CheckIfTableExistsAsync(string tableName)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3"));
                var info = await connection.GetTableInfoAsync(tableName);
                return info.Any();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
