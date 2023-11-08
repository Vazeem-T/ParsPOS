using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.PermissionAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class AccessControlAttribute : Attribute
    {
        public AccessControlAttribute(string processId)
        {
            _processId = processId;
        }
        public string _processId { get; private set; }

        public bool GetRights()
        {
            return true;
            //userId = "100";
            //var Id = await App.Database.GetId(userId);
            //var User = await App.Database.ReadUniqueUser(userId);
            //if (userId == "Programmer")
            //{
            //    return true;
            //}
            //else if (User.MasterYn == true)
            //{
            //    return true;
            //}
            //else
            //{

            //    return await App.Database.GetRight(Id, _processId);
            //}
        }
    }
}
