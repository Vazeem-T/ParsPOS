using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.PermissionAttributes
{
    public class GetUserRights
    {
        public async Task<bool> GetRights(string userId, string processId)
        {
            var Id = await App.Database.GetId(userId);
            var User = await App.Database.ReadUniqueUser(userId);
            if (userId == "Programmer")
            {
                return true;
            }
            else if (User.MasterYn == true)
            {
                return true;
            }
            else
            {
               
                return await App.Database.GetRight(Id, processId);
            }
        }
    }
}
